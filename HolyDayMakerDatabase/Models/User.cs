using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolyDayMakerDatabase.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Account Account { get; set; }
        public Booking Booking { get; set; }
    }
}
