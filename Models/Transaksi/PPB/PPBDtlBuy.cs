using System;

namespace MySambu.Api.Models.Transaksi.PPB
{
    public class PPBDtlBuy : BaseModelTransaksi
    {
        
        public string PPBDtlBuyGUID { get; set; }
        public string PPBGUID { get; set; }
        public string ItemID { get; set; }
        public string ItemSpecID { get; set; }
        public short BuyDNo { get; set; }
        public byte Status { get; set; }
        public decimal QntyBuy { get; set; }
        public string SupplierID { get; set; }
        public string CurrencyID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExchangeRateIDR { get; set; }
        public decimal PPHID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Remark { get; set; }
        public string PLGUpdatedBy { get; set; }
        public bool UpdateApprovalInd { get; set; }
        public string PLGApprovalBy { get; set; }
        public DateTime? PLGApprovalDate { get; set; }
        public string PLGRemark { get; set; }
        public string FINApprovalBy { get; set; }
        public DateTime? FINApprovalDate { get; set; }
        public string FINRemark { get; set; }
        public string DivApprovalBy { get; set; }
        public DateTime? DivApprovalDate { get; set; }
        public string DivRemark { get; set; }
        public string M1ApprovalBy { get; set; }
        public DateTime? M1ApprovalDate { get; set; }
        public string M1Remark { get; set; }
        public string M2ApprovalBy { get; set; }
        public DateTime? M2ApprovalDate { get; set; }
        public string M2Remark { get; set; }
        public string SupplierIDOld { get; set; }
    }
}