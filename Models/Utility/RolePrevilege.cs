using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_RolePrivilege")]
    public class RolePrevilege
    {
        [ExplicitKey]
        public string RoleId { get; set; }
        [ExplicitKey]
        public string MenuId { get; set; }
        [Write(false)]
        public  Menu Menu { get; set; }
        [ExplicitKey]
        public int GrandId { get; set; }
        public bool IsGrand { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}