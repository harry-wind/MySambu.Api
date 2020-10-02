using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemSpecRepository : BaseRepository, IItemSpecRepository
    {
        // private IDbTransaction _transaction;

        public ItemSpecRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(ItemSpec obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("Updated tMst_ItemSpec SET IsActive = false, UpdatedBy = @by, UpdatedDate = @tgl WHERE ID = @id ", new { by = by, tgl = DateTime.Now, id = id}, transaction: Transaction);
        }

        public async Task<IEnumerable<ItemSpec>> GetAll()
        {
            return await Connection.GetAllAsync<ItemSpec>(transaction:Transaction);
        }

        public async Task<ItemSpec> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemSpec>("SELECT * FROM tMst_ItemSpec WHERE ID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemSpec>> GetByItem(string itemid)
        {
            return await Connection.QueryAsync<ItemSpec>("SELECT * FROM tMst_ItemSpec WHERE ItemID = @id", new { id = itemid}, transaction:Transaction);
        }

        public async Task Save(ItemSpec obj)
        {
            await Connection.InsertAsync<ItemSpec>(obj, transaction:Transaction);
        }

        public async Task Update(ItemSpec obj)
        {
            await Connection.QueryAsync("Updated tMst_ItemSpec SET DetailSpesifikasi = @spec, UpdatedBy = @by, UpdatedDate = @tgl  WHERE ID = @id ", new { spec = obj.DetailSpesifikasi, by = obj.CreatedBy, tgl = DateTime.Now, id = obj.ID}, transaction: Transaction);
        }
    }
}