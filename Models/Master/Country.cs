using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Country")]
    public class Country : BaseModel
    {
        [Key]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryIdd { get; set; }
     
    }

}