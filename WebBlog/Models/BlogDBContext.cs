using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBlog.Models
{
    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {
        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.Property(e => e.CategoryName).HasColumnType("ntext");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Url).HasMaxLength(1000);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(4000);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Comment_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PortId);

                entity.ToTable("Post");

                entity.Property(e => e.PortId).HasMaxLength(50);

                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.PostName).HasColumnType("ntext");

                entity.Property(e => e.ShortDescription).HasColumnType("ntext");

                entity.Property(e => e.Tab).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.Url).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Post_Category1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(1000);

                entity.Property(e => e.Mail).HasMaxLength(300);

                entity.Property(e => e.RoleId).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
