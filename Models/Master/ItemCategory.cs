using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemCategory")]
    public class ItemCategory : BaseModel
    {
        [ExplicitKey]
        public short CategoryID { get; set; }
        public short RevisionNo { get; set; }
        public string CategoryName { get; set; }
        public string ACCID { get; set; }
        public bool NotJurnalIND { get; set; }
        public string RekeningJurnal { get; set; }
        public short? CompanyID { get; set; }
      
    }
}