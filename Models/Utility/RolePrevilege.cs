using System;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_RolePrivilege")]
    public class RolePrevilege : BaseModel
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
       

    }
}