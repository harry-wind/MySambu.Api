using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    [Table("tMst_Country")]
    public class Country
    {
        [Key]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryIdd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string Computer { get; set; }
        public Nullable<DateTime> ComputerDate { get; set; }
    }

}