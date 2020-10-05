using System;
using System.Collections.Generic;
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
    public class CurrencyController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CurrencyController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public CurrencyController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Save")]
        public async Task<IActionResult> Save(Currency cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                await _uow.CurrencyRepository.Save(cur);
                _uow.Commit();
                _log.Info("Succes Save");
               
                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Currency>(cur);
                log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                var st = StTrans.SetSt(200, 0, "Succes Save");
                return Ok(new{Status = st, Results = cur});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Currency>(cur);
                log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Currency cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                await _uow.CurrencyRepository.Save(cur);
                _uow.Commit();
                _log.Info("Succes Save");
               
                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Currency>(cur);
                log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                var st = StTrans.SetSt(200, 0, "Succes Update");
                return Ok(new{Status = st, Results = cur});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Currency>(cur);
                log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
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
                var dt = await _uow.CurrencyRepository.GetAll();
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