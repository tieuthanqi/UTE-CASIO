using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHoCasio.Model;
namespace DongHoCasio.Controllers
{
    public class AccountController : Controller
    {
        DongHoCasioDbContext db = new DongHoCasioDbContext();

        [HttpGet]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password );
            if (user != null && user.Allowed == 1)
            {
                Session["username"] = user.UserName;

                ViewBag.username = user.UserName;
                return Redirect("/Admin/HomeAdmin/Index");

            }
            else if ( user != null && user.Allowed ==0)
            {
                Session["username"] = user.UserName;
                if(Session["CartSession"] == null)
                    Response.Redirect("/");
                else
                    Response.Redirect("/thanh-toan");
            }
            else if (user != null && user.Allowed == 2)
            {
                Session["username"] = user.UserName;
                
                Response.Redirect("/Shipper/DonHangShipper/Index");
            }


            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
            return View();
        }
        public ActionResult SingUp()
        {
            User user = new User();
            user.UserName = Request.Form["username"].ToString();
            user.Email = Request.Form["Email"].ToString();
            string pass = Request.Form["password"];
            user.Password = pass;
            user.Allowed = 0;
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return Redirect("/");
          
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return Redirect("/");
        }


    }
}