using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<IEnumerable<Country>> GetByStatus(bool IsActive);
    }
}