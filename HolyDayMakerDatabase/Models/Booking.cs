using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolyDayMakerDatabase.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public int UserID { get; set; }
    }
}
