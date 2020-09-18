using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolyDayMakerDatabase.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string NumberOfBeds { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
