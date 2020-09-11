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
    public class UserBookingsController : ControllerBase
    {
        private readonly HolyDayMakerDatabaseContext _context;

        public UserBookingsController(HolyDayMakerDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserBookings
        [HttpGet]
        public IEnumerable<UserBooking> GetUserBooking()
        {
            return _context.UserBooking;
        }

        // GET: api/UserBookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userBooking = await _context.UserBooking.FindAsync(id);

            if (userBooking == null)
            {
                return NotFound();
            }

            return Ok(userBooking);
        }

        // PUT: api/UserBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBooking([FromRoute] int id, [FromBody] UserBooking userBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userBooking.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBookingExists(id))
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

        // POST: api/UserBookings
        [HttpPost]
        public async Task<IActionResult> PostUserBooking([FromBody] UserBooking userBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserBooking.Add(userBooking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserBookingExists(userBooking.UserID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserBooking", new { id = userBooking.UserID }, userBooking);
        }

        // DELETE: api/UserBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userBooking = await _context.UserBooking.FindAsync(id);
            if (userBooking == null)
            {
                return NotFound();
            }

            _context.UserBooking.Remove(userBooking);
            await _context.SaveChangesAsync();

            return Ok(userBooking);
        }

        private bool UserBookingExists(int id)
        {
            return _context.UserBooking.Any(e => e.UserID == id);
        }
    }
}