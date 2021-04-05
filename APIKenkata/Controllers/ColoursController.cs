using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIKenkata.Data;
using APIKenkata.Models;

namespace APIKenkata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ColoursController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Colours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
        {
            return await _context.Colours.ToListAsync();
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colour>> GetColour(int id)
        {
            var colour = await _context.Colours.FindAsync(id);

            if (colour == null)
            {
                return NotFound();
            }

            return colour;
        }

        // PUT: api/Colours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int id, Colour colour)
        {
            if (id != colour.Id)
            {
                return BadRequest();
            }

            _context.Entry(colour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColourExists(id))
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

        // POST: api/Colours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColour(Colour colour)
        {
            _context.Colours.Add(colour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColour(int id)
        {
            var colour = await _context.Colours.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }

            _context.Colours.Remove(colour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColourExists(int id)
        {
            return _context.Colours.Any(e => e.Id == id);
        }
    }
}
