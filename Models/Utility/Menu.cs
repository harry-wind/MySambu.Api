using System;

namespace MySambu.Api.Models.Utility
{
    public class Menu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public string ParentId { get; set; }
        public int? OrderNumber { get; set; }
        public bool IsActive { get; set; }
        public string FormName { get; set; }
        public bool IsEnable { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }

    }
}