using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class LoggedInUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string LoginToken { get; set; }
        public List<string> RoleCodes { get; set; }
    }
}