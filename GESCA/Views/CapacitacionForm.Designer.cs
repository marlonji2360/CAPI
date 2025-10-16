namespace GESCA.Views
{
    partial class CapacitacionForm
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
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.mtbInicio = new System.Windows.Forms.MaskedTextBox();
            this.mtbFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtEstado = new System.Windows.Forms.ComboBox();
            this.cboLugar = new System.Windows.Forms.ComboBox();
            this.cboCapacitador = new System.Windows.Forms.ComboBox();
            this.cboTema = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblLugar = new System.Windows.Forms.Label();
            this.lblCapacitador = new System.Windows.Forms.Label();
            this.lblTema = new System.Windows.Forms.Label();
            this.dgvParticipantes = new System.Windows.Forms.DataGridView();
            this.lblParticipantes = new System.Windows.Forms.Label();
            this.btnCargarParticipantes = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarCapacitador = new System.Windows.Forms.Button();
            this.dgvCapacitadores = new System.Windows.Forms.DataGridView();
            this.btnGenerarDiplomas = new System.Windows.Forms.Button();
            this.lblTipoActividad = new System.Windows.Forms.Label();
            this.txtTipoActividad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(105, 79);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaInicial.TabIndex = 0;
            // 
            // mtbInicio
            // 
            this.mtbInicio.Location = new System.Drawing.Point(105, 105);
            this.mtbInicio.Mask = "00:00";
            this.mtbInicio.Name = "mtbInicio";
            this.mtbInicio.Size = new System.Drawing.Size(44, 20);
            this.mtbInicio.TabIndex = 3;
            // 
            // mtbFinal
            // 
            this.mtbFinal.Location = new System.Drawing.Point(186, 105);
            this.mtbFinal.Mask = "00:00";
            this.mtbFinal.Name = "mtbFinal";
            this.mtbFinal.Size = new System.Drawing.Size(44, 20);
            this.mtbFinal.TabIndex = 4;
            // 
            // txtEstado
            // 
            this.txtEstado.FormattingEnabled = true;
            this.txtEstado.Items.AddRange(new object[] {
            "No Iniciado",
            "Iniciado",
            "Finalizado"});
            this.txtEstado.Location = new System.Drawing.Point(105, 161);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(96, 21);
            this.txtEstado.TabIndex = 5;
            // 
            // cboLugar
            // 
            this.cboLugar.AutoCompleteCustomSource.AddRange(new string[] {
            "No iniciado",
            "En curso",
            "Completado"});
            this.cboLugar.FormattingEnabled = true;
            this.cboLugar.Location = new System.Drawing.Point(245, 161);
            this.cboLugar.Name = "cboLugar";
            this.cboLugar.Size = new System.Drawing.Size(279, 21);
            this.cboLugar.TabIndex = 6;
            // 
            // cboCapacitador
            // 
            this.cboCapacitador.AutoCompleteCustomSource.AddRange(new string[] {
            "No iniciado",
            "En curso",
            "Completado"});
            this.cboCapacitador.FormattingEnabled = true;
            this.cboCapacitador.Location = new System.Drawing.Point(105, 188);
            this.cboCapacitador.Name = "cboCapacitador";
            this.cboCapacitador.Size = new System.Drawing.Size(385, 21);
            this.cboCapacitador.TabIndex = 7;
            // 
            // cboTema
            // 
            this.cboTema.AutoCompleteCustomSource.AddRange(new string[] {
            "No iniciado",
            "En curso",
            "Completado"});
            this.cboTema.FormattingEnabled = true;
            this.cboTema.Location = new System.Drawing.Point(105, 134);
            this.cboTema.Name = "cboTema";
            this.cboTema.Size = new System.Drawing.Size(225, 21);
            this.cboTema.TabIndex = 8;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(76, 83);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(23, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Del";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(249, 108);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(81, 13);
            this.lblDuracion.TabIndex = 10;
            this.lblDuracion.Text = "Duración Horas";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(336, 105);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(96, 20);
            this.txtDuracion.TabIndex = 2;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(67, 108);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(32, 13);
            this.lblInicio.TabIndex = 11;
            this.lblInicio.Text = "Inicio";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(159, 108);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(21, 13);
            this.lblFin.TabIndex = 12;
            this.lblFin.Text = "Fin";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(59, 164);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "Estado";
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.Location = new System.Drawing.Point(207, 164);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(34, 13);
            this.lblLugar.TabIndex = 14;
            this.lblLugar.Text = "Lugar";
            // 
            // lblCapacitador
            // 
            this.lblCapacitador.AutoSize = true;
            this.lblCapacitador.Location = new System.Drawing.Point(35, 191);
            this.lblCapacitador.Name = "lblCapacitador";
            this.lblCapacitador.Size = new System.Drawing.Size(64, 13);
            this.lblCapacitador.TabIndex = 15;
            this.lblCapacitador.Text = "Capacitador";
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(65, 137);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(34, 13);
            this.lblTema.TabIndex = 16;
            this.lblTema.Text = "Tema";
            // 
            // dgvParticipantes
            // 
            this.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipantes.Location = new System.Drawing.Point(105, 359);
            this.dgvParticipantes.Name = "dgvParticipantes";
            this.dgvParticipantes.Size = new System.Drawing.Size(419, 153);
            this.dgvParticipantes.TabIndex = 17;
            // 
            // lblParticipantes
            // 
            this.lblParticipantes.AutoSize = true;
            this.lblParticipantes.Location = new System.Drawing.Point(35, 335);
            this.lblParticipantes.Name = "lblParticipantes";
            this.lblParticipantes.Size = new System.Drawing.Size(68, 13);
            this.lblParticipantes.TabIndex = 18;
            this.lblParticipantes.Text = "Participantes";
            // 
            // btnCargarParticipantes
            // 
            this.btnCargarParticipantes.Location = new System.Drawing.Point(109, 330);
            this.btnCargarParticipantes.Name = "btnCargarParticipantes";
            this.btnCargarParticipantes.Size = new System.Drawing.Size(75, 23);
            this.btnCargarParticipantes.TabIndex = 19;
            this.btnCargarParticipantes.Text = "Cargar";
            this.btnCargarParticipantes.UseVisualStyleBackColor = true;
            this.btnCargarParticipantes.Click += new System.EventHandler(this.btnCargarParticipantes_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(105, 518);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(165, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 37);
            this.lblTitulo.TabIndex = 21;
            this.lblTitulo.Text = "Capacitaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Al";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(274, 79);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaFinal.TabIndex = 22;
            // 
            // btnAgregarCapacitador
            // 
            this.btnAgregarCapacitador.Location = new System.Drawing.Point(496, 188);
            this.btnAgregarCapacitador.Name = "btnAgregarCapacitador";
            this.btnAgregarCapacitador.Size = new System.Drawing.Size(28, 23);
            this.btnAgregarCapacitador.TabIndex = 24;
            this.btnAgregarCapacitador.Text = "+";
            this.btnAgregarCapacitador.UseVisualStyleBackColor = true;
            this.btnAgregarCapacitador.Click += new System.EventHandler(this.btnAgregarCapacitador_Click);
            // 
            // dgvCapacitadores
            // 
            this.dgvCapacitadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapacitadores.Location = new System.Drawing.Point(105, 217);
            this.dgvCapacitadores.Name = "dgvCapacitadores";
            this.dgvCapacitadores.Size = new System.Drawing.Size(419, 98);
            this.dgvCapacitadores.TabIndex = 25;
            // 
            // btnGenerarDiplomas
            // 
            this.btnGenerarDiplomas.Enabled = false;
            this.btnGenerarDiplomas.Location = new System.Drawing.Point(186, 518);
            this.btnGenerarDiplomas.Name = "btnGenerarDiplomas";
            this.btnGenerarDiplomas.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarDiplomas.TabIndex = 26;
            this.btnGenerarDiplomas.Text = "Diplomas";
            this.btnGenerarDiplomas.UseVisualStyleBackColor = true;
            this.btnGenerarDiplomas.Click += new System.EventHandler(this.btnGenerarDiplomas_Click);
            // 
            // lblTipoActividad
            // 
            this.lblTipoActividad.AutoSize = true;
            this.lblTipoActividad.Location = new System.Drawing.Point(347, 137);
            this.lblTipoActividad.Name = "lblTipoActividad";
            this.lblTipoActividad.Size = new System.Drawing.Size(75, 13);
            this.lblTipoActividad.TabIndex = 28;
            this.lblTipoActividad.Text = "Tipo Actividad";
            // 
            // txtTipoActividad
            // 
            this.txtTipoActividad.Location = new System.Drawing.Point(428, 134);
            this.txtTipoActividad.Name = "txtTipoActividad";
            this.txtTipoActividad.Size = new System.Drawing.Size(96, 20);
            this.txtTipoActividad.TabIndex = 29;
            // 
            // CapacitacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 571);
            this.Controls.Add(this.txtTipoActividad);
            this.Controls.Add(this.lblTipoActividad);
            this.Controls.Add(this.btnGenerarDiplomas);
            this.Controls.Add(this.dgvCapacitadores);
            this.Controls.Add(this.btnAgregarCapacitador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCargarParticipantes);
            this.Controls.Add(this.lblParticipantes);
            this.Controls.Add(this.dgvParticipantes);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.lblCapacitador);
            this.Controls.Add(this.lblLugar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cboTema);
            this.Controls.Add(this.cboCapacitador);
            this.Controls.Add(this.cboLugar);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.mtbFinal);
            this.Controls.Add(this.mtbInicio);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.dtpFechaInicial);
            this.Name = "CapacitacionForm";
            this.Text = "Capacitacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.MaskedTextBox mtbInicio;
        private System.Windows.Forms.MaskedTextBox mtbFinal;
        private System.Windows.Forms.ComboBox txtEstado;
        private System.Windows.Forms.ComboBox cboLugar;
        private System.Windows.Forms.ComboBox cboCapacitador;
        private System.Windows.Forms.ComboBox cboTema;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.Label lblCapacitador;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.DataGridView dgvParticipantes;
        private System.Windows.Forms.Label lblParticipantes;
        private System.Windows.Forms.Button btnCargarParticipantes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Button btnAgregarCapacitador;
        private System.Windows.Forms.DataGridView dgvCapacitadores;
        private System.Windows.Forms.Button btnGenerarDiplomas;
        private System.Windows.Forms.Label lblTipoActividad;
        private System.Windows.Forms.TextBox txtTipoActividad;
    }
}