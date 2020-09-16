using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySambu.Api.Models;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class AuthRepository : IAuthRepository
    {
        private IDbTransaction _transaction;

        public AuthRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<bool> ChangePassword(string username, string passwordold, string passwordnew)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
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

        public Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}