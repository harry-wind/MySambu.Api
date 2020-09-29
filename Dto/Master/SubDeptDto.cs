namespace MySambu.Api.Dto.Master
{
    public class SubDeptDto
    {
        public int SubDeptId { get; set; }
        public string SubDeptName { get; set; }
        public string SubDeptAbbr { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptAbbr { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionAbbr { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAbbr { get; set; }
        public int IsActive { get; set; }
    }
}