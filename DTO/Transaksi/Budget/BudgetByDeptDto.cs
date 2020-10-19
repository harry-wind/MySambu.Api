using System;

namespace MySambu.Api.DTO.Transaksi.Budget
{
    public class BudgetByDeptDto
    {
        public int DeptID { get; set; }
        public DateTime BudgetPeriod { get; set; }
    }
}