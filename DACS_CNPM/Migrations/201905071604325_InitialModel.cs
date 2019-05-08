namespace DACS_CNPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bai_Hoc",
                c => new
                    {
                        MaBh = c.Int(nullable: false, identity: true),
                        TenBh = c.String(),
                        MaKh = c.Int(),
                        TaiLieu = c.String(),
                    })
                .PrimaryKey(t => t.MaBh)
                .ForeignKey("dbo.Khoa_hoc", t => t.MaKh)
                .Index(t => t.MaKh);
            
            CreateTable(
                "dbo.Khoa_hoc",
                c => new
                    {
                        MaKh = c.Int(nullable: false, identity: true),
                        TenKh = c.String(),
                        MaMh = c.Int(),
                        MaLoai = c.Int(),
                        MaGv = c.Int(),
                        HocPhi = c.Decimal(storeType: "money"),
                        Mota = c.String(),
                        NgayKhaiGiang = c.DateTime(storeType: "date"),
                        Banner = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MaKh)
                .ForeignKey("dbo.Giang_Vien", t => t.MaGv)
                .ForeignKey("dbo.Loai_Khoa_Hoc", t => t.MaLoai)
                .ForeignKey("dbo.Mon_Hoc", t => t.MaMh)
                .Index(t => t.MaMh)
                .Index(t => t.MaLoai)
                .Index(t => t.MaGv);
            
            CreateTable(
                "dbo.Dang_Ky_KH",
                c => new
                    {
                        MaDk = c.Int(nullable: false, identity: true),
                        MaHv = c.Int(),
                        MaKh = c.Int(),
                        NgayDangKy = c.DateTime(storeType: "date"),
                        UuDai = c.Decimal(storeType: "money"),
                        ThanhToan = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.MaDk)
                .ForeignKey("dbo.Hoc_Vien", t => t.MaHv)
                .ForeignKey("dbo.Khoa_hoc", t => t.MaKh)
                .Index(t => t.MaHv)
                .Index(t => t.MaKh);
            
            CreateTable(
                "dbo.Hoc_Vien",
                c => new
                    {
                        MaHv = c.Int(nullable: false, identity: true),
                        TenDn = c.String(nullable: false, maxLength: 100, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 100, unicode: false),
                        HoTen = c.String(nullable: false),
                        DiaChi = c.String(),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sdt = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaLoaiTV = c.Int(),
                        NgaySinh = c.DateTime(storeType: "date"),
                        HinhAnh = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MaHv)
                .ForeignKey("dbo.Loai_TV", t => t.MaLoaiTV)
                .Index(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.CauHoi",
                c => new
                    {
                        MaCH = c.Int(nullable: false, identity: true),
                        CauHoi = c.String(),
                        PhanHoi = c.String(),
                        MaHv = c.Int(),
                        NgayDat = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.MaCH)
                .ForeignKey("dbo.Hoc_Vien", t => t.MaHv)
                .Index(t => t.MaHv);
            
            CreateTable(
                "dbo.Giang_Vien",
                c => new
                    {
                        MaGv = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        Email = c.String(),
                        Sdt = c.String(maxLength: 20, unicode: false),
                        DiaChi = c.String(),
                        LyLich = c.String(),
                        BangCap = c.String(),
                        NgaySinh = c.DateTime(storeType: "date"),
                        HinhAnh = c.String(unicode: false),
                        TenDn = c.String(maxLength: 100, unicode: false),
                        MatKhau = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaGv);
            
            CreateTable(
                "dbo.Loai_TV",
                c => new
                    {
                        MaLoaiTv = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                        UuDai = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.MaLoaiTv);
            
            CreateTable(
                "dbo.Loai_Khoa_Hoc",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.Mon_Hoc",
                c => new
                    {
                        MaMh = c.Int(nullable: false, identity: true),
                        TenMh = c.String(),
                    })
                .PrimaryKey(t => t.MaMh);
            
            CreateTable(
                "dbo.Quan_Tri",
                c => new
                    {
                        TenDN = c.String(nullable: false, maxLength: 100, unicode: false),
                        MatKhau = c.String(maxLength: 100, unicode: false),
                        HoTen = c.String(),
                    })
                .PrimaryKey(t => t.TenDN);
            
            CreateTable(
                "dbo.Theo_doi",
                c => new
                    {
                        MaGv = c.Int(nullable: false),
                        MaHv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaGv, t.MaHv })
                .ForeignKey("dbo.Giang_Vien", t => t.MaGv, cascadeDelete: true)
                .ForeignKey("dbo.Hoc_Vien", t => t.MaHv, cascadeDelete: true)
                .Index(t => t.MaGv)
                .Index(t => t.MaHv);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Khoa_hoc", "MaMh", "dbo.Mon_Hoc");
            DropForeignKey("dbo.Khoa_hoc", "MaLoai", "dbo.Loai_Khoa_Hoc");
            DropForeignKey("dbo.Dang_Ky_KH", "MaKh", "dbo.Khoa_hoc");
            DropForeignKey("dbo.Hoc_Vien", "MaLoaiTV", "dbo.Loai_TV");
            DropForeignKey("dbo.Khoa_hoc", "MaGv", "dbo.Giang_Vien");
            DropForeignKey("dbo.Theo_doi", "MaHv", "dbo.Hoc_Vien");
            DropForeignKey("dbo.Theo_doi", "MaGv", "dbo.Giang_Vien");
            DropForeignKey("dbo.Dang_Ky_KH", "MaHv", "dbo.Hoc_Vien");
            DropForeignKey("dbo.CauHoi", "MaHv", "dbo.Hoc_Vien");
            DropForeignKey("dbo.Bai_Hoc", "MaKh", "dbo.Khoa_hoc");
            DropIndex("dbo.Theo_doi", new[] { "MaHv" });
            DropIndex("dbo.Theo_doi", new[] { "MaGv" });
            DropIndex("dbo.CauHoi", new[] { "MaHv" });
            DropIndex("dbo.Hoc_Vien", new[] { "MaLoaiTV" });
            DropIndex("dbo.Dang_Ky_KH", new[] { "MaKh" });
            DropIndex("dbo.Dang_Ky_KH", new[] { "MaHv" });
            DropIndex("dbo.Khoa_hoc", new[] { "MaGv" });
            DropIndex("dbo.Khoa_hoc", new[] { "MaLoai" });
            DropIndex("dbo.Khoa_hoc", new[] { "MaMh" });
            DropIndex("dbo.Bai_Hoc", new[] { "MaKh" });
            DropTable("dbo.Theo_doi");
            DropTable("dbo.Quan_Tri");
            DropTable("dbo.Mon_Hoc");
            DropTable("dbo.Loai_Khoa_Hoc");
            DropTable("dbo.Loai_TV");
            DropTable("dbo.Giang_Vien");
            DropTable("dbo.CauHoi");
            DropTable("dbo.Hoc_Vien");
            DropTable("dbo.Dang_Ky_KH");
            DropTable("dbo.Khoa_hoc");
            DropTable("dbo.Bai_Hoc");
        }
    }
}
