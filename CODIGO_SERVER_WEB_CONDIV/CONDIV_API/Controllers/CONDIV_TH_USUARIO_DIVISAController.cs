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
    public class CONDIV_TH_USUARIO_DIVISAController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TH_USUARIO_DIVISAController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TH_USUARIO_DIVISA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TH_USUARIO_DIVISA>>> GetCONDIV_TH_USUARIO_DIVISA()
        {
          if (_context.CONDIV_TH_USUARIO_DIVISA == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TH_USUARIO_DIVISA.ToListAsync();
        }

        // GET: api/CONDIV_TH_USUARIO_DIVISA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TH_USUARIO_DIVISA>> GetCONDIV_TH_USUARIO_DIVISA(int id)
        {
          if (_context.CONDIV_TH_USUARIO_DIVISA == null)
          {
              return NotFound();
          }
            var cONDIV_TH_USUARIO_DIVISA = await _context.CONDIV_TH_USUARIO_DIVISA.FindAsync(id);

            if (cONDIV_TH_USUARIO_DIVISA == null)
            {
                return NotFound();
            }

            return cONDIV_TH_USUARIO_DIVISA;
        }

        // PUT: api/CONDIV_TH_USUARIO_DIVISA/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TH_USUARIO_DIVISA(int id, CONDIV_TH_USUARIO_DIVISA cONDIV_TH_USUARIO_DIVISA)
        {
            if (id != cONDIV_TH_USUARIO_DIVISA.ID_USUARIO_DIVISA)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TH_USUARIO_DIVISA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TH_USUARIO_DIVISAExists(id))
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

        // POST: api/CONDIV_TH_USUARIO_DIVISA
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TH_USUARIO_DIVISA>> PostCONDIV_TH_USUARIO_DIVISA(CONDIV_TH_USUARIO_DIVISA cONDIV_TH_USUARIO_DIVISA)
        {
          if (_context.CONDIV_TH_USUARIO_DIVISA == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TH_USUARIO_DIVISA'  is null.");
          }
            _context.CONDIV_TH_USUARIO_DIVISA.Add(cONDIV_TH_USUARIO_DIVISA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TH_USUARIO_DIVISA", new { id = cONDIV_TH_USUARIO_DIVISA.ID_USUARIO_DIVISA }, cONDIV_TH_USUARIO_DIVISA);
        }

        // DELETE: api/CONDIV_TH_USUARIO_DIVISA/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TH_USUARIO_DIVISA(int id)
        {
            if (_context.CONDIV_TH_USUARIO_DIVISA == null)
            {
                return NotFound();
            }
            var cONDIV_TH_USUARIO_DIVISA = await _context.CONDIV_TH_USUARIO_DIVISA.FindAsync(id);
            if (cONDIV_TH_USUARIO_DIVISA == null)
            {
                return NotFound();
            }

            _context.CONDIV_TH_USUARIO_DIVISA.Remove(cONDIV_TH_USUARIO_DIVISA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TH_USUARIO_DIVISAExists(int id)
        {
            return (_context.CONDIV_TH_USUARIO_DIVISA?.Any(e => e.ID_USUARIO_DIVISA == id)).GetValueOrDefault();
        }
    }
}
