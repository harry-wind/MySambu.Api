using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/[controller]")]
    [ApiController]
    public class OrganizationStructureController : ControllerBase
    {
        private readonly IUnitOfWorks _uow; 
        private readonly IConfiguration _config;
        public OrganizationStructureController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> OrganizationStructure()
        {
            var result = await _uow.OrganizationStructure.GetAll();
            return Ok(result);
        }
    }
}