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
    public class CONDIV_TC_TIPO_CAMBIOController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TC_TIPO_CAMBIOController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TC_TIPO_CAMBIO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TC_TIPO_CAMBIO>>> GetCONDIV_TC_TIPO_CAMBIO()
        {
          if (_context.CONDIV_TC_TIPO_CAMBIO == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TC_TIPO_CAMBIO.ToListAsync();
        }

        // GET: api/CONDIV_TC_TIPO_CAMBIO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TC_TIPO_CAMBIO>> GetCONDIV_TC_TIPO_CAMBIO(int id)
        {
          if (_context.CONDIV_TC_TIPO_CAMBIO == null)
          {
              return NotFound();
          }
            var cONDIV_TC_TIPO_CAMBIO = await _context.CONDIV_TC_TIPO_CAMBIO.FindAsync(id);

            if (cONDIV_TC_TIPO_CAMBIO == null)
            {
                return NotFound();
            }

            return cONDIV_TC_TIPO_CAMBIO;
        }

        // PUT: api/CONDIV_TC_TIPO_CAMBIO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TC_TIPO_CAMBIO(int id, CONDIV_TC_TIPO_CAMBIO cONDIV_TC_TIPO_CAMBIO)
        {
            if (id != cONDIV_TC_TIPO_CAMBIO.ID_TIPO_CAMBIO)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TC_TIPO_CAMBIO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TC_TIPO_CAMBIOExists(id))
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

        // POST: api/CONDIV_TC_TIPO_CAMBIO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TC_TIPO_CAMBIO>> PostCONDIV_TC_TIPO_CAMBIO(CONDIV_TC_TIPO_CAMBIO cONDIV_TC_TIPO_CAMBIO)
        {
          if (_context.CONDIV_TC_TIPO_CAMBIO == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TC_TIPO_CAMBIO'  is null.");
          }
            _context.CONDIV_TC_TIPO_CAMBIO.Add(cONDIV_TC_TIPO_CAMBIO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TC_TIPO_CAMBIO", new { id = cONDIV_TC_TIPO_CAMBIO.ID_TIPO_CAMBIO }, cONDIV_TC_TIPO_CAMBIO);
        }

        // DELETE: api/CONDIV_TC_TIPO_CAMBIO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TC_TIPO_CAMBIO(int id)
        {
            if (_context.CONDIV_TC_TIPO_CAMBIO == null)
            {
                return NotFound();
            }
            var cONDIV_TC_TIPO_CAMBIO = await _context.CONDIV_TC_TIPO_CAMBIO.FindAsync(id);
            if (cONDIV_TC_TIPO_CAMBIO == null)
            {
                return NotFound();
            }

            _context.CONDIV_TC_TIPO_CAMBIO.Remove(cONDIV_TC_TIPO_CAMBIO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TC_TIPO_CAMBIOExists(int id)
        {
            return (_context.CONDIV_TC_TIPO_CAMBIO?.Any(e => e.ID_TIPO_CAMBIO == id)).GetValueOrDefault();
        }
    }
}
