using System;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBBuySaveDto
    {
        public string PPBDtlBuyGUID { get; set; }
        public string PPBDtlRequestGUID { get; set; }
        public short BuyDNo { get; set; }
        public string ItemID { get; set; }
        public string ItemSpecID { get; set; }
        public decimal QntyBuy { get; set; }
        public string SupplierID { get; set; }
        public string CurrencyID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExchangeRateIDR { get; set; }
        public string PPHDtlGUID { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; } 
        public string Remark { get; set; }
        public short Status { get; set; }
        public string UserID { get; set; }
        public string Computer { get; set; }
    }
}