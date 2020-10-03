using System;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
         private static readonly ILog _log = LogManager.GetLogger(typeof(WarehouseController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public WarehouseController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("Save")]
        public async Task<IActionResult> Save(Country count){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                count.CountryId = _uow.GetGUID();
                count.CreatedDate = DateTime.Now;
                await _uow.CountryRepository.Save(count);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = count});
        
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


        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdatedCountry(Country count){
            try
            {
                // count.CountryId = _uow.GetGUID();
                count.CreatedDate = DateTime.Now;
                await _uow.CountryRepository.Save(count);
               
                _uow.Commit();
                _log.Info("Succes Updated");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = count});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["User"] = count.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.WarehouseRepository.GetAll();
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
    }
}