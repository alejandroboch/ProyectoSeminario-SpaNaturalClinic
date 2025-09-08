using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Globalization;

namespace Capa_Modelo_Seguimiento
{
    public class Sentencias
    {
        private readonly Conexion con = new Conexion();

        // Obtiene VIPs, ahora con filtro de búsqueda
        public OdbcDataAdapter fun_obtener_clientes_vip(string textoBusqueda)
        {
            // Si el texto está vacío, WHERE 1=1 no hace nada. Si tiene texto, filtra.
            string filtro = string.IsNullOrWhiteSpace(textoBusqueda) ? "1=1" : $"nombre LIKE '%{textoBusqueda}%'";
            string sql = $@"SELECT nombre, telefono, correo 
                            FROM tbl_clientes 
                            WHERE es_vip = 1 AND {filtro}
                            ORDER BY nombre;";
            return new OdbcDataAdapter(sql, con.conexion());
        }

        // Obtiene Top Clientes, ahora con MÁS DATOS y filtro de búsqueda
        public OdbcDataAdapter fun_obtener_top_clientes(string textoBusqueda)
        {
            string filtro = string.IsNullOrWhiteSpace(textoBusqueda) ? "1=1" : $"c.nombre LIKE '%{textoBusqueda}%'";
            // MEJORA: Ahora también calculamos SUM(t.total) para el gasto y MAX(t.fecha_cita) para la última visita.
            string sql = $@"SELECT 
                                c.nombre, 
                                COUNT(t.pk_id_cita) AS total_citas,
                                SUM(t.total) AS total_gastado,
                                MAX(t.fecha_cita) AS ultima_visita
                            FROM tbl_clientes c
                            JOIN tbl_citas t ON c.pk_id_cliente = t.fk_id_cliente
                            WHERE {filtro} AND t.estado = 'Finalizado' -- Solo contamos citas finalizadas
                            GROUP BY c.pk_id_cliente, c.nombre
                            ORDER BY total_citas DESC, total_gastado DESC;";
            return new OdbcDataAdapter(sql, con.conexion());
        }
    }
}