using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class MenuRepository : BaseRepository, IMenuRepository
    {

        public MenuRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(Menu obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await Connection.GetAllAsync<Menu>(transaction:Transaction);
        }

        public Task<Menu> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Menu obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Menu obj)
        {
            throw new System.NotImplementedException();
        }
    }
}