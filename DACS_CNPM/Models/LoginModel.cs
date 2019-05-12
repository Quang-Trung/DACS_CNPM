using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS_CNPM.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập")]
        public string TenDn { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string MatKhau { get; set; }
    }
}