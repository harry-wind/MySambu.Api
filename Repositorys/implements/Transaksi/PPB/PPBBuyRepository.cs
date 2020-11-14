using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.DTO.Transaksi.PPB;
using MySambu.Api.helper;
using MySambu.Api.Repositorys.Interfaces.Transaksi;

namespace MySambu.Api.Repositorys.implements
{
    internal class PPBBuyRepository : BaseRepository, IPbbBuyRepository
    {
        public PPBBuyRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public async Task<List<PPBBuyDto>> GetListPPBUy(PPBBuyGetDataDto dt)
        {
            string sql = "";
            
            sql = SqlQuery.SetCondition(sql, dt.PPBNoQuery);
            sql = SqlQuery.SetCondition(sql, dt.PeriodeQuery);
            sql = SqlQuery.SetCondition(sql, dt.BudgetQuery);
            sql = SqlQuery.SetCondition(sql, dt.DeptQuery);
            sql = SqlQuery.SetCondition(sql, dt.PcsQuery);
            sql = SqlQuery.SetCondition(sql, dt.ItemQuery);
            sql = SqlQuery.SetCondition(sql, dt.CategoryQuery);
            sql = SqlQuery.SetCondition(sql, dt.SubCategoryQuery);
            sql = SqlQuery.SetCondition(sql, dt.SupplierQuery);
            sql = SqlQuery.SetCondition(sql, dt.StatusQuery);

            sql = "Select * FROM vTrn_PPBBuyPLG WHERE RequestStatus in (3,4) " + sql;

            var data = await Connection.QueryAsync<PPBBuyDto>(sql, transaction:Transaction);

            return data.ToList();

        }
    }
}