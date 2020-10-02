using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSubCategory")]
    public class ItemSubCategory
    {
        public string SubCategoryGUID { get; set; }
        public short SubCategoryID { get; set; }
        public short RevisionNo { get; set; }
        public string SubCategoryName { get; set; }
        public short CategoryID { get; set; }
        public string CategoryGUID { get; set; }
        public string ACCID { get; set; }
        public bool NotActive { get; set; }
        public short? CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByPosition { get; set; }
        public string CreatedByVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string LastUpdatedByName { get; set; }
        public string LastUpdatedByPosition { get; set; }
        public string UpdatedByVersion { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}