using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Utility;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class TransAccessRepository : BaseRepository, ITransAccessRepository
    {
        

        public TransAccessRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }

        public Task Delete(TransAccess obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TransAccess>> GetAll()
        {
            return await Connection.GetAllAsync<TransAccess>(transaction:Transaction);
        }

        public Task<TransAccess> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TransAccess> Save(TransAccess obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<TransAccess>("pUtl_TransAcces", new
            {
                TransAccessID = obj.TransAccessID,
                TransAccesName = obj.TransAccessName,
                IsActive = obj.IsActive,
                Computer = obj.Computer,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(TransAccess obj)
        {
            throw new System.NotImplementedException();
        }
    }
}