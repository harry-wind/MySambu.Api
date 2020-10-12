using System.Collections.Generic;
using System.Threading.Tasks;
using MySambu.Api.DTO.Utility;
using MySambu.Api.Models;
using MySambu.Api.Models.Utility;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User> Register(User user);
        Task<bool> UserExists(string username);
        Task<User> Login(string username, string password);
        Task Login(UserLoginInfoDto userLoginDto);
        Task<bool> ChangePassword(string username, string passwordold, string passwordnew);
        Task<bool> ChangePassword(string username, string passwordnew);
        Task<bool> NonActiveUser(string username, string by);        
    }
}