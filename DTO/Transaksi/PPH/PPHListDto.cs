using System;
using MySambu.Api.Models;

namespace MySambu.Api.DTO.Transaksi.PPH
{
    public class PPHListDto : BaseModelTransaksi
    {
        public long PPHID { get; set; }
        public Guid PPHHdrGuid { get; set; }
        public string PPHNo { get; set; }
        public string SupplierPPHRef { get; set; }
        public DateTime TransDate { get; set; }
        public string SupplierID { get; set; }
        public bool PriceInd { get; set; }
        public string Remark { get; set; }
        public long PPHDtlID { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public short UOMID { get; set; }
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