using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DAL;
using DAO.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CONDIV_TC_MONEDAController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TC_MONEDAController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TC_MONEDA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TC_MONEDA>>> GetCONDIV_TC_MONEDA()
        {
          if (_context.CONDIV_TC_MONEDA == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TC_MONEDA.ToListAsync();
        }

        // GET: api/CONDIV_TC_MONEDA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TC_MONEDA>> GetCONDIV_TC_MONEDA(int id)
        {
          if (_context.CONDIV_TC_MONEDA == null)
          {
              return NotFound();
          }
            var cONDIV_TC_MONEDA = await _context.CONDIV_TC_MONEDA.FindAsync(id);

            if (cONDIV_TC_MONEDA == null)
            {
                return NotFound();
            }

            return cONDIV_TC_MONEDA;
        }

        // PUT: api/CONDIV_TC_MONEDA/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TC_MONEDA(int id, CONDIV_TC_MONEDA cONDIV_TC_MONEDA)
        {
            if (id != cONDIV_TC_MONEDA.ID_MONEDA)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TC_MONEDA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TC_MONEDAExists(id))
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

        // POST: api/CONDIV_TC_MONEDA
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TC_MONEDA>> PostCONDIV_TC_MONEDA(CONDIV_TC_MONEDA cONDIV_TC_MONEDA)
        {
          if (_context.CONDIV_TC_MONEDA == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TC_MONEDA'  is null.");
          }
            _context.CONDIV_TC_MONEDA.Add(cONDIV_TC_MONEDA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TC_MONEDA", new { id = cONDIV_TC_MONEDA.ID_MONEDA }, cONDIV_TC_MONEDA);
        }

        // DELETE: api/CONDIV_TC_MONEDA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TC_MONEDA(int id)
        {
            if (_context.CONDIV_TC_MONEDA == null)
            {
                return NotFound();
            }
            var cONDIV_TC_MONEDA = await _context.CONDIV_TC_MONEDA.FindAsync(id);
            if (cONDIV_TC_MONEDA == null)
            {
                return NotFound();
            }

            _context.CONDIV_TC_MONEDA.Remove(cONDIV_TC_MONEDA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TC_MONEDAExists(int id)
        {
            return (_context.CONDIV_TC_MONEDA?.Any(e => e.ID_MONEDA == id)).GetValueOrDefault();
        }
    }
}
