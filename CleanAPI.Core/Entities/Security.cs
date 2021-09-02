using CleanAPI.Core.Enumerations;

namespace CleanAPI.Core.Entities
{
    public class Security : BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleTypeEnum Role { get; set; }
    }
}
