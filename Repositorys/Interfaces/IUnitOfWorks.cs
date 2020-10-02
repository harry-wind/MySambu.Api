namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IUnitOfWorks
    {
        ILog4NetRepository Log4NetRepository { get; }
        IAuthRepository AuthRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRolePrevilegeRepository RolePrevilegeRepository {get;}
        IMenuRepository MenuRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IItemRepository ItemRepository { get; }
        IItemCategoryRepository ItemCategoryRepository { get; }
        IItemSubCategoryRepository ItemSubCategoryRepository { get; }
        IItemUOMRepository  ItemUOMRepository { get; }
        IItemUomConvertionRepository ItemUomConvertionRepository { get; }
        IItemSpecRepository ItemSpecRepository { get; }
        void Commit();
        void Rollback();
        string GetGUID();
         
    }
}