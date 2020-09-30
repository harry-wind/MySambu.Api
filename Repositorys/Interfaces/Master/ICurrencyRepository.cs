using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Controllers.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface ICurrencyRepository : IBaseRepository<Currency>
    {
        Task SaveRate(IEnumerable<CurrencyRates> dt);
        Task UpdateRate(IEnumerable<CurrencyRates> dt);
        Task<IEnumerable<CurrencyRates>> GetListCurrencyRate();
        Task<IEnumerable<CurrencyRates>> GetListCurrencyRateBydate(DateTime tgl);
    }
}