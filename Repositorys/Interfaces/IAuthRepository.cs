using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.Models;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IAuthRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
        Task<User> Login(string username, string password);
        Task<bool> ChangePassword(string username, string passwordold, string passwordnew);
        Task<bool> NonActiveUser(string username);
    }
}