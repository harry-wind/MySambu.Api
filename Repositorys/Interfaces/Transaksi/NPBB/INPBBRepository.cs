using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.NPBB;
using MySambu.Api.DTO.Transaksi.PPB;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface INPBBRepository
    {
        Task<IEnumerable<PurchaserDto>> GetDataPurchaser();
        Task<IEnumerable<Supplier>> GetDataSupplier(NPBBGetDto dt);
        Task<IEnumerable<DeptDto>> GetDataDept(NPBBGetDto dt);
        Task<IEnumerable<Currency>> GetDataCur(NPBBGetDto dt);
        Task<List<PPBBuyDto>> GetListPPBUy(NPBBGetDto dt);
        // Task<Supplier> GetDataPPBBuy(NPBBGetDto dt);
        // Task<NPPBFindDto> 
    }
}