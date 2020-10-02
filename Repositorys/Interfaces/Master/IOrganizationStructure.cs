using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Dto.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces.Master
{
    public interface IOrganizationStructureRepository : IBaseRepository<OrganizationStructure>
    {
        Task Remove(int structureId);
        Task<OrganizationStructure> GetOrganizationStructureById(int structureId);
        Task<IEnumerable<StructureLevelModel>> GetListStructureLevel();
        Task<IEnumerable<CompanyDto>> GetListCompany();
        Task<IEnumerable<DivisionDto>> GetListDivision(int companyId);
        Task<IEnumerable<DepartmentDto>> GetListDept(int companyId);
        Task<IEnumerable<SubDeptDto>> GetListSubDept(int companyId);
    }
}