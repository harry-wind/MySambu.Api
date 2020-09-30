namespace MySambu.Api.DTO.Utility
{
    public class UserRegisterDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public long EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int StatusUser { get; set; }
        public string Computer { get; set; }
    }
}