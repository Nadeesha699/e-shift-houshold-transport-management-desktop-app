using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShift
{
    internal class SessionManager
    {
        public static long UserID { get; set; }
        public static long CustomerID { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; }
    }
}
