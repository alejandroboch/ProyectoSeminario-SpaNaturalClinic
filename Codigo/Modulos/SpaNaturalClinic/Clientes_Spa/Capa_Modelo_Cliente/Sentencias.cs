using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Cliente
{
    public class Sentencias
    {
        // === Conexión en el formato que pediste ===
        Conexion con = new Conexion();

        //////// 1) “obtener datos de una tabla” (patrón que mostraste) ////////
        public OdbcDataAdapter llenarTbl(string sTabla)
        {
            string sSql = "SELECT * FROM " + sTabla + ";"; // usa nombre tal cual
            OdbcDataAdapter da = new OdbcDataAdapter(sSql, con.conexion());
            return da;
        }

        //////// 2) Listar clientes con encabezados explícitos ////////
        public OdbcDataAdapter fun_listar_clientes()
        {
            string sSql = @"SELECT pk_id_cliente, nombre, telefono, correo, es_vip
                            FROM tbl_clientes ORDER BY nombre;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        //////// 3) Búsqueda por texto (nombre/correo/teléfono) ////////
        public OdbcDataAdapter fun_buscar_clientes(string sTexto)
        {
            // En ODBC con DataAdapter es práctico usar LIKE directo (cuidado con comillas).
            string sSql = $@"SELECT pk_id_cliente, nombre, telefono, correo, es_vip
                             FROM tbl_clientes
                             WHERE nombre LIKE '%{sTexto.Replace("'", "''")}%'
                                OR correo LIKE '%{sTexto.Replace("'", "''")}%'
                                OR telefono LIKE '%{sTexto.Replace("'", "''")}%'
                             ORDER BY nombre;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }

        //////// 4) INSERT ////////
        public int pro_insertar_cliente(Cliente c)
        {
            string sSql = @"INSERT INTO tbl_clientes(nombre, telefono, correo, es_vip)
                            VALUES(?, ?, ?, ?);";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", c.sNombre ?? "");
                cmd.Parameters.AddWithValue("@p2", c.sTelefono ?? "");
                cmd.Parameters.AddWithValue("@p3", c.sCorreo ?? "");
                cmd.Parameters.AddWithValue("@p4", c.bEsVip ? 1 : 0);
                return cmd.ExecuteNonQuery();
            }
        }

        //////// 5) UPDATE ////////
        public int pro_actualizar_cliente(Cliente c)
        {
            string sSql = @"UPDATE tbl_clientes
                            SET nombre = ?, telefono = ?, correo = ?, es_vip = ?
                            WHERE pk_id_cliente = ?;";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", c.sNombre ?? "");
                cmd.Parameters.AddWithValue("@p2", c.sTelefono ?? "");
                cmd.Parameters.AddWithValue("@p3", c.sCorreo ?? "");
                cmd.Parameters.AddWithValue("@p4", c.bEsVip ? 1 : 0);
                cmd.Parameters.AddWithValue("@p5", c.iId);
                return cmd.ExecuteNonQuery();
            }
        }

        //////// 6) DELETE ////////
        public int pro_eliminar_cliente(int iId)
        {
            string sSql = "DELETE FROM tbl_clientes WHERE pk_id_cliente = ?;";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", iId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}