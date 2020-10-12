using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using MySambu.Api.Models.Master;

namespace MySambu.Api.Models.Utility
{
    [Table("tUtl_User")]
    public class User : BaseModel
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
        public int StatusUser { get; set; }
        [Write(false)]
        public string Token { get; set; }
        [Write(false)]
        public IEnumerable<RolePrevilege> RolePrivileges { get; set; }
        [Write(false)]
        public string SignID { get; set; }
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