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

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
