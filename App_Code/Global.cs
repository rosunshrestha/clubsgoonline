using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clubsgoonline.App_Code
{
    public static class Global
    {
        static int _currentpage;
        public static int currentpage
        {
            get{return _currentpage;}
            set{_currentpage = value;}
        }
    }
}