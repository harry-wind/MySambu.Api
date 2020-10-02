using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IItemSpecRepository : IBaseRepository<ItemSpec>
    {
        Task<IEnumerable<ItemSpec>>  GetByItem(string itemid);
    }
}