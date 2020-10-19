using System;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_TransAcces")]
    public class TransAccess : BaseModel
    {
        [ExplicitKey]
        public string TransAccessID { get; set; }
        public string TransAccessName { get; set; }
       
    }
}