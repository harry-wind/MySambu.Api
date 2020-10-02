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
    internal class ItemCategoryRepository : BaseRepository, IItemCategoryRepository
    {
        public ItemCategoryRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public Task Delete(ItemCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemCategory SET IsActive = false, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate WHERE CategoryGUID = @CategoryGUID",
                    new{UpdatedBy = by, UpdatedDate = DateTime.Now,  CategoryGUID = id}, transaction:Transaction
            );
        }

        public async Task<IEnumerable<ItemCategory>> GetAll()
        {
            return await Connection.GetAllAsync<ItemCategory>(transaction:Transaction);
        }

        public async Task<ItemCategory> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemCategory>("Select * FROM tMst_ItemCategory where CategoryGUID = @id", new { id = id}, transaction: Transaction);
        }

        public async Task Save(ItemCategory obj)
        {
            await Connection.InsertAsync<ItemCategory>(obj, transaction: Transaction);
        }

        public async Task Update(ItemCategory obj)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemCategory SET RevisionNo = RevisionNo + 1, CategoryName = @CategoryName, ACCID = @ACCID, NotJurnalIND = @NotJurnalIND, RekeningJurnal = @RekeningJurnal, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate WHERE CategoryGUID = @CategoryGUID",
                    new { CategoryName = obj.CategoryName, ACCID = obj.ACCID, NotJurnalIND = obj.NotJurnalIND, RekeningJurnal = obj.RekeningJurnal , UpdatedBy = obj.CreatedBy, UpdatedDate = DateTime.Now, CategoryGUID = obj.CategoryGUID }, transaction: Transaction);
        }
    }
}






