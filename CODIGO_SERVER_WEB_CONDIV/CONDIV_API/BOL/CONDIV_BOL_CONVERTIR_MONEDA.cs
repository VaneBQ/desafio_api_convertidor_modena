using API.DAL;
using DAO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CONDIV_API.BOL
{
    public class CONDIV_BOL_CONVERTIR_MONEDA
    {
        private readonly ApplicationDbContext _context;

        public CONDIV_BOL_CONVERTIR_MONEDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<decimal> CONVERTIR_MONEDA(int ID_MONEDA_INGRESO, int ID_MONEDA_SALIDA, int ID_CATEGORIA_CAMBIO, decimal MONTO)
        {
            decimal MONTO_CALCULADO = 0;
            //ID_MONEDA_INGRESO = 1, int ID_MONEDA_SALIDA = 2, int ID_CATEGORIA_CAMBIO = 1 (VENTA), decimal MONTO = 1000

            CONDIV_TC_CONVERTIR_MONEDA CONDIV_TC_CONVERTIR_MONEDA = await _context.CONDIV_TC_CONVERTIR_MONEDA.Where(l => l.ID_MONEDA == ID_MONEDA_SALIDA).FirstOrDefaultAsync();
            CONDIV_TC_TIPO_CAMBIO CONDIV_TC_TIPO_CAMBIO = await _context.CONDIV_TC_TIPO_CAMBIO.Where(l => l.ID_CONVERTIR == CONDIV_TC_CONVERTIR_MONEDA.ID_CONVERTIR && l.ID_CATEGORIA_CAMBIO == ID_CATEGORIA_CAMBIO && l.ES_REGISTRO == "A").FirstOrDefaultAsync();

            switch (CONDIV_TC_CONVERTIR_MONEDA.FA_CONVERTIR_MONEDA)
            {
                case "/":
                    MONTO_CALCULADO = MONTO / CONDIV_TC_TIPO_CAMBIO.MO_TIPO_CAMBIO;
                    break;
                case "*":
                    MONTO_CALCULADO = MONTO * CONDIV_TC_TIPO_CAMBIO.MO_TIPO_CAMBIO;
                    break;
            }
            return MONTO_CALCULADO;
        }
        public async Task<int> GET_ID_TIPO_CAMBIOO(int ID_MONEDA_INGRESO, int ID_MONEDA_SALIDA, int ID_CATEGORIA_CAMBIO, decimal MONTO)
        {
            int ID_TIPO_CAMBIO = 0;

            CONDIV_TC_CONVERTIR_MONEDA CONDIV_TC_CONVERTIR_MONEDA = await _context.CONDIV_TC_CONVERTIR_MONEDA.Where(l => l.ID_MONEDA == ID_MONEDA_SALIDA).FirstOrDefaultAsync();
            CONDIV_TC_TIPO_CAMBIO CONDIV_TC_TIPO_CAMBIO = await _context.CONDIV_TC_TIPO_CAMBIO.Where(l => l.ID_CONVERTIR == CONDIV_TC_CONVERTIR_MONEDA.ID_CONVERTIR && l.ID_CATEGORIA_CAMBIO == ID_CATEGORIA_CAMBIO && l.ES_REGISTRO == "A").FirstOrDefaultAsync();
            ID_TIPO_CAMBIO = CONDIV_TC_TIPO_CAMBIO.ID_TIPO_CAMBIO;
            return ID_TIPO_CAMBIO;
        }
    }
}
