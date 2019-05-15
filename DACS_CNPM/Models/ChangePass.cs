using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS_CNPM.Models
{
    public class ChangePass
    {
        [Key]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu mới")]
        [Display(Name = "Mật khẩu Mới")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string MatKhaumoi { get; set; }

        [Required(ErrorMessage = "Vui lòng điền lại mật khẩu mới")]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string nhaplai { get; set; }
    }
}