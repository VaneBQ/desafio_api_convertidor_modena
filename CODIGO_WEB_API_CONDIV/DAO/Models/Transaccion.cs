using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Transaccion
    {
        [Key]
        public int IdTransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMonedaOrigen { get; set; }
        public decimal MontoIngresado { get; set; }
        public decimal MontoEgresado { get; set; }
        public int IdMonedaDestino { get; set; }
        public DateTime Fecha { get; set; }
    }
}
