using System;
using System.Collections.Generic;
using System.Linq;
using MySambu.Api.Models;
using MySambu.Api.Models.Transaksi.BudgetItem;

namespace MySambu.Api.DTO.Transaksi.BudgetItem
{
    public class BudgetItemHdrDto : BaseModelTransaksi
    {
        public string BudgetCatGuid { get; set; }
        public string BudgetDeptGuid { get; set; }
        public DateTime BudgetPeriod { get; set; }
        public int BudgetCategoryID { get; set; }
        public string BudgetCategoryName { get; set; }
        public decimal? TotalTarget { get; set; } = 0;
        public bool? IsComplete { get; set; } = false;
        public string Proposal { get; set; }
        public int DeptID { get; set; }
        public string StructureName { get; set; }
        public int? TotalItem
        {
            get
            {
                return BudgetItems[0] == null ? 0 : BudgetItems.Count;
            }
        }
        public decimal? TotalHarga
        {
            get
            {
                return BudgetItems[0] == null ? 0 : BudgetItems.Sum(r => r.TotalHarga);
                // if(BudgetItems[0] == null)
                //     return 0;
                
                // return BudgetItems.Sum(r => r.TotalHarga);

            }

        }
        public List<BudgetDtlItem> BudgetItems { get; set; }

    }
}