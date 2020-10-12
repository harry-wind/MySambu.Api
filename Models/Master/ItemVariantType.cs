using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_ItemVariantType")]
    public class ItemVariantType : BaseModel
    {
        [ExplicitKey]
        public long VariantTypeID { get; set; }
        public string VariantTypeName { get; set; }
    }
}