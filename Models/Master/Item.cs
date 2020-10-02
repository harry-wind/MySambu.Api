using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_item")]
    public class Item
    {
        [ExplicitKey]
        public string ItemID { get; set; }
        public string ItemIDSambu { get; set; }
        public string ItemIDSambu_Bak { get; set; }
        public string ItemIDPSS { get; set; }
        public short RevisionNo { get; set; }
        public string ItemName { get; set; }
        public string ItemNameChinese { get; set; }
        public string OldItemID { get; set; }
        public string AlternateID { get; set; }
        public string ItemDesc { get; set; }
        public string ItemDescChinese { get; set; }
        public short UOMID { get; set; }
        public short SubCategoryID { get; set; }
        public decimal? AVGMonthlyUsage { get; set; }
        public decimal? LeadTime { get; set; }
        public decimal MinStock { get; set; }
        public decimal MaxStock { get; set; }
        public decimal? AvgUsage { get; set; }
        public byte DecimalInQnty { get; set; }
        public bool InActive { get; set; }
        public bool StockItem { get; set; }
        public bool Important { get; set; }
        public bool PPICPriority { get; set; }
        public bool PPBAutoApproval { get; set; }
        public bool PPBAutoApproval2 { get; set; }
        public bool BPBApprovalByManagement { get; set; }
        public bool KawasanBerikatInd { get; set; }
        public bool RoutineInd { get; set; }
        public short? MainProductCategoryID { get; set; }
        public string HSNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
        public string ItemIDOld { get; set; }
        public string ind { get; set; }
        public string KSPItemID { get; set; }
        public string ItemOldID { get; set; }
        public bool ImportAllowed { get; set; }
        public short BCCategoryID { get; set; }
        public string GroupItemIDBC { get; set; }
        public string UOMBC { get; set; }
        public decimal ConversionUOMBC { get; set; }
        public decimal lowprice { get; set; }
        public string Reset_by { get; set; }
        public DateTime? Reset_date { get; set; }
        public decimal lowfinal { get; set; }
        public DateTime? tanggal_final { get; set; }
        public decimal pricebeforereset { get; set; }
        public int peruom { get; set; }
        public bool CentralisasiInd { get; set; }
        public bool LimbahB3Ind { get; set; }
        public short? DeptID { get; set; }
        public string ImagePath { get; set; }
        public int? SubCategoryIDGroup { get; set; }
        public bool isFixedAsset { get; set; }
        public string ItemiDMySambu { get; set; }
        public string LastRevisionBy { get; set; }
        public DateTime? LastRevisionDate { get; set; }
        public string LastRevisionRemark { get; set; }
        public string ItemIDGroup { get; set; }
        public string P1_ItemID { get; set; }
        public string P2_ItemID { get; set; }
    }
}