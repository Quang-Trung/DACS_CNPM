using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_CNPM.Entities;

namespace DACS_CNPM.Controllers
{
    public class Khoa_HocController : Controller
    {
        private DACSDbContext db = new DACSDbContext();

        // GET: Khoa_Hoc
        public ActionResult Index()
        {
            var dang_Ky_KH = db.Dang_Ky_KH.Include(d => d.Hoc_Vien).Include(d => d.Khoa_hoc);
            return View(dang_Ky_KH.ToList());
        }

        // GET: Khoa_Hoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dang_Ky_KH dang_Ky_KH = db.Dang_Ky_KH.Find(id);
            if (dang_Ky_KH == null)
            {
                return HttpNotFound();
            }
            return View(dang_Ky_KH);
        }

        // GET: Khoa_Hoc/Create
        public ActionResult Create()
        {
            ViewBag.MaHv = new SelectList(db.Hoc_Vien, "MaHv", "TenDn");
            ViewBag.MaKh = new SelectList(db.Khoa_hoc, "MaKh", "TenKh");
            return View();
        }

        // POST: Khoa_Hoc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDk,MaHv,MaKh,NgayDangKy,UuDai,ThanhToan")] Dang_Ky_KH dang_Ky_KH)
        {
            if (ModelState.IsValid)
            {
                db.Dang_Ky_KH.Add(dang_Ky_KH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHv = new SelectList(db.Hoc_Vien, "MaHv", "TenDn", dang_Ky_KH.MaHv);
            ViewBag.MaKh = new SelectList(db.Khoa_hoc, "MaKh", "TenKh", dang_Ky_KH.MaKh);
            return View(dang_Ky_KH);
        }

        // GET: Khoa_Hoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dang_Ky_KH dang_Ky_KH = db.Dang_Ky_KH.Find(id);
            if (dang_Ky_KH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHv = new SelectList(db.Hoc_Vien, "MaHv", "TenDn", dang_Ky_KH.MaHv);
            ViewBag.MaKh = new SelectList(db.Khoa_hoc, "MaKh", "TenKh", dang_Ky_KH.MaKh);
            return View(dang_Ky_KH);
        }

        // POST: Khoa_Hoc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDk,MaHv,MaKh,NgayDangKy,UuDai,ThanhToan")] Dang_Ky_KH dang_Ky_KH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dang_Ky_KH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHv = new SelectList(db.Hoc_Vien, "MaHv", "TenDn", dang_Ky_KH.MaHv);
            ViewBag.MaKh = new SelectList(db.Khoa_hoc, "MaKh", "TenKh", dang_Ky_KH.MaKh);
            return View(dang_Ky_KH);
        }

        // GET: Khoa_Hoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dang_Ky_KH dang_Ky_KH = db.Dang_Ky_KH.Find(id);
            if (dang_Ky_KH == null)
            {
                return HttpNotFound();
            }
            return View(dang_Ky_KH);
        }

        // POST: Khoa_Hoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dang_Ky_KH dang_Ky_KH = db.Dang_Ky_KH.Find(id);
            db.Dang_Ky_KH.Remove(dang_Ky_KH);
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
