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
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class BudgetCategoryController : ControllerBase
    {
         private static readonly ILog _log = LogManager.GetLogger(typeof(BudgetCategoryController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public BudgetCategoryController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BudgetCategory dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.BudgetCategoryID = 0;
                dt.CreatedBy = userby;
                dt.CreatedDate = DateTime.Now;
                var dts = await _uow.BudgetCategoryRepository.Save(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetCategory>(dts);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dts});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetCategory>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("SaveAccess")]
        public async Task<IActionResult> SaveAccess(IEnumerable<BudgetAccessDto> dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                await _uow.BudgetCategoryRepository.SaveBudgetAccess(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<IEnumerable<BudgetAccessDto>>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<IEnumerable<BudgetAccessDto>>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdatedCountry(BudgetCategory dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.CreatedBy = userby;
                dt.CreatedDate = DateTime.Now;
                await _uow.BudgetCategoryRepository.Save(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetCategory>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetCategory>(dt);
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