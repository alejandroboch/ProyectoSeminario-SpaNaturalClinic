using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_PaqServ
{
    public class Paquete_Servicio
    {
        public int iId { get; set; }            // pk_id_paquete
        public int iNombrePaquete { get; set; }     // nombre del paquete
        public int iNombreServicio { get; set; }   // nombre del servicio
        public int iNumSesion { get; set; }   // numero de sesiones al que pertenece
    }
}
