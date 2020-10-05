using System;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_AppMenu")]
    public class Menu : BaseModel
    {
        [ExplicitKey]
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public string ParentId { get; set; }
        public int? OrderNumber { get; set; }
        public string FormName { get; set; }
        public bool IsEnable { get; set; }
      
    }
}