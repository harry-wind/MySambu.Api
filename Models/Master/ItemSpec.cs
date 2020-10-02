using System;

namespace MySambu.Api.Models.Master
{
    public class ItemSpec
    {
        public string ID { get; set; }
        public string ItemID { get; set; }
        public string DetailSpesifikasi { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}