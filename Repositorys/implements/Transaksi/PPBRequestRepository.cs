using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySambu.Api.DTO.Transaksi.BudgetItem;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class PPBRequestRepository : IPpbRequestRepository
    {
        private IDbTransaction _transaction;

        public PPBRequestRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public Task<IEnumerable<BudgetItemHdrDto>> GetAll(string Role)
        {
            throw new System.NotImplementedException();
        }
    }
}