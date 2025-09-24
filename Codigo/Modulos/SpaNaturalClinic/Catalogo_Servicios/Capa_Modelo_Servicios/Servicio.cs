using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Servicios
{
    public class Servicio
    {
        public int iId { get; set; }            // pk_id_servicio
        public string sNombreServicio { get; set; }     // nombre del servicio
        public decimal dPrecioServicio { get; set; }   // precio del servicio
    }
}
