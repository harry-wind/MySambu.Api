using System.Data;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    internal class ItemUomConvertionRepository : BaseRepository, IItemUomConvertionRepository
    {
        public ItemUomConvertionRepository(IDbTransaction transaction) : base(transaction)
        {

        }
    }
}