using System;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    public class MenuItem : BaseModel
    {
        public string MenuItemId { get; set; }
        public string MenuId { get; set; }
        public int? GrandId { get; set; }
        public string Description { get; set; }
       

    }
}