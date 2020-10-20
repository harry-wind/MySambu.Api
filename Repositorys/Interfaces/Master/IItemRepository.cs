using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<IEnumerable<Item>> GetAllByPage(ItemPageDto itemPageDto);
        Task<int> GetPageCount(int rowOfPage);
    }
}