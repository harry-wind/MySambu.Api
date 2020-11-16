using System;
using System.Collections.Generic;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBBuyDto
    {
        public string PPBGUID { get; set; }
        public long? PPBNo { get; set; }
        public DateTime TransDate { get; set; }
        public short DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptAbbr { get; set; }
        public short BudgetCategoryID { get; set; }
        public string BudgetCategoryName { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemSpecID { get; set; }
        public string ItemSpec { get; set; }
        public string UOMPurchaseName { get; set; }
        public decimal? QntyConvert { get; set; }
        public string UOMUsageName { get; set; }
        public string Deskripsi { get; set; }
        public short SubCategoryID { get; set; }
        public short CategoryID { get; set; }
        public string PPBDtlRequestGUID { get; set; }
        public decimal QntyReq { get; set; }
        public string DeptRemark { get; set; }
        public bool RequstUpdateApprovalInd { get; set; }
        public byte RequestStatus { get; set; }
        public bool BSTB { get; set; }
        public bool Priority { get; set; }
        public string DeptApprovalBy { get; set; }
        public string DeptApprovalRemark { get; set; }
        public DateTime? RequestUpdate { get; set; }
        public string PLGUpdatedBy { get; set; }
        public DateTime? PLGUpdatedDate { get; set; }
        public string PPBDtlBuyGUID { get; set; }
        public short? BuyDNo { get; set; }
        public short? RevisionNo { get; set; }
        public byte? Status { get; set; }
        public decimal? QntyBuy { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string PPHHdrGuid { get; set; }
        public string CurrencyID { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? ExchangeRateIDR { get; set; }
        public string Remark { get; set; }
        public bool? UpdateApprovalInd { get; set; }
        public DateTime? DeliveryDate { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string NPBBDtlGUID { get; set; }
        public string PPHNo { get; set; }
        public List<PPBBuySupplierDto> SupplierPrice { get; set; }

    }
}