namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hoc_Vien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoc_Vien()
        {
            CauHoi = new HashSet<CauHoi>();
            Dang_Ky_KH = new HashSet<Dang_Ky_KH>();
            Giang_Vien = new HashSet<Giang_Vien>();
        }

        [Key]
        public int MaHv { get; set; }

        [Display(Name ="Tên đăng nhập")]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập")]
        public string TenDn { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [RegularExpression(@"^[ a-zA-ZẮẰẲẴẶĂẤẦẨẪẬÂÁÀÃẢẠĐẾỀỂỄỆÊÉÈẺẼẸÍÌỈĨỊỐỒỔỖỘÔỚỜỞỠỢƠÓÒÕỎỌỨỪỬỮỰƯÚÙỦŨỤÝỲỶỸỴắằẳẵặăấầẩẫậâáàãảạđếềểễệêéèẻẽẹíìỉĩịốồổỗộôớờởỡợơóòõỏọứừửữựưúùủũụýỳỷỹỵ]+$", ErrorMessage = "Họ và tên phải là chữ")]
        [Required(ErrorMessage = "Vui lòng điền họ tên")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email phải định dạnh abc@xxx.xyz")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Điện thoại liên hệ")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại phải là số")]
        [StringLength(20)]
        public string Sdt { get; set; }

        [Display(Name = "Loại thành viên")]
        public int? MaLoaiTV { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dang_Ky_KH> Dang_Ky_KH { get; set; }

        public virtual Loai_TV Loai_TV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giang_Vien> Giang_Vien { get; set; }
    }
}
