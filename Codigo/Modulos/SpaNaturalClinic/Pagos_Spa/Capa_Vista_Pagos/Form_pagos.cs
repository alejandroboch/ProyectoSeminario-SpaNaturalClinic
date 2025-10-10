using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Pagos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Capa_Vista_Pagos
{
    public partial class Form_pagos : Form
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

        public Form_pagos()
        {
            InitializeComponent();

            logica2 = new Controlador();
            CargarDatos();
            ConfigurarControles(false);

            string tabla = "tbl_citas";
            string campo1 = "pk_id_cita";
            string campo2 = "fk_id_cliente";
            // Llama al método para llenar el ComboBox
            llenarseCitas(tabla, campo1, campo2);
        }

        /*********************************Ismar Leonel Cortez Sanchez -0901-21-560*****************************************/
        /**************************************Combo box inteligente 1*****************************************************/

        public void llenarseCitas(string tabla, string campo1, string campo2)
        {
            // Obtén los datos para el ComboBox
            var dt2 = logica2.enviar(tabla, campo1, campo2);

            // Limpia el ComboBox antes de llenarlo
            Cbo_numCita.Items.Clear();

            foreach (DataRow row in dt2.Rows)
            {
                Cbo_numCita.Items.Add(new ComboBoxItem
                {
                    Value = row["pk_id_cita"].ToString(),
                    Display = row["nombre_cliente"].ToString()
                });
            }

            // AutoComplete (opcional)
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add($"{row["pk_id_cita"]}-{row["nombre_cliente"]}");
                coleccion.Add($"{row["nombre_cliente"]}-{row["pk_id_cita"]}");
            }

            Cbo_numCita.AutoCompleteCustomSource = coleccion;
            Cbo_numCita.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_numCita.AutoCompleteSource = AutoCompleteSource.CustomSource;
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



        private void Cbo_numCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Cbo_numCita.SelectedItem != null)
            //{
            //    try
            //    {
            //        // Obtener el valor del ValueMember seleccionado
            //        var selectedItem = (ComboBoxItem)(Cbo_numCita.SelectedItem);
            //        valorSeleccionado = selectedItem.Value;

            //        // Convertir a int para consultar
            //        int idCita = Convert.ToInt32(valorSeleccionado);

            //        // Obtener los datos de la cita
            //        DataRow datosCita = logica2.ObtenerDatosCita(idCita);

            //        if (datosCita != null)
            //        {
            //            // Cargar los datos en los controles del formulario

            //            // Cliente (asumiendo que tienes un ComboBox de clientes)
            //            if (Txt_cliente != null)
            //            {
            //                //Cbo_nombreCliente.SelectedValue = datosCita["IdCliente"].ToString();
            //                // O si prefieres buscar por texto:
            //                Txt_cliente.Text = datosCita["NombreCliente"].ToString();
            //            }

            //            // Fecha de la cita
            //            if (Dtp_fechaCita != null && datosCita["FechaCita"] != DBNull.Value)
            //            {
            //                Dtp_fechaCita.Value = Convert.ToDateTime(datosCita["FechaCita"]);
            //            }

            //            //// Estado de la cita
            //            //if (Cbo_estadoCita != null)
            //            //{
            //            //    Cbo_estadoCita.Text = datosCita["EstadoCita"].ToString();
            //            //}

            //            // Total de la cita
            //            if (Txt_totalCita != null)
            //            {
            //                Txt_totalCita.Text = datosCita["Total"].ToString();
            //            }

            //            // Saldo pendiente
            //            if (Txt_saldoPendiente != null)
            //            {
            //                Txt_saldoPendiente.Text = datosCita["SaldoPendiente"].ToString();
            //            }

            //            // Opcional: Mostrar mensaje de confirmación (puedes comentar esto)
            //            // MessageBox.Show($"Datos cargados para la cita #{idCita}", "Información");
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se encontraron datos para esta cita o fue eliminada", "Advertencia");
            //            LimpiarFormulario(); // Método para limpiar los campos
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error al cargar datos de la cita: " + ex.Message, "Error");
            //    }
            //}
            if (Cbo_numCita.SelectedItem != null)
            {
                try
                {
                    // Obtener el valor del ValueMember seleccionado
                    var selectedItem = (ComboBoxItem)(Cbo_numCita.SelectedItem);
                    valorSeleccionado = selectedItem.Value;

                    // Convertir a int para consultar
                    int idCita = Convert.ToInt32(valorSeleccionado);

                    // Actualizar variable global
                    idCitaActual = idCita;

                    //// Actualizar label si existe
                    //if (Lbl_NumeroDeCita != null)
                    //{
                    //    Lbl_NumeroDeCita.Text = idCita.ToString();
                    //}

                    // ✅ CARGAR DATOS USANDO EL MÉTODO REUTILIZABLE
                    CargarDatosCitaDesdeId(idCita);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de la cita: " + ex.Message, "Error");
                }
            }

        }

        /***************************************************************************************************/

        private void ConfigurarControles(bool habilitar)
        {
            // Habilitar o deshabilitar los controles de texto
            Cbo_numCita.Enabled = habilitar;
            Cbo_tipoPago.Enabled = habilitar;
            Txt_montoAcancelar.Enabled = habilitar;
            


            // Habilitar o deshabilitar los botones


            Btn_guardar.Enabled = habilitar;
            Btn_editar.Enabled = habilitar;
            Btn_eliminar.Enabled = habilitar;
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            // Buscar el último ID en el DataGridView y sumarle 1
            if (Dgv_pagos.Rows.Count > 0)
            {
                int maxId = 0;
                foreach (DataGridViewRow row in Dgv_pagos.Rows)
                {
                    if (row.Cells["ID_Pago"].Value != null)
                    {
                        int currentId = Convert.ToInt32(row.Cells["ID_Pago"].Value);
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


            Cbo_numCita.SelectedIndex = -1;
            Txt_cliente.Text = "";
            Dtp_fechaCita.Text = "";

            Txt_totalCita.Text = "";
            Txt_saldoPendiente.Text = "";

            Cbo_tipoPago.SelectedIndex = -1;
            Txt_montoAcancelar.Text = "";
            //Cbo_servicios.SelectedIndex = -1;
            //Cbo_paquete.SelectedIndex = -1;

            //ActualizarBotonExcepcion();
            //ActualizarBotonEstado();
        }


        private void CargarDatos()
        {
            try
            {
                DataTable dt = logica2.funConsultarPagos();
                if (dt != null)
                {
                    Dgv_pagos.DataSource = dt;

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



        private void Form_pagos_Load(object sender, EventArgs e)
        {
            // Limpia el ComboBox (por si tiene datos anteriores)
            Cbo_tipoPago.Items.Clear();

            // Agrega los elementos
            Cbo_tipoPago.Items.Add("Efectivo");
            Cbo_tipoPago.Items.Add("Transferencia");
            Cbo_tipoPago.Items.Add("POS");

            // (Opcional) Selecciona un valor por defecto
            Cbo_tipoPago.SelectedIndex = 0; // selecciona "Efectivo"
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
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

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================================
                // VALIDACIONES INICIALES
                // ============================================

                // Validar que se haya seleccionado una cita
                if (idCitaActual == 0)
                {
                    MessageBox.Show("Debe seleccionar una cita para registrar el pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya un método de pago seleccionado
                if (Cbo_tipoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un método de pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya ingresado un monto
                if (string.IsNullOrWhiteSpace(Txt_montoAcancelar.Text))
                {
                    MessageBox.Show("Debe ingresar el monto del pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                // Validar que el monto sea un número válido
                decimal montoPago = 0;
                if (!decimal.TryParse(Txt_montoAcancelar.Text, out montoPago))
                {
                    MessageBox.Show("El monto ingresado no es válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                // Validar que el monto sea mayor a 0
                if (montoPago <= 0)
                {
                    MessageBox.Show("El monto del pago debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                // Obtener método de pago
                string metodoPago = Cbo_tipoPago.SelectedItem.ToString();

                // ============================================
                // MODO INSERCIÓN (idSeleccionado == 0)
                // ============================================
                if (idSeleccionado == 0)
                {
                    // Validar que el monto no exceda el saldo pendiente (solo para nuevo pago)
                    decimal saldoPendiente = 0;
                    if (decimal.TryParse(Txt_saldoPendiente.Text, out saldoPendiente))
                    {
                        if (montoPago > saldoPendiente)
                        {
                            MessageBox.Show(
                                $"El monto del pago (Q{montoPago:F2}) excede el saldo pendiente (Q{saldoPendiente:F2})\n\n" +
                                "No puede pagar más del saldo pendiente.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            Txt_montoAcancelar.Focus();
                            return;
                        }
                    }

                    // Calcular nuevo saldo
                    decimal nuevoSaldo = saldoPendiente - montoPago;

                    // Mensaje de confirmación
                    string mensaje = $"¿Confirmar el registro del pago?\n\n" +
                                    $"Cita #: {idCitaActual}\n" +
                                    $"Cliente: {Txt_cliente.Text}\n" +
                                    $"Total de la cita: Q{Txt_totalCita.Text}\n" +
                                    $"Saldo actual: Q{saldoPendiente:F2}\n" +
                                    $"Monto a pagar: Q{montoPago:F2}\n" +
                                    $"Nuevo saldo: Q{nuevoSaldo:F2}\n" +
                                    $"Método de pago: {metodoPago}";

                    if (nuevoSaldo == 0)
                    {
                        mensaje += "\n\n✓ Esta cita quedará COMPLETAMENTE PAGADA";
                    }

                    DialogResult resultado = MessageBox.Show(
                        mensaje,
                        "Confirmar pago",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        // REGISTRAR EL PAGO
                        logica2.RegistrarPago(idCitaActual, montoPago, metodoPago);

                        // Mensaje de éxito
                        if (nuevoSaldo == 0)
                        {
                            MessageBox.Show(
                                $"✓ Pago registrado exitosamente\n\n" +
                                $"Monto pagado: Q{montoPago:F2}\n" +
                                $"La cita ha sido completamente pagada.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                $"✓ Pago registrado exitosamente\n\n" +
                                $"Monto pagado: Q{montoPago:F2}\n" +
                                $"Saldo restante: Q{nuevoSaldo:F2}",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                }
                // ============================================
                // MODO ACTUALIZACIÓN (idSeleccionado > 0)
                // ============================================
                else
                {
                    // Obtener datos actuales del pago desde el DataGridView
                    decimal montoAnterior = 0;
                    string metodoPagoAnterior = "";

                    // Buscar el registro en el DataGridView para obtener el monto anterior
                    foreach (DataGridViewRow row in Dgv_pagos.Rows)
                    {
                        if (row.Cells["ID_Pago"].Value != null &&
                            Convert.ToInt32(row.Cells["ID_Pago"].Value) == idSeleccionado)
                        {
                            montoAnterior = Convert.ToDecimal(row.Cells["Monto"].Value);
                            metodoPagoAnterior = row.Cells["MetodoPago"].Value.ToString();
                            break;
                        }
                    }

                    // Calcular diferencia y nuevo saldo estimado
                    decimal diferenciaMonto = montoPago - montoAnterior;
                    decimal saldoPendienteActual = decimal.Parse(Txt_saldoPendiente.Text);
                    decimal nuevoSaldoEstimado = saldoPendienteActual - diferenciaMonto;

                    // Construir mensaje de confirmación
                    string mensajeModificar = $"¿Confirmar la modificación del pago?\n\n" +
                                             $"═══ DATOS ANTERIORES ═══\n" +
                                             $"Monto: Q{montoAnterior:F2}\n" +
                                             $"Método de pago: {metodoPagoAnterior}\n\n" +
                                             $"═══ DATOS NUEVOS ═══\n" +
                                             $"Monto: Q{montoPago:F2}\n" +
                                             $"Método de pago: {metodoPago}\n\n" +
                                             $"═══ IMPACTO EN LA CITA ═══\n" +
                                             $"Cita #: {idCitaActual}\n" +
                                             $"Cliente: {Txt_cliente.Text}\n" +
                                             $"Saldo actual: Q{saldoPendienteActual:F2}\n" +
                                             $"Diferencia: Q{diferenciaMonto:F2}\n" +
                                             $"Nuevo saldo estimado: Q{nuevoSaldoEstimado:F2}";

                    if (diferenciaMonto > 0)
                    {
                        mensajeModificar += "\n\n⚠ El monto aumentó, se pagará MÁS";
                    }
                    else if (diferenciaMonto < 0)
                    {
                        mensajeModificar += "\n\n⚠ El monto disminuyó, se pagará MENOS";
                    }

                    if (nuevoSaldoEstimado == 0)
                    {
                        mensajeModificar += "\n✓ La cita quedará COMPLETAMENTE PAGADA";
                    }

                    DialogResult resultadoModificar = MessageBox.Show(
                        mensajeModificar,
                        "Confirmar modificación de pago",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultadoModificar == DialogResult.Yes)
                    {
                        // ACTUALIZAR EL PAGO
                        logica2.ActualizarPago(idSeleccionado, idCitaActual, montoPago, metodoPago);

                        MessageBox.Show(
                            $"✓ Pago actualizado exitosamente\n\n" +
                            $"Nuevo monto: Q{montoPago:F2}\n" +
                            $"Nuevo saldo de la cita: Q{nuevoSaldoEstimado:F2}",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }

                // Limpiar y recargar
                CargarDatos();
                LimpiarFormulario();
                ConfigurarControles(false);

                // Opcional: registrar en bitácora
                // logicaSeg.funinsertarabitacora(idUsuario, $"Modificó/Registró pago", "tbl_pagos", "12001");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Carga los datos de una cita en los controles del formulario
        /// Se puede usar desde ComboBox, DataGridView, o cualquier otra fuente
        /// </summary>
        /// <summary>
        /// Carga los datos de una cita en los controles del formulario
        /// </summary>
        private void CargarDatosCitaDesdeId(int idCita)
        {
            try
            {
                // Obtener los datos de la cita
                DataRow datosCita = logica2.ObtenerDatosCita(idCita);

                if (datosCita != null)
                {
                    // ✅ Cliente (TextBox)
                    if (Txt_cliente != null)
                    {
                        Txt_cliente.Text = datosCita["NombreCliente"].ToString();
                    }

                    // ✅ Fecha de la cita (DateTimePicker)
                    if (Dtp_fechaCita != null && datosCita["FechaCita"] != DBNull.Value)
                    {
                        Dtp_fechaCita.Value = Convert.ToDateTime(datosCita["FechaCita"]);
                    }

                    // ✅ Total de la cita (TextBox)
                    if (Txt_totalCita != null)
                    {
                        Txt_totalCita.Text = datosCita["Total"].ToString();
                    }

                    // ✅ Saldo pendiente (TextBox)
                    if (Txt_saldoPendiente != null)
                    {
                        Txt_saldoPendiente.Text = datosCita["SaldoPendiente"].ToString();
                    }

                    // Opcional: Sincronizar el ComboBox de citas
                    if (Cbo_numCita != null)
                    {
                        for (int i = 0; i < Cbo_numCita.Items.Count; i++)
                        {
                            var item = (ComboBoxItem)Cbo_numCita.Items[i];
                            if (item.Value == idCita.ToString())
                            {
                                Cbo_numCita.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para esta cita o fue eliminada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Dgv_pagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // ✅ Obtener ID del pago seleccionado
                    idSeleccionado = Convert.ToInt32(Dgv_pagos.Rows[e.RowIndex].Cells["ID_Pago"].Value);

                    // ✅ IMPORTANTE: Obtener el ID de la cita (la columna se llama "NumeroCita" según tu SQL)
                    if (Dgv_pagos.Rows[e.RowIndex].Cells["NumeroCita"].Value != null)
                    {
                        idCitaActual = Convert.ToInt32(Dgv_pagos.Rows[e.RowIndex].Cells["NumeroCita"].Value);

                        // ✅ CARGAR DATOS DE LA CITA AUTOMÁTICAMENTE
                        CargarDatosCitaDesdeId(idCitaActual);
                    }

                    // ✅ Cargar datos específicos del pago seleccionado

                    // Monto del pago
                    if (Dgv_pagos.Rows[e.RowIndex].Cells["Monto"].Value != null)
                    {
                        Txt_montoAcancelar.Text = Dgv_pagos.Rows[e.RowIndex].Cells["Monto"].Value.ToString();
                    }

                    // Método de pago
                    if (Dgv_pagos.Rows[e.RowIndex].Cells["MetodoPago"].Value != null &&
                        Cbo_tipoPago != null)
                    {
                        string metodoPago = Dgv_pagos.Rows[e.RowIndex].Cells["MetodoPago"].Value.ToString();

                        // Buscar y seleccionar el método de pago en el ComboBox
                        int index = Cbo_tipoPago.FindStringExact(metodoPago);
                        if (index >= 0)
                        {
                            Cbo_tipoPago.SelectedIndex = index;
                        }
                        else
                        {
                            Cbo_tipoPago.Text = metodoPago; // Si no lo encuentra, lo asigna como texto
                        }
                    }

                    // Habilitar botones de edición/eliminación
                    Btn_editar.Enabled = true;
                    Btn_eliminar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para editar");
                return;
            }
            //.Focus();
            Cbo_tipoPago.Enabled = true;
            Txt_montoAcancelar.Enabled = true;
           
            Btn_guardar.Enabled = true;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            // Validar que hay un registro seleccionado
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un pago para eliminar",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener información del pago seleccionado para el mensaje
                decimal montoPago = 0;
                string metodoPago = "";
                string fechaPago = "";
                string cliente = "";
                int numeroCita = 0;

                DataGridViewRow filaSeleccionada = Dgv_pagos.CurrentRow;
                if (filaSeleccionada != null)
                {
                    // Obtener datos del pago
                    object valorMonto = filaSeleccionada.Cells["Monto"].Value;
                    object valorMetodo = filaSeleccionada.Cells["MetodoPago"].Value;
                    object valorFecha = filaSeleccionada.Cells["FechaPago"].Value;
                    object valorCliente = filaSeleccionada.Cells["Cliente"].Value;
                    object valorCita = filaSeleccionada.Cells["NumeroCita"].Value;

                    if (valorMonto != null && valorMonto != DBNull.Value)
                        montoPago = Convert.ToDecimal(valorMonto);

                    if (valorMetodo != null && valorMetodo != DBNull.Value)
                        metodoPago = valorMetodo.ToString();

                    if (valorFecha != null && valorFecha != DBNull.Value)
                        fechaPago = Convert.ToDateTime(valorFecha).ToString("dd/MM/yyyy");

                    if (valorCliente != null && valorCliente != DBNull.Value)
                        cliente = valorCliente.ToString();

                    if (valorCita != null && valorCita != DBNull.Value)
                        numeroCita = Convert.ToInt32(valorCita);
                }

                // Obtener el saldo actual de la cita
                decimal saldoActual = 0;
                if (!string.IsNullOrEmpty(Txt_saldoPendiente.Text))
                {
                    decimal.TryParse(Txt_saldoPendiente.Text, out saldoActual);
                }

                // Calcular el nuevo saldo después de eliminar el pago
                decimal nuevoSaldoEstimado = saldoActual + montoPago;

                // Construir mensaje de confirmación detallado
                string mensaje = "¿Está seguro de ELIMINAR este pago?\n\n";
                mensaje += "═══════════════════════════════════\n";
                mensaje += "📋 INFORMACIÓN DEL PAGO\n";
                mensaje += "═══════════════════════════════════\n";
                mensaje += $"• Cita #: {numeroCita}\n";
                mensaje += $"• Cliente: {cliente}\n";
                mensaje += $"• Monto pagado: Q{montoPago:F2}\n";
                mensaje += $"• Método de pago: {metodoPago}\n";
                mensaje += $"• Fecha de pago: {fechaPago}\n\n";

                mensaje += "═══════════════════════════════════\n";
                mensaje += "⚠️ IMPACTO EN LA CITA\n";
                mensaje += "═══════════════════════════════════\n";
                mensaje += $"• Saldo pendiente actual: Q{saldoActual:F2}\n";
                mensaje += $"• Monto a revertir: +Q{montoPago:F2}\n";
                mensaje += $"• Nuevo saldo pendiente: Q{nuevoSaldoEstimado:F2}\n\n";

                // Advertencias específicas según el caso
                if (saldoActual == 0)
                {
                    mensaje += "⚠️ ADVERTENCIA IMPORTANTE:\n";
                    mensaje += "• La cita está completamente pagada\n";
                    mensaje += "• Al eliminar este pago, volverá a tener saldo pendiente\n";
                    mensaje += "• El estado cambiará de 'Completado' a 'Pendiente'\n\n";
                }

                mensaje += "═══════════════════════════════════\n";
                mensaje += "Esta acción realizará lo siguiente:\n";
                mensaje += "═══════════════════════════════════\n";
                mensaje += "• El pago será marcado como ELIMINADO\n";
                mensaje += "• El saldo pendiente de la cita AUMENTARÁ\n";
                mensaje += "• Los totales serán recalculados automáticamente\n";
                if (saldoActual == 0)
                {
                    mensaje += "• El estado de la cita cambiará a 'Pendiente'\n";
                }
                mensaje += "\n❌ Esta operación no se puede deshacer fácilmente.";

                // Mostrar confirmación
                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "⚠️ Confirmar eliminación de pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2 // Por defecto en "No"
                );

                if (resultado == DialogResult.Yes)
                {
                    // Segunda confirmación para operaciones críticas
                    if (saldoActual == 0 || montoPago >= 500) // Si la cita está pagada o es un monto grande
                    {
                        DialogResult segundaConfirmacion = MessageBox.Show(
                            "Esta es una operación crítica.\n\n" +
                            "¿Está COMPLETAMENTE SEGURO de eliminar este pago?",
                            "⚠️ Confirmación final",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2
                        );

                        if (segundaConfirmacion != DialogResult.Yes)
                        {
                            return; // Cancelar operación
                        }
                    }

                    // Llamar al método de eliminación lógica
                    bool exito = logica2.EliminarPago(idSeleccionado);

                    if (exito)
                    {
                        // Mensaje de éxito detallado
                        string mensajeExito = "✅ PAGO ELIMINADO CORRECTAMENTE\n\n";
                        mensajeExito += "═══════════════════════════════════\n";
                        mensajeExito += $"• Monto revertido: Q{montoPago:F2}\n";
                        mensajeExito += $"• Método de pago: {metodoPago}\n";
                        mensajeExito += $"• Nuevo saldo de la cita: Q{nuevoSaldoEstimado:F2}\n\n";

                        if (saldoActual == 0)
                        {
                            mensajeExito += "ℹ️ La cita ha vuelto a estado 'Pendiente'\n";
                            mensajeExito += "El cliente deberá realizar el pago nuevamente.";
                        }
                        else
                        {
                            mensajeExito += "ℹ️ El saldo pendiente ha sido actualizado\n";
                            mensajeExito += "correctamente en la cita.";
                        }

                        MessageBox.Show(mensajeExito,
                            "Operación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Limpiar formulario y recargar datos
                        LimpiarFormulario();
                        CargarDatos();

                        // Opcional: Registrar en bitácora
                        // string accion = $"Eliminó pago de Q{montoPago:F2} (Método: {metodoPago}) de la cita #{numeroCita}";
                        // logicaSeg.funinsertarabitacora(idUsuario, accion, "tbl_pagos", "XXXX");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error al eliminar el pago:\n\n{ex.Message}\n\n" +
                    "Por favor, verifique que:\n" +
                    "• El pago no haya sido eliminado previamente\n" +
                    "• La cita asociada esté activa\n" +
                    "• No existan problemas de integridad en los datos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Reporte reporte = new frm_Reporte();
            reporte.Show();
        }
    }
}
