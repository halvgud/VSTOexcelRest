namespace ExcelAddIn1
{
    partial class SideBarReporteReceta
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
            this.lbOrdenar = new System.Windows.Forms.Label();
            this.cbOrdenarReceta = new System.Windows.Forms.ComboBox();
            this.btGenerarReceta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipoReceta = new System.Windows.Forms.CheckBox();
            this.cbPlatillo = new System.Windows.Forms.CheckBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.lbFin = new System.Windows.Forms.Label();
            this.lbIni = new System.Windows.Forms.Label();
            this.cbproducto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbOrdenar
            // 
            this.lbOrdenar.AutoSize = true;
            this.lbOrdenar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrdenar.Location = new System.Drawing.Point(65, 318);
            this.lbOrdenar.Name = "lbOrdenar";
            this.lbOrdenar.Size = new System.Drawing.Size(136, 22);
            this.lbOrdenar.TabIndex = 2;
            this.lbOrdenar.Text = "Ordenar por :";
            // 
            // cbOrdenarReceta
            // 
            this.cbOrdenarReceta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOrdenarReceta.BackColor = System.Drawing.Color.Silver;
            this.cbOrdenarReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrdenarReceta.FormattingEnabled = true;
            this.cbOrdenarReceta.Location = new System.Drawing.Point(47, 343);
            this.cbOrdenarReceta.Name = "cbOrdenarReceta";
            this.cbOrdenarReceta.Size = new System.Drawing.Size(165, 26);
            this.cbOrdenarReceta.TabIndex = 4;
            this.cbOrdenarReceta.SelectedIndexChanged += new System.EventHandler(this.cbOrdenarReceta_SelectedIndexChanged);
            // 
            // btGenerarReceta
            // 
            this.btGenerarReceta.BackColor = System.Drawing.Color.Black;
            this.btGenerarReceta.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerarReceta.ForeColor = System.Drawing.Color.White;
            this.btGenerarReceta.Location = new System.Drawing.Point(69, 391);
            this.btGenerarReceta.Name = "btGenerarReceta";
            this.btGenerarReceta.Size = new System.Drawing.Size(112, 33);
            this.btGenerarReceta.TabIndex = 6;
            this.btGenerarReceta.Text = "Generar";
            this.btGenerarReceta.UseVisualStyleBackColor = false;
            this.btGenerarReceta.Click += new System.EventHandler(this.btGenerarReceta_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbProducto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbTipoReceta);
            this.panel1.Controls.Add(this.cbPlatillo);
            this.panel1.Controls.Add(this.dtpFechaFin);
            this.panel1.Controls.Add(this.dtpFechaIni);
            this.panel1.Controls.Add(this.lbFin);
            this.panel1.Controls.Add(this.lbIni);
            this.panel1.Controls.Add(this.cbproducto);
            this.panel1.Controls.Add(this.btGenerarReceta);
            this.panel1.Controls.Add(this.cbOrdenarReceta);
            this.panel1.Controls.Add(this.lbOrdenar);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 454);
            this.panel1.TabIndex = 7;
            // 
            // tbProducto
            // 
            this.tbProducto.BackColor = System.Drawing.Color.Silver;
            this.tbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProducto.Location = new System.Drawing.Point(103, 267);
            this.tbProducto.Name = "tbProducto";
            this.tbProducto.Size = new System.Drawing.Size(165, 24);
            this.tbProducto.TabIndex = 15;
            this.tbProducto.TextChanged += new System.EventHandler(this.tbProducto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Buscar por:";
            // 
            // cbTipoReceta
            // 
            this.cbTipoReceta.AutoSize = true;
            this.cbTipoReceta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoReceta.Location = new System.Drawing.Point(8, 227);
            this.cbTipoReceta.Name = "cbTipoReceta";
            this.cbTipoReceta.Size = new System.Drawing.Size(125, 23);
            this.cbTipoReceta.TabIndex = 13;
            this.cbTipoReceta.Text = "Tipo Receta:";
            this.cbTipoReceta.UseVisualStyleBackColor = true;
            this.cbTipoReceta.CheckedChanged += new System.EventHandler(this.cbTipoReceta_CheckedChanged);
            // 
            // cbPlatillo
            // 
            this.cbPlatillo.AutoSize = true;
            this.cbPlatillo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlatillo.Location = new System.Drawing.Point(3, 268);
            this.cbPlatillo.Name = "cbPlatillo";
            this.cbPlatillo.Size = new System.Drawing.Size(105, 23);
            this.cbPlatillo.TabIndex = 12;
            this.cbPlatillo.Text = "Producto:";
            this.cbPlatillo.UseVisualStyleBackColor = true;
            this.cbPlatillo.CheckedChanged += new System.EventHandler(this.cbPlatillo_CheckedChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Location = new System.Drawing.Point(17, 118);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(251, 22);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIni.Location = new System.Drawing.Point(17, 50);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(251, 22);
            this.dtpFechaIni.TabIndex = 10;
            // 
            // lbFin
            // 
            this.lbFin.AutoSize = true;
            this.lbFin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFin.Location = new System.Drawing.Point(98, 93);
            this.lbFin.Name = "lbFin";
            this.lbFin.Size = new System.Drawing.Size(103, 22);
            this.lbFin.TabIndex = 9;
            this.lbFin.Text = "FechaFin:";
            // 
            // lbIni
            // 
            this.lbIni.AutoSize = true;
            this.lbIni.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIni.Location = new System.Drawing.Point(105, 25);
            this.lbIni.Name = "lbIni";
            this.lbIni.Size = new System.Drawing.Size(96, 22);
            this.lbIni.TabIndex = 8;
            this.lbIni.Text = "FechaIni:";
            // 
            // cbproducto
            // 
            this.cbproducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbproducto.BackColor = System.Drawing.Color.Silver;
            this.cbproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbproducto.FormattingEnabled = true;
            this.cbproducto.Location = new System.Drawing.Point(134, 227);
            this.cbproducto.Name = "cbproducto";
            this.cbproducto.Size = new System.Drawing.Size(134, 26);
            this.cbproducto.TabIndex = 7;
            // 
            // SideBarReporteReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SideBarReporteReceta";
            this.Size = new System.Drawing.Size(286, 460);
            this.Load += new System.EventHandler(this.SideBarReporteReceta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbOrdenar;
        private System.Windows.Forms.ComboBox cbOrdenarReceta;
        private System.Windows.Forms.Button btGenerarReceta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbproducto;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.Label lbFin;
        private System.Windows.Forms.Label lbIni;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.CheckBox cbPlatillo;
        private System.Windows.Forms.CheckBox cbTipoReceta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProducto;
    }
}
