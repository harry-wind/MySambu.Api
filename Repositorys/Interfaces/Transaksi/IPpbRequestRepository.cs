using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.BudgetItem;
using MySambu.Api.DTO.Transaksi.PPB;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IPpbRequestRepository
    {
        Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role);
        Task<PPBRequestDto> Save(PPBRequestDto dt);
        Task<IEnumerable<PPBRequestDto>> GetPPBRequest(PPBRequestGetDto dt);
        Task PPBRequestApproveByDept(List<PPBRequestApproveByDeptDto> dtx, string user);
        Task PPBSetPurchase(List<PPBSetPurchaserDto> dt, string user);
    }
}