using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IItemUOMRepository : IBaseRepository<ItemUOM>
    {
        Task<IEnumerable<ItemUOM>> GetByStatus(bool st);
    }
}