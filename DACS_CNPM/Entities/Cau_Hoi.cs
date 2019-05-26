namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cau_Hoi
    {
        [Key]
        public int MaCh { get; set; }

        public string CauHoi { get; set; }

        public string PhanHoi { get; set; }

        public int? MaHv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public virtual Hoc_Vien Hoc_Vien { get; set; }
    }
}
