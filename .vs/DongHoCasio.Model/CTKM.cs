namespace DongHoCasio.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTKM")]
    public partial class CTKM
    {
        [Key]
        public int ID { get; set; }

        public int? MaKM { get; set; }

        [StringLength(30)]
        public string MaSP { get; set; }

        public int? PhanTram { get; set; }

        [StringLength(30)]
        public string TinhTrang { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
