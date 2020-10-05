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

        public Task<ItemNew> Save(ItemNew obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ItemNew obj)
        {
            throw new System.NotImplementedException();
        }
    }
}