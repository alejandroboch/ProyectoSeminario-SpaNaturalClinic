using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Pagos;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Pagos
{
    public class Controlador
    {

        Sentencias sn = new Sentencias();
        /*********************Ismar Leonel Cortez Sanchez -0901-21-560************/
        /***********************Combo box inteligente*****************************/

        public DataTable enviar(string tabla, string campo1, string campo2)
        {

            var dt1 = sn.obtener2(tabla, campo1, campo2);
            return dt1;
        }
        /**************************************************************************/


        public DataTable funConsultarPagos()
        {
            try
            {
                OdbcDataAdapter dt = sn.funConsultarPagos();
                DataTable table = new DataTable();
                dt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarDetalle: " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Obtiene los datos de una cita específica
        /// </summary>
        public DataRow ObtenerDatosCita(int idCita)
        {
            try
            {
                // Validación
                if (idCita <= 0)
                    throw new ArgumentException("ID de cita inválido");

                return sn.ObtenerDatosCita(idCita);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerDatosCita (Controlador): {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Registra un pago para una cita con validaciones de negocio
        /// </summary>
        public void RegistrarPago(int idCita, decimal montoPago, string metodoPago)
        {
            try
            {
                // Validaciones de negocio
                if (idCita <= 0)
                    throw new ArgumentException("ID de cita inválido");

                if (montoPago <= 0)
                    throw new ArgumentException("El monto del pago debe ser mayor a 0");

                if (string.IsNullOrWhiteSpace(metodoPago))
                    throw new ArgumentException("Debe especificar el método de pago");

                // Llamar al modelo
                sn.funcInsertarPago(idCita, montoPago, metodoPago);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RegistrarPago (Controlador): {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene los pagos de una cita específica
        /// </summary>
        public OdbcDataAdapter ConsultarPagosPorCita(int idCita)
        {
            try
            {
                if (idCita <= 0)
                    throw new ArgumentException("ID de cita inválido");

                return sn.funConsultarPagosPorCita(idCita);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ConsultarPagosPorCita (Controlador): {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los pagos registrados
        /// </summary>
        public OdbcDataAdapter ConsultarTodosPagos()
        {
            try
            {
                return sn.funConsultarTodosPagos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ConsultarTodosPagos (Controlador): {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un pago existente con validaciones de negocio
        /// </summary>
        public void ActualizarPago(int idPago, int idCita, decimal nuevoMonto, string nuevoMetodoPago)
        {
            try
            {
                // Validaciones de negocio
                if (idPago <= 0)
                    throw new ArgumentException("ID de pago inválido");

                if (idCita <= 0)
                    throw new ArgumentException("ID de cita inválido");

                if (nuevoMonto <= 0)
                    throw new ArgumentException("El monto del pago debe ser mayor a 0");

                if (string.IsNullOrWhiteSpace(nuevoMetodoPago))
                    throw new ArgumentException("Debe especificar el método de pago");

                // Llamar al modelo
                sn.funcActualizarPago(idPago, idCita, nuevoMonto, nuevoMetodoPago);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ActualizarPago (Controlador): {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Elimina lógicamente un pago con validaciones de negocio
        /// </summary>
        public bool EliminarPago(int idPago)
        {
            try
            {
                // Validaciones de negocio
                if (idPago <= 0)
                    throw new ArgumentException("ID de pago inválido");

                // Llamar al modelo
                return sn.funcEliminarPago(idPago);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en EliminarPago (Controlador): {ex.Message}");
                throw;
            }
        }

    }
}
