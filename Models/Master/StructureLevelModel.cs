using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_StructureLevel")]
    public class StructureLevelModel
    {
        [ExplicitKey]
        public int StructureLevel { get; set; }
        public string StructureRemark { get; set; }
    }
}