namespace ExcelAddIn1
{
    partial class MenuSemanal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuSemanal));
            this.Dtpikerinicio = new System.Windows.Forms.DateTimePicker();
            this.Dtpikerfinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDiaSemana = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.Btrecetasemanal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cbguarnicion = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtpikerinicio
            // 
            this.Dtpikerinicio.Location = new System.Drawing.Point(40, 46);
            this.Dtpikerinicio.Name = "Dtpikerinicio";
            this.Dtpikerinicio.Size = new System.Drawing.Size(200, 20);
            this.Dtpikerinicio.TabIndex = 0;
            this.Dtpikerinicio.ValueChanged += new System.EventHandler(this.Dtpikerinicio_ValueChanged);
            // 
            // Dtpikerfinal
            // 
            this.Dtpikerfinal.Location = new System.Drawing.Point(425, 46);
            this.Dtpikerfinal.Name = "Dtpikerfinal";
            this.Dtpikerfinal.Size = new System.Drawing.Size(200, 20);
            this.Dtpikerfinal.TabIndex = 1;
            this.Dtpikerfinal.ValueChanged += new System.EventHandler(this.Dtpikerfinal_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "De :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta :";
            // 
            // lbDiaSemana
            // 
            this.lbDiaSemana.FormattingEnabled = true;
            this.lbDiaSemana.Location = new System.Drawing.Point(25, 89);
            this.lbDiaSemana.Name = "lbDiaSemana";
            this.lbDiaSemana.Size = new System.Drawing.Size(120, 173);
            this.lbDiaSemana.TabIndex = 4;
            this.lbDiaSemana.SelectedIndexChanged += new System.EventHandler(this.lbDiaSemana_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.Btrecetasemanal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Cbguarnicion);
            this.panel1.Location = new System.Drawing.Point(175, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 171);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tipo :";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Kg",
            "Lt",
            "Oz",
            "gr",
            "ml",
            "Pieza"});
            this.comboBox4.Location = new System.Drawing.Point(29, 45);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(211, 21);
            this.comboBox4.TabIndex = 18;
            // 
            // Btrecetasemanal
            // 
            this.Btrecetasemanal.Location = new System.Drawing.Point(466, 95);
            this.Btrecetasemanal.Name = "Btrecetasemanal";
            this.Btrecetasemanal.Size = new System.Drawing.Size(91, 43);
            this.Btrecetasemanal.TabIndex = 17;
            this.Btrecetasemanal.Text = "Generar";
            this.Btrecetasemanal.UseVisualStyleBackColor = true;
            this.Btrecetasemanal.Click += new System.EventHandler(this.Btrecetasemanal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cantidad :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(484, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Platillo :";
            // 
            // Cbguarnicion
            // 
            this.Cbguarnicion.FormattingEnabled = true;
            this.Cbguarnicion.Location = new System.Drawing.Point(250, 45);
            this.Cbguarnicion.Name = "Cbguarnicion";
            this.Cbguarnicion.Size = new System.Drawing.Size(211, 21);
            this.Cbguarnicion.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(25, 283);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(726, 182);
            this.dataGridView1.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Dia";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo Platillo";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Platillo";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cantidad";
            this.Column4.Name = "Column4";
            // 
            // MenuSemanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 515);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbDiaSemana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dtpikerfinal);
            this.Controls.Add(this.Dtpikerinicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuSemanal";
            this.Text = "MenuSemanal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Dtpikerinicio;
        private System.Windows.Forms.DateTimePicker Dtpikerfinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDiaSemana;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button Btrecetasemanal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cbguarnicion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}