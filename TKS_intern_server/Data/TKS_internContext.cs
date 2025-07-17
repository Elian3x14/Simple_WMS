using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TKS_intern_shared.Models;

namespace TKS_intern_server.Data
{
    public class TKS_internContext : DbContext
    {
        public TKS_internContext (DbContextOptions<TKS_internContext> options)
            : base(options)
        {
        }

        public DbSet<DonViTinh> DonViTinh { get; set; } = default!;
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; } = default!;
        public DbSet<SanPham> SanPhams { get; set; } = default!;
        public DbSet<NhaCungCap> NhaCungCap { get; set; } = default!;
        public DbSet<Kho> Kho { get; set; } = default!;
        public DbSet<KhoUser> KhoUsers { get; set; } = default!;
        public DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; } = default!;

        public DbSet<ChiTietPhieuNhapKho> ChiTietPhieuNhapKhos { get; set; } = default!;

        public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; } = default!;

        public DbSet<ChiTietPhieuXuatKho> ChiTietPhieuXuatKhos{ get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;


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

            // Nhà cung cấp
            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.ToTable("tbl_DM_Nha_Cung_Cap");

                entity.Property(e => e.MaNhaCungCap)
                    .IsRequired()
                    .HasColumnName("Ma_NCC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TenNhaCungCap)
                    .IsRequired()
                    .HasColumnName("Ten_NCC")
                    .HasColumnType("varchar(255)");

                entity.HasIndex(e => e.TenNhaCungCap)
                    .IsUnique(); // Tên nhà cung cấp là duy nhất

                entity.HasIndex(e => e.MaNhaCungCap)
                    .IsUnique(); // Mã nhà cung cấp là duy nhất

                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(max)"); // Hoặc tùy theo bạn dùng varchar/nvarchar
            });

            // Kho
            modelBuilder.Entity<Kho>(entity =>
            {
                entity.ToTable("tbl_DM_Kho");

                entity.Property(e => e.TenKho)
                    .IsRequired()
                    .HasColumnName("Ten_Kho")
                    .HasColumnType("varchar(255)");

                entity.HasIndex(e => e.TenKho)
                    .IsUnique(); // Tên kho là duy nhất

                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(max)");
            });

            // Kho - User
            modelBuilder.Entity<KhoUser>(entity =>
            {
                entity.ToTable("tbl_DM_Kho_User");

                entity.Property(e => e.MaDangNhap)
                    .IsRequired()
                    .HasColumnName("Ma_Dang_Nhap")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.KhoId)
                    .IsRequired()
                    .HasColumnName("Kho_ID");

                // Thiết lập khóa chính tổng hợp (composite key)
                entity.HasKey(e => new { e.MaDangNhap, e.KhoId });

                // Thiết lập khóa ngoại (FK) tới Kho nếu có quan hệ
                entity.HasOne(e => e.Kho)
                    .WithMany()
                    .HasForeignKey(e => e.KhoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Phiếu nhập kho
            modelBuilder.Entity<PhieuNhapKho>(entity =>
            {
                entity.ToTable("tbl_DM_Phieu_Nhap_Kho");

                entity.Property(e => e.SoPhieuNhapKho)
                    .IsRequired()
                    .HasColumnName("So_Phieu_Nhap_Kho")
                    .HasColumnType("varchar(50)");

                entity.HasIndex(e => e.SoPhieuNhapKho).IsUnique();

                entity.Property(e => e.KhoId)
                    .IsRequired()
                    .HasColumnName("Kho_ID");

                entity.Property(e => e.NhaCungCapId)
                    .IsRequired()
                    .HasColumnName("NCC_ID");

                entity.Property(e => e.NgayNhapKho)
                    .IsRequired()
                    .HasColumnName("Ngay_Nhap_Kho");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(max)");

                entity.HasOne(e => e.Kho)
                    .WithMany()
                    .HasForeignKey(e => e.KhoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.NhaCungCap)
                    .WithMany()
                    .HasForeignKey(e => e.NhaCungCapId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Nhập kho raw data (chi tiết phiếu nhập)
            modelBuilder.Entity<ChiTietPhieuNhapKho>(entity =>
            {
                entity.ToTable("tbl_DM_Nhap_Kho_Raw_Data");

                entity.Property(e => e.PhieuNhapKhoId)
                    .IsRequired()
                    .HasColumnName("Nhap_Kho_ID");

                entity.Property(e => e.SanPhamId)
                    .IsRequired()
                    .HasColumnName("San_Pham_ID");

                entity.Property(e => e.SoLuongNhap)
                    .IsRequired()
                    .HasColumnName("SL_Nhap")
                    .HasPrecision(18, 2); ;

                entity.Property(e => e.DonGiaNhap)
                    .IsRequired()
                    .HasColumnName("Don_Gia_Nhap")
                    .HasColumnType("decimal(18,2)")
                    .HasPrecision(18, 2); ;

                entity.HasOne(e => e.PhieuNhapKho)
                    .WithMany(p => p.ChiTietPhieuNhapKhos)
                    .HasForeignKey(e => e.PhieuNhapKhoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.SanPham)
                    .WithMany()
                    .HasForeignKey(e => e.SanPhamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // Phiếu xuất kho
            modelBuilder.Entity<PhieuXuatKho>(entity =>
            {
                entity.ToTable("tbl_DM_Phieu_Xuat_Kho");
                entity.Property(e => e.SoPhieuXuatKho)
                    .IsRequired()
                    .HasColumnName("So_Phieu_Xuat_Kho")
                    .HasColumnType("varchar(50)");
                entity.HasIndex(e => e.SoPhieuXuatKho).IsUnique();
                entity.Property(e => e.KhoId)
                    .IsRequired()
                    .HasColumnName("Kho_ID");
                entity.Property(e => e.NgayXuatKho)
                    .IsRequired()
                    .HasColumnName("Ngay_Xuat_Kho");
                entity.Property(e => e.GhiChu)
                    .HasColumnName("Ghi_Chu")
                    .HasColumnType("nvarchar(max)");
                entity.HasOne(e => e.Kho)
                    .WithMany()
                    .HasForeignKey(e => e.KhoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // Nhập kho raw data (chi tiết phiếu xuất)
            modelBuilder.Entity<ChiTietPhieuXuatKho>(entity =>
            {
                entity.ToTable("tbl_DM_Xuat_Kho_Raw_Data");
                entity.Property(e => e.PhieuXuatKhoId)
                    .IsRequired()
                    .HasColumnName("Xuat_Kho_ID");
                entity.Property(e => e.SanPhamId)
                    .IsRequired()
                    .HasColumnName("San_Pham_ID");
                entity.Property(e => e.SoLuongXuat)
                    .IsRequired()
                    .HasColumnName("SL_Xuat")
                    .HasPrecision(18, 2); ;
                entity.Property(e => e.DonGiaXuat)
                    .IsRequired()
                    .HasColumnName("Don_Gia_Xuat")
                    .HasColumnType("decimal(18,2)")
                    .HasPrecision(18, 2); ;
                entity.HasOne(e => e.PhieuXuatKho)
                    .WithMany(p => p.ChiTietPhieuXuatKhos)
                    .HasForeignKey(e => e.PhieuXuatKhoId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.SanPham)
                    .WithMany()
                    .HasForeignKey(e => e.SanPhamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(u => u.UserName)
                      .IsUnique(); 

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(u => u.FullName)
                    .HasMaxLength(100);

                entity.Property(u => u.IsActive)
                    .HasDefaultValue(true);
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
