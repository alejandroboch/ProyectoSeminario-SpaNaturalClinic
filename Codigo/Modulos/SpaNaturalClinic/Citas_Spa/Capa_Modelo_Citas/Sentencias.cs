using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Capa_Modelo_Citas
{
    public class Sentencias
    {

        Conexion con = new Conexion();

        // Obtener datos de una tabla Capa Modelo
        //public OdbcDataAdapter llenarTbl(string tabla) //método que obtiene el contenido de una tabla
        //{
        //    //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
        //    string sql = "SELECT * FROM " + tabla + ";";
        //    OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
        //    return dataTable;
        //}

        public OdbcDataAdapter llenarDetalleCitas()
        {
            string sql = @"
    SELECT 
        cs.pk_id_cita_servicio AS id_asignacion,
        c.pk_id_cita AS id_cita,
        cli.nombre AS nombre_cliente,
        s.pk_id_servicio AS id_servicio,
        s.nombre AS nombre_servicio,
        p.pk_id_paquete AS id_paquete,
        p.nombre AS nombre_paquete,
        cs.numero_sesion,
        cs.costo_referencia,
        cs.monto_a_cobrar,
        (cs.costo_referencia - cs.monto_a_cobrar) AS descuento,
        cs.fecha_creacion
    FROM tbl_cita_servicio cs
    INNER JOIN tbl_citas c 
        ON cs.fk_id_cita = c.pk_id_cita
    INNER JOIN tbl_clientes cli 
        ON c.fk_id_cliente = cli.pk_id_cliente
    LEFT JOIN tbl_servicios s 
        ON cs.fk_id_servicio = s.pk_id_servicio
    LEFT JOIN tbl_paquetes p 
        ON cs.fk_id_paquete = p.pk_id_paquete
    ORDER BY cs.fecha_creacion DESC;
    ";

            return new OdbcDataAdapter(sql, con.conexion());
        }

        public OdbcDataAdapter funConsultarCitas()
        {
            try
            {
                string sql = "SELECT " +
                             "c.pk_id_cita AS ID, " +
                             "cli.nombre AS Cliente, " +
                             "c.fecha_cita AS Fecha, " +
                             "c.estado AS Estado, " +
                             "c.total AS Total, " +
                             "c.saldo_pendiente AS SaldoPendiente " +
                             "FROM tbl_citas c " +
                             "INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente " +
                             "ORDER BY c.fecha_cita DESC";

                return new OdbcDataAdapter(sql, con.conexion());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarCitas: " + ex.Message);
                return null;
            }
        }


        public OdbcDataAdapter funConsultarDetalle()
        {
            try
            {
                string sql = @"
            SELECT 
                cs.pk_id_cita_servicio AS ID,
                c.pk_id_cita AS ID_Cita,
                cli.nombre AS Cliente,
                s.nombre AS Servicio,
                p.nombre AS Paquete,
                cs.numero_sesion AS NumeroSesion,
                cs.costo_referencia AS CostoReferencia,
                cs.monto_a_cobrar AS MontoCobrar,
                cs.fecha_creacion AS FechaCreacion
            FROM tbl_cita_servicio cs
            INNER JOIN tbl_citas c ON cs.fk_id_cita = c.pk_id_cita
            INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
            LEFT JOIN tbl_servicios s ON cs.fk_id_servicio = s.pk_id_servicio
            LEFT JOIN tbl_paquetes p ON cs.fk_id_paquete = p.pk_id_paquete
            ORDER BY cs.fecha_creacion DESC";

                return new OdbcDataAdapter(sql, con.conexion());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarDetalle: " + ex.Message);
                return null;
            }
        }


        public DataRow ObtenerPrecioServicio(string idServicio)
        {
            string sql = $@"
        SELECT 
            nombre AS Servicio,
            precio AS Precio
        FROM tbl_servicios
        WHERE pk_id_servicio = {idServicio};";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener servicio y precio: " + ex.Message);
            }

            return null;
        }

        public DataRow ObtenerPrecioPaquete(string idPaquete)
        {
            string sql = $@"
        SELECT 
            nombre AS Paquete,
            precio_total AS PrecioTotal,
            numero_sesiones AS NumeroSesiones
        FROM tbl_paquetes
        WHERE pk_id_paquete = {idPaquete};";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener paquete y precio: " + ex.Message);
            }

            return null;
        }
        /*******************Ismar Leonel Cortez Sanchez  -0901-21-560*******************************************************/
        /****************************Combo box inteligente 2******************************************************************/
        //public Sentencias(string idUsuario)
        //{
        //    this.idUsuario = idUsuario;
        //}

        public string[] funLlenarCmb2(string sTabla, string sCampo1, string sCampo2)
        {
            Conexion cn = new Conexion();
            string[] sCampos = new string[300];
            int iI = 0;

            string sql = "SELECT DISTINCT " + sCampo1 + "," + sCampo2 + " FROM " + sTabla;

            /* La sentencia consulta el modelo de la base de datos con cada campo */
            try
            {
                // Muestra la consulta SQL antes de ejecutarla
                Console.Write(sql);
                MessageBox.Show(sql);

                OdbcCommand command = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sCampos[iI] = reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString();
                    iI++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nError en asignarCombo, revise los parámetros \n -" + sTabla + "\n -" + sCampo1);
            }

            return sCampos;
        }


        public DataTable obtener2(string sTabla, string sCampo1, string sCampo2)
        {
            Conexion cn = new Conexion();
            string sql = "SELECT DISTINCT " + sCampo1 + "," + sCampo2 + " FROM " + sTabla;

            OdbcCommand command = new OdbcCommand(sql, cn.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);


            return dt;
        }
        /****************************************************************************************************************/

        public void funcInsertarCita(int Cliente, DateTime fecha, string EstadoCita, float Total, float SaldoPendiente)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = "INSERT INTO tbl_citas (fk_id_cliente, fecha_cita, estado, total, saldo_pendiente) " +
                                 "VALUES (?, ?, ?, ?, ?)";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("fk_id_cliente", Cliente);
                        cmd.Parameters.AddWithValue("fecha_cita", fecha);
                        cmd.Parameters.AddWithValue("estado", EstadoCita);
                        cmd.Parameters.AddWithValue("total", Total);
                        cmd.Parameters.AddWithValue("saldo_pendiente", SaldoPendiente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcInsertarCita (Modelo): {ex.Message}");
                throw;
            }
        }



        //public void funcInsertarDetalle(int iServicio, int iPaquete, int iSesion)
        //{
        //    try
        //    {
        //        using (OdbcConnection conexion = con.conexion())
        //        {
        //            string sql = "INSERT INTO tbl_citas (fk_id_cliente, fecha_cita, estado, total, saldo_pendiente) " +
        //                         "VALUES (?, ?, ?, ?, ?)";

        //            using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
        //            {
        //                cmd.Parameters.AddWithValue("fk_id_cliente", Cliente);
        //                cmd.Parameters.AddWithValue("fecha_cita", fecha);
        //                cmd.Parameters.AddWithValue("estado", EstadoCita);
        //                cmd.Parameters.AddWithValue("total", Total);
        //                cmd.Parameters.AddWithValue("saldo_pendiente", SaldoPendiente);

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error en funcInsertarCita (Modelo): {ex.Message}");
        //        throw;
        //    }
        //}

        public void funcInsertarDetalle(int fk_id_cita, int? fk_id_servicio, int? fk_id_paquete, int? numero_sesion, decimal costoReferencia)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = @"
                INSERT INTO tbl_cita_servicio 
                (fk_id_cita, fk_id_servicio, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar) 
                VALUES (?, ?, ?, ?, ?, ?)";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
                    {
                        cmd.Parameters.Add("@fk_id_cita", OdbcType.Int).Value = fk_id_cita;
                        cmd.Parameters.Add("@fk_id_servicio", OdbcType.Int).Value = fk_id_servicio.HasValue ? fk_id_servicio.Value : (object)DBNull.Value;
                        cmd.Parameters.Add("@fk_id_paquete", OdbcType.Int).Value = fk_id_paquete.HasValue ? fk_id_paquete.Value : (object)DBNull.Value;
                        cmd.Parameters.Add("@numero_sesion", OdbcType.Int).Value = numero_sesion.HasValue ? numero_sesion.Value : (object)DBNull.Value;
                        cmd.Parameters.Add("@costo_referencia", OdbcType.Decimal).Value = costoReferencia;
                        cmd.Parameters.Add("@monto_a_cobrar", OdbcType.Decimal).Value = costoReferencia;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OdbcException ex)
            {
                // Información detallada de ODBC
                string detalles = $"ODBC Error Code: {ex.ErrorCode}\n" +
                                  $"Mensaje: {ex.Message}\n" +
                                  $"StackTrace: {ex.StackTrace}";
                Console.WriteLine(detalles);
                MessageBox.Show("Error ODBC al insertar detalle:\n" + detalles, "Error ODBC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Opcional, para que la capa controlador también capture
            }
            catch (Exception ex)
            {
                // Cualquier otra excepción
                string detalles = $"Mensaje: {ex.Message}\nStackTrace: {ex.StackTrace}";
                Console.WriteLine(detalles);
                MessageBox.Show("Error general al insertar detalle:\n" + detalles, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        public int ObtenerUltimoIdCita()
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = "SELECT MAX(pk_id_cita) AS UltimoId FROM tbl_citas";
                    using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener último ID de cita: {ex.Message}");
                throw;
            }
        }




    }
}
