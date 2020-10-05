using System;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_Role")]
    public class Role : BaseModel
    {
        [ExplicitKey]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

    }
}