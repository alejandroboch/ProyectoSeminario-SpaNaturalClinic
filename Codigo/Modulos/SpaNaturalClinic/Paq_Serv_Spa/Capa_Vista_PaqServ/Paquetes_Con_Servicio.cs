using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Modelo_PaqServ;
using Capa_Controlador_PaqServ;
using System.Data.Odbc;

namespace Capa_Vista_PaqServ
{
    public partial class Paquetes_Con_Servicio : Form
    {

        Controlador cn = new Controlador();
        private readonly string sTabla = "tbl_paquete_servicio";
        private readonly ToolTip toolTip1 = new ToolTip(); // NUEVO
        public Paquetes_Con_Servicio()
        {
            InitializeComponent();
            fun_limpiar();
            Txt_IdPaqueteServicio.Enabled = false;
            // Tabla
            Dgv_PaquetesServicios.AutoGenerateColumns = true;
            Dgv_PaquetesServicios.ReadOnly = true;
            Dgv_PaquetesServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Eventos de validación de entrada
            Txt_Buscar.KeyPress += Txt_Buscar_KeyPress_SoloLetras;
            Cmb_NombrePaquete.KeyPress += Txt_Buscar_KeyPress_SoloLetras;

            // Eventos de tabla
            Dgv_PaquetesServicios.CellClick += Dgv_PaquetesServicios_CellClick;

            // NUEVO: cuando el cuadro de búsqueda queda vacío, recargar todo
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;

            // NUEVO: ToolTips de botones (se pueden mover al Load si prefieres)
            toolTip1.SetToolTip(Btn_Nuevo, "Preparar formulario para asignar un servicio a un paquete");
            toolTip1.SetToolTip(Btn_Guardar, "Guardar un nuevo servicio asignado al paquete");
            toolTip1.SetToolTip(Btn_Actualizar, "Modificar un servicios asignado al paquete seleccionado");
            toolTip1.SetToolTip(Btn_Buscar, "Buscar un servicio asignado a un paquete por nombre");
            toolTip1.SetToolTip(Btn_Eliminar, "Eliminar un servicio asignado a un paquete seleccionado");
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar operación y limpiar formulario");
            toolTip1.SetToolTip(Btn_Reporte, "Generar reporte de servicios asignados a paquetes");
            toolTip1.SetToolTip(Btn_Ayuda, "Abrir ayuda del módulo");

            Cmb_NombrePaquete.DataSource = cn.pro_LlenarCombo("tbl_paquetes", "nombre", "pk_id_paquete");
            Cmb_NombrePaquete.DisplayMember = "nombre";       // lo que ve el usuario
            Cmb_NombrePaquete.ValueMember = "pk_id_paquete";   // el ID que necesitamos internamente
            Cmb_NombrePaquete.SelectedIndex = -1;

            Cmb_NombreServicio.DataSource = cn.pro_LlenarCombo("tbl_servicios", "nombre", "pk_id_servicio");
            Cmb_NombreServicio.DisplayMember = "nombre"; // 👈 lo que se muestra
            Cmb_NombreServicio.ValueMember = "pk_id_servicio";   // 👈 el valor interno (puede ser ID si quieres)
            Cmb_NombreServicio.SelectedIndex = -1; // opcional: deja el combo vacío al inicio
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

        private void Dgv_PaquetesServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_PaquetesServicios.CurrentRow == null) return;

            var r = Dgv_PaquetesServicios.Rows[e.RowIndex];

            Txt_IdPaqueteServicio.Text = Convert.ToString(r.Cells["pk_id_paquete_servicio"].Value);
            Cmb_NombrePaquete.SelectedValue = r.Cells["fk_id_paquete"].Value;
            Cmb_NombreServicio.SelectedValue = r.Cells["fk_id_servicio"].Value;
            Txt_NumSesion.Text = Convert.ToString(r.Cells["numero_sesion"].Value);

            // Pasa a modo edición (habilita Actualizar/Eliminar y deshabilita Guardar)
            fun_estado_edicion(true);
        }

        private void fun_estado_edicion(bool bActivo)
        {
            Cmb_NombrePaquete.Enabled = bActivo;
            Cmb_NombreServicio.Enabled = bActivo;
            Txt_NumSesion.Enabled = bActivo;

            // Botones según modo
            Btn_Guardar.Enabled = bActivo && string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text);
            Btn_Actualizar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text);
            Btn_Eliminar.Enabled = bActivo && !string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text);
        }
        public void actualizardatagriew()
        {
            DataTable dt = cn.obtenerPaquetesServiciosConNombres();
            Dgv_PaquetesServicios.DataSource = dt;

            // Cambiar encabezados
            if (Dgv_PaquetesServicios.Columns.Contains("pk_id_paquete_servicio"))
                Dgv_PaquetesServicios.Columns["pk_id_paquete_servicio"].HeaderText = "ID Paquete";
            if (Dgv_PaquetesServicios.Columns.Contains("nombre_paquete"))
                Dgv_PaquetesServicios.Columns["nombre_paquete"].HeaderText = "Nombre del Paquete";
            if (Dgv_PaquetesServicios.Columns.Contains("nombre_servicio"))
                Dgv_PaquetesServicios.Columns["nombre_servicio"].HeaderText = "Nombre del Servicio";
            if (Dgv_PaquetesServicios.Columns.Contains("numero_sesion"))
                Dgv_PaquetesServicios.Columns["numero_sesion"].HeaderText = "Número de Sesión";
        }
        private void fun_limpiar()
        {
            Txt_IdPaqueteServicio.Clear();
            Cmb_NombrePaquete.Text = string.Empty;
            Cmb_NombreServicio.Text = string.Empty;
            Txt_NumSesion.Clear();

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
            Cmb_NombrePaquete.Focus();
        }

        private bool fun_validar_obligatorios()
        {
            if (string.IsNullOrWhiteSpace(Cmb_NombrePaquete.Text))
            {
                MessageBox.Show("El paquete es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombrePaquete.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Cmb_NombreServicio.Text))
            {
                MessageBox.Show("El servicio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombreServicio.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Txt_NumSesion.Text))
            {
                MessageBox.Show("El numero de sesion es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NumSesion.Focus();
                return false;
            }

            return true;
        }
        private Paquete_Servicio fun_capturar()
        {
            return new Paquete_Servicio
            {
                iId = string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text)
               ? 0
               : int.Parse(Txt_IdPaqueteServicio.Text),

                iNombrePaquete = Cmb_NombrePaquete.SelectedValue == null
               ? 0
               : Convert.ToInt32(Cmb_NombrePaquete.SelectedValue),

                iNombreServicio = Cmb_NombreServicio.SelectedValue == null
               ? 0
               : Convert.ToInt32(Cmb_NombreServicio.SelectedValue),

                iNumSesion = string.IsNullOrWhiteSpace(Txt_NumSesion.Text)
               ? 0
               : int.Parse(Txt_NumSesion.Text),
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
                MessageBox.Show("Servicio asignado a paquete guardado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizardatagriew();
                fun_limpiar();
            }
            /*else
            {
                MessageBox.Show("Verifica los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text))
            {
                MessageBox.Show("Selecciona un registro a actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CAMBIO: Validación estricta de todos los obligatorios
            if (!fun_validar_obligatorios()) return;

            // NUEVO: Confirmación de modificación
            var conf = MessageBox.Show("¿Deseas modificar el servicios asignado a un paquete seleccionado?", "Confirmación",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            var s = fun_capturar();

            if (cn.pro_actualizar(s))
            {
                MessageBox.Show("Servicio asignado a un paquete actualizado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            DataTable dt = cn.fun_buscar_paquetes_servicios(Txt_Buscar.Text.Trim());
            Dgv_PaquetesServicios.DataSource = dt;
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text)) return;

            int iId = int.Parse(Txt_IdPaqueteServicio.Text);

            if (MessageBox.Show("¿Eliminar el servicio asignado a paquete seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (cn.pro_eliminar(iId)) // tu método ODBC
                    {
                        MessageBox.Show("Servicio asignado a paquete eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("No se puede eliminar este serivicio asignado a paquete porque está relacionado con otra tabla.",
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
