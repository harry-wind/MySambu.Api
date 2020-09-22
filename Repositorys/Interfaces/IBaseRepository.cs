using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> Save(T obj);
        Task<int> Update(T obj);
        Task<int> Delete(T obj);
        Task<IEnumerable<T>> GetAll();
    }
}