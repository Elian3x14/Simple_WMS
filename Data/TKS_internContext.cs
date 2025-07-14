using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TKS_intern.Models;

namespace TKS_intern.Data
{
    public class TKS_internContext : DbContext
    {
        public TKS_internContext (DbContextOptions<TKS_internContext> options)
            : base(options)
        {
        }

        public DbSet<TKS_intern.Models.DonViTinh> DonViTinh { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViTinh>(entity =>
            {
                entity.ToTable("tbl_DM_Don_Vi_Tinh");
                entity.Property(e => e.TenDonViTinh)
                    .IsRequired() // NOT NULL
                    .HasColumnName("Ten_Don_Vi_Tinh")
                    .HasColumnType("varchar(255)");
                entity.HasIndex(entity => entity.TenDonViTinh)
                    .IsUnique(); // Unique
                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu");
            });

            // Cấu hình cho tất cả entity kế thừa từ BaseModel
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    // Thêm các thuộc tính CreatedAt và UpdatedAt tự động
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETUTCDATE()"); // Sử dụng UTC để tránh vấn đề múi giờ

                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("UpdatedAt")
                        .HasDefaultValueSql("GETUTCDATE()"); 
                }
            }
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseModel>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;   
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }

    }
}
