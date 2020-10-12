namespace MySambu.Api.DTO.Utility
{
    public class UserLoginDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Computer { get; set; } = "";
        public string AppVersion { get; set; } = "";
    }
}