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
    public class CONDIV_TM_CATEGORIA_CAMBIOController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TM_CATEGORIA_CAMBIOController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TM_CATEGORIA_CAMBIO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TM_CATEGORIA_CAMBIO>>> GetCONDIV_TM_CATEGORIA_CAMBIO()
        {
          if (_context.CONDIV_TM_CATEGORIA_CAMBIO == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TM_CATEGORIA_CAMBIO.ToListAsync();
        }

        // GET: api/CONDIV_TM_CATEGORIA_CAMBIO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TM_CATEGORIA_CAMBIO>> GetCONDIV_TM_CATEGORIA_CAMBIO(int id)
        {
          if (_context.CONDIV_TM_CATEGORIA_CAMBIO == null)
          {
              return NotFound();
          }
            var cONDIV_TM_CATEGORIA_CAMBIO = await _context.CONDIV_TM_CATEGORIA_CAMBIO.FindAsync(id);

            if (cONDIV_TM_CATEGORIA_CAMBIO == null)
            {
                return NotFound();
            }

            return cONDIV_TM_CATEGORIA_CAMBIO;
        }

        // PUT: api/CONDIV_TM_CATEGORIA_CAMBIO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TM_CATEGORIA_CAMBIO(int id, CONDIV_TM_CATEGORIA_CAMBIO cONDIV_TM_CATEGORIA_CAMBIO)
        {
            if (id != cONDIV_TM_CATEGORIA_CAMBIO.ID_CATEGORIA_CAMBIO)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TM_CATEGORIA_CAMBIO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TM_CATEGORIA_CAMBIOExists(id))
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

        // POST: api/CONDIV_TM_CATEGORIA_CAMBIO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TM_CATEGORIA_CAMBIO>> PostCONDIV_TM_CATEGORIA_CAMBIO(CONDIV_TM_CATEGORIA_CAMBIO cONDIV_TM_CATEGORIA_CAMBIO)
        {
          if (_context.CONDIV_TM_CATEGORIA_CAMBIO == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TM_CATEGORIA_CAMBIO'  is null.");
          }
            _context.CONDIV_TM_CATEGORIA_CAMBIO.Add(cONDIV_TM_CATEGORIA_CAMBIO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TM_CATEGORIA_CAMBIO", new { id = cONDIV_TM_CATEGORIA_CAMBIO.ID_CATEGORIA_CAMBIO }, cONDIV_TM_CATEGORIA_CAMBIO);
        }

        // DELETE: api/CONDIV_TM_CATEGORIA_CAMBIO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TM_CATEGORIA_CAMBIO(int id)
        {
            if (_context.CONDIV_TM_CATEGORIA_CAMBIO == null)
            {
                return NotFound();
            }
            var cONDIV_TM_CATEGORIA_CAMBIO = await _context.CONDIV_TM_CATEGORIA_CAMBIO.FindAsync(id);
            if (cONDIV_TM_CATEGORIA_CAMBIO == null)
            {
                return NotFound();
            }

            _context.CONDIV_TM_CATEGORIA_CAMBIO.Remove(cONDIV_TM_CATEGORIA_CAMBIO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TM_CATEGORIA_CAMBIOExists(int id)
        {
            return (_context.CONDIV_TM_CATEGORIA_CAMBIO?.Any(e => e.ID_CATEGORIA_CAMBIO == id)).GetValueOrDefault();
        }
    }
}
