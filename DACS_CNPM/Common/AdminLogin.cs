using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS_CNPM.Common
{
    [Serializable]
    public class AdminLogin
    {
        public string AdminId { set; get; }
        public string AdminName { set; get; }
    }
}