﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolyDayMakerDatabase.Models
{
    public class UserBooking
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookingID { get; set; }
        

    }
}
