using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class StructureTransAccessRepository : BaseRepository, IStructureTransAccessRepository
    {        

        public StructureTransAccessRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(StructureTransAccess obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id, string by)
        {
            await Connection.QueryAsync("DELETE FROM tUtl_StructureManagementTrans WHERE TransAccesID = @id" , new {id = id}, transaction:Transaction);
        }

        

        public Task<IEnumerable<StructureTransAccess>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<StructureTransAccess> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<StructureTransAccess>> GetByTrans(string id)
        {
            return await Connection.QueryAsync<StructureTransAccess>("SELECT * FROM tUtl_StructureManagementTrans WHERE TransAccesID = @id", new {id = id}, transaction:Transaction);
        }

        public Task<StructureTransAccess> Save(StructureTransAccess obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveAccess(List<StructureTransAccess> st)
        {
            await Connection.QueryAsync("Insert Into tUtl_StructureManagementTrans VALUES(@StructureID, @TransAccesID, @CreatedBy, @CreatedDate, @Computer, @ComputerDate)",
                                        st, transaction:Transaction);
        }

        public Task Update(StructureTransAccess obj)
        {
            throw new System.NotImplementedException();
        }
    }
}