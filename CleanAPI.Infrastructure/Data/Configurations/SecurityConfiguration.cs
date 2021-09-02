using CleanAPI.Core.Entities;
using CleanAPI.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CleanAPI.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Seguridad");

            builder.Property(e => e.Id)
                .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnName("NombreUsuario")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Contrasena")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                .HasColumnName("Rol")
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion(x => x.ToString(), x => (RoleTypeEnum)Enum.Parse(typeof(RoleTypeEnum), x));
        }
    }
}
