using System;

#nullable disable

namespace CleanAPI.Core.Entities
{
    public partial class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telephone { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
