using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class CompanyProfileRepository : BaseRepository, ICompanyProfileRepository
    {
        // private IDbTransaction _transaction;

        public CompanyProfileRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(CompanyProfile obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CompanyProfile>> GetAll()
        {
            return await Connection.GetAllAsync<CompanyProfile>(transaction:Transaction);
        }

        public async Task<CompanyProfile> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<CompanyProfile>("SELECT * FROM tUtl_CompanyProfile WHERE ProfileId = @id", new {id=id}, transaction:Transaction );
        }

        public Task<CompanyProfile> Save(CompanyProfile obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CompanyProfile obj)
        {
            throw new System.NotImplementedException();
        }
    }
}