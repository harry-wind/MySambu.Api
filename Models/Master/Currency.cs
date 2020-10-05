using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Currency")]
    public class Currency : BaseModel
    {
        [ExplicitKey]
        public string CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencySayInWords { get; set; }
        public string CurrencySayInWords2 { get; set; }       

    }
}