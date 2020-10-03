using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Warehouse")]
    public class Warehouse
    {
       [ExplicitKey] 
        public short WHSID { get; set; }
        public string WHSName { get; set; }
        public int? CompanyDeptID { get; set; }
        public int? DeptID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime? ComputerDate { get; set; }
        public string Remark { get; set; }
        public bool? WHSProduction { get; set; }

    }
}