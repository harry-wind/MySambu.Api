using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Transaksi
{
    [Table("tTrn_BudgetCategory")]
    public class BudgetCategoryTrn : BaseModel
    {
        [ExplicitKey]
        public string BudgetCatGuid { get; set; }
        public string BudgetDeptGuid { get; set; }
        public int BudgetCategoryID { get; set; }
        public int? RevisionNo { get; set; } = 0;
        public decimal? TotalTarget { get; set; } = 0;
        public bool? IsComplete { get; set; } = false;

    }
}