using System;

namespace MySambu.Api.Models.Transaksi.PPB
{
    public class PPBHdr : BaseModelTransaksi
    {
        public string PPBGUID { get; set; }
        public int PPBNo { get; set; }
        public string BudgetCatGUID { get; set; }
        public DateTime TransDate { get; set; }
        public short DeptID { get; set; }
        public string DeptName { get; set; }
        public short BudgetCategoryID { get; set; }
        public string BudgetCategoryName { get; set; }
        
        
    }
}