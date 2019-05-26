namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Giang_Vien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giang_Vien()
        {
            Khoa_hoc = new HashSet<Khoa_hoc>();
            Hoc_Vien = new HashSet<Hoc_Vien>();
        }

        [Key]
        public int MaGv { get; set; }
        [RegularExpression(@"^[ a-zA-ZẮẰẲẴẶĂẤẦẨẪẬÂÁÀÃẢẠĐẾỀỂỄỆÊÉÈẺẼẸÍÌỈĨỊỐỒỔỖỘÔỚỜỞỠỢƠÓÒÕỎỌỨỪỬỮỰƯÚÙỦŨỤÝỲỶỸỴắằẳẵặăấầẩẫậâáàãảạđếềểễệêéèẻẽẹíìỉĩịốồổỗộôớờởỡợơóòõỏọứừửữựưúùủũụýỳỷỹỵ]+$", ErrorMessage = "Họ và tên phải là chữ")]
        [Required(ErrorMessage = "Vui lòng điền họ tên")]
        [Display(Name = "Tên giảng viên")]
        public string HoTen { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email phải định dạnh abc@xxx.xyz")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Điện thoại liên hệ")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại phải là số")]
        [StringLength(13)]
        public string Sdt { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Lý lịch")]
        public string LyLich { get; set; }

        [Display(Name = "Bằng cấp")]
        public string BangCap { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoa_hoc> Khoa_hoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoc_Vien> Hoc_Vien { get; set; }
    }
}
