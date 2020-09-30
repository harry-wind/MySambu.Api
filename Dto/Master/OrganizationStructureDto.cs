using System.Collections.Generic;

namespace MySambu.Api.Dto.Master
{
    public class OrganizationStructureDto : CompanyDto
    {
        public IList<DivisionDto> Divisions { get; private set; }

        public OrganizationStructureDto()
        {
            Divisions = new List<DivisionDto>();
        }
    }
}