using DongHoCasio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DongHoCasio.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DongHoCasioDbContext db = new DongHoCasioDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string username, string password)
        {
            User user = db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password && x.Allowed == 1);
            if( user!= null)
            {
                Session["userid"] = user.UserID;
                Session["username"] = user.UserName;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index");

            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
            return View();
        }
    }
}