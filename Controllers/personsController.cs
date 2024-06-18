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
    public class personsController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public personsController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<persons>>> Getpersons()
        {
            return await _context.persons.ToListAsync();
        }

        // GET: api/persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<persons>> Getpersons(int id)
        {
            var persons = await _context.persons.FindAsync(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        // PUT: api/persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpersons(int id, persons persons)
        {
            if (id != persons.person_id)
            {
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personsExists(id))
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

        // POST: api/persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<persons>> Postpersons(persons persons)
        {
            _context.persons.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpersons", new { id = persons.person_id }, persons);
        }

        // DELETE: api/persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepersons(int id)
        {
            var persons = await _context.persons.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.persons.Remove(persons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool personsExists(int id)
        {
            return _context.persons.Any(e => e.person_id == id);
        }
    }
}
