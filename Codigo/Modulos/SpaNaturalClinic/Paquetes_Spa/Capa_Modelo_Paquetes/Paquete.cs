using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Paquetes
{
    public class Paquete
    {
        public int iId { get; set; }            // pk_id_paquete
        public string sNombrePaquete { get; set; }     // nombre del paquete
        public decimal dPrecioPaquete { get; set; }   // precio del paquete
        public int iNumSesiones { get; set; }   // cantidad de sesiones del paquete
    }
}
