using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.Models.Transaksi;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBudgetTargetRepository : IBaseRepository<BudgetHdr>
    {
        Task<BudgetTargetHdrDto> Save(BudgetTargetHdrDto obj);
        Task<IEnumerable<BudgetTargetHdrDto>> GetAllTarget();
        Task<BudgetTargetHdrDto> GetByIDs(string id);
    }
}