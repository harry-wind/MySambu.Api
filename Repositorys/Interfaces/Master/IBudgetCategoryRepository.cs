using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Master;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBudgetCategoryRepository : IBaseRepository<BudgetCategory>
    {
        Task SaveBudgetAccess(IEnumerable<BudgetAccessDto> budget);
    }
}