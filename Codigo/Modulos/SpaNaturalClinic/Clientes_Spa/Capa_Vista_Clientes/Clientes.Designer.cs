
namespace Capa_Vista_Clientes
{
    partial class Clientes
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
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Txt_Telefono = new System.Windows.Forms.TextBox();
            this.Txt_Correo = new System.Windows.Forms.TextBox();
            this.Chk_Vip = new System.Windows.Forms.CheckBox();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Dgv_Clientes = new System.Windows.Forms.DataGridView();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Telefono = new System.Windows.Forms.Label();
            this.Lbl_Correo = new System.Windows.Forms.Label();
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Id
            // 
            this.Txt_Id.Location = new System.Drawing.Point(146, 175);
            this.Txt_Id.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.Size = new System.Drawing.Size(126, 20);
            this.Txt_Id.TabIndex = 2;
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Location = new System.Drawing.Point(146, 216);
            this.Txt_Nombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(126, 20);
            this.Txt_Nombre.TabIndex = 3;
            // 
            // Txt_Telefono
            // 
            this.Txt_Telefono.Location = new System.Drawing.Point(146, 256);
            this.Txt_Telefono.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Telefono.Name = "Txt_Telefono";
            this.Txt_Telefono.Size = new System.Drawing.Size(126, 20);
            this.Txt_Telefono.TabIndex = 4;
            // 
            // Txt_Correo
            // 
            this.Txt_Correo.Location = new System.Drawing.Point(146, 300);
            this.Txt_Correo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Correo.Name = "Txt_Correo";
            this.Txt_Correo.Size = new System.Drawing.Size(126, 20);
            this.Txt_Correo.TabIndex = 5;
            // 
            // Chk_Vip
            // 
            this.Chk_Vip.AutoSize = true;
            this.Chk_Vip.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_Vip.Location = new System.Drawing.Point(107, 340);
            this.Chk_Vip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Chk_Vip.Name = "Chk_Vip";
            this.Chk_Vip.Size = new System.Drawing.Size(51, 23);
            this.Chk_Vip.TabIndex = 6;
            this.Chk_Vip.Text = "Vip";
            this.Chk_Vip.UseVisualStyleBackColor = true;
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(252, 124);
            this.Txt_Buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(284, 20);
            this.Txt_Buscar.TabIndex = 7;
            this.Txt_Buscar.TextChanged += new System.EventHandler(this.Txt_Buscar_TextChanged);
            // 
            // Dgv_Clientes
            // 
            this.Dgv_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Clientes.Location = new System.Drawing.Point(294, 168);
            this.Dgv_Clientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dgv_Clientes.Name = "Dgv_Clientes";
            this.Dgv_Clientes.RowHeadersWidth = 51;
            this.Dgv_Clientes.RowTemplate.Height = 24;
            this.Dgv_Clientes.Size = new System.Drawing.Size(537, 327);
            this.Dgv_Clientes.TabIndex = 14;
            this.Dgv_Clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Clientes_CellContentClick);
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.AutoSize = true;
            this.Lbl_Id.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Id.Location = new System.Drawing.Point(62, 178);
            this.Lbl_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.Size = new System.Drawing.Size(25, 19);
            this.Lbl_Id.TabIndex = 15;
            this.Lbl_Id.Text = "ID";
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(64, 219);
            this.Lbl_Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(66, 19);
            this.Lbl_Nombre.TabIndex = 16;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Telefono
            // 
            this.Lbl_Telefono.AutoSize = true;
            this.Lbl_Telefono.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Telefono.Location = new System.Drawing.Point(64, 256);
            this.Lbl_Telefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Telefono.Name = "Lbl_Telefono";
            this.Lbl_Telefono.Size = new System.Drawing.Size(69, 19);
            this.Lbl_Telefono.TabIndex = 17;
            this.Lbl_Telefono.Text = "Teléfono";
            // 
            // Lbl_Correo
            // 
            this.Lbl_Correo.AutoSize = true;
            this.Lbl_Correo.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Correo.Location = new System.Drawing.Point(64, 300);
            this.Lbl_Correo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Correo.Name = "Lbl_Correo";
            this.Lbl_Correo.Size = new System.Drawing.Size(58, 19);
            this.Lbl_Correo.TabIndex = 18;
            this.Lbl_Correo.Text = "Correo";
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Buscar.Location = new System.Drawing.Point(359, 94);
            this.Lbl_Buscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(57, 19);
            this.Lbl_Buscar.TabIndex = 20;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Ayuda.FlatAppearance.BorderSize = 0;
            this.Btn_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ayuda.Image = global::Capa_Vista_Clientes.Properties.Resources.AYUDA_V4;
            this.Btn_Ayuda.Location = new System.Drawing.Point(778, 85);
            this.Btn_Ayuda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(52, 57);
            this.Btn_Ayuda.TabIndex = 22;
            this.Btn_Ayuda.Text = "button2";
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Reporte.FlatAppearance.BorderSize = 0;
            this.Btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Reporte.Image = global::Capa_Vista_Clientes.Properties.Resources.impresora;
            this.Btn_Reporte.Location = new System.Drawing.Point(722, 85);
            this.Btn_Reporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(52, 57);
            this.Btn_Reporte.TabIndex = 21;
            this.Btn_Reporte.Text = "button1";
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.Image = global::Capa_Vista_Clientes.Properties.Resources.CANCELAR_V4;
            this.Btn_Cancelar.Location = new System.Drawing.Point(664, 85);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(52, 57);
            this.Btn_Cancelar.TabIndex = 13;
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar.Image = global::Capa_Vista_Clientes.Properties.Resources.BORRAR_V4;
            this.Btn_Eliminar.Location = new System.Drawing.Point(608, 85);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(52, 57);
            this.Btn_Eliminar.TabIndex = 12;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Actualizar.FlatAppearance.BorderSize = 0;
            this.Btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Actualizar.Image = global::Capa_Vista_Clientes.Properties.Resources.EDITAR_V4;
            this.Btn_Actualizar.Location = new System.Drawing.Point(184, 85);
            this.Btn_Actualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(52, 57);
            this.Btn_Actualizar.TabIndex = 11;
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Guardar.FlatAppearance.BorderSize = 0;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.Image = global::Capa_Vista_Clientes.Properties.Resources.guardar;
            this.Btn_Guardar.Location = new System.Drawing.Point(124, 85);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(52, 57);
            this.Btn_Guardar.TabIndex = 10;
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Nuevo.FlatAppearance.BorderSize = 0;
            this.Btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Nuevo.Image = global::Capa_Vista_Clientes.Properties.Resources.INGRESAR_V4;
            this.Btn_Nuevo.Location = new System.Drawing.Point(62, 85);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(52, 57);
            this.Btn_Nuevo.TabIndex = 9;
            this.Btn_Nuevo.UseVisualStyleBackColor = false;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(185)))), ((int)(((byte)(102)))));
            this.Btn_Buscar.FlatAppearance.BorderSize = 0;
            this.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Buscar.Image = global::Capa_Vista_Clientes.Properties.Resources.BUCAR_V4;
            this.Btn_Buscar.Location = new System.Drawing.Point(550, 85);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(52, 57);
            this.Btn_Buscar.TabIndex = 8;
            this.Btn_Buscar.UseVisualStyleBackColor = false;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Clientes.Location = new System.Drawing.Point(398, 14);
            this.Lbl_Clientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(80, 22);
            this.Lbl_Clientes.TabIndex = 23;
            this.Lbl_Clientes.Text = "Clientes";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(891, 515);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Reporte);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Lbl_Correo);
            this.Controls.Add(this.Lbl_Telefono);
            this.Controls.Add(this.Lbl_Nombre);
            this.Controls.Add(this.Lbl_Id);
            this.Controls.Add(this.Dgv_Clientes);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Actualizar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Controls.Add(this.Chk_Vip);
            this.Controls.Add(this.Txt_Correo);
            this.Controls.Add(this.Txt_Telefono);
            this.Controls.Add(this.Txt_Nombre);
            this.Controls.Add(this.Txt_Id);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txt_Id;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.TextBox Txt_Telefono;
        private System.Windows.Forms.TextBox Txt_Correo;
        private System.Windows.Forms.CheckBox Chk_Vip;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Actualizar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.DataGridView Dgv_Clientes;
        private System.Windows.Forms.Label Lbl_Id;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Telefono;
        private System.Windows.Forms.Label Lbl_Correo;
        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Label Lbl_Clientes;
    }
}