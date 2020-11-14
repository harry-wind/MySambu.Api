using System;

namespace MySambu.Api.Models.Transaksi.PPB
{
    public class PPBRequets : BaseModelTransaksi
    {
        
        public string PPBDtlRequestGUID { get; set; }
        public string PPBGUID { get; set; }
        public string BudgetItemGuid { get;  set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemSpecID { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public long  SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemSpec { get; set; }
        public string UOMPurchaseName { get; set; }
        public decimal QntyConvert { get; set; }
        public string UOMUsageName { get; set; }
        public string Deskripsi { get; set; }
        public byte Status { get; set; }
        public decimal QntyReq { get; set; }
        public string CurrencyID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExchangeRateIDR { get; set; }
        public bool BSTB { get; set; }
        public bool Priority { get; set; }
        public short? UsedByDeptID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Remark { get; set; }
        public string DeptApprovalBy { get; set; }
        public DateTime? DeptApprovalDate { get; set; }
        public string DeptRemark { get; set; }
        public bool UpdateApprovalInd { get; set; }
        public string PLGUpdatedBy { get; set; }
        public DateTime? PLGUpdatedDate { get; set; }
        public string CancelByPurchaser { get; set; }
        public string CancelRemark { get; set; }
    }
}