using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSubCategory")]
    public class ItemSubCategory : BaseModel
    {
        [ExplicitKey]
        public short SubCategoryID { get; set; }
        public short RevisionNo { get; set; }
        public string SubCategoryName { get; set; }
        public short CategoryID { get; set; }
        public string ACCID { get; set; }
      
        public int DeptID { get; set; }
        public bool NotJurnalIND { get; set; }

    }
}