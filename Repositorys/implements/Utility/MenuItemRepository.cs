using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class MenuItemRepository : BaseRepository, IMenuItemRepository
    {

        public MenuItemRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(MenuItem obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MenuItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<MenuItem> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MenuItem>> GetByMenuId(string id)
        {
            return await Connection.QueryAsync<MenuItem>("SELECT * FROM tUtl_AppMenuItem WHERE MenuId = @id", new{id=id}, transaction:Transaction);
        }

        public Task<MenuItem> Save(MenuItem obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(MenuItem obj)
        {
            throw new System.NotImplementedException();
        }
    }
}