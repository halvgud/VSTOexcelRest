namespace ExcelAddIn1
{
    partial class SideBarReportes
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbreportes = new System.Windows.Forms.ComboBox();
            this.btgenerar = new System.Windows.Forms.Button();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.dtpfinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbde = new System.Windows.Forms.Label();
            this.lbhasta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbreportes
            // 
            this.cbreportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbreportes.FormattingEnabled = true;
            this.cbreportes.Location = new System.Drawing.Point(114, 26);
            this.cbreportes.Name = "cbreportes";
            this.cbreportes.Size = new System.Drawing.Size(136, 21);
            this.cbreportes.TabIndex = 0;
            this.cbreportes.Visible = false;
            this.cbreportes.SelectedIndexChanged += new System.EventHandler(this.cbreportes_SelectedIndexChanged);
            // 
            // btgenerar
            // 
            this.btgenerar.BackColor = System.Drawing.Color.Black;
            this.btgenerar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btgenerar.ForeColor = System.Drawing.Color.Yellow;
            this.btgenerar.Location = new System.Drawing.Point(75, 171);
            this.btgenerar.Name = "btgenerar";
            this.btgenerar.Size = new System.Drawing.Size(102, 38);
            this.btgenerar.TabIndex = 1;
            this.btgenerar.Text = "Generar";
            this.btgenerar.UseVisualStyleBackColor = false;
            this.btgenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpinicio
            // 
            this.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpinicio.Location = new System.Drawing.Point(114, 71);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(96, 20);
            this.dtpinicio.TabIndex = 2;
            // 
            // dtpfinal
            // 
            this.dtpfinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfinal.Location = new System.Drawing.Point(114, 117);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(96, 20);
            this.dtpfinal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reportes :";
            this.label1.Visible = false;
            // 
            // lbde
            // 
            this.lbde.AutoSize = true;
            this.lbde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbde.Location = new System.Drawing.Point(72, 75);
            this.lbde.Name = "lbde";
            this.lbde.Size = new System.Drawing.Size(36, 16);
            this.lbde.TabIndex = 5;
            this.lbde.Text = "De :";
            // 
            // lbhasta
            // 
            this.lbhasta.AutoSize = true;
            this.lbhasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhasta.Location = new System.Drawing.Point(51, 121);
            this.lbhasta.Name = "lbhasta";
            this.lbhasta.Size = new System.Drawing.Size(57, 16);
            this.lbhasta.TabIndex = 6;
            this.lbhasta.Text = "Hasta :";
            // 
            // SideBarReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbhasta);
            this.Controls.Add(this.lbde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpfinal);
            this.Controls.Add(this.dtpinicio);
            this.Controls.Add(this.btgenerar);
            this.Controls.Add(this.cbreportes);
            this.Name = "SideBarReportes";
            this.Size = new System.Drawing.Size(275, 297);
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbreportes;
        private System.Windows.Forms.Button btgenerar;
        private System.Windows.Forms.DateTimePicker dtpinicio;
        private System.Windows.Forms.DateTimePicker dtpfinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbde;
        private System.Windows.Forms.Label lbhasta;
    }
}
