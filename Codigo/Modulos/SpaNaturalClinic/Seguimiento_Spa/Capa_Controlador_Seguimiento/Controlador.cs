using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Capa_Modelo_Seguimiento;

namespace Capa_Controlador_Seguimiento
{
    public class Controlador
    {
        private readonly Sentencias sn = new Sentencias();

        // Patrón llenarTbl: expone DataTable a la Vista
        public DataTable llenarTbl(string sTabla)
        {
            var da = sn.llenarTbl(sTabla);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable fun_listar()
        {
            var da = sn.fun_listar_seguimiento();
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable fun_buscar_por_cliente(string sNombre)
        {
            var da = sn.fun_buscar_por_cliente(sNombre ?? "");
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable fun_clientes_combo()
        {
            var da = sn.fun_listar_clientes_combo();
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Guardar / Actualizar / Eliminar
        public bool pro_guardar(Seguimiento s) => fun_validar(s) && sn.pro_insertar(s) > 0;
        public bool pro_actualizar(Seguimiento s) => s.iId > 0 && fun_validar(s) && sn.pro_actualizar(s) > 0;
        public bool pro_eliminar(int iId) => iId > 0 && sn.pro_eliminar(iId) > 0;

        // Reglas de validación (todos obligatorios salvo observaciones)
        private bool fun_validar(Seguimiento s)
        {
            if (s.iIdCliente <= 0) return false;
            if (string.IsNullOrWhiteSpace(s.sServicio)) return false;
            if (string.IsNullOrWhiteSpace(s.sFecha)) return false;

            // monto > 0
            if (s.dMonto <= 0) return false;

            // Fecha formato ISO yyyy-MM-dd simple (si quieres validar más, puedes hacer DateTime.TryParseExact)
            var okFecha = Regex.IsMatch(s.sFecha, @"^\d{4}-\d{2}-\d{2}$");
            if (!okFecha) return false;

            return true;
        }
    }
}
