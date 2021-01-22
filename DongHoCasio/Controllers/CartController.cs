using Common;
using DongHoCasio.Class;
using DongHoCasio.Model;
using DongHoCasio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DongHoCasio.Controllers
{
    public class CartController : Controller
    {
        DongHoCasioDbContext db = new DongHoCasioDbContext();
        public const string CartSession = "CartSession";
        private int tongTien;
        // GET: Cart
        public ActionResult Index()
         {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
                foreach (var item in list)
                {
                    tongTien += (int)item.SanPham.Gia * item.SoLuong;
                }
                ViewBag.TongTien = tongTien;

            }
            
            return View(list);
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List < CartItem >)Session[CartSession]; 
            foreach( var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if(jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }    
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            }) ;
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(string MaSP)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == MaSP);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(string maSP, int soLuong)
        {
            SanPham sanpham = db.SanPhams.Find(maSP);
            var cart = Session[CartSession];
            if (cart != null)
            {
                
                var list = (List<CartItem>)cart;
                if( list.Exists(x => x.SanPham.MaSP ==maSP))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaSP == maSP)
                        {
                            item.SoLuong += soLuong;
                            
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cart item
                    var item = new CartItem();
                    item.SanPham = sanpham;
                    item.SoLuong = soLuong;
                    list.Add(item);
                }
                //Gan vao session
                Session[CartSession] = list;
            }
            else
            {
                //tao moi doi tuong cart item
                var item = new CartItem();
                item.SanPham= sanpham;
                item.SoLuong = soLuong;
  
                var list = new List<CartItem>();
                list.Add(item);
                //Gan vao session
                Session[CartSession] = list;
            }

            ViewBag.TongTien = tongTien;
            return RedirectToAction("Index");

        }
        public ActionResult ThanhToan()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
                
            }
            return View(list);
           
        }

        [HttpPost]
        public ActionResult ThanhToan(string HoTenKH, string DiaChi, string SDT, string Email )
        {

            var cart = (List<CartItem>)Session[CartSession];
            foreach (var item in cart)
            {
                tongTien += item.SoLuong * (int)item.SanPham.Gia;
            }
            string ct = "Sản Phẩm       Số Lượng  \n";
            DonHang donHang = new DonHang();
            donHang.UserName = Session["username"].ToString();
            donHang.NgayMua = DateTime.Now;
            donHang.HoTenKH = HoTenKH;
            donHang.DiaChi = DiaChi;
            donHang.SDT = SDT;
            donHang.Email = Email;
            donHang.TrangThai = "Chờ xác nhận";
            donHang.TongTien = tongTien;
            var MaDH = new DonHangDAO().Insert(donHang);
            var chiTietDAO = new ChiTietDonHangDAO();
            foreach (var item in cart)
            {
                var chiTiet = new ChiTietDonHang();
                chiTiet.MaSP = item.SanPham.MaSP;
                chiTiet.MaDH = MaDH;
                chiTiet.Gia = item.SanPham.Gia;
                chiTiet.SoLuong = item.SoLuong;
                chiTietDAO.Insert(chiTiet);

                ct += item.SanPham.MaSP +"    " +item.SoLuong + "\n";
               
            }
            
           

            string content = System.IO.File.ReadAllText(Server.MapPath("/GuiEmail/neworder.html"));
            content = content.Replace("{{UserName}}", Session["username"].ToString());
            content = content.Replace("{{Phone}}", SDT);
            content = content.Replace("{{Email}}", Email);
            content = content.Replace("{{Address}}", DiaChi);
            content = content.Replace("{{Total}}", tongTien.ToString("N0"));
            content = content.Replace( "{{chitiet}}", ct);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            new MailHelper().SendMail(Email, "Đơn hàng mới từ Shop UTE-CASIO", content);
            new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Shop UTE-CASIO", content);
            return Redirect("/hoan-thanh");

        }

        public ActionResult HoanThanh()
        {
            Session.Clear();
            return View();
        }
       
    }
}