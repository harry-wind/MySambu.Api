using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemNewRepository : BaseRepository, IItemNewRepository
    {
        public ItemNewRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(ItemNew obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ItemNew>> GetAll()
        {
            return await Connection.GetAllAsync<ItemNew>(transaction:Transaction);
        }

        public Task<ItemNew> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemNew> Save(ItemNew obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemNew>("pMst_ItemNewSave", new
            {
                NewItemID = obj.NewItemID,
                DeptItemKode = obj.DeptItemCode,
                NewItemName = obj.NewItemName,
                NewItemDesc	= obj.NewItemDesc,
                UOMID = obj.UOMID,
                SubCategoryID =  obj.SubCategoryID,
                CurrencyID	 = obj.CurrencyID,
                UnitPrice = obj.UnitPrice,
                DeptID = obj.DeptID,
                Cancel = obj.Cancel,
                NeedToUpdate = obj.NeedToUpdate,
                PurchasingRemark = obj.PurchasingRemark,
                MemoItemNew = obj.MemoItemNew,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0 
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(ItemNew obj)
        {
            throw new System.NotImplementedException();
        }
    }
}