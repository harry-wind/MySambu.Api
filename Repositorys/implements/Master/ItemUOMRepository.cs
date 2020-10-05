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
    internal class ItemUOMRepository : BaseRepository, IItemUOMRepository
    {
        public ItemUOMRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(ItemUOM obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemUOM SET IsActive = FALSE, UpdatedBy = @by, UpdatedDate = @tgl WHERE UOMID = @id",
                new { by = by, tgl = DateTime.Now, id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemUOM>> GetAll()
        {
            return await Connection.GetAllAsync<ItemUOM>(transaction:Transaction);
        }

        public async Task<ItemUOM> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemUOM>("Select * FROM tMst_ItemUOM where UOMID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemUOM>> GetByStatus(bool st)
        {
            return await Connection.QueryAsync<ItemUOM>("Select * FROM tMst_ItemUOM where IsActive = @id", new { id = st}, transaction:Transaction);
        }

        public async Task<ItemUOM> Save(ItemUOM obj)
        {
            // await Connection.InsertAsync<ItemUOM>(obj, transaction: Transaction);
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemUOM>("pMst_ItemUomSave", new
            {
                UOMID = obj.UOMID,
                UOMName = obj.UOMName,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(ItemUOM obj)
        {
             throw new System.NotImplementedException();
        }
    }
}