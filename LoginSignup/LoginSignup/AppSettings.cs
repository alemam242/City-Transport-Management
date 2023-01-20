using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSignup
{
    public static class AppSettings
    {
        public static string Connection()
        {
            string constring = "Server = localhost; database = city_management; Uid = root; Pwd = ''; SslMode = none";
            return constring;
        }
    }
}
