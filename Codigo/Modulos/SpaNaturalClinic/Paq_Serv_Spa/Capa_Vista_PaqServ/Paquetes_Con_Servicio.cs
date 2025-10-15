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
        private readonly ToolTip toolTip1 = new ToolTip();

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

            // ✅ NUEVO: Validar solo números en sesión
            Txt_NumSesion.KeyPress += Txt_NumSesion_KeyPress_SoloNumeros;

            // Eventos de tabla
            Dgv_PaquetesServicios.CellClick += Dgv_PaquetesServicios_CellClick;

            // Cuando el cuadro de búsqueda queda vacío, recargar todo
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;

            // ToolTips de botones
            toolTip1.SetToolTip(Btn_Nuevo, "Preparar formulario para asignar un servicio a un paquete");
            toolTip1.SetToolTip(Btn_Guardar, "Guardar un nuevo servicio asignado al paquete");
            toolTip1.SetToolTip(Btn_Actualizar, "Modificar un servicios asignado al paquete seleccionado");
            toolTip1.SetToolTip(Btn_Buscar, "Buscar un servicio asignado a un paquete por nombre");
            toolTip1.SetToolTip(Btn_Eliminar, "Eliminar un servicio asignado a un paquete seleccionado");
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar operación y limpiar formulario");
            toolTip1.SetToolTip(Btn_Reporte, "Generar reporte de servicios asignados a paquetes");
            toolTip1.SetToolTip(Btn_Ayuda, "Abrir ayuda del módulo");

            // ✅ CARGAR COMBOS
            CargarCombos();
        }

        // ✅ NUEVO: Método para cargar los ComboBox
        private void CargarCombos()
        {
            try
            {
                // Cargar ComboBox de Paquetes
                Cmb_NombrePaquete.DataSource = cn.pro_LlenarCombo("tbl_paquetes", "nombre", "pk_id_paquete");
                Cmb_NombrePaquete.DisplayMember = "nombre";
                Cmb_NombrePaquete.ValueMember = "pk_id_paquete";
                Cmb_NombrePaquete.SelectedIndex = -1;

                // Cargar ComboBox de Servicios
                Cmb_NombreServicio.DataSource = cn.pro_LlenarCombo("tbl_servicios", "nombre", "pk_id_servicio");
                Cmb_NombreServicio.DisplayMember = "nombre";
                Cmb_NombreServicio.ValueMember = "pk_id_servicio";
                Cmb_NombreServicio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los ComboBox:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Validación KeyPress para solo números en sesión
        private void Txt_NumSesion_KeyPress_SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return; // Permitir backspace, delete, etc.

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true; // Bloquear todo excepto números
        }

        private void Txt_Buscar_KeyPress_SoloLetras(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esEspacio = char.IsWhiteSpace(e.KeyChar);

            if (!(esControl || esLetra || esEspacio))
                e.Handled = true;
        }

        private void Txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Buscar.Text))
            {
                actualizardatagriew();
            }
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

        // ✅ MEJORADO: Actualizar DataGridView con columnas ocultas
        public void actualizardatagriew()
        {
            try
            {
                // ✅ Usar el método correcto que incluye las columnas FK
                DataTable dt = cn.obtenerPaquetesServiciosConNombres();
                Dgv_PaquetesServicios.DataSource = dt;

                // ✅ Verificar que las columnas existen antes de configurarlas
                if (Dgv_PaquetesServicios.Columns.Contains("pk_id_paquete_servicio"))
                    Dgv_PaquetesServicios.Columns["pk_id_paquete_servicio"].Visible = false;

                if (Dgv_PaquetesServicios.Columns.Contains("fk_id_paquete"))
                    Dgv_PaquetesServicios.Columns["fk_id_paquete"].Visible = false;

                if (Dgv_PaquetesServicios.Columns.Contains("fk_id_servicio"))
                    Dgv_PaquetesServicios.Columns["fk_id_servicio"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fun_limpiar()
        {
            Txt_IdPaqueteServicio.Clear();
            Cmb_NombrePaquete.SelectedIndex = -1;
            Cmb_NombreServicio.SelectedIndex = -1;
            Txt_NumSesion.Clear();

            // Regresa a modo lectura
            fun_estado_edicion(false);

            // Reiniciar la grilla completa
            actualizardatagriew();
        }

        //------------------------------------BOTONES-------------------------------------
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
            Cmb_NombrePaquete.Focus();
        }

        // ✅ MEJORADO: Validaciones completas
        private bool fun_validar_obligatorios()
        {
            // 1. Validar que se seleccionó un paquete
            if (Cmb_NombrePaquete.SelectedValue == null ||
                string.IsNullOrWhiteSpace(Cmb_NombrePaquete.Text))
            {
                MessageBox.Show("Debe seleccionar un paquete.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombrePaquete.Focus();
                return false;
            }

            // 2. Validar que el ID del paquete sea válido
            int idPaquete;
            if (!int.TryParse(Cmb_NombrePaquete.SelectedValue.ToString(), out idPaquete) || idPaquete <= 0)
            {
                MessageBox.Show("El paquete seleccionado no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombrePaquete.Focus();
                return false;
            }

            // 3. Validar que se seleccionó un servicio
            if (Cmb_NombreServicio.SelectedValue == null ||
                string.IsNullOrWhiteSpace(Cmb_NombreServicio.Text))
            {
                MessageBox.Show("Debe seleccionar un servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombreServicio.Focus();
                return false;
            }

            // 4. Validar que el ID del servicio sea válido
            int idServicio;
            if (!int.TryParse(Cmb_NombreServicio.SelectedValue.ToString(), out idServicio) || idServicio <= 0)
            {
                MessageBox.Show("El servicio seleccionado no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_NombreServicio.Focus();
                return false;
            }

            // 5. Validar número de sesión no vacío
            if (string.IsNullOrWhiteSpace(Txt_NumSesion.Text))
            {
                MessageBox.Show("El número de sesión es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NumSesion.Focus();
                return false;
            }

            // 6. Validar que número de sesión sea entero válido
            int numSesion;
            if (!int.TryParse(Txt_NumSesion.Text.Trim(), out numSesion))
            {
                MessageBox.Show("El número de sesión debe ser un número entero válido (ejemplo: 1, 2, 3...).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NumSesion.Focus();
                Txt_NumSesion.SelectAll();
                return false;
            }

            // 7. Validar que número de sesión sea positivo
            if (numSesion <= 0)
            {
                MessageBox.Show("El número de sesión debe ser mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NumSesion.Focus();
                Txt_NumSesion.SelectAll();
                return false;
            }

            // 8. Validar que número de sesión no sea excesivo
            if (numSesion > 100)
            {
                MessageBox.Show("El número de sesión no puede ser mayor a 100.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NumSesion.Focus();
                Txt_NumSesion.SelectAll();
                return false;
            }

            return true;
        }

        // ✅ MEJORADO: Capturar con try-catch
        private Paquete_Servicio fun_capturar()
        {
            try
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
                           : int.Parse(Txt_NumSesion.Text.Trim())
                };
            }
            catch (FormatException)
            {
                MessageBox.Show("Error al capturar los datos. Verifica que el número de sesión sea válido.",
                    "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Error al capturar los datos de los ComboBox. Asegúrate de seleccionar valores válidos.",
                    "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al capturar datos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

        // ✅ MEJORADO: Guardar con validaciones completas
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación estricta
                if (!fun_validar_obligatorios())
                    return;

                // Capturar datos
                var ps = fun_capturar();

                // Verificar captura exitosa
                if (ps == null)
                {
                    MessageBox.Show("No se pudieron capturar los datos correctamente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar
                if (cn.pro_guardar(ps))
                {
                    MessageBox.Show("Servicio asignado al paquete guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew();
                    fun_limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la asignación. Verifica los datos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OdbcException ex)
            {
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Este servicio ya está asignado a este paquete en esta sesión.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Message.Contains("foreign key"))
                {
                    MessageBox.Show("Error de integridad: El paquete o servicio seleccionado no existe.",
                        "Error de referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos:\n{ex.Message}",
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ MEJORADO: Actualizar con validaciones completas
        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_IdPaqueteServicio.Text))
                {
                    MessageBox.Show("Selecciona un registro a actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validación estricta
                if (!fun_validar_obligatorios())
                    return;

                // Confirmación
                var conf = MessageBox.Show("¿Deseas modificar el servicio asignado al paquete?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes)
                    return;

                // Capturar datos
                var ps = fun_capturar();

                // Verificar captura exitosa
                if (ps == null)
                {
                    MessageBox.Show("No se pudieron capturar los datos correctamente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizar
                if (cn.pro_actualizar(ps))
                {
                    MessageBox.Show("Servicio asignado al paquete actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew();
                    fun_limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la asignación.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OdbcException ex)
            {
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Este servicio ya está asignado a este paquete en esta sesión.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Message.Contains("foreign key"))
                {
                    MessageBox.Show("Error de integridad: El paquete o servicio seleccionado no existe.",
                        "Error de referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos:\n{ex.Message}",
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ CORREGIDO: Búsqueda que funciona
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar búsqueda
                if (!fun_busqueda_valida())
                    return;

                // Buscar
                DataTable dt = cn.fun_buscar_paquetes_servicios(Txt_Buscar.Text.Trim());

                if (dt != null && dt.Rows.Count > 0)
                {
                    Dgv_PaquetesServicios.DataSource = dt;

                    // Actualizar encabezados
                    if (Dgv_PaquetesServicios.Columns.Contains("pk_id_paquete_servicio"))
                        Dgv_PaquetesServicios.Columns["pk_id_paquete_servicio"].HeaderText = "ID";
                    if (Dgv_PaquetesServicios.Columns.Contains("fk_id_paquete"))
                        Dgv_PaquetesServicios.Columns["fk_id_paquete"].Visible = false;
                    if (Dgv_PaquetesServicios.Columns.Contains("fk_id_servicio"))
                        Dgv_PaquetesServicios.Columns["fk_id_servicio"].Visible = false;
                    if (Dgv_PaquetesServicios.Columns.Contains("nombre_paquete"))
                        Dgv_PaquetesServicios.Columns["nombre_paquete"].HeaderText = "Paquete";
                    if (Dgv_PaquetesServicios.Columns.Contains("nombre_servicio"))
                        Dgv_PaquetesServicios.Columns["nombre_servicio"].HeaderText = "Servicio";
                    if (Dgv_PaquetesServicios.Columns.Contains("numero_sesion"))
                        Dgv_PaquetesServicios.Columns["numero_sesion"].HeaderText = "Sesión";

                    MessageBox.Show($"Se encontraron {dt.Rows.Count} resultado(s).",
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados.",
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew(); // Restaurar todos los datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (cn.pro_eliminar(iId))
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
                        MessageBox.Show("No se puede eliminar este servicio asignado a paquete porque está relacionado con otra tabla.",
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

        private void Dgv_PaquetesServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_PaquetesServicios.CurrentRow == null) return;

            try
            {
                var r = Dgv_PaquetesServicios.Rows[e.RowIndex];

                // ✅ Cargar ID del Paquete-Servicio
                if (r.Cells["pk_id_paquete_servicio"].Value != null)
                {
                    Txt_IdPaqueteServicio.Text = Convert.ToString(r.Cells["pk_id_paquete_servicio"].Value);
                }

                // ✅ Cargar Paquete en ComboBox
                if (r.Cells["fk_id_paquete"].Value != null)
                {
                    int idPaquete = Convert.ToInt32(r.Cells["fk_id_paquete"].Value);
                    Cmb_NombrePaquete.SelectedValue = idPaquete;
                }

                // ✅ Cargar Servicio en ComboBox  
                if (r.Cells["fk_id_servicio"].Value != null)
                {
                    int idServicio = Convert.ToInt32(r.Cells["fk_id_servicio"].Value);
                    Cmb_NombreServicio.SelectedValue = idServicio;
                }

                // ✅ CORREGIDO: Usar Txt_NumSesion en lugar de Txt_CantSesiones
                if (r.Cells["numero_sesion"].Value != null)
                {
                    Txt_NumSesion.Text = Convert.ToString(r.Cells["numero_sesion"].Value); // ✅ CORREGIDO
                }

                // ✅ CORREGIDO: Usar fun_estado_edicion en lugar de ConfigurarControles
                fun_estado_edicion(true); // ✅ CORREGIDO
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_PaquetesServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Dgv_PaquetesServicios.CurrentRow == null) return;

            try
            {
                var r = Dgv_PaquetesServicios.Rows[e.RowIndex];

                // ✅ Cargar ID
                if (r.Cells["pk_id_paquete_servicio"].Value != null)
                {
                    Txt_IdPaqueteServicio.Text = Convert.ToString(r.Cells["pk_id_paquete_servicio"].Value);
                }

                // ✅ Cargar Paquete en ComboBox usando el ID
                if (r.Cells["fk_id_paquete"].Value != null && r.Cells["fk_id_paquete"].Value != DBNull.Value)
                {
                    int idPaquete = Convert.ToInt32(r.Cells["fk_id_paquete"].Value);
                    Cmb_NombrePaquete.SelectedValue = idPaquete;
                }
                else
                {
                    Cmb_NombrePaquete.SelectedIndex = -1;
                }

                // ✅ Cargar Servicio en ComboBox usando el ID
                if (r.Cells["fk_id_servicio"].Value != null && r.Cells["fk_id_servicio"].Value != DBNull.Value)
                {
                    int idServicio = Convert.ToInt32(r.Cells["fk_id_servicio"].Value);
                    Cmb_NombreServicio.SelectedValue = idServicio;
                }
                else
                {
                    Cmb_NombreServicio.SelectedIndex = -1;
                }

                // ✅ Cargar Número de Sesión
                if (r.Cells["numero_sesion"].Value != null && r.Cells["numero_sesion"].Value != DBNull.Value)
                {
                    int numSesion = Convert.ToInt32(r.Cells["numero_sesion"].Value);
                    Txt_NumSesion.Text = numSesion.ToString();
                }
                else
                {
                    Txt_NumSesion.Text = "";
                }

                // Pasa a modo edición
                fun_estado_edicion(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos:\n{ex.Message}\n\nDetalles:\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}