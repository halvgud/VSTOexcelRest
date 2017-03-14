namespace testVSTO2
{
    partial class SideBarImportarInformacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAyuda = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chDepartamento = new System.Windows.Forms.CheckBox();
            this.chCategoria = new System.Windows.Forms.CheckBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chProveedor = new System.Windows.Forms.CheckBox();
            this.chTipoProducto = new System.Windows.Forms.CheckBox();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.cbTipoProducto = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.cbImprimir = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbOrderBy = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAyuda);
            this.panel1.Controls.Add(this.btAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 50);
            this.panel1.TabIndex = 9;
            // 
            // btAyuda
            // 
            this.btAyuda.Cursor = System.Windows.Forms.Cursors.Help;
            this.btAyuda.Location = new System.Drawing.Point(124, 15);
            this.btAyuda.Name = "btAyuda";
            this.btAyuda.Size = new System.Drawing.Size(75, 23);
            this.btAyuda.TabIndex = 2;
            this.btAyuda.Text = "Ayuda";
            this.btAyuda.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Enabled = false;
            this.btAceptar.Location = new System.Drawing.Point(16, 15);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbOrderBy);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbImprimir);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parámetros de búsqueda";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSucursal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbCategoria);
            this.groupBox2.Controls.Add(this.cbDepartamento);
            this.groupBox2.Controls.Add(this.chCategoria);
            this.groupBox2.Controls.Add(this.chDepartamento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 126);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categoria / Departamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Departamento ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Categoria";
            // 
            // chDepartamento
            // 
            this.chDepartamento.AutoSize = true;
            this.chDepartamento.Checked = true;
            this.chDepartamento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDepartamento.Location = new System.Drawing.Point(228, 66);
            this.chDepartamento.Name = "chDepartamento";
            this.chDepartamento.Size = new System.Drawing.Size(15, 14);
            this.chDepartamento.TabIndex = 6;
            this.chDepartamento.UseVisualStyleBackColor = true;
            this.chDepartamento.CheckedChanged += new System.EventHandler(this.chDepartamento_CheckedChanged);
            // 
            // chCategoria
            // 
            this.chCategoria.AutoSize = true;
            this.chCategoria.Checked = true;
            this.chCategoria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCategoria.Location = new System.Drawing.Point(228, 100);
            this.chCategoria.Name = "chCategoria";
            this.chCategoria.Size = new System.Drawing.Size(15, 14);
            this.chCategoria.TabIndex = 7;
            this.chCategoria.UseVisualStyleBackColor = true;
            this.chCategoria.CheckedChanged += new System.EventHandler(this.chCategoria_CheckedChanged);
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(6, 62);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(216, 21);
            this.cbDepartamento.TabIndex = 0;
            this.cbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbDepartamento_SelectedIndexChanged);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(6, 97);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(216, 21);
            this.cbCategoria.TabIndex = 1;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sucursal";
            // 
            // cbSucursal
            // 
            this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursal.FormattingEnabled = true;
            this.cbSucursal.Location = new System.Drawing.Point(6, 27);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(216, 21);
            this.cbSucursal.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTipoProducto);
            this.groupBox3.Controls.Add(this.cbProveedor);
            this.groupBox3.Controls.Add(this.chTipoProducto);
            this.groupBox3.Controls.Add(this.chProveedor);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 114);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proveedor/Tipo producto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Producto";
            // 
            // chProveedor
            // 
            this.chProveedor.AutoSize = true;
            this.chProveedor.Location = new System.Drawing.Point(228, 39);
            this.chProveedor.Name = "chProveedor";
            this.chProveedor.Size = new System.Drawing.Size(15, 14);
            this.chProveedor.TabIndex = 12;
            this.chProveedor.UseVisualStyleBackColor = true;
            this.chProveedor.CheckedChanged += new System.EventHandler(this.chProveedor_CheckedChanged);
            // 
            // chTipoProducto
            // 
            this.chTipoProducto.AutoSize = true;
            this.chTipoProducto.Location = new System.Drawing.Point(228, 81);
            this.chTipoProducto.Name = "chTipoProducto";
            this.chTipoProducto.Size = new System.Drawing.Size(15, 14);
            this.chTipoProducto.TabIndex = 13;
            this.chTipoProducto.UseVisualStyleBackColor = true;
            this.chTipoProducto.CheckedChanged += new System.EventHandler(this.chTipoProducto_CheckedChanged);
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(6, 36);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(216, 21);
            this.cbProveedor.TabIndex = 8;
            // 
            // cbTipoProducto
            // 
            this.cbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoProducto.FormattingEnabled = true;
            this.cbTipoProducto.Location = new System.Drawing.Point(6, 78);
            this.cbTipoProducto.Name = "cbTipoProducto";
            this.cbTipoProducto.Size = new System.Drawing.Size(216, 21);
            this.cbTipoProducto.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtFechaIni);
            this.groupBox1.Controls.Add(this.dtFechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 111);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de fechas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Fin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Inicio";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(6, 72);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(216, 20);
            this.dtFechaFin.TabIndex = 3;
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Location = new System.Drawing.Point(6, 33);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(216, 20);
            this.dtFechaIni.TabIndex = 2;
            // 
            // cbImprimir
            // 
            this.cbImprimir.AutoSize = true;
            this.cbImprimir.Location = new System.Drawing.Point(9, 403);
            this.cbImprimir.Name = "cbImprimir";
            this.cbImprimir.Size = new System.Drawing.Size(109, 17);
            this.cbImprimir.TabIndex = 11;
            this.cbImprimir.Text = "Versión imprimible";
            this.cbImprimir.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ordenar por:";
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(9, 370);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(216, 21);
            this.cbOrderBy.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(292, 494);
            this.tabControl1.TabIndex = 8;
            // 
            // SideBarImportarInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SideBarImportarInformacion";
            this.Size = new System.Drawing.Size(292, 544);
            this.Load += new System.EventHandler(this.ImportarInformacion_Load);
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAyuda;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbOrderBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker dtFechaIni;
        public System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbTipoProducto;
        public System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.CheckBox chTipoProducto;
        private System.Windows.Forms.CheckBox chProveedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cbSucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCategoria;
        public System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.CheckBox chCategoria;
        private System.Windows.Forms.CheckBox chDepartamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
