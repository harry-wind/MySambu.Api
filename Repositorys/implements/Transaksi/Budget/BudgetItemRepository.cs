using System;
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

        public async Task ApprovalBudget(List<BudgetItemApprovHdrDto> dt)
        {
            foreach(var hdr in dt){
                await Connection.QueryAsync("pTrn_BudgetItemApprovHdr", new
                {
                    BudgetCatGuid = hdr.BudgetCatGuid,
                    IsComplete = hdr.IsComplete,
                    UserID = hdr.UserID,
                    Computer = hdr.Computer                    
                }, commandType: CommandType.StoredProcedure, transaction: Transaction);

               if(hdr.IsComplete == true){
                   foreach(var dtl in hdr.DtlApprov){
                        await Connection.QueryAsync("pTrn_BudgetItemApprov", new
                        {
                            BudgetItemGuid = dtl.BudgetItemGuid,
                            Stat = dtl.Stat,
                            UserID = hdr.UserID,
                            Remark = dtl.Remark,
                            Computer = hdr.Computer,
                            LevelApp = dtl.LevelApp
                        }, commandType: CommandType.StoredProcedure, transaction: Transaction);
                   }
               }
           }
            // foreach(var data in dt){
            //   
            // }
        }

        public async Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role, int stat=0)
        {
            var bhdr = new Dictionary<string, BudgetItemHdrDto>();

            // string sql = "SELECT * FROM vw_TrnBudgetTarget where BudgetHdrGuid = @id ORDER BY BudgetPeriod DESC, DeptID, BudgetCategoryID ";
            await Connection.QueryAsync<BudgetItemHdrDto, BudgetDtlItem, BudgetItemHdrDto>("pTrn_BudgetItemGetHdr", (hdr, dtl) =>
            {
                BudgetItemHdrDto biHdr;

                if (!bhdr.TryGetValue(hdr.BudgetCatGuid.ToString(), out biHdr))
                {
                    biHdr = hdr;
                    biHdr.BudgetItems = new List<BudgetDtlItem>();
                    bhdr.Add(biHdr.BudgetCatGuid, biHdr);
                }

                biHdr.BudgetItems.Add(dtl);

                return biHdr;
            }, splitOn: "BudgetItemGuid", param: new{Role=Role, Stat=stat}, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return bhdr.Values;
        }

        public async Task<IEnumerable<BudgetCategoryTrn>> GetBudgetByDept(BudgetByDeptDto inp)
        {
            return await Connection.QueryAsync<BudgetCategoryTrn>("Select * FROM vw_TrnBudgetTarget where DeptID = @DeptID AND BudgetPeriod = @BudgetPeriod", inp, transaction:Transaction);
        }

        public async Task SaveBudget(BudgetItemHdrDto item)
        {
            await Connection.QueryAsync("UPDATE tTrn_BudgetCategory SET IsComplete = @a, UpdatedBy = @b, UpdatedDate = @c, Computer = @d, ComputerDate = @e WHERE BudgetCatGuid = @id",
                    new {a = item.IsComplete, b =  item.CreatedBy, c = DateTime.Now, d = item.Computer, e = DateTime.Now, id = item.BudgetCatGuid}, transaction:Transaction);
                    
            foreach(var dt in item.BudgetItems){
                await Connection.QueryAsync("pTrn_BudgetTargetItemSave", new
                {
                    BudgetItemGuid = dt.BudgetItemGuid,
                    BudgetCatGuid = dt.BudgetCatGuid,
                    ItemSpecID = dt.ItemSpecID,
                    QntyDept = dt.QntyDept,
                    Qnty = dt.Qnty,
                    CurrencyId = dt.CurrencyID,
                    UnitPrice = dt.UnitPrice,
                    ExchangeRateIDR = dt.ExchangeRateIDR,
                    Remark = dt.Remark,
                    UserID = dt.CreatedBy,
                    Computer = dt.Computer,
                    Flag = 0
                }, commandType: CommandType.StoredProcedure, transaction: Transaction);
            }
        }
    }
}