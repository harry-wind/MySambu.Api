using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_BudgetCategory")]
    public class BudgetCategory : BaseModel
    {
        [ExplicitKey]
        public int BudgetCategoryID { get; set; }
        public string BudgetCategoryName { get; set; }
        public string BudgetCategoryAbbr { get; set; }
        public bool IsPPBWithOutBudget { get; set; }
    }
}