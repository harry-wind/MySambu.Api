using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models.Utility;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<IEnumerable<Role>> GetByStatus(bool st);
    }
}