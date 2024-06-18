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
    public class usedpartsController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public usedpartsController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/usedparts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<usedparts>>> Getusedparts()
        {
            return await _context.usedparts.ToListAsync();
        }

        // GET: api/usedparts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<usedparts>> Getusedparts(int id)
        {
            var usedparts = await _context.usedparts.FindAsync(id);

            if (usedparts == null)
            {
                return NotFound();
            }

            return usedparts;
        }

        // PUT: api/usedparts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusedparts(int id, usedparts usedparts)
        {
            if (id != usedparts.used_id)
            {
                return BadRequest();
            }

            _context.Entry(usedparts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usedpartsExists(id))
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

        // POST: api/usedparts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<usedparts>> Postusedparts(usedparts usedparts)
        {
            _context.usedparts.Add(usedparts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getusedparts", new { id = usedparts.used_id }, usedparts);
        }

        // DELETE: api/usedparts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusedparts(int id)
        {
            var usedparts = await _context.usedparts.FindAsync(id);
            if (usedparts == null)
            {
                return NotFound();
            }

            _context.usedparts.Remove(usedparts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool usedpartsExists(int id)
        {
            return _context.usedparts.Any(e => e.used_id == id);
        }
    }
}
