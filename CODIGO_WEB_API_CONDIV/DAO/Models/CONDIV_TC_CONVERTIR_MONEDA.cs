using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class CONDIV_TC_CONVERTIR_MONEDA
    {
        [Key]
        public int ID_CONVERTIR_MONEDA { get; set; }
        public string FA_CONVERTIR_MONEDA { get; set; }
        public int ID_CONVERTIR { get; set; }
        public int ID_MONEDA { get; set; }
        public string ES_REGISTRO { get; set; }
        public string US_CREACION { get; set; }
        public DateTime FE_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string US_ACTUALIZACION { get; set; }
        public DateTime FE_ACTUALIZACION { get; set; }
        public string IP_ACTUALIZACION { get; set; }
    }
}
