using DACS_CNPM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS_CNPM.DAO
{
    public class UserDAO
    {
        DACSDbContext db;
        public UserDAO()
        {
            db = new DACSDbContext();
        }

        public Hoc_Vien GetById(string userName)
        {
            return db.Hoc_Vien.SingleOrDefault(x => x.TenDn == userName);
        }

        public bool Update(Hoc_Vien entity)
        {
            try {
                var user = db.Hoc_Vien.Find(entity.MaHv);
                user.HoTen = entity.HoTen;
                user.HinhAnh = entity.HinhAnh;
                user.NgaySinh = entity.NgaySinh;
                user.Sdt = entity.Sdt;
                db.SaveChanges();
                return true;
            } catch {
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
                var res = db.Hoc_Vien.SingleOrDefault(x => x.TenDn == tk);
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