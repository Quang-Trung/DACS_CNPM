using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_CNPM.Common;
using DACS_CNPM.Entities;

namespace DACS_CNPM.Controllers
{
    public class DK_Khoa_HocController : Controller
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

        public static int id_kh;
        public ActionResult Dang_ky(int id)
        {
            id_kh = id;
           
            var khoahoc_Session = new DK_KH();

            var khoa_hoc = db.Khoa_hoc.Find(id);
            khoahoc_Session.TenKh = khoa_hoc.TenKh;
            khoahoc_Session.MaKh = khoa_hoc.MaKh;

            Session.Add(CommonConstants.KHOAHOC_SESSION, khoahoc_Session);

            Khoa_hoc dangky = db.Khoa_hoc.Find(id);
            ViewBag.dang_ky = dangky;
            return View();
        }

        // POST: Khoa_Hoc/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dang_ky()
        {
            
            var session = (UserLogin)Session[DACS_CNPM.Common.CommonConstants.USER_SESSION];
            var khsession = (DK_KH)Session[DACS_CNPM.Common.CommonConstants.KHOAHOC_SESSION];


            Dang_Ky_KH test = db.Dang_Ky_KH.SingleOrDefault(x => x.MaHv == session.UserID && x.MaKh == khsession.MaKh);
            Dang_Ky_KH dang_ky = new Dang_Ky_KH();
            try {
                if (ModelState.IsValid && test == null)
                {
                    dang_ky.MaHv = session.UserID;
                    dang_ky.MaKh = khsession.MaKh;
                    dang_ky.NgayDangKy = DateTime.Now;
                    db.Dang_Ky_KH.Add(dang_ky);
                    db.SaveChanges();
                    SetAlert("Đăng ký thành công", "success");
                    return View();
                }
                else
                    SetAlert("Đăng ký không thành công", "danger");
            }
            catch(Exception)
            {
                SetAlert("Đăng ký không thành công", "danger");
            }
            return View();
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

        public void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "wanning")
            {
                TempData["AlertType"] = "alert-wanning";
            }
            else if (type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
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
