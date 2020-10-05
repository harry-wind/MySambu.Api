using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class BudgetCategoryRepository : BaseRepository, IBudgetCategoryRepository
    {
        // private IDbTransaction _transaction;

        public BudgetCategoryRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(BudgetCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<BudgetCategory>> GetAll()
        {
            return await Connection.GetAllAsync<BudgetCategory>(transaction:Transaction);
        }

        public Task<BudgetCategory> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BudgetCategory> Save(BudgetCategory obj)
        {
            var data = await Connection.QueryFirstAsync<BudgetCategory>("pMst_BudgetCategory", new
            {
                BudgetCategoryID = obj.BudgetCategoryID,
                BudgetCategoryName = obj.BudgetCategoryName,
                BudgetCategoryAbbr = obj.BudgetCategoryAbbr,
                IsActive = obj.IsActive,
                IsPPBWithOutBudget = obj.IsPPBWithOutBudget,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return data;
        }

        public async Task SaveBudgetAccess(IEnumerable<BudgetAccessDto> budget)
        {
            await Connection.ExecuteAsync("DELETE tMst_BudgetCategoryAccess WHERE StrukturID = @StrukturID", budget, transaction:Transaction);
            await Connection.ExecuteAsync("INSERT INTO tMst_BudgetCategoryAccess(StrukturID, BudgetCategoryID) VALUES (@StrukturID, @BudgetCategoryID)", budget, transaction:Transaction);
        }

        // pMst_BudgetCategory

        public Task Update(BudgetCategory obj)
        {
            throw new System.NotImplementedException();
        }
    }
}