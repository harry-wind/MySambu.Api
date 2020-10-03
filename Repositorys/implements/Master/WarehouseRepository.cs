using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        // private IDbTransaction _transaction;

        public WarehouseRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(Warehouse obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await Connection.GetAllAsync<Warehouse>(transaction:Transaction);
        }

        public Task<Warehouse> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Warehouse obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Warehouse obj)
        {
            throw new System.NotImplementedException();
        }
    }
}