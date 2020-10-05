using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse>
    {
        Task SaveWarehouseAccess(IEnumerable<WarehouseAccessDto> dt);
    }
}