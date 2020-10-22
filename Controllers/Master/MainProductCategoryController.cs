using System.Security.Claims;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class MainProductCategoryController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(MainProductCategoryController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;

        public MainProductCategoryController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        // [Authorize(Policy="RequireAdmin")]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string userby = "harry";
            try
            {
                var dt = await _uow.MainProductCategoryRepository.GetAll();
                _uow.Commit();
               
                var st = StTrans.SetSt(200, 1, "Success");
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