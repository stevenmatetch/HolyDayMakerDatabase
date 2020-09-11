using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolyDayMakerDatabase.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
    }
}
