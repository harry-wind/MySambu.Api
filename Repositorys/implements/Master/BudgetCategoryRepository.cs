using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class BudgetCategoryRepository : BaseRepository, IBudgetCategoryRepository
    {
        // private IDbTransaction _transaction;

        public BudgetCategoryRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(BudgetCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<BudgetCategory>> GetAll()
        {
            return await Connection.GetAllAsync<BudgetCategory>(transaction:Transaction);
        }

        public Task<BudgetCategory> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(BudgetCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(BudgetCategory obj)
        {
            throw new System.NotImplementedException();
        }
    }
}