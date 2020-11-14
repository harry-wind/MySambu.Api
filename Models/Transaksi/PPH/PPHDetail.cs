using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Transaksi.PPH
{
    [Table("tTrn_PPHDtl")]
    public class PPHDetail : BaseModelTransaksi
    {
        [Key]
        public long PPHDtlID { get; set; }
        public long PPHID { get; set; }
        public Guid? PPHHdrGuid { get; set; }
        public string ItemSpecID { get; set; }
        public string ItemSpecDesc { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal? Qnty { get; set; }
        public string CurrencyID { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? ExchangeRateIDR { get; set; }
        public byte? WeekNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DetailRemark { get; set; }
        public bool ShowSpecInd { get; set; }
        public decimal? PPBID { get; set; }
        public string ItemIDOld { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}