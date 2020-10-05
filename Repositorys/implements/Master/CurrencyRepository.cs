using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
// using Dapper.Bulk;
using Dapper.Contrib.Extensions;
using MySambu.Api.Controllers.Master;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class CurrencyRepository : BaseRepository, ICurrencyRepository
    {
        public CurrencyRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public Task Delete(Currency obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            var data = await Connection.GetAllAsync<Currency>(transaction: Transaction);
            return data;
        }

        public async Task<Currency> Save(Currency obj)
        {
            var data = await Connection.QueryFirstOrDefaultAsync<Currency>("pMst_CurrencySave", new
            {
                CurrencyID = obj.CurrencyId,
                CurrencyName = obj.CurrencyName,
                CurrencySymbol = obj.CurrencySymbol,
                CurrencySayInWords = obj.CurrencySayInWords,
                CurrencySayInWords2 = obj.CurrencySayInWords2,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);
            
            return data;
        }

        public Task Update(Currency obj)
        {
            throw new System.NotImplementedException();
        }

        // Curremcy Rate
        public async Task SaveRate(IEnumerable<CurrencyRates> dt)
        {
            foreach (var data in dt)
            {
                await Connection.InsertAsync<CurrencyRates>(data, transaction: Transaction);
            }
        }

        public async Task UpdateRate(IEnumerable<CurrencyRates> dt)
        {
            foreach (var data in dt)
            {
                await Connection.QueryAsync("UPDATE tMst_CurrencyRate SET CurrencyRate = @l1, LastUpdatedBy = @l2, LastUpdatedDate = @l3 WHERE CurrencyDate = @l4",
                        new { l1 = data.CurrencyRate, l2 = data.UpdatedBy, l3 = data.UpdatedDate, l4 = data.CurrencyDate }, transaction: Transaction);
            }
        }

        public async Task<IEnumerable<CurrencyRates>> GetListCurrencyRate()
        {
            var data = await Connection.QueryAsync<CurrencyRates>("SELECT * FROM tMst_CurrencyRate");
            return data;
        }

        public async Task<IEnumerable<CurrencyRates>> GetListCurrencyRateBydate(System.DateTime tgl)
        {
            var data = await Connection.QueryAsync<CurrencyRates>("SELECT * FROM tMst_CurrencyRate where CurrencyDate = @cur ", new { cur = tgl }, transaction: Transaction);
            return data;
        }

        public Task<Currency> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }
    }
}
