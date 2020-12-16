namespace DongHoCasio.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMai()
        {
            CTKMs = new HashSet<CTKM>();
        }

        [Key]
        public int MaKM { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianBD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKT { get; set; }

        [StringLength(200)]
        public string TenCTKM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTKM> CTKMs { get; set; }
    }
}
