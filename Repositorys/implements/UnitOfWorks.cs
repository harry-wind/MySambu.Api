using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using log4net;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Repositorys.implements.Master;
using MySambu.Api.Repositorys.implements.Transaksi;
using MySambu.Api.Repositorys.Interfaces;
using MySambu.Api.Repositorys.Interfaces.Master;
using MySambu.Api.Repositorys.Interfaces.Transaksi;

namespace MySambu.Api.Repositorys.implements
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private IConfiguration _configuration;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        private IAuthRepository _authRepository;
        private ILog4NetRepository _log4NetRepository;
        private ISupplierRepository _supplierRepository;
        private IOrganizationStructureRepository _organizationRepository;
        private ICountryRepository _countryRepository;
        private ICurrencyRepository _currencyRepository;
        private IRoleRepository _roleRepository;
        private IRolePrevilegeRepository _rolePrevilegeRepository;
        private IItemRepository _itemRepository;
        private IItemCategoryRepository _itemCategoryRepository;
        private IItemSubCategoryRepository _itemSubCategoryRepository;
        private IItemUOMRepository _itemUOMRepository;
        private IItemUomConvertionRepository _itemUomConvertionRepository;
        private IMenuRepository _menuRepository;
        private IMenuItemRepository _menuItemRepository;
        private IItemSpecRepository _itemSpecRepository;
        private ITransTypeRepository _transTypeRepository;
        private IBudgetCategoryRepository _budgetCategoryRepository;
        private IWarehouseRepository _warehouseRepository;
        private ICompanyProfileRepository _companyProfileRepository;
        private IItemNewRepository _itemNewRepository;
        private IItemVariantTypeRepository _itemVariantTypeRepository;
        private IItemVariantValueRepository _itemVariantValueRepository;
        private IBudgetTargetRepository _budgetTargetRepository;
        private IBudgetItemRepository _budgetItemRepository;
        private ITransAccessRepository _transAccessRepository;
        private IStructureTransAccessRepository _structureTransAccessRepository;
        private IMainProductCategoryRepository _mainProductCategoryRepository;
        private IPpbRequestRepository _ppbRepository;
        private PPHRepository _pphRepository;

        public IAuthRepository AuthRepository {
            get { return _authRepository ?? (_authRepository = new AuthRepository(_transaction)); }
        }

        public ILog4NetRepository Log4NetRepository {
             get { return _log4NetRepository ?? (_log4NetRepository = new Log4NetRepository(_transaction)); }
        }

        public ISupplierRepository SupplierRepository {
            get { return _supplierRepository ?? (_supplierRepository = new SupplierRepository(_transaction)); }
        }

        public IOrganizationStructureRepository OrganizationStructure {
            get { return _organizationRepository ?? (_organizationRepository = new OrganizationStructureRepository(_transaction)); }
        }
        
        public ICountryRepository CountryRepository{
            get { return _countryRepository ?? (_countryRepository = new CountryRepository(_transaction));}
        }

        public ICurrencyRepository CurrencyRepository{
            get { return _currencyRepository ?? (_currencyRepository = new CurrencyRepository(_transaction)); }
        }

        public IRoleRepository RoleRepository {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_transaction)); }
        }

        public IRolePrevilegeRepository RolePrevilegeRepository {
            get { return _rolePrevilegeRepository ?? (_rolePrevilegeRepository = new RolePrevilegeRepository(_transaction)); }
        }

        public IMenuRepository MenuRepository {
            get { return _menuRepository ?? (_menuRepository = new MenuRepository(_transaction)); }
        }
        public IMenuItemRepository MenuItemRepository {
            get { return _menuItemRepository ?? (_menuItemRepository = new MenuItemRepository(_transaction));}
        }
        public IItemRepository ItemRepository {
            get { return _itemRepository ?? (_itemRepository = new ItemRepository(_transaction)); }
        }

        public IItemCategoryRepository ItemCategoryRepository {
            get { return _itemCategoryRepository ?? (_itemCategoryRepository = new ItemCategoryRepository(_transaction)); }
        }

        public IItemSubCategoryRepository ItemSubCategoryRepository {
            get { return _itemSubCategoryRepository ?? (_itemSubCategoryRepository = new ItemSubCategoryRepository(_transaction)); }
        }

        public IItemUOMRepository ItemUOMRepository {
            get { return _itemUOMRepository ?? (_itemUOMRepository = new ItemUOMRepository(_transaction)); }
        }

        public IItemUomConvertionRepository ItemUomConvertionRepository {
            get { return _itemUomConvertionRepository ?? (_itemUomConvertionRepository = new ItemUomConvertionRepository(_transaction)); }
        }

        public IItemSpecRepository ItemSpecRepository {
            get { return _itemSpecRepository ?? (_itemSpecRepository = new ItemSpecRepository(_transaction)); }
        }

        public ITransTypeRepository TransTypeRepository {
            get { return _transTypeRepository ?? (_transTypeRepository = new TransTypeRepository(_transaction)); }
        }

        public IBudgetCategoryRepository BudgetCategoryRepository{
            get { return _budgetCategoryRepository ?? (_budgetCategoryRepository = new BudgetCategoryRepository(_transaction)); }
        }

        public IWarehouseRepository WarehouseRepository {
            get { return _warehouseRepository ?? (_warehouseRepository = new WarehouseRepository(_transaction)); }
        }

        public ICompanyProfileRepository CompanyProfileRepository {
            get { return _companyProfileRepository ?? (_companyProfileRepository = new CompanyProfileRepository(_transaction)); }
        }

        public IItemNewRepository ItemNewRepository {
            get { return _itemNewRepository ?? (_itemNewRepository = new ItemNewRepository(_transaction));}
        }

        public IItemVariantTypeRepository ItemVariantTypeRepository {
            get { return _itemVariantTypeRepository ?? (_itemVariantTypeRepository = new ItemVariantTypeRepository(_transaction)); }
        }

        public IItemVariantValueRepository ItemVariantValueRepository {
            get { return _itemVariantValueRepository ?? (_itemVariantValueRepository = new ItemVariantValueRepository(_transaction) ); }
        }

        public ITransAccessRepository TransAccessRepository {
            get { return _transAccessRepository ?? (_transAccessRepository = new TransAccessRepository(_transaction));  }
        }

        public IStructureTransAccessRepository StructureTransAccessRepository {
            get { return _structureTransAccessRepository = (_structureTransAccessRepository = new StructureTransAccessRepository(_transaction)); }
        }
        
        // Transaksi
        public IBudgetTargetRepository BudgetTargetRepository {
            get { return _budgetTargetRepository ?? (_budgetTargetRepository = new BudgetTargetRepository(_transaction)); }
        }

        public IBudgetItemRepository BudgetItemRepository {
            get { return _budgetItemRepository ?? (_budgetItemRepository = new BudgetItemRepository(_transaction));}
        }

       

        public IMainProductCategoryRepository MainProductCategoryRepository {
            get { return _mainProductCategoryRepository ?? (_mainProductCategoryRepository = new MainProductCategoryRepository(_transaction)); }
        }

        public IPpbRequestRepository PPBRepository {
            get { return _ppbRepository ?? (_ppbRepository = new PPBRequestRepository(_transaction)); }
        }
        
        public IPPHRepository PPHRepository {
            get { return _pphRepository ?? (_pphRepository = new PPHRepository(_transaction)); }
        }

        private void resetRepository()
        {
            resetMasterRepository();   
            resetTransRepository();
        }

        private void resetTransRepository()
        {
            _budgetTargetRepository = null;
            _budgetItemRepository = null;
            _ppbRepository = null;
            _pphRepository = null;
        }

        private void resetMasterRepository()
        {
            _authRepository = null;
            _supplierRepository = null;
            _countryRepository = null;
            _currencyRepository = null;
            _roleRepository = null;
            _menuRepository = null;
            _menuItemRepository = null;
            _rolePrevilegeRepository = null;
            _itemRepository = null;
            _itemCategoryRepository = null;
            _itemSubCategoryRepository = null;
            _itemUOMRepository = null;
            _organizationRepository = null;
            _itemUomConvertionRepository = null;
            _itemSpecRepository = null;
            _transTypeRepository = null;
            _budgetCategoryRepository = null;
            _warehouseRepository = null;
            _companyProfileRepository = null;
            _itemNewRepository = null;
            _itemVariantTypeRepository = null;
            _itemVariantValueRepository = null;
            _transAccessRepository = null;
            _structureTransAccessRepository = null;
            _mainProductCategoryRepository = null;            
        }

        public UnitOfWorks(IConfiguration configuration)
        {
            _configuration = configuration;
            if(_connection == null){
                _connection = GetOpenConnection();
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }

           
        }

        private IDbConnection GetOpenConnection()
        {
            DbConnection conn = null;
            
            try
            {
                // cari di nuget
                SqlClientFactory provider = SqlClientFactory.Instance; 
                conn = provider.CreateConnection();
                string _constring = "Data Source=192.168.12.5; Initial Catalog=SambuERP; User ID=uKoneksi; Password=sm@rt2018; MultipleActiveResultSets=True;";
                // string _constring = "Data Source=192.168.12.55\\LOCAL12; Initial Catalog=SambuERP; User ID=sa; Password=p@ssw0rd; MultipleActiveResultSets=True;";
                // string _constring = "Data Source=(local); Initial Catalog=DocumentDB; User ID=sa; Password=123; MultipleActiveResultSets=True;";
                conn.ConnectionString = _constring;
            }
            catch (System.Exception)
            {
                
                throw;
            }

            return conn;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (System.Exception)
            {
                _transaction.Rollback();
                throw;
            }
            finally{
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepository();
            }
        }

        public void Dispose(){
           dispose(true);
           GC.SuppressFinalize(this);
        }

        private void dispose(bool v)
        {
             if(!_disposed){
                if(_transaction != null){
                    _transaction.Dispose();
                    _transaction = null;
                }
                if(_connection != null){
                    _connection.Dispose();
                    _connection = null;
                }
                _disposed = true;
            }
        }

        public void Rollback()
        {
            if(_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepository();
            }
        }

        public string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }

        ~UnitOfWorks(){
            dispose(false);
        }
    }
}