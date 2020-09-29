using System.ComponentModel.DataAnnotations;

namespace MySambu.Api.Dto.Master
{
    public class CompanyDto
    {
        [Display(Name = "Company Id")]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name="Company Abbr")]
        public string CompanyAbbr { get; set; }
        public bool IsActive { get; set; }
    }
}