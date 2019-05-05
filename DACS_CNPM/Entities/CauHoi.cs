namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHoi")]
    public partial class CauHoi
    {
        [Key]
        public int MaCH { get; set; }

        [Column("CauHoi")]
        public string CauHoi1 { get; set; }

        public string PhanHoi { get; set; }

        public int? MaHv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public virtual Hoc_Vien Hoc_Vien { get; set; }
    }
}
