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
            string sql = $@"
        SELECT 
            c.nombre, 
            COUNT(CASE WHEN t.estado = 'Finalizado' THEN t.pk_id_cita END) AS total_citas,
            SUM(CASE WHEN t.estado = 'Finalizado' THEN t.total ELSE 0 END) AS total_gastado,
            MAX(CASE WHEN t.estado = 'Finalizado' THEN t.fecha_cita END) AS ultima_visita
        FROM tbl_clientes c
        LEFT JOIN tbl_citas t ON c.pk_id_cliente = t.fk_id_cliente
        WHERE {filtro}
        GROUP BY c.pk_id_cliente, c.nombre
        ORDER BY total_citas DESC, total_gastado DESC;";
            return new OdbcDataAdapter(sql, con.conexion());
        }
    }
}