using CleanAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Role>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = Guid.NewGuid(), Name = "Admin" },
                new Role() { Id = Guid.NewGuid(), Name = "Employee" }                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CleanAPI;Integrated Security = true");
        }
    }
}
