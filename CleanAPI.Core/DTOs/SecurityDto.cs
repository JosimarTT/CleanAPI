using CleanAPI.Core.Enumerations;

namespace CleanAPI.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleTypeEnum? Role { get; set; }
    }
}
