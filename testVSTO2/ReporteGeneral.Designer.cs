namespace testVSTO2
{
    partial class ReporteGeneral
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTagProveedor = new System.Windows.Forms.TextBox();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.labelUltimo1 = new System.Windows.Forms.LinkLabel();
            this.labelUltimo2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUltimo3 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btGenerar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cbImprimir = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROVEEDOR: ";
            // 
            // txtTagProveedor
            // 
            this.txtTagProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagProveedor.Location = new System.Drawing.Point(149, 10);
            this.txtTagProveedor.Name = "txtTagProveedor";
            this.txtTagProveedor.Size = new System.Drawing.Size(369, 29);
            this.txtTagProveedor.TabIndex = 1;
            this.txtTagProveedor.TextChanged += new System.EventHandler(this.txtTagProveedor_TextChanged);
            this.txtTagProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTagProveedor_KeyUp);
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedor.Location = new System.Drawing.Point(3, 16);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.Size = new System.Drawing.Size(689, 148);
            this.dgvProveedor.TabIndex = 2;
            this.dgvProveedor.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProveedor_CellBeginEdit);
            this.dgvProveedor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProveedor_DataBindingComplete);
            // 
            // labelUltimo1
            // 
            this.labelUltimo1.AutoSize = true;
            this.labelUltimo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimo1.Location = new System.Drawing.Point(3, 0);
            this.labelUltimo1.Name = "labelUltimo1";
            this.labelUltimo1.Size = new System.Drawing.Size(76, 20);
            this.labelUltimo1.TabIndex = 3;
            this.labelUltimo1.TabStop = true;
            this.labelUltimo1.Text = "posicion1";
            this.labelUltimo1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelUltimo1_LinkClicked);
            // 
            // labelUltimo2
            // 
            this.labelUltimo2.AutoSize = true;
            this.labelUltimo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimo2.Location = new System.Drawing.Point(122, 0);
            this.labelUltimo2.Name = "labelUltimo2";
            this.labelUltimo2.Size = new System.Drawing.Size(76, 20);
            this.labelUltimo2.TabIndex = 4;
            this.labelUltimo2.TabStop = true;
            this.labelUltimo2.Text = "posicion2";
            this.labelUltimo2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelUltimo2_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProveedor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 167);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Proveedores";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.25806F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.22581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.51613F));
            this.tableLayoutPanel1.Controls.Add(this.labelUltimo1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelUltimo2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelUltimo3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(149, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 34);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // labelUltimo3
            // 
            this.labelUltimo3.AutoSize = true;
            this.labelUltimo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimo3.Location = new System.Drawing.Point(244, 0);
            this.labelUltimo3.Name = "labelUltimo3";
            this.labelUltimo3.Size = new System.Drawing.Size(76, 20);
            this.labelUltimo3.TabIndex = 5;
            this.labelUltimo3.TabStop = true;
            this.labelUltimo3.Text = "posicion3";
            this.labelUltimo3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelUltimo3_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ultimos buscados :";
            // 
            // btGenerar
            // 
            this.btGenerar.BackColor = System.Drawing.Color.LimeGreen;
            this.btGenerar.Location = new System.Drawing.Point(533, 38);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(150, 34);
            this.btGenerar.TabIndex = 11;
            this.btGenerar.Text = "Generar Reporte";
            this.btGenerar.UseVisualStyleBackColor = false;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btBuscar.Location = new System.Drawing.Point(529, 8);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(68, 29);
            this.btBuscar.TabIndex = 12;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cbImprimir
            // 
            this.cbImprimir.AutoSize = true;
            this.cbImprimir.Checked = true;
            this.cbImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImprimir.Location = new System.Drawing.Point(603, 11);
            this.cbImprimir.Name = "cbImprimir";
            this.cbImprimir.Size = new System.Drawing.Size(71, 17);
            this.cbImprimir.TabIndex = 13;
            this.cbImprimir.Text = "Resumen";
            this.cbImprimir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtFechaIni);
            this.groupBox2.Controls.Add(this.dtFechaFin);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 64);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango de fechas";
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Location = new System.Drawing.Point(6, 33);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(216, 20);
            this.dtFechaIni.TabIndex = 2;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(467, 33);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(216, 20);
            this.dtFechaFin.TabIndex = 3;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Fin";
            // 
            // ReporteGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 308);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbImprimir);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btGenerar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTagProveedor);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTagProveedor;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.LinkLabel labelUltimo1;
        private System.Windows.Forms.LinkLabel labelUltimo2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel labelUltimo3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.CheckBox cbImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DateTimePicker dtFechaIni;
        public System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}