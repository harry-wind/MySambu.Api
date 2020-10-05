using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Warehouse")]
    public class Warehouse : BaseModel
    {
       [ExplicitKey] 
        public short WHSID { get; set; }
        public string WHSName { get; set; }
        public string Remark { get; set; }
        public bool? WHSProduction { get; set; }

    }
}