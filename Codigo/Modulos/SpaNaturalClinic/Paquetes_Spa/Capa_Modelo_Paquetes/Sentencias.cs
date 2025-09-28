using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Paquetes
{
    public class Sentencias
    {
        Conexion con = new Conexion();

        //////// 1) “obtener datos de una tabla”  ////////
        public OdbcDataAdapter llenarTbl(string sTabla)
        {
            string sSql = "SELECT * FROM " + sTabla + ";"; // usa nombre tal cual
            OdbcDataAdapter da = new OdbcDataAdapter(sSql, con.conexion());
            return da;
        }

        public int pro_insertar_paquete(Paquete p)
        {
            string sSql = @"INSERT INTO tbl_paquetes(nombre, precio_total, numero_sesiones) VALUES(?, ?, ?);";

            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.Add("@nombre", OdbcType.VarChar).Value = p.sNombrePaquete ?? "";
                // Convertimos a double para asegurar compatibilidad ODBC
                cmd.Parameters.Add("@precio_total", OdbcType.Double).Value = (double)p.dPrecioPaquete;
                cmd.Parameters.Add("@numero_sesiones", OdbcType.Int).Value = (int)p.iNumSesiones;

                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_actualizar_paquete(Paquete p)
        {
            string sSql = @"UPDATE tbl_paquetes
                    SET nombre = ?, precio_total = ?, numero_sesiones = ?
                    WHERE pk_id_paquete = ?;";

            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                // Orden de parámetros = orden de los '?'
                cmd.Parameters.Add("@nombre", OdbcType.VarChar).Value = p.sNombrePaquete ?? "";
                cmd.Parameters.Add("@precio_total", OdbcType.Double).Value = (double)p.dPrecioPaquete;
                cmd.Parameters.Add("@numero_sesiones", OdbcType.Int).Value = (int)p.iNumSesiones;
                cmd.Parameters.Add("@id", OdbcType.Int).Value = p.iId;

                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_eliminar_paquete(int iId)
        {
            string sSql = "DELETE FROM tbl_paquetes WHERE pk_id_paquete = ?;";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", iId);
                return cmd.ExecuteNonQuery();
            }
        }

        public OdbcDataAdapter fun_buscar_paquete(string sTexto)
        {
            // En ODBC con DataAdapter es práctico usar LIKE directo (cuidado con comillas).
            string sSql = $@"SELECT pk_id_paquete, nombre, precio_total, numero_sesiones
                             FROM tbl_paquetes
                             WHERE nombre LIKE '%{sTexto.Replace("'", "''")}%'                        
                             ORDER BY nombre;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }
    }
}
