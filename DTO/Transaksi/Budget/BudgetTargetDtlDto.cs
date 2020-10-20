using MySambu.Api.Models.Master;

namespace MySambu.Api.DTO.Transaksi.Budget
{
    public class BudgetTargetDtlDto
    {
        public string BudgetDeptGuid { get; set; }
        public long DeptId { get; set; }
        public string BudgetCatGuid { get; set; }
        public int BudgetCategoryID { get; set; }
        public int? RevisionNo { get; set; } = 0;
        public decimal? TotalTarget { get; set; } = 0;
        public bool? IsComplete { get; set; } = false;
    }
}