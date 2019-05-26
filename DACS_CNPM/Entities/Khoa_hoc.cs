namespace DACS_CNPM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Khoa_hoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa_hoc()
        {
            Bai_Hoc = new HashSet<Bai_Hoc>();
            Dang_Ky_KH = new HashSet<Dang_Ky_KH>();
        }

        [Key]
        public int MaKh { get; set; }

        [Display(Name = "Tên khóa học")]
        [Required(ErrorMessage ="Vui lòng điền tên khóa học")]
        public string TenKh { get; set; }

        [Display(Name = "Môn học")]
        public int? MaMh { get; set; }

        [Display(Name = "Loại khóa học")]
        public int? MaLoai { get; set; }

        [Display(Name = "Giảng viên phụ trách khóa học")]
        public int? MaGv { get; set; }

        [Display(Name = "Học phí")]
        [Required(ErrorMessage = "Vui lòng điền học phí khóa học")]
        public long? HocPhi { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Display(Name = "Hạn sử dụng")]
        public int? HanSuDung { get; set; }

        [Display(Name = "Banner")]
        public string Banner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bai_Hoc> Bai_Hoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dang_Ky_KH> Dang_Ky_KH { get; set; }

        public virtual Giang_Vien Giang_Vien { get; set; }

        public virtual Loai_Khoa_Hoc Loai_Khoa_Hoc { get; set; }

        public virtual Mon_Hoc Mon_Hoc { get; set; }
    }
}
