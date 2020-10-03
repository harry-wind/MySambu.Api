using System.Linq;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces.Master;
using Dapper.Contrib.Extensions;
using MySambu.Api.Dto.Master;
using Dapper;
using MySambu.Api.DTO.Master;

namespace MySambu.Api.Repositorys.implements.Master
{
    public class OrganizationStructureRepository : BaseRepository, IOrganizationStructureRepository
    {
        public OrganizationStructureRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
        
        public Task Delete(OrganizationStructure obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<OrganizationStructure>> GetAll()
        {
            var result = await Connection.GetAllAsync<OrganizationStructure>(transaction: Transaction);
            return result;
        }

        public async Task<OrganizationStructure> GetOrganizationStructureById(int structureId)
        {
            var sql = @"Select * From tMst_OrganizationStructure where StructureId=@structureId";
            var orgs = await Connection.QueryFirstOrDefaultAsync<OrganizationStructure>(sql, new {structureId}, transaction: Transaction);
            return orgs;
        }

        public async Task<IEnumerable<CompanyDto>> GetListCompany()
        {
            string sql = @"Select * From vwMst_StructureCompany ";
            var result = await Connection.QueryAsync<CompanyDto>(sql, transaction : Transaction);
            return result;
        }

        public async Task<IEnumerable<DepartmentDto>> GetListDept(int companyId)
        {
            string sql = @"Select * From vwMst_StructureDepartment Where CompanyId=@companyId";
            var result = await Connection.QueryAsync<DepartmentDto>(sql, new {CompanyId = companyId}, transaction : Transaction);
            return result;
        }

        public async Task<IEnumerable<DivisionDto>> GetListDivision(int companyId)
        {
            string sql = @"Select * From vwMst_StructureDivision Where CompanyId=@companyId";
            var result = await Connection.QueryAsync<DivisionDto>(sql, new {CompanyId = companyId}, transaction : Transaction);
            return result;
        }

        public async Task<IEnumerable<StructureLevelModel>> GetListStructureLevel()
        {
            var result = await Connection.GetAllAsync<StructureLevelModel>(transaction: Transaction);
            return result;
        }

        public async Task<IEnumerable<SubDeptDto>> GetListSubDept(int companyId)
        {
            string sql = @"Select * From vwMst_StructureSubDepartment Where CompanyId=@companyId";
            var result = await Connection.QueryAsync<SubDeptDto>(sql, new {companyId}, transaction : Transaction);
            return result;
        }

        public async Task Save(OrganizationStructure obj)
        {
            await Connection.InsertAsync<OrganizationStructure>(obj, transaction: Transaction);
        }

        public async Task Update(OrganizationStructure obj)
        {
            var sql = @"Update tMst_OrganizationStructure Set
                    StructureName = @StructureName,
                    StructureAbbr = @StructureAbbr,
                    StructureParentId = @StructureParentId,
                    StructureLevel = @StructureLevel,
                    StructureOrder = @StructureOrder,
                    IsActive = @IsActive,
                    LastUpdatedBy = @LastUpdatedBy,
                    LastUpdatedDate = @LastUpdatedDate
                    WHERE StructureId = @StructureId";

                await Connection.ExecuteAsync(sql, obj, transaction:Transaction);
        }

        public async Task Remove(int structureId)
        {
            await Connection.ExecuteAsync(@"Update tMst_OrganizationStructure Set InActive=1 Where StructureId=@structureId", new {ID = structureId}, transaction:Transaction);
        }

        public Task<OrganizationStructure> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<OrganizationStructureDto>> GetListOrganization()
        {
            var orgs = await Connection.GetAllAsync<OrganizationStructureDto>(transaction: Transaction);

            IList<OrganizationStructureDto> L1 = new List<OrganizationStructureDto>();
            IList<OrganizationStructureDto> L2 = new List<OrganizationStructureDto>();
            IList<OrganizationStructureDto> L3 = new List<OrganizationStructureDto>();
            IList<OrganizationStructureDto> L4 = new List<OrganizationStructureDto>();

            L1 = orgs.Where(o => o.StructureLevel.Equals(1)).ToList();
            L2 = orgs.Where(o => o.StructureLevel.Equals(2)).ToList();
            L3 = orgs.Where(o => o.StructureLevel.Equals(3)).ToList();
            L4 = orgs.Where(o => o.StructureLevel.Equals(4)).ToList();

            IList<OrganizationStructureDto> result = new List<OrganizationStructureDto>();

            foreach (var i3 in L3)
            {
                i3.StructureChild = GetChildren(L4, i3.StructureId);
            }

            foreach (var i2 in L2)
            {
                i2.StructureChild = GetChildren(L3, i2.StructureId);
            }

            foreach (var i1 in L1)
            {                
                i1.StructureChild = GetChildren(L2, i1.StructureId);
                result.Add(i1);                
            }

            return result;
        }

        private IList<OrganizationStructureDto> GetChildren(IList<OrganizationStructureDto> source, int parentId)
        {
            var children = source.Where(x => x.StructureParentId.Equals(parentId)).ToList();
            children.ForEach(x => x.StructureChild.Equals(GetChildren(source, x.StructureId)));
            return children ;
        }
    }
}