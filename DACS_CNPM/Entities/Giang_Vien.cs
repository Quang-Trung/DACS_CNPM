namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Giang_Vien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giang_Vien()
        {
            Khoa_hoc = new HashSet<Khoa_hoc>();
            Hoc_Vien = new HashSet<Hoc_Vien>();
        }

        [Key]
        public int MaGv { get; set; }

        public string HoTen { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public string Sdt { get; set; }

        public string DiaChi { get; set; }

        public string LyLich { get; set; }

        public string BangCap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public string HinhAnh { get; set; }

        [StringLength(100)]
        public string TenDn { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoa_hoc> Khoa_hoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoc_Vien> Hoc_Vien { get; set; }
    }
}
