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
    public class SubsController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        public SubsController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: api/Subs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub>>> GetSubs()
        {
          if (_context.Subs == null)
          {
              return NotFound();
          }
            return await _context.Subs.ToListAsync();
        }

        // GET: api/Subs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sub>> GetSub(int id)
        {
          if (_context.Subs == null)
          {
              return NotFound();
          }
            var sub = await _context.Subs.FindAsync(id);

            if (sub == null)
            {
                return NotFound();
            }

            return sub;
        }

        // PUT: api/Subs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSub(int id, Sub sub)
        {
            if (id != sub.Id)
            {
                return BadRequest();
            }

            _context.Entry(sub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubExists(id))
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

        // POST: api/Subs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sub>> PostSub(Sub sub)
        {
          if (_context.Subs == null)
          {
              return Problem("Entity set 'SocialMediaContext.Subs'  is null.");
          }
            _context.Subs.Add(sub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSub", new { id = sub.Id }, sub);
        }

        // DELETE: api/Subs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSub(int id)
        {
            if (_context.Subs == null)
            {
                return NotFound();
            }
            var sub = await _context.Subs.FindAsync(id);
            if (sub == null)
            {
                return NotFound();
            }

            _context.Subs.Remove(sub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubExists(int id)
        {
            return (_context.Subs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
