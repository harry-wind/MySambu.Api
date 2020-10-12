using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IItemVariantValueRepository : IBaseRepository<ItemVariantValue>
    {
        Task<IEnumerable<ItemVariantValue>> GetByType(string id);
    }
}