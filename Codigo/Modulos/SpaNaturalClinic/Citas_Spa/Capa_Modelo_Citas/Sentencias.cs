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

        //public void funcInsertarDetalle(int fk_id_cita, int? fk_id_servicio, int? fk_id_paquete, int? numero_sesion, decimal costoReferencia)
        //{
        //    try
        //    {
        //        using (OdbcConnection conexion = con.conexion())
        //        {
        //            string sql = @"
        //        INSERT INTO tbl_cita_servicio 
        //        (fk_id_cita, fk_id_servicio, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar) 
        //        VALUES (?, ?, ?, ?, ?, ?)";

        //            using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
        //            {
        //                cmd.Parameters.Add("@fk_id_cita", OdbcType.Int).Value = fk_id_cita;
        //                cmd.Parameters.Add("@fk_id_servicio", OdbcType.Int).Value = fk_id_servicio.HasValue ? fk_id_servicio.Value : (object)DBNull.Value;
        //                cmd.Parameters.Add("@fk_id_paquete", OdbcType.Int).Value = fk_id_paquete.HasValue ? fk_id_paquete.Value : (object)DBNull.Value;
        //                cmd.Parameters.Add("@numero_sesion", OdbcType.Int).Value = numero_sesion.HasValue ? numero_sesion.Value : (object)DBNull.Value;
        //                cmd.Parameters.Add("@costo_referencia", OdbcType.Decimal).Value = costoReferencia;
        //                cmd.Parameters.Add("@monto_a_cobrar", OdbcType.Decimal).Value = costoReferencia;

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (OdbcException ex)
        //    {
        //        // Información detallada de ODBC
        //        string detalles = $"ODBC Error Code: {ex.ErrorCode}\n" +
        //                          $"Mensaje: {ex.Message}\n" +
        //                          $"StackTrace: {ex.StackTrace}";
        //        Console.WriteLine(detalles);
        //        MessageBox.Show("Error ODBC al insertar detalle:\n" + detalles, "Error ODBC", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        throw; // Opcional, para que la capa controlador también capture
        //    }
        //    catch (Exception ex)
        //    {
        //        // Cualquier otra excepción
        //        string detalles = $"Mensaje: {ex.Message}\nStackTrace: {ex.StackTrace}";
        //        Console.WriteLine(detalles);
        //        MessageBox.Show("Error general al insertar detalle:\n" + detalles, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        throw;
        //    }
        //}


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

        /***********************Codigo Agregado Ismar Cortez - 23/9/25
       /********************************************************************************************************************/
        //public void funcInsertarDetalle(int fk_id_cita, int fk_id_servicio, int fk_id_paquete, int numero_sesion)
        //{
        //    OdbcTransaction transaction = null;

        //    try
        //    {
        //        using (OdbcConnection conexion = con.conexion())
        //        {
        //            transaction = conexion.BeginTransaction();

        //            // OBTENER ID_CLIENTE DE LA CITA
        //            int fk_id_cliente = 0;
        //            string sqlCliente = "SELECT fk_id_cliente FROM tbl_citas WHERE pk_id_cita = ?";
        //            using (OdbcCommand cmdCliente = new OdbcCommand(sqlCliente, conexion, transaction))
        //            {
        //                cmdCliente.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;
        //                object result = cmdCliente.ExecuteScalar();
        //                if (result != DBNull.Value)
        //                {
        //                    fk_id_cliente = Convert.ToInt32(result);
        //                }
        //                else
        //                {
        //                    throw new Exception($"No se encontró la cita con ID {fk_id_cita}");
        //                }
        //            }

        //            decimal montoACobrar = 0;
        //            decimal costoReferencia = 0;
        //            int clientePaqueteId = 0;

        //            if (fk_id_paquete > 0 && numero_sesion > 0)
        //            {
        //                // ===============================
        //                // MANEJO DE PAQUETES
        //                // ===============================

        //                // 1. Obtener información del paquete
        //                string sqlPaquete = "SELECT precio_total, numero_sesiones FROM tbl_paquetes WHERE pk_id_paquete = ?";
        //                int sesionesTotales = 0;

        //                using (OdbcCommand cmdPaquete = new OdbcCommand(sqlPaquete, conexion, transaction))
        //                {
        //                    cmdPaquete.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;
        //                    using (OdbcDataReader reader = cmdPaquete.ExecuteReader())
        //                    {
        //                        if (reader.Read())
        //                        {
        //                            costoReferencia = Convert.ToDecimal(reader[0]); // primer campo (precio_total)
        //                            sesionesTotales = Convert.ToInt32(reader[1]);   // segundo campo (numero_sesiones)
        //                        }
        //                        else
        //                        {
        //                            throw new Exception($"Paquete con ID {fk_id_paquete} no encontrado");
        //                        }
        //                    }
        //                }

        //                // 2. Verificar si el cliente ya tiene este paquete activo
        //                string sqlVerificarPaquete = @"
        //            SELECT COUNT(*) as cuenta, COALESCE(MAX(pk_id_cliente_paquete), 0) as id_paquete
        //            FROM tbl_cliente_paquete cp
        //            INNER JOIN tbl_paquetes p ON cp.fk_id_paquete = p.pk_id_paquete
        //            WHERE cp.fk_id_cliente = ? 
        //              AND cp.fk_id_paquete = ?
        //              AND cp.estado = 'En uso'
        //              AND cp.sesiones_usadas < p.numero_sesiones";

        //                bool tienePaqueteActivo = false;

        //                using (OdbcCommand cmdVerificar = new OdbcCommand(sqlVerificarPaquete, conexion, transaction))
        //                {
        //                    cmdVerificar.Parameters.Add("@id_cliente", OdbcType.Int).Value = fk_id_cliente;
        //                    cmdVerificar.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;

        //                    using (OdbcDataReader reader = cmdVerificar.ExecuteReader())
        //                    {
        //                        if (reader.Read())
        //                        {
        //                            int cuenta = Convert.ToInt32(reader[0]); // primera columna (cuenta)
        //                            if (cuenta > 0)
        //                            {
        //                                tienePaqueteActivo = true;
        //                                clientePaqueteId = Convert.ToInt32(reader[1]); // segunda columna (id_paquete)
        //                            }
        //                        }
        //                    }
        //                }

        //                if (tienePaqueteActivo && clientePaqueteId > 0)
        //                {
        //                    // Ya tiene paquete activo - NO COBRAR
        //                    montoACobrar = 0;
        //                }
        //                else
        //                {
        //                    // No tiene paquete activo - COBRAR COMPLETO y crear nuevo control
        //                    montoACobrar = costoReferencia;

        //                    // Crear nuevo control de paquete
        //                    string sqlNuevoPaquete = @"
        //                INSERT INTO tbl_cliente_paquete 
        //                (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra)
        //                VALUES (?, ?, ?, 0, 0, ?)";

        //                    using (OdbcCommand cmdNuevo = new OdbcCommand(sqlNuevoPaquete, conexion, transaction))
        //                    {
        //                        cmdNuevo.Parameters.Add("@id_cliente", OdbcType.Int).Value = fk_id_cliente;
        //                        cmdNuevo.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;
        //                        cmdNuevo.Parameters.Add("@fecha", OdbcType.Date).Value = DateTime.Now.Date;
        //                        cmdNuevo.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;

        //                        cmdNuevo.ExecuteNonQuery();
        //                    }

        //                    // Obtener el ID del paquete recién creado
        //                    string sqlUltimoId = "SELECT MAX(pk_id_cliente_paquete) FROM tbl_cliente_paquete WHERE fk_id_cliente = ? AND fk_id_paquete = ?";
        //                    using (OdbcCommand cmdUltimo = new OdbcCommand(sqlUltimoId, conexion, transaction))
        //                    {
        //                        cmdUltimo.Parameters.Add("@id_cliente", OdbcType.Int).Value = fk_id_cliente;
        //                        cmdUltimo.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;

        //                        object result = cmdUltimo.ExecuteScalar();
        //                        if (result != DBNull.Value)
        //                        {
        //                            clientePaqueteId = Convert.ToInt32(result);
        //                        }
        //                    }
        //                }

        //                // 3. Insertar en tbl_cita_servicio (PAQUETE)
        //                string sqlInsertarPaquete = @"
        //            INSERT INTO tbl_cita_servicio 
        //            (fk_id_cita, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar, fk_id_cliente_paquete)
        //            VALUES (?, ?, ?, ?, ?, ?)";

        //                using (OdbcCommand cmdInsertar = new OdbcCommand(sqlInsertarPaquete, conexion, transaction))
        //                {
        //                    cmdInsertar.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;
        //                    cmdInsertar.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;
        //                    cmdInsertar.Parameters.Add("@numero_sesion", OdbcType.Int).Value = numero_sesion;
        //                    cmdInsertar.Parameters.Add("@costo_ref", OdbcType.Decimal).Value = costoReferencia;
        //                    cmdInsertar.Parameters.Add("@monto_cobrar", OdbcType.Decimal).Value = montoACobrar;
        //                    cmdInsertar.Parameters.Add("@cliente_paquete_id", OdbcType.Int).Value = clientePaqueteId > 0 ? clientePaqueteId : (object)DBNull.Value;

        //                    cmdInsertar.ExecuteNonQuery();
        //                }

        //                // 4. Actualizar sesiones usadas
        //                if (clientePaqueteId > 0)
        //                {
        //                    string sqlActualizarSesiones = "UPDATE tbl_cliente_paquete SET sesiones_usadas = sesiones_usadas + 1 WHERE pk_id_cliente_paquete = ?";
        //                    using (OdbcCommand cmdActualizar = new OdbcCommand(sqlActualizarSesiones, conexion, transaction))
        //                    {
        //                        cmdActualizar.Parameters.Add("@id", OdbcType.Int).Value = clientePaqueteId;
        //                        cmdActualizar.ExecuteNonQuery();
        //                    }

        //                    // 5. Verificar si completó todas las sesiones y marcar como finalizado
        //                    string sqlFinalizarPaquete = @"
        //                UPDATE tbl_cliente_paquete 
        //                SET estado = 'Finalizado'
        //                WHERE pk_id_cliente_paquete = ? AND sesiones_usadas >= ?";

        //                    using (OdbcCommand cmdFinalizar = new OdbcCommand(sqlFinalizarPaquete, conexion, transaction))
        //                    {
        //                        cmdFinalizar.Parameters.Add("@id", OdbcType.Int).Value = clientePaqueteId;
        //                        cmdFinalizar.Parameters.Add("@sesiones", OdbcType.Int).Value = sesionesTotales;
        //                        cmdFinalizar.ExecuteNonQuery();
        //                    }
        //                }
        //            }
        //            else if (fk_id_servicio > 0)
        //            {
        //                // ===============================
        //                // MANEJO DE SERVICIOS INDIVIDUALES
        //                // ===============================

        //                // 1. Obtener precio del servicio
        //                string sqlServicio = "SELECT precio FROM tbl_servicios WHERE pk_id_servicio = ?";

        //                using (OdbcCommand cmdServicio = new OdbcCommand(sqlServicio, conexion, transaction))
        //                {
        //                    cmdServicio.Parameters.Add("@id_servicio", OdbcType.Int).Value = fk_id_servicio;

        //                    object result = cmdServicio.ExecuteScalar();
        //                    if (result != DBNull.Value)
        //                    {
        //                        costoReferencia = Convert.ToDecimal(result);
        //                        montoACobrar = costoReferencia; // Para servicios individuales siempre se cobra
        //                    }
        //                    else
        //                    {
        //                        throw new Exception($"Servicio con ID {fk_id_servicio} no encontrado");
        //                    }
        //                }

        //                // 2. Insertar en tbl_cita_servicio (SERVICIO)
        //                string sqlInsertarServicio = @"
        //            INSERT INTO tbl_cita_servicio 
        //            (fk_id_cita, fk_id_servicio, costo_referencia, monto_a_cobrar)
        //            VALUES (?, ?, ?, ?)";

        //                using (OdbcCommand cmdInsertar = new OdbcCommand(sqlInsertarServicio, conexion, transaction))
        //                {
        //                    cmdInsertar.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;
        //                    cmdInsertar.Parameters.Add("@id_servicio", OdbcType.Int).Value = fk_id_servicio;
        //                    cmdInsertar.Parameters.Add("@costo_ref", OdbcType.Decimal).Value = costoReferencia;
        //                    cmdInsertar.Parameters.Add("@monto_cobrar", OdbcType.Decimal).Value = montoACobrar;

        //                    cmdInsertar.ExecuteNonQuery();
        //                }
        //            }
        //            else
        //            {
        //                throw new Exception("Debe especificar un servicio individual (fk_id_servicio > 0) O un paquete con número de sesión (fk_id_paquete > 0 y numero_sesion > 0)");
        //            }

        //            // 6. Actualizar totales de la cita (simulando el trigger)
        //            funcActualizarTotalesCita(fk_id_cita, conexion, transaction);

        //            transaction.Commit();
        //            Console.WriteLine("Detalle insertado correctamente con lógica de negocio en C#");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (transaction != null)
        //        {
        //            try { transaction.Rollback(); } catch { }
        //        }

        //        string detalles = $"Error en funcInsertarDetalle: {ex.Message}\nStackTrace: {ex.StackTrace}";
        //        Console.WriteLine(detalles);
        //        MessageBox.Show("Error al insertar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        throw;
        //    }
        //}

        public void funcInsertarDetalle(int fk_id_cita, int fk_id_servicio, int fk_id_paquete, int numero_sesion)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    conexion.Open();
                    using (OdbcTransaction transaction = conexion.BeginTransaction())
                    {
                        // 1. Obtener cliente de la cita
                        int fk_id_cliente = 0;
                        using (OdbcCommand cmdCliente = new OdbcCommand(
                            "SELECT fk_id_cliente FROM tbl_citas WHERE pk_id_cita = ?", conexion, transaction))
                        {
                            cmdCliente.Parameters.AddWithValue("@id_cita", fk_id_cita);
                            object result = cmdCliente.ExecuteScalar();
                            if (result == DBNull.Value)
                                throw new Exception($"No se encontró la cita con ID {fk_id_cita}");
                            fk_id_cliente = Convert.ToInt32(result);
                        }

                        decimal costoReferencia = 0;
                        decimal montoACobrar = 0;
                        int clientePaqueteId = 0;

                        // ===============================
                        // Manejo de paquetes
                        // ===============================
                        if (fk_id_paquete > 0 && numero_sesion > 0)
                        {
                            int sesionesTotales = 0;

                            // 1. Obtener info del paquete
                            using (OdbcCommand cmdPaquete = new OdbcCommand(
                                "SELECT precio_total, numero_sesiones FROM tbl_paquetes WHERE pk_id_paquete = ?", conexion, transaction))
                            {
                                cmdPaquete.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                using (OdbcDataReader reader = cmdPaquete.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        costoReferencia = Convert.ToDecimal(reader[0]);
                                        sesionesTotales = Convert.ToInt32(reader[1]);
                                    }
                                    else
                                        throw new Exception($"Paquete con ID {fk_id_paquete} no encontrado");
                                }
                            }

                            // 2. Buscar paquete activo del cliente
                            using (OdbcCommand cmdVerificar = new OdbcCommand(
                                @"SELECT pk_id_cliente_paquete, sesiones_usadas
                          FROM tbl_cliente_paquete
                          WHERE fk_id_cliente = ? AND fk_id_paquete = ? AND estado = 'En uso'
                          ORDER BY fecha_compra ASC
                          LIMIT 1", conexion, transaction))
                            {
                                cmdVerificar.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                cmdVerificar.Parameters.AddWithValue("@id_paquete", fk_id_paquete);

                                using (OdbcDataReader reader = cmdVerificar.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        clientePaqueteId = Convert.ToInt32(reader[0]);
                                        int sesionesUsadas = Convert.ToInt32(reader[1]);
                                        montoACobrar = 0; // Continuidad: no cobrar nuevamente
                                    }
                                    else
                                    {
                                        // No hay paquete activo, crear uno nuevo
                                        montoACobrar = costoReferencia;
                                        using (OdbcCommand cmdNuevo = new OdbcCommand(
                                            @"INSERT INTO tbl_cliente_paquete 
                                      (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra)
                                      VALUES (?, ?, ?, 0, 0, ?)", conexion, transaction))
                                        {
                                            cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                            cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                            cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                            cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                            cmdNuevo.ExecuteNonQuery();
                                        }

                                        // Obtener ID del nuevo paquete
                                        using (OdbcCommand cmdUltimo = new OdbcCommand(
                                            "SELECT LAST_INSERT_ID()", conexion, transaction))
                                        {
                                            clientePaqueteId = Convert.ToInt32(cmdUltimo.ExecuteScalar());
                                        }
                                    }
                                }
                            }

                            // 3. Insertar detalle de cita (paquete)
                            using (OdbcCommand cmdInsertar = new OdbcCommand(
                                @"INSERT INTO tbl_cita_servicio 
                          (fk_id_cita, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar, fk_id_cliente_paquete)
                          VALUES (?, ?, ?, ?, ?, ?)", conexion, transaction))
                            {
                                cmdInsertar.Parameters.AddWithValue("@fk_id_cita", fk_id_cita);
                                cmdInsertar.Parameters.AddWithValue("@fk_id_paquete", fk_id_paquete);
                                cmdInsertar.Parameters.AddWithValue("@numero_sesion", numero_sesion);
                                cmdInsertar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                                cmdInsertar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                                cmdInsertar.Parameters.AddWithValue("@fk_id_cliente_paquete", clientePaqueteId);
                                cmdInsertar.ExecuteNonQuery();
                            }

                            // 4. Actualizar sesiones usadas y finalizar si aplica
                            using (OdbcCommand cmdActualizar = new OdbcCommand(
                                @"UPDATE tbl_cliente_paquete
                          SET sesiones_usadas = sesiones_usadas + 1,
                              estado = CASE WHEN sesiones_usadas + 1 >= ? THEN 'Finalizado' ELSE 'En uso' END
                          WHERE pk_id_cliente_paquete = ?", conexion, transaction))
                            {
                                cmdActualizar.Parameters.AddWithValue("@sesiones_totales", sesionesTotales);
                                cmdActualizar.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
                                cmdActualizar.ExecuteNonQuery();
                            }
                        }
                        // ===============================
                        // Manejo de servicios individuales
                        // ===============================
                        else if (fk_id_servicio > 0)
                        {
                            using (OdbcCommand cmdServicio = new OdbcCommand(
                                "SELECT precio FROM tbl_servicios WHERE pk_id_servicio = ?", conexion, transaction))
                            {
                                cmdServicio.Parameters.AddWithValue("@id_servicio", fk_id_servicio);
                                object result = cmdServicio.ExecuteScalar();
                                if (result == DBNull.Value)
                                    throw new Exception($"Servicio con ID {fk_id_servicio} no encontrado");

                                costoReferencia = Convert.ToDecimal(result);
                                montoACobrar = costoReferencia;
                            }

                            using (OdbcCommand cmdInsertar = new OdbcCommand(
                                @"INSERT INTO tbl_cita_servicio 
                          (fk_id_cita, fk_id_servicio, costo_referencia, monto_a_cobrar)
                          VALUES (?, ?, ?, ?)", conexion, transaction))
                            {
                                cmdInsertar.Parameters.AddWithValue("@fk_id_cita", fk_id_cita);
                                cmdInsertar.Parameters.AddWithValue("@fk_id_servicio", fk_id_servicio);
                                cmdInsertar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                                cmdInsertar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                                cmdInsertar.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            throw new Exception("Debe especificar un servicio o un paquete con número de sesión.");
                        }

                        // 5. Actualizar totales de la cita
                        funcActualizarTotalesCita(fk_id_cita, conexion, transaction);

                        transaction.Commit();
                        Console.WriteLine("Detalle insertado correctamente con continuidad de paquetes.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcInsertarDetalle: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show("Error al insertar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        /// <summary>
        /// Método interno para actualizar totales de cita (simula el trigger)
        /// </summary>
        private void funcActualizarTotalesCita(int fk_id_cita, OdbcConnection conexion, OdbcTransaction transaction)
        {
            try
            {
                // Calcular nuevo total
                string sqlTotal = "SELECT COALESCE(SUM(monto_a_cobrar), 0) AS total FROM tbl_cita_servicio WHERE fk_id_cita = ?";
                decimal nuevoTotal = 0;

                using (OdbcCommand cmdTotal = new OdbcCommand(sqlTotal, conexion, transaction))
                {
                    cmdTotal.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;
                    object result = cmdTotal.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        nuevoTotal = Convert.ToDecimal(result);
                    }
                }

                // Calcular saldo pendiente (total - pagos)
                string sqlPagos = "SELECT COALESCE(SUM(monto), 0) AS pagado FROM tbl_pagos WHERE fk_id_cita = ?";
                decimal totalPagado = 0;

                using (OdbcCommand cmdPagos = new OdbcCommand(sqlPagos, conexion, transaction))
                {
                    cmdPagos.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;
                    object result = cmdPagos.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalPagado = Convert.ToDecimal(result);
                    }
                }

                decimal saldoPendiente = nuevoTotal - totalPagado;

                // Actualizar la cita
                string sqlActualizar = "UPDATE tbl_citas SET total = ?, saldo_pendiente = ? WHERE pk_id_cita = ?";
                using (OdbcCommand cmdActualizar = new OdbcCommand(sqlActualizar, conexion, transaction))
                {
                    cmdActualizar.Parameters.Add("@total", OdbcType.Decimal).Value = nuevoTotal;
                    cmdActualizar.Parameters.Add("@saldo", OdbcType.Decimal).Value = saldoPendiente;
                    cmdActualizar.Parameters.Add("@id_cita", OdbcType.Int).Value = fk_id_cita;

                    cmdActualizar.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar totales de cita: {ex.Message}");
            }
        }

        /// <summary>
        /// Verificar si un cliente tiene un paquete activo (lógica en C#)
        /// </summary>
        public bool funcVerificarPaqueteActivo(int fk_id_cliente, int fk_id_paquete)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = @"
                SELECT COUNT(*) as cuenta
                FROM tbl_cliente_paquete cp
                INNER JOIN tbl_paquetes p ON cp.fk_id_paquete = p.pk_id_paquete
                WHERE cp.fk_id_cliente = ? 
                  AND cp.fk_id_paquete = ?
                  AND cp.estado = 'En uso'
                  AND cp.sesiones_usadas < p.numero_sesiones";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
                    {
                        cmd.Parameters.Add("@id_cliente", OdbcType.Int).Value = fk_id_cliente;
                        cmd.Parameters.Add("@id_paquete", OdbcType.Int).Value = fk_id_paquete;

                        object result = cmd.ExecuteScalar();
                        int cuenta = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                        return cuenta > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar paquete activo: {ex.Message}");
                return false;
            }
        }

        /********************************************************************************************************************/



    }
}
