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
    internal class RolePrevilegeRepository : BaseRepository, IRolePrevilegeRepository
    {
        // private IDbTransaction _transaction;

        public RolePrevilegeRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(RolePrevilege obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("Update tUtl_RolePrivilege SET IsActive = False, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                    new {  users = by, tgl = DateTime.Now,  userid = by}, transaction: Transaction);
        }

        public async Task<IEnumerable<RolePrevilege>> GetAll()
        {
            return await Connection.GetAllAsync<RolePrevilege>(transaction:Transaction);
        }

        public async Task<RolePrevilege> GetByID(string id)
        {

            var sql = "SELECT A.RoleId, A.GrandId, A.IsGrand, B.MenuId, B.MenuName" +
                                              " FROM tUtl_RolePrivilege A" +
                                              " INNER JOIN tUtl_AppMenu B ON A.MenuId=B.MenuId" +
                                              " WHERE A.RoleId = @roleId";

            IEnumerable<RolePrevilege> oList = await Connection.QueryAsync<RolePrevilege, Menu, RolePrevilege>(sql, (rp, m) =>
            {
                rp.MenuId = m.MenuId; rp.Menu = m;
                return rp;
            }, new {roleId = id}, splitOn: "MenuId");

            return await Connection.QueryFirstOrDefaultAsync("SELECT * FROM tUtl_RolePrivilege WHERE RoleId = @id", new {id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<RolePrevilege>> GetByID2(string id)
        {
            var sql = "SELECT A.RoleId, A.GrandId, A.IsGrand, B.MenuId, B.MenuName" +
                                              " FROM tUtl_RolePrivilege A" +
                                              " INNER JOIN tUtl_AppMenu B ON A.MenuId=B.MenuId" +
                                              " WHERE A.RoleId = @roleId";

            IEnumerable<RolePrevilege> oList = await Connection.QueryAsync<RolePrevilege, Menu, RolePrevilege>(sql, (rp, m) =>
            {
                rp.MenuId = m.MenuId; rp.Menu = m;
                return rp;
            }, new {roleId = id}, transaction:Transaction, splitOn: "MenuId");

            return oList;
            // return await Connection.QueryFirstOrDefaultAsync("SELECT * FROM tUtl_RolePrivilege WHERE RoleId = @id", new {id = id}, transaction:Transaction);
        }

        public async Task<IEnumerable<RolePrevilege>> GetByID3(string id, string menuid)
        {
             var sql = "SELECT A.RoleId, A.GrandId, A.IsGrand, B.MenuId, B.MenuName" +
                                              " FROM tUtl_RolePrivilege A" +
                                              " INNER JOIN tUtl_AppMenu B ON A.MenuId=B.MenuId" +
                                              " WHERE A.RoleId = @roleId and A.MenuId = @menu";

            IEnumerable<RolePrevilege> oList = await Connection.QueryAsync<RolePrevilege, Menu, RolePrevilege>(sql, (rp, m) =>
            {
                rp.MenuId = m.MenuId; rp.Menu = m;
                return rp;
            }, new {roleId = id, menuid}, transaction:Transaction, splitOn: "MenuId");

            return oList;
        }

        public async Task<RolePrevilege> Save(RolePrevilege obj)
        {
            var dt = new RolePrevilege();
            await Connection.InsertAsync<RolePrevilege>(obj, transaction:Transaction);
            return dt;
        }

        public Task Update(RolePrevilege obj)
        {
            throw new System.NotImplementedException();
        }
    }
}