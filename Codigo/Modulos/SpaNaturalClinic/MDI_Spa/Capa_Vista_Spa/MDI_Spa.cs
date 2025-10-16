using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_Citas;
using Capa_Vista_Seguridad;

namespace Capa_Vista_Spa
{
    public partial class MDI_Spa : Form
    {
        private int childFormNumber = 0;
        string idUsuario;
        private Timer timer;
        public MDI_Spa(string idUsuario)
        {
            InitializeComponent();
            //AjustarPictureBox();
            this.idUsuario = idUsuario;
            lbl_nombreUsuario.Text = idUsuario;
            timer = new Timer();
            timer.Interval = 1000; // 1000 ms = 1 segundo
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_FechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void MDI_Spa_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.BackColor = Color.LightYellow; // o el color que quieras


        }

        //private void AjustarPictureBox()
        //{
        //    if (pictureBox1.Image != null)
        //    {
        //        double relacion = (double)pictureBox1.Image.Width / pictureBox1.Image.Height;
        //        pictureBox1.Width = (int)(pictureBox1.Height * relacion);
        //    }
        //}

        private void CentrarFormulario(Form hijo)
        {
            hijo.StartPosition = FormStartPosition.Manual;
            int x = (this.ClientSize.Width - hijo.Width) / 2;
            int y = (this.ClientSize.Height - hijo.Height) / 2;
            hijo.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
        }

        private void nóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDisciplinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Pagos.Form_pagos GD = new Capa_Vista_Pagos.Form_pagos();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void postulanteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void mantemientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Citas.Form_citas GD = new Form_citas();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();

        }

        private void desarrolloDeCarreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Clientes.Clientes GD = new Capa_Vista_Clientes.Clientes();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void reclutamientoYSelecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Seguimiento.SeguimientoForm GD = new Capa_Vista_Seguimiento.SeguimientoForm();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void capacitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Capa_Vista_Servicios.Servicios GD = new Capa_Vista_Servicios.Servicios();
            //GD.MdiParent = this;
            //CentrarFormulario(GD);
            //GD.Show();
        }

        private void evaluacionDesempeñoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idusuario= lbl_nombreUsuario.Text;
            Capa_Vista_Seguridad.frm_usuarios GD = new Capa_Vista_Seguridad.frm_usuarios(idusuario);
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Servicios.Servicios GD = new Capa_Vista_Servicios.Servicios();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void paquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Paquetes.Paquetes GD = new Capa_Vista_Paquetes.Paquetes();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }



        private void serviciosEnPaquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Capa_Vista_PaqServ.Paquetes_Con_Servicio GD = new Capa_Vista_PaqServ.Paquetes_Con_Servicio();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarAplicacion();
        }

        private void CerrarAplicacion()
        {
            /************Ismar Cortez - 12/10/25****************/
            //Yo comente esto
            //logica l = new logica(idUsuario);
            //l.funinsertarabitacora(idUsuario, "Cerro sesion en el sistema", "Login", "1301");

            // Devolver al FormModulos con el usuario aun en linea Joel López 12/02/2024
            frm_login login = new frm_login();
            login.FormClosed += (s, args) =>
            {
                if (login.DialogResult != DialogResult.OK)
                {
                    Application.Exit();
                }
            };

            // Ocultar la ventana actual
            this.Hide();

            // Mostrar el login
            login.Show();

            // Cerrar el MDI_Seguridad
            this.Close();
            /************************************************************/
        }

        private void detalleCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Citas.Form_asignarServicios_aCita GD = new Form_asignarServicios_aCita();
            GD.MdiParent = this;
            CentrarFormulario(GD);
            GD.Show();
        }

        private void FMDI_Spa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Hay formularios abiertos. ¿Deseas cerrar todo?",
                    "Confirmar cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Environment.Exit(0);
        }

    }

}
