using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySambu.Api.DTO.Utility;
using MySambu.Api.Models;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Utility
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(AuthController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public AuthController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        [Authorize(Policy="RequireAdmin")] 
        [HttpPost("Save")]
        public async Task<IActionResult> Register(UserRegisterDto userDto){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            userDto.UserId = userDto.UserId.ToLower();

            try
            {
                var flag = await _uow.AuthRepository.UserExists(userDto.UserId);
                if(flag){
                    var st = StTrans.SetSt(400, 0, "User Sudah Di Buat");
                    return Ok(new{Status = st});
                }

                User user = new User {
                    UserGuid = _uow.GetGUID(),
                    UserId = userDto.UserId,
                    RoleId = userDto.RoleId,
                    EmployeeId = userDto.EmployeeId,
                    UserName = userDto.UserName,
                    Password = userDto.Password,
                    PasswordKey = _uow.GetGUID(),
                    IsActive = true,
                    StatusUser = userDto.StatusUser,
                    // CreatedBy = userby,
                    CreatedDate = DateTime.Now,
                    Computer = userDto.Computer,
                    ComputerDate = DateTime.Now
                };

                var usercreate = await _uow.AuthRepository.Register(user);
                var st2 = StTrans.SetSt(200, 0, "User Berhasil Di Buat");
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<User>(user);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                return Ok(new{Status = st2, Results = usercreate});

            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                 log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<UserRegisterDto>(userDto);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(User cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
               await _uow.AuthRepository.Update(cur);
               _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<User>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
               _log.Info("Succes Update");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Results = cur});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<User>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        // 
        [Authorize(Policy="RequireAdmin")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
               await _uow.AuthRepository.ChangePassword(cur.userID, cur.PasswordOld, cur.PasswordNew);
               _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<UserChangePasswordDto>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
               _log.Info("Succes Update");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Results = cur});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<UserChangePasswordDto>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            try
            {
                var dt = await _uow.AuthRepository.Login(userDto.UserId.ToLower(), userDto.Password);
                UserLoginInfoDto users = new UserLoginInfoDto{
                    LoginAutoID = _uow.GetGUID(),
                    LoginDateTime = DateTime.Now,
                    LoginID = userDto.UserId.ToLower(),
                    ComputerName = userDto.Computer,
                    LoginType = "O",
                    AppVersion = userDto.AppVersion,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                
                await _uow.AuthRepository.Login(users);
                
                if (dt == null)
                    return Unauthorized();

                dt.Role = await _uow.RoleRepository.GetByID(dt.RoleId);
                dt.Token = GenerateJwtToken(dt);
                dt.RolePrivileges = await _uow.RolePrevilegeRepository.GetByID2(dt.RoleId);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "User Berhasil Login");
                log4net.LogicalThreadContext.Properties["User"] = userDto.UserId;
                _log.Info("Telah Login");
                return Ok(new{Status = st, Results = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["User"] = userDto.UserId;
                _log.Error("Error", e);
                return Ok(new{Status = st});
            }
        }

        [AllowAnonymous]
        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetByID(string id){
            try
            {
                var dt = await _uow.AuthRepository.GetByID(id);
                var st = StTrans.SetSt(200, 0, "User Berhasil Login");
                // log4net.LogicalThreadContext.Properties["User"] = userDto.UserId;
                // _log.Info("Telah Login");
                return Ok(new{Status = st, Results = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                // log4net.LogicalThreadContext.Properties["User"] = userDto.UserId;
                _log.Error("Error", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.AuthRepository.GetAll();
                _uow.Commit();
               
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }

        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserGuid),
                new Claim(ClaimTypes.Name, user.UserId),
                new Claim(ClaimTypes.Role, user.RoleId),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}