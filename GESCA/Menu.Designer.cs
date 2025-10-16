namespace GESCA
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapacitaciones = new System.Windows.Forms.Button();
            this.btnLugares = new System.Windows.Forms.Button();
            this.btnTemas = new System.Windows.Forms.Button();
            this.btnCapacitador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCapacitaciones
            // 
            this.btnCapacitaciones.Location = new System.Drawing.Point(321, 161);
            this.btnCapacitaciones.Name = "btnCapacitaciones";
            this.btnCapacitaciones.Size = new System.Drawing.Size(88, 30);
            this.btnCapacitaciones.TabIndex = 0;
            this.btnCapacitaciones.Text = "Capacitaciones";
            this.btnCapacitaciones.UseVisualStyleBackColor = true;
            this.btnCapacitaciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLugares
            // 
            this.btnLugares.Location = new System.Drawing.Point(321, 208);
            this.btnLugares.Name = "btnLugares";
            this.btnLugares.Size = new System.Drawing.Size(88, 30);
            this.btnLugares.TabIndex = 1;
            this.btnLugares.Text = "Lugares";
            this.btnLugares.UseVisualStyleBackColor = true;
            // 
            // btnTemas
            // 
            this.btnTemas.Location = new System.Drawing.Point(321, 254);
            this.btnTemas.Name = "btnTemas";
            this.btnTemas.Size = new System.Drawing.Size(88, 30);
            this.btnTemas.TabIndex = 2;
            this.btnTemas.Text = "Temas";
            this.btnTemas.UseVisualStyleBackColor = true;
            // 
            // btnCapacitador
            // 
            this.btnCapacitador.Location = new System.Drawing.Point(321, 300);
            this.btnCapacitador.Name = "btnCapacitador";
            this.btnCapacitador.Size = new System.Drawing.Size(88, 30);
            this.btnCapacitador.TabIndex = 3;
            this.btnCapacitador.Text = "Capacitadores";
            this.btnCapacitador.UseVisualStyleBackColor = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCapacitador);
            this.Controls.Add(this.btnTemas);
            this.Controls.Add(this.btnLugares);
            this.Controls.Add(this.btnCapacitaciones);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapacitaciones;
        private System.Windows.Forms.Button btnLugares;
        private System.Windows.Forms.Button btnTemas;
        private System.Windows.Forms.Button btnCapacitador;
    }
}

