using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Cliente;
using System.Data;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace Capa_Controlador_Cliente
{
    public class Controlador
    {
        private readonly Sentencias sn = new Sentencias();

        // ====== patrón que pediste (llenarTbl desde Controlador) ======
        public DataTable llenarTbl(string sTabla)
        {
            OdbcDataAdapter da = sn.llenarTbl(sTabla);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Listado específico de clientes
        public DataTable fun_listar_clientes()
        {
            var da = sn.fun_listar_clientes();
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Búsqueda
        public DataTable fun_buscar_clientes(string sTexto)
        {
            var da = sn.fun_buscar_clientes(sTexto ?? "");
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ====== CRUD ======
        public bool pro_guardar(Cliente c) => fun_validar(c) && sn.pro_insertar_cliente(c) > 0;
        public bool pro_actualizar(Cliente c) => c.iId > 0 && fun_validar(c) && sn.pro_actualizar_cliente(c) > 0;
        public bool pro_eliminar(int iId) => iId > 0 && sn.pro_eliminar_cliente(iId) > 0;

        // Validaciones mínimas (según estándar de tipos y sentido común)
        private bool fun_validar(Cliente c)
        {
            if (string.IsNullOrWhiteSpace(c.sNombre)) return false;
            if (!string.IsNullOrWhiteSpace(c.sCorreo))
            {
                var rgx = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                if (!rgx.IsMatch(c.sCorreo)) return false;
            }
            return true;
        }
    }
}