using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolyDayMakerDatabase.Data;
using HolyDayMakerDatabase.Models;

namespace HolyDayMakerDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly HolyDayMakerDatabaseContext _context;

        public BookingsController(HolyDayMakerDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public IEnumerable<Booking> GetBooking()
        {
            return _context.Booking;
        }

        // GET: api/Bookings/5
        [HttpGet("{userid}")]
        public async Task<IActionResult> GetBooking([FromRoute] int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookings = _context.Booking.Where(x => x.UserID == userid).ToList();

            List<UserBooking> userbooking = new List<UserBooking>();

            foreach(var booking in bookings)
            {
                var r = _context.Room.Where(x => x.ID == booking.RoomID).FirstOrDefault();
                UserBooking ub = new UserBooking();
                ub.Room = r;
                ub.CheckinDate = booking.StartDate;
                ub.CheckoutDate = booking.EndDate;
                ub.BookingID = booking.ID;
                userbooking.Add(ub);
            }

            if (userbooking == null)
            {
                return NotFound();
            }

            return Ok(userbooking);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.ID)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> PostBooking([FromBody]List<Booking> booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach(var room in booking)
            {
                _context.Booking.Add(room);
            }

            //_context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }
    }
}