using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemUOM")]
    public class ItemUOM : BaseModel
    {
        [ExplicitKey]
        public short UOMID { get; set; }
        public short RevisionNo { get; set; }
        public string UOMName { get; set; }

    }
}