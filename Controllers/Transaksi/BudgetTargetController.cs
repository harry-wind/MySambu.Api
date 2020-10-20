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
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Transaksi
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class BudgetTargetController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(BudgetTargetController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public BudgetTargetController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BudgetTargetHdrDto dt)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.BudgetHdrGuid = _uow.GetGUID();
                dt.BudgetPeriod = new DateTime(dt.BudgetPeriod.Year, dt.BudgetPeriod.Month, 1);
                dt.CreatedBy = userby;
                long deptguid = 0; string guid = "";
                dt.BudgetTargetItem = dt.BudgetTargetItem.OrderBy(r => r.DeptId).ToList();
                foreach (var data in dt.BudgetTargetItem)
                {
                    if (deptguid != data.DeptId)
                    {
                        guid =  _uow.GetGUID();
                        deptguid = data.DeptId;
                    }
                    
                    data.BudgetDeptGuid = guid;
                    data.BudgetCatGuid = _uow.GetGUID();
                }
                var dts = await _uow.BudgetTargetRepository.Save(dt);
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetTargetHdrDto>(dts);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");

                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new { Status = st, Results = dts });

            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetTargetHdrDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new { Status = st });
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdatedCountry(BudgetTargetHdrDto dt)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.CreatedBy = userby;
               

                await _uow.BudgetTargetRepository.Save(dt);

                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetTargetHdrDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");


                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new { Status = st, Results = dt });

            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<BudgetTargetHdrDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new { Status = st });
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.BudgetTargetRepository.GetAllTarget();
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new { Status = st, Results = dt });
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new { Status = st });
            }

        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetByPeriodID")]
        public async Task<IActionResult> GetByPeriodID(string id)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.BudgetTargetRepository.GetByIDs(id);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new { Status = st, Results = dt });
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new { Status = st });
            }

        }
    }
}