using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TKS_intern_shared.Models;

namespace TKS_intern.Data
{
    public class TKS_internContext : DbContext
    {
        public TKS_internContext (DbContextOptions<TKS_internContext> options)
            : base(options)
        {
        }

        public DbSet<TKS_intern_shared.Models.DonViTinh> DonViTinh { get; set; } = default!;
        public DbSet<TKS_intern_shared.Models.LoaiSanPham> LoaiSanPham { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Don vi tinh
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
            // Loai san pham
            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.ToTable("tbl_DM_Loai_San_Pham");

                entity.Property(e => e.MaLoaiSanPham)
                    .IsRequired()
                    .HasColumnName("Ma_Loai_San_Pham")
                    .HasColumnType("varchar(50)");

                entity.HasIndex(e => e.MaLoaiSanPham).IsUnique();

                entity.Property(e => e.TenLoaiSanPham)
                    .IsRequired()
                    .HasColumnName("Ten_Loai_San_Pham")
                    .HasColumnType("varchar(255)");

                entity.HasIndex(e => e.TenLoaiSanPham).IsUnique();

                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(max)");
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
