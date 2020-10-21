using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSpec")]
    public class ItemSpec : BaseModel
    {
        [ExplicitKey]
        public long ItemSpecID { get; set; }
        public string ItemID { get; set; }
        public string UOM { get; set; }
        public decimal? QntyConvert { get; set; }
        public string Deskripsi { get; set; }
        [Write(false)]
        public IEnumerable<ItemSpecDtl> ItemSpecDtl { get; set; }

    }
}