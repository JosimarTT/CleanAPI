﻿using CleanAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=CleanAPI;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("Comentario");

                entity.Property(e => e.CommentId)
                    .HasColumnName("IdComentario")
                    .ValueGeneratedNever();

                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion");

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Activo");

                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Publicacion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Usuario");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("Publicacion");

                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion");

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario");

                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasColumnName("Imagen")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicacion_Usuario");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Usuario");

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario");

                entity.Property(e => e.LastName)
                    .HasColumnName("Apellidos")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("FechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("Nombres")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasColumnName("Telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("Activo");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}