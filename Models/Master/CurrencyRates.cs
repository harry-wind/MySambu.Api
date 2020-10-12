using System;
// using System.ComponentModel.DataAnnotations.Schema;
// using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Controllers.Master
{
    [Table("tMst_CurrencyRate")]
    public class CurrencyRates : BaseModel
    {
        public DateTime CurrencyDate { get; set; }
        public string TypeRate { get; set; }
        public string CurrencyID { get; set; }
        public decimal CurrencyRate { get; set; }
        public bool Modified { get; set; }
    }
}