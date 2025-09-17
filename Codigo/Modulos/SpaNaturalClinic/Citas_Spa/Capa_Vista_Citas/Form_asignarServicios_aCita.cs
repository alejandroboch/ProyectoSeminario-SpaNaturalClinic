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
    public partial class Form_asignarServicios_aCita : Form
    {

        Controlador cn = new Controlador();

        string tabla_cita_servicio = "tbl_cita_servicio";

        public Form_asignarServicios_aCita()
        {
            InitializeComponent();
        }

        //Mostrar los datos Capa Vista
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(tabla_cita_servicio);
            Dgv_asignaciones.DataSource = dt;

            if (Dgv_asignaciones.Columns.Contains("pk_id_cita_servicio"))
                Dgv_asignaciones.Columns["pk_id_cita_servicio"].HeaderText = "ID Asignación Cita-Servicio";
            if (Dgv_asignaciones.Columns.Contains("fk_id_cita"))
                Dgv_asignaciones.Columns["fk_id_cita"].HeaderText = "ID Cita";
            if (Dgv_asignaciones.Columns.Contains("fk_id_servicio"))
                Dgv_asignaciones.Columns["fk_id_servicio"].HeaderText = "ID Servicio";
            if (Dgv_asignaciones.Columns.Contains("numero_sesion"))
                Dgv_asignaciones.Columns["numero_sesion"].HeaderText = "Núm sesión";
            if (Dgv_asignaciones.Columns.Contains("costo"))
                Dgv_asignaciones.Columns["costo"].HeaderText = "Costo";
        }


        private void Form_asignarServicios_aCita_Load(object sender, EventArgs e)
        {
            actualizardatagriew();
        }
    }
}
