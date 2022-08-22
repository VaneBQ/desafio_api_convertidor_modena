using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class MonedaPrecio
    {
        [Key]
        public int IdMoneda { get; set; }
        public int IdMonedaOrigen { get; set; }
        public decimal Compra { get; set; }
        public decimal Venta { get; set; }
        public int IdMonedaDestino { get; set; }
        public DateTime Fecha { get; set; }
    }
}
