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
    public class PPBBuyController : ControllerBase
    {
        
        private static readonly ILog _log = LogManager.GetLogger(typeof(PPBBuyController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public PPBBuyController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }    

        [Authorize(Policy="RequireAdmin")]
        [HttpPost("GetBy")]
        public async Task<IActionResult> GetBy(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            PPBBuyGetDataDto dts = new PPBBuyGetDataDto();
            try
            {
                var dt = await _uow.PPBBuyRepository.GetListPPBUy(dts);
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