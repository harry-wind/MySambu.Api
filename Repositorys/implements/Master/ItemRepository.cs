using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.DTO.Master;
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
            // return await Connection.GetAllAsync<Item>(transaction:Transaction);
            return await Connection.QueryAsync<Item>("SELECT * FROM tMst_Item where IsActive = 0", transaction:Transaction);
        }

        public async Task<IEnumerable<Item>> GetAllByPage(ItemPageDto itemPageDto)
        {
            var pc = await Connection.ExecuteScalarAsync("Select dbo.fcMst_GetItemPageCount (@RowsOfPage)", new {RowsOfPage = itemPageDto.RowsOfPage}, transaction: Transaction);
            var data =  new
            {
                PageNumber = itemPageDto.PageNumber,
                RowsOfPage = itemPageDto.RowsOfPage,
                PageCount = pc
            };
            var dt = await Connection.QueryAsync<Item>("pMst_GetItem", data, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
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

        public async Task<int> GetPageCount(int rowOfpage)
        {
            return (int)await Connection.ExecuteScalarAsync("Select dbo.fcMst_GetItemPageCount (@RowsOfPage)", new {RowsOfPage = rowOfpage}, transaction: Transaction);
        }
    }
}