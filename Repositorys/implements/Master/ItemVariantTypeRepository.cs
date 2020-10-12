using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemVariantTypeRepository : BaseRepository, IItemVariantTypeRepository
    {
        // private IDbTransaction _transaction;

        public ItemVariantTypeRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;1
        }

        public Task Delete(ItemVariantType obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ItemVariantType>> GetAll()
        {
            return await Connection.GetAllAsync<ItemVariantType>(transaction:Transaction);
        }

        public Task<ItemVariantType> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemVariantType> Save(ItemVariantType obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<ItemVariantType>("pMst_ItemVariantType", new
            {
                VariantTypeID = obj.VariantTypeID,
                VariantTypeName = obj.VariantTypeName,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(ItemVariantType obj)
        {
            throw new System.NotImplementedException();
        }
    }
}