using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace day07lab.Models;

public partial class K64cntt1dbContext : DbContext
{
    public K64cntt1dbContext()
    {
    }

    public K64cntt1dbContext(DbContextOptions<K64cntt1dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtHoaDon> CtHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=K64CNTT1DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CT_HOA_D__3214EC27425A3909");

            entity.ToTable("CT_HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.HoaDonId)
                .HasConstraintName("FK__CT_HOA_DO__HoaDo__5BE2A6F2");

            entity.HasOne(d => d.SanPham).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__CT_HOA_DO__SanPh__5CD6CB2B");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOA_DON__3214EC273F16AEE3");

            entity.ToTable("HOA_DON");

            entity.HasIndex(e => e.MaHoaDon, "UQ__HOA_DON__835ED13AA1AAFEF6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(255);
            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.NgayNhan).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhaHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhaHang)
                .HasConstraintName("FK__HOA_DON__MaKhaHa__59063A47");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHACH_HA__3214EC274DFB765E");

            entity.ToTable("KHACH_HANG");

            entity.HasIndex(e => e.DienThoai, "UQ__KHACH_HA__1F031876774E4C19").IsUnique();

            entity.HasIndex(e => e.MaKhachHang, "UQ__KHACH_HA__88D2F0E465E335DB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__KHACH_HA__A9D10534C3E99738").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(255);
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NgayDangKy).HasColumnType("datetime");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAI_SAN__3214EC2770F6A701");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.HasIndex(e => e.MaLoai, "UQ__LOAI_SAN__730A5758AE61F5C7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(255);
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUAN_TRI__3214EC27CE2AA489");

            entity.ToTable("QUAN_TRI");

            entity.HasIndex(e => e.TaiKhoan, "UQ__QUAN_TRI__D5B8C7F00B9BAFAF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SAN_PHAM__3214EC2760FB63B2");

            entity.ToTable("SAN_PHAM");

            entity.HasIndex(e => e.MaSanPham, "UQ__SAN_PHAM__FAC7442C6765F957").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__SAN_PHAM__MaLoai__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
