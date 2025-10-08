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

        //    public OdbcDataAdapter llenarDetalleCitas()
        //    {
        //        string sql = @"
        //SELECT 
        //    cs.pk_id_cita_servicio AS id_asignacion,
        //    c.pk_id_cita AS id_cita,
        //    cli.nombre AS nombre_cliente,
        //    s.pk_id_servicio AS id_servicio,
        //    s.nombre AS nombre_servicio,
        //    p.pk_id_paquete AS id_paquete,
        //    p.nombre AS nombre_paquete,
        //    cs.numero_sesion,
        //    cs.costo_referencia,
        //    cs.monto_a_cobrar,
        //    (cs.costo_referencia - cs.monto_a_cobrar) AS descuento,
        //    cs.fecha_creacion
        //FROM tbl_cita_servicio cs
        //INNER JOIN tbl_citas c 
        //    ON cs.fk_id_cita = c.pk_id_cita
        //INNER JOIN tbl_clientes cli 
        //    ON c.fk_id_cliente = cli.pk_id_cliente
        //LEFT JOIN tbl_servicios s 
        //    ON cs.fk_id_servicio = s.pk_id_servicio
        //LEFT JOIN tbl_paquetes p 
        //    ON cs.fk_id_paquete = p.pk_id_paquete
        //ORDER BY cs.fecha_creacion DESC;
        //";

        //        return new OdbcDataAdapter(sql, con.conexion());
        //    }

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
WHERE c.estado_eliminado = 1 AND cs.estado_eliminado = 1
ORDER BY cs.fecha_creacion DESC;
";

            return new OdbcDataAdapter(sql, con.conexion());
        }

        //public OdbcDataAdapter funConsultarCitas()
        //{
        //    try
        //    {
        //        string sql = "SELECT " +
        //                     "c.pk_id_cita AS ID, " +
        //                     "cli.nombre AS Cliente, " +
        //                     "c.fecha_cita AS Fecha, " +
        //                     "c.estado AS Estado, " +
        //                     "c.total AS Total, " +
        //                     "c.saldo_pendiente AS SaldoPendiente " +
        //                     "FROM tbl_citas c " +
        //                     "INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente " +
        //                     "ORDER BY c.fecha_cita DESC";

        //        return new OdbcDataAdapter(sql, con.conexion());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error en funConsultarCitas: " + ex.Message);
        //        return null;
        //    }
        //}

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
                             "WHERE c.estado_eliminado = 1 " +
                             "ORDER BY c.fecha_cita DESC";

                return new OdbcDataAdapter(sql, con.conexion());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarCitas: " + ex.Message);
                return null;
            }
        }


        //public OdbcDataAdapter funConsultarDetalle()
        //{
        //    try
        //    {
        //        string sql = @"
        //    SELECT 
        //        cs.pk_id_cita_servicio AS ID,
        //        c.pk_id_cita AS ID_Cita,
        //        cli.nombre AS Cliente,
        //        s.nombre AS Servicio,
        //        p.nombre AS Paquete,
        //        cs.numero_sesion AS NumeroSesion,
        //        cs.costo_referencia AS CostoReferencia,
        //        cs.monto_a_cobrar AS MontoCobrar,
        //        cs.fecha_creacion AS FechaCreacion
        //    FROM tbl_cita_servicio cs
        //    INNER JOIN tbl_citas c ON cs.fk_id_cita = c.pk_id_cita
        //    INNER JOIN tbl_clientes cli ON c.fk_id_cliente = cli.pk_id_cliente
        //    LEFT JOIN tbl_servicios s ON cs.fk_id_servicio = s.pk_id_servicio
        //    LEFT JOIN tbl_paquetes p ON cs.fk_id_paquete = p.pk_id_paquete
        //    ORDER BY cs.fecha_creacion DESC";

        //        return new OdbcDataAdapter(sql, con.conexion());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error en funConsultarDetalle: " + ex.Message);
        //        return null;
        //    }
        //}

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
        WHERE c.estado_eliminado = 1 AND cs.estado_eliminado = 1
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

        //public void funcInsertarCita(int Cliente, DateTime fecha, string EstadoCita, float Total, float SaldoPendiente)
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

        public void funcInsertarCita(int Cliente, DateTime fecha, string EstadoCita, float Total, float SaldoPendiente)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = "INSERT INTO tbl_citas (fk_id_cliente, fecha_cita, estado, total, saldo_pendiente, estado_eliminado) " +
                                 "VALUES (?, ?, ?, ?, ?, 1)";

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


        public void funcInsertarDetalle(int fk_id_cita, int fk_id_servicio, int fk_id_paquete, int numero_sesion)
        {
            // Validaciones al inicio
            if (fk_id_cita <= 0)
                throw new ArgumentException("ID de cita debe ser mayor a 0");

            if (fk_id_servicio <= 0 && fk_id_paquete <= 0)
                throw new ArgumentException("Debe especificar un servicio o un paquete");

            if (fk_id_paquete > 0 && numero_sesion <= 0)
                throw new ArgumentException("Número de sesión debe ser mayor a 0 para paquetes");

            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                // NO ABRIR SI YA ESTÁ ABIERTA
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

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

                    // 2. Buscar paquete activo del cliente (SOLO 'En uso')
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

                                // Verificar si el paquete puede continuar
                                if (sesionesUsadas < sesionesTotales)
                                {
                                    montoACobrar = 0; // Continuidad: no cobrar nuevamente
                                }
                                else
                                {
                                    //  // El paquete está completamente usado, crear uno nuevo
                                    //  montoACobrar = costoReferencia;
                                    //  using (OdbcCommand cmdNuevo = new OdbcCommand(
                                    //      @"INSERT INTO tbl_cliente_paquete 
                                    //(fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra)
                                    //VALUES (?, ?, ?, 0, 0, ?)", conexion, transaction))
                                    //  {
                                    //      cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                    //      cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                    //      cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                    //      cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                    //      cmdNuevo.ExecuteNonQuery();
                                    //  }

                                    // El paquete está completamente usado, crear uno nuevo
                                    montoACobrar = costoReferencia;
                                    using (OdbcCommand cmdNuevo = new OdbcCommand(
                                        @"INSERT INTO tbl_cliente_paquete 
      (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra, estado_eliminado)
      VALUES (?, ?, ?, 0, 0, ?, 1)", conexion, transaction))
                                    {
                                        cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                        cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                        cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                        cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                        cmdNuevo.Parameters.AddWithValue("@estado_eliminado", 1);
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
                            else
                            {
                                //  // No hay paquete activo, crear uno nuevo
                                //  montoACobrar = costoReferencia;
                                //  using (OdbcCommand cmdNuevo = new OdbcCommand(
                                //      @"INSERT INTO tbl_cliente_paquete 
                                //(fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra)
                                //VALUES (?, ?, ?, 0, 0, ?)", conexion, transaction))
                                //  {
                                //      cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                //      cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                //      cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                //      cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                //      cmdNuevo.ExecuteNonQuery();
                                //  }

                                // No hay paquete activo, crear uno nuevo
                                montoACobrar = costoReferencia;
                                using (OdbcCommand cmdNuevo = new OdbcCommand(
                                    @"INSERT INTO tbl_cliente_paquete 
      (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra, estado_eliminado)
      VALUES (?, ?, ?, 0, 0, ?, 1)", conexion, transaction))
                                {
                                    cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                    cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete);
                                    cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                    cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                    cmdNuevo.Parameters.AddWithValue("@estado_eliminado", 1);
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

                    // 3. Insertar detalle de cita (paquete) - CON NÚMERO DE SESIÓN INCREMENTAL
                    // Primero obtener el número de sesión actual
                    int numeroSesionReal = 0;
                    using (OdbcCommand cmdObtenerSesion = new OdbcCommand(
                        "SELECT sesiones_usadas FROM tbl_cliente_paquete WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdObtenerSesion.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
                        object result = cmdObtenerSesion.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            numeroSesionReal = Convert.ToInt32(result) + 1; // +1 porque es la próxima sesión
                        }
                    }

                    // Insertar detalle con el número de sesión real
                    //  using (OdbcCommand cmdInsertar = new OdbcCommand(
                    //      @"INSERT INTO tbl_cita_servicio 
                    //(fk_id_cita, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar, fk_id_cliente_paquete)
                    //VALUES (?, ?, ?, ?, ?, ?)", conexion, transaction))
                    //  {
                    //      cmdInsertar.Parameters.AddWithValue("@fk_id_cita", fk_id_cita);
                    //      cmdInsertar.Parameters.AddWithValue("@fk_id_paquete", fk_id_paquete);
                    //      cmdInsertar.Parameters.AddWithValue("@numero_sesion", numeroSesionReal); // ✅ Número real
                    //      cmdInsertar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                    //      cmdInsertar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                    //      cmdInsertar.Parameters.AddWithValue("@fk_id_cliente_paquete", clientePaqueteId);
                    //      cmdInsertar.ExecuteNonQuery();
                    //  }

                    // Insertar detalle con el número de sesión real
                    using (OdbcCommand cmdInsertar = new OdbcCommand(
                        @"INSERT INTO tbl_cita_servicio 
      (fk_id_cita, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar, fk_id_cliente_paquete, estado_eliminado)
      VALUES (?, ?, ?, ?, ?, ?, 1)", conexion, transaction))
                    {
                        cmdInsertar.Parameters.AddWithValue("@fk_id_cita", fk_id_cita);
                        cmdInsertar.Parameters.AddWithValue("@fk_id_paquete", fk_id_paquete);
                        cmdInsertar.Parameters.AddWithValue("@numero_sesion", numeroSesionReal);
                        cmdInsertar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                        cmdInsertar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                        cmdInsertar.Parameters.AddWithValue("@fk_id_cliente_paquete", clientePaqueteId);
                        cmdInsertar.ExecuteNonQuery();
                    }

                    // 4. Actualizar sesiones usadas - LÓGICA CORREGIDA
                    // Primero: Incrementar las sesiones
                    using (OdbcCommand cmdIncrementar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET sesiones_usadas = sesiones_usadas + 1
                  WHERE pk_id_cliente_paquete = ?", conexion, transaction))
                    {
                        cmdIncrementar.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
                        cmdIncrementar.ExecuteNonQuery();
                    }

                    // Segundo: Verificar si debe finalizarse basándose en el valor ACTUAL
                    using (OdbcCommand cmdVerificarFinal = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET estado = CASE WHEN sesiones_usadas >= ? THEN 'Finalizado' ELSE 'En uso' END
                  WHERE pk_id_cliente_paquete = ?", conexion, transaction))
                    {
                        cmdVerificarFinal.Parameters.AddWithValue("@sesiones_totales", sesionesTotales);
                        cmdVerificarFinal.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
                        cmdVerificarFinal.ExecuteNonQuery();
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

                    //  using (OdbcCommand cmdInsertar = new OdbcCommand(
                    //      @"INSERT INTO tbl_cita_servicio 
                    //(fk_id_cita, fk_id_servicio, costo_referencia, monto_a_cobrar)
                    //VALUES (?, ?, ?, ?)", conexion, transaction))
                    //  {
                    //      cmdInsertar.Parameters.AddWithValue("@fk_id_cita", fk_id_cita);
                    //      cmdInsertar.Parameters.AddWithValue("@fk_id_servicio", fk_id_servicio);
                    //      cmdInsertar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                    //      cmdInsertar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                    //      cmdInsertar.ExecuteNonQuery();
                    //  }
                    using (OdbcCommand cmdInsertar = new OdbcCommand(
      @"INSERT INTO tbl_cita_servicio 
      (fk_id_cita, fk_id_servicio, costo_referencia, monto_a_cobrar, estado_eliminado)
      VALUES (?, ?, ?, ?, 1)", conexion, transaction))
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
            catch (Exception ex)
            {
                // Rollback en caso de error
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcInsertarDetalle: {ex.Message}");
                MessageBox.Show("Error al insertar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                // Cleanup en finally
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }

                // NO CERRAR LA CONEXIÓN AQUÍ porque puede ser una conexión global
                // Solo dispose si fue creada localmente
                conexion = null;
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
                //string sqlTotal = "SELECT COALESCE(SUM(monto_a_cobrar), 0) AS total FROM tbl_cita_servicio WHERE fk_id_cita = ?";
                string sqlTotal = "SELECT COALESCE(SUM(monto_a_cobrar), 0) AS total FROM tbl_cita_servicio WHERE fk_id_cita = ? AND estado_eliminado = 1";

                decimal nuevoTotal = 0;

                using (OdbcCommand cmdTotal = new OdbcCommand(sqlTotal, conexion, transaction))
                {
                    cmdTotal.Parameters.AddWithValue("@id_cita", fk_id_cita);
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
                    cmdPagos.Parameters.AddWithValue("@id_cita", fk_id_cita);
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
                    cmdActualizar.Parameters.AddWithValue("@total", nuevoTotal);
                    cmdActualizar.Parameters.AddWithValue("@saldo", saldoPendiente);
                    cmdActualizar.Parameters.AddWithValue("@id_cita", fk_id_cita);

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
                    // Solo abrir si está cerrada
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

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
                        cmd.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                        cmd.Parameters.AddWithValue("@id_paquete", fk_id_paquete);

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


        //public void funcActualizarCita(int idCita, int Cliente, DateTime fecha, string EstadoCita, float Total, float SaldoPendiente)
        //{
        //    try
        //    {
        //        using (OdbcConnection conexion = con.conexion())
        //        {
        //            string sql = "UPDATE tbl_citas SET fk_id_cliente = ?, fecha_cita = ?, estado = ?, total = ?, saldo_pendiente = ? WHERE pk_id_cita = ? AND estado_eliminado = 1";

        //            using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
        //            {
        //                cmd.Parameters.AddWithValue("fk_id_cliente", Cliente);
        //                cmd.Parameters.AddWithValue("fecha_cita", fecha);
        //                cmd.Parameters.AddWithValue("estado", EstadoCita);
        //                cmd.Parameters.AddWithValue("total", Total);
        //                cmd.Parameters.AddWithValue("saldo_pendiente", SaldoPendiente);
        //                cmd.Parameters.AddWithValue("pk_id_cita", idCita);

        //                int filasAfectadas = cmd.ExecuteNonQuery();

        //                if (filasAfectadas == 0)
        //                {
        //                    throw new Exception("No se encontró la cita o ya fue eliminada");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error en funcActualizarCita (Modelo): {ex.Message}");
        //        throw;
        //    }
        //}
        public void funcActualizarCita(int idCita, int Cliente, DateTime fecha, string EstadoCita)
        {
            try
            {
                using (OdbcConnection conexion = con.conexion())
                {
                    string sql = "UPDATE tbl_citas SET fk_id_cliente = ?, fecha_cita = ?, estado = ? WHERE pk_id_cita = ? AND estado_eliminado = 1";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("fk_id_cliente", Cliente);
                        cmd.Parameters.AddWithValue("fecha_cita", fecha);
                        cmd.Parameters.AddWithValue("estado", EstadoCita);
                        cmd.Parameters.AddWithValue("pk_id_cita", idCita);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la cita o ya fue eliminada");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en funcActualizarCita (Modelo): {ex.Message}");
                throw;
            }
        }

        //public void funcEliminarCita(int idCita)
        //{
        //    OdbcConnection conexion = null;
        //    OdbcTransaction transaction = null;

        //    try
        //    {
        //        conexion = con.conexion();

        //        // Abrir conexión si está cerrada
        //        if (conexion.State == ConnectionState.Closed)
        //        {
        //            conexion.Open();
        //        }

        //        transaction = conexion.BeginTransaction();

        //        // 1. Verificar que la cita existe y está activa
        //        using (OdbcCommand cmdVerificar = new OdbcCommand(
        //            "SELECT COUNT(*) FROM tbl_citas WHERE pk_id_cita = ? AND estado_eliminado = 1",
        //            conexion, transaction))
        //        {
        //            cmdVerificar.Parameters.AddWithValue("@id_cita", idCita);
        //            object result = cmdVerificar.ExecuteScalar();

        //            if (Convert.ToInt32(result) == 0)
        //            {
        //                throw new Exception("La cita no existe o ya fue eliminada");
        //            }
        //        }

        //        // 2. Actualizar tbl_citas: estado_eliminado = 0 y estado = 'Cancelado'
        //        using (OdbcCommand cmdCitas = new OdbcCommand(
        //            "UPDATE tbl_citas SET estado_eliminado = 0, estado = 'Cancelado' WHERE pk_id_cita = ?",
        //            conexion, transaction))
        //        {
        //            cmdCitas.Parameters.AddWithValue("@id_cita", idCita);
        //            int filasCitas = cmdCitas.ExecuteNonQuery();

        //            if (filasCitas == 0)
        //            {
        //                throw new Exception("No se pudo actualizar la cita");
        //            }
        //        }

        //        // 3. Actualizar tbl_cita_servicio: estado_eliminado = 0
        //        using (OdbcCommand cmdDetalle = new OdbcCommand(
        //            "UPDATE tbl_cita_servicio SET estado_eliminado = 0 WHERE fk_id_cita = ?",
        //            conexion, transaction))
        //        {
        //            cmdDetalle.Parameters.AddWithValue("@id_cita", idCita);
        //            cmdDetalle.ExecuteNonQuery();
        //        }

        //        // 4. Si hay paquetes asociados, actualizar tbl_cliente_paquete
        //        // Primero obtener los IDs de paquetes del cliente asociados a esta cita
        //        using (OdbcCommand cmdObtenerPaquetes = new OdbcCommand(
        //            @"SELECT DISTINCT fk_id_cliente_paquete 
        //      FROM tbl_cita_servicio 
        //      WHERE fk_id_cita = ? AND fk_id_cliente_paquete IS NOT NULL",
        //            conexion, transaction))
        //        {
        //            cmdObtenerPaquetes.Parameters.AddWithValue("@id_cita", idCita);

        //            using (OdbcDataReader reader = cmdObtenerPaquetes.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int clientePaqueteId = Convert.ToInt32(reader[0]);

        //                    // Actualizar el paquete del cliente a estado_eliminado = 0
        //                    using (OdbcCommand cmdPaquete = new OdbcCommand(
        //                        "UPDATE tbl_cliente_paquete SET estado_eliminado = 0 WHERE pk_id_cliente_paquete = ?",
        //                        conexion, transaction))
        //                    {
        //                        cmdPaquete.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
        //                        cmdPaquete.ExecuteNonQuery();
        //                    }
        //                }
        //            }
        //        }

        //        transaction.Commit();
        //        Console.WriteLine($"Cita {idCita} eliminada lógicamente con todos sus detalles");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Rollback en caso de error
        //        if (transaction != null)
        //        {
        //            try
        //            {
        //                transaction.Rollback();
        //            }
        //            catch { }
        //        }

        //        Console.WriteLine($"Error en funcEliminarCita: {ex.Message}");
        //        throw;
        //    }
        //    finally
        //    {
        //        // Cleanup
        //        if (transaction != null)
        //        {
        //            try { transaction.Dispose(); } catch { }
        //        }

        //        // No cerrar la conexión aquí porque puede ser global
        //        conexion = null;
        //    }
        //}

        public void funcEliminarCita(int idCita)
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
                using (OdbcCommand cmdVerificar = new OdbcCommand(
                    "SELECT COUNT(*) FROM tbl_citas WHERE pk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdVerificar.Parameters.AddWithValue("@id_cita", idCita);
                    object result = cmdVerificar.ExecuteScalar();

                    if (Convert.ToInt32(result) == 0)
                    {
                        throw new Exception("La cita no existe o ya fue eliminada");
                    }
                }

                // 2. Actualizar tbl_citas: estado_eliminado = 0 y estado = 'Cancelado'
                using (OdbcCommand cmdCitas = new OdbcCommand(
                    "UPDATE tbl_citas SET estado_eliminado = 0, estado = 'Cancelado' WHERE pk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdCitas.Parameters.AddWithValue("@id_cita", idCita);
                    int filasCitas = cmdCitas.ExecuteNonQuery();

                    if (filasCitas == 0)
                    {
                        throw new Exception("No se pudo actualizar la cita");
                    }
                }

                // 3. Actualizar tbl_cita_servicio: estado_eliminado = 0
                using (OdbcCommand cmdDetalle = new OdbcCommand(
                    "UPDATE tbl_cita_servicio SET estado_eliminado = 0 WHERE fk_id_cita = ?",
                    conexion, transaction))
                {
                    cmdDetalle.Parameters.AddWithValue("@id_cita", idCita);
                    cmdDetalle.ExecuteNonQuery();
                }

                // 4. Si hay paquetes asociados, actualizar tbl_cliente_paquete
                // Primero obtener los IDs de paquetes del cliente asociados a esta cita
                using (OdbcCommand cmdObtenerPaquetes = new OdbcCommand(
                    @"SELECT DISTINCT fk_id_cliente_paquete 
              FROM tbl_cita_servicio 
              WHERE fk_id_cita = ? AND fk_id_cliente_paquete IS NOT NULL",
                    conexion, transaction))
                {
                    cmdObtenerPaquetes.Parameters.AddWithValue("@id_cita", idCita);

                    using (OdbcDataReader reader = cmdObtenerPaquetes.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clientePaqueteId = Convert.ToInt32(reader[0]);

                            // Actualizar el paquete del cliente: estado_eliminado = 0 Y estado = 'Finalizado'
                            using (OdbcCommand cmdPaquete = new OdbcCommand(
                                "UPDATE tbl_cliente_paquete SET estado_eliminado = 0, estado = 'Finalizado' WHERE pk_id_cliente_paquete = ?",
                                conexion, transaction))
                            {
                                cmdPaquete.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteId);
                                cmdPaquete.ExecuteNonQuery();
                            }
                        }
                    }
                }

                transaction.Commit();
                Console.WriteLine($"Cita {idCita} eliminada lógicamente con todos sus detalles y paquetes marcados como finalizados");
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

                Console.WriteLine($"Error en funcEliminarCita: {ex.Message}");
                throw;
            }
            finally
            {
                // Cleanup
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }

                // No cerrar la conexión aquí porque puede ser global
                conexion = null;
            }
        }

        // ═══════════════════════════════════════════════════════════════════════════
        // 1️⃣ CAPA MODELO - Clase Sentencias
        // ═══════════════════════════════════════════════════════════════════════════
        // Agregar este método en tu clase Sentencias.cs

        /// <summary>
        /// Actualiza un detalle de cita existente, manejando cambios entre servicios y paquetes
        /// </summary>
        /// <param name="idDetalle">ID del registro en tbl_cita_servicio</param>
        /// <param name="fk_id_cita">ID de la cita</param>
        /// <param name="fk_id_servicio_nuevo">ID del servicio nuevo (0 si es paquete)</param>
        /// <param name="fk_id_paquete_nuevo">ID del paquete nuevo (0 si es servicio)</param>
        /// <param name="numero_sesion">Número de sesión (se calcula automáticamente)</param>
        public void funcActualizarDetalle(int idDetalle, int fk_id_cita, int fk_id_servicio_nuevo, int fk_id_paquete_nuevo, int numero_sesion)
        {
            // Validaciones iniciales
            if (idDetalle <= 0)
                throw new ArgumentException("ID de detalle debe ser mayor a 0");

            if (fk_id_cita <= 0)
                throw new ArgumentException("ID de cita debe ser mayor a 0");

            if (fk_id_servicio_nuevo <= 0 && fk_id_paquete_nuevo <= 0)
                throw new ArgumentException("Debe especificar un servicio o un paquete");

            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

                // =====================================================
                // PASO 1: Obtener información del detalle ACTUAL
                // =====================================================
                int fk_id_servicio_anterior = 0;
                int fk_id_paquete_anterior = 0;
                int fk_id_cliente_paquete_anterior = 0;
                int fk_id_cliente = 0;

                using (OdbcCommand cmdObtener = new OdbcCommand(
                    @"SELECT cs.fk_id_servicio, cs.fk_id_paquete, cs.fk_id_cliente_paquete, c.fk_id_cliente
              FROM tbl_cita_servicio cs
              INNER JOIN tbl_citas c ON cs.fk_id_cita = c.pk_id_cita
              WHERE cs.pk_id_cita_servicio = ? AND cs.estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdObtener.Parameters.AddWithValue("@id_detalle", idDetalle);
                    using (OdbcDataReader reader = cmdObtener.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fk_id_servicio_anterior = !reader.IsDBNull(0) ? Convert.ToInt32(reader[0]) : 0;
                            fk_id_paquete_anterior = !reader.IsDBNull(1) ? Convert.ToInt32(reader[1]) : 0;
                            fk_id_cliente_paquete_anterior = !reader.IsDBNull(2) ? Convert.ToInt32(reader[2]) : 0;
                            fk_id_cliente = Convert.ToInt32(reader[3]);
                        }
                        else
                        {
                            throw new Exception($"No se encontró el detalle con ID {idDetalle} o ya fue eliminado");
                        }
                    }
                }

                // =====================================================
                // PASO 2: REVERTIR el registro anterior (si era paquete)
                // =====================================================
                if (fk_id_paquete_anterior > 0 && fk_id_cliente_paquete_anterior > 0)
                {
                    // Decrementar sesiones usadas del paquete anterior
                    using (OdbcCommand cmdDecrementar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET sesiones_usadas = CASE WHEN sesiones_usadas > 0 THEN sesiones_usadas - 1 ELSE 0 END
                  WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdDecrementar.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete_anterior);
                        cmdDecrementar.ExecuteNonQuery();
                    }

                    // Verificar si debe volver a 'En uso'
                    using (OdbcCommand cmdReactivar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete cp
                  INNER JOIN tbl_paquetes p ON cp.fk_id_paquete = p.pk_id_paquete
                  SET cp.estado = CASE WHEN cp.sesiones_usadas < p.numero_sesiones THEN 'En uso' ELSE 'Finalizado' END
                  WHERE cp.pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdReactivar.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete_anterior);
                        cmdReactivar.ExecuteNonQuery();
                    }
                }

                // =====================================================
                // PASO 3: Determinar el tipo de cambio y procesar
                // =====================================================
                decimal costoReferencia = 0;
                decimal montoACobrar = 0;
                int clientePaqueteIdNuevo = 0;
                int numeroSesionReal = 0;

                // --- CASO A: El nuevo es un SERVICIO ---
                if (fk_id_servicio_nuevo > 0)
                {
                    // Obtener precio del servicio
                    using (OdbcCommand cmdServicio = new OdbcCommand(
                        "SELECT precio FROM tbl_servicios WHERE pk_id_servicio = ?",
                        conexion, transaction))
                    {
                        cmdServicio.Parameters.AddWithValue("@id_servicio", fk_id_servicio_nuevo);
                        object result = cmdServicio.ExecuteScalar();
                        if (result == DBNull.Value)
                            throw new Exception($"Servicio con ID {fk_id_servicio_nuevo} no encontrado");

                        costoReferencia = Convert.ToDecimal(result);
                        montoACobrar = costoReferencia;
                    }

                    // Actualizar el detalle a SERVICIO
                    using (OdbcCommand cmdActualizar = new OdbcCommand(
                        @"UPDATE tbl_cita_servicio
                  SET fk_id_servicio = ?, 
                      fk_id_paquete = NULL,
                      numero_sesion = NULL,
                      fk_id_cliente_paquete = NULL,
                      costo_referencia = ?,
                      monto_a_cobrar = ?
                  WHERE pk_id_cita_servicio = ?",
                        conexion, transaction))
                    {
                        cmdActualizar.Parameters.AddWithValue("@fk_id_servicio", fk_id_servicio_nuevo);
                        cmdActualizar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                        cmdActualizar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                        cmdActualizar.Parameters.AddWithValue("@id_detalle", idDetalle);
                        cmdActualizar.ExecuteNonQuery();
                    }
                }
                // --- CASO B: El nuevo es un PAQUETE ---
                else if (fk_id_paquete_nuevo > 0)
                {
                    int sesionesTotales = 0;

                    // 1. Obtener info del paquete nuevo
                    using (OdbcCommand cmdPaquete = new OdbcCommand(
                        "SELECT precio_total, numero_sesiones FROM tbl_paquetes WHERE pk_id_paquete = ?",
                        conexion, transaction))
                    {
                        cmdPaquete.Parameters.AddWithValue("@id_paquete", fk_id_paquete_nuevo);
                        using (OdbcDataReader reader = cmdPaquete.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                costoReferencia = Convert.ToDecimal(reader[0]);
                                sesionesTotales = Convert.ToInt32(reader[1]);
                            }
                            else
                                throw new Exception($"Paquete con ID {fk_id_paquete_nuevo} no encontrado");
                        }
                    }

                    // 2. Buscar paquete activo del cliente (SOLO 'En uso' y estado_eliminado = 1)
                    using (OdbcCommand cmdVerificar = new OdbcCommand(
                        @"SELECT pk_id_cliente_paquete, sesiones_usadas
                  FROM tbl_cliente_paquete
                  WHERE fk_id_cliente = ? AND fk_id_paquete = ? AND estado = 'En uso' AND estado_eliminado = 1
                  ORDER BY fecha_compra ASC
                  LIMIT 1",
                        conexion, transaction))
                    {
                        cmdVerificar.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                        cmdVerificar.Parameters.AddWithValue("@id_paquete", fk_id_paquete_nuevo);

                        using (OdbcDataReader reader = cmdVerificar.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Paquete existente y activo
                                clientePaqueteIdNuevo = Convert.ToInt32(reader[0]);
                                int sesionesUsadas = Convert.ToInt32(reader[1]);

                                if (sesionesUsadas < sesionesTotales)
                                {
                                    montoACobrar = 0; // Continuidad: no cobrar
                                }
                                else
                                {
                                    // Crear nuevo paquete
                                    montoACobrar = costoReferencia;
                                    using (OdbcCommand cmdNuevo = new OdbcCommand(
                                        @"INSERT INTO tbl_cliente_paquete 
                                  (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra, estado_eliminado)
                                  VALUES (?, ?, ?, 0, 0, ?, 1)",
                                        conexion, transaction))
                                    {
                                        cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                        cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete_nuevo);
                                        cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                        cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                        cmdNuevo.ExecuteNonQuery();
                                    }

                                    using (OdbcCommand cmdUltimo = new OdbcCommand("SELECT LAST_INSERT_ID()", conexion, transaction))
                                    {
                                        clientePaqueteIdNuevo = Convert.ToInt32(cmdUltimo.ExecuteScalar());
                                    }
                                }
                            }
                            else
                            {
                                // No hay paquete activo, crear uno nuevo
                                montoACobrar = costoReferencia;
                                using (OdbcCommand cmdNuevo = new OdbcCommand(
                                    @"INSERT INTO tbl_cliente_paquete 
                              (fk_id_cliente, fk_id_paquete, fecha_compra, sesiones_usadas, saldo_pendiente, fk_id_cita_compra, estado_eliminado)
                              VALUES (?, ?, ?, 0, 0, ?, 1)",
                                    conexion, transaction))
                                {
                                    cmdNuevo.Parameters.AddWithValue("@id_cliente", fk_id_cliente);
                                    cmdNuevo.Parameters.AddWithValue("@id_paquete", fk_id_paquete_nuevo);
                                    cmdNuevo.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                                    cmdNuevo.Parameters.AddWithValue("@id_cita", fk_id_cita);
                                    cmdNuevo.ExecuteNonQuery();
                                }

                                using (OdbcCommand cmdUltimo = new OdbcCommand("SELECT LAST_INSERT_ID()", conexion, transaction))
                                {
                                    clientePaqueteIdNuevo = Convert.ToInt32(cmdUltimo.ExecuteScalar());
                                }
                            }
                        }
                    }

                    // 3. Obtener número de sesión real
                    using (OdbcCommand cmdObtenerSesion = new OdbcCommand(
                        "SELECT sesiones_usadas FROM tbl_cliente_paquete WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdObtenerSesion.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteIdNuevo);
                        object result = cmdObtenerSesion.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            numeroSesionReal = Convert.ToInt32(result) + 1;
                        }
                    }

                    // 4. Actualizar el detalle a PAQUETE
                    using (OdbcCommand cmdActualizar = new OdbcCommand(
                        @"UPDATE tbl_cita_servicio
                  SET fk_id_servicio = NULL,
                      fk_id_paquete = ?,
                      numero_sesion = ?,
                      fk_id_cliente_paquete = ?,
                      costo_referencia = ?,
                      monto_a_cobrar = ?
                  WHERE pk_id_cita_servicio = ?",
                        conexion, transaction))
                    {
                        cmdActualizar.Parameters.AddWithValue("@fk_id_paquete", fk_id_paquete_nuevo);
                        cmdActualizar.Parameters.AddWithValue("@numero_sesion", numeroSesionReal);
                        cmdActualizar.Parameters.AddWithValue("@fk_id_cliente_paquete", clientePaqueteIdNuevo);
                        cmdActualizar.Parameters.AddWithValue("@costo_referencia", costoReferencia);
                        cmdActualizar.Parameters.AddWithValue("@monto_a_cobrar", montoACobrar);
                        cmdActualizar.Parameters.AddWithValue("@id_detalle", idDetalle);
                        cmdActualizar.ExecuteNonQuery();
                    }

                    // 5. Incrementar sesiones usadas del nuevo paquete
                    using (OdbcCommand cmdIncrementar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET sesiones_usadas = sesiones_usadas + 1
                  WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdIncrementar.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteIdNuevo);
                        cmdIncrementar.ExecuteNonQuery();
                    }

                    // 6. Verificar si debe finalizarse
                    using (OdbcCommand cmdVerificarFinal = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET estado = CASE WHEN sesiones_usadas >= ? THEN 'Finalizado' ELSE 'En uso' END
                  WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdVerificarFinal.Parameters.AddWithValue("@sesiones_totales", sesionesTotales);
                        cmdVerificarFinal.Parameters.AddWithValue("@id_cliente_paquete", clientePaqueteIdNuevo);
                        cmdVerificarFinal.ExecuteNonQuery();
                    }
                }

                // =====================================================
                // PASO 4: Actualizar totales de la cita
                // =====================================================
                funcActualizarTotalesCita(fk_id_cita, conexion, transaction);

                transaction.Commit();
                Console.WriteLine($"Detalle {idDetalle} actualizado correctamente");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcActualizarDetalle: {ex.Message}");
                MessageBox.Show("Error al actualizar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }
                conexion = null;
            }
        }


        // ═══════════════════════════════════════════════════════════════════════════
        // 1️⃣ CAPA MODELO - Clase Sentencias
        // ═══════════════════════════════════════════════════════════════════════════
        // Agregar este método en tu clase Sentencias.cs

        /// <summary>
        /// Elimina lógicamente un detalle de cita y ajusta los totales
        /// Si es paquete: decrementa sesiones y actualiza estado
        /// Si es servicio: solo recalcula totales
        /// </summary>
        /// <param name="idDetalle">ID del registro en tbl_cita_servicio a eliminar</param>
        public void funcEliminarDetalle(int idDetalle)
        {
            // Validación inicial
            if (idDetalle <= 0)
                throw new ArgumentException("ID de detalle debe ser mayor a 0");

            OdbcConnection conexion = null;
            OdbcTransaction transaction = null;

            try
            {
                conexion = con.conexion();

                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                transaction = conexion.BeginTransaction();

                // =====================================================
                // PASO 1: Obtener información del detalle a eliminar
                // =====================================================
                int fk_id_cita = 0;
                int fk_id_servicio = 0;
                int fk_id_paquete = 0;
                int fk_id_cliente_paquete = 0;
                decimal monto_a_cobrar = 0;
                int numero_sesion = 0;

                using (OdbcCommand cmdObtener = new OdbcCommand(
                    @"SELECT fk_id_cita, fk_id_servicio, fk_id_paquete, fk_id_cliente_paquete, 
                     monto_a_cobrar, numero_sesion
              FROM tbl_cita_servicio
              WHERE pk_id_cita_servicio = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdObtener.Parameters.AddWithValue("@id_detalle", idDetalle);
                    using (OdbcDataReader reader = cmdObtener.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fk_id_cita = Convert.ToInt32(reader[0]);
                            fk_id_servicio = !reader.IsDBNull(1) ? Convert.ToInt32(reader[1]) : 0;
                            fk_id_paquete = !reader.IsDBNull(2) ? Convert.ToInt32(reader[2]) : 0;
                            fk_id_cliente_paquete = !reader.IsDBNull(3) ? Convert.ToInt32(reader[3]) : 0;
                            monto_a_cobrar = Convert.ToDecimal(reader[4]);
                            numero_sesion = !reader.IsDBNull(5) ? Convert.ToInt32(reader[5]) : 0;
                        }
                        else
                        {
                            throw new Exception($"No se encontró el detalle con ID {idDetalle} o ya fue eliminado");
                        }
                    }
                }

                // =====================================================
                // PASO 2: Verificar si es el único detalle de la cita
                // =====================================================
                int cantidadDetalles = 0;
                using (OdbcCommand cmdContar = new OdbcCommand(
                    @"SELECT COUNT(*) 
              FROM tbl_cita_servicio 
              WHERE fk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdContar.Parameters.AddWithValue("@id_cita", fk_id_cita);
                    cantidadDetalles = Convert.ToInt32(cmdContar.ExecuteScalar());
                }

                // Si es el único detalle, mostrar advertencia pero permitir eliminar
                if (cantidadDetalles == 1)
                {
                    Console.WriteLine("ADVERTENCIA: Este es el único detalle de la cita. La cita quedará sin servicios.");
                }

                // =====================================================
                // PASO 3: Si era un PAQUETE, revertir las sesiones
                // =====================================================
                if (fk_id_paquete > 0 && fk_id_cliente_paquete > 0)
                {
                    // A. Decrementar sesiones usadas
                    using (OdbcCommand cmdDecrementar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete
                  SET sesiones_usadas = CASE WHEN sesiones_usadas > 0 THEN sesiones_usadas - 1 ELSE 0 END
                  WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdDecrementar.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete);
                        int filasAfectadas = cmdDecrementar.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine($"Sesiones decrementadas para paquete {fk_id_cliente_paquete}");
                        }
                    }

                    // B. Verificar si el paquete debe volver a "En uso"
                    using (OdbcCommand cmdReactivar = new OdbcCommand(
                        @"UPDATE tbl_cliente_paquete cp
                  INNER JOIN tbl_paquetes p ON cp.fk_id_paquete = p.pk_id_paquete
                  SET cp.estado = CASE 
                      WHEN cp.sesiones_usadas < p.numero_sesiones THEN 'En uso' 
                      ELSE 'Finalizado' 
                  END
                  WHERE cp.pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdReactivar.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete);
                        cmdReactivar.ExecuteNonQuery();
                    }

                    // C. Verificar si el paquete ahora tiene 0 sesiones usadas
                    // Si es así, considerarlo para eliminación lógica también
                    int sesionesRestantes = 0;
                    using (OdbcCommand cmdVerificar = new OdbcCommand(
                        "SELECT sesiones_usadas FROM tbl_cliente_paquete WHERE pk_id_cliente_paquete = ?",
                        conexion, transaction))
                    {
                        cmdVerificar.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete);
                        object result = cmdVerificar.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            sesionesRestantes = Convert.ToInt32(result);
                        }
                    }

                    // Si el paquete quedó con 0 sesiones, verificar si era la cita de compra
                    if (sesionesRestantes == 0)
                    {
                        int citaCompra = 0;
                        using (OdbcCommand cmdCitaCompra = new OdbcCommand(
                            "SELECT fk_id_cita_compra FROM tbl_cliente_paquete WHERE pk_id_cliente_paquete = ?",
                            conexion, transaction))
                        {
                            cmdCitaCompra.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete);
                            object result = cmdCitaCompra.ExecuteScalar();
                            if (result != DBNull.Value && result != null)
                            {
                                citaCompra = Convert.ToInt32(result);
                            }
                        }

                        // Si esta era la cita donde se compró el paquete Y quedó en 0 sesiones,
                        // eliminar lógicamente el paquete también
                        if (citaCompra == fk_id_cita)
                        {
                            using (OdbcCommand cmdEliminarPaquete = new OdbcCommand(
                                @"UPDATE tbl_cliente_paquete 
                          SET estado_eliminado = 0, estado = 'Finalizado'
                          WHERE pk_id_cliente_paquete = ?",
                                conexion, transaction))
                            {
                                cmdEliminarPaquete.Parameters.AddWithValue("@id_cliente_paquete", fk_id_cliente_paquete);
                                cmdEliminarPaquete.ExecuteNonQuery();
                                Console.WriteLine($"Paquete {fk_id_cliente_paquete} eliminado (era compra en esta cita y quedó en 0 sesiones)");
                            }
                        }
                    }
                }

                // =====================================================
                // PASO 4: Eliminar lógicamente el detalle
                // =====================================================
                using (OdbcCommand cmdEliminarDetalle = new OdbcCommand(
                    @"UPDATE tbl_cita_servicio 
              SET estado_eliminado = 0 
              WHERE pk_id_cita_servicio = ?",
                    conexion, transaction))
                {
                    cmdEliminarDetalle.Parameters.AddWithValue("@id_detalle", idDetalle);
                    int filasAfectadas = cmdEliminarDetalle.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo eliminar el detalle");
                    }
                }

                // =====================================================
                // PASO 5: Recalcular totales de la cita
                // =====================================================
                funcActualizarTotalesCita(fk_id_cita, conexion, transaction);

                // =====================================================
                // PASO 6: Verificar si la cita quedó sin detalles activos
                // =====================================================
                int detallesActivos = 0;
                using (OdbcCommand cmdContarActivos = new OdbcCommand(
                    @"SELECT COUNT(*) 
              FROM tbl_cita_servicio 
              WHERE fk_id_cita = ? AND estado_eliminado = 1",
                    conexion, transaction))
                {
                    cmdContarActivos.Parameters.AddWithValue("@id_cita", fk_id_cita);
                    detallesActivos = Convert.ToInt32(cmdContarActivos.ExecuteScalar());
                }

                // Si quedó sin detalles, actualizar el estado de la cita a "Pendiente"
                if (detallesActivos == 0)
                {
                    using (OdbcCommand cmdActualizarCita = new OdbcCommand(
                        @"UPDATE tbl_citas 
                  SET estado = 'Pendiente', total = 0, saldo_pendiente = 0 
                  WHERE pk_id_cita = ?",
                        conexion, transaction))
                    {
                        cmdActualizarCita.Parameters.AddWithValue("@id_cita", fk_id_cita);
                        cmdActualizarCita.ExecuteNonQuery();
                        Console.WriteLine($"Cita {fk_id_cita} quedó sin detalles activos");
                    }
                }

                transaction.Commit();

                string tipoDetalle = fk_id_servicio > 0 ? "servicio" : "paquete";
                Console.WriteLine($"Detalle {idDetalle} ({tipoDetalle}) eliminado correctamente");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                    }
                    catch { }
                }

                Console.WriteLine($"Error en funcEliminarDetalle: {ex.Message}");
                MessageBox.Show("Error al eliminar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                if (transaction != null)
                {
                    try { transaction.Dispose(); } catch { }
                }
                conexion = null;
            }
        }



    }
}
