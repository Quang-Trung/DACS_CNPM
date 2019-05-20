using DACS_CNPM.Areas.Admin.Models;
using DACS_CNPM.Common;
using DACS_CNPM.DAO;
using DACS_CNPM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DACS_CNPM.Areas.Admin.Controllers
{
    public class LoginAdController : Controller
    {
        // GET: Admin/LoginAd
        public ActionResult LoginAd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginActionAd(Quan_Tri acc)
        {
            if (ModelState.IsValid)
            {
                AdminDAO dao = new AdminDAO();

                var res = dao.Login(acc.TenDN, acc.MatKhau);
                if (res == 1)
                {
                    var admin = dao.GetById(acc.TenDN);
                    var adminSession = new AdminLogin();
                    adminSession.AdminId = admin.TenDN;
                    adminSession.AdminName = admin.TenDN;

                    Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                    return RedirectToAction("IndexAd", "HomeAd");

                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin tài khoản.");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LoginAd");
        }
    }
}
