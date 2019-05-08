using DACS_CNPM.DAO;
using DACS_CNPM.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace DACS_CNPM.Controllers
{
    public class LoginController : Controller
    {
        DACSDbContext db = new DACSDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAction(Hoc_Vien acc)
        {
            if (!ModelState.IsValid)
            {
                UserDAO user = new UserDAO();

                var res = user.Login(acc.TenDn, acc.MatKhau);
                if (res == 1)
                {
                    var tai_khoan = db.Hoc_Vien.SingleOrDefault(x => x.TenDn == acc.TenDn);
                    Session["UserName"] = tai_khoan;
                    return RedirectToAction("Index", "Home");

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
            return View("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}
