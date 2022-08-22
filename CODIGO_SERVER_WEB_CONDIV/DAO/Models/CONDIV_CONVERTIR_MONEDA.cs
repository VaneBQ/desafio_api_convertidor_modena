using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class CONDIV_CONVERTIR_MONEDA
    {
        public int ID_USUARIO { get; set; }
        public int ID_MONEDA_ORIGEN { get; set; }
        public int ID_MONEDA_DESTINO { get; set; }
        public int ID_CATEGORIA_CAMBIO { get; set; }
        public decimal MONTO { get; set; }
    }
}
