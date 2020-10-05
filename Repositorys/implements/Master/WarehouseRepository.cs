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
    internal class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        // private IDbTransaction _transaction;

        public WarehouseRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(Warehouse obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await Connection.GetAllAsync<Warehouse>(transaction:Transaction);
        }

        public Task<Warehouse> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Warehouse> Save(Warehouse obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<Warehouse>("pMst_WarehouseSave", new
            {
                WHSID = obj.WHSID,
                WHSName = obj.WHSName,
                Remark = obj.Remark,
                WHSProduction = obj.WHSProduction,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public async Task SaveWarehouseAccess(IEnumerable<WarehouseAccessDto> dt)
        {
            await Connection.ExecuteAsync("DELETE tMst_WarehouseAccess WHERE StrukturID = @StrukturID", dt, transaction:Transaction);
            await Connection.ExecuteAsync("INSERT INTO tMst_WarehouseAccess(StrukturID, WarehouseID) VALUES (@StrukturID, @WarehouseID)", dt, transaction:Transaction);
        }

        public Task Update(Warehouse obj)
        {
            throw new System.NotImplementedException();
        }
    }
}