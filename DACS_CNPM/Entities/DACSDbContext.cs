namespace DACS_CNPM.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DACSDbContext : DbContext
    {
        public DACSDbContext()
            : base("name=DACSDbContext")
        {
        }

        public virtual DbSet<Bai_Hoc> Bai_Hoc { get; set; }
        public virtual DbSet<Cau_Hoi> Cau_Hoi { get; set; }
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
            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Giang_Vien>()
                .HasMany(e => e.Hoc_Vien)
                .WithMany(e => e.Giang_Vien)
                .Map(m => m.ToTable("Theo_doi").MapLeftKey("MaGv").MapRightKey("MaHv"));

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.TenDn)
                .IsUnicode(false);

            modelBuilder.Entity<Hoc_Vien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Quan_Tri>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<Quan_Tri>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
