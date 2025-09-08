
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
            this.Lbl_Buscar = new System.Windows.Forms.Label();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            this.Lbl_Servicio = new System.Windows.Forms.Label();
            this.Txt_Servicio = new System.Windows.Forms.TextBox();
            this.Cmb_Cliente = new System.Windows.Forms.ComboBox();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Monto = new System.Windows.Forms.Label();
            this.Txt_Monto = new System.Windows.Forms.TextBox();
            this.Lbl_Obs = new System.Windows.Forms.Label();
            this.Txt_Obs = new System.Windows.Forms.TextBox();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Dgv_Seguimiento = new System.Windows.Forms.DataGridView();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.Txt_Id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Seguimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Buscar
            // 
            this.Lbl_Buscar.AutoSize = true;
            this.Lbl_Buscar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Buscar.Location = new System.Drawing.Point(491, 70);
            this.Lbl_Buscar.Name = "Lbl_Buscar";
            this.Lbl_Buscar.Size = new System.Drawing.Size(69, 23);
            this.Lbl_Buscar.TabIndex = 30;
            this.Lbl_Buscar.Text = "Buscar";
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(348, 107);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(378, 22);
            this.Txt_Buscar.TabIndex = 23;
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Clientes.Location = new System.Drawing.Point(478, 9);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(228, 28);
            this.Lbl_Clientes.TabIndex = 33;
            this.Lbl_Clientes.Text = "Clientes Frecuentes";
            // 
            // Lbl_Servicio
            // 
            this.Lbl_Servicio.AutoSize = true;
            this.Lbl_Servicio.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Servicio.Location = new System.Drawing.Point(63, 342);
            this.Lbl_Servicio.Name = "Lbl_Servicio";
            this.Lbl_Servicio.Size = new System.Drawing.Size(80, 23);
            this.Lbl_Servicio.TabIndex = 37;
            this.Lbl_Servicio.Text = "Servicio";
            // 
            // Txt_Servicio
            // 
            this.Txt_Servicio.Location = new System.Drawing.Point(210, 342);
            this.Txt_Servicio.Name = "Txt_Servicio";
            this.Txt_Servicio.Size = new System.Drawing.Size(167, 22);
            this.Txt_Servicio.TabIndex = 34;
            // 
            // Cmb_Cliente
            // 
            this.Cmb_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Cliente.FormattingEnabled = true;
            this.Cmb_Cliente.Location = new System.Drawing.Point(210, 223);
            this.Cmb_Cliente.Name = "Cmb_Cliente";
            this.Cmb_Cliente.Size = new System.Drawing.Size(167, 24);
            this.Cmb_Cliente.TabIndex = 38;
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fecha.Location = new System.Drawing.Point(210, 282);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(167, 22);
            this.Dtp_Fecha.TabIndex = 39;
            // 
            // Lbl_Monto
            // 
            this.Lbl_Monto.AutoSize = true;
            this.Lbl_Monto.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Monto.Location = new System.Drawing.Point(63, 404);
            this.Lbl_Monto.Name = "Lbl_Monto";
            this.Lbl_Monto.Size = new System.Drawing.Size(66, 23);
            this.Lbl_Monto.TabIndex = 41;
            this.Lbl_Monto.Text = "Monto";
            // 
            // Txt_Monto
            // 
            this.Txt_Monto.Location = new System.Drawing.Point(210, 404);
            this.Txt_Monto.Name = "Txt_Monto";
            this.Txt_Monto.Size = new System.Drawing.Size(167, 22);
            this.Txt_Monto.TabIndex = 40;
            // 
            // Lbl_Obs
            // 
            this.Lbl_Obs.AutoSize = true;
            this.Lbl_Obs.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Obs.Location = new System.Drawing.Point(63, 474);
            this.Lbl_Obs.Name = "Lbl_Obs";
            this.Lbl_Obs.Size = new System.Drawing.Size(118, 23);
            this.Lbl_Obs.TabIndex = 43;
            this.Lbl_Obs.Text = "Observación";
            // 
            // Txt_Obs
            // 
            this.Txt_Obs.Location = new System.Drawing.Point(210, 474);
            this.Txt_Obs.Multiline = true;
            this.Txt_Obs.Name = "Txt_Obs";
            this.Txt_Obs.Size = new System.Drawing.Size(167, 22);
            this.Txt_Obs.TabIndex = 42;
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Cliente.Location = new System.Drawing.Point(63, 224);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(70, 23);
            this.Lbl_Cliente.TabIndex = 44;
            this.Lbl_Cliente.Text = "Cliente";
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Fecha.Location = new System.Drawing.Point(63, 281);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(60, 23);
            this.Lbl_Fecha.TabIndex = 45;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Ayuda.FlatAppearance.BorderSize = 0;
            this.Btn_Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ayuda.Image = global::Capa_Vista_Seguimiento.Properties.Resources.AYUDA_V4;
            this.Btn_Ayuda.Location = new System.Drawing.Point(1050, 59);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(70, 70);
            this.Btn_Ayuda.TabIndex = 32;
            this.Btn_Ayuda.Text = "button2";
            this.Btn_Ayuda.UseVisualStyleBackColor = false;
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Reporte.FlatAppearance.BorderSize = 0;
            this.Btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Reporte.Image = global::Capa_Vista_Seguimiento.Properties.Resources.impresora;
            this.Btn_Reporte.Location = new System.Drawing.Point(974, 59);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(70, 70);
            this.Btn_Reporte.TabIndex = 31;
            this.Btn_Reporte.Text = "button1";
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.Image = global::Capa_Vista_Seguimiento.Properties.Resources.CANCELAR_V4;
            this.Btn_Cancelar.Location = new System.Drawing.Point(898, 59);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(70, 70);
            this.Btn_Cancelar.TabIndex = 29;
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar.Image = global::Capa_Vista_Seguimiento.Properties.Resources.BORRAR_V4;
            this.Btn_Eliminar.Location = new System.Drawing.Point(822, 59);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(70, 70);
            this.Btn_Eliminar.TabIndex = 28;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Actualizar.FlatAppearance.BorderSize = 0;
            this.Btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Actualizar.Image = global::Capa_Vista_Seguimiento.Properties.Resources.ACTUALIZAR_V4;
            this.Btn_Actualizar.Location = new System.Drawing.Point(257, 59);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(70, 70);
            this.Btn_Actualizar.TabIndex = 27;
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Guardar.FlatAppearance.BorderSize = 0;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.Image = global::Capa_Vista_Seguimiento.Properties.Resources.guardar;
            this.Btn_Guardar.Location = new System.Drawing.Point(177, 59);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(70, 70);
            this.Btn_Guardar.TabIndex = 26;
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Nuevo.FlatAppearance.BorderSize = 0;
            this.Btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Nuevo.Image = global::Capa_Vista_Seguimiento.Properties.Resources.INGRESAR_V4;
            this.Btn_Nuevo.Location = new System.Drawing.Point(95, 59);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(70, 70);
            this.Btn_Nuevo.TabIndex = 25;
            this.Btn_Nuevo.UseVisualStyleBackColor = false;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Buscar.FlatAppearance.BorderSize = 0;
            this.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Buscar.Image = global::Capa_Vista_Seguimiento.Properties.Resources.BUCAR_V4;
            this.Btn_Buscar.Location = new System.Drawing.Point(746, 59);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(70, 70);
            this.Btn_Buscar.TabIndex = 24;
            this.Btn_Buscar.UseVisualStyleBackColor = false;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Dgv_Seguimiento
            // 
            this.Dgv_Seguimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Seguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Seguimiento.Location = new System.Drawing.Point(415, 165);
            this.Dgv_Seguimiento.Name = "Dgv_Seguimiento";
            this.Dgv_Seguimiento.RowHeadersWidth = 51;
            this.Dgv_Seguimiento.RowTemplate.Height = 24;
            this.Dgv_Seguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Seguimiento.Size = new System.Drawing.Size(716, 402);
            this.Dgv_Seguimiento.TabIndex = 46;
            this.Dgv_Seguimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Seguimiento_CellContentClick);
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.AutoSize = true;
            this.Lbl_Id.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Id.Location = new System.Drawing.Point(63, 166);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.Size = new System.Drawing.Size(27, 23);
            this.Lbl_Id.TabIndex = 48;
            this.Lbl_Id.Text = "Id";
            // 
            // Txt_Id
            // 
            this.Txt_Id.Location = new System.Drawing.Point(210, 166);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.Size = new System.Drawing.Size(167, 22);
            this.Txt_Id.TabIndex = 47;
            // 
            // SeguimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 634);
            this.Controls.Add(this.Lbl_Id);
            this.Controls.Add(this.Txt_Id);
            this.Controls.Add(this.Dgv_Seguimiento);
            this.Controls.Add(this.Lbl_Fecha);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.Lbl_Obs);
            this.Controls.Add(this.Txt_Obs);
            this.Controls.Add(this.Lbl_Monto);
            this.Controls.Add(this.Txt_Monto);
            this.Controls.Add(this.Dtp_Fecha);
            this.Controls.Add(this.Cmb_Cliente);
            this.Controls.Add(this.Lbl_Servicio);
            this.Controls.Add(this.Txt_Servicio);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Reporte);
            this.Controls.Add(this.Lbl_Buscar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Actualizar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Name = "SeguimientoForm";
            this.Text = "Seguimiento";
            this.Load += new System.EventHandler(this.SeguimientoForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Seguimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Label Lbl_Buscar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Actualizar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Label Lbl_Clientes;
        private System.Windows.Forms.Label Lbl_Servicio;
        private System.Windows.Forms.TextBox Txt_Servicio;
        private System.Windows.Forms.ComboBox Cmb_Cliente;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Label Lbl_Monto;
        private System.Windows.Forms.TextBox Txt_Monto;
        private System.Windows.Forms.Label Lbl_Obs;
        private System.Windows.Forms.TextBox Txt_Obs;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.DataGridView Dgv_Seguimiento;
        private System.Windows.Forms.Label Lbl_Id;
        private System.Windows.Forms.TextBox Txt_Id;
    }
}