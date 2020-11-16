using System;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBBuySupplierDto
    {
        public long PriceID { get; set; }
        public string SupplierIDPrice { get; set; }
        public string SupplierNamePrice { get; set; }
        public string CurrencyIDPrice { get; set; }
        public decimal UnitPricePrice { get; set; }
        public decimal ExchangeRateIDRPrice { get; set; }
        public bool ShowIndPrice { get; set; }
        public decimal? UnitPriceIDR { get; set; }
        public string PPHNoPrice { get; set; }
        public DateTime? TransDatePrice { get; set; }
        public DateTime? ValidUntil { get; set; }
        public DateTime? DeliveryDatePrice { get; set; }
        public short? LeadTime { get; set; }
        public string RemarkPrice { get; set; }
    }
}