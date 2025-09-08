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

namespace Capa_Vista_Seguimiento
{
    public partial class SeguimientoForm : Form
    {
        private readonly Controlador cn = new Controlador();
        private readonly ErrorProvider ep = new ErrorProvider();
        private readonly ToolTip tt = new ToolTip();

        // (opcional) nombre de la tabla si deseas usar el patrón llenarTbl directo
        private readonly string sTabla = "tbl_seguimiento_clientes";

        public SeguimientoForm()
        {
            InitializeComponent();

            // DataGridView
            Dgv_Seguimiento.AutoGenerateColumns = true;
            Dgv_Seguimiento.ReadOnly = true;
            Dgv_Seguimiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Entradas: validación
            Txt_Buscar.KeyPress += Txt_SoloLetras_KeyPress;
            Txt_Servicio.KeyPress += Txt_SoloLetras_KeyPress;
            Txt_Monto.KeyPress += Txt_Monto_KeyPress;

            // Enter para buscar
            Txt_Buscar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { Btn_Buscar.PerformClick(); e.SuppressKeyPress = true; } };
            Txt_Buscar.TextChanged += (s, e) => { if (string.IsNullOrWhiteSpace(Txt_Buscar.Text)) fun_cargar_lista(); };

            // Tabla
            Dgv_Seguimiento.CellClick += Dgv_Seguimiento_CellClick;
            Dgv_Seguimiento.CellFormatting += Dgv_Seguimiento_CellFormatting;

            // Validaciones Leave
            Cmb_Cliente.Leave += (s, e) => fun_validar_cliente(true);
            Dtp_Fecha.Leave += (s, e) => fun_validar_fecha(true);
            Txt_Servicio.Leave += (s, e) => fun_validar_servicio(true);
            Txt_Monto.Leave += (s, e) => fun_validar_monto(true);

            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            fun_configurar_tooltips();
        }

        private void SeguimientoForm_Load(object sender, EventArgs e)
        {
            fun_cargar_clientes_combo();
            fun_cargar_lista();
            fun_estado_edicion(false);
            fun_configurar_tabindex();

            this.AcceptButton = Btn_Guardar;
            this.CancelButton = Btn_Cancelar;

        }

        // ============ Carga de datos ============
        private void fun_cargar_clientes_combo()
        {
            var dt = cn.fun_clientes_combo();
            Cmb_Cliente.DisplayMember = "nombre";
            Cmb_Cliente.ValueMember = "pk_id_cliente";
            Cmb_Cliente.DataSource = dt;
            Cmb_Cliente.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
        }

        private void fun_cargar_lista()
        {
            var dt = cn.fun_listar(); // usa JOIN con clientes
            Dgv_Seguimiento.DataSource = dt;

            if (Dgv_Seguimiento.Columns.Contains("pk_id_seguimiento"))
                Dgv_Seguimiento.Columns["pk_id_seguimiento"].HeaderText = "ID";
            if (Dgv_Seguimiento.Columns.Contains("cliente"))
                Dgv_Seguimiento.Columns["cliente"].HeaderText = "Cliente";
            if (Dgv_Seguimiento.Columns.Contains("fecha"))
                Dgv_Seguimiento.Columns["fecha"].HeaderText = "Fecha";
            if (Dgv_Seguimiento.Columns.Contains("servicio"))
                Dgv_Seguimiento.Columns["servicio"].HeaderText = "Servicio";
            if (Dgv_Seguimiento.Columns.Contains("monto"))
                Dgv_Seguimiento.Columns["monto"].HeaderText = "Monto";
            if (Dgv_Seguimiento.Columns.Contains("observaciones"))
                Dgv_Seguimiento.Columns["observaciones"].HeaderText = "Observaciones";
            if (Dgv_Seguimiento.Columns.Contains("es_frecuente"))
                Dgv_Seguimiento.Columns["es_frecuente"].HeaderText = "Frecuente";
        }

        // ============ Estado UI ============
        private void fun_estado_edicion(bool bActivo)
        {
            Cmb_Cliente.Enabled = bActivo;
            Dtp_Fecha.Enabled = bActivo;
            Txt_Servicio.Enabled = bActivo;
            Txt_Monto.Enabled = bActivo;
            Txt_Obs.Enabled = bActivo;
            Chk_Frecuente.Enabled = bActivo;

            Btn_Guardar.Enabled = bActivo && string.IsNullOrWhiteSpace(Txt_Id.Text);
            Btn_Actualizar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_Id.Text);
            Btn_Eliminar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_Id.Text);

            this.AcceptButton = string.IsNullOrWhiteSpace(Txt_Id.Text) ? Btn_Guardar : Btn_Actualizar;
        }

        private void fun_limpiar()
        {
            ep.Clear();
            Txt_Id.Clear();
            if (Cmb_Cliente.Items.Count > 0) Cmb_Cliente.SelectedIndex = 0; else Cmb_Cliente.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Today;
            Txt_Servicio.Clear();
            Txt_Monto.Clear();
            Txt_Obs.Clear();
            Chk_Frecuente.Checked = false;

            fun_estado_edicion(false);
            Cmb_Cliente.Focus();
        }

        // ============ Captura / construcción del modelo ============
        private Seguimiento fun_capturar()
        {
            return new Seguimiento
            {
                iId = string.IsNullOrWhiteSpace(Txt_Id.Text) ? 0 : int.Parse(Txt_Id.Text),
                iIdCliente = Cmb_Cliente.SelectedValue == null ? 0 : Convert.ToInt32(Cmb_Cliente.SelectedValue),
                sFecha = Dtp_Fecha.Value.ToString("yyyy-MM-dd"),
                sServicio = Txt_Servicio.Text.Trim(),
                dMonto = fun_parse_monto(Txt_Monto.Text.Trim()),
                sObs = Txt_Obs.Text.Trim(),
                bFrecuente = Chk_Frecuente.Checked
            };
        }

        private decimal fun_parse_monto(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;
            // acepta coma o punto como separador
            s = s.Replace(',', '.');
            decimal.TryParse(s, System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal v);
            return v;
        }

        // ============ Validaciones ============
        private void Txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ctl = char.IsControl(e.KeyChar);
            bool let = char.IsLetter(e.KeyChar);
            bool spc = char.IsWhiteSpace(e.KeyChar);
            if (!(ctl || let || spc)) e.Handled = true;
        }

        private void Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ctl = char.IsControl(e.KeyChar);
            bool dig = char.IsDigit(e.KeyChar);
            bool sep = e.KeyChar == '.' || e.KeyChar == ','; // separador decimal
            if (!(ctl || dig || sep)) e.Handled = true;
        }

        private void fun_msg(string t, Control foco = null)
        {
            MessageBox.Show(t, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foco?.Focus();
        }

        private bool fun_validar_cliente(bool msg)
        {
            bool ok = Cmb_Cliente.SelectedValue != null && Convert.ToInt32(Cmb_Cliente.SelectedValue) > 0;
            ep.SetError(Cmb_Cliente, ok ? "" : "Selecciona un cliente.");
            if (!ok && msg) fun_msg("Selecciona un cliente.", Cmb_Cliente);
            return ok;
        }

        private bool fun_validar_fecha(bool msg)
        {
            // Permite hoy o fechas pasadas/futuras; si quieres limitar, ajusta aquí
            ep.SetError(Dtp_Fecha, "");
            return true;
        }

        private bool fun_validar_servicio(bool msg)
        {
            bool ok = !string.IsNullOrWhiteSpace(Txt_Servicio.Text);
            ep.SetError(Txt_Servicio, ok ? "" : "El servicio es obligatorio.");
            if (!ok && msg) fun_msg("El servicio es obligatorio.", Txt_Servicio);
            return ok;
        }

        private bool fun_validar_monto(bool msg)
        {
            string s = Txt_Monto.Text.Trim();
            bool ok = !string.IsNullOrEmpty(s) && fun_parse_monto(s) > 0;
            ep.SetError(Txt_Monto, ok ? "" : "Monto obligatorio (> 0).");
            if (!ok && msg) fun_msg("El monto es obligatorio y debe ser mayor que 0.", Txt_Monto);
            return ok;
        }

        private bool fun_validar_form()
        {
            bool okCli = fun_validar_cliente(false);
            bool okFec = fun_validar_fecha(false);
            bool okSer = fun_validar_servicio(false);
            bool okMon = fun_validar_monto(false);

            if (okCli && okFec && okSer && okMon) return true;

            var sb = new StringBuilder("Por favor corrige:\n\n");
            if (!okCli) sb.AppendLine("• Selecciona un cliente.");
            if (!okSer) sb.AppendLine("• El servicio es obligatorio.");
            if (!okMon) sb.AppendLine("• El monto es obligatorio y mayor que 0.");
            fun_msg(sb.ToString());

            fun_validar_cliente(true);
            fun_validar_servicio(true);
            fun_validar_monto(true);
            return false;
        }

        private bool fun_busqueda_valida()
        {
            string s = Txt_Buscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(s)) { fun_cargar_lista(); return false; }
            foreach (char c in s)
                if (!(char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    fun_msg("La búsqueda solo admite letras y espacios.", Txt_Buscar);
                    return false;
                }
            return true;
        }

        // ============ Botones ============
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!fun_validar_form()) return;

            var s = fun_capturar();
            if (cn.pro_guardar(s))
            {
                MessageBox.Show("Seguimiento guardado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ep.Clear();
                fun_cargar_lista();
                fun_limpiar();
            }
            else MessageBox.Show("No se pudo guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Id.Text))
            {
                fun_msg("Selecciona un registro a actualizar.", Dgv_Seguimiento);
                return;
            }
            if (!fun_validar_form()) return;

            var s = fun_capturar();
            if (cn.pro_actualizar(s))
            {
                MessageBox.Show("Seguimiento actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ep.Clear();
                fun_cargar_lista();
                fun_limpiar();
            }
            else MessageBox.Show("No se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Id.Text)) return;
            int iId = int.Parse(Txt_Id.Text);

            if (MessageBox.Show("¿Eliminar el registro seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cn.pro_eliminar(iId))
                {
                    MessageBox.Show("Seguimiento eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ep.Clear();
                    fun_cargar_lista();
                    fun_limpiar();
                }
                else MessageBox.Show("No se pudo eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_cargar_lista(); // mostrar todo
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (!fun_busqueda_valida()) return; // si está vacío, ya carga todo

            var dt = cn.fun_buscar_por_cliente(Txt_Buscar.Text.Trim());
            Dgv_Seguimiento.DataSource = dt;
        }

        // ============ Tabla ============
        private void Dgv_Seguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_Seguimiento.CurrentRow == null) return;
            var r = Dgv_Seguimiento.Rows[e.RowIndex];

            Txt_Id.Text = Convert.ToString(r.Cells["pk_id_seguimiento"].Value);

            // Cliente
            string sNombre = Convert.ToString(r.Cells["cliente"].Value);
            if (!string.IsNullOrWhiteSpace(sNombre) && Cmb_Cliente.Items.Count > 0)
            {
                // busca por display
                for (int i = 0; i < Cmb_Cliente.Items.Count; i++)
                {
                    var drv = Cmb_Cliente.Items[i] as DataRowView;
                    if (drv != null && string.Equals(Convert.ToString(drv["nombre"]), sNombre, StringComparison.OrdinalIgnoreCase))
                    { Cmb_Cliente.SelectedIndex = i; break; }
                }
            }

            // Fecha
            DateTime dt;
            if (DateTime.TryParse(Convert.ToString(r.Cells["fecha"].Value), out dt)) Dtp_Fecha.Value = dt;

            Txt_Servicio.Text = Convert.ToString(r.Cells["servicio"].Value);
            Txt_Monto.Text = Convert.ToString(r.Cells["monto"].Value);
            Txt_Obs.Text = Convert.ToString(r.Cells["observaciones"].Value);

            object frec = r.Cells["es_frecuente"].Value;
            bool bF = false;
            if (frec is bool) bF = (bool)frec;
            else if (frec != null && int.TryParse(frec.ToString(), out int n)) bF = (n == 1);
            Chk_Frecuente.Checked = bF;

            fun_estado_edicion(true);
            Btn_Actualizar.Focus();
        }

        private void Dgv_Seguimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Dgv_Seguimiento.Columns[e.ColumnIndex].Name == "es_frecuente" && e.Value != null)
            {
                if (e.Value is bool b) { e.Value = b ? "Sí" : "No"; e.FormattingApplied = true; }
                else if (int.TryParse(e.Value.ToString(), out int v)) { e.Value = (v == 1) ? "Sí" : "No"; e.FormattingApplied = true; }
            }
        }

        // ============ Tab / Tooltips ============
        private void fun_configurar_tabindex()
        {
            // Búsqueda
            Txt_Buscar.TabIndex = 0; Btn_Buscar.TabIndex = 1;

            // Formulario
            Txt_Id.TabIndex = 2; // read-only
            Cmb_Cliente.TabIndex = 3;
            Dtp_Fecha.TabIndex = 4;
            Txt_Servicio.TabIndex = 5;
            Txt_Monto.TabIndex = 6;
            Txt_Obs.TabIndex = 7;
            Chk_Frecuente.TabIndex = 8;

            // Botones
            Btn_Nuevo.TabIndex = 9;
            Btn_Guardar.TabIndex = 10;
            Btn_Actualizar.TabIndex = 11;
            Btn_Eliminar.TabIndex = 12;
            Btn_Cancelar.TabIndex = 13;

            // Lista
            Dgv_Seguimiento.TabIndex = 14;
        }

        private void fun_configurar_tooltips()
        {
            tt.AutoPopDelay = 7000;
            tt.InitialDelay = 300;
            tt.ReshowDelay = 100;

            tt.SetToolTip(Txt_Buscar, "Escribe el nombre del cliente (solo letras). Enter para buscar.");
            tt.SetToolTip(Btn_Buscar, "Buscar por nombre de cliente. Si está vacío, se muestran todos.");
            tt.SetToolTip(Txt_Id, "Identificador interno (no editable).");
            tt.SetToolTip(Cmb_Cliente, "Selecciona el cliente.");
            tt.SetToolTip(Dtp_Fecha, "Fecha del seguimiento.");
            tt.SetToolTip(Txt_Servicio, "Servicio realizado (obligatorio).");
            tt.SetToolTip(Txt_Monto, "Monto cobrado (obligatorio, mayor que 0).");
            tt.SetToolTip(Txt_Obs, "Observaciones (opcional).");
            tt.SetToolTip(Chk_Frecuente, "Marca si es cliente frecuente.");
            tt.SetToolTip(Btn_Nuevo, "Nuevo registro.");
            tt.SetToolTip(Btn_Guardar, "Guardar (todos los campos obligatorios).");
            tt.SetToolTip(Btn_Actualizar, "Actualizar registro seleccionado.");
            tt.SetToolTip(Btn_Eliminar, "Eliminar registro seleccionado.");
            tt.SetToolTip(Btn_Cancelar, "Cancelar y limpiar. Se muestran todos los registros.");
            tt.SetToolTip(Dgv_Seguimiento, "Selecciona un registro para editar o eliminar.");
        }

        private void Dgv_Seguimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

