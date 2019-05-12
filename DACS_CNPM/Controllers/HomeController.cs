using DACS_CNPM.DAO;
using DACS_CNPM.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS_CNPM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DACSDbContext db = new DACSDbContext();
        public static KhoaHocDAO KH = new KhoaHocDAO();
        IQueryable<Khoa_hoc> ListKhoaHoc = KH.ListKH();

        public static GiangVienDAO GV = new GiangVienDAO();
        IQueryable<Giang_Vien> ListGiangVien = GV.ListGV();

        //=========== Khóa học =====================================================
        public ActionResult KhoaHocTheoMon(int mh)
        {
            KhoaHocDAO KH = new KhoaHocDAO();
            IQueryable<Khoa_hoc> ListKhoaHoc = KH.ListKH(mh);
            return View(ListKhoaHoc);
        }
        public ActionResult KhoaHocTheoGiangVien(int gv)
        {
            KhoaHocDAO KH = new KhoaHocDAO();
            IQueryable<Khoa_hoc> ListKhoaHoc = KH.ListKHGV(gv);
            return View(ListKhoaHoc);
        }

        public ActionResult IndexKH(int? trang)
        {
            //return View(ListSanPham);
            int sosptrentrang = 6;
            int stttrang = (trang ?? 1);
            return View(db.Khoa_hoc.ToList().OrderBy(x => x.MaKh).ToPagedList(stttrang, sosptrentrang));
        }


        public ActionResult ChitietKhoaHoc(int id)
        {

            Khoa_hoc sptk = new Khoa_hoc();
            foreach (var item in ListKhoaHoc)
            {
                if (item.MaKh == id) sptk = item;
            }
            ViewBag.spct = sptk;
            return View();
        }
        public ActionResult timkiemKH(string tenkh)
        {
            KhoaHocDAO sp = new KhoaHocDAO();
            ViewData["TimKiemKH"] = sp.listTimkiem(tenkh);
            return View();
        }


        //============== Giảng Viên =======================================================

        public ActionResult IndexGV(int? trang)
        {
            //return View(ListSanPham);
            int sosptrentrang = 6;
            int stttrang = (trang ?? 1);
            return View(db.Giang_Vien.ToList().OrderBy(x => x.MaGv).ToPagedList(stttrang, sosptrentrang));
        }
        public ActionResult timkiemGV(string tengv)
        {
            GiangVienDAO sp = new GiangVienDAO();
            ViewData["TimKiemGV"] = sp.listTimkiem(tengv);
            return View();
        }

        //============== Theo dõi giảng viên ==================================================
        //============== Khóa học đã đăng ký ==================================================
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}