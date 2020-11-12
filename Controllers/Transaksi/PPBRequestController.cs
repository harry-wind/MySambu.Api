using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.DTO.Transaksi.PPB;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Transaksi
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class PPBRequestController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(BudgetTargetController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public PPBRequestController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }    

        [Authorize(Policy="RequireAdmin")]
        [HttpGet("GetItemBudget")]
        public async Task<IActionResult> GetItemBudget(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string Role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            
            try
            {
                var dt = await _uow.PPBRequestRepository.GetAll(Role);
                _uow.Commit();
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
        [HttpPost("GetPPBRequest")]
        public async Task<IActionResult> GetDataPPBRequest(PPBRequestGetDto data){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string Role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            
            try
            {
                var dt = await _uow.PPBRequestRepository.GetPPBRequest(data);
                _uow.Commit();
                // dt = dt.OrderByDescending(f => f.);
               
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
        public async Task<IActionResult> Save(PPBRequestDto dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.PPBGUID = _uow.GetGUID();
                dt.CreatedBy = userby;
                foreach(var dtx in dt.PPBRequestDtl){
                    if(dtx.PPBDtlRequestGUID == null)
                        dtx.PPBDtlRequestGUID = _uow.GetGUID();
                    // if(dtx.BudgetItemGuid == null)
                    //     dtx.BudgetItemGuid = _uow.GetGUID();
                }
                
                await _uow.PPBRequestRepository.Save(dt);
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<PPBRequestDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<PPBRequestDto>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st, Results = dt});
            }
        }



        
    }
}