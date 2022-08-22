using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class CONDIV_TM_CATEGORIA_CAMBIO
    {
        [Key]
        public int ID_CATEGORIA_CAMBIO { get; set; }
        public string NO_CATEGORIA_CAMBIO { get; set; }
        public string ES_REGISTRO { get; set; }
        public string US_CREACION { get; set; }
        public DateTime FE_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string US_ACTUALIZACION { get; set; }
        public DateTime FE_ACTUALIZACION { get; set; }
        public string IP_ACTUALIZACION { get; set; }
    }
}
