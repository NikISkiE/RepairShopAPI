using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairShopAPI;
using RepairShopAPI.Data;

namespace RepairShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class partsController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public partsController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<parts>>> Getparts()
        {
            return await _context.parts.ToListAsync();
        }

        // GET: api/parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<parts>> Getparts(int id)
        {
            var parts = await _context.parts.FindAsync(id);

            if (parts == null)
            {
                return NotFound();
            }

            return parts;
        }

        // PUT: api/parts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putparts(int id, parts parts)
        {
            if (id != parts.part_id)
            {
                return BadRequest();
            }

            _context.Entry(parts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!partsExists(id))
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

        // POST: api/parts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<parts>> Postparts(parts parts)
        {
            _context.parts.Add(parts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getparts", new { id = parts.part_id }, parts);
        }

        // DELETE: api/parts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteparts(int id)
        {
            var parts = await _context.parts.FindAsync(id);
            if (parts == null)
            {
                return NotFound();
            }

            _context.parts.Remove(parts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool partsExists(int id)
        {
            return _context.parts.Any(e => e.part_id == id);
        }
    }
}
