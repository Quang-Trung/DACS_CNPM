using DACS_CNPM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS_CNPM.DAO
{ 
    public class KhoaHocDAO
    {
        DACSDbContext db;
        public KhoaHocDAO()
        {
            db = new DACSDbContext();
        }

        public IQueryable<Khoa_hoc> ListKH()
        {
            var res = (from sp in db.Khoa_hoc select sp);
            return res;
        }

        //Xuất danh sách khóa học theo môn
        public IQueryable<Khoa_hoc> ListKH(int? mh)
        {
            var res = (from sp in db.Khoa_hoc where sp.MaMh == mh select sp);
            return res;
        }

        //Xuất khóa học theo giảng viên
        public IQueryable<Khoa_hoc> ListKHGV(int? tl)
        {
            var res = (from sp in db.Khoa_hoc where sp.MaGv == tl select sp);
            return res;
        }

        //Xuất Khóa học theo tên 
        public List<Khoa_hoc> listTimkiem(string tenkh)
        {
            string search = "select * from Khoa_hoc where TenKh like '%" + tenkh + "%'";
            var rs = db.Khoa_hoc.SqlQuery(search).ToList();
            return rs;
        }
    }
}