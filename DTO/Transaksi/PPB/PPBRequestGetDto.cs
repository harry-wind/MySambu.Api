using System;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBRequestGetDto
    {
        public int Stat { get; set; }
        public long Dept { get; set; }
        public string PPBNo { get; set; }
        public Nullable<DateTime> DateAwal { get; set; }
        public Nullable<DateTime> DateAkhir { get; set; }
        public long CategoryID { get; set; } = 0;
        public long SubCategoryID { get; set; }=0;
        public string Item { get; set; }
        public string Role { get; set; }
        public string DeptQuery { get { if (this.Dept != 0) return " A.DeptID = '" + this.Dept + "'"; return ""; } }
        public string PPBNoQuery { get { if (PPBNo != "" && PPBNo != null) return "A.PPBNo = '" + this.PPBNo + "'"; return ""; } } 
        public string DateQuery { get { if (DateAwal != null && DateAkhir != null) return " A.TransDate Between '" + DateAwal.Value.ToString("yyyy-MM-dd") + "' AND '" + DateAkhir.Value.ToString("yyyy-MM-dd") + "'"; else return "";} }
        public string ItemQuery { get { if(Item != "" && Item != null) return "  G.ItemID LIKE '%" + Item + "%' OR G.ItemName Like '%" + Item + "%' OR B.ItemSpecID LIKE '%" + Item + "%'"; return ""; } }
        public string CategoryQuery { get { if (CategoryID != 0) return " G2.CategoryID = " + CategoryID; return "";} }
        public string SubCatQuery { get { if (SubCategoryID != 0) return " G1.SubCategoryID = " + SubCategoryID; return "";} }
    }
}