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

        public DataTable fun_cargar_vips(string buscar = "")
        {
            using (var da = sn.fun_obtener_clientes_vip(buscar))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable fun_cargar_top_clientes(string buscar = "")
        {
            using (var da = sn.fun_obtener_top_clientes(buscar))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}