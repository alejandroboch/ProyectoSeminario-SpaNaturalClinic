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




        private int idCitaActual = 0; // ✅ NUEVA VARIABLE


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
                //// Mostrar el valor en un MessageBox
                //MessageBox.Show($"Valor seleccionado: {valorSeleccionado}", "Valor Seleccionado");
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
                //MessageBox.Show($"Valor seleccionado: {valorSeleccionado2}", "Valor Seleccionado");
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

            //try
            //{
            //    if (Cbo_paquete.SelectedIndex == -1 && Cbo_servicios.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Seleccione un servicio o un paquete");
            //        return;
            //    }

            //    int idServicio = 0;
            //    int idPaquete = 0;
            //    int numeroSesion = 0;
            //    decimal costoReferencia = 0;

            //    if (Cbo_servicios.SelectedIndex != -1)
            //    {
            //        idServicio = Convert.ToInt32(valorSeleccionado);
            //        DataRow datos = logica2.ObtenerPrecioServicio(valorSeleccionado);
            //        costoReferencia = datos != null ? Convert.ToDecimal(datos["Precio"]) : 0;
            //    }
            //    else if (Cbo_paquete.SelectedIndex != -1)
            //    {
            //        idPaquete = Convert.ToInt32(valorSeleccionado2);
            //        numeroSesion = 1/*Convert.ToInt32(Nud_numSesion.Value)*/;
            //        DataRow datos = logica2.ObtenerPrecioPaquete(valorSeleccionado2);
            //        //costoReferencia = datos != null ? Convert.ToDecimal(datos["PrecioTotal"]) : 0;
            //    }

            //    // Obtener el último ID de cita
            //    int ultimoIdCita = logica2.ObtenerUltimoIdCita();

            //    if (idSeleccionado == 0)
            //    {

            //        // Insertar detalle
            //        logica2.funcInsertarDetalle(ultimoIdCita, idServicio, idPaquete, numeroSesion);
            //        MessageBox.Show("Registro insertado exitosamente");
            //    }
            //    else { 
            //        //Para modificar


            //    }

            //    CargarDatos();
            //    LimpiarFormulario();
            //    ConfigurarControles(false);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al guardar: " + ex.Message);
            //}
            try
            {
                // Validación: Debe seleccionar servicio O paquete
                if (Cbo_paquete.SelectedIndex == -1 && Cbo_servicios.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un servicio o un paquete");
                    return;
                }

                // Validación: No se puede seleccionar ambos
                if (Cbo_paquete.SelectedIndex != -1 && Cbo_servicios.SelectedIndex != -1)
                {
                    MessageBox.Show("Solo puede seleccionar un servicio O un paquete, no ambos");
                    return;
                }

                int idServicio = 0;
                int idPaquete = 0;
                int numeroSesion = 0;
                decimal costoReferencia = 0;

                // Determinar qué se seleccionó
                if (Cbo_servicios.SelectedIndex != -1)
                {
                    idServicio = Convert.ToInt32(valorSeleccionado);
                    DataRow datos = logica2.ObtenerPrecioServicio(valorSeleccionado);
                    costoReferencia = datos != null ? Convert.ToDecimal(datos["Precio"]) : 0;
                }
                else if (Cbo_paquete.SelectedIndex != -1)
                {
                    idPaquete = Convert.ToInt32(valorSeleccionado2);
                    numeroSesion = 1; // Siempre 1, el sistema calcula la sesión real
                    DataRow datos = logica2.ObtenerPrecioPaquete(valorSeleccionado2);
                    costoReferencia = datos != null ? Convert.ToDecimal(datos["PrecioTotal"]) : 0;
                }

                // ============================================
                // MODO INSERCIÓN (cuando idSeleccionado == 0)
                // ============================================
                if (idSeleccionado == 0)
                {
                    int ultimoIdCita = logica2.ObtenerUltimoIdCita();

                    if (ultimoIdCita == 0)
                    {
                        MessageBox.Show("No hay citas registradas. Debe crear una cita primero.");
                        return;
                    }

                    // Insertar detalle
                    logica2.funcInsertarDetalle(ultimoIdCita, idServicio, idPaquete, numeroSesion);
                    MessageBox.Show("Registro insertado exitosamente");
                }
                // ============================================
                // MODO ACTUALIZACIÓN (cuando idSeleccionado > 0)
                // ============================================
                else
                {
                    if (idCitaActual == 0)
                    {
                        MessageBox.Show("No se pudo obtener el ID de la cita. Intente seleccionar el registro nuevamente.");
                        return;
                    }

                    // Confirmar la modificación
                    DialogResult resultado = MessageBox.Show(
                        "¿Está seguro de modificar este detalle de cita?\n\n" +
                        "IMPORTANTE: Si cambia de paquete o servicio, se ajustarán automáticamente las sesiones.",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        // Actualizar detalle
                        logica2.funcActualizarDetalle(idSeleccionado, idCitaActual, idServicio, idPaquete, numeroSesion);
                        MessageBox.Show("Registro actualizado exitosamente");
                    }
                }

                // Limpiar y recargar
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

        private void Dgv_asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    try
            //    {
            //        idSeleccionado = Convert.ToInt32(Dgv_asignaciones.Rows[e.RowIndex].Cells["ID"].Value);
            //        Lbl_NumeroDeCita.Text = idSeleccionado.ToString(); // Añadir esta línea

            //        //// Obtener ID del detalle (ID de tbl_cita_servicio)
            //        //idSeleccionado = Convert.ToInt32(Dgv_asignaciones.Rows[e.RowIndex].Cells["ID"].Value);

            //        // ✅ IMPORTANTE: También obtener el ID de la cita
            //        if (Dgv_asignaciones.Rows[e.RowIndex].Cells["ID_Cita"] != null)
            //        {
            //            idCitaActual = Convert.ToInt32(Dgv_asignaciones.Rows[e.RowIndex].Cells["ID_Cita"].Value);
            //            Lbl_NumeroDeCita.Text = idCitaActual.ToString();
            //        }

            //        Cbo_servicios.SelectedItem = Dgv_asignaciones.Rows[e.RowIndex].Cells["Servicio"].Value.ToString();

            //        //// Obtener el valor de la celda y asignarlo al DateTimePicker
            //        //if (Dgv_citas.Rows[e.RowIndex].Cells["Fecha"].Value != null)
            //        //{
            //        //    DateTime fecha;
            //        //    if (DateTime.TryParse(Dgv_citas.Rows[e.RowIndex].Cells["Fecha"].Value.ToString(), out fecha))
            //        //    {
            //        //        Dtp_fechaCita.Value = fecha;
            //        //    }
            //        //}

            //        Cbo_paquete.SelectedItem = Dgv_asignaciones.Rows[e.RowIndex].Cells["Paquete"].Value.ToString();

            //        //Cbo_clase.SelectedItem = Dgv_perp_dec.Rows[e.RowIndex].Cells["Clase"].Value.ToString();

            //        //excepcionActiva = Convert.ToInt32(Dgv_perp_dec.Rows[e.RowIndex].Cells["Excepcion"].Value);
            //        //estadoActivo = Convert.ToInt32(Dgv_perp_dec.Rows[e.RowIndex].Cells["Estado"].Value);

            //        //ActualizarBotonExcepcion();
            //        //ActualizarBotonEstado();

            //        //Txt_monto.Text = Dgv_perp_dec.Rows[e.RowIndex].Cells["Monto"].Value.ToString();
            //        Btn_modificar.Enabled = true;
            //        Btn_eliminar.Enabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error al seleccionar registro: " + ex.Message);
            //    }
            //}
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener ID del detalle
                    idSeleccionado = Convert.ToInt32(Dgv_asignaciones.Rows[e.RowIndex].Cells["ID"].Value);

                    // ✅ Obtener el ID de la cita
                    if (Dgv_asignaciones.Rows[e.RowIndex].Cells["ID_Cita"].Value != null)
                    {
                        idCitaActual = Convert.ToInt32(Dgv_asignaciones.Rows[e.RowIndex].Cells["ID_Cita"].Value);
                        Lbl_NumeroDeCita.Text = idCitaActual.ToString();
                    }

                    // ✅ Limpiar selecciones previas
                    Cbo_servicios.SelectedIndex = -1;
                    Cbo_paquete.SelectedIndex = -1;
                    Nud_numSesion.Value = 0;
                    Txt_costo.Text = "0.00";

                    // Habilitar ambos ComboBox temporalmente
                    Cbo_servicios.Enabled = true;
                    Cbo_paquete.Enabled = true;
                    Nud_numSesion.Enabled = true;

                    // ✅ Verificar si es un Servicio
                    object valorServicio = Dgv_asignaciones.Rows[e.RowIndex].Cells["Servicio"].Value;
                    bool esServicio = valorServicio != null &&
                                     valorServicio != DBNull.Value &&
                                     !string.IsNullOrEmpty(valorServicio.ToString());

                    // ✅ Verificar si es un Paquete
                    object valorPaquete = Dgv_asignaciones.Rows[e.RowIndex].Cells["Paquete"].Value;
                    bool esPaquete = valorPaquete != null &&
                                    valorPaquete != DBNull.Value &&
                                    !string.IsNullOrEmpty(valorPaquete.ToString());

                    if (esServicio)
                    {
                        // ===== CARGAR SERVICIO =====
                        string nombreServicio = valorServicio.ToString();
                        bool servicioEncontrado = false;

                        foreach (var item in Cbo_servicios.Items)
                        {
                            ComboBoxItem comboItem = (ComboBoxItem)item;
                            if (comboItem.Display.Equals(nombreServicio, StringComparison.OrdinalIgnoreCase) ||
                                comboItem.Display.Contains(nombreServicio) ||
                                nombreServicio.Contains(comboItem.Display))
                            {
                                Cbo_servicios.SelectedItem = item;
                                valorSeleccionado = comboItem.Value;
                                servicioEncontrado = true;
                                break;
                            }
                        }

                        if (!servicioEncontrado)
                        {
                            Cbo_servicios.Text = nombreServicio;
                        }

                        // Deshabilitar paquete
                        Cbo_paquete.Enabled = false;
                        Nud_numSesion.Enabled = false;
                    }
                    else if (esPaquete)
                    {
                        // ===== CARGAR PAQUETE =====
                        string nombrePaquete = valorPaquete.ToString();
                        bool paqueteEncontrado = false;

                        foreach (var item in Cbo_paquete.Items)
                        {
                            ComboBoxItem comboItem = (ComboBoxItem)item;
                            if (comboItem.Display.Equals(nombrePaquete, StringComparison.OrdinalIgnoreCase) ||
                                comboItem.Display.Contains(nombrePaquete) ||
                                nombrePaquete.Contains(comboItem.Display))
                            {
                                Cbo_paquete.SelectedItem = item;
                                valorSeleccionado2 = comboItem.Value;
                                paqueteEncontrado = true;
                                break;
                            }
                        }

                        if (!paqueteEncontrado)
                        {
                            Cbo_paquete.Text = nombrePaquete;
                        }

                        // ✅ Cargar Número de Sesión
                        object valorNumeroSesion = Dgv_asignaciones.Rows[e.RowIndex].Cells["NumeroSesion"].Value;
                        if (valorNumeroSesion != null && valorNumeroSesion != DBNull.Value)
                        {
                            int numeroSesion = Convert.ToInt32(valorNumeroSesion);
                            Nud_numSesion.Value = numeroSesion;
                        }

                        // Deshabilitar servicio
                        Cbo_servicios.Enabled = false;
                    }

                    // ✅ Cargar Costo de Referencia
                    object valorCosto = Dgv_asignaciones.Rows[e.RowIndex].Cells["CostoReferencia"].Value;
                    if (valorCosto != null && valorCosto != DBNull.Value)
                    {
                        decimal costo = Convert.ToDecimal(valorCosto);
                        Txt_costo.Text = costo.ToString("F2");
                    }
                    else
                    {
                        Txt_costo.Text = "0.00";
                    }

                    // Habilitar botones
                    Btn_modificar.Enabled = true;
                    Btn_eliminar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar registro:\n{ex.Message}\n\nDetalles:\n{ex.StackTrace}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para editar");
                return;
            }
            //.Focus();
            Cbo_servicios.Enabled = true;
            Cbo_paquete.Enabled = true;
            Nud_numSesion.Enabled = true;
            Btn_guardar.Enabled = true;

            Cbo_servicios.SelectedIndex = -1;
            Cbo_paquete.SelectedIndex = -1;
            Nud_numSesion.ResetText();



        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            // Validar que hay un registro seleccionado
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para eliminar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener información del detalle seleccionado para el mensaje
                string tipoDetalle = "";
                string nombreDetalle = "";

                DataGridViewRow filaSeleccionada = Dgv_asignaciones.CurrentRow;
                if (filaSeleccionada != null)
                {
                    // Verificar si es servicio o paquete
                    object valorServicio = filaSeleccionada.Cells["Servicio"].Value;
                    object valorPaquete = filaSeleccionada.Cells["Paquete"].Value;

                    if (valorServicio != null && !string.IsNullOrEmpty(valorServicio.ToString()))
                    {
                        tipoDetalle = "servicio";
                        nombreDetalle = valorServicio.ToString();
                    }
                    else if (valorPaquete != null && !string.IsNullOrEmpty(valorPaquete.ToString()))
                    {
                        tipoDetalle = "paquete";
                        nombreDetalle = valorPaquete.ToString();

                        // Obtener número de sesión si está disponible
                        object valorSesion = filaSeleccionada.Cells["NumeroSesion"].Value;
                        if (valorSesion != null && valorSesion != DBNull.Value)
                        {
                            nombreDetalle += $" (Sesión {valorSesion})";
                        }
                    }
                    else
                    {
                        tipoDetalle = "detalle";
                        nombreDetalle = "desconocido";
                    }
                }

                // Construir mensaje de confirmación personalizado
                string mensaje = $"¿Está seguro de eliminar este {tipoDetalle}?\n\n";
                mensaje += $"📋 Detalle: {nombreDetalle}\n\n";
                mensaje += "Esta acción realizará lo siguiente:\n";

                if (tipoDetalle == "paquete")
                {
                    mensaje += "• Se reducirá el contador de sesiones del paquete\n";
                    mensaje += "• Si el paquete estaba finalizado, volverá a estado 'En uso'\n";
                    mensaje += "• Si era la única sesión, el paquete puede eliminarse\n";
                }

                mensaje += "• Se recalcularán los totales de la cita\n";
                mensaje += "• El registro será marcado como eliminado\n\n";
                mensaje += "⚠️ Esta acción no se puede deshacer fácilmente.";

                // Mostrar confirmación
                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "Confirmar eliminación de detalle",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2 // Por defecto en "No"
                );

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de eliminación lógica
                    bool exito = logica2.funcEliminarDetalle(idSeleccionado);

                    if (exito)
                    {
                        // Mensaje de éxito personalizado
                        string mensajeExito = $"✅ {tipoDetalle.ToUpper()} eliminado correctamente\n\n";
                        mensajeExito += $"Detalle: {nombreDetalle}\n\n";

                        if (tipoDetalle == "paquete")
                        {
                            mensajeExito += "Las sesiones del paquete han sido ajustadas automáticamente.";
                        }
                        else
                        {
                            mensajeExito += "Los totales de la cita han sido recalculados.";
                        }

                        MessageBox.Show(mensajeExito,
                            "Operación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Limpiar formulario y recargar datos
                        LimpiarFormulario();
                        CargarDatos();

                        // Opcional: Registrar en bitácora
                        // string accion = $"Eliminó {tipoDetalle}: {nombreDetalle}";
                        // logicaSeg.funinsertarabitacora(idUsuario, accion, "tbl_cita_servicio", "XXXX");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error al eliminar el detalle:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_ReporteDetalle reporte = new frm_ReporteDetalle();
            reporte.Show();
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
