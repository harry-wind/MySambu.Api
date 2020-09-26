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

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var data = await Connection.GetAllAsync<Supplier>(transaction:Transaction);
            return data;
        }

        public async Task Save(Supplier obj)
        {
            await Connection.QueryAsync("spSupplierSave", new
            {
                SupplierID = obj.SupplierID,
                CSTSupplierID = obj.SupplierIDOld,
                SupplierName = obj.SupplierName,
                SupplierShortName = obj.SupplierShortName,
                AccountNumber = obj.AccountNumber,
                AccountName = obj.AccountName,
                CountryID = obj.CountryID,
                Address1 = obj.Address1,
                Address2 = obj.Address2,
                Address3 = obj.Address3,
                Address4 = obj.Address4,
                ContactPerson1 = obj.ContactPerson1,
                ContactPerson2 = obj.ContactPerson2,
                Telephone = obj.Telephone,
                Fax = obj.Fax,
                Email = obj.Email,
                Financial = obj.Email,
                Legality = obj.Legality,
                Quality = obj.Quality,
                Security = obj.Security,
                EnvHealthSafety = obj.EnvHealthSafety,
                FoodSafety = obj.FoodSafety,
                OrganicAllergent = obj.OrganicAllergent,
                HalalKosher = obj.HalalKosher,
                Remark = obj.Remark,
                UserID = obj.CreatedBy,
                Flag = 0
            }, commandType: CommandType.StoredProcedure, transaction: Transaction);
        }

        public Task Update(Supplier obj)
        {
            throw new System.NotImplementedException();
        }
    }
}