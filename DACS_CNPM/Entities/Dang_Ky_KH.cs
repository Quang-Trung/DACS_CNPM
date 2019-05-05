namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dang_Ky_KH
    {
        [Key]
        public int MaDk { get; set; }

        public int? MaHv { get; set; }

        public int? MaKh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "money")]
        public decimal? UuDai { get; set; }

        [Column(TypeName = "money")]
        public decimal? ThanhToan { get; set; }

        public virtual Hoc_Vien Hoc_Vien { get; set; }

        public virtual Khoa_hoc Khoa_hoc { get; set; }
    }
}
