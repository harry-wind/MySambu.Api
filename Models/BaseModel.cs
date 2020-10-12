using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    public class BaseModel
    {
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime? ComputerDate { get; set; } = DateTime.Now;
    }
}