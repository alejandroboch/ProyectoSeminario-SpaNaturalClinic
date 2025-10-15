
namespace Capa_Vista_PaqServ
{
    partial class Paquetes_Con_Servicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paquetes_Con_Servicio));
            this.Lbl_PaquetesServicio = new System.Windows.Forms.Label();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Txt_NumSesion = new System.Windows.Forms.TextBox();
            this.Lbl_NumSesion = new System.Windows.Forms.Label();
            this.Txt_IdPaqueteServicio = new System.Windows.Forms.TextBox();
            this.Lbl_NombreServicio = new System.Windows.Forms.Label();
            this.Lbl_NombrePaquete = new System.Windows.Forms.Label();
            this.Lbl_IdPaqueteServicio = new System.Windows.Forms.Label();
            this.Dgv_PaquetesServicios = new System.Windows.Forms.DataGridView();
            this.Cmb_NombrePaquete = new System.Windows.Forms.ComboBox();
            this.Cmb_NombreServicio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PaquetesServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_PaquetesServicio
            // 
            this.Lbl_PaquetesServicio.AutoSize = true;
            this.Lbl_PaquetesServicio.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PaquetesServicio.Location = new System.Drawing.Point(457, 32);
            this.Lbl_PaquetesServicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_PaquetesServicio.Name = "Lbl_PaquetesServicio";
            this.Lbl_PaquetesServicio.Size = new System.Drawing.Size(327, 28);
            this.Lbl_PaquetesServicio.TabIndex = 2;
            this.Lbl_PaquetesServicio.Text = "Asignar Servicios a Paquetes";
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Ayuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.BackgroundImage")));
            this.Btn_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Ayuda.Location = new System.Drawing.Point(1029, 107);
            this.Btn_Ayuda.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(85, 80);
            this.Btn_Ayuda.TabIndex = 30;
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Reporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Reporte.BackgroundImage")));
            this.Btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Reporte.Location = new System.Drawing.Point(936, 107);
            this.Btn_Reporte.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(85, 80);
            this.Btn_Reporte.TabIndex = 29;
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Cancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Cancelar.BackgroundImage")));
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Cancelar.Location = new System.Drawing.Point(843, 107);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(85, 80);
            this.Btn_Cancelar.TabIndex = 28;
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar.BackgroundImage")));
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Eliminar.Location = new System.Drawing.Point(749, 107);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(85, 80);
            this.Btn_Eliminar.TabIndex = 27;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Buscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.BackgroundImage")));
            this.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Buscar.Location = new System.Drawing.Point(656, 107);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(85, 80);
            this.Btn_Buscar.TabIndex = 26;
            this.Btn_Buscar.UseVisualStyleBackColor = false;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Buscar.Location = new System.Drawing.Point(445, 134);
            this.Lbl_Buscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(69, 23);
            this.Lbl_Buscar.TabIndex = 25;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(321, 162);
            this.Txt_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(325, 22);
            this.Txt_Buscar.TabIndex = 24;
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Actualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Actualizar.BackgroundImage")));
            this.Btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Actualizar.Location = new System.Drawing.Point(228, 107);
            this.Btn_Actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(85, 80);
            this.Btn_Actualizar.TabIndex = 23;
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Guardar.BackgroundImage")));
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Guardar.Location = new System.Drawing.Point(135, 107);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(85, 80);
            this.Btn_Guardar.TabIndex = 22;
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Nuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Nuevo.BackgroundImage")));
            this.Btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Nuevo.Location = new System.Drawing.Point(41, 107);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(85, 80);
            this.Btn_Nuevo.TabIndex = 21;
            this.Btn_Nuevo.UseVisualStyleBackColor = false;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Txt_NumSesion
            // 
            this.Txt_NumSesion.Location = new System.Drawing.Point(253, 418);
            this.Txt_NumSesion.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_NumSesion.Name = "Txt_NumSesion";
            this.Txt_NumSesion.Size = new System.Drawing.Size(187, 22);
            this.Txt_NumSesion.TabIndex = 38;
            // 
            // Lbl_NumSesion
            // 
            this.Lbl_NumSesion.AutoSize = true;
            this.Lbl_NumSesion.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NumSesion.Location = new System.Drawing.Point(36, 417);
            this.Lbl_NumSesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_NumSesion.Name = "Lbl_NumSesion";
            this.Lbl_NumSesion.Size = new System.Drawing.Size(167, 23);
            this.Lbl_NumSesion.TabIndex = 37;
            this.Lbl_NumSesion.Text = "Número de Sesión";
            // 
            // Txt_IdPaqueteServicio
            // 
            this.Txt_IdPaqueteServicio.Location = new System.Drawing.Point(253, 258);
            this.Txt_IdPaqueteServicio.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_IdPaqueteServicio.Name = "Txt_IdPaqueteServicio";
            this.Txt_IdPaqueteServicio.Size = new System.Drawing.Size(187, 22);
            this.Txt_IdPaqueteServicio.TabIndex = 34;
            // 
            // Lbl_NombreServicio
            // 
            this.Lbl_NombreServicio.AutoSize = true;
            this.Lbl_NombreServicio.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NombreServicio.Location = new System.Drawing.Point(36, 366);
            this.Lbl_NombreServicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_NombreServicio.Name = "Lbl_NombreServicio";
            this.Lbl_NombreServicio.Size = new System.Drawing.Size(185, 23);
            this.Lbl_NombreServicio.TabIndex = 33;
            this.Lbl_NombreServicio.Text = "Nombre del Servicio";
            // 
            // Lbl_NombrePaquete
            // 
            this.Lbl_NombrePaquete.AutoSize = true;
            this.Lbl_NombrePaquete.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NombrePaquete.Location = new System.Drawing.Point(36, 315);
            this.Lbl_NombrePaquete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_NombrePaquete.Name = "Lbl_NombrePaquete";
            this.Lbl_NombrePaquete.Size = new System.Drawing.Size(185, 23);
            this.Lbl_NombrePaquete.TabIndex = 32;
            this.Lbl_NombrePaquete.Text = "Nombre del Paquete";
            // 
            // Lbl_IdPaqueteServicio
            // 
            this.Lbl_IdPaqueteServicio.AutoSize = true;
            this.Lbl_IdPaqueteServicio.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_IdPaqueteServicio.Location = new System.Drawing.Point(36, 261);
            this.Lbl_IdPaqueteServicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_IdPaqueteServicio.Name = "Lbl_IdPaqueteServicio";
            this.Lbl_IdPaqueteServicio.Size = new System.Drawing.Size(29, 23);
            this.Lbl_IdPaqueteServicio.TabIndex = 31;
            this.Lbl_IdPaqueteServicio.Text = "ID";
            // 
            // Dgv_PaquetesServicios
            // 
            this.Dgv_PaquetesServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_PaquetesServicios.Location = new System.Drawing.Point(496, 258);
            this.Dgv_PaquetesServicios.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_PaquetesServicios.Name = "Dgv_PaquetesServicios";
            this.Dgv_PaquetesServicios.RowHeadersWidth = 51;
            this.Dgv_PaquetesServicios.Size = new System.Drawing.Size(619, 311);
            this.Dgv_PaquetesServicios.TabIndex = 39;
            this.Dgv_PaquetesServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_PaquetesServicios_CellContentClick);
            // 
            // Cmb_NombrePaquete
            // 
            this.Cmb_NombrePaquete.FormattingEnabled = true;
            this.Cmb_NombrePaquete.Location = new System.Drawing.Point(253, 315);
            this.Cmb_NombrePaquete.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_NombrePaquete.Name = "Cmb_NombrePaquete";
            this.Cmb_NombrePaquete.Size = new System.Drawing.Size(187, 24);
            this.Cmb_NombrePaquete.TabIndex = 40;
            // 
            // Cmb_NombreServicio
            // 
            this.Cmb_NombreServicio.FormattingEnabled = true;
            this.Cmb_NombreServicio.Location = new System.Drawing.Point(253, 367);
            this.Cmb_NombreServicio.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_NombreServicio.Name = "Cmb_NombreServicio";
            this.Cmb_NombreServicio.Size = new System.Drawing.Size(187, 24);
            this.Cmb_NombreServicio.TabIndex = 41;
            // 
            // Paquetes_Con_Servicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 634);
            this.Controls.Add(this.Cmb_NombreServicio);
            this.Controls.Add(this.Cmb_NombrePaquete);
            this.Controls.Add(this.Dgv_PaquetesServicios);
            this.Controls.Add(this.Txt_NumSesion);
            this.Controls.Add(this.Lbl_NumSesion);
            this.Controls.Add(this.Txt_IdPaqueteServicio);
            this.Controls.Add(this.Lbl_NombreServicio);
            this.Controls.Add(this.Lbl_NombrePaquete);
            this.Controls.Add(this.Lbl_IdPaqueteServicio);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Reporte);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Controls.Add(this.Btn_Actualizar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Lbl_PaquetesServicio);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Paquetes_Con_Servicio";
            this.Text = "Paquetes_Con_Servicio";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PaquetesServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_PaquetesServicio;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Button Btn_Actualizar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.TextBox Txt_NumSesion;
        private System.Windows.Forms.Label Lbl_NumSesion;
        private System.Windows.Forms.TextBox Txt_IdPaqueteServicio;
        private System.Windows.Forms.Label Lbl_NombreServicio;
        private System.Windows.Forms.Label Lbl_NombrePaquete;
        private System.Windows.Forms.Label Lbl_IdPaqueteServicio;
        private System.Windows.Forms.DataGridView Dgv_PaquetesServicios;
        private System.Windows.Forms.ComboBox Cmb_NombrePaquete;
        private System.Windows.Forms.ComboBox Cmb_NombreServicio;
    }
}