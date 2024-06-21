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
    public class serials_locationController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public serials_locationController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/serials_location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<serials_location>>> Getserials_location()
        {
            return await _context.serials_location.ToListAsync();
        }

        // GET: api/serials_location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<serials_location>> Getserials_location(int id)
        {
            var serials_location = await _context.serials_location.FindAsync(id);

            if (serials_location == null)
            {
                return NotFound();
            }

            return serials_location;
        }

        // PUT: api/serials_location/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putserials_location(int id, serials_location serials_location)
        {
            if (id != serials_location.serial_id)
            {
                return BadRequest();
            }

            _context.Entry(serials_location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!serials_locationExists(id))
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

        // POST: api/serials_location
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<serials_location>> Postserials_location(serials_location serials_location)
        {
            _context.serials_location.Add(serials_location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getserials_location", new { id = serials_location.serial_id }, serials_location);
        }

        // DELETE: api/serials_location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteserials_location(int id)
        {
            var serials_location = await _context.serials_location.FindAsync(id);
            if (serials_location == null)
            {
                return NotFound();
            }

            _context.serials_location.Remove(serials_location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool serials_locationExists(int id)
        {
            return _context.serials_location.Any(e => e.serial_id == id);
        }
    }
}
