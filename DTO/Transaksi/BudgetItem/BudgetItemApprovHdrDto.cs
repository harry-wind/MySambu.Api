using System.Collections.Generic;

namespace MySambu.Api.DTO.Transaksi.BudgetItem
{
    public class BudgetItemApprovHdrDto
    {
        public string BudgetCatGuid { get; set; }
        public bool IsComplete { get; set; }
        public string UserID { get; set; }
        public string Computer { get; set; }
        public List<BudgetItemApprovalDto>  DtlApprov { get; set; }
    }
}