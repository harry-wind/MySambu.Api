using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/orgs")]
    [ApiController]
    public class OrganizationStructureController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OrganizationStructure));
        private readonly IUnitOfWorks _uow; 
        private readonly IConfiguration _config;
        private IHttpContextAccessor _httpContext;
        public OrganizationStructureController(IUnitOfWorks uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
            _httpContext = (IHttpContextAccessor)new HttpContextAccessor();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> OrganizationStructure()
        {
            var result = await _uow.OrganizationStructure.GetListOrganization();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("save")]
        public async Task<IActionResult> SaveOrganizationStructure(OrganizationStructure organization)
        {
            try
            {
                await _uow.OrganizationStructure.Save(organization);
                _uow.Commit();
                _log.Info("Save Success");

                return Ok(
                    new {
                        statusResult = "Success",
                        messageResult = "Saving Organization Structure Success",
                        structureId = organization.StructureId
                    }
                );
            }
            catch (System.Exception ex)
            {
                _uow.Rollback();
                var err = ex.Message.ToString();
                _log.Error("Error : ", ex);

                return BadRequest(new{
                    statusResult = "Failed",
                    messageResult = err,
                    structureId = 0
                });
            }
        }

        [AllowAnonymous]
        [HttpPut("update/{structureId}")]
        public async Task<IActionResult> UpdateOrganizationStructure(OrganizationStructure organization, int structureId)
        {
            try
            {
                var org = new OrganizationStructure {
                    StructureId = structureId,
                    StructureName = organization.StructureName.ToString(),
                    StructureAbbr = organization.StructureAbbr.ToString(),
                    StructureParentId = organization.StructureParentId,
                    StructureLevel = organization.StructureLevel,
                    StructureOrder = organization.StructureOrder,
                    IsActive = organization.IsActive,
                    OldId = organization.OldId,
                    LastUpdatedBy = organization.LastUpdatedBy,
                    LastUpdatedDate = DateTime.Now
                };
                await _uow.OrganizationStructure.Update(org);
                _uow.Commit();
                _log.Info("Update Success");

                return Ok(new{
                    statusResult = "Success",
                    messageResult = "Update Organization Structure Success",
                    structureId = org.StructureId
                });
            }
            catch (System.Exception ex)
            {
                _uow.Rollback();
                var err = ex.Message.ToString();
                _log.Error("Error : ", ex);

                return BadRequest(new{
                    statusResult = "Failed",
                    messageResult = err,
                    structureId = 0
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> OrganizationStructureList()
        {
            var result = await _uow.OrganizationStructure.GetAll();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("list_level")]
        public async Task<IActionResult> GetListLevel()
        {
            var result = await _uow.OrganizationStructure.GetListStructureLevel();
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