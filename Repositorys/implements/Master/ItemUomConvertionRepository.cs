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
    internal class ItemUomConvertionRepository : BaseRepository, IItemUomConvertionRepository
    {
        public ItemUomConvertionRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public Task Delete(ItemUOMConvertion obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
           await Connection.QueryAsync("UPDATE tMst_ItemUOMConvertion SET IsActive = false, UpdatedBy = @by, UpdatedDate = @tgl WHERE ID = @id",
                new{ UpdatedBy = by, UpdatedDate = DateTime.Now, id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemUOMConvertion>> GetAll()
        {
            return await Connection.GetAllAsync<ItemUOMConvertion>(transaction:Transaction);
        }

        public async Task<ItemUOMConvertion> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemUOMConvertion>("SELECT * FROM tMst_ItemUOMConvertion WHERE ID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task Save(ItemUOMConvertion obj)
        {
            await Connection.InsertAsync<ItemUOMConvertion>(obj, transaction:Transaction);
        }

        public async Task Update(ItemUOMConvertion obj)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemUOMConvertion SET UomUsage = @usage, UomPurchase = @purchase, UpdatedBy = @by, UpdatedDate = @tgl WHERE ID = @id",
                new{usage = obj.UomUsage, purchase = obj.UomPurchase, UpdatedBy = obj.CreatedBy, UpdatedDate = DateTime.Now, id = obj.ID}, transaction:Transaction);
        }
    }
}