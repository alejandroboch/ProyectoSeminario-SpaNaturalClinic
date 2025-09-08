using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Capa_Modelo_Seguimiento;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Seguimiento
{
    public class Controlador
    {
        private readonly Sentencias sn = new Sentencias();

        public DataTable fun_obtener_lista_seguimientos()
        {
            using (var da = sn.fun_listar_seguimientos())
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable fun_buscar_seguimientos(string texto)
        {
            using (var da = sn.fun_buscar_seguimientos(texto))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable fun_obtener_clientes()
        {
            using (var da = sn.fun_obtener_clientes_combo())
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool pro_guardar_seguimiento(Seguimiento s)
        {
            return sn.pro_insertar_seguimiento(s) > 0;
        }

        public bool pro_actualizar_seguimiento(Seguimiento s)
        {
            return sn.pro_actualizar_seguimiento(s) > 0;
        }

        public bool pro_eliminar_seguimiento(int id)
        {
            return sn.pro_eliminar_seguimiento(id) > 0;
        }
    }
}