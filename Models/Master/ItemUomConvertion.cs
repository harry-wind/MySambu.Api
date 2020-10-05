using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemUOMConvertion")]
    public class ItemUOMConvertion : BaseModel
    {
        [ExplicitKey]
        public int UOMConvertionID { get; set; }
        public long? UOMUsage { get; set; }
        [Write(false)]
        public string UOMUsageName { get; set; }
        public long? UOMPurchase { get; set; }
        [Write(false)]
        public string UOMPurchaseName { get; set; }
        public decimal? QntyConvertion { get; set; }
    

    }
}