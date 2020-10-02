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

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto){
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
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
                // log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                return Ok(new{Status = st2, Results = usercreate});

            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                // log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error", e);
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