using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Seguimiento
{
    public class Seguimiento
    {
        public int iIdSeguimiento { get; set; }
        public int iIdCliente { get; set; }
        public DateTime dtFecha { get; set; }
        public string sServicio { get; set; }
        public decimal dMonto { get; set; }
        public string sObservaciones { get; set; }
    }
}
