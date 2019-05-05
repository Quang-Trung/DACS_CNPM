namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hoc_Vien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoc_Vien()
        {
            CauHoi = new HashSet<CauHoi>();
            Dang_Ky_KH = new HashSet<Dang_Ky_KH>();
            Giang_Vien = new HashSet<Giang_Vien>();
        }

        [Key]
        public int MaHv { get; set; }

        [StringLength(100)]
        public string TenDn { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public string Sdt { get; set; }

        public int? MaLoaiTV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dang_Ky_KH> Dang_Ky_KH { get; set; }

        public virtual Loai_TV Loai_TV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giang_Vien> Giang_Vien { get; set; }
    }
}
