using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_1.Models;

public partial class ProjectDemoContext : DbContext
{
    public ProjectDemoContext()
    {
    }

    public ProjectDemoContext(DbContextOptions<ProjectDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Data Source=SINA;Initial Catalog=Project-demo;TrustServerCertificate=True;Integrated Security=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category_1");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(50);

            entity.HasOne(d => d.Service).WithMany(p => p.Categories)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Service");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("image");

            entity.HasIndex(e => e.UserId, "IX_image").IsUnique();

            entity.Property(e => e.FilePath).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Images)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_image_Category");

            entity.HasOne(d => d.Order).WithMany(p => p.Images)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_image_Order");

            entity.HasOne(d => d.Service).WithMany(p => p.Images)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_image_Service");

            entity.HasOne(d => d.User).WithOne(p => p.Image)
                .HasForeignKey<Image>(d => d.UserId)
                .HasConstraintName("FK_image_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");

            entity.HasMany(d => d.Statuses).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderStatus",
                    r => r.HasOne<Status>().WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OrderStatus_Status"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OrderStatus_Order"),
                    j =>
                    {
                        j.HasKey("OrderId", "StatusId");
                        j.ToTable("OrderStatus");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.ToTable("Suggestion");

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.Suggestions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suggestion_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasMany(d => d.Categories).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserCategory_Category1"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserCategory_User"),
                    j =>
                    {
                        j.HasKey("UserId", "CategoryId");
                        j.ToTable("UserCategory");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("categoryId");
                    });

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_Role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_User"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_UserRole_1");
                        j.ToTable("UserRole");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
