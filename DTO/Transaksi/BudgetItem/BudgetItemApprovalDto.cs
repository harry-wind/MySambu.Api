namespace MySambu.Api.DTO.Transaksi.BudgetItem
{
    public class BudgetItemApprovalDto
    {
        public string BudgetItemGuid { get; set; }
        public string Remark { get; set; }
        public int LevelApp { get; set; }
        public int Stat { get; internal set; }
    }
}