using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class TransTypeRepository : BaseRepository, ITransTypeRepository
    {
        // private IDbTransaction _transaction;0

        public TransTypeRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(TransType obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TransType>> GetAll()
        {
            return await Connection.GetAllAsync<TransType>(transaction:Transaction);
        }

        public Task<TransType> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(TransType obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(TransType obj)
        {
            throw new System.NotImplementedException();
        }
    }
}