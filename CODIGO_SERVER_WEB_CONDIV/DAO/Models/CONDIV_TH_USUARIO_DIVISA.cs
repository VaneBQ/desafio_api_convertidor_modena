using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class CONDIV_TH_USUARIO_DIVISA
    {
        [Key]
        public int ID_USUARIO_DIVISA { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_TIPO_CAMBIO { get; set; }
        public decimal MO_ENTRADA { get; set; }
        public decimal MO_SALIDA { get; set; }
        public string ES_REGISTRO { get; set; }
        public string US_CREACION { get; set; }
        public DateTime FE_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string US_ACTUALIZACION { get; set; }
        public DateTime FE_ACTUALIZACION { get; set; }
        public string IP_ACTUALIZACION { get; set; }
    }
}
