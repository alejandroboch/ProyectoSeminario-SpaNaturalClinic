using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Paquetes;
using System.Data.Odbc;
using System.Data;

namespace Capa_Controlador_Paquetes
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

        public bool pro_guardar(Paquete p) => fun_validar(p) && sn.pro_insertar_paquete(p) > 0;
        public bool pro_actualizar(Paquete p) => p.iId > 0 && fun_validar(p) && sn.pro_actualizar_paquete(p) > 0;
        public bool pro_eliminar(int iId) => iId > 0 && sn.pro_eliminar_paquete(iId) > 0;
        private bool fun_validar(Paquete p)
        {
            if (string.IsNullOrWhiteSpace(p.sNombrePaquete)) return false;
            return true;
        }

        public DataTable fun_buscar_paquetes(string sTexto)
        {
            var da = sn.fun_buscar_paquete(sTexto ?? "");
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
