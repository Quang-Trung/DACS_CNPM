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
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập")]
        public string TenDN { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        public string MatKhau { get; set; }

        public string HoTen { get; set; }
    }
}
