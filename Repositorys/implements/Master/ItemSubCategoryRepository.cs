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
    internal class ItemSubCategoryRepository : BaseRepository, IItemSubCategoryRepository
    {

        public ItemSubCategoryRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(ItemSubCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("UPDATE tMst_ItemCategory SET IsActive = false , UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate WHERE SubCategoryID = @CategoryGUID", 
                new {UpdatedBy = by, UpdatedDate = DateTime.Now, SubCategoryGUID = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<ItemSubCategory>> GetAll()
        {
            return await Connection.GetAllAsync<ItemSubCategory>(transaction:Transaction);
        }

        public async Task<ItemSubCategory> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<ItemSubCategory>("SELECT * FROM tMst_ItemCategory WHERE SubCategoryID = @id", new { id = id}, transaction:Transaction);
        }

        public async Task<ItemSubCategory> Save(ItemSubCategory obj)
        {
            // await Connection.InsertAsync<ItemSubCategory>(obj, transaction:Transaction);
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemSubCategory>("pMst_ItemSubCategorySave", new
            {
                SubCategoryID = obj.SubCategoryID,
                SubCategoryName = obj.SubCategoryName,
                CategoryID = obj.CategoryID,
                ACCID = obj.ACCID,
                IsActive = obj.IsActive,
                DeptID = obj.DeptID,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0 
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(ItemSubCategory obj)
        {
             throw new System.NotImplementedException();
            // await Connection.QueryAsync("UPDATE tMst_ItemSubCategory SET RevisionNo = RevisionNo + 1, SubCategoryName = @CategoryName, CategoryGUID = @CategoryGUID, CategoryID = @CategoryID, ACCID = @ACCID, UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate WHERE SubCategoryGUID = @SubCategoryID",
            //         new { CategoryName = obj.SubCategoryName, ACCID = obj.ACCID, CategoryGUID = obj.CategoryGUID, CategoryID = obj.CategoryID , UpdatedBy = obj.CreatedBy, UpdatedDate = DateTime.Now, SubCategoryGUID = obj.SubCategoryID }, transaction: Transaction);
        }
    }
}