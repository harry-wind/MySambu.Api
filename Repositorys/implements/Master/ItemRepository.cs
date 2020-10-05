using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemRepository : BaseRepository, IItemRepository
    {
        // private IDbTransaction _transaction;

        public ItemRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(Item obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await Connection.GetAllAsync<Item>(transaction:Transaction);
        }

        public async Task<Item> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<Item>("SELECT * FROM tMst_Item where ItemID = @id", new{id = id}, transaction:Transaction);
        }

        public Task<Item> Save(Item obj)
        {
             throw new System.NotImplementedException();
            // await Connection.QueryAsync("pMst_SupplierSave", new
            // {
                
            // }, commandType: CommandType.StoredProcedure, transaction: Transaction);
        }

        public Task Update(Item obj)
        {
            throw new System.NotImplementedException();
        }
    }
}