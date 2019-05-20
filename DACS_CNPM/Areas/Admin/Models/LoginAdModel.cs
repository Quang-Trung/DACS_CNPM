using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS_CNPM.Areas.Admin.Models
{
    public class LoginAdModel
    {
        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập")]
        public string TenDN { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}