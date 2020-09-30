using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(IDbTransaction transaction) : base(transaction)
        {
     
        }

        public Task Delete(Country obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var data = await Connection.GetAllAsync<Country>(transaction:Transaction);
            return data;
        }

        public Task<Country> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Save(Country obj)
        {
            await Connection.QueryAsync("pMst_CountrySave", new
            {
                CountryID = obj.CountryId,
                CountryName = obj.CountryName,
                CountryIDD = obj.CountryIdd,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);
        }

        public Task Update(Country obj)
        {
            throw new System.NotImplementedException();
        }
    }
}