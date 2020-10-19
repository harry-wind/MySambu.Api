using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Utility;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IStructureTransAccessRepository : IBaseRepository<StructureTransAccess>
    {
        Task SaveAccess(List<StructureTransAccess> st);
        Task<IEnumerable<StructureTransAccess>> GetByTrans(string id);
    }
}