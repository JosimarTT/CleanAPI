using System;

namespace CleanAPI.Core.Entities
{
    public class Role : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
