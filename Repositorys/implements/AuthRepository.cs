using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using log4net;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class AuthRepository : BaseRepository, IAuthRepository
    {
        // private IDbTransaction _transaction;
        private ILog _log;
        public AuthRepository(IDbTransaction transaction, ILog log) : base(transaction)
        {
            // _transaction = transaction;
            _log = log;
        }

        public Task<bool> ChangePassword(string username, string passwordold, string passwordnew)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> NonActiveUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Save(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}