using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using log4net;
using Microsoft.Extensions.Configuration;
using MySambu.Api.Repositorys.Interfaces;

namespace MySambu.Api.Repositorys.implements
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private IConfiguration _configuration;
        private IDbConnection _connection;
        // private ILog _log;
        private IDbTransaction _transaction;
        private bool _disposed;
        private IAuthRepository _authRepository;
        private ILog4NetRepository _log4NetRepository;
        private ISupplierRepository _supplierRepository;

        public IAuthRepository AuthRepository {
            get { return _authRepository ?? (_authRepository = new AuthRepository(_transaction)); }
        }

        public ILog4NetRepository Log4NetRepository {
             get { return _log4NetRepository ?? (_log4NetRepository = new Log4NetRepository(_transaction)); }
        }

        public ISupplierRepository SupplierRepository {
            get { return _supplierRepository ?? (_supplierRepository = new SupplierRepository(_transaction)); }
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

        private void resetRepository()
        {
            _authRepository = null;
            _supplierRepository = null;
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

        ~UnitOfWorks(){
            dispose(false);
        }
    }
}