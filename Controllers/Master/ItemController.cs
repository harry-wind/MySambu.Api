using System;
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
    public class ItemController : ControllerBase
    {
         private static readonly ILog _log = LogManager.GetLogger(typeof(ItemController));
        private readonly IUnitOfWorks _uow;
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public ItemController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }
        
        [Authorize(Policy="RequireAdmin")]        
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ItemNew dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.NewItemID = 0;
                dt.CreatedBy = userby;
                dt.CreatedDate = DateTime.Now;
                await _uow.ItemNewRepository.Save(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<ItemNew>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<ItemNew>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }


        [Authorize(Policy="RequireAdmin")]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdatedCountry(ItemNew dt){
            string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                dt.CreatedBy = userby;
                dt.CreatedDate = DateTime.Now;
                await _uow.ItemNewRepository.Save(dt);
               
                _uow.Commit();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<ItemNew>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Info("Succes Save");
                
                
                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = dt});
        
            }
            catch (System.Exception e)
            {
                var st = StTrans.SetSt(400, 0, e.Message);
                _uow.Rollback();

                log4net.LogicalThreadContext.Properties["NewValue"] = Logs.ToJson<ItemNew>(dt);
                log4net.LogicalThreadContext.Properties["User"] = userby;
                _log.Error("Error : ", e);
                return Ok(new{Status = st});
            }
        }

        // [Authorize(Policy="RequireAdmin")]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string userby = "fandy";
            try
            {
                var dt = await _uow.ItemRepository.GetAll();
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

        [AllowAnonymous]
        [HttpPost("GetPageCount")]
        public async Task<IActionResult> GetPageCount(int rowOfPage){
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string userby = "fandy";
            try
            {
                var dt = await _uow.ItemRepository.GetPageCount(rowOfPage);
                _uow.Commit();
               
                var st = StTrans.SetSt(200, dt, "Success");
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
        // [AllowAnonymous]
        [HttpPost("GetAllByPage")]
        public async Task<IActionResult> GetAllByPage(ItemPageDto item){
            // string userby = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            string userby = "fandy";
            try
            {
                var dt = await _uow.ItemRepository.GetAllByPage(item);
                int pc = await _uow.ItemRepository.GetPageCount(item.RowsOfPage);          
                _uow.Commit();
               
                var st = StTrans.SetSt(200, pc, "Success");
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