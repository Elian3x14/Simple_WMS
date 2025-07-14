using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.Data
{
    public class TKS_internContext : DbContext
    {
        public TKS_internContext (DbContextOptions<TKS_internContext> options)
            : base(options)
        {
        }

        public DbSet<TKS_intern_shared.Models.DonViTinh> DonViTinh { get; set; } = default!;
        public DbSet<TKS_intern_shared.Models.LoaiSanPham> LoaiSanPham { get; set; } = default!;
        public DbSet<TKS_intern_shared.Models.SanPham> SanPham { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Đơn vị tính
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
            // Loại sản phẩm
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
            // Sản phẩm
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("tbl_DM_San_Pham");

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasColumnName("Ma_San_Pham")
                    .HasColumnType("varchar(50)");

                entity.HasIndex(e => e.MaSanPham)
                    .IsUnique();

                entity.Property(e => e.TenSanPham)
                    .IsRequired()
                    .HasColumnName("Ten_San_Pham")
                    .HasColumnType("nvarchar(255)");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(500)");

                // Loại sản phẩm (FK)
                entity.Property(e => e.LoaiSanPhamId)
                    .IsRequired()
                    .HasColumnName("Loai_San_Pham_ID");

                entity.HasOne(e => e.LoaiSanPham)
                    .WithMany()
                    .HasForeignKey(e => e.LoaiSanPhamId)
                    .OnDelete(DeleteBehavior.Restrict); // tránh xoá lan truyền

                // Đơn vị tính (FK)
                entity.Property(e => e.DonViTinhId)
                    .IsRequired()
                    .HasColumnName("Don_Vi_Tinh_ID");

                entity.HasOne(e => e.DonViTinh)
                    .WithMany()
                    .HasForeignKey(e => e.DonViTinhId)
                    .OnDelete(DeleteBehavior.Restrict); // tránh xoá lan truyền
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
