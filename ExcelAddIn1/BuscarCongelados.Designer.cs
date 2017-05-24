namespace ExcelAddIn1
{
    partial class BuscarCongelados
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
            this.btaceptarbcongelados = new System.Windows.Forms.Button();
            this.dgvbuscar_congelados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbfechaagregar = new System.Windows.Forms.Label();
            this.lbclave = new System.Windows.Forms.Label();
            this.lbdescripcion = new System.Windows.Forms.Label();
            this.lbtclave = new System.Windows.Forms.Label();
            this.lbtdescripcion = new System.Windows.Forms.Label();
            this.lbcantidad = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.rbmerma = new System.Windows.Forms.RadioButton();
            this.rbempleado = new System.Windows.Forms.RadioButton();
            this.rbutilizacion = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscar_congelados)).BeginInit();
            this.SuspendLayout();
            // 
            // btaceptarbcongelados
            // 
            this.btaceptarbcongelados.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btaceptarbcongelados.Location = new System.Drawing.Point(12, 161);
            this.btaceptarbcongelados.Name = "btaceptarbcongelados";
            this.btaceptarbcongelados.Size = new System.Drawing.Size(75, 36);
            this.btaceptarbcongelados.TabIndex = 0;
            this.btaceptarbcongelados.Text = "Aceptar";
            this.btaceptarbcongelados.UseVisualStyleBackColor = true;
            this.btaceptarbcongelados.Click += new System.EventHandler(this.btaceptarbcongelados_Click);
            // 
            // dgvbuscar_congelados
            // 
            this.dgvbuscar_congelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbuscar_congelados.Location = new System.Drawing.Point(12, 42);
            this.dgvbuscar_congelados.Name = "dgvbuscar_congelados";
            this.dgvbuscar_congelados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbuscar_congelados.Size = new System.Drawing.Size(497, 96);
            this.dgvbuscar_congelados.TabIndex = 1;
            this.dgvbuscar_congelados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbuscar_congelados_CellClick);
            this.dgvbuscar_congelados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbuscar_congelados_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha :";
            // 
            // lbfechaagregar
            // 
            this.lbfechaagregar.AutoSize = true;
            this.lbfechaagregar.Location = new System.Drawing.Point(68, 9);
            this.lbfechaagregar.Name = "lbfechaagregar";
            this.lbfechaagregar.Size = new System.Drawing.Size(37, 13);
            this.lbfechaagregar.TabIndex = 4;
            this.lbfechaagregar.Text = "xxxxxx";
            // 
            // lbclave
            // 
            this.lbclave.AutoSize = true;
            this.lbclave.Location = new System.Drawing.Point(200, 187);
            this.lbclave.Name = "lbclave";
            this.lbclave.Size = new System.Drawing.Size(47, 13);
            this.lbclave.TabIndex = 13;
            this.lbclave.Text = "xxxxxxxx";
            this.lbclave.Visible = false;
            // 
            // lbdescripcion
            // 
            this.lbdescripcion.AutoSize = true;
            this.lbdescripcion.Location = new System.Drawing.Point(200, 161);
            this.lbdescripcion.Name = "lbdescripcion";
            this.lbdescripcion.Size = new System.Drawing.Size(42, 13);
            this.lbdescripcion.TabIndex = 12;
            this.lbdescripcion.Text = "xxxxxxx";
            this.lbdescripcion.Visible = false;
            // 
            // lbtclave
            // 
            this.lbtclave.AutoSize = true;
            this.lbtclave.Location = new System.Drawing.Point(154, 187);
            this.lbtclave.Name = "lbtclave";
            this.lbtclave.Size = new System.Drawing.Size(40, 13);
            this.lbtclave.TabIndex = 11;
            this.lbtclave.Text = "Clave :";
            this.lbtclave.Visible = false;
            // 
            // lbtdescripcion
            // 
            this.lbtdescripcion.AutoSize = true;
            this.lbtdescripcion.Location = new System.Drawing.Point(125, 161);
            this.lbtdescripcion.Name = "lbtdescripcion";
            this.lbtdescripcion.Size = new System.Drawing.Size(69, 13);
            this.lbtdescripcion.TabIndex = 10;
            this.lbtdescripcion.Text = "Descripcion :";
            this.lbtdescripcion.Visible = false;
            // 
            // lbcantidad
            // 
            this.lbcantidad.AutoSize = true;
            this.lbcantidad.Location = new System.Drawing.Point(303, 187);
            this.lbcantidad.Name = "lbcantidad";
            this.lbcantidad.Size = new System.Drawing.Size(55, 13);
            this.lbcantidad.TabIndex = 9;
            this.lbcantidad.Text = "Cantidad :";
            this.lbcantidad.Visible = false;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(364, 184);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(66, 20);
            this.txtcantidad.TabIndex = 8;
            this.txtcantidad.Visible = false;
            // 
            // rbmerma
            // 
            this.rbmerma.AutoSize = true;
            this.rbmerma.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbmerma.Location = new System.Drawing.Point(526, 42);
            this.rbmerma.Name = "rbmerma";
            this.rbmerma.Size = new System.Drawing.Size(77, 23);
            this.rbmerma.TabIndex = 14;
            this.rbmerma.TabStop = true;
            this.rbmerma.Text = "Merma";
            this.rbmerma.UseVisualStyleBackColor = true;
            // 
            // rbempleado
            // 
            this.rbempleado.AutoSize = true;
            this.rbempleado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbempleado.Location = new System.Drawing.Point(526, 74);
            this.rbempleado.Name = "rbempleado";
            this.rbempleado.Size = new System.Drawing.Size(93, 23);
            this.rbempleado.TabIndex = 15;
            this.rbempleado.TabStop = true;
            this.rbempleado.Text = "Empleado";
            this.rbempleado.UseVisualStyleBackColor = true;
            // 
            // rbutilizacion
            // 
            this.rbutilizacion.AutoSize = true;
            this.rbutilizacion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbutilizacion.Location = new System.Drawing.Point(526, 107);
            this.rbutilizacion.Name = "rbutilizacion";
            this.rbutilizacion.Size = new System.Drawing.Size(96, 23);
            this.rbutilizacion.TabIndex = 16;
            this.rbutilizacion.TabStop = true;
            this.rbutilizacion.Text = "Utilización";
            this.rbutilizacion.UseVisualStyleBackColor = true;
            // 
            // BuscarCongelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 227);
            this.Controls.Add(this.rbutilizacion);
            this.Controls.Add(this.rbempleado);
            this.Controls.Add(this.rbmerma);
            this.Controls.Add(this.lbclave);
            this.Controls.Add(this.lbdescripcion);
            this.Controls.Add(this.lbtclave);
            this.Controls.Add(this.lbtdescripcion);
            this.Controls.Add(this.lbcantidad);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.lbfechaagregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvbuscar_congelados);
            this.Controls.Add(this.btaceptarbcongelados);
            this.Name = "BuscarCongelados";
            this.Text = "v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuscarCongelados_FormClosing);
            this.Load += new System.EventHandler(this.BuscarCongelados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscar_congelados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btaceptarbcongelados;
        private System.Windows.Forms.DataGridView dgvbuscar_congelados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbfechaagregar;
        public System.Windows.Forms.Label lbdescripcion;
        public System.Windows.Forms.Label lbclave;
        public System.Windows.Forms.Label lbtclave;
        public System.Windows.Forms.Label lbtdescripcion;
        public System.Windows.Forms.Label lbcantidad;
        public System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.RadioButton rbmerma;
        private System.Windows.Forms.RadioButton rbempleado;
        private System.Windows.Forms.RadioButton rbutilizacion;
    }
}