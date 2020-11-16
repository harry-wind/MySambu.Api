using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.DTO.Transaksi.BudgetItem;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Models.Transaksi.BudgetItem;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBudgetItemRepository
    {
        Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role, int stat);
        Task SaveBudget(BudgetItemHdrDto item);
        Task ApprovalBudget(List<BudgetItemApprovHdrDto> dt);
    }
}