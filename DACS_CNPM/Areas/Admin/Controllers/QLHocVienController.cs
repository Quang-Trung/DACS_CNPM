using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_CNPM.Entities;

namespace DACS_CNPM.Areas.Admin.Controllers
{
    public class QLHocVienController : Controller
    {
        private DACSDbContext db = new DACSDbContext();

        // GET: Admin/QLHocVien
        public ActionResult Index()
        {
            var hoc_Vien = db.Hoc_Vien.Include(h => h.Loai_TV);
            return View(hoc_Vien.ToList());
        }

        // GET: Admin/QLHocVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(id);
            if (hoc_Vien == null)
            {
                return HttpNotFound();
            }
            return View(hoc_Vien);
        }

        // GET: Admin/QLHocVien/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV, "MaLoaiTv", "Tenloai");
            return View();
        }

        // POST: Admin/QLHocVien
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHv,HoTen,DiaChi,Email,Sdt,MaLoaiTV,NgaySinh,GioiTinh,HinhAnh,TenDn,MatKhau")] Hoc_Vien hoc_Vien)
        {
            if (ModelState.IsValid)
            {
                db.Hoc_Vien.Add(hoc_Vien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV, "MaLoaiTv", "Tenloai", hoc_Vien.MaLoaiTV);
            return View(hoc_Vien);
        }

        // GET: Admin/QLHocVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(id);
            if (hoc_Vien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV, "MaLoaiTv", "Tenloai", hoc_Vien.MaLoaiTV);
            return View(hoc_Vien);
        }

        // POST: Admin/QLHocVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHv,HoTen,DiaChi,Email,Sdt,MaLoaiTV,NgaySinh,GioiTinh,HinhAnh,TenDn,MatKhau")] Hoc_Vien hoc_Vien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoc_Vien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV, "MaLoaiTv", "Tenloai", hoc_Vien.MaLoaiTV);
            return View(hoc_Vien);
        }

        // GET: Admin/QLHocVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(id);
            if (hoc_Vien == null)
            {
                return HttpNotFound();
            }
            return View(hoc_Vien);
        }

        // POST: Admin/QLHocVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(id);
            db.Hoc_Vien.Remove(hoc_Vien);
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
