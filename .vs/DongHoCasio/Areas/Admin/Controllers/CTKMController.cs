using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DongHoCasio.Model;

namespace DongHoCasio.Areas.Admin.Controllers
{
    public class CTKMController : Controller
    {
        private DongHoCasioDbContext db = new DongHoCasioDbContext();

        // GET: Admin/CTKM
        public ActionResult Index()
        {
            var cTKMs = db.CTKMs.Include(c => c.KhuyenMai).Include(c => c.SanPham);
            return View(cTKMs.ToList());
        }

        // GET: Admin/CTKM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKM cTKM = db.CTKMs.Find(id);
            if (cTKM == null)
            {
                return HttpNotFound();
            }
            return View(cTKM);
        }

        // GET: Admin/CTKM/Create
        public ActionResult Create()
        {
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "MaKM");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP");
            return View();
        }

        // POST: Admin/CTKM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaKM,MaSP,PhanTram")] CTKM cTKM)
        {
            if (ModelState.IsValid)
            {
                db.CTKMs.Add(cTKM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "MaKH", cTKM.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", cTKM.MaSP);
            return View(cTKM);
        }

        // GET: Admin/CTKM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKM cTKM = db.CTKMs.Find(id);
            if (cTKM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "MaKM", cTKM.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", cTKM.MaSP);
            return View(cTKM);
        }

        // POST: Admin/CTKM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaKM,MaSP,PhanTram")] CTKM cTKM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTKM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "MaKM", "TenCTKM", cTKM.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaLoai", cTKM.MaSP);
            return View(cTKM);
        }

        // GET: Admin/CTKM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKM cTKM = db.CTKMs.Find(id);
            if (cTKM == null)
            {
                return HttpNotFound();
            }
            return View(cTKM);
        }

        // POST: Admin/CTKM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTKM cTKM = db.CTKMs.Find(id);
            db.CTKMs.Remove(cTKM);
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
