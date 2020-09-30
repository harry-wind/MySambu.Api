using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemUOMRepository : BaseRepository, IItemUOMRepository
    {
        public ItemUOMRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
    }
}