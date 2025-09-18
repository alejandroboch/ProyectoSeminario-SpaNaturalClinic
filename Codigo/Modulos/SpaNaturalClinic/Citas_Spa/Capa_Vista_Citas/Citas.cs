using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Citas;


namespace Capa_Vista_Citas
{

    public partial class Form_citas : Form
    {
        Controlador logica2;
        private int idSeleccionado = 0;
        private int excepcionActiva = 1;
        private int estadoActivo = 1;
        string valorSeleccionado;
        string valorSeleccionado2;

        //logica logicaSeg = new logica();

        Controlador cn = new Controlador();

        public Form_citas()
        {
            InitializeComponent();
            logica2 = new Controlador();
            CargarDatos();
            ConfigurarControles(false);
            string tabla = "tbl_clientes";
            string campo1 = "pk_id_cliente";
            string campo2 = "nombre";

            // Llama al método para llenar el ComboBox
            llenarseClientes(tabla, campo1, campo2);
            //llenarseApli(tablaApli, campo1Apli, campo2Apli);
        }

        /*********************************Ismar Leonel Cortez Sanchez -0901-21-560*****************************************/
        /**************************************Combo box inteligente 1*****************************************************/

        public void llenarseClientes(string tabla, string campo1, string campo2)
        {
            // Obtén los datos para el ComboBox
            var dt2 = logica2.enviar(tabla, campo1, campo2);

            // Limpia el ComboBox antes de llenarlo
            Cbo_nombreCliente.Items.Clear();

            foreach (DataRow row in dt2.Rows)
            {
                // Agrega el elemento mostrando el formato "ID-Nombre"
                Cbo_nombreCliente.Items.Add(new ComboBoxItem
                {
                    Value = row[campo1].ToString(),
                    Display = row[campo2].ToString()
                });
            }

            // Configura AutoComplete para el ComboBox con el formato deseado
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));
            }

            Cbo_nombreCliente.AutoCompleteCustomSource = coleccion;
            Cbo_nombreCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_nombreCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
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


        private void Cbo_nombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_nombreCliente.SelectedItem != null)
            {
                // Obtener el valor del ValueMember seleccionado
                var selectedItem = (ComboBoxItem)Cbo_nombreCliente.SelectedItem;
                valorSeleccionado = selectedItem.Value;
                // Mostrar el valor en un MessageBox
                MessageBox.Show($"Valor seleccionado: {valorSeleccionado}", "Valor Seleccionado");
            }
        }

        /***************************************************************************************************/


        private void CargarDatos()
        {
            try
            {
                DataTable dt = logica2.funConsultarCitas();
                if (dt != null)
                {
                    Dgv_citas.DataSource = dt;

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

        private void ConfigurarControles(bool habilitar)
        {
            // Habilitar o deshabilitar los controles de texto
            Cbo_nombreCliente.Enabled = habilitar;
            Dtp_fechaCita.Enabled = habilitar;
            Cbo_estadoCita.Enabled = habilitar;


            // Habilitar o deshabilitar los botones


            Btn_guardar.Enabled = habilitar;
            Btn_modificar.Enabled = habilitar;
            Btn_eliminar.Enabled = habilitar;
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            // Buscar el último ID en el DataGridView y sumarle 1
            if (Dgv_citas.Rows.Count > 0)
            {
                int maxId = 0;
                foreach (DataGridViewRow row in Dgv_citas.Rows)
                {
                    if (row.Cells["ID"].Value != null)
                    {
                        int currentId = Convert.ToInt32(row.Cells["ID"].Value);
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



            Cbo_nombreCliente.SelectedIndex = -1;
            Cbo_estadoCita.SelectedIndex = -1;

            //ActualizarBotonExcepcion();
            //ActualizarBotonEstado();
        }
        private void Form_citas_Load(object sender, EventArgs e)
        {
            Cbo_estadoCita.Items.Clear();
            Cbo_estadoCita.Items.Add("Pendiente");
            Cbo_estadoCita.Items.Add("Programada");
            Cbo_estadoCita.Items.Add("En Proceso");
            Cbo_estadoCita.Items.Add("Finalizada");
            Cbo_estadoCita.Items.Add("Cancelada");

            // Estado inicial seleccionado
            Cbo_estadoCita.SelectedIndex = 0;
        }

        private void Btn_asignarServicios_Click(object sender, EventArgs e)
        {
            // 1. Crea una nueva instancia del formulario que quieres abrir.
            Form_asignarServicios_aCita formAsignarServicios = new Form_asignarServicios_aCita();

            // 2. Muestra el formulario.
            formAsignarServicios.Show();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos
                if (
                   Cbo_nombreCliente.SelectedIndex == -1 || Cbo_estadoCita.SelectedIndex == -1
                   )
                {
                    MessageBox.Show("Porfavor seleccione Cliente o Estado");
                    return;
                }

                // Obtener valores de los campos
                //string empleado = cmb_empleado.SelectedItem.ToString();
                string IdCliente = valorSeleccionado;
                DateTime fecha = Dtp_fechaCita.Value;
                string EstadoCita = estadoSeleccionado;

                int Cliente = Convert.ToInt32(IdCliente);
                //float Total = Convert.ToInt32(Txt_total);
                //float SaldoPendiente = Convert.ToInt32(Txt_saldoPendiente);
                float Total = 0;
                float SaldoPendiente = 0;

                float.TryParse(Txt_total.Text, out Total);
                float.TryParse(Txt_saldoPendiente.Text, out SaldoPendiente);
                //string fecha = dtp_fecha.Value.ToString("yyyy-MM-dd");

                // Insertar nuevo registro
                logica2.funcInsertarCita(Cliente,fecha, EstadoCita, Total, SaldoPendiente);
                    MessageBox.Show("Registro insertado exitosamente");
                    //logicaSeg.funinsertarabitacora(idUsuario, "Ingreso una promocion", "Tbl_promociones", "12001");
                    CargarDatos();

        

                LimpiarFormulario();
                ConfigurarControles(false); // Deshabilitar controles después de guardar
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(); // Limpia el formulario
            ConfigurarControles(false); // Deshabilita controles de edición
            CargarDatos();
        }

        private void Btn_nuevoRegistro_Click(object sender, EventArgs e)
        {
            ConfigurarControles(true);
            LimpiarFormulario();

            // Poner valores iniciales en los labels/textbox
            Txt_saldoPendiente.Text = "0.00";
            Txt_total.Text = "0.00";

            //Btn_Editar.Enabled = false;
            Btn_eliminar.Enabled = false;
        }
       string estadoSeleccionado = "";
        private void Cbo_estadoCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_estadoCita.SelectedItem != null)
            {
                estadoSeleccionado = Cbo_estadoCita.SelectedItem.ToString();
       
            }
        }
    }
}
