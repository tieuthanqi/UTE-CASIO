using DongHoCasio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DongHoCasio.Controllers
{
    public class HomeController : Controller
    {
        
        
        DongHoCasioDbContext db = new DongHoCasioDbContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayThem).Take(4).ToList();
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(4).ToList();

            return View();
        }
        public ActionResult SanPhamBanChay()
        {
           
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(100).ToList();

            return View();
        }
        
        public ActionResult SanPhamMoi()
        {
            ViewBag.TrangSanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayThem).Take(100).ToList();

            return View();
        }
        public ActionResult Details(string id)
        {
            //Tim san pham cos ma sp =id
           // SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}