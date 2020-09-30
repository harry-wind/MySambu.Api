using System;
// using System.ComponentModel.DataAnnotations.Schema;
// using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Controllers.Master
{
    [Table("tMst_CurrencyRate")]
    public class CurrencyRates
    {
        public DateTime CurrencyDate { get; set; }
        public string CurrencyID { get; set; }
        public decimal CurrencyRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
        public bool Modified { get; set; }
    }
}