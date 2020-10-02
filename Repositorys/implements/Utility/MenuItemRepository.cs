using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class MenuItemRepository : BaseRepository, IMenuItemRepository
    {

        public MenuItemRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
    }
}