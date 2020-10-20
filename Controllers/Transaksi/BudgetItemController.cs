using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Transaksi
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class BudgetItemController : ControllerBase
    {
         private static readonly ILog _log = LogManager.GetLogger(typeof(BudgetItemController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public BudgetItemController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BudgetHdr dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.BudgetHdrGuid = _uow.GetGUID();
                dt.BudgetPeriod = new DateTime(dt.BudgetPeriod.Year, dt.BudgetPeriod.Month, 1); 
                dt.CreatedBy = userby;
                foreach(var data in dt.BudgetDept){
                    data.BudgetDeptGuid = _uow.GetGUID();
                    data.BudgetHdrGuid = dt.BudgetHdrGuid;
                    data.CreatedBy = userby;
                    foreach(var dd in data.BudgetCategory){
                        dd.BudgetCatGuid = _uow.GetGUID();
                        dd.BudgetDeptGuid = data.BudgetDeptGuid;
                        dd.CreatedBy = userby;
                    }
                }
                
                var dts = await _uow.BudgetTargetRepository.Save(dt);
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dts);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dts});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdatedCountry(BudgetHdr dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.CreatedBy = userby;
                foreach(var data in dt.BudgetDept){
                    data.CreatedBy = userby;
                    foreach(var dd in data.BudgetCategory){
                        dd.CreatedBy = userby;
                    }
                }
                
                await _uow.BudgetTargetRepository.Update(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
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
                var dt = await _uow.BudgetCategoryRepository.GetAll();
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