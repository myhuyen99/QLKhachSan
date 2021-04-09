using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLKhachSan.Models
{
    public partial class QLKhachSanContext : DbContext
    {
        public QLKhachSanContext()
        {
        }

        public QLKhachSanContext(DbContextOptions<QLKhachSanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiet> Chitiet { get; set; }
        public virtual DbSet<ChitietGia> ChitietGia { get; set; }
        public virtual DbSet<Datphong> Datphong { get; set; }
        public virtual DbSet<Dichvu> Dichvu { get; set; }
        public virtual DbSet<Giaphong> Giaphong { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loaiphong> Loaiphong { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<Trangbi> Trangbi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H6NC501;Database=QLKhachSan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiet>(entity =>
            {
                entity.HasKey(e => e.CtMa)
                    .HasName("PK__CHITIET__DC4CD6EDBF7174AE");

                entity.ToTable("CHITIET");

                entity.Property(e => e.CtMa)
                    .HasColumnName("CT_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CtGia).HasColumnName("CT_GIA");

                entity.Property(e => e.CtThanhtien).HasColumnName("CT_THANHTIEN");

                entity.Property(e => e.DvMa)
                    .HasColumnName("DV_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HdMa)
                    .HasColumnName("HD_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DvMaNavigation)
                    .WithMany(p => p.Chitiet)
                    .HasForeignKey(d => d.DvMa)
                    .HasConstraintName("FK__CHITIET__DV_MA__31EC6D26");

                entity.HasOne(d => d.HdMaNavigation)
                    .WithMany(p => p.Chitiet)
                    .HasForeignKey(d => d.HdMa)
                    .HasConstraintName("FK__CHITIET__HD_MA__30F848ED");
            });

            modelBuilder.Entity<ChitietGia>(entity =>
            {
                entity.HasKey(e => e.CtgMa)
                    .HasName("PK__CHITIET___AEB709E9BD2E96CB");

                entity.ToTable("CHITIET_GIA");

                entity.Property(e => e.CtgMa)
                    .HasColumnName("CTG_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CtgTgapdungDenngay)
                    .HasColumnName("CTG_TGAPDUNG_DENNGAY")
                    .HasColumnType("date");

                entity.Property(e => e.CtgTgapdungTungay)
                    .HasColumnName("CTG_TGAPDUNG_TUNGAY")
                    .HasColumnType("date");

                entity.Property(e => e.GpMa)
                    .HasColumnName("GP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LpMa)
                    .HasColumnName("LP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.GpMaNavigation)
                    .WithMany(p => p.ChitietGia)
                    .HasForeignKey(d => d.GpMa)
                    .HasConstraintName("FK__CHITIET_G__GP_MA__35BCFE0A");

                entity.HasOne(d => d.LpMaNavigation)
                    .WithMany(p => p.ChitietGia)
                    .HasForeignKey(d => d.LpMa)
                    .HasConstraintName("FK__CHITIET_G__LP_MA__34C8D9D1");
            });

            modelBuilder.Entity<Datphong>(entity =>
            {
                entity.HasKey(e => e.DpMa)
                    .HasName("PK__DATPHONG__7E734E2ABDD5F12D");

                entity.ToTable("DATPHONG");

                entity.Property(e => e.DpMa)
                    .HasColumnName("DP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpTgnhan)
                    .HasColumnName("DP_TGNHAN")
                    .HasColumnType("date");

                entity.Property(e => e.DpTgtra)
                    .HasColumnName("DP_TGTRA")
                    .HasColumnType("date");

                entity.Property(e => e.KhMa)
                    .HasColumnName("KH_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NvMa)
                    .HasColumnName("NV_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.KhMaNavigation)
                    .WithMany(p => p.Datphong)
                    .HasForeignKey(d => d.KhMa)
                    .HasConstraintName("FK__DATPHONG__KH_MA__1BFD2C07");

                entity.HasOne(d => d.NvMaNavigation)
                    .WithMany(p => p.Datphong)
                    .HasForeignKey(d => d.NvMa)
                    .HasConstraintName("FK__DATPHONG__NV_MA__1CF15040");
            });

            modelBuilder.Entity<Dichvu>(entity =>
            {
                entity.HasKey(e => e.DvMa)
                    .HasName("PK__DICHVU__48CEB8F06C63EF0D");

                entity.ToTable("DICHVU");

                entity.Property(e => e.DvMa)
                    .HasColumnName("DV_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DvGia).HasColumnName("DV_GIA");

                entity.Property(e => e.DvSlnhap).HasColumnName("DV_SLNHAP");

                entity.Property(e => e.DvTen)
                    .HasColumnName("DV_TEN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DvTonkho).HasColumnName("DV_TONKHO");
            });

            modelBuilder.Entity<Giaphong>(entity =>
            {
                entity.HasKey(e => e.GpMa)
                    .HasName("PK__GIAPHONG__8EC1C4067F578DB3");

                entity.ToTable("GIAPHONG");

                entity.Property(e => e.GpMa)
                    .HasColumnName("GP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GpQuadem).HasColumnName("GP_QUADEM");

                entity.Property(e => e.GpTheongay).HasColumnName("GP_THEONGAY");

                entity.Property(e => e.GpTheothang).HasColumnName("GP_THEOTHANG");

                entity.Property(e => e.GpTheotuan).HasColumnName("GP_THEOTUAN");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.HdMa)
                    .HasName("PK__HOADON__8222DE1F0BC4CA53");

                entity.ToTable("HOADON");

                entity.Property(e => e.HdMa)
                    .HasColumnName("HD_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HdTgnhan)
                    .HasColumnName("HD_TGNHAN")
                    .HasColumnType("date");

                entity.Property(e => e.HdTgtra)
                    .HasColumnName("HD_TGTRA")
                    .HasColumnType("date");

                entity.Property(e => e.HdTongtien).HasColumnName("HD_TONGTIEN");

                entity.Property(e => e.KhMa)
                    .HasColumnName("KH_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NvMa)
                    .HasColumnName("NV_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PMa)
                    .HasColumnName("P_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.KhMaNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.KhMa)
                    .HasConstraintName("FK__HOADON__KH_MA__2C3393D0");

                entity.HasOne(d => d.NvMaNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.NvMa)
                    .HasConstraintName("FK__HOADON__NV_MA__2D27B809");

                entity.HasOne(d => d.PMaNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.PMa)
                    .HasConstraintName("FK__HOADON__P_MA__2E1BDC42");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.KhMa)
                    .HasName("PK__KHACHHAN__2415D8A19E99A56D");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.KhMa)
                    .HasColumnName("KH_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KhCmnd)
                    .HasColumnName("KH_CMND")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.KhDiachi)
                    .HasColumnName("KH_DIACHI")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KhEmail)
                    .HasColumnName("KH_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KhGioitinh)
                    .HasColumnName("KH_GIOITINH")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.KhHoten)
                    .HasColumnName("KH_HOTEN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KhSdt)
                    .HasColumnName("KH_SDT")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loaiphong>(entity =>
            {
                entity.HasKey(e => e.LpMa)
                    .HasName("PK__LOAIPHON__14A26B59E6CD9DEC");

                entity.ToTable("LOAIPHONG");

                entity.Property(e => e.LpMa)
                    .HasColumnName("LP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LpTenloai)
                    .HasColumnName("LP_TENLOAI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.NvMa)
                    .HasName("PK__NHANVIEN__E5064E10D6EBDE9E");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.NvMa)
                    .HasColumnName("NV_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NvMatkhau)
                    .HasColumnName("NV_MATKHAU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NvTendn)
                    .HasColumnName("NV_TENDN")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.PMa)
                    .HasName("PK__PHONG__A3422A05C9879A22");

                entity.ToTable("PHONG");

                entity.Property(e => e.PMa)
                    .HasColumnName("P_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LpMa)
                    .HasColumnName("LP_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PMota)
                    .HasColumnName("P_MOTA")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PSlgiuong).HasColumnName("P_SLGIUONG");

                entity.Property(e => e.PTen)
                    .HasColumnName("P_TEN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PTrangthai)
                    .HasColumnName("P_TRANGTHAI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LpMaNavigation)
                    .WithMany(p => p.Phong)
                    .HasForeignKey(d => d.LpMa)
                    .HasConstraintName("FK__PHONG__LP_MA__21B6055D");
            });

            modelBuilder.Entity<Trangbi>(entity =>
            {
                entity.HasKey(e => e.TbMa)
                    .HasName("PK__TRANGBI__B17B6DB3FC33F391");

                entity.ToTable("TRANGBI");

                entity.Property(e => e.TbMa)
                    .HasColumnName("TB_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PMa)
                    .HasColumnName("P_MA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TbMota)
                    .HasColumnName("TB_MOTA")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TbTen)
                    .HasColumnName("TB_TEN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PMaNavigation)
                    .WithMany(p => p.Trangbi)
                    .HasForeignKey(d => d.PMa)
                    .HasConstraintName("FK__TRANGBI__P_MA__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
