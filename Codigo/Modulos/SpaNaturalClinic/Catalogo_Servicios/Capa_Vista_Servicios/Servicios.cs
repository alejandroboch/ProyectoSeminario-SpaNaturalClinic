using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Serv;
using Capa_Modelo_Servicios;
using System.Data.Odbc;

namespace Capa_Vista_Servicios
{
    public partial class Servicios : Form
    {
        Controlador cn = new Controlador();
        private readonly string sTabla = "tbl_servicios";
        private readonly ToolTip toolTip1 = new ToolTip(); // NUEVO

        public Servicios()
        {
            InitializeComponent();
            Txt_IdServicio.Enabled = false;
            // Tabla
            Dgv_Servicios.AutoGenerateColumns = true;
            Dgv_Servicios.ReadOnly = true;
            Dgv_Servicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Eventos de validación de entrada
            Txt_Buscar.KeyPress += Txt_Buscar_KeyPress_SoloLetras;
            Txt_NombreServicio.KeyPress += Txt_Buscar_KeyPress_SoloLetras;

            // Eventos de tabla
            Dgv_Servicios.CellClick += Dgv_Servicios_CellClick;

            // NUEVO: cuando el cuadro de búsqueda queda vacío, recargar todo
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;

            // NUEVO: ToolTips de botones (se pueden mover al Load si prefieres)
            toolTip1.SetToolTip(Btn_Nuevo, "Preparar formulario para nuevo servicio");
            toolTip1.SetToolTip(Btn_Guardar, "Guardar un servicio nuevo");
            toolTip1.SetToolTip(Btn_Actualizar, "Modificar el servicio seleccionado");
            toolTip1.SetToolTip(Btn_Buscar, "Buscar servicios por nombre");
            toolTip1.SetToolTip(Btn_Eliminar, "Eliminar el servicio seleccionado");
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar operación y limpiar formulario");
            toolTip1.SetToolTip(Btn_Reporte, "Generar reporte de servicios");
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

        private void Dgv_Servicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_Servicios.CurrentRow == null) return;

            var r = Dgv_Servicios.Rows[e.RowIndex];

            Txt_IdServicio.Text = Convert.ToString(r.Cells["pk_id_servicio"].Value);
            Txt_NombreServicio.Text = Convert.ToString(r.Cells["nombre"].Value);
            Txt_PrecioServicio.Text = Convert.ToString(r.Cells["precio"].Value);

            // Pasa a modo edición (habilita Actualizar/Eliminar y deshabilita Guardar)
            fun_estado_edicion(true);
        }

        private void fun_estado_edicion(bool bActivo)
        {
            Txt_NombreServicio.Enabled = bActivo;
            Txt_PrecioServicio.Enabled = bActivo;

            // Botones según modo
            Btn_Guardar.Enabled = bActivo && string.IsNullOrWhiteSpace(Txt_IdServicio.Text);
            Btn_Actualizar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdServicio.Text);
            Btn_Eliminar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdServicio.Text);
        }

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(sTabla);
            Dgv_Servicios.DataSource = dt;

            if (Dgv_Servicios.Columns.Contains("pk_id_servicio"))
                Dgv_Servicios.Columns["pk_id_servicio"].HeaderText = "ID Servicio";
            if (Dgv_Servicios.Columns.Contains("nombre"))
                Dgv_Servicios.Columns["nombre"].HeaderText = "Nombre del Servicio";
            if (Dgv_Servicios.Columns.Contains("precio"))
                Dgv_Servicios.Columns["precio"].HeaderText = "Precio";
        }

        private void fun_limpiar()
        {
            Txt_IdServicio.Clear();
            Txt_NombreServicio.Clear();
            Txt_PrecioServicio.Clear();
        
            // Regresa a modo lectura
            fun_estado_edicion(false);

            // NUEVO: al limpiar, también reiniciamos la grilla completa
            actualizardatagriew();
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
            Txt_NombreServicio.Focus();
        }

        private bool fun_validar_obligatorios()
        {
            if (string.IsNullOrWhiteSpace(Txt_NombreServicio.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NombreServicio.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Txt_PrecioServicio.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioServicio.Focus();
                return false;
            }
           
            return true;
        }

        private Servicio fun_capturar()
        {
            return new Servicio
            {
                iId = string.IsNullOrWhiteSpace(Txt_IdServicio.Text)
                        ? 0
                        : int.Parse(Txt_IdServicio.Text),
                sNombreServicio = Txt_NombreServicio.Text.Trim(),
                dPrecioServicio = string.IsNullOrWhiteSpace(Txt_PrecioServicio.Text)
                        ? 0
                        : decimal.Parse(
                            Txt_PrecioServicio.Text.Trim().Replace(',', '.'),
                            System.Globalization.CultureInfo.InvariantCulture)
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
                MessageBox.Show("Servicio guardado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(Txt_IdServicio.Text))
            {
                MessageBox.Show("Selecciona un registro a actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CAMBIO: Validación estricta de todos los obligatorios
            if (!fun_validar_obligatorios()) return;

            // NUEVO: Confirmación de modificación
            var conf = MessageBox.Show("¿Deseas modificar el servicio seleccionado?", "Confirmación",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            var s = fun_capturar();

            if (cn.pro_actualizar(s))
            {
                MessageBox.Show("Servicio actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(Txt_IdServicio.Text)) return;

            int iId = int.Parse(Txt_IdServicio.Text);

            if (MessageBox.Show("¿Eliminar el servicio seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (cn.pro_eliminar(iId)) // tu método ODBC
                    {
                        MessageBox.Show("Servicio eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("No se puede eliminar este servicio porque está relacionado con otra tabla.",
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

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // Obliga a buscar por NOMBRE: solo letras + no vacío
            if (!fun_busqueda_valida()) return;

            DataTable dt = cn.fun_buscar_servicio(Txt_Buscar.Text.Trim());
            Dgv_Servicios.DataSource = dt;
        }
    }
}
