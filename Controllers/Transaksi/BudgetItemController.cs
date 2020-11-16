using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.DTO.Master;
using MySambu.Api.DTO.Transaksi;
using MySambu.Api.DTO.Transaksi.BudgetItem;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Models.Transaksi.BudgetItem;
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
        [HttpGet("GetAll/{param}")]
        public async Task<IActionResult> GetAll(int param){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string Role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            
            try
            {
                var dt = await _uow.BudgetItemRepository.GetAll(Role, param);

                dt = dt.ToList();
                _uow.Commit();
               

                foreach(var data in dt){
                    if(data.BudgetItems != null){
                        foreach(var dt2 in data.BudgetItems){
                                if(dt2 != null)
                                    dt2.BudgetCatGuid = data.BudgetCatGuid;
                        }
                    }
                }

                dt = dt.OrderByDescending(f => f.BudgetPeriod);

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

        
        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BudgetItemHdrDto dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                
                foreach(var dtx in dt.BudgetItems){
                    dtx.CreatedBy = userby;
                    if(dtx.BudgetItemGuid == null)
                        dtx.BudgetItemGuid = _uow.GetGUID();
                }
                
                await _uow.BudgetItemRepository.SaveBudget(dt);
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetItemHdrDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetItemHdrDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st, Results = dt});
            }
        }

        // [Authorize(Policy="RequireAdmin")]
        // [HttpPost("Update")]
        // public async Task<IActionResult> UpdatedCountry(BudgetHdr dt){
        //     string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        //     try
        //     {
        //         dt.CreatedBy = userby;
        //         foreach(var data in dt.BudgetDept){
        //             data.CreatedBy = userby;
        //             foreach(var dd in data.BudgetCategory){
        //                 dd.CreatedBy = userby;
        //             }
        //         }
                
        //         await _uow.BudgetTargetRepository.Update(dt);
               
        //         _uow.Commit();

        //         log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dt);
        //         log4net.LogicalThreadContext.Properties["User"] = userby;
        //         _log.Info("Succes Save");
                
                
        //         var st = StTrans.SetSt(200, 0, "Succes");
        //         return Ok(new{Status = st, Results = dt});
        
        //     }
        //     catch (System.Exception e)
        //     {
        //         var st = StTrans.SetSt(400, 0, e.Message);
        //         _uow.Rollback();

        //         log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetHdr>(dt);
        //         log4net.LogicalThreadContext.Properties["User"] = userby;
        //         _log.Error("Error : ", e);
        //         return Ok(new{Status = st});
        //     }
        // }

      
        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Approval")]
        public async Task<IActionResult> Approval(List<BudgetItemApprovHdrDto> param){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string Role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            
            try
            {
                await _uow.BudgetItemRepository.ApprovalBudget(param);
                _uow.Commit();
               
                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<List<BudgetItemApprovHdrDto>>(param);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                 _log.Info("Succes Approv");
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = param});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<List<BudgetItemApprovHdrDto>>(param);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }

        }
    }
}