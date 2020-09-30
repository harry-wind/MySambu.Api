using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_User")]
    public class User
    {
        [ExplicitKey]
        public string UserGuid { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        [Write(false)]
        public Role Role {get; set;}
        public long EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public bool IsActive { get; set; }
        public int StatusUser { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public string Computer { get; set; }
        public DateTime ComputerDate { get; set; }
        [Write(false)]
        public string Token { get; set; }
        [Write(false)]
        public IEnumerable<RolePrevilege> RolePrevilege { get; set; }
    }

    public static class UserFn{
        public static string GetMD5Hash(string plainText, string key = "")
        {
            if (key.Length > 0)
                plainText += key;

            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bs = System.Text.Encoding.UTF8.GetBytes(plainText);
            bs = x.ComputeHash(bs);

            var s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
    }
}