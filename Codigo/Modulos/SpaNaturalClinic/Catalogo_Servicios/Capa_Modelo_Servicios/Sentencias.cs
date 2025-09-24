using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Servicios
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

        public int pro_insertar_servicio(Servicio s)
        {
            string sSql = @"INSERT INTO tbl_servicios(nombre, precio) VALUES(?, ?);";

            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.Add("@nombre", OdbcType.VarChar).Value = s.sNombreServicio ?? "";
                // Convertimos a double para asegurar compatibilidad ODBC
                cmd.Parameters.Add("@precio", OdbcType.Double).Value = (double)s.dPrecioServicio;

                return cmd.ExecuteNonQuery();
            }
        }



        public int pro_actualizar_cliente(Servicio s)
        {
            string sSql = @"UPDATE tbl_servicios
                    SET nombre = ?, precio = ?
                    WHERE pk_id_servicio = ?;";

            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                // Orden de parámetros = orden de los '?'
                cmd.Parameters.Add("@nombre", OdbcType.VarChar).Value = s.sNombreServicio ?? "";
                cmd.Parameters.Add("@precio", OdbcType.Double).Value = (double)s.dPrecioServicio;
                cmd.Parameters.Add("@id", OdbcType.Int).Value = s.iId;

                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_eliminar_servicio(int iId)
        {
            string sSql = "DELETE FROM tbl_servicios WHERE pk_id_servicio = ?;";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", iId);
                return cmd.ExecuteNonQuery();
            }
        }

        public OdbcDataAdapter fun_buscar_servicio(string sTexto)
        {
            // En ODBC con DataAdapter es práctico usar LIKE directo (cuidado con comillas).
            string sSql = $@"SELECT pk_id_servicio, nombre, precio
                             FROM tbl_servicios
                             WHERE nombre LIKE '%{sTexto.Replace("'", "''")}%'                        
                             ORDER BY nombre;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

    }
}
