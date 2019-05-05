namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bai_Hoc
    {
        [Key]
        public int MaBh { get; set; }

        public string TenBh { get; set; }

        public int? MaKh { get; set; }

        public string TaiLieu { get; set; }

        public virtual Khoa_hoc Khoa_hoc { get; set; }
    }
}
