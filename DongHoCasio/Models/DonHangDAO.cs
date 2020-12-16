using DongHoCasio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DongHoCasio.Models
{
    public class DonHangDAO
    {
        DongHoCasioDbContext db = null;
        public DonHangDAO()
        {
            db = new DongHoCasioDbContext();
        }
        public int Insert(DonHang donHang)
        {
            db.DonHangs.Add(donHang);
            db.SaveChanges();
            return donHang.MaDH;

        }
    }

}