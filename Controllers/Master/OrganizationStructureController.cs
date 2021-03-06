using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Models;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Controllers.Master
{
    [Route("apimysambu/orgs")]
    [ApiController]
    public class OrganizationStructureController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OrganizationStructureController));
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
        [HttpPost("Save")]
        public async Task<IActionResult> SaveOrganizationStructure(OrganizationStructure organization)
        {
            try
            {
                await _uow.OrganizationStructure.Save(organization);
                _uow.Commit();
                _log.Info("Save Success");

                // return Ok(
                //     new {
                //         statusResult = "Success",
                //         messageResult = "Saving Organization Structure Success",
                //         structureId = organization.StructureId
                //     }
                // );

                var st = StTrans.SetSt(200, 0, "Succes");
                return Ok(new{Status = st, Results = organization});
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
        [HttpPut("Update/{structureId}")]
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
                    UpdatedBy = organization.UpdatedBy,
                    UpdatedDate = DateTime.Now
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
        [HttpGet("List")]
        public async Task<IActionResult> OrganizationStructureList()
        {
            var result = await _uow.OrganizationStructure.GetAll();
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
        }

        [AllowAnonymous]
        [HttpGet("ListLevel")]
        public async Task<IActionResult> GetListLevel()
        {
            var result = await _uow.OrganizationStructure.GetListStructureLevel();
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
        }

        [AllowAnonymous]
        [HttpGet("ListCompany")]
        public async Task<IActionResult> GetListCompany()
        {
            var result = await _uow.OrganizationStructure.GetListCompany();
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
        }

        [AllowAnonymous]
        [HttpGet("ListDivision/{companyid}")]
        public async Task<IActionResult> GetListDivision(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListDivision(companyid);
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
        }

        [AllowAnonymous]
        [HttpGet("ListDepartment/{companyid}")]
        public async Task<IActionResult> GetListDepartment(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListDept(companyid);
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
        }

        [AllowAnonymous]
        [HttpGet("ListSubDepartment/{companyid}")]
        public async Task<IActionResult> GetListSubDepartment(int companyid)
        {
            var result = await _uow.OrganizationStructure.GetListSubDept(companyid);
            
            var st = StTrans.SetSt(200, 0, "Succes");
            return Ok(new{Status = st, Results = result});
            
        }
    }
}