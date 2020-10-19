using System;

namespace MySambu.Api.Models.Utility
{
    public class StructureTransAccess
    {
         public int StructureID { get; set; }
        public string TransAccesID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}