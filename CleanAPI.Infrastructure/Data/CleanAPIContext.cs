using CleanAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

#nullable disable

namespace CleanAPI.Infrastructure.Data
{
    public partial class CleanAPIContext : DbContext
    {
        public CleanAPIContext()
        {
        }

        public CleanAPIContext(DbContextOptions<CleanAPIContext> options)
            : base(options)
        {
        }

        public  DbSet<User> User { get; set; }
        public  DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
