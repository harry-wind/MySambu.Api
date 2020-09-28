using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Master
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }
        [Write(false)]
        public Nullable<DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        [Write(false)]
        public Nullable<DateTime> LastUpdatedDate { get; set; }
    }
}