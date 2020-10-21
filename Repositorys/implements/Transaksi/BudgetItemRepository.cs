using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.DTO.Transaksi.Budget;
using MySambu.Api.DTO.Transaksi.BudgetItem;
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

        public async Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role)
        {
            var bhdr = new Dictionary<string, BudgetItemHdrDto>();

            // string sql = "SELECT * FROM vw_TrnBudgetTarget where BudgetHdrGuid = @id ORDER BY BudgetPeriod DESC, DeptID, BudgetCategoryID ";
            await Connection.QueryAsync<BudgetItemHdrDto, BudgetDtlItem, BudgetItemHdrDto>("pTrn_BudgetItemGetHdr", (hdr, dtl) =>
            {
                BudgetItemHdrDto biHdr;

                if (!bhdr.TryGetValue(hdr.BudgetCatGuid, out biHdr))
                {
                    biHdr = hdr;
                    biHdr.BudgetItems = new List<BudgetDtlItem>();
                    bhdr.Add(biHdr.BudgetCatGuid, biHdr);
                }

                biHdr.BudgetItems.Add(dtl);

                return biHdr;
            }, splitOn: "BudgetItemGuid", param: new{Role=Role}, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return bhdr.Values;
        }

        public async Task<IEnumerable<BudgetCategoryTrn>> GetBudgetByDept(BudgetByDeptDto inp)
        {
            return await Connection.QueryAsync<BudgetCategoryTrn>("Select * FROM vw_TrnBudgetTarget where DeptID = @DeptID AND BudgetPeriod = @BudgetPeriod", inp, transaction:Transaction);
        }

        public Task SaveBudget(List<BudgetDtlItem> item)
        {
            throw new System.NotImplementedException();
        }
    }
}