using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_PaqServ;
using System.Data.Odbc;
using System.Data;

namespace Capa_Controlador_PaqServ
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

        public DataTable obtenerPaquetesServiciosConNombres()
        {
            OdbcDataAdapter da = sn.llenarTblPaqueteServicioConNombres();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable pro_LlenarCombo(string nombreTabla, string nombreColumna, string idColumna)
{
    DataTable dt = new DataTable();
    sn.LlenarCombo(nombreTabla, nombreColumna, idColumna).Fill(dt);
    return dt;
}

        public bool pro_guardar(Paquete_Servicio ps) => fun_validar(ps) && sn.pro_insertar_paquete_servicio(ps) > 0;
        public bool pro_actualizar(Paquete_Servicio ps) => ps.iId > 0 && fun_validar(ps) && sn.pro_actualizar_paquete_servicio(ps) > 0;
        public bool pro_eliminar(int iId) => iId > 0 && sn.pro_eliminar_paquete_servicio(iId) > 0;
        private bool fun_validar(Paquete_Servicio ps)
        {
            if (ps.iNombrePaquete == 0) return false;
            return true;
        }

        public DataTable fun_buscar_paquetes_servicios(string sTexto)
        {
            var da = sn.fun_buscar_paquete_servicio(sTexto ?? "");
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
