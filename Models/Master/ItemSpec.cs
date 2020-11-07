using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSpec")]
    public class ItemSpec : BaseModel
    {
        [ExplicitKey]
        public string ItemSpecID { get; set; }
        public string ItemID { get; set; }
        public string UOM { get; set; }
        public decimal? QntyConvert { get; set; }
        public string Deskripsi { get; set; }
        [Write(false)]
        public IList<ItemSpecDtl> ItemSpecDtl { get; set; }
        public ItemPriceSupplier ItemPrice { get; set; }

    }
}