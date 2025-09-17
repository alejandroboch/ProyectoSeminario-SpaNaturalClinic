
namespace Capa_Vista_Citas
{
    partial class Form_citas
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
            this.Lbl_titulo = new System.Windows.Forms.Label();
            this.Lbl_cliente = new System.Windows.Forms.Label();
            this.Lbl_fecha = new System.Windows.Forms.Label();
            this.Lbl_estado = new System.Windows.Forms.Label();
            this.Lbl_total = new System.Windows.Forms.Label();
            this.Lbl_saldoPendiente = new System.Windows.Forms.Label();
            this.Dgv_citas = new System.Windows.Forms.DataGridView();
            this.Cbo_nombreCliente = new System.Windows.Forms.ComboBox();
            this.Cbo_estadoCita = new System.Windows.Forms.ComboBox();
            this.Txt_saldoPendiente = new System.Windows.Forms.TextBox();
            this.Txt_total = new System.Windows.Forms.TextBox();
            this.Dtp_fechaCita = new System.Windows.Forms.DateTimePicker();
            this.Btn_asignarServicios = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_nuevoRegistro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_citas)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(388, 21);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(258, 28);
            this.Lbl_titulo.TabIndex = 0;
            this.Lbl_titulo.Text = "Programación de citas";
            this.Lbl_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_cliente
            // 
            this.Lbl_cliente.AutoSize = true;
            this.Lbl_cliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_cliente.Location = new System.Drawing.Point(29, 206);
            this.Lbl_cliente.Name = "Lbl_cliente";
            this.Lbl_cliente.Size = new System.Drawing.Size(70, 23);
            this.Lbl_cliente.TabIndex = 1;
            this.Lbl_cliente.Text = "Cliente";
            // 
            // Lbl_fecha
            // 
            this.Lbl_fecha.AutoSize = true;
            this.Lbl_fecha.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_fecha.Location = new System.Drawing.Point(32, 264);
            this.Lbl_fecha.Name = "Lbl_fecha";
            this.Lbl_fecha.Size = new System.Drawing.Size(60, 23);
            this.Lbl_fecha.TabIndex = 2;
            this.Lbl_fecha.Text = "Fecha";
            // 
            // Lbl_estado
            // 
            this.Lbl_estado.AutoSize = true;
            this.Lbl_estado.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_estado.Location = new System.Drawing.Point(32, 326);
            this.Lbl_estado.Name = "Lbl_estado";
            this.Lbl_estado.Size = new System.Drawing.Size(70, 23);
            this.Lbl_estado.TabIndex = 3;
            this.Lbl_estado.Text = "Estado";
            // 
            // Lbl_total
            // 
            this.Lbl_total.AutoSize = true;
            this.Lbl_total.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_total.Location = new System.Drawing.Point(32, 385);
            this.Lbl_total.Name = "Lbl_total";
            this.Lbl_total.Size = new System.Drawing.Size(53, 23);
            this.Lbl_total.TabIndex = 4;
            this.Lbl_total.Text = "Total";
            // 
            // Lbl_saldoPendiente
            // 
            this.Lbl_saldoPendiente.AutoSize = true;
            this.Lbl_saldoPendiente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_saldoPendiente.Location = new System.Drawing.Point(32, 441);
            this.Lbl_saldoPendiente.Name = "Lbl_saldoPendiente";
            this.Lbl_saldoPendiente.Size = new System.Drawing.Size(148, 23);
            this.Lbl_saldoPendiente.TabIndex = 5;
            this.Lbl_saldoPendiente.Text = "Saldo pendiente";
            // 
            // Dgv_citas
            // 
            this.Dgv_citas.AllowUserToAddRows = false;
            this.Dgv_citas.AllowUserToDeleteRows = false;
            this.Dgv_citas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_citas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_citas.Location = new System.Drawing.Point(436, 205);
            this.Dgv_citas.Name = "Dgv_citas";
            this.Dgv_citas.ReadOnly = true;
            this.Dgv_citas.RowHeadersWidth = 51;
            this.Dgv_citas.RowTemplate.Height = 24;
            this.Dgv_citas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_citas.Size = new System.Drawing.Size(558, 344);
            this.Dgv_citas.TabIndex = 6;
            // 
            // Cbo_nombreCliente
            // 
            this.Cbo_nombreCliente.FormattingEnabled = true;
            this.Cbo_nombreCliente.Location = new System.Drawing.Point(160, 205);
            this.Cbo_nombreCliente.Name = "Cbo_nombreCliente";
            this.Cbo_nombreCliente.Size = new System.Drawing.Size(246, 24);
            this.Cbo_nombreCliente.TabIndex = 7;
            // 
            // Cbo_estadoCita
            // 
            this.Cbo_estadoCita.FormattingEnabled = true;
            this.Cbo_estadoCita.Location = new System.Drawing.Point(160, 325);
            this.Cbo_estadoCita.Name = "Cbo_estadoCita";
            this.Cbo_estadoCita.Size = new System.Drawing.Size(246, 24);
            this.Cbo_estadoCita.TabIndex = 8;
            // 
            // Txt_saldoPendiente
            // 
            this.Txt_saldoPendiente.Location = new System.Drawing.Point(234, 442);
            this.Txt_saldoPendiente.Name = "Txt_saldoPendiente";
            this.Txt_saldoPendiente.ReadOnly = true;
            this.Txt_saldoPendiente.Size = new System.Drawing.Size(172, 22);
            this.Txt_saldoPendiente.TabIndex = 9;
            // 
            // Txt_total
            // 
            this.Txt_total.Location = new System.Drawing.Point(234, 385);
            this.Txt_total.Name = "Txt_total";
            this.Txt_total.ReadOnly = true;
            this.Txt_total.Size = new System.Drawing.Size(172, 22);
            this.Txt_total.TabIndex = 10;
            // 
            // Dtp_fechaCita
            // 
            this.Dtp_fechaCita.Location = new System.Drawing.Point(160, 265);
            this.Dtp_fechaCita.Name = "Dtp_fechaCita";
            this.Dtp_fechaCita.Size = new System.Drawing.Size(246, 22);
            this.Dtp_fechaCita.TabIndex = 11;
            // 
            // Btn_asignarServicios
            // 
            this.Btn_asignarServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_asignarServicios.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_asignarServicios.Location = new System.Drawing.Point(234, 509);
            this.Btn_asignarServicios.Name = "Btn_asignarServicios";
            this.Btn_asignarServicios.Size = new System.Drawing.Size(171, 40);
            this.Btn_asignarServicios.TabIndex = 18;
            this.Btn_asignarServicios.Text = "Asignar servicios";
            this.Btn_asignarServicios.UseVisualStyleBackColor = false;
            this.Btn_asignarServicios.Click += new System.EventHandler(this.Btn_asignarServicios_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.Image = global::Capa_Vista_Citas.Properties.Resources.cancelar_2;
            this.Btn_cancelar.Location = new System.Drawing.Point(722, 87);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(75, 77);
            this.Btn_cancelar.TabIndex = 17;
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Image = global::Capa_Vista_Citas.Properties.Resources.eliminar_2;
            this.Btn_eliminar.Location = new System.Drawing.Point(623, 87);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(75, 77);
            this.Btn_eliminar.TabIndex = 16;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Image = global::Capa_Vista_Citas.Properties.Resources.buscar_2;
            this.Btn_buscar.Location = new System.Drawing.Point(422, 87);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(75, 77);
            this.Btn_buscar.TabIndex = 15;
            this.Btn_buscar.UseVisualStyleBackColor = false;
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Image = global::Capa_Vista_Citas.Properties.Resources.modificar_2;
            this.Btn_modificar.Location = new System.Drawing.Point(522, 87);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(75, 77);
            this.Btn_modificar.TabIndex = 14;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Image = global::Capa_Vista_Citas.Properties.Resources.guardar_2;
            this.Btn_guardar.Location = new System.Drawing.Point(321, 87);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(75, 77);
            this.Btn_guardar.TabIndex = 13;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            // 
            // Btn_nuevoRegistro
            // 
            this.Btn_nuevoRegistro.Image = global::Capa_Vista_Citas.Properties.Resources.nuevo_registro_2;
            this.Btn_nuevoRegistro.Location = new System.Drawing.Point(219, 87);
            this.Btn_nuevoRegistro.Name = "Btn_nuevoRegistro";
            this.Btn_nuevoRegistro.Size = new System.Drawing.Size(77, 77);
            this.Btn_nuevoRegistro.TabIndex = 12;
            this.Btn_nuevoRegistro.UseVisualStyleBackColor = false;
            // 
            // Form_citas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1026, 583);
            this.Controls.Add(this.Btn_asignarServicios);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Btn_nuevoRegistro);
            this.Controls.Add(this.Dtp_fechaCita);
            this.Controls.Add(this.Txt_total);
            this.Controls.Add(this.Txt_saldoPendiente);
            this.Controls.Add(this.Cbo_estadoCita);
            this.Controls.Add(this.Cbo_nombreCliente);
            this.Controls.Add(this.Dgv_citas);
            this.Controls.Add(this.Lbl_saldoPendiente);
            this.Controls.Add(this.Lbl_total);
            this.Controls.Add(this.Lbl_estado);
            this.Controls.Add(this.Lbl_fecha);
            this.Controls.Add(this.Lbl_cliente);
            this.Controls.Add(this.Lbl_titulo);
            this.Name = "Form_citas";
            this.Text = "Programación de Citas";
            this.Load += new System.EventHandler(this.Form_citas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_citas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_titulo;
        private System.Windows.Forms.Label Lbl_cliente;
        private System.Windows.Forms.Label Lbl_fecha;
        private System.Windows.Forms.Label Lbl_estado;
        private System.Windows.Forms.Label Lbl_total;
        private System.Windows.Forms.Label Lbl_saldoPendiente;
        private System.Windows.Forms.DataGridView Dgv_citas;
        private System.Windows.Forms.ComboBox Cbo_nombreCliente;
        private System.Windows.Forms.ComboBox Cbo_estadoCita;
        private System.Windows.Forms.TextBox Txt_saldoPendiente;
        private System.Windows.Forms.TextBox Txt_total;
        private System.Windows.Forms.DateTimePicker Dtp_fechaCita;
        private System.Windows.Forms.Button Btn_nuevoRegistro;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Button Btn_asignarServicios;
    }
}