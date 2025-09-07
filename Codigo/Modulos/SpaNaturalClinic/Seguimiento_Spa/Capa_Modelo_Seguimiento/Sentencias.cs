using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Seguimiento
{
    public class Sentencias
    {
        Conexion con = new Conexion();

        // 1) Patrón base: obtener tabla cruda
        public OdbcDataAdapter llenarTbl(string sTabla)
        {
            string sSql = "SELECT * FROM " + sTabla + ";";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        // 2) Listado con JOIN para mostrar nombre del cliente
        public OdbcDataAdapter fun_listar_seguimiento()
        {
            string sSql = @"
                SELECT s.pk_id_seguimiento, s.fk_id_cliente, c.nombre AS cliente,
                       s.fecha, s.servicio, s.monto, s.observaciones, s.es_frecuente
                FROM tbl_seguimiento_clientes s
                INNER JOIN tbl_clientes c ON c.pk_id_cliente = s.fk_id_cliente
                ORDER BY s.fecha DESC, c.nombre ASC;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        // 3) Búsqueda por nombre de cliente
        public OdbcDataAdapter fun_buscar_por_cliente(string sNombre)
        {
            string safe = sNombre.Replace("'", "''");
            string sSql = $@"
                SELECT s.pk_id_seguimiento, s.fk_id_cliente, c.nombre AS cliente,
                       s.fecha, s.servicio, s.monto, s.observaciones, s.es_frecuente
                FROM tbl_seguimiento_clientes s
                INNER JOIN tbl_clientes c ON c.pk_id_cliente = s.fk_id_cliente
                WHERE c.nombre LIKE '%{safe}%'
                ORDER BY s.fecha DESC, c.nombre ASC;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        // 4) Listar clientes (para ComboBox)
        public OdbcDataAdapter fun_listar_clientes_combo()
        {
            string sSql = @"SELECT pk_id_cliente, nombre FROM tbl_clientes ORDER BY nombre;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        // 5) INSERT
        public int pro_insertar(Seguimiento s)
        {
            string sql = @"
                INSERT INTO tbl_seguimiento_clientes
                    (fk_id_cliente, fecha, servicio, monto, observaciones, es_frecuente)
                VALUES (?, ?, ?, ?, ?, ?);";
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", s.iIdCliente);
                cmd.Parameters.AddWithValue("@p2", s.sFecha);
                cmd.Parameters.AddWithValue("@p3", s.sServicio ?? "");
                cmd.Parameters.AddWithValue("@p4", s.dMonto);
                cmd.Parameters.AddWithValue("@p5", (object)(s.sObs ?? ""));
                cmd.Parameters.AddWithValue("@p6", s.bFrecuente ? 1 : 0);
                return cmd.ExecuteNonQuery();
            }
        }

        // 6) UPDATE
        public int pro_actualizar(Seguimiento s)
        {
            string sql = @"
                UPDATE tbl_seguimiento_clientes
                   SET fk_id_cliente = ?, fecha = ?, servicio = ?, monto = ?, observaciones = ?, es_frecuente = ?
                 WHERE pk_id_seguimiento = ?;";
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", s.iIdCliente);
                cmd.Parameters.AddWithValue("@p2", s.sFecha);
                cmd.Parameters.AddWithValue("@p3", s.sServicio ?? "");
                cmd.Parameters.AddWithValue("@p4", s.dMonto);
                cmd.Parameters.AddWithValue("@p5", (object)(s.sObs ?? ""));
                cmd.Parameters.AddWithValue("@p6", s.bFrecuente ? 1 : 0);
                cmd.Parameters.AddWithValue("@p7", s.iId);
                return cmd.ExecuteNonQuery();
            }
        }

        // 7) DELETE
        public int pro_eliminar(int iId)
        {
            using (var cn = con.conexion())
            using (var cmd = new OdbcCommand("DELETE FROM tbl_seguimiento_clientes WHERE pk_id_seguimiento = ?;", cn))
            {
                cmd.Parameters.AddWithValue("@p1", iId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}