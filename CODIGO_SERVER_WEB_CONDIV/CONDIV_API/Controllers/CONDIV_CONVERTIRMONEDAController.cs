using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DAL;
using DAO.Models;
using CONDIV_API.BOL;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CONDIV_CONVERTIRMONEDAController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CONDIV_CONVERTIRMONEDAController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<CONDIV_TC_TIPO_CAMBIO>> PostCONDIV_TC_TIPO_CAMBIO(CONDIV_CONVERTIR_MONEDA CONDIV_CONVERTIR_MONEDA)
        {
            bool retorno = false;
            if (CONDIV_CONVERTIR_MONEDA == null)
            {
                return Ok(new { result = retorno });
            }
            CONDIV_BOL_CONVERTIR_MONEDA CONDIV_BOL_CONVERTIR_MONEDA = new CONDIV_BOL_CONVERTIR_MONEDA(_context);
            decimal MONTO_SALIDA = await CONDIV_BOL_CONVERTIR_MONEDA.CONVERTIR_MONEDA(CONDIV_CONVERTIR_MONEDA.ID_MONEDA_ORIGEN, CONDIV_CONVERTIR_MONEDA.ID_MONEDA_DESTINO, CONDIV_CONVERTIR_MONEDA.ID_CATEGORIA_CAMBIO, CONDIV_CONVERTIR_MONEDA.MONTO);
            int ID_TIPO_CAMBIO = await CONDIV_BOL_CONVERTIR_MONEDA.GET_ID_TIPO_CAMBIOO(CONDIV_CONVERTIR_MONEDA.ID_MONEDA_ORIGEN, CONDIV_CONVERTIR_MONEDA.ID_MONEDA_DESTINO, CONDIV_CONVERTIR_MONEDA.ID_CATEGORIA_CAMBIO, CONDIV_CONVERTIR_MONEDA.MONTO);

            CONDIV_TH_USUARIO_DIVISA CONDIV_TH_USUARIO_DIVISA = new CONDIV_TH_USUARIO_DIVISA();
            CONDIV_TH_USUARIO_DIVISA.ID_USUARIO = CONDIV_CONVERTIR_MONEDA.ID_USUARIO;
            CONDIV_TH_USUARIO_DIVISA.MO_ENTRADA = CONDIV_CONVERTIR_MONEDA.MONTO;
            CONDIV_TH_USUARIO_DIVISA.MO_SALIDA = MONTO_SALIDA;
            CONDIV_TH_USUARIO_DIVISA.ID_TIPO_CAMBIO = ID_TIPO_CAMBIO;
            CONDIV_TH_USUARIO_DIVISA.ES_REGISTRO = "A";
            CONDIV_TH_USUARIO_DIVISA.US_CREACION = "";
            CONDIV_TH_USUARIO_DIVISA.FE_CREACION = DateTime.Now;
            CONDIV_TH_USUARIO_DIVISA.IP_CREACION = "";
            CONDIV_TH_USUARIO_DIVISA.US_ACTUALIZACION = "";
            CONDIV_TH_USUARIO_DIVISA.FE_ACTUALIZACION = DateTime.Now;
            CONDIV_TH_USUARIO_DIVISA.IP_ACTUALIZACION = "";


            _context.CONDIV_TH_USUARIO_DIVISA.Add(CONDIV_TH_USUARIO_DIVISA);
            retorno = true;

            await _context.SaveChangesAsync();
            MONTO_SALIDA = decimal.Round(MONTO_SALIDA, 2);
            return Ok(new { result = MONTO_SALIDA });
        }
    }
}
