using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Save(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task Delete(string id, string by);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(string id);
    }
}