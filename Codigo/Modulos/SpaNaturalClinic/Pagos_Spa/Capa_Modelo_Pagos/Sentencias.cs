using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Capa_Modelo_Pagos
{
    public class Sentencias
    {

        Conexion con = new Conexion();

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
            string sql = "";

            if (sTabla == "tbl_citas")
            {
                // Une tbl_citas con tbl_clientes para mostrar el nombre del cliente
                // SOLO CITAS ACTIVAS
                sql = @"
            SELECT 
                c.pk_id_cita,
                cli.nombre AS nombre_cliente
            FROM tbl_citas c
            INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
            WHERE c.estado_eliminado = 1
            ORDER BY c.pk_id_cita DESC;";
            }
            else
            {
                // Consulta general para otros casos
                sql = "SELECT DISTINCT " + sCampo1 + ", " + sCampo2 + " FROM " + sTabla;
            }

            OdbcCommand command = new OdbcCommand(sql, cn.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            return dt;
        }
        /****************************************************************************************************************/
        public OdbcDataAdapter funConsultarPagos()
        {
            try
            {
                string sql = @"
        SELECT 
            p.pk_id_pago AS ID_Pago,
            c.pk_id_cita AS NumeroCita,
            cli.nombre AS Cliente,
            p.monto AS Monto,
            p.metodo_pago AS MetodoPago,
            p.fecha_pago AS FechaPago,
            p.nota AS Nota,
            p.fecha_creacion AS FechaCreacion
        FROM tbl_pagos p
        INNER JOIN tbl_citas c ON p.fk_id_cita = c.pk_id_cita
        INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
        WHERE c.estado_eliminado = 1 AND p.estado_eliminado = 1
        ORDER BY p.fecha_creacion DESC;";

                return new OdbcDataAdapter(sql, con.conexion());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarPagos: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtiene los datos completos de una cita por su ID
        /// </summary>
        public DataRow ObtenerDatosCita(int idCita)
        {
            string sql = @"
        SELECT 
            c.pk_id_cita AS IdCita,
            c.fk_id_cliente AS IdCliente,
            cli.nombre AS NombreCliente,
            c.fecha_cita AS FechaCita,
            c.estado AS EstadoCita,
            c.total AS Total,
            c.saldo_pendiente AS SaldoPendiente
        FROM tbl_citas c
        INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
        WHERE c.pk_id_cita = ? AND c.estado_eliminado = 1";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                command.Parameters.AddWithValue("@id_cita", idCita);

                OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de la cita: " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Inserta un pago y actualiza el saldo pendiente de la cita de forma transaccional
        /// </summary>
        public void funcInsertarPago(int idCita, decimal montoPago, string metodoPago)
        {
            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                // Abrir conexión si está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

                // 1. Verificar que la cita existe y está activa
                decimal saldoPendienteActual = 0;
                using (OdbcCommand cmdVerificar = new OdbcCommand(
                    "SELECT saldo_pendiente FROM tbl_citas WHERE pk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdVerificar.Parameters.AddWithValue("@id_cita", idCita);
                    object result = cmdVerificar.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("La cita no existe o fue eliminada");
                    }

                    saldoPendienteActual = Convert.ToDecimal(result);
                }

                // 2. Validar que el monto no exceda el saldo pendiente
                if (montoPago > saldoPendienteActual)
                {
                    throw new Exception($"El monto del pago (Q{montoPago:F2}) excede el saldo pendiente (Q{saldoPendienteActual:F2})");
                }

                if (montoPago <= 0)
                {
                    throw new Exception("El monto del pago debe ser mayor a 0");
                }

                // 3. Insertar el pago
                using (OdbcCommand cmdInsertarPago = new OdbcCommand(
                    @"INSERT INTO tbl_pagos (fk_id_cita, monto, metodo_pago, fecha_pago, nota)
              VALUES (?, ?, ?, ?, NULL)",
                    conexion, transaction))
                {
                    cmdInsertarPago.Parameters.AddWithValue("@fk_id_cita", idCita);
                    cmdInsertarPago.Parameters.AddWithValue("@monto", montoPago);
                    cmdInsertarPago.Parameters.AddWithValue("@metodo_pago", metodoPago);
                    cmdInsertarPago.Parameters.AddWithValue("@fecha_pago", DateTime.Now.Date);

                    cmdInsertarPago.ExecuteNonQuery();
                }

                // 4. Actualizar el saldo pendiente de la cita
                decimal nuevoSaldo = saldoPendienteActual - montoPago;
                using (OdbcCommand cmdActualizarSaldo = new OdbcCommand(
                    "UPDATE tbl_citas SET saldo_pendiente = ? WHERE pk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdActualizarSaldo.Parameters.AddWithValue("@saldo_pendiente", nuevoSaldo);
                    cmdActualizarSaldo.Parameters.AddWithValue("@pk_id_cita", idCita);

                    cmdActualizarSaldo.ExecuteNonQuery();
                }

                // 5. Si el saldo queda en 0, actualizar el estado de la cita a "Completado"
                if (nuevoSaldo == 0)
                {
                    using (OdbcCommand cmdActualizarEstado = new OdbcCommand(
                        "UPDATE tbl_citas SET estado = 'Completado' WHERE pk_id_cita = ?",
                        conexion, transaction))
                    {
                        cmdActualizarEstado.Parameters.AddWithValue("@pk_id_cita", idCita);
                        cmdActualizarEstado.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                Console.WriteLine($"Pago de Q{montoPago:F2} registrado exitosamente. Nuevo saldo: Q{nuevoSaldo:F2}");
            }
            catch (Exception ex)
            {
                // Rollback en caso de error
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcInsertarPago: {ex.Message}");
                throw;
            }
            finally
            {
                // Cleanup
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }

                conexion = null;
            }
        }

        /// <summary>
        /// Consulta todos los pagos de una cita específica
        /// </summary>
        public OdbcDataAdapter funConsultarPagosPorCita(int idCita)
        {
            try
            {
                string sql = @"
            SELECT 
                p.pk_id_pago AS ID,
                p.fk_id_cita AS ID_Cita,
                p.monto AS Monto,
                p.metodo_pago AS MetodoPago,
                p.fecha_pago AS FechaPago,
                p.nota AS Nota,
                p.fecha_creacion AS FechaRegistro
            FROM tbl_pagos p
            WHERE p.fk_id_cita = ?
            ORDER BY p.fecha_pago DESC, p.fecha_creacion DESC";

                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                command.Parameters.AddWithValue("@id_cita", idCita);

                return new OdbcDataAdapter(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarPagosPorCita: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Consulta todos los pagos registrados
        /// </summary>
        public OdbcDataAdapter funConsultarTodosPagos()
        {
            try
            {
                string sql = @"
            SELECT 
                p.pk_id_pago AS ID,
                p.fk_id_cita AS ID_Cita,
                c.pk_id_cita AS NumCita,
                cli.nombre AS Cliente,
                p.monto AS Monto,
                p.metodo_pago AS MetodoPago,
                p.fecha_pago AS FechaPago,
                c.total AS TotalCita,
                c.saldo_pendiente AS SaldoPendiente
            FROM tbl_pagos p
            INNER JOIN tbl_citas c ON p.fk_id_cita = c.pk_id_cita
            INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
            WHERE c.estado_eliminado = 1
            ORDER BY p.fecha_pago DESC, p.fecha_creacion DESC";

                return new OdbcDataAdapter(sql, con.conexion());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarTodosPagos: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Actualiza un pago existente y ajusta el saldo pendiente de la cita
        /// </summary>
        public void funcActualizarPago(int idPago, int idCita, decimal nuevoMonto, string nuevoMetodoPago)
        {
            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                // Abrir conexión si está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

                // 1. Obtener el monto anterior del pago
                decimal montoAnterior = 0;
                using (OdbcCommand cmdObtenerMonto = new OdbcCommand(
                    "SELECT monto FROM tbl_pagos WHERE pk_id_pago = ?",
                    conexion, transaction))
                {
                    cmdObtenerMonto.Parameters.AddWithValue("@id_pago", idPago);
                    object result = cmdObtenerMonto.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("El pago no existe");
                    }

                    montoAnterior = Convert.ToDecimal(result);
                }

                // 2. Obtener el saldo pendiente actual de la cita
                decimal saldoPendienteActual = 0;
                decimal totalCita = 0;
                using (OdbcCommand cmdSaldo = new OdbcCommand(
                    "SELECT saldo_pendiente, total FROM tbl_citas WHERE pk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdSaldo.Parameters.AddWithValue("@id_cita", idCita);
                    using (OdbcDataReader reader = cmdSaldo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            saldoPendienteActual = Convert.ToDecimal(reader["saldo_pendiente"]);
                            totalCita = Convert.ToDecimal(reader["total"]);
                        }
                        else
                        {
                            throw new Exception("La cita no existe o fue eliminada");
                        }
                    }
                }

                // 3. Calcular el ajuste del saldo
                // Si el nuevo monto es MAYOR que el anterior: se paga MÁS, entonces el saldo DISMINUYE
                // Si el nuevo monto es MENOR que el anterior: se paga MENOS, entonces el saldo AUMENTA
                decimal diferenciaMonto = nuevoMonto - montoAnterior;
                decimal nuevoSaldoPendiente = saldoPendienteActual - diferenciaMonto;

                // 4. Validar que el nuevo saldo no sea negativo
                if (nuevoSaldoPendiente < 0)
                {
                    throw new Exception(
                        $"El nuevo monto genera un saldo negativo.\n\n" +
                        $"Saldo actual: Q{saldoPendienteActual:F2}\n" +
                        $"Diferencia: Q{diferenciaMonto:F2}\n" +
                        $"Saldo resultante: Q{nuevoSaldoPendiente:F2}\n\n" +
                        $"No puede exceder el total de la cita."
                    );
                }

                // 5. Validar que el nuevo monto sea mayor a 0
                if (nuevoMonto <= 0)
                {
                    throw new Exception("El monto del pago debe ser mayor a 0");
                }

                // 6. Calcular cuánto se ha pagado total (sin incluir este pago)
                decimal totalPagadoSinEste = totalCita - saldoPendienteActual - montoAnterior;

                // 7. Validar que el nuevo monto total no exceda el total de la cita
                if (totalPagadoSinEste + nuevoMonto > totalCita)
                {
                    decimal maximoPermitido = totalCita - totalPagadoSinEste;
                    throw new Exception(
                        $"El nuevo monto excede el total de la cita.\n\n" +
                        $"Total de la cita: Q{totalCita:F2}\n" +
                        $"Ya pagado (otros pagos): Q{totalPagadoSinEste:F2}\n" +
                        $"Máximo permitido para este pago: Q{maximoPermitido:F2}\n" +
                        $"Monto ingresado: Q{nuevoMonto:F2}"
                    );
                }

                // 8. Actualizar el pago
                using (OdbcCommand cmdActualizarPago = new OdbcCommand(
                    "UPDATE tbl_pagos SET monto = ?, metodo_pago = ? WHERE pk_id_pago = ?",
                    conexion, transaction))
                {
                    cmdActualizarPago.Parameters.AddWithValue("@monto", nuevoMonto);
                    cmdActualizarPago.Parameters.AddWithValue("@metodo_pago", nuevoMetodoPago);
                    cmdActualizarPago.Parameters.AddWithValue("@id_pago", idPago);

                    int filasAfectadas = cmdActualizarPago.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo actualizar el pago");
                    }
                }

                // 9. Actualizar el saldo pendiente de la cita
                using (OdbcCommand cmdActualizarSaldo = new OdbcCommand(
                    "UPDATE tbl_citas SET saldo_pendiente = ? WHERE pk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdActualizarSaldo.Parameters.AddWithValue("@saldo_pendiente", nuevoSaldoPendiente);
                    cmdActualizarSaldo.Parameters.AddWithValue("@pk_id_cita", idCita);

                    cmdActualizarSaldo.ExecuteNonQuery();
                }

                // 10. Actualizar el estado de la cita según el nuevo saldo
                string nuevoEstado = nuevoSaldoPendiente == 0 ? "Completado" : "Pendiente";
                using (OdbcCommand cmdActualizarEstado = new OdbcCommand(
                    "UPDATE tbl_citas SET estado = ? WHERE pk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdActualizarEstado.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmdActualizarEstado.Parameters.AddWithValue("@pk_id_cita", idCita);

                    cmdActualizarEstado.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine(
                    $"Pago actualizado exitosamente.\n" +
                    $"Monto anterior: Q{montoAnterior:F2}\n" +
                    $"Nuevo monto: Q{nuevoMonto:F2}\n" +
                    $"Diferencia: Q{diferenciaMonto:F2}\n" +
                    $"Nuevo saldo: Q{nuevoSaldoPendiente:F2}"
                );
            }
            catch (Exception ex)
            {
                // Rollback en caso de error
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcActualizarPago: {ex.Message}");
                throw;
            }
            finally
            {
                // Cleanup
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }

                conexion = null;
            }
        }

        /// <summary>
        /// Elimina lógicamente un pago y ajusta el saldo pendiente de la cita
        /// </summary>
        public bool funcEliminarPago(int idPago)
        {
            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                // Abrir conexión si está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

                // 1. Verificar que el pago existe y está activo
                decimal montoPago = 0;
                int idCita = 0;
                string metodoPago = "";
                DateTime fechaPago = DateTime.Now;

                using (OdbcCommand cmdVerificar = new OdbcCommand(
                    @"SELECT p.monto, p.fk_id_cita, p.metodo_pago, p.fecha_pago
              FROM tbl_pagos p
              WHERE p.pk_id_pago = ? AND p.estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdVerificar.Parameters.AddWithValue("@id_pago", idPago);

                    using (OdbcDataReader reader = cmdVerificar.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            montoPago = Convert.ToDecimal(reader["monto"]);
                            idCita = Convert.ToInt32(reader["fk_id_cita"]);
                            metodoPago = reader["metodo_pago"].ToString();
                            fechaPago = Convert.ToDateTime(reader["fecha_pago"]);
                        }
                        else
                        {
                            throw new Exception("El pago no existe o ya fue eliminado");
                        }
                    }
                }

                // 2. Obtener el saldo pendiente actual de la cita
                decimal saldoPendienteActual = 0;
                decimal totalCita = 0;
                string estadoCita = "";

                using (OdbcCommand cmdCita = new OdbcCommand(
                    "SELECT saldo_pendiente, total, estado FROM tbl_citas WHERE pk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdCita.Parameters.AddWithValue("@id_cita", idCita);

                    using (OdbcDataReader reader = cmdCita.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            saldoPendienteActual = Convert.ToDecimal(reader["saldo_pendiente"]);
                            totalCita = Convert.ToDecimal(reader["total"]);
                            estadoCita = reader["estado"].ToString();
                        }
                        else
                        {
                            throw new Exception("La cita asociada no existe o fue eliminada");
                        }
                    }
                }

                // 3. Calcular el nuevo saldo (aumenta porque se está eliminando un pago)
                decimal nuevoSaldoPendiente = saldoPendienteActual + montoPago;

                // 4. Validar que el nuevo saldo no exceda el total de la cita
                if (nuevoSaldoPendiente > totalCita)
                {
                    throw new Exception(
                        $"Error: El nuevo saldo ({nuevoSaldoPendiente:F2}) excedería el total de la cita ({totalCita:F2}).\n" +
                        "Esto puede indicar un problema de integridad en los datos."
                    );
                }

                // 5. Marcar el pago como eliminado (eliminación lógica)
                using (OdbcCommand cmdEliminarPago = new OdbcCommand(
                    "UPDATE tbl_pagos SET estado_eliminado = 0 WHERE pk_id_pago = ?",
                    conexion, transaction))
                {
                    cmdEliminarPago.Parameters.AddWithValue("@id_pago", idPago);

                    int filasAfectadas = cmdEliminarPago.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo eliminar el pago");
                    }
                }

                // 6. Actualizar el saldo pendiente de la cita
                using (OdbcCommand cmdActualizarSaldo = new OdbcCommand(
                    "UPDATE tbl_citas SET saldo_pendiente = ? WHERE pk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdActualizarSaldo.Parameters.AddWithValue("@saldo_pendiente", nuevoSaldoPendiente);
                    cmdActualizarSaldo.Parameters.AddWithValue("@pk_id_cita", idCita);

                    cmdActualizarSaldo.ExecuteNonQuery();
                }

                // 7. Actualizar el estado de la cita
                // Si estaba "Completado" y ahora tiene saldo pendiente, cambiar a "Pendiente"
                if (estadoCita == "Completado" && nuevoSaldoPendiente > 0)
                {
                    using (OdbcCommand cmdActualizarEstado = new OdbcCommand(
                        "UPDATE tbl_citas SET estado = 'Pendiente' WHERE pk_id_cita = ?",
                        conexion, transaction))
                    {
                        cmdActualizarEstado.Parameters.AddWithValue("@pk_id_cita", idCita);
                        cmdActualizarEstado.ExecuteNonQuery();
                    }
                }

                transaction.Commit();

                Console.WriteLine(
                    $"Pago eliminado exitosamente.\n" +
                    $"ID Pago: {idPago}\n" +
                    $"Monto: Q{montoPago:F2}\n" +
                    $"Método: {metodoPago}\n" +
                    $"Saldo anterior: Q{saldoPendienteActual:F2}\n" +
                    $"Nuevo saldo: Q{nuevoSaldoPendiente:F2}"
                );

                return true;
            }
            catch (Exception ex)
            {
                // Rollback en caso de error
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcEliminarPago: {ex.Message}");
                throw;
            }
            finally
            {
                // Cleanup
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }

                conexion = null;
            }
        }



    }
}
