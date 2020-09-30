using System;
using System.Collections.Generic;
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
        
        // [Authorize(Policy="RequireAdminRole")]
        [AllowAnonymous]
        [HttpPost("SaveCurrency")]
        public async Task<IActionResult> SaveCurrency(Currency cur){
            try
            {
               await _uow.CurrencyRepository.Save(cur);
               _uow.Commit();
               _log.Info("Succes Save");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Result = cur});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        // [Authorize(Policy="RequireAdminRole")]
        [AllowAnonymous]
        [HttpGet("GetListCurrency")]
        public async Task<IActionResult> GetListCurrency(){
            try
            {
                var dt = await _uow.CurrencyRepository.GetAll();
                _uow.Commit();
               
                var st = StTrans.SetSt(200, 0, "Succes");
                _log.Info("Get Data Country");
                return Ok(new{Status = st, Result = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                // log4net.LogicalThreadContext.Properties["User"] = sup.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }

        }

        // CurrencyRate

        // [Authorize(Policy="RequireAdminRole")]
        [AllowAnonymous]
        [HttpPost("SaveCurrencyRate")]
        public async Task<IActionResult> SaveCurrencyRate(IEnumerable<CurrencyRates> cur){
            try
            {
               await _uow.CurrencyRepository.SaveRate(cur);
               _uow.Commit();
               _log.Info("Succes Save");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Result = cur});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                // log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        // [Authorize(Policy="RequireAdminRole")]
        [AllowAnonymous]
        [HttpPost("UpdateCurrencyRate")]
        public async Task<IActionResult> UpdateCurrencyRate(IEnumerable<CurrencyRates> cur){
            try
            {
               await _uow.CurrencyRepository.UpdateRate(cur);
               _uow.Commit();
               _log.Info("Succes Update");
               
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Result = cur});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                // log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [AllowAnonymous]
        [HttpGet("GetListCurrencyRateByDate")]
        public async Task<IActionResult> GetListCurrencyRateByDate(DateTime tgl){
            try
            {
               var data = await _uow.CurrencyRepository.GetListCurrencyRateBydate(tgl);
               _uow.Commit();
            //    _log.Info("Succes Update");
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Result = data});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                // log4net.LogicalThreadContext.Properties["User"] = cur.CreatedBy;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }



    }
}