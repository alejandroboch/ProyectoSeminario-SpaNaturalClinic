using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Pagos;

namespace Capa_Vista_Pagos
{
    public partial class Form_pagos : Form
    {

        Controlador cn = new Controlador();

        public Form_pagos()
        {
            InitializeComponent();
        }

        private void Form_pagos_Load(object sender, EventArgs e)
        {

        }
    }
}
