using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_OrganizationStructure")]
    public class OrganizationStructure : BaseModel
    {
        [Key]
        public int StructureId { get; set; }
        public string StructureName { get; set; }
        public string StructureAbbr { get; set; }
        public int StructureParentId { get; set; }
        public int StructureLevel { get; set; }
        public int StructureOrder { get; set; }
        public bool IsActive { get; set; }
        public int OldId { get; set; }

    }
}