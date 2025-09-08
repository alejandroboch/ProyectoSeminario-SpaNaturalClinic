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

        public OdbcDataAdapter fun_listar_seguimientos()
        {
            string sql = @"SELECT s.pk_id_seguimiento, c.pk_id_cliente, c.nombre AS Cliente, s.fecha, s.servicio, s.monto, s.observaciones, c.es_vip 
                           FROM tbl_seguimiento_clientes s
                           JOIN tbl_clientes c ON s.fk_id_cliente = c.pk_id_cliente
                           ORDER BY s.fecha DESC;";
            return new OdbcDataAdapter(sql, con.conexion());
        }

        public OdbcDataAdapter fun_buscar_seguimientos(string textoBusqueda)
        {
            string sql = $@"SELECT s.pk_id_seguimiento, c.pk_id_cliente, c.nombre AS Cliente, s.fecha, s.servicio, s.monto, s.observaciones, c.es_vip 
                             FROM tbl_seguimiento_clientes s
                             JOIN tbl_clientes c ON s.fk_id_cliente = c.pk_id_cliente
                             WHERE c.nombre LIKE '%{textoBusqueda}%'
                             ORDER BY s.fecha DESC;";
            return new OdbcDataAdapter(sql, con.conexion());
        }

        public OdbcDataAdapter fun_obtener_clientes_combo()
        {
            string sql = "SELECT pk_id_cliente, nombre FROM tbl_clientes ORDER BY nombre;";
            return new OdbcDataAdapter(sql, con.conexion());
        }

        public int pro_insertar_seguimiento(Seguimiento s)
        {
            string sql = "INSERT INTO tbl_seguimiento_clientes(fk_id_cliente, fecha, servicio, monto, observaciones) VALUES(?, ?, ?, ?, ?);";
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", s.iIdCliente);
                cmd.Parameters.AddWithValue("@p2", s.dtFecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@p3", s.sServicio);
                // CORRECCIÓN FINAL: Convertir decimal a string
                cmd.Parameters.AddWithValue("@p4", s.dMonto.ToString(CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@p5", s.sObservaciones);
                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_actualizar_seguimiento(Seguimiento s)
        {
            string sql = "UPDATE tbl_seguimiento_clientes SET fk_id_cliente = ?, fecha = ?, servicio = ?, monto = ?, observaciones = ? WHERE pk_id_seguimiento = ?;";
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", s.iIdCliente);
                cmd.Parameters.AddWithValue("@p2", s.dtFecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@p3", s.sServicio);
                // CORRECCIÓN FINAL: Convertir decimal a string
                cmd.Parameters.AddWithValue("@p4", s.dMonto.ToString(CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@p5", s.sObservaciones);
                cmd.Parameters.AddWithValue("@p6", s.iIdSeguimiento);
                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_eliminar_seguimiento(int id)
        {
            string sql = "DELETE FROM tbl_seguimiento_clientes WHERE pk_id_seguimiento = ?;";
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}