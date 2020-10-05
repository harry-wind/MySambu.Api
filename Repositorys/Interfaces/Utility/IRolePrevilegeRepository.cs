using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Utility;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IRolePrevilegeRepository : IBaseRepository<RolePrevilege>
    {
        Task<IEnumerable<RolePrevilege>> GetByID2(string id);
        Task<IEnumerable<RolePrevilege>> GetByID3(string id, string menuid);
    }
}