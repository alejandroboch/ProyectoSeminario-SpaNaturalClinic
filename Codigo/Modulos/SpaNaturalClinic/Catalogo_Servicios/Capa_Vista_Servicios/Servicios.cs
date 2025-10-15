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
            fun_limpiar();
            Txt_IdServicio.Enabled = false;

            // Tabla
            Dgv_Servicios.AutoGenerateColumns = true;
            Dgv_Servicios.ReadOnly = true;
            Dgv_Servicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Eventos de validación de entrada
            Txt_Buscar.KeyPress += Txt_Buscar_KeyPress_SoloLetras;
            Txt_NombreServicio.KeyPress += Txt_Buscar_KeyPress_SoloLetras;

            // ✅ NUEVO: Validar que solo se ingresen números en el precio
            Txt_PrecioServicio.KeyPress += Txt_PrecioServicio_KeyPress_SoloNumerosYDecimal;

            // Eventos de tabla
            Dgv_Servicios.CellClick += Dgv_Servicios_CellClick;

            // Cuando el cuadro de búsqueda queda vacío, recargar todo
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;

            // ToolTips de botones
            toolTip1.SetToolTip(Btn_Nuevo, "Preparar formulario para nuevo servicio");
            toolTip1.SetToolTip(Btn_Guardar, "Guardar un servicio nuevo");
            toolTip1.SetToolTip(Btn_Actualizar, "Modificar el servicio seleccionado");
            toolTip1.SetToolTip(Btn_Buscar, "Buscar servicios por nombre");
            toolTip1.SetToolTip(Btn_Eliminar, "Eliminar el servicio seleccionado");
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar operación y limpiar formulario");
            toolTip1.SetToolTip(Btn_Reporte, "Generar reporte de servicios");
            toolTip1.SetToolTip(Btn_Ayuda, "Abrir ayuda del módulo");
        }


        // ✅ NUEVO: Método para validar precio
        private void Txt_PrecioServicio_KeyPress_SoloNumerosYDecimal(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esDigito = char.IsDigit(e.KeyChar);
            bool esPuntoOComa = (e.KeyChar == '.' || e.KeyChar == ',');

            // Permitir punto/coma solo si no existe ya uno
            if (esPuntoOComa)
            {
                string texto = Txt_PrecioServicio.Text;
                if (texto.Contains(".") || texto.Contains(","))
                {
                    e.Handled = true; // Ya existe un separador decimal
                    return;
                }
            }

            if (!(esControl || esDigito || esPuntoOComa))
            {
                e.Handled = true; // Bloquear caracteres no válidos
            }
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
        //-------------------BOTONES--------------------------------------------------
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            fun_limpiar();
            fun_estado_edicion(true);
            Txt_NombreServicio.Focus();
        }

        private bool fun_validar_obligatorios()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(Txt_NombreServicio.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_NombreServicio.Focus();
                return false;
            }

            // Validar que el precio no esté vacío
            if (string.IsNullOrWhiteSpace(Txt_PrecioServicio.Text))
            {
                MessageBox.Show("El precio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioServicio.Focus();
                return false;
            }

            // ✅ NUEVO: Validar que el precio sea un número válido
            decimal precio;
            if (!decimal.TryParse(Txt_PrecioServicio.Text.Trim().Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioServicio.Focus();
                return false;
            }

            // ✅ NUEVO: Validar que el precio sea positivo
            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioServicio.Focus();
                return false;
            }

            // ✅ NUEVO: Validar que el precio no sea excesivo (opcional)
            if (precio > 999999.99m)
            {
                MessageBox.Show("El precio no puede ser mayor a 999,999.99", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_PrecioServicio.Focus();
                return false;
            }

            return true;
        }

        private Servicio fun_capturar()
        {
            try
            {
                return new Servicio
                {
                    iId = string.IsNullOrWhiteSpace(Txt_IdServicio.Text)
                            ? 0
                            : int.Parse(Txt_IdServicio.Text),

                    sNombreServicio = Txt_NombreServicio.Text.Trim(),

                    dPrecioServicio = decimal.Parse(
                        Txt_PrecioServicio.Text.Trim().Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture)
                };
            }
            catch (FormatException)
            {
                MessageBox.Show("Error al capturar los datos. Verifica que el precio sea un número válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validación estricta de todos los obligatorios
                if (!fun_validar_obligatorios())
                    return;

                // ✅ Capturar datos con validación
                var s = fun_capturar();

                // ✅ Verificar que la captura fue exitosa
                if (s == null)
                {
                    MessageBox.Show("No se pudieron capturar los datos correctamente.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Intentar guardar
                if (cn.pro_guardar(s))
                {
                    MessageBox.Show("Servicio guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew();
                    fun_limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el servicio. Verifica los datos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OdbcException ex)
            {
                // Errores específicos de base de datos
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Ya existe un servicio con ese nombre.",
                        "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos:\n{ex.Message}",
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el servicio:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_IdServicio.Text))
                {
                    MessageBox.Show("Selecciona un registro a actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ✅ Validación estricta de todos los obligatorios
                if (!fun_validar_obligatorios())
                    return;

                // ✅ Confirmación de modificación
                var conf = MessageBox.Show("¿Deseas modificar el servicio seleccionado?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes)
                    return;

                // ✅ Capturar datos con validación
                var s = fun_capturar();

                // ✅ Verificar que la captura fue exitosa
                if (s == null)
                {
                    MessageBox.Show("No se pudieron capturar los datos correctamente.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Intentar actualizar
                if (cn.pro_actualizar(s))
                {
                    MessageBox.Show("Servicio actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizardatagriew();
                    fun_limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el servicio.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OdbcException ex)
            {
                // Errores específicos de base de datos
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Ya existe un servicio con ese nombre.",
                        "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos:\n{ex.Message}",
                        "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el servicio:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_Reporte reporte = new frm_Reporte();
            reporte.Show();
        }

        private void Dgv_Servicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
