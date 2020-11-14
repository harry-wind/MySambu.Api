using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.PPB;

namespace MySambu.Api.Repositorys.Interfaces.Transaksi
{
    public interface IPbbBuyRepository
    {
        Task<List<PPBBuyDto>> GetListPPBUy(PPBBuyGetDataDto dt);
    }
}