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
    public class CurrencyRateController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CurrencyRateController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public CurrencyRateController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Save")]
        public async Task<IActionResult> Save(IEnumerable<CurrencyRates> cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                await _uow.CurrencyRepository.SaveRate(cur);
                _uow.Commit();
                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<IEnumerable<CurrencyRates>>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
               
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Result = cur});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<IEnumerable<CurrencyRates>>(cur);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(IEnumerable<CurrencyRates> cur){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
               await _uow.CurrencyRepository.UpdateRate(cur);
               _uow.Commit();
               _log.Info("Succes Update");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Results = cur});
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
        [HttpGet("GetListCurrencyRateByDate")]
        public async Task<IActionResult> GetListCurrencyRateByDate(DateTime tgl){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
               var data = await _uow.CurrencyRepository.GetListCurrencyRateBydate(tgl);
               _uow.Commit();
            //    _log.Info("Succes Update");
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Results = data});
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