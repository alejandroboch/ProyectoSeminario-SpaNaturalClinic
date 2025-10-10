using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Modelo_Paquetes;
using Capa_Controlador_Paquetes;

namespace Capa_Vista_Paquetes
{
    public partial class Paquetes : Form
    {
        Controlador cn = new Controlador();
        private readonly string sTabla = "tbl_paquetes";
        private readonly ToolTip toolTip1 = new ToolTip(); // NUEVO
        public Paquetes()
        {
            InitializeComponent();
            fun_limpiar();
            Txt_IdPaquete.Enabled = false;
            // Tabla
            Dgv_Paquetes.AutoGenerateColumns = true;
            Dgv_Paquetes.ReadOnly = true;
            Dgv_Paquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Eventos de validación de entrada
            Txt_Buscar.KeyPress += Txt_Buscar_KeyPress_SoloLetras;
            Txt_NombrePaquete.KeyPress += Txt_Buscar_KeyPress_SoloLetras;

            // Eventos de tabla
            Dgv_Paquetes.CellClick += Dgv_Paquetes_CellClick;

            // NUEVO: cuando el cuadro de búsqueda queda vacío, recargar todo
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;

            // NUEVO: ToolTips de botones (se pueden mover al Load si prefieres)
            toolTip1.SetToolTip(Btn_Nuevo, "Preparar formulario para nuevo paquete");
            toolTip1.SetToolTip(Btn_Guardar, "Guardar un paquete nuevo");
            toolTip1.SetToolTip(Btn_Actualizar, "Modificar el paquete seleccionado");
            toolTip1.SetToolTip(Btn_Buscar, "Buscar paquetes por nombre");
            toolTip1.SetToolTip(Btn_Eliminar, "Eliminar el paquete seleccionado");
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar operación y limpiar formulario");
            toolTip1.SetToolTip(Btn_Reporte, "Generar reporte de paquetes");
            toolTip1.SetToolTip(Btn_Ayuda, "Abrir ayuda del módulo");
        }

        private void Txt_Buscar_KeyPress_SoloLetras(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esEspacio = char.IsWhiteSpace(e.KeyChar);

            if (!(esControl || esLetra || esEspacio))
                e.Handled = true; // bloquea números, símbolos, etc.
        }

        private void Txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            // NUEVO: si se limpia el texto, restaurar todos los registros
            if (string.IsNullOrWhiteSpace(Txt_Buscar.Text))
            {
                actualizardatagriew();
            }
        }

        private void Dgv_Paquetes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_Paquetes.CurrentRow == null) return;

            var r = Dgv_Paquetes.Rows[e.RowIndex];

            Txt_IdPaquete.Text = Convert.ToString(r.Cells["pk_id_paquete"].Value);
            Txt_NombrePaquete.Text = Convert.ToString(r.Cells["nombre"].Value);
            Txt_PrecioPaquete.Text = Convert.ToString(r.Cells["precio_total"].Value);
            Txt_CantSesiones.Text = Convert.ToString(r.Cells["numero_sesiones"].Value);

            // Pasa a modo edición (habilita Actualizar/Eliminar y deshabilita Guardar)
            fun_estado_edicion(true);
        }

        private void fun_estado_edicion(bool bActivo)
        {
            Txt_NombrePaquete.Enabled = bActivo;
            Txt_PrecioPaquete.Enabled = bActivo;
            Txt_CantSesiones.Enabled = bActivo;

            // Botones según modo
            Btn_Guardar.Enabled = bActivo && string.IsNullOrWhiteSpace(Txt_IdPaquete.Text);
            Btn_Actualizar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdPaquete.Text);
            Btn_Eliminar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdPaquete.Text);
        }

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(sTabla);
            Dgv_Paquetes.DataSource = dt;

            if (Dgv_Paquetes.Columns.Contains("pk_id_paquete"))
                Dgv_Paquetes.Columns["pk_id_paquete"].HeaderText = "ID Paquete";
            if (Dgv_Paquetes.Columns.Contains("nombre"))
                Dgv_Paquetes.Columns["nombre"].HeaderText = "Nombre del Paquete";
            if (Dgv_Paquetes.Columns.Contains("precio_total"))
                Dgv_Paquetes.Columns["precio_total"].HeaderText = "Precio";
            if (Dgv_Paquetes.Columns.Contains("numero_sesiones"))
                Dgv_Paquetes.Columns["numero_sesiones"].HeaderText = "Cantidad de Sesiones";
        }

        private void fun_limpiar()
        {
            Txt_IdPaquete.Clear();
            Txt_NombrePaquete.Clear();
            Txt_PrecioPaquete.Clear();
            Txt_CantSesiones.Clear();

            // Regresa a modo lectura
            fun_estado_edicion(false);

            // NUEVO: al limpiar, también reiniciamos la grilla completa
            actualizardatagriew();
        }
        //------------------------------------BOTONES-------------------------------------
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
            Txt_NombrePaquete.Focus();
        }

        private bool fun_validar_obligatorios()
        {
            if (string.IsNullOrWhiteSpace(Txt_NombrePaquete.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NombrePaquete.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Txt_PrecioPaquete.Text))
            {
                MessageBox.Show("El precio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioPaquete.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Txt_CantSesiones.Text))
            {
                MessageBox.Show("La cantidad de sesiones es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_CantSesiones.Focus();
                return false;
            }

            return true;
        }

        private Paquete fun_capturar()
        {
            return new Paquete
            {
                iId = string.IsNullOrWhiteSpace(Txt_IdPaquete.Text)
                        ? 0
                        : int.Parse(Txt_IdPaquete.Text),
                sNombrePaquete = Txt_NombrePaquete.Text.Trim(),
                dPrecioPaquete = string.IsNullOrWhiteSpace(Txt_PrecioPaquete.Text)
                        ? 0
                        : decimal.Parse(
                            Txt_PrecioPaquete.Text.Trim().Replace(',', '.'),
                            System.Globalization.CultureInfo.InvariantCulture),
                iNumSesiones = string.IsNullOrWhiteSpace(Txt_CantSesiones.Text)
                        ? 0
                        : int.Parse(Txt_CantSesiones.Text),
            };
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

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // CAMBIO: Validación estricta de todos los obligatorios
            if (!fun_validar_obligatorios()) return;

            var s = fun_capturar();

            if (cn.pro_guardar(s))
            {
                MessageBox.Show("Paquete guardado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(Txt_IdPaquete.Text))
            {
                MessageBox.Show("Selecciona un registro a actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CAMBIO: Validación estricta de todos los obligatorios
            if (!fun_validar_obligatorios()) return;

            // NUEVO: Confirmación de modificación
            var conf = MessageBox.Show("¿Deseas modificar el Paquete seleccionado?", "Confirmación",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            var s = fun_capturar();

            if (cn.pro_actualizar(s))
            {
                MessageBox.Show("Paquete actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizardatagriew();
                fun_limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // Obliga a buscar por NOMBRE: solo letras + no vacío
            if (!fun_busqueda_valida()) return;

            DataTable dt = cn.fun_buscar_paquetes(Txt_Buscar.Text.Trim());
            Dgv_Paquetes.DataSource = dt;
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_IdPaquete.Text)) return;

            int iId = int.Parse(Txt_IdPaquete.Text);

            if (MessageBox.Show("¿Eliminar el paquete seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (cn.pro_eliminar(iId)) // tu método ODBC
                    {
                        MessageBox.Show("Paquete eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizardatagriew();
                        fun_limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (System.Data.Odbc.OdbcException ex)
                {
                    if (ex.Message.Contains("foreign key") || ex.Message.Contains("Cannot delete or update"))
                    {
                        MessageBox.Show("No se puede eliminar este paquete porque está relacionado con otra tabla.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            fun_limpiar();
        }

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_Reporte reporte = new frm_Reporte();
            reporte.Show();
        }
    }
}
