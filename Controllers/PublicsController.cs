using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labka2.Models;

namespace Labka2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicsController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        public PublicsController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: api/Publics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public>>> GetPublics()
        {
          if (_context.Publics == null)
          {
              return NotFound();
          }
            return await _context.Publics.ToListAsync();
        }

        // GET: api/Publics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Public>> GetPublic(int id)
        {
          if (_context.Publics == null)
          {
              return NotFound();
          }
            var @public = await _context.Publics.FindAsync(id);

            if (@public == null)
            {
                return NotFound();
            }

            return @public;
        }

        // PUT: api/Publics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublic(int id, Public @public)
        {
            if (id != @public.Id)
            {
                return BadRequest();
            }

            _context.Entry(@public).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicExists(id))
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

        // POST: api/Publics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Public>> PostPublic(Public @public)
        {
          if (_context.Publics == null)
          {
              return Problem("Entity set 'SocialMediaContext.Publics'  is null.");
          }
            _context.Publics.Add(@public);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublic", new { id = @public.Id }, @public);
        }

        // DELETE: api/Publics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublic(int id)
        {
            if (_context.Publics == null)
            {
                return NotFound();
            }
            var @public = await _context.Publics.FindAsync(id);
            if (@public == null)
            {
                return NotFound();
            }

            _context.Publics.Remove(@public);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicExists(int id)
        {
            return (_context.Publics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
