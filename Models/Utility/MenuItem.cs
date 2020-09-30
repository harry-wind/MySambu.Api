using System;

namespace MySambu.Api.Models.Utility
{
    public class MenuItem
    {
        public string MenuItemId { get; set; }
        public string MenuId { get; set; }
        public int? GrandId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}