using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSpecDtl")]
    public class ItemSpecDtl : BaseModel
    {
        [ExplicitKey]
        public long ItemSpecDtlID { get; set; }
        public long ItemSpecID { get; set; }
        public long VariantValueID { get; set; }

    }
}