using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Cliente
{
    public class Cliente
    {
        public int iId { get; set; }            // pk_id_cliente
        public string sNombre { get; set; }     // nombre
        public string sTelefono { get; set; }   // telefono
        public string sCorreo { get; set; }     // correo
        public bool bEsVip { get; set; }        // es_vip (0/1)
    }
}
