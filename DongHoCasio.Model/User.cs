namespace DongHoCasio.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Users")]
    public partial class User
    {
         
        [Key]
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

       
        [StringLength(500)]
        public string Avatar { get; set; }

        public int? Allowed { get; set; }

        [StringLength(200)]
        public string Status { get; set; }

    }
}
