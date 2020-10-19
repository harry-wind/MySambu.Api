using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Transaksi
{
    [Table("tTrn_BudgetHdr")]
    public class BudgetHdr : BaseModel
    {
        [ExplicitKey]
        public string BudgetHdrGuid { get; set; }
        // public DateTime BudgetPeriod { get { return BudgetPeriod; } set { BudgetPeriod = new DateTime(BudgetPeriod.Year, BudgetPeriod.Month, 1); } }
        // public int? BudgetYear { get { return BudgetYear; } set { BudgetYear = BudgetPeriod.Year; } }
        // public int? BudgetMonth { get { return BudgetMonth; } set { BudgetMonth = BudgetPeriod.Month; } }
        public DateTime BudgetPeriod { get; set; }
        [Write(false)]
        public List<BudgetDept> BudgetDept { get; set; }

    }
}