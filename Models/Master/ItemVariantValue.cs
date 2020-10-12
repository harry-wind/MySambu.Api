namespace MySambu.Api.Models.Master
{
    public class ItemVariantValue : BaseModel
    {
        public long VariantValueID { get; set; }
        public string VariantValueName { get; set; }
        public long VariantTypeID { get; set; }
    }
}