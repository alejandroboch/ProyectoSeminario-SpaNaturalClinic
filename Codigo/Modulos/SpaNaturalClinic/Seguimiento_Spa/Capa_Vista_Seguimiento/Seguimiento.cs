using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using Capa_Controlador_Seguimiento;
using Capa_Modelo_Seguimiento;
using System.Data.Odbc;

namespace Capa_Vista_Seguimiento
{
    public partial class SeguimientoForm : Form
    {
        private readonly Controlador cn = new Controlador();
        private readonly ToolTip tt = new ToolTip();

        public SeguimientoForm()
        {
            InitializeComponent();
        }

        private void SeguimientoForm_Load(object sender, EventArgs e)
        {
            fun_actualizar_tabla();
            fun_cargar_combos();
            fun_limpiar_y_desactivar();
            fun_configurar_tooltips();
        }

        // --- MÉTODOS PRINCIPALES ---

        private void fun_actualizar_tabla()
        {
            Dgv_Seguimiento.DataSource = cn.fun_obtener_lista_seguimientos();
            fun_formatear_dgv();
        }

        private void fun_cargar_combos()
        {
            Cmb_Cliente.DataSource = cn.fun_obtener_clientes();
            Cmb_Cliente.DisplayMember = "nombre";
            Cmb_Cliente.ValueMember = "pk_id_cliente";
        }

        private void fun_limpiar_y_desactivar()
        {
            Txt_Id.Clear();
            Txt_Buscar.Clear();
            Cmb_Cliente.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Now;
            Txt_Servicio.Clear();
            Txt_Monto.Clear();
            Txt_Obs.Clear();
            Dgv_Seguimiento.ClearSelection();

            Cmb_Cliente.Enabled = false;
            Dtp_Fecha.Enabled = false;
            Txt_Servicio.Enabled = false;
            Txt_Monto.Enabled = false;
            Txt_Obs.Enabled = false;

            Btn_Guardar.Enabled = false;
            Btn_Actualizar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Nuevo.Enabled = true;
        }

        private void fun_activar_para_edicion()
        {
            Cmb_Cliente.Enabled = true;
            Dtp_Fecha.Enabled = true;
            Txt_Servicio.Enabled = true;
            Txt_Monto.Enabled = true;
            Txt_Obs.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Nuevo.Enabled = false;
        }

        // --- MÉTODOS DE MEJORA ---

        private void fun_formatear_dgv()
        {
            Dgv_Seguimiento.Columns["pk_id_seguimiento"].Visible = false;
            Dgv_Seguimiento.Columns["pk_id_cliente"].Visible = false;
            Dgv_Seguimiento.Columns["Cliente"].HeaderText = "Cliente";
            Dgv_Seguimiento.Columns["fecha"].HeaderText = "Fecha de Visita";
            Dgv_Seguimiento.Columns["servicio"].HeaderText = "Servicio Realizado";
            Dgv_Seguimiento.Columns["monto"].HeaderText = "Monto Pagado";
            Dgv_Seguimiento.Columns["observaciones"].HeaderText = "Notas";
            Dgv_Seguimiento.Columns["es_vip"].HeaderText = "Es VIP";
            Dgv_Seguimiento.Columns["monto"].DefaultCellStyle.Format = "c";
            Dgv_Seguimiento.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_Seguimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fun_configurar_tooltips()
        {
            tt.SetToolTip(Btn_Nuevo, "Habilita el formulario para ingresar un nuevo seguimiento.");
            tt.SetToolTip(Btn_Guardar, "Guarda el nuevo registro en la base de datos.");
            tt.SetToolTip(Btn_Actualizar, "Guarda los cambios hechos al registro seleccionado.");
            tt.SetToolTip(Btn_Eliminar, "Elimina permanentemente el registro seleccionado.");
            tt.SetToolTip(Btn_Cancelar, "Descarta los cambios, limpia el formulario y quita los filtros de búsqueda.");
            tt.SetToolTip(Txt_Buscar, "Escriba el nombre de un cliente para filtrar la tabla.");
            tt.SetToolTip(Btn_Buscar, "Realiza la búsqueda con el texto escrito.");
            tt.SetToolTip(Dgv_Seguimiento, "Haga clic en una fila para ver sus detalles y poder editarla o eliminarla.");
        }


        // --- EVENTOS DE BOTONES ---

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar_y_desactivar();
            fun_activar_para_edicion();
            Btn_Guardar.Enabled = true;
            Cmb_Cliente.Focus();
        }

        // En: Capa_Vista_Seguimiento/SeguimientoForm.cs

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // --- NUEVA VALIDACIÓN MEJORADA ---
            // 1. Verifica si algo está seleccionado en el ComboBox.
            if (Cmb_Cliente.SelectedIndex == -1 || Cmb_Cliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_Cliente.Focus(); // Pone el cursor en el ComboBox para que el usuario lo corrija
                return; // Detiene la ejecución del método aquí mismo
            }

            // 2. Verifica que los otros campos obligatorios no estén vacíos.
            if (string.IsNullOrWhiteSpace(Txt_Servicio.Text) || string.IsNullOrWhiteSpace(Txt_Monto.Text))
            {
                MessageBox.Show("El servicio y el monto son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_Servicio.Focus();
                return;
            }

            // 3. Verifica que el monto sea un número válido.
            if (!decimal.TryParse(Txt_Monto.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto))
            {
                MessageBox.Show("El monto ingresado no es un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_Monto.Focus();
                return;
            }
            // --- FIN DE LA VALIDACIÓN ---

            // Si pasamos todas las validaciones, procedemos a crear el objeto.
            var seguimiento = new Seguimiento
            {
                iIdCliente = Convert.ToInt32(Cmb_Cliente.SelectedValue),
                dtFecha = Dtp_Fecha.Value,
                sServicio = Txt_Servicio.Text,
                dMonto = monto,
                sObservaciones = Txt_Obs.Text
            };

            if (cn.pro_guardar_seguimiento(seguimiento))
            {
                MessageBox.Show("Guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fun_actualizar_tabla();
                fun_limpiar_y_desactivar();
            }
            else
            {
                MessageBox.Show("Error al guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Id.Text)) { MessageBox.Show("Debe seleccionar un registro de la tabla."); return; }
            if (Cmb_Cliente.SelectedValue == null) { MessageBox.Show("Debe seleccionar un cliente."); return; }
            if (!decimal.TryParse(Txt_Monto.Text, out decimal monto)) { MessageBox.Show("El monto no es válido."); return; }

            // --- AÑADIDO: Pregunta de confirmación antes de modificar ---
            var confirmacion = MessageBox.Show("¿Está seguro de que desea modificar este registro?", "Confirmar Modificación",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario presiona "No", detenemos la ejecución del método aquí.
            if (confirmacion == DialogResult.No)
            {
                return;
            }
            // --- FIN DEL AÑADIDO ---

            var seguimiento = new Seguimiento
            {
                iIdSeguimiento = Convert.ToInt32(Txt_Id.Text),
                iIdCliente = Convert.ToInt32(Cmb_Cliente.SelectedValue),
                dtFecha = Dtp_Fecha.Value,
                sServicio = Txt_Servicio.Text,
                dMonto = monto,
                sObservaciones = Txt_Obs.Text
            };

            if (cn.pro_actualizar_seguimiento(seguimiento))
            {
                // --- MODIFICADO: Se añade título e icono al mensaje ---
                MessageBox.Show("Registro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fun_actualizar_tabla();
                fun_limpiar_y_desactivar();
            }
            else { MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Id.Text)) { MessageBox.Show("Debe seleccionar un registro de la tabla."); return; }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion == DialogResult.Yes)
            {
                if (cn.pro_eliminar_seguimiento(Convert.ToInt32(Txt_Id.Text)))
                {
                    // --- MODIFICADO: Se añade título e icono al mensaje ---
                    MessageBox.Show("Registro eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fun_actualizar_tabla();
                    fun_limpiar_y_desactivar();
                }
                else { MessageBox.Show("Error al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            fun_limpiar_y_desactivar();
            fun_actualizar_tabla();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Dgv_Seguimiento.DataSource = cn.fun_buscar_seguimientos(Txt_Buscar.Text);
            fun_formatear_dgv();

            // CORRECCIÓN 1: Habilitar el botón Cancelar después de una búsqueda
            Btn_Cancelar.Enabled = true;
        }

        // --- EVENTOS DE LA TABLA ---

        private void Dgv_Seguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // CORRECCIÓN 2: Se movió toda la lógica al evento CellContentClick, que es el que tu diseñador está usando.
        private void Dgv_Seguimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita error al hacer clic en el encabezado

            fun_activar_para_edicion();
            Btn_Actualizar.Enabled = true;
            Btn_Eliminar.Enabled = true;

            var fila = Dgv_Seguimiento.Rows[e.RowIndex];
            Txt_Id.Text = fila.Cells["pk_id_seguimiento"].Value.ToString();
            Cmb_Cliente.SelectedValue = fila.Cells["pk_id_cliente"].Value;
            Dtp_Fecha.Value = Convert.ToDateTime(fila.Cells["fecha"].Value);
            Txt_Servicio.Text = fila.Cells["servicio"].Value.ToString();
            Txt_Monto.Text = Convert.ToDecimal(fila.Cells["monto"].Value).ToString(CultureInfo.InvariantCulture);
            Txt_Obs.Text = fila.Cells["observaciones"].Value.ToString();
        }

        // Método de compatibilidad para el diseñador
        private void SeguimientoForm_Load_1(object sender, EventArgs e)
        {
            SeguimientoForm_Load(sender, e);
        }
    }
}