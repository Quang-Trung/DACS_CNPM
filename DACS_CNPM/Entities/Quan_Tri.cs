namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quan_Tri
    {
        [Key]
        [StringLength(100)]
        public string TenDN { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public string HoTen { get; set; }
    }
}
