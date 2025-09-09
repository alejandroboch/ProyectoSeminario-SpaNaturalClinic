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
        // Componente para mostrar mensajes de ayuda contextuales.
        private readonly ToolTip tt = new ToolTip();

        public SeguimientoForm()
        {
            InitializeComponent();

            // Asigna el evento de validación para solo permitir letras en los TextBoxes de búsqueda.
            this.Txt_BuscarVip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_SoloLetras_KeyPress);
            this.Txt_BuscarTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_SoloLetras_KeyPress);

            // Asigna el evento para buscar al presionar la tecla "Enter".
            this.Txt_BuscarVip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Buscar_KeyDown);
            this.Txt_BuscarTop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Buscar_KeyDown);
        }

        private void SeguimientoForm_Load(object sender, EventArgs e)
        {
            cargar_datos_completos();
            fun_configurar_tooltips();
            fun_configurar_tabindex();
        }

        private void cargar_datos_completos()
        {
            Txt_BuscarVip.Clear();
            Dgv_Vips.DataSource = cn.fun_cargar_vips();
            formatear_dgv_vips();

            Txt_BuscarTop.Clear();
            Dgv_TopClientes.DataSource = cn.fun_cargar_top_clientes();
            formatear_dgv_top_clientes();
        }

        private void formatear_dgv_vips()
        {
            Dgv_Vips.Columns["nombre"].HeaderText = "Nombre Cliente VIP";
            Dgv_Vips.Columns["telefono"].HeaderText = "Teléfono";
            Dgv_Vips.Columns["correo"].HeaderText = "Correo Electrónico";

            Dgv_Vips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Vips.ReadOnly = true;
        }

        private void formatear_dgv_top_clientes()
        {
            Dgv_TopClientes.Columns["nombre"].HeaderText = "Nombre Cliente";
            Dgv_TopClientes.Columns["total_citas"].HeaderText = "N° de Visitas";
            Dgv_TopClientes.Columns["total_gastado"].HeaderText = "Total Gastado";
            Dgv_TopClientes.Columns["ultima_visita"].HeaderText = "Última Visita";

            Dgv_TopClientes.Columns["total_gastado"].DefaultCellStyle.Format = "c";

            Dgv_TopClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_TopClientes.ReadOnly = true;
        }

        // --- MÉTODOS DE MEJORA DE USABILIDAD ---

        private void fun_configurar_tooltips()
        {
            tt.AutoPopDelay = 5000; // El mensaje dura 5 segundos en pantalla.
            tt.InitialDelay = 500;  // Aparece después de medio segundo.

            tt.SetToolTip(Txt_BuscarVip, "Escriba el nombre de un cliente VIP para filtrar la lista.");
            tt.SetToolTip(Btn_BuscarVip, "Realiza la búsqueda en la lista de Clientes VIP.");
            tt.SetToolTip(Txt_BuscarTop, "Escriba el nombre de un cliente para filtrar el ranking.");
            tt.SetToolTip(Btn_BuscarTop, "Realiza la búsqueda en el ranking de Top Clientes.");
            tt.SetToolTip(Btn_LimpiarBusquedas, "Limpia ambos buscadores y muestra las listas completas.");
            tt.SetToolTip(Dgv_Vips, "Lista de clientes marcados manualmente como VIP.");
            tt.SetToolTip(Dgv_TopClientes, "Ranking de clientes ordenado por cantidad de visitas y total gastado.");
        }

        private void fun_configurar_tabindex()
        {
            // Define el orden en que se moverá el cursor al presionar la tecla TAB.
            Txt_BuscarVip.TabIndex = 0;
            Btn_BuscarVip.TabIndex = 1;
            Txt_BuscarTop.TabIndex = 2;
            Btn_BuscarTop.TabIndex = 3;
            Btn_LimpiarBusquedas.TabIndex = 4;
            Dgv_Vips.TabIndex = 5;
            Dgv_TopClientes.TabIndex = 6;
        }

        private void Txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Txt_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            // Si el usuario presiona la tecla Enter...
            if (e.KeyCode == Keys.Enter)
            {
                // Identificamos qué TextBox disparó el evento.
                TextBox currentTextBox = sender as TextBox;
                if (currentTextBox == Txt_BuscarVip)
                {
                    // Simulamos un clic en el botón de búsqueda de VIPs.
                    Btn_BuscarVip.PerformClick();
                }
                else if (currentTextBox == Txt_BuscarTop)
                {
                    // Simulamos un clic en el botón de búsqueda de Top Clientes.
                    Btn_BuscarTop.PerformClick();
                }

                // Suprimimos el sonido "bip" de Windows al presionar Enter en un TextBox.
                e.SuppressKeyPress = true;
            }
        }

        // --- EVENTOS DE LOS BOTONES ---

        private void Btn_BuscarVip_Click(object sender, EventArgs e)
        {
            Dgv_Vips.DataSource = cn.fun_cargar_vips(Txt_BuscarVip.Text);
            formatear_dgv_vips();
        }

        private void Btn_BuscarTop_Click(object sender, EventArgs e)
        {
            Dgv_TopClientes.DataSource = cn.fun_cargar_top_clientes(Txt_BuscarTop.Text);
            formatear_dgv_top_clientes();
        }

        private void Btn_LimpiarBusquedas_Click(object sender, EventArgs e)
        {
            cargar_datos_completos();
        }
    }
}