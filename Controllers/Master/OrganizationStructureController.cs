using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/orgs")]
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

        [AllowAnonymous]
        [HttpGet("list_company")]
        public async Task<IActionResult> GetListCompany()
        {
            var result = await _uow.OrganizationStructure.GetListCompany();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("list_div/{companyid}")]
        public async Task<IActionResult> GetListDivision(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListDivision(companyid);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("list_dept/{companyid}")]
        public async Task<IActionResult> GetListDepartment(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListDept(companyid);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("list_subdept/{companyid}")]
        public async Task<IActionResult> GetListSubDepartment(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListSubDept(companyid);
            return Ok(result);
        }
    }
}