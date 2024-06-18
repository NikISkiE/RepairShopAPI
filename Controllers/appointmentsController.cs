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
    public class appointmentsController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public appointmentsController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<appointments>>> Getappointments()
        {
            return await _context.appointments.ToListAsync();
        }

        // GET: api/appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<appointments>> Getappointments(int id)
        {
            var appointments = await _context.appointments.FindAsync(id);

            if (appointments == null)
            {
                return NotFound();
            }

            return appointments;
        }

        // PUT: api/appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putappointments(int id, appointments appointments)
        {
            if (id != appointments.appointment_id)
            {
                return BadRequest();
            }

            _context.Entry(appointments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!appointmentsExists(id))
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

        // POST: api/appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<appointments>> Postappointments(appointments appointments)
        {
            _context.appointments.Add(appointments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getappointments", new { id = appointments.appointment_id }, appointments);
        }

        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteappointments(int id)
        {
            var appointments = await _context.appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }

            _context.appointments.Remove(appointments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool appointmentsExists(int id)
        {
            return _context.appointments.Any(e => e.appointment_id == id);
        }
    }
}
