using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class RoleRepository : BaseRepository, IRoleRepository
    {
        // private IDbTransaction _transaction;

        public RoleRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(Role obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("Update tUtl_Role SET IsActive = False, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                    new {  users = by, tgl = DateTime.Now,  userid = by}, transaction: Transaction);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await Connection.GetAllAsync<Role>(transaction:Transaction);
        }

        public async Task<Role> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<Role>("SELECT * FROM tUtl_Role WHERE RoleId = @id", new {id = id}, transaction:Transaction);
        }

        public async Task Save(Role obj)
        {
            await Connection.InsertAsync<Role>(obj, transaction:Transaction);
        }

        public Task Update(Role obj)
        {
            throw new System.NotImplementedException();
        }
    }
}