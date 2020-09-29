using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces.Master;
using Dapper.Contrib.Extensions;
using MySambu.Api.Dto.Master;
using Dapper;

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

        public async Task<IEnumerable<OrganizationStructure>> GetAll()
        {
            var result = await Connection.GetAllAsync<OrganizationStructure>(transaction: Transaction);
            return result;
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
            await Connection.UpdateAsync<OrganizationStructure>(obj, transaction: Transaction);
        }
    }
}