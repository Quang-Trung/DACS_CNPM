namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Loai_TV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loai_TV()
        {
            Hoc_Vien = new HashSet<Hoc_Vien>();
        }

        [Key]
        public int MaLoaiTv { get; set; }

        public string TenLoai { get; set; }

        [Column(TypeName = "money")]
        public decimal? UuDai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoc_Vien> Hoc_Vien { get; set; }
    }
}
