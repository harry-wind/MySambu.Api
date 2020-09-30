using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_Role")]
    public class Role
    {
        [ExplicitKey]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public string Computer { get; set; }
        public Nullable<DateTime> ComputerDate { get; set; }

    }
}