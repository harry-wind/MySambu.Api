using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.DTO.Transaksi.PPH;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Transaksi
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class PPHController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PPHController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;

        public PPHController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        [Authorize(Policy="RequireAdmin")]
        [HttpGet("GetAlls")]
        public async Task<IActionResult> GetAlls(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;            
            try
            {
                var dt = await _uow.PPHRepository.GetAlls();
                _uow.Commit();                
               
                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpGet("GetAllHeader")]
        public async Task<IActionResult> GetAllHeader(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;            
            try
            {
                var dt = await _uow.PPHRepository.GetAllHeader();
                _uow.Commit();                
               
                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpGet("GetAllDetail")]
        public async Task<IActionResult> GetAllDetail(){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;            
            try
            {
                var dt = await _uow.PPHRepository.GetAllDetail();
                _uow.Commit();                
               
                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpPost("GetByParam")]
        public async Task<IActionResult> GetByParam(PPHParameterDto obj)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.PPHRepository.GetAllByParam(obj);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpGet("GetByHdrGuid")]
        public async Task<IActionResult> GetByHdrGuid(string hdrGuid)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.PPHRepository.GetByGuid(hdrGuid);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpPost("SaveAll")]
        public async Task<IActionResult> SaveAll(PPHDto obj)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                obj.PPHID = 0;
                obj.CreatedBy = userby;
                obj.UpdatedBy = null;
                var dt = await _uow.PPHRepository.SaveAll(obj);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Success");
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
        [HttpPost("UpdateAll")]
        public async Task<IActionResult> UpdateAll(PPHDto obj)
        {
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                obj.CreatedBy = null;
                obj.UpdatedBy = userby;
                var dt = await _uow.PPHRepository.SaveAll(obj);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Success");
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

        [AllowAnonymous]
        [HttpPost("FindAllItem")]
        public async Task<IActionResult> FindAllItem(PPHFindItemParam obj)
        {
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var dt = await _uow.PPHRepository.FindItem(obj);
                _uow.Commit();

                var st = StTrans.SetSt(200, 0, "Success");
                return Ok(new{Status = st, Results = dt});
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();
                // log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

    }
}