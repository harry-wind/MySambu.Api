using System;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_CompanyProfile")]
    public class CompanyProfile : BaseModel
    {
        [ExplicitKey]
        public string ProfileId { get; set; }
        public long? StructureId { get; set; }
        public string ProfileName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

    }
}