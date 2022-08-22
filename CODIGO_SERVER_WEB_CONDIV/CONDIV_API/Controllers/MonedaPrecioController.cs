using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DAL;
using DAO.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaPrecioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonedaPrecioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MonedaPrecio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonedaPrecio>>> GetMonedaPrecio()
        {
          if (_context.MonedaPrecio == null)
          {
              return NotFound();
          }
            return await _context.MonedaPrecio.ToListAsync();
        }

        // GET: api/MonedaPrecio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonedaPrecio>> GetMonedaPrecio(int id)
        {
          if (_context.MonedaPrecio == null)
          {
              return NotFound();
          }
            var monedaPrecio = await _context.MonedaPrecio.FindAsync(id);

            if (monedaPrecio == null)
            {
                return NotFound();
            }

            return monedaPrecio;
        }

        // PUT: api/MonedaPrecio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonedaPrecio(int id, MonedaPrecio monedaPrecio)
        {
            if (id != monedaPrecio.IdMoneda)
            {
                return BadRequest();
            }

            _context.Entry(monedaPrecio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonedaPrecioExists(id))
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

        // POST: api/MonedaPrecio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonedaPrecio>> PostMonedaPrecio(MonedaPrecio monedaPrecio)
        {
          if (_context.MonedaPrecio == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MonedaPrecio'  is null.");
          }
            _context.MonedaPrecio.Add(monedaPrecio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonedaPrecio", new { id = monedaPrecio.IdMoneda }, monedaPrecio);
        }

        // DELETE: api/MonedaPrecio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonedaPrecio(int id)
        {
            if (_context.MonedaPrecio == null)
            {
                return NotFound();
            }
            var monedaPrecio = await _context.MonedaPrecio.FindAsync(id);
            if (monedaPrecio == null)
            {
                return NotFound();
            }

            _context.MonedaPrecio.Remove(monedaPrecio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonedaPrecioExists(int id)
        {
            return (_context.MonedaPrecio?.Any(e => e.IdMoneda == id)).GetValueOrDefault();
        }
    }
}
