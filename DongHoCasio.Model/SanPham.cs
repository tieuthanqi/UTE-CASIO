namespace DongHoCasio.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTKMs = new HashSet<CTKM>();
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            Hinh = @"/Areas/Admin/Contents/Images/BABY_G BGD-560WM-5.png";
        }

        [Key]
        [Required]
        [StringLength(30)]
        public string MaSP { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? NgayThem { get; set; }

        public int? SoLuongKho { get; set; }

        public int? SoLuongBan { get; set; }

        [StringLength(10)]
        public string MaLoai { get; set; }

        [StringLength(30)]
        public string TinhTrang { get; set; }

        [StringLength(500)]
        public string Hinh { get; set; }

        [Column(TypeName = "ntext")]
        public string TinhNang { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTKM> CTKMs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }


        [NotMapped]
        public  HttpPostedFileBase ImageUpload { get; set; }

    }
}
