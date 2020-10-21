using System;

namespace MySambu.Api.Models
{
    public class BaseModelTransaksi
    {
        public int RevisionNo { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime? ComputerDate { get; set; } = DateTime.Now;
    }
}