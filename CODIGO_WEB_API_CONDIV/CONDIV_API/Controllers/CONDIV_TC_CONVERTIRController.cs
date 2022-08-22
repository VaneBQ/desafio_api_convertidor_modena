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
    public class CONDIV_TC_CONVERTIRController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TC_CONVERTIRController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TC_CONVERTIR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TC_CONVERTIR>>> GetCONDIV_TC_CONVERTIR()
        {
          if (_context.CONDIV_TC_CONVERTIR == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TC_CONVERTIR.ToListAsync();
        }

        // GET: api/CONDIV_TC_CONVERTIR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TC_CONVERTIR>> GetCONDIV_TC_CONVERTIR(int id)
        {
          if (_context.CONDIV_TC_CONVERTIR == null)
          {
              return NotFound();
          }
            var cONDIV_TC_CONVERTIR = await _context.CONDIV_TC_CONVERTIR.FindAsync(id);

            if (cONDIV_TC_CONVERTIR == null)
            {
                return NotFound();
            }

            return cONDIV_TC_CONVERTIR;
        }

        // PUT: api/CONDIV_TC_CONVERTIR/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TC_CONVERTIR(int id, CONDIV_TC_CONVERTIR cONDIV_TC_CONVERTIR)
        {
            if (id != cONDIV_TC_CONVERTIR.ID_CONVERTIR)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TC_CONVERTIR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TC_CONVERTIRExists(id))
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

        // POST: api/CONDIV_TC_CONVERTIR
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TC_CONVERTIR>> PostCONDIV_TC_CONVERTIR(CONDIV_TC_CONVERTIR cONDIV_TC_CONVERTIR)
        {
          if (_context.CONDIV_TC_CONVERTIR == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TC_CONVERTIR'  is null.");
          }
            _context.CONDIV_TC_CONVERTIR.Add(cONDIV_TC_CONVERTIR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TC_CONVERTIR", new { id = cONDIV_TC_CONVERTIR.ID_CONVERTIR }, cONDIV_TC_CONVERTIR);
        }

        // DELETE: api/CONDIV_TC_CONVERTIR/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TC_CONVERTIR(int id)
        {
            if (_context.CONDIV_TC_CONVERTIR == null)
            {
                return NotFound();
            }
            var cONDIV_TC_CONVERTIR = await _context.CONDIV_TC_CONVERTIR.FindAsync(id);
            if (cONDIV_TC_CONVERTIR == null)
            {
                return NotFound();
            }

            _context.CONDIV_TC_CONVERTIR.Remove(cONDIV_TC_CONVERTIR);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TC_CONVERTIRExists(int id)
        {
            return (_context.CONDIV_TC_CONVERTIR?.Any(e => e.ID_CONVERTIR == id)).GetValueOrDefault();
        }
    }
}
