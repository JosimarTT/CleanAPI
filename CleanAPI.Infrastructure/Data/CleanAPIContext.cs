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
                new Role() { Id = new Guid("beb585d6-6c62-4063-b783-123516a8127a"), Name = "Admin" },
                new Role() { Id = new Guid("9164cf6d-10c0-4b10-8797-8d70c771b371"), Name = "Employee" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CleanAPI;Integrated Security = true");
        }
    }
}
