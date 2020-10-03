using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_InventoryTransType")]
    public class TransType
    {

        [ExplicitKey]
        public short TransTypeID { get; set; }
        public string TransTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime? ComputerDate { get; set; }

    }
}