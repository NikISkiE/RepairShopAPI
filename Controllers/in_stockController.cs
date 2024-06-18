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
    public class in_stockController : ControllerBase
    {
        private readonly RepairShopAPIContext _context;

        public in_stockController(RepairShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/in_stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<in_stock>>> Getin_stock()
        {
            return await _context.in_stock.ToListAsync();
        }

        // GET: api/in_stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<in_stock>> Getin_stock(int id)
        {
            var in_stock = await _context.in_stock.FindAsync(id);

            if (in_stock == null)
            {
                return NotFound();
            }

            return in_stock;
        }

        // PUT: api/in_stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putin_stock(int id, in_stock in_stock)
        {
            if (id != in_stock.stock_id)
            {
                return BadRequest();
            }

            _context.Entry(in_stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!in_stockExists(id))
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

        // POST: api/in_stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<in_stock>> Postin_stock(in_stock in_stock)
        {
            _context.in_stock.Add(in_stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getin_stock", new { id = in_stock.stock_id }, in_stock);
        }

        // DELETE: api/in_stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletein_stock(int id)
        {
            var in_stock = await _context.in_stock.FindAsync(id);
            if (in_stock == null)
            {
                return NotFound();
            }

            _context.in_stock.Remove(in_stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool in_stockExists(int id)
        {
            return _context.in_stock.Any(e => e.stock_id == id);
        }
    }
}
