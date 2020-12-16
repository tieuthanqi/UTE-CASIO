 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DongHoCasio.Model;
using Microsoft.AspNetCore.Http;

namespace DongHoCasio.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DongHoCasioDbContext db = new DongHoCasioDbContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanPhams.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(string id)
        {
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

            // GET: Admin/Product/Create
            public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "MaLoai");
            SanPham sp = new SanPham();

            return View(sp);
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create (SanPham sanPham )
        { 
            if (sanPham.ImageUpload != null)
            {

                //string wwwfilesPath = @"D:\ThuongMaiDienTu\DoAn\DongHoCasio\DongHoCasio\Areas\Admin\Images\";
                string fileName = Path.GetFileNameWithoutExtension(sanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(sanPham.ImageUpload.FileName);
                fileName = fileName + extension;
                sanPham.Hinh = "/Areas/Admin/Contents/Images/" + fileName;
                sanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Areas/Admin/Contents/Images/"), fileName));
                //if (sanPham.Hinh != null)
                //{
                //    // edit 
                //    var imagePath = Path.Combine(wwwfilesPath, account.Image.TrimStart('\\'));
                //    if (System.IO.File.Exists(imagePath))
                //    {
                //        System.IO.File.Delete(imagePath);
                //    }

                //}
                
            }
            db.SanPhams.Add(sanPham);

            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TinhTrang", sanPham.MaLoai);
            return View();
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "MaLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanPham)
        {

            if (sanPham.ImageUpload != null)
            {

                //string wwwfilesPath = @"D:\ThuongMaiDienTu\DoAn\DongHoCasio\DongHoCasio\Areas\Admin\Images\";
                string fileName = Path.GetFileNameWithoutExtension(sanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(sanPham.ImageUpload.FileName);
                fileName = fileName + extension;
                sanPham.Hinh = "/Areas/Admin/Contents/Images/" + fileName;
                sanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Areas/Admin/Contents/Images/"), fileName));
               
            }

            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "MaLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(string id)
        {
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

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
