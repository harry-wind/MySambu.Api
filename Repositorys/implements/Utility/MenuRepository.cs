using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class MenuRepository : BaseRepository, IMenuRepository
    {

        public MenuRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
    }
}