using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemVariantValueRepository : BaseRepository, IItemVariantValueRepository
    {
        // private IDbTransaction _transaction;

        public ItemVariantValueRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(ItemVariantValue obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ItemVariantValue>> GetAll()
        {
            return await Connection.GetAllAsync<ItemVariantValue>(transaction:Transaction);
        }

        public Task<ItemVariantValue> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ItemVariantValue>> GetByType(string id)
        {
            return await Connection.QueryAsync<ItemVariantValue>("SELECT * FROM tMst_ItemVariantValue where VariantTypeID = @id", new{id=id}, transaction:Transaction);
        }

        public async Task<ItemVariantValue> Save(ItemVariantValue obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemVariantValue>("pMst_ItemVariantValue", new
            {
                VariantValueID = obj.VariantValueID,
                VariantValueName = obj.VariantValueName,
                VariantTypeID = obj.VariantTypeID,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(ItemVariantValue obj)
        {
            throw new System.NotImplementedException();
        }
    }
}