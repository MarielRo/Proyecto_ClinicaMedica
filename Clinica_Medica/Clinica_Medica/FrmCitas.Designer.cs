
namespace Capa_Presentación
{
    partial class FrmCitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCitas));
            this.grbDatosPaciente = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.blCodigo = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.g = new System.Windows.Forms.GroupBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtCodigoMedico = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblCita = new System.Windows.Forms.Label();
            this.txtCita = new System.Windows.Forms.TextBox();
            this.dtpFSalida = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCita = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.grdCitas = new System.Windows.Forms.DataGridView();
            this.ID_CITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.grbDatosPaciente.SuspendLayout();
            this.g.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDatosPaciente
            // 
            this.grbDatosPaciente.Controls.Add(this.textBox2);
            this.grbDatosPaciente.Controls.Add(this.lblEmail);
            this.grbDatosPaciente.Controls.Add(this.txtCodigo);
            this.grbDatosPaciente.Controls.Add(this.txtTelefono);
            this.grbDatosPaciente.Controls.Add(this.txtNombre);
            this.grbDatosPaciente.Controls.Add(this.blCodigo);
            this.grbDatosPaciente.Controls.Add(this.LblNombre);
            this.grbDatosPaciente.Controls.Add(this.lblTelefono);
            this.grbDatosPaciente.Controls.Add(this.btnBuscar);
            this.grbDatosPaciente.Location = new System.Drawing.Point(6, 21);
            this.grbDatosPaciente.Name = "grbDatosPaciente";
            this.grbDatosPaciente.Size = new System.Drawing.Size(886, 125);
            this.grbDatosPaciente.TabIndex = 1;
            this.grbDatosPaciente.TabStop = false;
            this.grbDatosPaciente.Text = "Datos del Paciente";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Info;
            this.txtCodigo.Location = new System.Drawing.Point(214, 36);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(90, 27);
            this.txtCodigo.TabIndex = 7;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.Info;
            this.txtTelefono.Location = new System.Drawing.Point(662, 32);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(132, 27);
            this.txtTelefono.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Info;
            this.txtNombre.Location = new System.Drawing.Point(380, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(203, 27);
            this.txtNombre.TabIndex = 5;
            // 
            // blCodigo
            // 
            this.blCodigo.AutoSize = true;
            this.blCodigo.Location = new System.Drawing.Point(136, 43);
            this.blCodigo.Name = "blCodigo";
            this.blCodigo.Size = new System.Drawing.Size(58, 20);
            this.blCodigo.TabIndex = 4;
            this.blCodigo.Text = "Código";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(310, 43);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(64, 20);
            this.LblNombre.TabIndex = 3;
            this.LblNombre.Text = "Nombre";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(589, 39);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(67, 20);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Teléfono";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(6, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(105, 56);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(214, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(465, 27);
            this.textBox2.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(136, 79);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 20);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // g
            // 
            this.g.Controls.Add(this.txtHora);
            this.g.Controls.Add(this.lblHora);
            this.g.Controls.Add(this.dtpFSalida);
            this.g.Controls.Add(this.lblFechaCita);
            this.g.Controls.Add(this.lblCita);
            this.g.Controls.Add(this.txtCita);
            this.g.Controls.Add(this.comboBox1);
            this.g.Controls.Add(this.label2);
            this.g.Controls.Add(this.lblEspecialidad);
            this.g.Controls.Add(this.txtCodigoMedico);
            this.g.Controls.Add(this.textBox5);
            this.g.Controls.Add(this.label3);
            this.g.Location = new System.Drawing.Point(6, 170);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(886, 181);
            this.g.TabIndex = 2;
            this.g.TabStop = false;
            this.g.Text = "Cita Actual";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(18, 85);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(93, 20);
            this.lblEspecialidad.TabIndex = 9;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtCodigoMedico
            // 
            this.txtCodigoMedico.BackColor = System.Drawing.SystemColors.Info;
            this.txtCodigoMedico.Location = new System.Drawing.Point(389, 26);
            this.txtCodigoMedico.Name = "txtCodigoMedico";
            this.txtCodigoMedico.Size = new System.Drawing.Size(90, 27);
            this.txtCodigoMedico.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Info;
            this.textBox5.Location = new System.Drawing.Point(576, 22);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(218, 27);
            this.textBox5.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código Médico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Médico";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(130, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 28);
            this.comboBox1.TabIndex = 10;
            // 
            // lblCita
            // 
            this.lblCita.AutoSize = true;
            this.lblCita.Location = new System.Drawing.Point(18, 34);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(88, 20);
            this.lblCita.TabIndex = 11;
            this.lblCita.Text = "Código Cita";
            // 
            // txtCita
            // 
            this.txtCita.BackColor = System.Drawing.SystemColors.Info;
            this.txtCita.Location = new System.Drawing.Point(130, 26);
            this.txtCita.Name = "txtCita";
            this.txtCita.Size = new System.Drawing.Size(116, 27);
            this.txtCita.TabIndex = 12;
            // 
            // dtpFSalida
            // 
            this.dtpFSalida.Location = new System.Drawing.Point(511, 80);
            this.dtpFSalida.Name = "dtpFSalida";
            this.dtpFSalida.Size = new System.Drawing.Size(283, 27);
            this.dtpFSalida.TabIndex = 14;
            // 
            // lblFechaCita
            // 
            this.lblFechaCita.AutoSize = true;
            this.lblFechaCita.Location = new System.Drawing.Point(428, 82);
            this.lblFechaCita.Name = "lblFechaCita";
            this.lblFechaCita.Size = new System.Drawing.Size(77, 20);
            this.lblFechaCita.TabIndex = 13;
            this.lblFechaCita.Text = "Fecha Cita";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(18, 139);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(72, 20);
            this.lblHora.TabIndex = 15;
            this.lblHora.Text = "Hora Cita";
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(130, 132);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(125, 27);
            this.txtHora.TabIndex = 16;
            // 
            // grdCitas
            // 
            this.grdCitas.AllowUserToAddRows = false;
            this.grdCitas.AllowUserToDeleteRows = false;
            this.grdCitas.AllowUserToOrderColumns = true;
            this.grdCitas.AllowUserToResizeColumns = false;
            this.grdCitas.AllowUserToResizeRows = false;
            this.grdCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_CITA,
            this.fecha,
            this.paciente,
            this.doctor,
            this.especialidad,
            this.detalle});
            this.grdCitas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdCitas.Location = new System.Drawing.Point(12, 371);
            this.grdCitas.Name = "grdCitas";
            this.grdCitas.RowHeadersWidth = 51;
            this.grdCitas.RowTemplate.Height = 29;
            this.grdCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCitas.Size = new System.Drawing.Size(880, 188);
            this.grdCitas.TabIndex = 3;
            // 
            // ID_CITA
            // 
            this.ID_CITA.HeaderText = "Código Cita";
            this.ID_CITA.MinimumWidth = 6;
            this.ID_CITA.Name = "ID_CITA";
            this.ID_CITA.Width = 125;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "FECHA";
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.Width = 125;
            // 
            // paciente
            // 
            this.paciente.DataPropertyName = "NOMBRE";
            this.paciente.HeaderText = "Paciente";
            this.paciente.MinimumWidth = 6;
            this.paciente.Name = "paciente";
            this.paciente.Width = 125;
            // 
            // doctor
            // 
            this.doctor.DataPropertyName = "NOMBRE";
            this.doctor.HeaderText = "Doctor";
            this.doctor.MinimumWidth = 6;
            this.doctor.Name = "doctor";
            this.doctor.Width = 125;
            // 
            // especialidad
            // 
            this.especialidad.DataPropertyName = "ESPECIALIDAD";
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.MinimumWidth = 6;
            this.especialidad.Name = "especialidad";
            this.especialidad.Width = 125;
            // 
            // detalle
            // 
            this.detalle.DataPropertyName = "DETALLE";
            this.detalle.HeaderText = "Detalle";
            this.detalle.MinimumWidth = 6;
            this.detalle.Name = "detalle";
            this.detalle.Width = 205;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(789, 605);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 56);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.Location = new System.Drawing.Point(174, 605);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 56);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnReservar
            // 
            this.btnReservar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReservar.Image = ((System.Drawing.Image)(resources.GetObject("btnReservar.Image")));
            this.btnReservar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReservar.Location = new System.Drawing.Point(49, 605);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(105, 56);
            this.btnReservar.TabIndex = 6;
            this.btnReservar.Text = "&Guardar";
            this.btnReservar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservar.UseVisualStyleBackColor = false;
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 673);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.grdCitas);
            this.Controls.Add(this.g);
            this.Controls.Add(this.grbDatosPaciente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCitas";
            this.Text = "Citas";
            this.grbDatosPaciente.ResumeLayout(false);
            this.grbDatosPaciente.PerformLayout();
            this.g.ResumeLayout(false);
            this.g.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatosPaciente;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label blCodigo;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox g;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtCodigoMedico;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpFSalida;
        private System.Windows.Forms.Label lblFechaCita;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.TextBox txtCita;
        private System.Windows.Forms.DataGridView grdCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnReservar;
    }
}