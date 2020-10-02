using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemCategory")]
    public class ItemCategory
    {
        [ExplicitKey]
        public string CategoryGUID { get; set; }
        public short CategoryID { get; set; }
        public short RevisionNo { get; set; }
        public string CategoryName { get; set; }
        public string ACCID { get; set; }
        public bool NotJurnalIND { get; set; }
        public string RekeningJurnal { get; set; }
        public bool IsActive { get; set; }
        public short? CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByPosition { get; set; }
        public string CreatedByVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string LastUpdatedByName { get; set; }
        public string LastUpdatedByPosition { get; set; }
        public string LastUpdatedByVersion { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
    }
}