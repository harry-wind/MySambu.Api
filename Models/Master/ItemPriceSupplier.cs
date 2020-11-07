using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tSum_ItemPriceBySupplier")]
    public class ItemPriceSupplier
    {
        [Key]
        public long PriceID { get; set; }
        public string ItemID { get; set; }
        public string ItemSpecID { get; set; }
        public string SupplierID { get; set; }
        public string CurrencyID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExchangeRateIDR { get; set; }
        public decimal PPHID { get; set; }
        public DateTime LastUsingPriceDate { get; set; }
        public bool ShowInd { get; set; }
        public bool UsedInBudgetInd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
        public string ItemIDOld { get; set; }
        public string SupplierIDOld { get; set; }

    }
}