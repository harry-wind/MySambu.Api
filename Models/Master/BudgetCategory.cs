using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_BudgetCategory")]
    public class BudgetCategory
    {
        [ExplicitKey]
        public int BudgetCategoryID { get; set; }
        public string BudgetCategoryName { get; set; }
        public string BudgetCategoryAbbr { get; set; }
        public bool ActiveInd { get; set; }
        public bool PPBWithOutBudgetInd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime? ComputerDate { get; set; }

    }
}