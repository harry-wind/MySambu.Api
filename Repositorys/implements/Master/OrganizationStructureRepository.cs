using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces.Master;
using Dapper.Contrib.Extensions;

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