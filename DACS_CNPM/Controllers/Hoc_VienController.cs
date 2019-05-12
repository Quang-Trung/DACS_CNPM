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

namespace DACS_CNPM.Controllers
{
    public class Hoc_VienController : Controller
    {
        private DACSDbContext db = new DACSDbContext();

        // GET: Hoc_Vien
        public ActionResult Index()
        {
            var hoc_Vien = db.Hoc_Vien.Include(h => h.Loai_TV);
            return View(hoc_Vien.ToList());
        }

        // GET: Hoc_Vien/Details/5
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

        // GET: Hoc_Vien/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV.ToList().OrderBy(x => x.TenLoai), "MaLoaiTv", "TenLoai");

            return View();
        }

        // POST: Hoc_Vien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hoc_Vien hv, HttpPostedFileBase fileanh)
        {
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV.ToList().OrderBy(x => x.TenLoai), "MaLoaiTv", "TenLoai");

            if (fileanh != null)
            {
                var filename = Path.GetFileName(fileanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/HV_Image"), filename);
                fileanh.SaveAs(path);
                hv.HinhAnh = fileanh.FileName;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Hoc_Vien.Add(hv);
                    db.SaveChanges();
                    SetAlert("Đăng ký thành công", "success");
                    return View(hv);
                }
                else
                {
                    return View(hv);
                }
            }
            catch
            {
                return View(hv);
            }
        }

        // GET: Hoc_Vien/Edit/5
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
            else
            {
                ViewBag.MaLoaiTV = new SelectList(db.Loai_TV.ToList().OrderBy(x => x.TenLoai), "MaLoaiTv", "TenLoai");
                
                return View(hoc_Vien);
            }

        }

        // POST: Hoc_Vien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hoc_Vien hv, HttpPostedFileBase fileanh)
        {
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(hv.MaHv);
            if (fileanh == null)
            {
                hoc_Vien.HoTen = hv.HoTen;
                hoc_Vien.NgaySinh = hv.NgaySinh;
                hoc_Vien.Sdt = hv.Sdt;
                hoc_Vien.Email = hv.Email;
                hoc_Vien.DiaChi = hv.DiaChi;
            }
            else
            {
                var filename = Path.GetFileName(fileanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/HV_Image"), filename);
                fileanh.SaveAs(path);
                hoc_Vien.HinhAnh = fileanh.FileName;
                hoc_Vien.HoTen = hv.HoTen;
                hoc_Vien.NgaySinh = hv.NgaySinh;
                hoc_Vien.Sdt = hv.Sdt;
                hoc_Vien.Email = hv.Email;
                hoc_Vien.DiaChi = hv.DiaChi;
            }

            if (!ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Sửa thành công", "success");
            }
            else
            {
                SetAlert("Không sửa được", "danger");
                return View(hv);
            }
            return View(hv);
        }

        public ActionResult Matkhau(int? id)
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
            else
            {
                return View(hoc_Vien);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Matkhau(Hoc_Vien hv)
        {
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(hv.MaHv);
            hoc_Vien.MatKhau = hv.MatKhau;
            if (!ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Sửa thành công", "success");
            }
            else
            {
                SetAlert("Không sửa được", "danger");
                return View(hv);
            }
            return View(hv);
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
