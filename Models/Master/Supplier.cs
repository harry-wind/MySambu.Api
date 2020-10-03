using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Supplier")]
    public class Supplier
    {
        [ExplicitKey]
       public string SupplierId { get; set; }
        public bool? IsActive { get; set; }
        public string SupplierName { get; set; }
        public string SupplierShortName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int? COAId { get; set; }
        public string COANo { get; set; }
        public string COAAccRecNo { get; set; }
        public string GroupWil { get; set; }
        public string GroupDept { get; set; }
        public string SupplierNameChinese { get; set; }
        public string CountryId { get; set; }
        public bool Import { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address1Chinese { get; set; }
        public string Address2Chinese { get; set; }
        public string Address3Chinese { get; set; }
        public string Address4Chinese { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactPerson1 { get; set; }
        public string ContactPerson2 { get; set; }
        public bool? Financial { get; set; }
        public bool? Legality { get; set; }
        public bool? Quality { get; set; }
        public bool? Security { get; set; }
        public bool? EnvHealthSafety { get; set; }
        public bool? FoodSafety { get; set; }
        public bool? OrganicAllergent { get; set; }
        public bool? HalalKosher { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
        public string SupplierIdOld2 { get; set; }
        public string SupplierIdOld { get; set; }
        public bool Modified { get; set; }
        public bool Register { get; set; }
        public string SupplierType { get; set; }
    }
}