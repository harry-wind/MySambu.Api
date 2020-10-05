using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Utility;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetByMenuId(string id);
    }
}