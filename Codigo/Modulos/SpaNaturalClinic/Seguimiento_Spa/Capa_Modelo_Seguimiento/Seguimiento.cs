using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Seguimiento
{
    public class Seguimiento
    {
        public int iId { get; set; }            // pk_id_seguimiento
        public int iIdCliente { get; set; }     // fk_id_cliente
        public string sFecha { get; set; }      // yyyy-MM-dd (DATE)
        public string sServicio { get; set; }   // servicio
        public decimal dMonto { get; set; }     // monto
        public string sObs { get; set; }        // observaciones (opcional)
        public bool bFrecuente { get; set; }    // es_frecuente (0/1)
    }
}
