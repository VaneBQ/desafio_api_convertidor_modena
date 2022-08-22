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
    public class CONDIV_TC_USUARIOController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_TC_USUARIOController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CONDIV_TC_USUARIO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDIV_TC_USUARIO>>> GetCONDIV_TC_USUARIO()
        {
          if (_context.CONDIV_TC_USUARIO == null)
          {
              return NotFound();
          }
            return await _context.CONDIV_TC_USUARIO.ToListAsync();
        }

        // GET: api/CONDIV_TC_USUARIO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CONDIV_TC_USUARIO>> GetCONDIV_TC_USUARIO(int id)
        {
          if (_context.CONDIV_TC_USUARIO == null)
          {
              return NotFound();
          }
            var cONDIV_TC_USUARIO = await _context.CONDIV_TC_USUARIO.FindAsync(id);

            if (cONDIV_TC_USUARIO == null)
            {
                return NotFound();
            }

            return cONDIV_TC_USUARIO;
        }

        // PUT: api/CONDIV_TC_USUARIO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCONDIV_TC_USUARIO(int id, CONDIV_TC_USUARIO cONDIV_TC_USUARIO)
        {
            if (id != cONDIV_TC_USUARIO.ID_USUARIO)
            {
                return BadRequest();
            }

            _context.Entry(cONDIV_TC_USUARIO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONDIV_TC_USUARIOExists(id))
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

        // POST: api/CONDIV_TC_USUARIO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CONDIV_TC_USUARIO>> PostCONDIV_TC_USUARIO(CONDIV_TC_USUARIO cONDIV_TC_USUARIO)
        {
          if (_context.CONDIV_TC_USUARIO == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CONDIV_TC_USUARIO'  is null.");
          }
            _context.CONDIV_TC_USUARIO.Add(cONDIV_TC_USUARIO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCONDIV_TC_USUARIO", new { id = cONDIV_TC_USUARIO.ID_USUARIO }, cONDIV_TC_USUARIO);
        }

        // DELETE: api/CONDIV_TC_USUARIO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCONDIV_TC_USUARIO(int id)
        {
            if (_context.CONDIV_TC_USUARIO == null)
            {
                return NotFound();
            }
            var cONDIV_TC_USUARIO = await _context.CONDIV_TC_USUARIO.FindAsync(id);
            if (cONDIV_TC_USUARIO == null)
            {
                return NotFound();
            }

            _context.CONDIV_TC_USUARIO.Remove(cONDIV_TC_USUARIO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CONDIV_TC_USUARIOExists(int id)
        {
            return (_context.CONDIV_TC_USUARIO?.Any(e => e.ID_USUARIO == id)).GetValueOrDefault();
        }
    }
}
