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
    public class accountsController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public accountsController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<accounts>>> Getaccounts()
        {
            return await _context.accounts.ToListAsync();
        }

        // GET: api/accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<accounts>> Getaccounts(int id)
        {
            var accounts = await _context.accounts.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;
        }

        // PUT: api/accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccounts(int id, accounts accounts)
        {
            if (id != accounts.account_id)
            {
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountsExists(id))
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

        // POST: api/accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<accounts>> Postaccounts(accounts accounts)
        {
            _context.accounts.Add(accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaccounts", new { id = accounts.account_id }, accounts);
        }

        // DELETE: api/accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaccounts(int id)
        {
            var accounts = await _context.accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool accountsExists(int id)
        {
            return _context.accounts.Any(e => e.account_id == id);
        }
    }
}
