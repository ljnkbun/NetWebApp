using Core.Models.Parameters;

namespace Application.Parameters.Users
{
    public class UserParameter : RequestParameter
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNum { get; set; }
    }
}
