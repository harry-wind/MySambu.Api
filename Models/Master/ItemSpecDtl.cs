using Dapper.Contrib.Extensions;
using MySambu.Api.DTO.Master;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemSpecDtl")]
    public class ItemSpecDtl : BaseModel
    {
        [ExplicitKey]
        public string ItemSpecDtlID { get; set; } = "0";
        public string ItemSpecID { get; set; }
        public long VariantTypeID { get; set; }
        public long VariantValueID { get; set; }
        public string VariantTypeName { get; set; }
        public string VariantValueName { get; set; }
    }
}