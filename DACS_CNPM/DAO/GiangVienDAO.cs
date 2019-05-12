using DACS_CNPM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS_CNPM.DAO
{
    public class GiangVienDAO
    {
        DACSDbContext db;
        public GiangVienDAO()
        {
            db = new DACSDbContext();
        }

        public IQueryable<Giang_Vien> ListGV()
        {
            var res = (from sp in db.Giang_Vien select sp);
            return res;
        }

        //Xuất Giảng viên theo tên 
        public List<Giang_Vien> listTimkiem(string tenGv)
        {
            string search = "select * from Giang_Vien where TenGv like '%" + tenGv + "%'";
            var rs = db.Giang_Vien.SqlQuery(search).ToList();
            return rs;
        }
    }
}