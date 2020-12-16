using DongHoCasio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DongHoCasio.Models
{
    public class ChiTietDonHangDAO
    {
        DongHoCasioDbContext db = null;
        public ChiTietDonHangDAO()
        {
            db = new DongHoCasioDbContext();
        }
        public bool Insert(ChiTietDonHang chiTiet)
        {

            db.ChiTietDonHangs.Add(chiTiet);
            db.SaveChanges();
            return true;



        }
    }
}