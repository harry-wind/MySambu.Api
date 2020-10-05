using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using log4net;
using MySambu.Api.DTO.Utility;
using MySambu.Api.Models;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class AuthRepository : BaseRepository, IAuthRepository
    {
        // private IDbTransaction _transaction;
        public AuthRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public async Task<bool> ChangePassword(string username, string passwordold, string passwordnew)
        {
            var user = await Connection.QueryFirstOrDefaultAsync<User>("Select * FROM tUtl_User WHERE UserId = @userid", new { userid = username }, transaction: Transaction);
            var psold = CreatePasswordHash(passwordold, user.PasswordKey);
            if (user == null || user.Password != psold)
                return false;

            var psnew = CreatePasswordHash(passwordnew, user.PasswordKey);
            await Connection.QueryAsync("Update tUtl_User SET Password = @psnew, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                    new { psnew = psnew, users = username, tgl = DateTime.Now,  userid = username}, transaction: Transaction);

            return true;
        }

        
        public async Task<bool> ChangePassword(string username, string passwordnew)
        {
            var user = await Connection.QueryFirstOrDefaultAsync<User>("Select * FROM tUtl_User WHERE UserId = @userid", new { userid = username }, transaction: Transaction);

            var psnew = CreatePasswordHash(passwordnew, user.PasswordKey);
            await Connection.QueryAsync("Update tUtl_User SET Password = @psnew, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                    new { psnew = psnew, users = username, tgl = DateTime.Now,  userid = username}, transaction: Transaction);

            return true;
        }

        public Task Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Connection.GetAllAsync<User>(transaction: Transaction);
        }


        public async Task<bool> NonActiveUser(string username, string by)
        {
            await Connection.QueryAsync("Update tUtl_User SET IsActive = False, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                    new {  users = by, tgl = DateTime.Now,  userid = username}, transaction: Transaction);

            return true;
        }

        public async Task Update(User obj)
        {
            await Connection.QueryAsync("Update tUtl_User SET RoleId = @RoleId, UserName = @UserName, IsActive = @IsActive, UpdatedBy = @users, UpdatedDate = @tgl Where UserId = @userid",
                new {RoleId = obj.RoleId, UserName = obj.UserName, IsActive = @obj.IsActive, users = obj.CreatedBy,  tgl = DateTime.Now,  userid = obj.UserId }, transaction:Transaction
            );
        }

        public async Task<bool> UserExists(string username)
        {
            if (await Connection.ExecuteScalarAsync<bool>("Select Count(1) From tUtl_User where " +
                            "userId = @userId", new { userId = username }, transaction: Transaction))
                return true;

            return false;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await Connection.QueryFirstOrDefaultAsync<User>("Select * FROM tUtl_User WHERE UserId = @userid", new { userid = username }, transaction: Transaction);

            if (user == null || !VerifyPassword(password, user.Password, user.PasswordKey))
                return (User)null;

            return user;
        }

        private bool VerifyPassword(string pass, string password, string passwordKey)
        {
            var passUser = CreatePasswordHash(pass, passwordKey);

            if (passUser != password)
                return false;

            return true;
        }

        public async Task<User> Register(User user)
        {
            string pass = CreatePasswordHash(user.Password, user.PasswordKey);
            user.Password = pass;
            await this.Save(user);

            return user;
        }

        public async Task<User> Save(User obj)
        {
            await Connection.InsertAsync<User>(obj, transaction: Transaction);
            return null;
        }

        private string CreatePasswordHash(string plainText, string key)
        {
            if (key.Length > 0)
                plainText += key;

            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bs = System.Text.Encoding.UTF8.GetBytes(plainText);
            bs = x.ComputeHash(bs);

            var s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

        public async Task<User> GetByID(string id)
        {
            return await Connection.QueryFirstOrDefaultAsync<User>("Select * FROM tUtl_User WHERE UserId = @userid", new { userid = id }, transaction: Transaction);
        }

        public Task Delete(string id, string by)
        {
            throw new NotImplementedException();
        }

    }
}