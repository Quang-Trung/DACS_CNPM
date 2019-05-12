namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using DACS_CNPM.DAO;

    public partial class Khoa_hoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa_hoc()
        {
            Bai_Hoc = new HashSet<Bai_Hoc>();
            Dang_Ky_KH = new HashSet<Dang_Ky_KH>();
        }

        [Key]
        public int MaKh { get; set; }

        public string TenKh { get; set; }

        public int? MaMh { get; set; }

        public int? MaLoai { get; set; }

        public int? MaGv { get; set; }

        [Column(TypeName = "money")]
        public decimal? HocPhi { get; set; }

        public string Mota { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKhaiGiang { get; set; }

        public string Banner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bai_Hoc> Bai_Hoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dang_Ky_KH> Dang_Ky_KH { get; set; }

        public virtual Giang_Vien Giang_Vien { get; set; }

        public virtual Loai_Khoa_Hoc Loai_Khoa_Hoc { get; set; }

        public virtual Mon_Hoc Mon_Hoc { get; set; }

        public static implicit operator Khoa_hoc(KhoaHocDAO v)
        {
            throw new NotImplementedException();
        }
    }
}
