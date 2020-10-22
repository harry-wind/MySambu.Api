using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces.Master;

namespace MySambu.Api.Repositorys.implements.Master
{
    public class MainProductCategoryRepository : BaseRepository, IMainProductCategoryRepository
    {

        public MainProductCategoryRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
        
        public Task Delete(MainProductCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MainProductCategory>> GetAll()
        {
            return await Connection.GetAllAsync<MainProductCategory>(transaction:Transaction);
        }

        public Task<MainProductCategory> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<MainProductCategory> Save(MainProductCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(MainProductCategory obj)
        {
            throw new System.NotImplementedException();
        }
    }
}