using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemNew")]
    public class ItemNew : BaseModel
    {
        [ExplicitKey]
        public long NewItemID { get; set; }
        public string DeptItemCode { get; set; }
        public string NewItemName { get; set; }
        public string NewItemDesc { get; set; }
        public int? SubCategoryID { get; set; }
        public short UOMID { get; set; }
        public string CurrencyID { get; set; }
        public decimal UnitPrice { get; set; }
        public short DeptID { get; set; }
        public string ItemID { get; set; }
        public bool Cancel { get; set; }
        public bool NeedToUpdate { get; set; }
        public string PurchasingRemark { get; set; }
        public string MemoItemNew { get; set; }
        public string ItemIDOld { get; set; }
        public long? NewItemIDP1 { get; set; }

    }
}