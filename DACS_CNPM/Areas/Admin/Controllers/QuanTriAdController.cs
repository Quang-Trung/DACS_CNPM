using DACS_CNPM.Common;
using DACS_CNPM.Entities;
using DACS_CNPM.Models;
using System.Web.Mvc;

namespace DACS_CNPM.Areas.Admin.Controllers
{
    public class QuanTriAdController : Controller
    {
        // GET: Admin/QuanTriAd
        private DACSDbContext db = new DACSDbContext();
        public ActionResult Matkhau1()
        {
            ChangePass quan_tri = new ChangePass();
            return View(quan_tri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Matkhau1(ChangePass taikhoan)
        {
            var session = (AdminLogin)Session[DACS_CNPM.Common.CommonConstants.ADMIN_SESSION];
            Quan_Tri quan_Tri = db.Quan_Tri.Find(session.AdminId);

            if (taikhoan.MatKhau == null || taikhoan.MatKhaumoi == null || taikhoan.nhaplai == null)
            {
                SetAlert("Vui lòng điền đầu đủ các trường", "danger");
                return View(taikhoan);
            }
            else
            {
                if (taikhoan.MatKhau == quan_Tri.MatKhau)
                {
                    if (taikhoan.MatKhaumoi == quan_Tri.MatKhau)
                    {
                        SetAlert("Mật khẩu mới trùng với mật khẩu cũ", "danger");
                        return View(taikhoan);
                    }
                    else
                    {
                        if (taikhoan.MatKhaumoi == taikhoan.nhaplai)
                        {
                            quan_Tri.MatKhau = taikhoan.MatKhaumoi;
                            if (ModelState.IsValid)
                            {
                                db.SaveChanges();
                                SetAlert("Sửa thành công", "success");
                            }
                            else
                            {
                                SetAlert("Không sửa được", "danger");
                                return View(taikhoan);
                            }
                        }
                        else
                        {
                            SetAlert("Nhập lại mật khẩu không trùng khớp", "danger");
                            return View(taikhoan);
                        }
                    }
                }
                else
                {
                    SetAlert("Mật khẩu không đúng", "danger");
                    return View(taikhoan);
                }
            }
            return View(taikhoan);
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
    }
}