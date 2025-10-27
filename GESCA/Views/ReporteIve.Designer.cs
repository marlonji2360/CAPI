namespace GESCA.Views
{
    partial class ReporteIve
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
            this.dgvCapacitacion = new System.Windows.Forms.DataGridView();
            this.cmbTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.lblTipoBusqueda = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblDel = new System.Windows.Forms.Label();
            this.lblAl = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.dtpDel = new System.Windows.Forms.DateTimePicker();
            this.dtpAl = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnIve = new System.Windows.Forms.Button();
            this.btnDiploma = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCapacitacion
            // 
            this.dgvCapacitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapacitacion.Location = new System.Drawing.Point(18, 369);
            this.dgvCapacitacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCapacitacion.Name = "dgvCapacitacion";
            this.dgvCapacitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapacitacion.Size = new System.Drawing.Size(1164, 305);
            this.dgvCapacitacion.TabIndex = 0;
            // 
            // cmbTipoBusqueda
            // 
            this.cmbTipoBusqueda.FormattingEnabled = true;
            this.cmbTipoBusqueda.Items.AddRange(new object[] {
            "Identificador",
            "Fecha",
            "Lugar",
            "Tema",
            "Tipo Actividad",
            "Capacitador",
            "Duracion",
            "Capacitado",
            "Puesto"});
            this.cmbTipoBusqueda.Location = new System.Drawing.Point(146, 125);
            this.cmbTipoBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoBusqueda.Name = "cmbTipoBusqueda";
            this.cmbTipoBusqueda.Size = new System.Drawing.Size(280, 28);
            this.cmbTipoBusqueda.TabIndex = 1;
            this.cmbTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbTipoBusqueda_SelectedIndexChanged);
            // 
            // lblTipoBusqueda
            // 
            this.lblTipoBusqueda.AutoSize = true;
            this.lblTipoBusqueda.Location = new System.Drawing.Point(18, 129);
            this.lblTipoBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBusqueda.Name = "lblTipoBusqueda";
            this.lblTipoBusqueda.Size = new System.Drawing.Size(116, 20);
            this.lblTipoBusqueda.TabIndex = 2;
            this.lblTipoBusqueda.Text = "Tipo Busqueda";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(72, 178);
            this.lblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(44, 20);
            this.lblValor.TabIndex = 3;
            this.lblValor.Text = "Dato";
            // 
            // lblDel
            // 
            this.lblDel.AutoSize = true;
            this.lblDel.Location = new System.Drawing.Point(84, 178);
            this.lblDel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDel.Name = "lblDel";
            this.lblDel.Size = new System.Drawing.Size(33, 20);
            this.lblDel.TabIndex = 4;
            this.lblDel.Text = "Del";
            this.lblDel.Visible = false;
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.Location = new System.Drawing.Point(462, 178);
            this.lblAl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(23, 20);
            this.lblAl.TabIndex = 5;
            this.lblAl.Text = "Al";
            this.lblAl.Visible = false;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(146, 174);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(280, 26);
            this.txtValor.TabIndex = 6;
            // 
            // dtpDel
            // 
            this.dtpDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDel.Location = new System.Drawing.Point(146, 174);
            this.dtpDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDel.Name = "dtpDel";
            this.dtpDel.Size = new System.Drawing.Size(280, 26);
            this.dtpDel.TabIndex = 7;
            this.dtpDel.Visible = false;
            // 
            // dtpAl
            // 
            this.dtpAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAl.Location = new System.Drawing.Point(495, 174);
            this.dtpAl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpAl.Name = "dtpAl";
            this.dtpAl.Size = new System.Drawing.Size(280, 26);
            this.dtpAl.TabIndex = 8;
            this.dtpAl.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(807, 171);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 35);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(18, 325);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(112, 35);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnIve
            // 
            this.btnIve.Location = new System.Drawing.Point(146, 325);
            this.btnIve.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIve.Name = "btnIve";
            this.btnIve.Size = new System.Drawing.Size(112, 35);
            this.btnIve.TabIndex = 11;
            this.btnIve.Text = "Texto IVE";
            this.btnIve.UseVisualStyleBackColor = true;
            this.btnIve.Click += new System.EventHandler(this.btnIve_Click);
            // 
            // btnDiploma
            // 
            this.btnDiploma.Location = new System.Drawing.Point(374, 325);
            this.btnDiploma.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDiploma.Name = "btnDiploma";
            this.btnDiploma.Size = new System.Drawing.Size(112, 35);
            this.btnDiploma.TabIndex = 12;
            this.btnDiploma.Text = "Diplomas";
            this.btnDiploma.UseVisualStyleBackColor = true;
            this.btnDiploma.Click += new System.EventHandler(this.btnDiploma_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(484, 28);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 37);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Reporte IVE";
            // 
            // ReporteIve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnDiploma);
            this.Controls.Add(this.btnIve);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpAl);
            this.Controls.Add(this.dtpDel);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblAl);
            this.Controls.Add(this.lblDel);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblTipoBusqueda);
            this.Controls.Add(this.cmbTipoBusqueda);
            this.Controls.Add(this.dgvCapacitacion);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReporteIve";
            this.Text = "CapacitacionBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCapacitacion;
        private System.Windows.Forms.ComboBox cmbTipoBusqueda;
        private System.Windows.Forms.Label lblTipoBusqueda;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDel;
        private System.Windows.Forms.Label lblAl;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.DateTimePicker dtpDel;
        private System.Windows.Forms.DateTimePicker dtpAl;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnIve;
        private System.Windows.Forms.Button btnDiploma;
        private System.Windows.Forms.Label lblTitulo;
    }
}