using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Citas;

namespace Capa_Vista_Citas
{
    public partial class Form_asignarServicios_aCita : Form
    {
        Controlador logica2;
        private int idSeleccionado = 0;
        private int excepcionActiva = 1;
        private int estadoActivo = 1;
        string valorSeleccionado;
        string valorSeleccionado2;

        //logica logicaSeg = new logica();


        Controlador cn = new Controlador();

        string tabla_cita_servicio = "tbl_cita_servicio";

        public Form_asignarServicios_aCita()
        {
            InitializeComponent();
            logica2 = new Controlador();
            CargarDatos();
            ConfigurarControles(false);

            string tabla = "tbl_servicios";
            string campo1 = "pk_id_servicio";
            string campo2 = "nombre";
            // Llama al método para llenar el ComboBox
            llenarseServicios(tabla, campo1, campo2);

            string tablaPa = "tbl_paquetes";
            string campo1Pa= "pk_id_paquete";
            string campo2Pa = "nombre";
            // Llama al método para llenar el ComboBox
            llenarsePaquetes(tablaPa, campo1Pa, campo2Pa);





        }



        /*********************************Ismar Leonel Cortez Sanchez -0901-21-560*****************************************/
        /**************************************Combo box inteligente 1*****************************************************/

        public void llenarseServicios(string tabla, string campo1, string campo2)
        {
            // Obtén los datos para el ComboBox
            var dt2 = logica2.enviar(tabla, campo1, campo2);

            // Limpia el ComboBox antes de llenarlo
            Cbo_servicios.Items.Clear();

            foreach (DataRow row in dt2.Rows)
            {
                // Agrega el elemento mostrando el formato "ID-Nombre"
                Cbo_servicios.Items.Add(new ComboBoxItem
                {
                    Value = row[campo1].ToString(),
                    Display = row[campo2].ToString()
                });
            }

            // Configura AutoComplete para el ComboBox con el formato deseado
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));
            }
            Cbo_servicios.AutoCompleteCustomSource = coleccion;
            Cbo_servicios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_servicios.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        // Clase auxiliar para almacenar Value y Display
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Display { get; set; }

            // Sobrescribir el método ToString para mostrar "ID-Nombre" en el ComboBox
            public override string ToString()
            {
                return $"{Value}-{Display}"; // Formato "ID-Nombre"
            }
        }


        private void Cbo_servicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_servicios.SelectedItem != null)
            {
                // Obtener el valor del ValueMember seleccionado
                var selectedItem = (ComboBoxItem)(Cbo_servicios.SelectedItem);
                valorSeleccionado = selectedItem.Value;
                // Mostrar el valor en un MessageBox
                MessageBox.Show($"Valor seleccionado: {valorSeleccionado}", "Valor Seleccionado");
                Cbo_paquete.Enabled = false;
                Nud_numSesion.Enabled = false;

                DataRow datos = logica2.ObtenerPrecioServicio(valorSeleccionado);
                if (datos != null)
                {
                    Txt_costo.Text = datos["Precio"].ToString(); // Asigna el precio del servicio
                }
                else
                {
                    Txt_costo.Text = "No encontrado";
                }


            }
        }

        /***************************************************************************************************/


        /*********************************Ismar Leonel Cortez Sanchez -0901-21-560*****************************************/
        /**************************************Combo box inteligente 2*****************************************************/

        public void llenarsePaquetes(string tabla, string campo1, string campo2)
        {
            // Obtén los datos para el ComboBox
            var dt2 = logica2.enviar(tabla, campo1, campo2);

            // Limpia el ComboBox antes de llenarlo
            Cbo_paquete.Items.Clear();

            foreach (DataRow row in dt2.Rows)
            {
                // Agrega el elemento mostrando el formato "ID-Nombre"
                Cbo_paquete.Items.Add(new ComboBoxItem
                {
                    Value = row[campo1].ToString(),
                    Display = row[campo2].ToString()
                });
            }

            // Configura AutoComplete para el ComboBox con el formato deseado
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));
            }
            Cbo_paquete.AutoCompleteCustomSource = coleccion;
            Cbo_paquete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_paquete.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        // Clase auxiliar para almacenar Value y Display
        public class ComboBoxItem2
        {
            public string Value { get; set; }
            public string Display { get; set; }

            // Sobrescribir el método ToString para mostrar "ID-Nombre" en el ComboBox
            public override string ToString()
            {
                return $"{Value}-{Display}"; // Formato "ID-Nombre"
            }
        }


        private void Cbo_paquete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_paquete.SelectedItem != null)
            {
                // Obtener el valor del ValueMember seleccionado
                var selectedItem = (ComboBoxItem)(Cbo_paquete.SelectedItem);
                valorSeleccionado2 = selectedItem.Value;
                // Mostrar el valor en un MessageBox
                MessageBox.Show($"Valor seleccionado: {valorSeleccionado2}", "Valor Seleccionado");
                Cbo_servicios.Enabled = false;

                DataRow datos = logica2.ObtenerPrecioPaquete(valorSeleccionado2);
                if (datos != null)
                {
                    Txt_costo.Text = datos["PrecioTotal"].ToString(); // Asigna el precio del servicio
                }
                else
                {
                    Txt_costo.Text = "No encontrado";
                }

            }

        }
        /***************************************************************************************************/







        private void ConfigurarControles(bool habilitar)
        {
            // Habilitar o deshabilitar los controles de texto
            Cbo_servicios.Enabled = habilitar;
            Cbo_paquete.Enabled = habilitar;
            Nud_numSesion.Enabled = habilitar;


            // Habilitar o deshabilitar los botones


            Btn_guardar.Enabled = habilitar;
            Btn_modificar.Enabled = habilitar;
            Btn_eliminar.Enabled = habilitar;
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            // Buscar el último ID en el DataGridView y sumarle 1
            if (Dgv_asignaciones.Rows.Count > 0)
            {
                int maxId = 0;
                foreach (DataGridViewRow row in Dgv_asignaciones.Rows)
                {
                    if (row.Cells["ID"].Value != null)
                    {
                        int currentId = Convert.ToInt32(row.Cells["ID"].Value);
                        if (currentId > maxId)
                            maxId = currentId;
                    }
                }
                // txt_ID.Text = (maxId + 1).ToString();
            }
            else
            {
                // txt_ID.Text = "1";
            }

            Cbo_servicios.SelectedIndex = -1;
            Cbo_paquete.SelectedIndex = -1;

            //ActualizarBotonExcepcion();
            //ActualizarBotonEstado();
        }



        //Mostrar los datos Capa Vista
        //public void actualizardatagriew()
        //{
        //    DataTable dt = cn.llenarDetalleCitas();
        //    Dgv_asignaciones.DataSource = dt;

        //    // Renombrar columnas de forma clara
        //    if (Dgv_asignaciones.Columns.Contains("id_asignacion"))
        //        Dgv_asignaciones.Columns["id_asignacion"].HeaderText = "Asignación";
        //    if (Dgv_asignaciones.Columns.Contains("id_cita"))
        //        Dgv_asignaciones.Columns["id_cita"].HeaderText = "Cita";
        //    if (Dgv_asignaciones.Columns.Contains("nombre_cliente"))
        //        Dgv_asignaciones.Columns["nombre_cliente"].HeaderText = "Cliente";

        //    if (Dgv_asignaciones.Columns.Contains("id_servicio"))
        //        Dgv_asignaciones.Columns["id_servicio"].HeaderText = "ID Servicio";
        //    if (Dgv_asignaciones.Columns.Contains("nombre_servicio"))
        //        Dgv_asignaciones.Columns["nombre_servicio"].HeaderText = "Servicio";

        //    if (Dgv_asignaciones.Columns.Contains("id_paquete"))
        //        Dgv_asignaciones.Columns["id_paquete"].HeaderText = "ID Paquete";
        //    if (Dgv_asignaciones.Columns.Contains("nombre_paquete"))
        //        Dgv_asignaciones.Columns["nombre_paquete"].HeaderText = "Paquete";

        //    if (Dgv_asignaciones.Columns.Contains("numero_sesion"))
        //        Dgv_asignaciones.Columns["numero_sesion"].HeaderText = "Sesión";
        //    if (Dgv_asignaciones.Columns.Contains("costo_referencia"))
        //        Dgv_asignaciones.Columns["costo_referencia"].HeaderText = "Costo Referencia";
        //    if (Dgv_asignaciones.Columns.Contains("monto_a_cobrar"))
        //        Dgv_asignaciones.Columns["monto_a_cobrar"].HeaderText = "Monto Cobrado";
        //    if (Dgv_asignaciones.Columns.Contains("descuento"))
        //        Dgv_asignaciones.Columns["descuento"].HeaderText = "Descuento";
        //    if (Dgv_asignaciones.Columns.Contains("fecha_creacion"))
        //        Dgv_asignaciones.Columns["fecha_creacion"].HeaderText = "Creación";

        //    // Opcional: ocultar columnas ID si solo quieres mostrar nombres
        //    // Dgv_asignaciones.Columns["id_servicio"].Visible = false;
        //    // Dgv_asignaciones.Columns["id_paquete"].Visible = false;
        //}


        private void CargarDatos()
        {
            try
            {
                DataTable dt = logica2.funConsultarDetalle();
                if (dt != null)
                {
                    Dgv_asignaciones.DataSource = dt;

                    //// Buscar el último ID y sumarle 1 para el nuevo registro
                    //if (dt.Rows.Count > 0)
                    //{
                    //    int maxId = dt.AsEnumerable()
                    //        .Max(row => Convert.ToInt32(row["ID"]));
                    //    txt_ID.Text = (maxId + 1).ToString();
                    //}
                    //else
                    //{
                    //    txt_ID.Text = "1";
                    //}
                }
                else
                {
                    MessageBox.Show("Error al cargar los datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void Form_asignarServicios_aCita_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Cbo_paquete.SelectedIndex == -1 && Cbo_servicios.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un servicio o un paquete");
                    return;
                }

                int idServicio = 0;
                int idPaquete = 0;
                int numeroSesion = 0;
                decimal costoReferencia = 0;

                if (Cbo_servicios.SelectedIndex != -1)
                {
                    idServicio = Convert.ToInt32(valorSeleccionado);
                    DataRow datos = logica2.ObtenerPrecioServicio(valorSeleccionado);
                    costoReferencia = datos != null ? Convert.ToDecimal(datos["Precio"]) : 0;
                }
                else if (Cbo_paquete.SelectedIndex != -1)
                {
                    idPaquete = Convert.ToInt32(valorSeleccionado2);
                    numeroSesion = 1/*Convert.ToInt32(Nud_numSesion.Value)*/;
                    DataRow datos = logica2.ObtenerPrecioPaquete(valorSeleccionado2);
                    //costoReferencia = datos != null ? Convert.ToDecimal(datos["PrecioTotal"]) : 0;
                }

                // Obtener el último ID de cita
                int ultimoIdCita = logica2.ObtenerUltimoIdCita();

                // Insertar detalle
                logica2.funcInsertarDetalle(ultimoIdCita, idServicio, idPaquete, numeroSesion);
                MessageBox.Show("Registro insertado exitosamente");

                CargarDatos();
                LimpiarFormulario();
                ConfigurarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void Btn_nuevoRegistro_Click(object sender, EventArgs e)
        {
            ConfigurarControles(true);
            LimpiarFormulario();



            //Btn_Editar.Enabled = false;
            Btn_eliminar.Enabled = false;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(); // Limpia el formulario
            ConfigurarControles(false); // Deshabilita controles de edición
            CargarDatos();
        }

 
    }
}
