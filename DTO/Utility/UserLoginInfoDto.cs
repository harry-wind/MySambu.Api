using System;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.DTO.Utility
{
    [Table("tUtl_LoginInfo")]
    public class UserLoginInfoDto
    {
        [ExplicitKey]
        public string LoginAutoID { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public string LoginID { get; set; }
        public DateTime?  LogOutDateTime { get; set; }
        public string ComputerName { get; set; }
        public string LoginType { get; set; }
        public string AppVersion { get; set; }
        public string IPAddress { get; set; }
    }
}