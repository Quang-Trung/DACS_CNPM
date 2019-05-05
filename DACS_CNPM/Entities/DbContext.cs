namespace DACS_CNPM.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=DACSDbContext")
        {
        }

        public virtual DbSet<Bai_Hoc> Bai_Hoc { get; set; }
        public virtual DbSet<CauHoi> CauHoi { get; set; }
        public virtual DbSet<Dang_Ky_KH> Dang_Ky_KH { get; set; }
        public virtual DbSet<Giang_Vien> Giang_Vien { get; set; }
        public virtual DbSet<Hoc_Vien> Hoc_Vien { get; set; }
        public virtual DbSet<Khoa_hoc> Khoa_hoc { get; set; }
        public virtual DbSet<Loai_Khoa_Hoc> Loai_Khoa_Hoc { get; set; }
        public virtual DbSet<Loai_TV> Loai_TV { get; set; }
        public virtual DbSet<Mon_Hoc> Mon_Hoc { get; set; }
        public virtual DbSet<Quan_Tri> Quan_Tri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dang_Ky_KH>()
                .Property(e => e.UuDai)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Dang_Ky_KH>()
                .Property(e => e.ThanhToan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.TenDn)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .HasMany(e => e.Hoc_Vien)
                .WithMany(e => e.Giang_Vien)
                .Map(m => m.ToTable("Theo_doi").MapLeftKey("MaGv").MapRightKey("MaHv"));

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.TenDn)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa_hoc>()
                .Property(e => e.HocPhi)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Khoa_hoc>()
                .Property(e => e.Banner)
                .IsUnicode(false);

            modelBuilder.Entity<Loai_TV>()
                .Property(e => e.UuDai)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Quan_Tri>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<Quan_Tri>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
