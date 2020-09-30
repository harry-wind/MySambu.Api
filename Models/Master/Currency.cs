using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Currency")]
    public class Currency
    {
        [ExplicitKey]
        public string CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencySayInWords { get; set; }
        public string CurrencySayInWords2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}