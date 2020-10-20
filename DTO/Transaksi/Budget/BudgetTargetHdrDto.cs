using System;
using System.Collections.Generic;
using MySambu.Api.Models.Master;

namespace MySambu.Api.DTO.Transaksi.Budget
{
    public class BudgetTargetHdrDto : BaseModel
    {
        public string BudgetHdrGuid { get; set; }
        public DateTime BudgetPeriod { get; set; }
        public List<BudgetTargetDtlDto> BudgetTargetItem { get; set; }
    }
}