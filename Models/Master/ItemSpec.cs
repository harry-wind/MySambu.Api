using System;

namespace MySambu.Api.Models.Master
{
    public class ItemSpec
    {
        public string ID { get; set; }
        public string ItemID { get; set; }
        public string DetailSpesifikasi { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}