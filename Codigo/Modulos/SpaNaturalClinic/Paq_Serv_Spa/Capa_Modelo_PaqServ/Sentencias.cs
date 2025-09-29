using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;



namespace Capa_Modelo_PaqServ
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

        public OdbcDataAdapter llenarTblPaqueteServicioConNombres()
        {
            string sSql = @"
        SELECT 
            ps.pk_id_paquete_servicio,
            p.nombre AS nombre_paquete,
            s.nombre AS nombre_servicio,
            ps.numero_sesion
        FROM tbl_paquete_servicio ps
        INNER JOIN tbl_paquetes p ON ps.fk_id_paquete = p.pk_id_paquete
        INNER JOIN tbl_servicios s ON ps.fk_id_servicio = s.pk_id_servicio;
    ";

            OdbcDataAdapter da = new OdbcDataAdapter(sSql, con.conexion());
            return da;
        }

        public OdbcDataAdapter LlenarCombo(string nombreTabla, string nombreColumna, string idColumna)
        {
            string sql = $"SELECT {idColumna}, {nombreColumna} FROM {nombreTabla};";
            OdbcDataAdapter da = new OdbcDataAdapter(sql, con.conexion());
            return da;
        }



        public int pro_insertar_paquete_servicio(Paquete_Servicio ps)
        {
            string sSql = @"INSERT INTO tbl_paquete_servicio(fk_id_paquete, fk_id_servicio, numero_sesion) VALUES(?, ?, ?);";

            try
            {
                using (OdbcConnection cn = con.conexion())
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
                {
                    cmd.Parameters.Add("@fk_id_paquete", OdbcType.Int).Value = ps.iNombrePaquete;
                    cmd.Parameters.Add("@fk_id_servicio", OdbcType.Int).Value = ps.iNombreServicio;
                    cmd.Parameters.Add("@numero_sesion", OdbcType.Int).Value = ps.iNumSesion;

                    return cmd.ExecuteNonQuery(); // devuelve número de filas afectadas
                }
            }
            catch (OdbcException ex)
            {
                // Manejo de duplicados
                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show(
                        "No se puede guardar: el paquete ya tiene asignado ese número de sesión.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show($"Error al insertar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return 0; // indica que no se insertó nada
            }
        }

        public int pro_actualizar_paquete_servicio(Paquete_Servicio ps)
        {
            string sSql = @"UPDATE tbl_paquete_servicio
                    SET fk_id_paquete = ?, fk_id_servicio = ?, numero_sesion = ?
                    WHERE pk_id_paquete_servicio = ?;";

            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                // Orden de parámetros = orden de los '?'
                cmd.Parameters.Add("@fk_id_paquete", OdbcType.Int).Value = (int)ps.iNombrePaquete;
                cmd.Parameters.Add("@fk_id_servicio", OdbcType.Int).Value = (int)ps.iNombreServicio;
                cmd.Parameters.Add("@numero_sesion", OdbcType.Int).Value = (int)ps.iNumSesion;
                cmd.Parameters.Add("@id", OdbcType.Int).Value = ps.iId;

                return cmd.ExecuteNonQuery();
            }
        }

        public int pro_eliminar_paquete_servicio(int iId)
        {
            string sSql = "DELETE FROM tbl_paquete_servicio WHERE pk_id_paquete_servicio = ?;";
            using (OdbcConnection cn = con.conexion())
            using (OdbcCommand cmd = new OdbcCommand(sSql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", iId);
                return cmd.ExecuteNonQuery();
            }
        }

        public OdbcDataAdapter fun_buscar_paquete_servicio(string sTexto)
        {
            // En ODBC con DataAdapter es práctico usar LIKE directo (cuidado con comillas).
            string sSql = $@"SELECT pk_id_paquete_servicio, fk_id_paquete, fk_id_servicio, numero_sesion
                             FROM tbl_paquete_servicio
                             WHERE fk_id_paquete LIKE '%{sTexto.Replace("'", "''")}%'                        
                             ORDER BY fk_id_paquete;";
            return new OdbcDataAdapter(sSql, con.conexion());
        }
    }
}
