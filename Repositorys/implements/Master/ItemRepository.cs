using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemRepository : BaseRepository, IItemRepository
    {
        // private IDbTransaction _transaction;

        public ItemRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }
    }
}