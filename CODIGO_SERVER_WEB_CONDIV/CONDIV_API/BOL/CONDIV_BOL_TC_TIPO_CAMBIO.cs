using API.DAL;
using DAO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CONDIV_API.BOL
{
    public class CONDIV_BOL_TC_TIPO_CAMBIO
    {
        private ApplicationDbContext _context;
        public CONDIV_BOL_TC_TIPO_CAMBIO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AGREGAR_TIPO_CAMBIO(CONDIV_TC_TIPO_CAMBIO CONDIV_TC_TIPO_CAMBIO)
        {
            bool retorno = false;

            CONDIV_TC_TIPO_CAMBIO CONDIV_TC_TIPO_CAMBIO_EXISTENTE = await _context.CONDIV_TC_TIPO_CAMBIO.FirstOrDefaultAsync(l => l.ID_CATEGORIA_CAMBIO == CONDIV_TC_TIPO_CAMBIO.ID_CATEGORIA_CAMBIO && l.ID_CONVERTIR == CONDIV_TC_TIPO_CAMBIO.ID_CONVERTIR && l.ES_REGISTRO == "A");
            CONDIV_TC_TIPO_CAMBIO_EXISTENTE.ES_REGISTRO = "F";
            /*_context.Entry(CONDIV_TC_TIPO_CAMBIO_EXISTENTE).State = EntityState.Modified;
            await _context.SaveChangesAsync();*/

            CONDIV_TC_TIPO_CAMBIO.ES_REGISTRO = "A";
            CONDIV_TC_TIPO_CAMBIO.FE_CREACION = DateTime.Now;
            CONDIV_TC_TIPO_CAMBIO.FE_ACTUALIZACION = DateTime.Now;
            CONDIV_TC_TIPO_CAMBIO.NO_TIPO_CAMBIO = "0";
            CONDIV_TC_TIPO_CAMBIO.MO_UNIDAD = 1;
            CONDIV_TC_TIPO_CAMBIO.US_CREACION = "";
            CONDIV_TC_TIPO_CAMBIO.IP_CREACION = "";
            CONDIV_TC_TIPO_CAMBIO.US_ACTUALIZACION = "";
            CONDIV_TC_TIPO_CAMBIO.IP_ACTUALIZACION = "";

            _context.CONDIV_TC_TIPO_CAMBIO.Add(CONDIV_TC_TIPO_CAMBIO);
            await _context.SaveChangesAsync();

            return retorno;
        }
    }
}
