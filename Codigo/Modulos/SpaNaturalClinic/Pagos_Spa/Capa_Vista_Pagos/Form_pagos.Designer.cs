
namespace Capa_Vista_Pagos
{
    partial class Form_pagos
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
            this.Lbl_numCita = new System.Windows.Forms.Label();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Lbl_fechaCita = new System.Windows.Forms.Label();
            this.Lbl_totalCita = new System.Windows.Forms.Label();
            this.Lbl_saldoPendiente = new System.Windows.Forms.Label();
            this.Lbl_tipoPago = new System.Windows.Forms.Label();
            this.Lbl_montoAcancelar = new System.Windows.Forms.Label();
            this.Cbo_numCita = new System.Windows.Forms.ComboBox();
            this.Txt_cliente = new System.Windows.Forms.TextBox();
            this.Txt_fechaCita = new System.Windows.Forms.TextBox();
            this.Txt_totalCita = new System.Windows.Forms.TextBox();
            this.Txt_saldoPendiente = new System.Windows.Forms.TextBox();
            this.Cbo_tipoPago = new System.Windows.Forms.ComboBox();
            this.Txt_montoAcancelar = new System.Windows.Forms.TextBox();
            this.Dgv_pagos = new System.Windows.Forms.DataGridView();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_editar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_pagos)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(514, 19);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(196, 28);
            this.Lbl_titulo.TabIndex = 0;
            this.Lbl_titulo.Text = "Control de pagos";
            // 
            // Lbl_numCita
            // 
            this.Lbl_numCita.AutoSize = true;
            this.Lbl_numCita.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_numCita.Location = new System.Drawing.Point(21, 189);
            this.Lbl_numCita.Name = "Lbl_numCita";
            this.Lbl_numCita.Size = new System.Drawing.Size(100, 23);
            this.Lbl_numCita.TabIndex = 1;
            this.Lbl_numCita.Text = "No. de cita";
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Cliente.Location = new System.Drawing.Point(24, 246);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(70, 23);
            this.Lbl_Cliente.TabIndex = 2;
            this.Lbl_Cliente.Text = "Cliente";
            // 
            // Lbl_fechaCita
            // 
            this.Lbl_fechaCita.AutoSize = true;
            this.Lbl_fechaCita.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_fechaCita.Location = new System.Drawing.Point(27, 307);
            this.Lbl_fechaCita.Name = "Lbl_fechaCita";
            this.Lbl_fechaCita.Size = new System.Drawing.Size(96, 23);
            this.Lbl_fechaCita.TabIndex = 3;
            this.Lbl_fechaCita.Text = "Fecha cita";
            // 
            // Lbl_totalCita
            // 
            this.Lbl_totalCita.AutoSize = true;
            this.Lbl_totalCita.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_totalCita.Location = new System.Drawing.Point(394, 246);
            this.Lbl_totalCita.Name = "Lbl_totalCita";
            this.Lbl_totalCita.Size = new System.Drawing.Size(89, 23);
            this.Lbl_totalCita.TabIndex = 4;
            this.Lbl_totalCita.Text = "Total cita";
            // 
            // Lbl_saldoPendiente
            // 
            this.Lbl_saldoPendiente.AutoSize = true;
            this.Lbl_saldoPendiente.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_saldoPendiente.Location = new System.Drawing.Point(394, 307);
            this.Lbl_saldoPendiente.Name = "Lbl_saldoPendiente";
            this.Lbl_saldoPendiente.Size = new System.Drawing.Size(148, 23);
            this.Lbl_saldoPendiente.TabIndex = 5;
            this.Lbl_saldoPendiente.Text = "Saldo pendiente";
            // 
            // Lbl_tipoPago
            // 
            this.Lbl_tipoPago.AutoSize = true;
            this.Lbl_tipoPago.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_tipoPago.Location = new System.Drawing.Point(793, 245);
            this.Lbl_tipoPago.Name = "Lbl_tipoPago";
            this.Lbl_tipoPago.Size = new System.Drawing.Size(121, 23);
            this.Lbl_tipoPago.TabIndex = 6;
            this.Lbl_tipoPago.Text = "Tipo de pago";
            // 
            // Lbl_montoAcancelar
            // 
            this.Lbl_montoAcancelar.AutoSize = true;
            this.Lbl_montoAcancelar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_montoAcancelar.Location = new System.Drawing.Point(796, 306);
            this.Lbl_montoAcancelar.Name = "Lbl_montoAcancelar";
            this.Lbl_montoAcancelar.Size = new System.Drawing.Size(156, 23);
            this.Lbl_montoAcancelar.TabIndex = 7;
            this.Lbl_montoAcancelar.Text = "Monto a cancelar";
            // 
            // Cbo_numCita
            // 
            this.Cbo_numCita.FormattingEnabled = true;
            this.Cbo_numCita.Location = new System.Drawing.Point(135, 188);
            this.Cbo_numCita.Name = "Cbo_numCita";
            this.Cbo_numCita.Size = new System.Drawing.Size(241, 24);
            this.Cbo_numCita.TabIndex = 8;
            // 
            // Txt_cliente
            // 
            this.Txt_cliente.Enabled = false;
            this.Txt_cliente.Location = new System.Drawing.Point(135, 246);
            this.Txt_cliente.Name = "Txt_cliente";
            this.Txt_cliente.Size = new System.Drawing.Size(240, 22);
            this.Txt_cliente.TabIndex = 9;
            // 
            // Txt_fechaCita
            // 
            this.Txt_fechaCita.Enabled = false;
            this.Txt_fechaCita.Location = new System.Drawing.Point(135, 307);
            this.Txt_fechaCita.Name = "Txt_fechaCita";
            this.Txt_fechaCita.Size = new System.Drawing.Size(241, 22);
            this.Txt_fechaCita.TabIndex = 10;
            // 
            // Txt_totalCita
            // 
            this.Txt_totalCita.Enabled = false;
            this.Txt_totalCita.Location = new System.Drawing.Point(557, 246);
            this.Txt_totalCita.Name = "Txt_totalCita";
            this.Txt_totalCita.Size = new System.Drawing.Size(223, 22);
            this.Txt_totalCita.TabIndex = 11;
            // 
            // Txt_saldoPendiente
            // 
            this.Txt_saldoPendiente.Enabled = false;
            this.Txt_saldoPendiente.Location = new System.Drawing.Point(557, 307);
            this.Txt_saldoPendiente.Name = "Txt_saldoPendiente";
            this.Txt_saldoPendiente.Size = new System.Drawing.Size(223, 22);
            this.Txt_saldoPendiente.TabIndex = 12;
            // 
            // Cbo_tipoPago
            // 
            this.Cbo_tipoPago.FormattingEnabled = true;
            this.Cbo_tipoPago.Location = new System.Drawing.Point(971, 243);
            this.Cbo_tipoPago.Name = "Cbo_tipoPago";
            this.Cbo_tipoPago.Size = new System.Drawing.Size(223, 24);
            this.Cbo_tipoPago.TabIndex = 13;
            // 
            // Txt_montoAcancelar
            // 
            this.Txt_montoAcancelar.Location = new System.Drawing.Point(971, 307);
            this.Txt_montoAcancelar.Name = "Txt_montoAcancelar";
            this.Txt_montoAcancelar.Size = new System.Drawing.Size(223, 22);
            this.Txt_montoAcancelar.TabIndex = 14;
            // 
            // Dgv_pagos
            // 
            this.Dgv_pagos.AllowUserToAddRows = false;
            this.Dgv_pagos.AllowUserToDeleteRows = false;
            this.Dgv_pagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_pagos.Location = new System.Drawing.Point(28, 353);
            this.Dgv_pagos.Name = "Dgv_pagos";
            this.Dgv_pagos.ReadOnly = true;
            this.Dgv_pagos.RowHeadersWidth = 51;
            this.Dgv_pagos.RowTemplate.Height = 24;
            this.Dgv_pagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_pagos.Size = new System.Drawing.Size(1166, 218);
            this.Dgv_pagos.TabIndex = 15;
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.Image = global::Capa_Vista_Pagos.Properties.Resources.cancelar;
            this.Btn_cancelar.Location = new System.Drawing.Point(803, 75);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(77, 77);
            this.Btn_cancelar.TabIndex = 20;
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Image = global::Capa_Vista_Pagos.Properties.Resources.eliminar;
            this.Btn_eliminar.Location = new System.Drawing.Point(690, 75);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(77, 77);
            this.Btn_eliminar.TabIndex = 19;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            // 
            // Btn_editar
            // 
            this.Btn_editar.Image = global::Capa_Vista_Pagos.Properties.Resources.editar;
            this.Btn_editar.Location = new System.Drawing.Point(574, 75);
            this.Btn_editar.Name = "Btn_editar";
            this.Btn_editar.Size = new System.Drawing.Size(77, 77);
            this.Btn_editar.TabIndex = 18;
            this.Btn_editar.UseVisualStyleBackColor = false;
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Image = global::Capa_Vista_Pagos.Properties.Resources.guardar;
            this.Btn_guardar.Location = new System.Drawing.Point(457, 75);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(77, 77);
            this.Btn_guardar.TabIndex = 17;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.Image = global::Capa_Vista_Pagos.Properties.Resources.nuevo;
            this.Btn_nuevo.Location = new System.Drawing.Point(341, 75);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(77, 77);
            this.Btn_nuevo.TabIndex = 16;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            // 
            // Form_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1222, 583);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_editar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Dgv_pagos);
            this.Controls.Add(this.Txt_montoAcancelar);
            this.Controls.Add(this.Cbo_tipoPago);
            this.Controls.Add(this.Txt_saldoPendiente);
            this.Controls.Add(this.Txt_totalCita);
            this.Controls.Add(this.Txt_fechaCita);
            this.Controls.Add(this.Txt_cliente);
            this.Controls.Add(this.Cbo_numCita);
            this.Controls.Add(this.Lbl_montoAcancelar);
            this.Controls.Add(this.Lbl_tipoPago);
            this.Controls.Add(this.Lbl_saldoPendiente);
            this.Controls.Add(this.Lbl_totalCita);
            this.Controls.Add(this.Lbl_fechaCita);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.Lbl_numCita);
            this.Controls.Add(this.Lbl_titulo);
            this.Name = "Form_pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Form_pagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_pagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_titulo;
        private System.Windows.Forms.Label Lbl_numCita;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Label Lbl_fechaCita;
        private System.Windows.Forms.Label Lbl_totalCita;
        private System.Windows.Forms.Label Lbl_saldoPendiente;
        private System.Windows.Forms.Label Lbl_tipoPago;
        private System.Windows.Forms.Label Lbl_montoAcancelar;
        private System.Windows.Forms.ComboBox Cbo_numCita;
        private System.Windows.Forms.TextBox Txt_cliente;
        private System.Windows.Forms.TextBox Txt_fechaCita;
        private System.Windows.Forms.TextBox Txt_totalCita;
        private System.Windows.Forms.TextBox Txt_saldoPendiente;
        private System.Windows.Forms.ComboBox Cbo_tipoPago;
        private System.Windows.Forms.TextBox Txt_montoAcancelar;
        private System.Windows.Forms.DataGridView Dgv_pagos;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_editar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_cancelar;
    }
}