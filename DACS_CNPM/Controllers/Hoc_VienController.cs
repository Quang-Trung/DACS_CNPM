using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_CNPM.DAO;
using DACS_CNPM.Entities;
using DACS_CNPM.Models;

namespace DACS_CNPM.Controllers
{
    public class Hoc_VienController : Controller
    {
        private DACSDbContext db = new DACSDbContext();

        //============== Quản lý tài khoản ============================================

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


        //================== Đăng ký tài khoản ===========================================================

        public ActionResult Create()
        {
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV.ToList().OrderBy(x => x.Tenloai), "MaLoaiTv", "TenLoai");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hoc_Vien hv, HttpPostedFileBase fileanh)
        {
            ViewBag.MaLoaiTV = new SelectList(db.Loai_TV.ToList().OrderBy(x => x.Tenloai), "MaLoaiTv", "TenLoai");

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

        //============== Sửa thông tin ===============================================================
        public ActionResult Edit(int? id)
        {
            Hoc_Vien sp = db.Hoc_Vien.SingleOrDefault(n => n.MaHv == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {

                return View(sp);
            }

        }


        [HttpPost]
        [ValidateInput(false)]
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


        public ActionResult Matkhau1(int? id)
        {
            ChangePass hoc_Vien = new ChangePass();
            return View(hoc_Vien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Matkhau1(ChangePass hv)
        {
            var session = (UserLogin)Session[DACS_CNPM.Common.CommonConstants.USER_SESSION];
            Hoc_Vien hoc_Vien = db.Hoc_Vien.Find(session.UserID);

            if (hv.MatKhau == null || hv.MatKhaumoi == null || hv.nhaplai == null)
            {
                SetAlert("Vui lòng điền đầu đủ các trường", "danger");
                return View(hv);
            }
            else
            {
                if (hv.MatKhau == hoc_Vien.MatKhau)
                {
                    if (hv.MatKhaumoi == hoc_Vien.MatKhau)
                    {
                        SetAlert("Mật khẩu mới trùng với mật khẩu cũ", "danger");
                        return View(hv);
                    }
                    else
                    {
                        if (hv.MatKhaumoi == hv.nhaplai)
                        {
                            hoc_Vien.MatKhau = hv.MatKhaumoi;
                            if (ModelState.IsValid)
                            {
                                db.SaveChanges();
                                SetAlert("Sửa thành công", "success");
                            }
                            else
                            {
                                SetAlert("Không sửa được", "danger");
                                return View(hv);
                            }
                        }
                        else
                        {
                            SetAlert("Nhập lại mật khẩu không trùng khớp", "danger");
                            return View(hv);
                        }
                    }
                }
                else
                {
                    SetAlert("Mật khẩu không đúng", "danger");
                    return View(hv);
                }
            }
            return View(hv);
        }

        //================= Khóa học đã đăng ký =====================================
        public ActionResult dangky(int id)
        {
            ViewBag.khoahoc = db.Khoa_hoc.ToList();
            ViewData["TimKiemDK"] = listTimkiem(id);
            return View();
        }
        public List<Dang_Ky_KH> listTimkiem(int id)
        {
            string search = "select * from Dang_Ky_KH where MaHv = '" + id + "'";
            var rs = db.Dang_Ky_KH.SqlQuery(search).ToList();
            return rs;
        }

        //=============================================================================
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
