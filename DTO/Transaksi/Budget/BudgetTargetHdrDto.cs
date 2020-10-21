using System;
using System.Collections.Generic;
using System.Linq;
using MySambu.Api.Models;

namespace MySambu.Api.DTO.Transaksi.Budget
{
    public class BudgetTargetHdrDto : BaseModelTransaksi
    {
        public string BudgetHdrGuid { get; set; }
        public DateTime BudgetPeriod { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTarget { get { return BudgetTargetItem.Sum(r => r.TotalTarget.Value);} }
        public decimal Discrepancy { get { return Total - TotalTarget; } }
        public List<BudgetTargetDtlDto> BudgetTargetItem { get; set; }
    }
}