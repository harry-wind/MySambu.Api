using System;
using MySambu.Api.helper;

namespace MySambu.Api.DTO.Transaksi.PPB
{
    public class PPBBuyGetDataDto
    {
        public string PPBNo { get; set; }
        public Nullable<DateTime> PeriodAwal { get; set; }
        public Nullable<DateTime> PeriodAkhir { get; set; }
        public long BudgetCategoryID { get; set; } = 0;
        public long DeptID { get; set; } = 0;
        public string Purchaser { get; set; } = "";
        public long CategoryID { get; set; } = 0;
        public long SubCategoryID { get; set; } = 0;
        public string Item { get; set; }
        public string SupplierID { get; set; } = "";
        public long Status { get; set; } = 0;
        public string PPBNoQuery
        {
            get
            {
                if (PPBNo != "" && PPBNo != null) return " A.PPBNo = '" + PPBNo + "'"; return "";
            }
        }
        public string PeriodeQuery
        {
            get
            {
                if (PeriodAwal != null && PeriodAkhir != null)
                    return " A.TransDate Between '" + PeriodAwal.Value.ToString("yyyy-MM-01") + "' AND '" + PeriodAkhir.Value + "'";
                return "";
            }
        }
        public string BudgetQuery
        {
            get
            {
                if (BudgetCategoryID != 0) return " A.BudgetCategoryID = '" + BudgetCategoryID + "'"; return "";
            }
        }
        public string DeptQuery
        {
            get
            {
                if (DeptID != 0)
                    return " A.DeptID = '" + DeptID + "'";
                return "";
            }
        }
        public string PcsQuery
        {
            get
            {
                if (Purchaser != "")
                    return " ( J.PLGUpdatedBy = '" + Purchaser + "' )";
                return "";
            }
        }
        public string ItemQuery
        {
            get
            {
                if (Item != "" && Item != null)
                    return "  ( B.ItemID LIKE '%" + Item + "%' OR G.ItemName Like '%" + Item + "%' OR B.ItemSpecID LIKE '%" + Item + "%' ) ";
                return "";
            }
        }
        public string CategoryQuery
        {
            get
            {
                if (CategoryID != 0) return " G1.CategoryID = " + CategoryID; return "";
            }
        }
        public string SubCategoryQuery
        {
            get
            {
                if (SubCategoryID != 0)
                    return " G.SubCategoryID = " + SubCategoryID;
                return "";
            }
        }
        public string SupplierQuery
        {
            get
            {
                if (SupplierID != "")
                    return " J.SupplierID = '" + SupplierID + "'";
                return "";
            }
        }
        public string StatusQuery
        {
            get
            {
                if (Status != 0)
                    return " J.Status = " + Status;
                return "";
            }
        }
        public string QueryConcat
        {
            get
            {
                string sql = "";

                sql = SqlQuery.SetCondition(sql, this.PPBNoQuery);
                sql = SqlQuery.SetCondition(sql, this.PeriodeQuery);
                sql = SqlQuery.SetCondition(sql, this.BudgetQuery);
                sql = SqlQuery.SetCondition(sql, this.DeptQuery);
                sql = SqlQuery.SetCondition(sql, this.PcsQuery);
                sql = SqlQuery.SetCondition(sql, this.ItemQuery);
                sql = SqlQuery.SetCondition(sql, this.CategoryQuery);
                sql = SqlQuery.SetCondition(sql, this.SubCategoryQuery);
                sql = SqlQuery.SetCondition(sql, this.SupplierQuery);
                sql = SqlQuery.SetCondition(sql, this.StatusQuery);

                return sql;
            }
        }
        public string PPBBuyQuery
        {
            get
            {
                return " WHERE B.Status in (3) " + QueryConcat;
            }
        }
        public string PPHGetQuery
        {
            get
            {
                return " WHERE B.Status in (1, 2, 3)" + QueryConcat;
            }
        }


    }
}