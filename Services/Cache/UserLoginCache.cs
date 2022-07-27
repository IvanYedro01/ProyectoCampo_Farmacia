using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cache
{
    public static class UserLoginCache
    {
        public static int userId { get; set; }
        public static string firstName { get; set; }
        public static string position { get; set; }
        public static string email { get; set; }


    }
}
