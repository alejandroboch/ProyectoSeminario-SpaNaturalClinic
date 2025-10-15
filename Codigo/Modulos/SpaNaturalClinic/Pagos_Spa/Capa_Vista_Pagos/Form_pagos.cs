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
        private int idCitaActual = 0;
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
            llenarseCitas(tabla, campo1, campo2);
        }

        /*********************************Ismar Leonel Cortez Sanchez -0901-21-560*****************************************/
        /**************************************Combo box inteligente 1*****************************************************/

        public void llenarseCitas(string tabla, string campo1, string campo2)
        {
            var dt2 = logica2.enviar(tabla, campo1, campo2);
            Cbo_numCita.Items.Clear();

            foreach (DataRow row in dt2.Rows)
            {
                Cbo_numCita.Items.Add(new ComboBoxItem
                {
                    Value = row["pk_id_cita"].ToString(),
                    Display = row["nombre_cliente"].ToString()
                });
            }

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

            public override string ToString()
            {
                return $"{Value}-{Display}";
            }
        }

        private void Cbo_numCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_numCita.SelectedItem != null)
            {
                try
                {
                    var selectedItem = (ComboBoxItem)(Cbo_numCita.SelectedItem);
                    valorSeleccionado = selectedItem.Value;
                    int idCita = Convert.ToInt32(valorSeleccionado);
                    idCitaActual = idCita;
                    CargarDatosCitaDesdeId(idCita);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de la cita: " + ex.Message, "Error");
                }
            }
        }

        private void ConfigurarControles(bool habilitar)
        {
            Cbo_numCita.Enabled = habilitar;
            Cbo_tipoPago.Enabled = habilitar;
            Txt_montoAcancelar.Enabled = habilitar;

            Btn_guardar.Enabled = habilitar;
            Btn_editar.Enabled = habilitar;
            Btn_eliminar.Enabled = habilitar;
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;

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
            }

            Cbo_numCita.SelectedIndex = -1;
            Txt_cliente.Text = "";
            Dtp_fechaCita.Text = "";
            Txt_totalCita.Text = "";
            Txt_saldoPendiente.Text = "";
            Cbo_tipoPago.SelectedIndex = -1;
            Txt_montoAcancelar.Text = "";
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = logica2.funConsultarPagos();
                if (dt != null)
                {
                    Dgv_pagos.DataSource = dt;
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
            Cbo_tipoPago.Items.Clear();
            Cbo_tipoPago.Items.Add("Efectivo");
            Cbo_tipoPago.Items.Add("Transferencia");
            Cbo_tipoPago.Items.Add("POS");
            Cbo_tipoPago.SelectedIndex = 0;

            // ✅ NUEVO: Configurar eventos de validación
            Txt_montoAcancelar.KeyPress += Txt_montoAcancelar_KeyPress_SoloNumeros;
            Txt_montoAcancelar.TextChanged += Txt_montoAcancelar_TextChanged;

            // ✅ NUEVO: Tooltips informativos
            ConfigurarTooltips();
        }

        // ✅ NUEVO: Validación de entrada solo números
        private void Txt_montoAcancelar_KeyPress_SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return; // Permitir backspace, delete, etc.

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true; // Bloquear todo excepto números y punto decimal
        }

        // ✅ NUEVO: Validación en tiempo real del monto
        private void Txt_montoAcancelar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_montoAcancelar.Text))
                return;

            if (decimal.TryParse(Txt_montoAcancelar.Text, out decimal monto))
            {
                // Obtener datos de la cita actual
                if (idCitaActual > 0 && !string.IsNullOrWhiteSpace(Txt_totalCita.Text) && !string.IsNullOrWhiteSpace(Txt_saldoPendiente.Text))
                {
                    decimal totalCita = decimal.Parse(Txt_totalCita.Text);
                    decimal saldoPendiente = decimal.Parse(Txt_saldoPendiente.Text);

                    // Si ya hay sobrepago, calcular el monto máximo permitido
                    if (saldoPendiente < 0)
                    {
                        decimal montoMaximo = Math.Abs(saldoPendiente);

                        if (monto > montoMaximo)
                        {
                            MessageBox.Show(
                                $"⚠️ Monto excede el máximo permitido\n\n" +
                                $"• Saldo pendiente: Q{saldoPendiente:F2} (sobrepago)\n" +
                                $"• Monto máximo permitido: Q{montoMaximo:F2}\n" +
                                $"• Monto ingresado: Q{monto:F2}\n\n" +
                                $"El monto se ajustará al máximo permitido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            Txt_montoAcancelar.Text = montoMaximo.ToString("F2");
                            Txt_montoAcancelar.SelectAll();
                        }
                    }
                    else
                    {
                        // Validar que no exceda el saldo pendiente
                        if (monto > saldoPendiente)
                        {
                            MessageBox.Show(
                                $"⚠️ Monto excede el saldo pendiente\n\n" +
                                $"• Saldo pendiente: Q{saldoPendiente:F2}\n" +
                                $"• Monto ingresado: Q{monto:F2}\n\n" +
                                $"El monto se ajustará al saldo pendiente.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            Txt_montoAcancelar.Text = saldoPendiente.ToString("F2");
                            Txt_montoAcancelar.SelectAll();
                        }
                    }
                }
            }
        }

        // ✅ NUEVO: Configurar tooltips
        private void ConfigurarTooltips()
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(Txt_montoAcancelar,
                "💡 Ingrese el monto del pago.\n" +
                "Si hay sobrepago, el sistema ajustará automáticamente.\n" +
                "Solo se permiten números y punto decimal.");

            tooltip.SetToolTip(Txt_saldoPendiente,
                "💰 Saldo pendiente de la cita.\n" +
                "Valor negativo indica sobrepago.");

            tooltip.SetToolTip(Btn_guardar,
                "💾 Guardar o actualizar el pago.\n" +
                "El sistema validará automáticamente los montos.");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            ConfigurarControles(true);
            LimpiarFormulario();
            Btn_eliminar.Enabled = false;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            ConfigurarControles(false);
            CargarDatos();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================================
                // VALIDACIONES INICIALES
                // ============================================

                if (idCitaActual == 0)
                {
                    MessageBox.Show("Debe seleccionar una cita para registrar el pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cbo_tipoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un método de pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Txt_montoAcancelar.Text))
                {
                    MessageBox.Show("Debe ingresar el monto del pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                decimal montoPago = 0;
                if (!decimal.TryParse(Txt_montoAcancelar.Text, out montoPago))
                {
                    MessageBox.Show("El monto ingresado no es válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                if (montoPago <= 0)
                {
                    MessageBox.Show("El monto del pago debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_montoAcancelar.Focus();
                    return;
                }

                string metodoPago = Cbo_tipoPago.SelectedItem.ToString();

                // ============================================
                // MODO INSERCIÓN (idSeleccionado == 0)
                // ============================================
                if (idSeleccionado == 0)
                {
                    decimal saldoPendiente = 0;
                    if (decimal.TryParse(Txt_saldoPendiente.Text, out saldoPendiente))
                    {
                        if (saldoPendiente > 0 && montoPago > saldoPendiente)
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

                    decimal nuevoSaldo = saldoPendiente - montoPago;
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
                    else if (nuevoSaldo < 0)
                    {
                        mensaje += $"\n\n⚠ Esta cita tendrá un SOBREPAGO de Q{Math.Abs(nuevoSaldo):F2}";
                    }

                    DialogResult resultado = MessageBox.Show(
                        mensaje,
                        "Confirmar pago",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        logica2.RegistrarPago(idCitaActual, montoPago, metodoPago);

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
                        else if (nuevoSaldo < 0)
                        {
                            MessageBox.Show(
                                $"✓ Pago registrado exitosamente\n\n" +
                                $"Monto pagado: Q{montoPago:F2}\n" +
                                $"Sobrepago: Q{Math.Abs(nuevoSaldo):F2}\n" +
                                $"El cliente tiene crédito para futuras citas.",
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

                    // ✅ MEJORADO: Calcular diferencia y nuevo saldo correctamente
                    decimal diferenciaMonto = montoPago - montoAnterior;
                    decimal saldoPendienteActual = decimal.Parse(Txt_saldoPendiente.Text);
                    decimal nuevoSaldoEstimado = saldoPendienteActual - diferenciaMonto;

                    // ✅ NUEVA VALIDACIÓN: Prevenir sobrepago excesivo
                    if (nuevoSaldoEstimado < 0)
                    {
                        decimal sobrepagoMaximo = Math.Abs(saldoPendienteActual);
                        decimal montoMaximoPermitido = montoAnterior + sobrepagoMaximo;

                        DialogResult ajustarMonto = MessageBox.Show(
                            $"❌ No se puede modificar el pago\n\n" +
                            $"• Saldo pendiente actual: Q{saldoPendienteActual:F2}\n" +
                            $"• Monto anterior: Q{montoAnterior:F2}\n" +
                            $"• Monto ingresado: Q{montoPago:F2}\n" +
                            $"• Diferencia: Q{diferenciaMonto:F2}\n" +
                            $"• Saldo resultante: Q{nuevoSaldoEstimado:F2}\n\n" +
                            $"✅ SOLUCIÓN:\n" +
                            $"• Monto máximo permitido: Q{montoMaximoPermitido:F2}\n" +
                            $"• Esto dejaría el saldo en Q0.00 (sin sobrepago)\n\n" +
                            $"¿Desea ajustar el monto automáticamente?",
                            "Sobrepago detectado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (ajustarMonto == DialogResult.Yes)
                        {
                            Txt_montoAcancelar.Text = montoMaximoPermitido.ToString("F2");
                            Txt_montoAcancelar.SelectAll();
                        }

                        return; // No continuar con el guardado
                    }

                    // ✅ MEJORADO: Mensaje más claro
                    string mensajeModificar = $"¿Confirmar la modificación del pago?\n\n" +
                                             $"═══════════════════════════════════\n" +
                                             $"📋 PAGO A MODIFICAR\n" +
                                             $"═══════════════════════════════════\n" +
                                             $"• ID Pago: {idSeleccionado}\n" +
                                             $"• Cita: #{idCitaActual}\n" +
                                             $"• Cliente: {Txt_cliente.Text}\n\n" +

                                             $"═══════════════════════════════════\n" +
                                             $"💰 CAMBIOS EN EL MONTO\n" +
                                             $"═══════════════════════════════════\n" +
                                             $"• Monto ACTUAL: Q{montoAnterior:F2}\n" +
                                             $"• Monto NUEVO: Q{montoPago:F2}\n" +
                                             $"• Diferencia: Q{diferenciaMonto:F2}\n\n" +

                                             $"═══════════════════════════════════\n" +
                                             $"📊 IMPACTO EN EL SALDO\n" +
                                             $"═══════════════════════════════════\n" +
                                             $"• Saldo pendiente ACTUAL: Q{saldoPendienteActual:F2}\n" +
                                             $"• Ajuste al saldo: -Q{diferenciaMonto:F2}\n" +
                                             $"• Saldo pendiente NUEVO: Q{nuevoSaldoEstimado:F2}\n\n";

                    // ✅ Añadir explicación según el caso
                    if (diferenciaMonto > 0)
                    {
                        mensajeModificar += $"✅ Se pagará Q{diferenciaMonto:F2} ADICIONALES\n";
                        mensajeModificar += $"   (El cliente pagará más)\n\n";
                    }
                    else if (diferenciaMonto < 0)
                    {
                        mensajeModificar += $"⚠️ Se reducirá el pago en Q{Math.Abs(diferenciaMonto):F2}\n";
                        mensajeModificar += $"   (El cliente pagará menos)\n\n";
                    }
                    else
                    {
                        mensajeModificar += $"ℹ️ El monto no cambia\n\n";
                    }

                    if (nuevoSaldoEstimado == 0)
                    {
                        mensajeModificar += $"🎉 ¡La cita quedará COMPLETAMENTE PAGADA!\n";
                    }

                    mensajeModificar += "\n¿Desea continuar con esta modificación?";

                    DialogResult resultadoModificar = MessageBox.Show(
                        mensajeModificar,
                        "Confirmar modificación de pago",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultadoModificar == DialogResult.Yes)
                    {
                        logica2.ActualizarPago(idSeleccionado, idCitaActual, montoPago, metodoPago);

                        MessageBox.Show(
                            $"✅ Pago actualizado exitosamente\n\n" +
                            $"• Monto anterior: Q{montoAnterior:F2}\n" +
                            $"• Monto nuevo: Q{montoPago:F2}\n" +
                            $"• Diferencia aplicada: Q{diferenciaMonto:F2}\n" +
                            $"• Nuevo saldo: Q{nuevoSaldoEstimado:F2}",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }

                CargarDatos();
                LimpiarFormulario();
                ConfigurarControles(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosCitaDesdeId(int idCita)
        {
            try
            {
                DataRow datosCita = logica2.ObtenerDatosCita(idCita);

                if (datosCita != null)
                {
                    if (Txt_cliente != null)
                    {
                        Txt_cliente.Text = datosCita["NombreCliente"].ToString();
                    }

                    if (Dtp_fechaCita != null && datosCita["FechaCita"] != DBNull.Value)
                    {
                        Dtp_fechaCita.Value = Convert.ToDateTime(datosCita["FechaCita"]);
                    }

                    if (Txt_totalCita != null)
                    {
                        Txt_totalCita.Text = datosCita["Total"].ToString();
                    }

                    if (Txt_saldoPendiente != null)
                    {
                        Txt_saldoPendiente.Text = datosCita["SaldoPendiente"].ToString();
                    }

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
                    idSeleccionado = Convert.ToInt32(Dgv_pagos.Rows[e.RowIndex].Cells["ID_Pago"].Value);

                    if (Dgv_pagos.Rows[e.RowIndex].Cells["NumeroCita"].Value != null)
                    {
                        idCitaActual = Convert.ToInt32(Dgv_pagos.Rows[e.RowIndex].Cells["NumeroCita"].Value);
                        CargarDatosCitaDesdeId(idCitaActual);
                    }

                    if (Dgv_pagos.Rows[e.RowIndex].Cells["Monto"].Value != null)
                    {
                        Txt_montoAcancelar.Text = Dgv_pagos.Rows[e.RowIndex].Cells["Monto"].Value.ToString();
                    }

                    if (Dgv_pagos.Rows[e.RowIndex].Cells["MetodoPago"].Value != null &&
                        Cbo_tipoPago != null)
                    {
                        string metodoPago = Dgv_pagos.Rows[e.RowIndex].Cells["MetodoPago"].Value.ToString();

                        int index = Cbo_tipoPago.FindStringExact(metodoPago);
                        if (index >= 0)
                        {
                            Cbo_tipoPago.SelectedIndex = index;
                        }
                        else
                        {
                            Cbo_tipoPago.Text = metodoPago;
                        }
                    }

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

            Cbo_tipoPago.Enabled = true;
            Txt_montoAcancelar.Enabled = true;
            Btn_guardar.Enabled = true;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
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
                decimal montoPago = 0;
                string metodoPago = "";
                string fechaPago = "";
                string cliente = "";
                int numeroCita = 0;

                DataGridViewRow filaSeleccionada = Dgv_pagos.CurrentRow;
                if (filaSeleccionada != null)
                {
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

                decimal saldoActual = 0;
                if (!string.IsNullOrEmpty(Txt_saldoPendiente.Text))
                {
                    decimal.TryParse(Txt_saldoPendiente.Text, out saldoActual);
                }

                decimal nuevoSaldoEstimado = saldoActual + montoPago;

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

                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "⚠️ Confirmar eliminación de pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (resultado == DialogResult.Yes)
                {
                    if (saldoActual == 0 || montoPago >= 500)
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
                            return;
                        }
                    }

                    bool exito = logica2.EliminarPago(idSeleccionado);

                    if (exito)
                    {
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

                        LimpiarFormulario();
                        CargarDatos();
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