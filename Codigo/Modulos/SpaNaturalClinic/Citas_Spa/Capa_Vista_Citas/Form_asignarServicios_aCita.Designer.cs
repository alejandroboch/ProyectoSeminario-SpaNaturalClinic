﻿
namespace Capa_Vista_Citas
{
    partial class Form_asignarServicios_aCita
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
            this.Lbl_servicio = new System.Windows.Forms.Label();
            this.Lbl_paquete = new System.Windows.Forms.Label();
            this.Gpb_paquete = new System.Windows.Forms.GroupBox();
            this.Nud_numSesion = new System.Windows.Forms.NumericUpDown();
            this.Cbo_paquete = new System.Windows.Forms.ComboBox();
            this.Lbl_numSesion = new System.Windows.Forms.Label();
            this.Lbl_costo = new System.Windows.Forms.Label();
            this.Cbo_servicios = new System.Windows.Forms.ComboBox();
            this.Txt_costo = new System.Windows.Forms.TextBox();
            this.Dgv_asignaciones = new System.Windows.Forms.DataGridView();
            this.Btn_nuevoRegistro = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Cita = new System.Windows.Forms.Label();
            this.Lbl_IDCitas = new System.Windows.Forms.Label();
            this.Lbl_NumeroDeCita = new System.Windows.Forms.Label();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Gpb_paquete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_numSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_asignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(436, 9);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(254, 27);
            this.Lbl_titulo.TabIndex = 0;
            this.Lbl_titulo.Text = "Asignar servicios a cita";
            // 
            // Lbl_servicio
            // 
            this.Lbl_servicio.AutoSize = true;
            this.Lbl_servicio.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_servicio.Location = new System.Drawing.Point(25, 199);
            this.Lbl_servicio.Name = "Lbl_servicio";
            this.Lbl_servicio.Size = new System.Drawing.Size(80, 23);
            this.Lbl_servicio.TabIndex = 1;
            this.Lbl_servicio.Text = "Servicio";
            // 
            // Lbl_paquete
            // 
            this.Lbl_paquete.AutoSize = true;
            this.Lbl_paquete.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_paquete.Location = new System.Drawing.Point(6, 28);
            this.Lbl_paquete.Name = "Lbl_paquete";
            this.Lbl_paquete.Size = new System.Drawing.Size(80, 23);
            this.Lbl_paquete.TabIndex = 2;
            this.Lbl_paquete.Text = "Paquete";
            // 
            // Gpb_paquete
            // 
            this.Gpb_paquete.Controls.Add(this.Nud_numSesion);
            this.Gpb_paquete.Controls.Add(this.Cbo_paquete);
            this.Gpb_paquete.Controls.Add(this.Lbl_paquete);
            this.Gpb_paquete.Controls.Add(this.Lbl_numSesion);
            this.Gpb_paquete.Location = new System.Drawing.Point(19, 238);
            this.Gpb_paquete.Name = "Gpb_paquete";
            this.Gpb_paquete.Size = new System.Drawing.Size(425, 122);
            this.Gpb_paquete.TabIndex = 3;
            this.Gpb_paquete.TabStop = false;
            // 
            // Nud_numSesion
            // 
            this.Nud_numSesion.Location = new System.Drawing.Point(292, 72);
            this.Nud_numSesion.Name = "Nud_numSesion";
            this.Nud_numSesion.Size = new System.Drawing.Size(120, 22);
            this.Nud_numSesion.TabIndex = 6;
            // 
            // Cbo_paquete
            // 
            this.Cbo_paquete.FormattingEnabled = true;
            this.Cbo_paquete.Location = new System.Drawing.Point(130, 25);
            this.Cbo_paquete.Name = "Cbo_paquete";
            this.Cbo_paquete.Size = new System.Drawing.Size(282, 24);
            this.Cbo_paquete.TabIndex = 5;
            this.Cbo_paquete.SelectedIndexChanged += new System.EventHandler(this.Cbo_paquete_SelectedIndexChanged);
            // 
            // Lbl_numSesion
            // 
            this.Lbl_numSesion.AutoSize = true;
            this.Lbl_numSesion.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_numSesion.Location = new System.Drawing.Point(6, 71);
            this.Lbl_numSesion.Name = "Lbl_numSesion";
            this.Lbl_numSesion.Size = new System.Drawing.Size(166, 23);
            this.Lbl_numSesion.TabIndex = 4;
            this.Lbl_numSesion.Text = "Número de sesión";
            // 
            // Lbl_costo
            // 
            this.Lbl_costo.AutoSize = true;
            this.Lbl_costo.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_costo.Location = new System.Drawing.Point(25, 376);
            this.Lbl_costo.Name = "Lbl_costo";
            this.Lbl_costo.Size = new System.Drawing.Size(59, 23);
            this.Lbl_costo.TabIndex = 5;
            this.Lbl_costo.Text = "Costo";
            // 
            // Cbo_servicios
            // 
            this.Cbo_servicios.FormattingEnabled = true;
            this.Cbo_servicios.Location = new System.Drawing.Point(149, 198);
            this.Cbo_servicios.Name = "Cbo_servicios";
            this.Cbo_servicios.Size = new System.Drawing.Size(282, 24);
            this.Cbo_servicios.TabIndex = 6;
            this.Cbo_servicios.SelectedIndexChanged += new System.EventHandler(this.Cbo_servicios_SelectedIndexChanged);
            // 
            // Txt_costo
            // 
            this.Txt_costo.Enabled = false;
            this.Txt_costo.Location = new System.Drawing.Point(258, 377);
            this.Txt_costo.Name = "Txt_costo";
            this.Txt_costo.ReadOnly = true;
            this.Txt_costo.Size = new System.Drawing.Size(173, 22);
            this.Txt_costo.TabIndex = 7;
            // 
            // Dgv_asignaciones
            // 
            this.Dgv_asignaciones.AllowUserToAddRows = false;
            this.Dgv_asignaciones.AllowUserToDeleteRows = false;
            this.Dgv_asignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_asignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_asignaciones.Location = new System.Drawing.Point(468, 199);
            this.Dgv_asignaciones.Name = "Dgv_asignaciones";
            this.Dgv_asignaciones.ReadOnly = true;
            this.Dgv_asignaciones.RowHeadersWidth = 51;
            this.Dgv_asignaciones.RowTemplate.Height = 24;
            this.Dgv_asignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_asignaciones.Size = new System.Drawing.Size(682, 362);
            this.Dgv_asignaciones.TabIndex = 8;
            this.Dgv_asignaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_asignaciones_CellContentClick);
            // 
            // Btn_nuevoRegistro
            // 
            this.Btn_nuevoRegistro.Image = global::Capa_Vista_Citas.Properties.Resources.nuevo_registro_2;
            this.Btn_nuevoRegistro.Location = new System.Drawing.Point(244, 60);
            this.Btn_nuevoRegistro.Name = "Btn_nuevoRegistro";
            this.Btn_nuevoRegistro.Size = new System.Drawing.Size(77, 77);
            this.Btn_nuevoRegistro.TabIndex = 9;
            this.Btn_nuevoRegistro.UseVisualStyleBackColor = false;
            this.Btn_nuevoRegistro.Click += new System.EventHandler(this.Btn_nuevoRegistro_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Image = global::Capa_Vista_Citas.Properties.Resources.guardar_2;
            this.Btn_guardar.Location = new System.Drawing.Point(353, 60);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(77, 77);
            this.Btn_guardar.TabIndex = 10;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Image = global::Capa_Vista_Citas.Properties.Resources.modificar_2;
            this.Btn_modificar.Location = new System.Drawing.Point(464, 60);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(77, 77);
            this.Btn_modificar.TabIndex = 11;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Image = global::Capa_Vista_Citas.Properties.Resources.eliminar_2;
            this.Btn_eliminar.Location = new System.Drawing.Point(571, 60);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(77, 77);
            this.Btn_eliminar.TabIndex = 12;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.Image = global::Capa_Vista_Citas.Properties.Resources.cancelar_2;
            this.Btn_cancelar.Location = new System.Drawing.Point(682, 60);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(77, 77);
            this.Btn_cancelar.TabIndex = 13;
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 14;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Lbl_Cita
            // 
            this.Lbl_Cita.AutoSize = true;
            this.Lbl_Cita.Location = new System.Drawing.Point(81, 469);
            this.Lbl_Cita.Name = "Lbl_Cita";
            this.Lbl_Cita.Size = new System.Drawing.Size(0, 16);
            this.Lbl_Cita.TabIndex = 15;
            // 
            // Lbl_IDCitas
            // 
            this.Lbl_IDCitas.AutoSize = true;
            this.Lbl_IDCitas.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold);
            this.Lbl_IDCitas.Location = new System.Drawing.Point(32, 469);
            this.Lbl_IDCitas.Name = "Lbl_IDCitas";
            this.Lbl_IDCitas.Size = new System.Drawing.Size(87, 27);
            this.Lbl_IDCitas.TabIndex = 16;
            this.Lbl_IDCitas.Text = "ID Cita:";
            // 
            // Lbl_NumeroDeCita
            // 
            this.Lbl_NumeroDeCita.AutoSize = true;
            this.Lbl_NumeroDeCita.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NumeroDeCita.Location = new System.Drawing.Point(145, 475);
            this.Lbl_NumeroDeCita.Name = "Lbl_NumeroDeCita";
            this.Lbl_NumeroDeCita.Size = new System.Drawing.Size(72, 20);
            this.Lbl_NumeroDeCita.TabIndex = 17;
            this.Lbl_NumeroDeCita.Text = "# de cita";
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.Image = global::Capa_Vista_Citas.Properties.Resources.reportes;
            this.Btn_Reporte.Location = new System.Drawing.Point(795, 60);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(77, 77);
            this.Btn_Reporte.TabIndex = 18;
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(120)))));
            this.Btn_Actualizar.Font = new System.Drawing.Font("Cambria", 12F);
            this.Btn_Actualizar.Location = new System.Drawing.Point(711, 159);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(170, 34);
            this.Btn_Actualizar.TabIndex = 19;
            this.Btn_Actualizar.Text = "Actualizar";
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Form_asignarServicios_aCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1162, 583);
            this.Controls.Add(this.Btn_Actualizar);
            this.Controls.Add(this.Btn_Reporte);
            this.Controls.Add(this.Lbl_NumeroDeCita);
            this.Controls.Add(this.Lbl_IDCitas);
            this.Controls.Add(this.Lbl_Cita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Btn_nuevoRegistro);
            this.Controls.Add(this.Dgv_asignaciones);
            this.Controls.Add(this.Txt_costo);
            this.Controls.Add(this.Cbo_servicios);
            this.Controls.Add(this.Lbl_costo);
            this.Controls.Add(this.Gpb_paquete);
            this.Controls.Add(this.Lbl_servicio);
            this.Controls.Add(this.Lbl_titulo);
            this.Name = "Form_asignarServicios_aCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar servicios a cita";
            this.Load += new System.EventHandler(this.Form_asignarServicios_aCita_Load);
            this.Gpb_paquete.ResumeLayout(false);
            this.Gpb_paquete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_numSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_asignaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_titulo;
        private System.Windows.Forms.Label Lbl_servicio;
        private System.Windows.Forms.Label Lbl_paquete;
        private System.Windows.Forms.GroupBox Gpb_paquete;
        private System.Windows.Forms.Label Lbl_numSesion;
        private System.Windows.Forms.Label Lbl_costo;
        private System.Windows.Forms.ComboBox Cbo_paquete;
        private System.Windows.Forms.ComboBox Cbo_servicios;
        private System.Windows.Forms.NumericUpDown Nud_numSesion;
        private System.Windows.Forms.TextBox Txt_costo;
        private System.Windows.Forms.DataGridView Dgv_asignaciones;
        private System.Windows.Forms.Button Btn_nuevoRegistro;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Cita;
        private System.Windows.Forms.Label Lbl_IDCitas;
        private System.Windows.Forms.Label Lbl_NumeroDeCita;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Button Btn_Actualizar;
    }
}