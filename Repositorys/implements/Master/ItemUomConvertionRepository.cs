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
           await Connection.QueryAsync("UPDATE tMst_ItemUOMConvertion SET IsActive = false, UpdatedBy = @by, UpdatedDate = @tgl WHERE UOMConvertionID = @id",
                new{ UpdatedBy = by, UpdatedDate = DateTime.Now, id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemUOMConvertion>> GetAll()
        {
            // return await Connection.GetAllAsync<ItemUOMConvertion>(transaction:Transaction);
            return await Connection.QueryAsync<ItemUOMConvertion>("SELECT A.*, B.UOMName as UOMUsageName, C.UOMName as UOMPurchaseName FROM tMst_ItemUOMConvertion A INNER JOIN tMst_ItemUOM B ON A.UOMUsage = B.UOMID INNER JOIN tMst_ItemUOM C ON A.UOMPurchase = C.UOMID",
                transaction:Transaction );
        }

        public async Task<ItemUOMConvertion> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemUOMConvertion>("SELECT * FROM tMst_ItemUOMConvertion WHERE UOMConvertionID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task<ItemUOMConvertion> Save(ItemUOMConvertion obj)
        {
            // await Connection.InsertAsync<ItemUOMConvertion>(obj, transaction:Transaction); pMst_tMst_ItemUOMConvertionSave
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemUOMConvertion>("pMst_tMst_ItemUOMConvertionSave", new
            {
                UOMConvertionID = obj.UOMConvertionID,
                UOMUsage = obj.UOMUsage,
                UOMPurchase = obj.UOMPurchase,
                QntyConvertion = obj.QntyConvertion,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0 
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public async Task Update(ItemUOMConvertion obj)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemUOMConvertion SET UomUsage = @usage, UomPurchase = @purchase, UpdatedBy = @by, UpdatedDate = @tgl WHERE UOMConvertionID = @id",
                new{usage = obj.UOMUsage, purchase = obj.UOMPurchase, UpdatedBy = obj.CreatedBy, UpdatedDate = DateTime.Now, id = obj.UOMConvertionID}, transaction:Transaction);
        }
    }
}