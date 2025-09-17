using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        }

        private void postulanteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void mantemientosToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
    }

}
