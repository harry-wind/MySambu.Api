using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.BudgetItem;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IPpbRequestRepository
    {
        Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role);
    }
}