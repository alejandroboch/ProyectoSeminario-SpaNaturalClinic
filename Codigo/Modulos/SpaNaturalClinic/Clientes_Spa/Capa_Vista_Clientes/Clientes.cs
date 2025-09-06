using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Capa_Controlador_Cliente;
using Capa_Modelo_Cliente;

namespace Capa_Vista_Clientes
{
    public partial class Clientes : Form
    {
          Controlador cn = new Controlador();
        private readonly string sTabla = "tbl_clientes";

        public Clientes()
        {
            InitializeComponent();

            // Tabla
            Dgv_Clientes.AutoGenerateColumns = true;
            Dgv_Clientes.ReadOnly = true;
            Dgv_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Eventos de validación de entrada
            Txt_Buscar.KeyPress += Txt_Buscar_KeyPress_SoloLetras;
            Txt_Nombre.KeyPress += Txt_Buscar_KeyPress_SoloLetras;

            // Eventos de tabla
            Dgv_Clientes.CellClick += Dgv_Clientes_CellClick;
            Dgv_Clientes.CellFormatting += Dgv_Clientes_CellFormatting;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            actualizardatagriew();
            fun_estado_edicion(false);

            // UX: aceptar = Guardar (en modo nuevo)
            this.AcceptButton = Btn_Guardar;
            this.CancelButton = Btn_Cancelar;

            if (Gpb_Form != null) Gpb_Form.Text = "Formulario";
            if (Gpb_Lista != null) Gpb_Lista.Text = "Listado";
        }

        // =================== CARGA Y ESTADO UI ===================
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(sTabla);
            Dgv_Clientes.DataSource = dt;

            if (Dgv_Clientes.Columns.Contains("pk_id_cliente"))
                Dgv_Clientes.Columns["pk_id_cliente"].HeaderText = "ID";
            if (Dgv_Clientes.Columns.Contains("nombre"))
                Dgv_Clientes.Columns["nombre"].HeaderText = "Nombre";
            if (Dgv_Clientes.Columns.Contains("telefono"))
                Dgv_Clientes.Columns["telefono"].HeaderText = "Teléfono";
            if (Dgv_Clientes.Columns.Contains("correo"))
                Dgv_Clientes.Columns["correo"].HeaderText = "Correo";
            if (Dgv_Clientes.Columns.Contains("es_vip"))
                Dgv_Clientes.Columns["es_vip"].HeaderText = "VIP";
        }

        private void fun_estado_edicion(bool bActivo)
        {
            Txt_Nombre.Enabled = bActivo;
            Txt_Telefono.Enabled = bActivo;
            Txt_Correo.Enabled = bActivo;
            Chk_Vip.Enabled = bActivo;

            // Botones según modo
            Btn_Guardar.Enabled = bActivo && string.IsNullOrWhiteSpace(Txt_Id.Text);
            Btn_Actualizar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_Id.Text);
            Btn_Eliminar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_Id.Text);

            // AcceptButton dinámico
            this.AcceptButton = string.IsNullOrWhiteSpace(Txt_Id.Text) ? Btn_Guardar : Btn_Actualizar;
        }

        private void fun_limpiar()
        {
            Txt_Id.Clear();
            Txt_Nombre.Clear();
            Txt_Telefono.Clear();
            Txt_Correo.Clear();
            Txt_Buscar.Clear();
            Chk_Vip.Checked = false;

            // Regresa a modo lectura
            fun_estado_edicion(false);
        }

        private Cliente fun_capturar()
        {
            return new Cliente
            {
                iId = string.IsNullOrWhiteSpace(Txt_Id.Text) ? 0 : int.Parse(Txt_Id.Text),
                sNombre = Txt_Nombre.Text.Trim(),
                sTelefono = Txt_Telefono.Text.Trim(),
                sCorreo = Txt_Correo.Text.Trim(),
                bEsVip = Chk_Vip.Checked
            };
        }

        // =================== VALIDACIONES ===================
        // Solo letras, espacio y teclas de edición
        private void Txt_Buscar_KeyPress_SoloLetras(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esEspacio = char.IsWhiteSpace(e.KeyChar);

            if (!(esControl || esLetra || esEspacio))
                e.Handled = true; // bloquea números, símbolos, etc.
        }

        private bool fun_busqueda_valida()
        {
            string s = Txt_Buscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(s))
            {
                MessageBox.Show("Ingresa un nombre para buscar.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txt_Buscar.Focus();
                return false;
            }

            // Verifica que todos los caracteres sean letras o espacios
            foreach (char c in s)
            {
                if (!(char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    MessageBox.Show("La búsqueda solo admite letras y espacios.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_Buscar.Focus();
                    return false;
                }
            }
            return true;
        }

        // =================== EVENTOS BOTONES ===================
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
            Txt_Nombre.Focus();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            var c = fun_capturar();
            if (string.IsNullOrWhiteSpace(c.sNombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_Nombre.Focus();
                return;
            }

            if (cn.pro_guardar(c))
            {
                MessageBox.Show("Cliente guardado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizardatagriew();
                fun_limpiar();
            }
            else
            {
                MessageBox.Show("Verifica los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            var c = fun_capturar();
            if (c.iId <= 0)
            {
                MessageBox.Show("Selecciona un registro a actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(c.sNombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_Nombre.Focus();
                return;
            }

            if (cn.pro_actualizar(c))
            {
                MessageBox.Show("Cliente actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizardatagriew();
                fun_limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Id.Text)) return;
            int iId = int.Parse(Txt_Id.Text);

            if (MessageBox.Show("¿Eliminar el cliente seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cn.pro_eliminar(iId))
                {
                    MessageBox.Show("Cliente eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew();
                    fun_limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            fun_limpiar();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // Obliga a buscar por NOMBRE: solo letras + no vacío
            if (!fun_busqueda_valida()) return;

            // Si quieres que realmente SOLO busque por nombre a nivel SQL,
            // cambia el método del Controlador por uno que filtre por nombre.
            // Aquí usamos el existente:
            DataTable dt = cn.fun_buscar_clientes(Txt_Buscar.Text.Trim());
            Dgv_Clientes.DataSource = dt;
        }

        // =================== EVENTOS TABLA ===================
        private void Dgv_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_Clientes.CurrentRow == null) return;

            var r = Dgv_Clientes.Rows[e.RowIndex];

            Txt_Id.Text = Convert.ToString(r.Cells["pk_id_cliente"].Value);
            Txt_Nombre.Text = Convert.ToString(r.Cells["nombre"].Value);
            Txt_Telefono.Text = Convert.ToString(r.Cells["telefono"].Value);
            Txt_Correo.Text = Convert.ToString(r.Cells["correo"].Value);

            // VIP puede venir como 0/1 o bool; cubrimos ambos
            object vip = r.Cells["es_vip"].Value;
            bool bVip = false;
            if (vip is bool) bVip = (bool)vip;
            else if (vip != null && int.TryParse(vip.ToString(), out int n)) bVip = (n == 1);
            Chk_Vip.Checked = bVip;

            // Pasa a modo edición (habilita Actualizar/Eliminar y deshabilita Guardar)
            fun_estado_edicion(true);
        }

        private void Dgv_Clientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Dgv_Clientes.Columns[e.ColumnIndex].Name == "es_vip" && e.Value != null)
            {
                // Muestra “Sí/No” en lugar de 1/0
                int val;
                if (e.Value is bool b) { e.Value = b ? "Sí" : "No"; e.FormattingApplied = true; }
                else if (int.TryParse(e.Value.ToString(), out val)) { e.Value = (val == 1) ? "Sí" : "No"; e.FormattingApplied = true; }
            }
        }



        private void Txt_Buscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

