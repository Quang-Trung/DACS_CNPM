using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_CNPM.Entities;

namespace DACS_CNPM.Areas.Admin.Controllers
{
    public class QLKhoaHocController : Controller
    {
        private DACSDbContext db = new DACSDbContext();

        // GET: Admin/QLKhoaHoc
        public ActionResult Index()
        {
            var khoa_hoc = db.Khoa_hoc.Include(k => k.Giang_Vien).Include(k => k.Loai_Khoa_Hoc).Include(k => k.Mon_Hoc);
            return View(khoa_hoc.ToList());
        }

        // GET: Admin/QLKhoaHoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa_hoc khoa_hoc = db.Khoa_hoc.Find(id);
            if (khoa_hoc == null)
            {
                return HttpNotFound();
            }
            return View(khoa_hoc);
        }

        // GET: Admin/QLKhoaHoc/Create
        public ActionResult Create()
        {
            ViewBag.MaGv = new SelectList(db.Giang_Vien, "MaGv", "HoTen");
            ViewBag.MaLoai = new SelectList(db.Loai_Khoa_Hoc, "MaLoai", "TenLoai");
            ViewBag.MaMh = new SelectList(db.Mon_Hoc, "MaMh", "TenMh");
            return View();
        }

        // POST: Admin/QLKhoaHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Khoa_hoc khoa_hoc, HttpPostedFileBase fileanh)
        {
            ViewBag.MaGv = new SelectList(db.Giang_Vien, "MaGv", "HoTen", khoa_hoc.MaGv);
            ViewBag.MaLoai = new SelectList(db.Loai_Khoa_Hoc, "MaLoai", "TenLoai", khoa_hoc.MaLoai);
            ViewBag.MaMh = new SelectList(db.Mon_Hoc, "MaMh", "TenMh", khoa_hoc.MaMh);
            if (fileanh != null)
            {
                var filename = Path.GetFileName(fileanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/KH_Image"), filename);
                fileanh.SaveAs(path);
                khoa_hoc.Banner = fileanh.FileName;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Khoa_hoc.Add(khoa_hoc);
                    db.SaveChanges();
                    SetAlert("Tạo mới thành công", "success");
                    return View(khoa_hoc);
                }
                else
                {
                    SetAlert("Tạo mới không thành công", "danger");
                    return View(khoa_hoc);

                }
            }
            catch
            {
                return View(khoa_hoc);
            }
        }

        // GET: Admin/QLKhoaHoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa_hoc khoa_hoc = db.Khoa_hoc.Find(id);
            if (khoa_hoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGv = new SelectList(db.Giang_Vien, "MaGv", "HoTen", khoa_hoc.MaGv);
            ViewBag.MaLoai = new SelectList(db.Loai_Khoa_Hoc, "MaLoai", "TenLoai", khoa_hoc.MaLoai);
            ViewBag.MaMh = new SelectList(db.Mon_Hoc, "MaMh", "TenMh", khoa_hoc.MaMh);
            return View(khoa_hoc);
        }

        // POST: Admin/QLKhoaHoc/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Khoa_hoc kh, HttpPostedFileBase fileanh)
        {
            ViewBag.MaGv = new SelectList(db.Giang_Vien, "MaGv", "HoTen", kh.MaGv);
            ViewBag.MaLoai = new SelectList(db.Loai_Khoa_Hoc, "MaLoai", "TenLoai", kh.MaLoai);
            ViewBag.MaMh = new SelectList(db.Mon_Hoc, "MaMh", "TenMh", kh.MaMh);
            Khoa_hoc khoa_hoc = db.Khoa_hoc.Find(kh.MaKh);
            if (fileanh != null)
            {
                var filename = Path.GetFileName(fileanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/KH_Image"), filename);
                fileanh.SaveAs(path);
                khoa_hoc.Banner = fileanh.FileName;
                khoa_hoc.MaGv = kh.MaGv;
                khoa_hoc.MaLoai = kh.MaLoai;
                khoa_hoc.TenKh = kh.TenKh;
                khoa_hoc.MaMh = kh.MaMh;
                khoa_hoc.HocPhi = kh.HocPhi;
                khoa_hoc.MoTa = kh.MoTa;
                khoa_hoc.NgayBatDau = kh.NgayBatDau;
            }
            else
            {
                khoa_hoc.MaGv = kh.MaGv;
                khoa_hoc.MaLoai = kh.MaLoai;
                khoa_hoc.TenKh = kh.TenKh;
                khoa_hoc.MaMh = kh.MaMh;
                khoa_hoc.HocPhi = kh.HocPhi;
                khoa_hoc.MoTa = kh.MoTa;
                khoa_hoc.NgayBatDau = kh.NgayBatDau;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                    SetAlert("Sửa thành công", "success");
                    return View(khoa_hoc);
                }
                else
                {
                    SetAlert("Sửa không thành công", "danger");
                    return View(khoa_hoc);

                }
            }
            catch
            {
                return View(khoa_hoc);
            }
        }

        //// GET: Admin/QLKhoaHoc/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Khoa_hoc khoa_hoc = db.Khoa_hoc.Find(id);
        //    if (khoa_hoc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(khoa_hoc);
        //}

        //// POST: Admin/QLKhoaHoc/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            Khoa_hoc sp = db.Khoa_hoc.SingleOrDefault(x => x.MaKh == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                try
                {
                    db.Khoa_hoc.Remove(sp);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
                catch (Exception)
                {
                    SetAlert("Không thể xóa khóa học đã được đăng ký", "danger");
                }

            }
            return Redirect(Request.UrlReferrer.ToString());
            
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
