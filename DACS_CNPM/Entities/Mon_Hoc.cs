namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mon_Hoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mon_Hoc()
        {
            Khoa_hoc = new HashSet<Khoa_hoc>();
        }

        [Key]
        public int MaMh { get; set; }

        public string TenMh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoa_hoc> Khoa_hoc { get; set; }
    }
}
