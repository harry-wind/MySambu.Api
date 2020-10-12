using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Repositorys.Interfaces;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using System.ComponentModel;
using System.Security.Claims;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(SupplierController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        // private readonly ILog _log;
        private IHttpContextAccessor _httpContext;
        // Status st1 = new Status();
        public SupplierController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            // _log = log;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        [Authorize(Policy="RequireAdmin")]
        // [AllowAnonymous]
        [HttpPost("Save")]
        public async Task<IActionResult> SaveSupplier(Supplier sup){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
               sup.CreatedBy = userby;
               await _uow.SupplierRepository.Save(sup);
               _uow.Commit();
               _log.Info("Succes Save");
               
               log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Supplier>(sup);
               var st = StTrans.SetSt(200, 0, "Succes");
               return Ok(new{Status = st, Results = sup});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<Supplier>(sup);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        [Authorize(Policy="RequireAdmin")]
        // [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.SupplierRepository.GetAll();
                _uow.Commit();
               
               var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                // log4net.LogicalThreadContext.Properties["User"] = sup.CreatedBy;
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }

        }
        
    }
}