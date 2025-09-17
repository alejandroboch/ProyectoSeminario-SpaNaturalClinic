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

        Controlador cn = new Controlador();

        public Form_citas()
        {
            InitializeComponent();
        }

        private void Form_citas_Load(object sender, EventArgs e)
        {

        }

        private void Btn_asignarServicios_Click(object sender, EventArgs e)
        {
            // 1. Crea una nueva instancia del formulario que quieres abrir.
            Form_asignarServicios_aCita formAsignarServicios = new Form_asignarServicios_aCita();

            // 2. Muestra el formulario.
            formAsignarServicios.Show();
        }
    }
}
