using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Transaksi;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class BudgetTargetRepository : BaseRepository, IBudgetTargetRepository
    {
        // private IDbTransaction _transaction;

        public BudgetTargetRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(BudgetHdr obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BudgetHdr>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<BudgetHdr> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BudgetHdr> Save(BudgetHdr obj)
        {
            await Connection.QueryAsync("pTrn_BudgetTargetHdrSave", new
            {
                BudgetHdrGuid = obj.BudgetHdrGuid,
                BudgetPeriod = obj.BudgetPeriod,
                UserID = obj.CreatedBy,
                Computer = obj.Computer,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            foreach(var dt in obj.BudgetDept){
                await Connection.QueryAsync("pTrn_BudgetTargetDeptSave", new
                {
                    BudgetDeptGuid = dt.BudgetDeptGuid,
                    BudgetHdrGuid = obj.BudgetHdrGuid,
                    DeptID = dt.DeptId,
                    UserID = obj.CreatedBy,
                    Computer = obj.Computer,
                    Flag = 0
                }, commandType: CommandType.StoredProcedure, transaction: Transaction);

                foreach(var dts in dt.BudgetCategory){
                    await Connection.QueryAsync("pTrn_BudgetTargetCategorySave", new
                    {
                        BudgetCatGuid = dts.BudgetCatGuid,
                        BudgetDeptGuid = dt.BudgetDeptGuid,
                        BudgetCategoryID = dts.BudgetCategoryID,
                        TotalTarget = dts.TotalTarget,
                        IsComplete = dts.IsComplete,
                        UserID = obj.CreatedBy,
                        Computer = obj.Computer,
                        Flag = 0
                    }, commandType: CommandType.StoredProcedure, transaction: Transaction);
                }
            }

            return obj;
        }

        public async Task Update(BudgetHdr obj)
        {
            await Connection.QueryAsync("UPDATE tTrn_BudgetHdr SET UpdatedBy = @UpdatedBy, UpdatedDate = @UpdatedDate, Computer = @Computer, ComputerDate = @ComputerDate WHERE BudgetHdrGuid = @id", 
                        new {
                            UpdatedBy = obj.UpdatedBy,
                            UpdateDate = DateTime.Now,
                            Computer = obj.Computer,
                            ComputerDate = DateTime.Now,
                            id = obj.BudgetHdrGuid
                        }, transaction:Transaction);
        }
    }
}