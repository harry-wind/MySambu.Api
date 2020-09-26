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
        public AuthRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task<bool> ChangePassword(string username, string passwordold, string passwordnew)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(User obj)
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

        public Task Save(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}