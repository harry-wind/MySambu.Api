using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Models.Transaksi.BudgetItem;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBudgetItemRepository
    {
        Task<IEnumerable<BudgetCategoryTrn>> GetBudgetByDept(BudgetByDeptDto inp);

        Task SaveBudget(List<BudgetItem> item);
    }
}