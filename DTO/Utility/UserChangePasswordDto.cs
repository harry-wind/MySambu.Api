namespace MySambu.Api.DTO.Utility
{
    public class UserChangePasswordDto
    {
        public string userID { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
    }
}