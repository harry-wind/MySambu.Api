using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using log4net;
using MySambu.Api.Repositorys.Interfaces;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Repositorys.implements
{
    internal class SupplierRepository : BaseRepository, ISupplierRepository
    {
        // private IDbTransaction _transaction;

        public SupplierRepository(IDbTransaction transaction) : base(transaction)
        {
            // _transaction = transaction;
        }

        public Task Delete(Supplier obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id, string by)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var data = await Connection.GetAllAsync<Supplier>(transaction:Transaction);
            return data;
        }

        public Task<Supplier> GetByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Supplier> Save(Supplier obj)
        {
            var dt = await Connection.QueryFirstOrDefaultAsync<Supplier>("pMst_SupplierSave", new
            {
                SupplierID = obj.SupplierID,
                IsActive = obj.IsActive,
                CSTSupplierID = obj.SupplierIDOld,
                SupplierName = obj.SupplierName,
                SupplierShortName = obj.SupplierShortName,
                AccountNumber = obj.AccountNumber,
                AccountName	= obj.AccountName,
                CountryID	= obj.CountryID,
                Import = obj.Import,
                Address1 = obj.Address1,
                Address2 = obj.Address2,
                Address3 = obj.Address3,
                Address4 =  obj.Address4,
                ContactPerson1 = obj.ContactPerson1,
                ContactPerson2	= obj.ContactPerson2,
                Telephone = obj.Telephone,
                Fax	=  obj.Fax,
                Email = obj.Email,
                Financial  = obj.Financial,
                Legality = obj.Legality,
                Quality = obj.Quality,
                Security = obj.Security,
                EnvHealthSafety = obj.EnvHealthSafety,
                FoodSafety = obj.FoodSafety,
                OrganicAllergent = obj.OrganicAllergent,
                HalalKosher	= obj.HalalKosher,
                Remark	= obj.Remark,
                UserID	= obj.CreatedBy,
                Computer = obj.Computer,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return dt;
        }

        public Task Update(Supplier obj)
        {
            throw new System.NotImplementedException();
        }
    }
}