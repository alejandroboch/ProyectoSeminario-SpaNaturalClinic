
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
            this.Gpb_Form = new System.Windows.Forms.GroupBox();
            this.Gpb_Lista = new System.Windows.Forms.GroupBox();
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Txt_Telefono = new System.Windows.Forms.TextBox();
            this.Txt_Correo = new System.Windows.Forms.TextBox();
            this.Chk_Vip = new System.Windows.Forms.CheckBox();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Dgv_Clientes = new System.Windows.Forms.DataGridView();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Telefono = new System.Windows.Forms.Label();
            this.Lbl_Correo = new System.Windows.Forms.Label();
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // Gpb_Form
            // 
            this.Gpb_Form.Location = new System.Drawing.Point(62, 251);
            this.Gpb_Form.Name = "Gpb_Form";
            this.Gpb_Form.Size = new System.Drawing.Size(200, 100);
            this.Gpb_Form.TabIndex = 0;
            this.Gpb_Form.TabStop = false;
            this.Gpb_Form.Text = "Form";
            // 
            // Gpb_Lista
            // 
            this.Gpb_Lista.Location = new System.Drawing.Point(681, 251);
            this.Gpb_Lista.Name = "Gpb_Lista";
            this.Gpb_Lista.Size = new System.Drawing.Size(200, 100);
            this.Gpb_Lista.TabIndex = 1;
            this.Gpb_Lista.TabStop = false;
            this.Gpb_Lista.Text = "Lista";
            // 
            // Txt_Id
            // 
            this.Txt_Id.Location = new System.Drawing.Point(475, 120);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.Size = new System.Drawing.Size(100, 22);
            this.Txt_Id.TabIndex = 2;
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Location = new System.Drawing.Point(475, 171);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(100, 22);
            this.Txt_Nombre.TabIndex = 3;
            // 
            // Txt_Telefono
            // 
            this.Txt_Telefono.Location = new System.Drawing.Point(475, 220);
            this.Txt_Telefono.Name = "Txt_Telefono";
            this.Txt_Telefono.Size = new System.Drawing.Size(100, 22);
            this.Txt_Telefono.TabIndex = 4;
            // 
            // Txt_Correo
            // 
            this.Txt_Correo.Location = new System.Drawing.Point(475, 274);
            this.Txt_Correo.Name = "Txt_Correo";
            this.Txt_Correo.Size = new System.Drawing.Size(100, 22);
            this.Txt_Correo.TabIndex = 5;
            // 
            // Chk_Vip
            // 
            this.Chk_Vip.AutoSize = true;
            this.Chk_Vip.Location = new System.Drawing.Point(436, 323);
            this.Chk_Vip.Name = "Chk_Vip";
            this.Chk_Vip.Size = new System.Drawing.Size(50, 21);
            this.Chk_Vip.TabIndex = 6;
            this.Chk_Vip.Text = "Vip";
            this.Chk_Vip.UseVisualStyleBackColor = true;
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(404, 40);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(100, 22);
            this.Txt_Buscar.TabIndex = 7;
            this.Txt_Buscar.TextChanged += new System.EventHandler(this.Txt_Buscar_TextChanged);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(539, 38);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 8;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Location = new System.Drawing.Point(122, 416);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(75, 23);
            this.Btn_Nuevo.TabIndex = 9;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(246, 416);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 10;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.Location = new System.Drawing.Point(386, 415);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Actualizar.TabIndex = 11;
            this.Btn_Actualizar.Text = "Actualizar";
            this.Btn_Actualizar.UseVisualStyleBackColor = true;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(539, 415);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Eliminar.TabIndex = 12;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(681, 415);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 13;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Dgv_Clientes
            // 
            this.Dgv_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Clientes.Location = new System.Drawing.Point(144, 461);
            this.Dgv_Clientes.Name = "Dgv_Clientes";
            this.Dgv_Clientes.RowHeadersWidth = 51;
            this.Dgv_Clientes.RowTemplate.Height = 24;
            this.Dgv_Clientes.Size = new System.Drawing.Size(680, 150);
            this.Dgv_Clientes.TabIndex = 14;
            this.Dgv_Clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Clientes_CellContentClick);
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.AutoSize = true;
            this.Lbl_Id.Location = new System.Drawing.Point(363, 124);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.Size = new System.Drawing.Size(21, 17);
            this.Lbl_Id.TabIndex = 15;
            this.Lbl_Id.Text = "ID";
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Location = new System.Drawing.Point(366, 175);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(58, 17);
            this.Lbl_Nombre.TabIndex = 16;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Telefono
            // 
            this.Lbl_Telefono.AutoSize = true;
            this.Lbl_Telefono.Location = new System.Drawing.Point(366, 220);
            this.Lbl_Telefono.Name = "Lbl_Telefono";
            this.Lbl_Telefono.Size = new System.Drawing.Size(64, 17);
            this.Lbl_Telefono.TabIndex = 17;
            this.Lbl_Telefono.Text = "Teléfono";
            // 
            // Lbl_Correo
            // 
            this.Lbl_Correo.AutoSize = true;
            this.Lbl_Correo.Location = new System.Drawing.Point(366, 274);
            this.Lbl_Correo.Name = "Lbl_Correo";
            this.Lbl_Correo.Size = new System.Drawing.Size(51, 17);
            this.Lbl_Correo.TabIndex = 18;
            this.Lbl_Correo.Text = "Correo";
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Location = new System.Drawing.Point(300, 44);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(52, 17);
            this.Lbl_Buscar.TabIndex = 20;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 634);
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
            this.Controls.Add(this.Gpb_Lista);
            this.Controls.Add(this.Gpb_Form);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_Form;
        private System.Windows.Forms.GroupBox Gpb_Lista;
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
    }
}