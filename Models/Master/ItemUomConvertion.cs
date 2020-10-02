using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemUOMConvertion")]
    public class ItemUOMConvertion
    {
        public string ID { get; set; }
        public long? UomUsage { get; set; }
        public long? UomPurchase { get; set; }
        public decimal? QntyConvertion { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}