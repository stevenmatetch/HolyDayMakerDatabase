using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolyDayMakerDatabase.Models;

namespace HolyDayMakerDatabase.Data
{
    public class HolyDayMakerDatabaseContext : DbContext
    {
        public HolyDayMakerDatabaseContext (DbContextOptions<HolyDayMakerDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<HolyDayMakerDatabase.Models.Account> Account { get; set; }

        public DbSet<HolyDayMakerDatabase.Models.Booking> Booking { get; set; }

        public DbSet<HolyDayMakerDatabase.Models.Room> Room { get; set; }

        public DbSet<HolyDayMakerDatabase.Models.Extra> Extra { get; set; }

        public DbSet<HolyDayMakerDatabase.Models.User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Models.UserBooking>().HasKey(ub => new { ub.UserID, ub.BookingID });

        }
        //public DbSet<HolyDayMakerDatabase.Models.UserBooking> UserBooking { get; set; }
    }

}
