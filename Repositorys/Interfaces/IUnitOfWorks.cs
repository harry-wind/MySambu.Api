using MySambu.Api.Repositorys.Interfaces.Master;
using MySambu.Api.Repositorys.Interfaces.Transaksi;

namespace MySambu.Api.Repositorys.Interfaces
{
    public interface IUnitOfWorks
    {
        ILog4NetRepository Log4NetRepository { get; }
        IAuthRepository AuthRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IOrganizationStructureRepository OrganizationStructure { get; }
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
        ITransTypeRepository TransTypeRepository { get; }
        IBudgetCategoryRepository BudgetCategoryRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }
        ICompanyProfileRepository CompanyProfileRepository{ get; }
        IItemNewRepository ItemNewRepository {get;}
        IItemVariantTypeRepository ItemVariantTypeRepository {get;}
        IItemVariantValueRepository ItemVariantValueRepository {get;}
        ITransAccessRepository TransAccessRepository { get; }
        IStructureTransAccessRepository StructureTransAccessRepository { get; }
        IBudgetTargetRepository BudgetTargetRepository { get; }
        IBudgetItemRepository BudgetItemRepository { get; }
        IMainProductCategoryRepository MainProductCategoryRepository { get; }
        IPpbRequestRepository PPBRequestRepository {get;}
        
        IPPHRepository PPHRepository { get; }

        void Commit();
        void Rollback();
        string GetGUID();
         
    }
}