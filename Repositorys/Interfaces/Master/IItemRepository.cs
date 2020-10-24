using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<Item> Save(Item item, int newItemID);
        Task<IEnumerable<Item>> GetAllByPage(ItemPageDto itemPageDto);
        Task<IEnumerable<Item>> GetByName(string param);
        Task<int> GetPageCount(int rowOfPage);
    }

}