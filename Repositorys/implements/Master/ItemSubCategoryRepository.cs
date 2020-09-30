using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemSubCategoryRepository : BaseRepository, IItemSubCategoryRepository
    {

        public ItemSubCategoryRepository(IDbTransaction transaction) : base(transaction)
        {
            
        }
    }
}