using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_InventoryTransType")]
    public class TransType : BaseModel
    {

        [ExplicitKey]
        public short TransTypeID { get; set; }
        public string TransTypeName { get; set; }
      
    }
}