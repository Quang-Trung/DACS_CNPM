using DACS_CNPM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS_CNPM.DAO
{
    public class AdminDAO
    {
        DACSDbContext db;
        public AdminDAO()
        {
            db = new DACSDbContext();
        }

        public Quan_Tri GetById(string userName)
        {
            return db.Quan_Tri.SingleOrDefault(x => x.TenDN == userName);
        }

        public bool Update(Quan_Tri entity)
        {
            try
            {
                var user = db.Hoc_Vien.Find(entity.TenDN);
                user.HoTen = entity.HoTen;
                user.MatKhau = entity.MatKhau;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public int Login(string tk, string mk)
        {
            if (tk == null || mk == null)
            {
                return -1;
            }
            else
            {
                var res = db.Quan_Tri.SingleOrDefault(x => x.TenDN == tk);
                if (res == null)
                {
                    return 0;
                }
                else
                {
                    if (res.MatKhau == mk)
                        return 1;
                    else
                        return -2;
                }
            }

        }
    }
}