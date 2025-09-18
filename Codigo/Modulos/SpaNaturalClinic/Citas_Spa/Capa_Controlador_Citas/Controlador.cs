using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Citas;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Citas
{
    public class Controlador
    {

        Sentencias sn = new Sentencias();

        //Llenar una tabla Capa Controlador
        //public DataTable llenarTbl(string tabla)
        //{
        //    OdbcDataAdapter dt = sn.llenarTbl(tabla);
        //    DataTable table = new DataTable();
        //    dt.Fill(table);
        //    return table;
        //}

        public DataTable llenarDetalleCitas()
        {
            OdbcDataAdapter dt = sn.llenarDetalleCitas();
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public DataTable funConsultarCitas()
        {
            try
            {
                OdbcDataAdapter dt = sn.funConsultarCitas();
                DataTable table = new DataTable();
                dt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en funConsultarCitas: " + ex.Message);
                return null;
            }
        }

        public DataTable funConsultarDetalle()
        {
            try
            {
                OdbcDataAdapter dt = sn.funConsultarDetalle();
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

        public DataRow ObtenerPrecioServicio(string idEmpleado)
        {
            return sn.ObtenerPrecioServicio(idEmpleado);
        }

        public DataRow ObtenerPrecioPaquete(string idEmpleado)
        {
            return sn.ObtenerPrecioPaquete(idEmpleado);
        }

        /*********************Ismar Leonel Cortez Sanchez -0901-21-560************/
        /***********************Combo box inteligente*****************************/

        public DataTable enviar(string tabla, string campo1, string campo2)
        {

            var dt1 = sn.obtener2(tabla, campo1, campo2);
            return dt1;
        }
        /**************************************************************************/

        public bool funcInsertarCita(int Cliente, DateTime fecha, string EstadoCita, float Total, float SaldoPendiente)
        {
            try
            {


                // Verificar si los salarios son válidos
                //if (salarioactual < 0 || salarionuevo < 0)
                //{
                //    throw new ArgumentException("Los salarios no pueden ser negativos.");
                //}

                // Llamada al modelo para insertar la promoción
                sn.funcInsertarCita(Cliente, fecha, EstadoCita, Total, SaldoPendiente);
                return true; // Si llegamos aquí, la inserción fue exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en insertar cita: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw new Exception($"Error al insertar el registro: {ex.Message}");
                return false; // En caso de error
            }
        }

        //public bool funcInsertarDetalle(int iServicio, int iPaquete, int iSesion)
        //{
        //    try
        //    {


        //        // Verificar si los salarios son válidos
        //        //if (salarioactual < 0 || salarionuevo < 0)
        //        //{
        //        //    throw new ArgumentException("Los salarios no pueden ser negativos.");
        //        //}

        //        // Llamada al modelo para insertar la promoción
        //        sn.funcInsertarDetalle(iServicio, iPaquete, iSesion);
        //        return true; // Si llegamos aquí, la inserción fue exitosa
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error en insertar cita: {ex.Message}");
        //        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        //        throw new Exception($"Error al insertar el registro: {ex.Message}");
        //        return false; // En caso de error
        //    }
        //}
        public bool funcInsertarDetalle(int fk_id_cita, int? fk_id_servicio, int? fk_id_paquete, int? numero_sesion, decimal costoReferencia)
        {
            try
            {
                sn.funcInsertarDetalle(fk_id_cita, fk_id_servicio, fk_id_paquete, numero_sesion, costoReferencia);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en insertar detalle: {ex.Message}");
                throw new Exception($"Error al insertar el registro: {ex.Message}");
            }
        }


        public int ObtenerUltimoIdCita()
        {
            try
            {
                return sn.ObtenerUltimoIdCita(); // Llama al modelo
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener último ID de cita: " + ex.Message);
                throw;
            }
        }



    }
}
