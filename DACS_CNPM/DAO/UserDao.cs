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