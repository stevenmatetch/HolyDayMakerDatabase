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
    public class ExtrasController : ControllerBase
    {
        private readonly HolyDayMakerDatabaseContext _context;

        public ExtrasController(HolyDayMakerDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Extras
        [HttpGet]
        public IEnumerable<Extra> GetExtra()
        {
            var result = _context.Extra;
            return _context.Extra;
        }

        // GET: api/Extras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExtra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra = await _context.Extra.FindAsync(id);

            if (extra == null)
            {
                return NotFound();
            }

            return Ok(extra);
        }

        // PUT: api/Extras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtra([FromRoute] int id, [FromBody] Extra extra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extra.ID)
            {
                return BadRequest();
            }

            _context.Entry(extra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(id))
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

        // POST: api/Extras
        [HttpPost]
        public async Task<IActionResult> PostExtra([FromBody] Extra extra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Extra.Add(extra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtra", new { id = extra.ID }, extra);
        }

        // DELETE: api/Extras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra = await _context.Extra.FindAsync(id);
            if (extra == null)
            {
                return NotFound();
            }

            _context.Extra.Remove(extra);
            await _context.SaveChangesAsync();

            return Ok(extra);
        }

        private bool ExtraExists(int id)
        {
            return _context.Extra.Any(e => e.ID == id);
        }
    }
}