namespace Capa_Vista_Seguimiento
{
    partial class SeguimientoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguimientoForm));
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Txt_BuscarVip = new System.Windows.Forms.TextBox();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            this.Dgv_TopClientes = new System.Windows.Forms.DataGridView();
            this.Dgv_Vips = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_BuscarTop = new System.Windows.Forms.TextBox();
            this.Btn_BuscarTop = new System.Windows.Forms.Button();
            this.Btn_LimpiarBusquedas = new System.Windows.Forms.Button();
            this.Btn_BuscarVip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_TopClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Vips)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Buscar.Location = new System.Drawing.Point(153, 80);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(166, 23);
            this.Lbl_Buscar.TabIndex = 30;
            this.Lbl_Buscar.Text = "Buscar Cliente VIP";
            // 
            // Txt_BuscarVip
            // 
            this.Txt_BuscarVip.Location = new System.Drawing.Point(53, 128);
            this.Txt_BuscarVip.Name = "Txt_BuscarVip";
            this.Txt_BuscarVip.Size = new System.Drawing.Size(378, 22);
            this.Txt_BuscarVip.TabIndex = 23;
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Clientes.Location = new System.Drawing.Point(489, 29);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(219, 27);
            this.Lbl_Clientes.TabIndex = 33;
            this.Lbl_Clientes.Text = "Clientes Frecuentes";
            // 
            // Dgv_TopClientes
            // 
            this.Dgv_TopClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_TopClientes.Location = new System.Drawing.Point(606, 165);
            this.Dgv_TopClientes.Name = "Dgv_TopClientes";
            this.Dgv_TopClientes.RowHeadersWidth = 51;
            this.Dgv_TopClientes.RowTemplate.Height = 24;
            this.Dgv_TopClientes.Size = new System.Drawing.Size(532, 402);
            this.Dgv_TopClientes.TabIndex = 46;
            // 
            // Dgv_Vips
            // 
            this.Dgv_Vips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Vips.Location = new System.Drawing.Point(53, 165);
            this.Dgv_Vips.Name = "Dgv_Vips";
            this.Dgv_Vips.RowHeadersWidth = 51;
            this.Dgv_Vips.RowTemplate.Height = 24;
            this.Dgv_Vips.Size = new System.Drawing.Size(532, 402);
            this.Dgv_Vips.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(761, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 23);
            this.label1.TabIndex = 50;
            this.label1.Text = "Buscar en Top Clientes";
            // 
            // Txt_BuscarTop
            // 
            this.Txt_BuscarTop.Location = new System.Drawing.Point(663, 128);
            this.Txt_BuscarTop.Name = "Txt_BuscarTop";
            this.Txt_BuscarTop.Size = new System.Drawing.Size(382, 22);
            this.Txt_BuscarTop.TabIndex = 48;
            // 
            // Btn_BuscarTop
            // 
            this.Btn_BuscarTop.BackColor = System.Drawing.Color.Transparent;
            this.Btn_BuscarTop.BackgroundImage = global::Capa_Vista_Seguimiento.Properties.Resources.buscar;
            this.Btn_BuscarTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_BuscarTop.FlatAppearance.BorderSize = 0;
            this.Btn_BuscarTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OliveDrab;
            this.Btn_BuscarTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_BuscarTop.Location = new System.Drawing.Point(1068, 80);
            this.Btn_BuscarTop.Name = "Btn_BuscarTop";
            this.Btn_BuscarTop.Size = new System.Drawing.Size(70, 70);
            this.Btn_BuscarTop.TabIndex = 49;
            this.Btn_BuscarTop.UseVisualStyleBackColor = false;
            this.Btn_BuscarTop.Click += new System.EventHandler(this.Btn_BuscarTop_Click);
            // 
            // Btn_LimpiarBusquedas
            // 
            this.Btn_LimpiarBusquedas.BackColor = System.Drawing.Color.Transparent;
            this.Btn_LimpiarBusquedas.BackgroundImage = global::Capa_Vista_Seguimiento.Properties.Resources.cancelar;
            this.Btn_LimpiarBusquedas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_LimpiarBusquedas.FlatAppearance.BorderSize = 0;
            this.Btn_LimpiarBusquedas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OliveDrab;
            this.Btn_LimpiarBusquedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LimpiarBusquedas.Location = new System.Drawing.Point(559, 80);
            this.Btn_LimpiarBusquedas.Name = "Btn_LimpiarBusquedas";
            this.Btn_LimpiarBusquedas.Size = new System.Drawing.Size(70, 70);
            this.Btn_LimpiarBusquedas.TabIndex = 28;
            this.Btn_LimpiarBusquedas.UseVisualStyleBackColor = false;
            this.Btn_LimpiarBusquedas.Click += new System.EventHandler(this.Btn_LimpiarBusquedas_Click);
            // 
            // Btn_BuscarVip
            // 
            this.Btn_BuscarVip.BackColor = System.Drawing.Color.Transparent;
            this.Btn_BuscarVip.BackgroundImage = global::Capa_Vista_Seguimiento.Properties.Resources.buscar;
            this.Btn_BuscarVip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_BuscarVip.FlatAppearance.BorderSize = 0;
            this.Btn_BuscarVip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OliveDrab;
            this.Btn_BuscarVip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_BuscarVip.Location = new System.Drawing.Point(450, 80);
            this.Btn_BuscarVip.Name = "Btn_BuscarVip";
            this.Btn_BuscarVip.Size = new System.Drawing.Size(70, 70);
            this.Btn_BuscarVip.TabIndex = 24;
            this.Btn_BuscarVip.UseVisualStyleBackColor = false;
            this.Btn_BuscarVip.Click += new System.EventHandler(this.Btn_BuscarVip_Click);
            // 
            // SeguimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1188, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_BuscarTop);
            this.Controls.Add(this.Txt_BuscarTop);
            this.Controls.Add(this.Dgv_Vips);
            this.Controls.Add(this.Dgv_TopClientes);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Btn_LimpiarBusquedas);
            this.Controls.Add(this.Btn_BuscarVip);
            this.Controls.Add(this.Txt_BuscarVip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeguimientoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento";
            this.Load += new System.EventHandler(this.SeguimientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_TopClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Vips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.Button Btn_LimpiarBusquedas;
        private System.Windows.Forms.Button Btn_BuscarVip;
        private System.Windows.Forms.TextBox Txt_BuscarVip;
        private System.Windows.Forms.Label Lbl_Clientes;
        private System.Windows.Forms.DataGridView Dgv_TopClientes;
        private System.Windows.Forms.DataGridView Dgv_Vips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_BuscarTop;
        private System.Windows.Forms.TextBox Txt_BuscarTop;
    }
}
