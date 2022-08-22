using API.DAL;
using DAO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using API.BOL;

namespace API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class CONDIV_TOKENController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CONDIV_TOKENController(IConfiguration config, ApplicationDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CONDIV_TC_USUARIO USUARIOPOST)
        {
            if (USUARIOPOST != null && USUARIOPOST.CO_USUARIO != null && USUARIOPOST.PW_USUARIO != null)
            {
                CONDIV_TC_USUARIO USUARIO = await GetUSUARIO(USUARIOPOST.CO_USUARIO, USUARIOPOST.PW_USUARIO);

                if (USUARIO != null)
                {
                    CONDIV_TOKEN CONDIV_TOKEN = new CONDIV_TOKEN();
                    string TOKEN = CONDIV_TOKEN.CREAR_TOKEN(USUARIO.ID_USUARIO, USUARIO.PW_USUARIO);
                    return Ok(TOKEN);
                }
                else
                {
                    return BadRequest("Acceso Invalido");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<CONDIV_TC_USUARIO> GetUSUARIO(string CO_USUARIO, string PW_USUARIO)
        {
            return await _context.CONDIV_TC_USUARIO.FirstOrDefaultAsync(u => u.CO_USUARIO == CO_USUARIO && u.PW_USUARIO == PW_USUARIO);
        }

    }
}
