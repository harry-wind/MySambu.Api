using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Transaksi
{
    [Table("tTrn_BudgetDept")]
    public class BudgetDept : BaseModel
    {
        [ExplicitKey]
        public string BudgetDeptGuid { get; set; }
        public string BudgetHdrGuid { get; set; }
        public long DeptId { get; set; }
        [Write(false)]
        public List<BudgetCategoryTrn> BudgetCategory { get; set; }
    }
}