using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Models.Transaksi.BudgetItem;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class BudgetItemRepository : BaseRepository, IBudgetItemRepository
    {
        // private IDbTransaction _transaction;

        public BudgetItemRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public async Task<IEnumerable<BudgetCategoryTrn>> GetBudgetByDept(BudgetByDeptDto inp)
        {
            return await Connection.QueryAsync<BudgetCategoryTrn>("Select * FROM vw_TrnBudgetTarget where DeptID = @DeptID AND BudgetPeriod = @BudgetPeriod", inp, transaction:Transaction);
        }

        public Task SaveBudget(List<BudgetItem> item)
        {
            throw new System.NotImplementedException();
        }
    }
}