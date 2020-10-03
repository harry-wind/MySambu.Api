using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.DTO.Master
{
    [Table("tMst_OrganizationStructure")]
    public class OrganizationStructureDto
    {
        [Dapper.Contrib.Extensions.Key]
        public int StructureId { get; set; }
        public string StructureName { get; set; }
        public string StructureAbbr { get; set; }
        public int StructureParentId { get; set; }
        public int StructureLevel { get; set; }
        public int StructureOrder { get; set; }
        public bool IsActive { get; set; }
        public IList<OrganizationStructureDto> StructureChild { get; set; }

        public OrganizationStructureDto()
        {
            StructureChild = new List<OrganizationStructureDto>();
        }
    }
}