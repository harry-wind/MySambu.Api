using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.DTO.Transaksi.BudgetItem;
using MySambu.Api.DTO.Transaksi.PPB;
using MySambu.Api.helper;
using MySambu.Api.Models.Transaksi.BudgetItem;
using MySambu.Api.Models.Transaksi.PPB;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class PPBRequestRepository : BaseRepository, IPpbRequestRepository
    {
        private IDbTransaction _transaction;

        public PPBRequestRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public async Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role)
        {
            
            var bhdr = new Dictionary<string, BudgetItemHdrDto>();

            // string sql = "SELECT * FROM vw_TrnBudgetTarget where BudgetHdrGuid = @id ORDER BY BudgetPeriod DESC, DeptID, BudgetCategoryID ";
            await Connection.QueryAsync<BudgetItemHdrDto, BudgetDtlItem, BudgetItemHdrDto>("pTrn_PPBRequestGetBudget", (hdr, dtl) =>
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
            }, splitOn: "BudgetItemGuid", param: new{Role=Role}, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return bhdr.Values;
        }

        public async Task<IEnumerable<PPBRequestDto>> GetPPBRequest(PPBRequestGetDto dt)
        {
            string sql = "";
            
            sql = SqlQuery.SetCondition(sql, dt.DeptQuery);
            sql = SqlQuery.SetCondition(sql, dt.PPBNoQuery);
            sql = SqlQuery.SetCondition(sql, dt.DateQuery);
            sql = SqlQuery.SetCondition(sql, dt.ItemQuery);
            
            var bhdr = new Dictionary<string, PPBRequestDto>();
            await Connection.QueryAsync<PPBRequestDto, PPBRequets, PPBRequestDto>(
                "pTrn_PPBRequestGetItem", (hdr, dtl) => {
                    PPBRequestDto biHdr;

                    if (!bhdr.TryGetValue(hdr.PPBGUID.ToString(), out biHdr))
                    {
                        biHdr = hdr;
                        biHdr.PPBRequestDtl = new List<PPBRequets>();
                        bhdr.Add(biHdr.PPBGUID, biHdr);
                    }

                    biHdr.PPBRequestDtl.Add(dtl);

                    return biHdr;
                }, splitOn: "PPBDtlRequestGUID", param: new{Stat=dt.Stat, sqlstatement=sql}, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return bhdr.Values;
        }

        public async Task<PPBRequestDto> Save(PPBRequestDto dt)
        {
            await Connection.QueryAsync("pTrn_PPBHdrSave", new
            {
                PPBGUID = dt.PPBGUID,
                BudgetCatGUID = dt.BudgetCatGUID,
                TransDate = dt.TransDate,
                DeptID = dt.DeptID,
                BudgetCategoryID = dt.BudgetCategoryID,
                UserID = dt.CreatedBy,
                Computer = dt.Computer
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            foreach (var dst in dt.PPBRequestDtl)
            {
                await Connection.QueryAsync("pTrn_PPBRequestDtlSave", new
                {
                    PPBDtlRequestGUID = dst.PPBDtlRequestGUID,
                    PPBGUID = dt.PPBGUID,
                    ItemSpecID = dst.ItemSpecID,
                    QntyReq = dst.QntyReq,
                    CurrencyID = dst.CurrencyID,
                    UnitPrice = dst.UnitPrice,
                    ExchangeRateIDR = dst.ExchangeRateIDR,
                    BSTB = dst.BSTB,
                    Priority = dst.Priority,
                    UsedByDeptID = dst.UsedByDeptID,
                    DeliveryDate = dst.DeliveryDate,
                    Remark = dst.Remark,
                    UserID = dt.CreatedBy,
                    Computer = dt.Computer
                }, commandType: CommandType.StoredProcedure, transaction: Transaction);
            }

            return dt;
        }
    }
}