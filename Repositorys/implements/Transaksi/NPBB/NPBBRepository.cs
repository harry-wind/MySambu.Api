using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.DTO.Transaksi.NPBB;
using MySambu.Api.DTO.Transaksi.PPB;
using MySambu.Api.Models.Master;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    public class NPBBRepository : BaseRepository, INPBBRepository
    {
        public NPBBRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public async Task<IEnumerable<Currency>> GetDataCur(NPBBGetDto dt)
        {
            return await Connection.QueryAsync<Currency>("pTrn_NPBBGetDept", new {Pcs = dt.Purchaser}, commandType:CommandType.StoredProcedure, transaction:Transaction);
        }

        public async Task<IEnumerable<DeptDto>> GetDataDept(NPBBGetDto dt)
        {
            return await Connection.QueryAsync<DeptDto>("pTrn_NPBBGetDept", new {Pcs = dt.Purchaser}, commandType:CommandType.StoredProcedure, transaction:Transaction);
        }

        public async Task<IEnumerable<PurchaserDto>> GetDataPurchaser()
        {
            return await Connection.QueryAsync<PurchaserDto>("SELECT DISTINCT PLGUpdatedBy FROM tTrn_PPBDtlRequest Status = 3 ORDER BY PLGUpdatedBy");
        }

        public async Task<IEnumerable<Supplier>> GetDataSupplier(NPBBGetDto dt)
        {
            return await Connection.QueryAsync<Supplier>("pTrn_NPBBGetSupplier", new {Pcs = dt.Purchaser}, commandType:CommandType.StoredProcedure, transaction:Transaction);
        }

        public Task<List<PPBBuyDto>> GetListPPBUy(NPBBGetDto dt)
        {
            throw new System.NotImplementedException();
        }
    }
}