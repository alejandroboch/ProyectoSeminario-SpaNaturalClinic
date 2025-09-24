using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Servicios;
using System.Data.Odbc;
using System.Data;

namespace Capa_Controlador_Serv
{
    public class Controlador
    {
        private readonly Sentencias sn = new Sentencias();
        public DataTable llenarTbl(string sTabla)
        {
            OdbcDataAdapter da = sn.llenarTbl(sTabla);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool pro_guardar(Servicio s) => fun_validar(s) && sn.pro_insertar_servicio(s) > 0;
        public bool pro_actualizar(Servicio s) => s.iId > 0 && fun_validar(s) && sn.pro_actualizar_cliente(s) > 0;
        public bool pro_eliminar(int iId) => iId > 0 && sn.pro_eliminar_servicio(iId) > 0;
        private bool fun_validar(Servicio s)
        {
            if (string.IsNullOrWhiteSpace(s.sNombreServicio)) return false;
            return true;
        }

        public DataTable fun_buscar_servicio(string sTexto)
        {
            var da = sn.fun_buscar_servicio(sTexto ?? "");
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
