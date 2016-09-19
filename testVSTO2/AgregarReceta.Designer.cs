namespace testVSTO2
{
    partial class AgregarReceta
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbMargenConPrecio = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbClaveReceta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbCostoElaboracion = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPrecioSugerido = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMargenSugerido = new System.Windows.Forms.MaskedTextBox();
            this.tbCostoEstimado = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.btBorrarSeleccion = new System.Windows.Forms.Button();
            this.btBorrarLista = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAyuda = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPesoLitro = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTipoReceta = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvIngredientes);
            this.tabPage1.Controls.Add(this.cbTipoReceta);
            this.tabPage1.Controls.Add(this.tbPesoLitro);
            this.tabPage1.Controls.Add(this.tbMargenConPrecio);
            this.tabPage1.Controls.Add(this.tbPrecio);
            this.tabPage1.Controls.Add(this.tbCostoElaboracion);
            this.tabPage1.Controls.Add(this.tbPrecioSugerido);
            this.tabPage1.Controls.Add(this.tbMargenSugerido);
            this.tabPage1.Controls.Add(this.tbCostoEstimado);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.tbDescripcion);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tbClaveReceta);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbCodigo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btBorrarSeleccion);
            this.tabPage1.Controls.Add(this.btBorrarLista);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btBuscar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(629, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbMargenConPrecio
            // 
            this.tbMargenConPrecio.Location = new System.Drawing.Point(521, 259);
            this.tbMargenConPrecio.Name = "tbMargenConPrecio";
            this.tbMargenConPrecio.Size = new System.Drawing.Size(100, 20);
            this.tbMargenConPrecio.TabIndex = 6;
            this.tbMargenConPrecio.TextChanged += new System.EventHandler(this.tbMargenConPrecio_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Margen con precio:";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(521, 329);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(100, 20);
            this.tbPrecio.TabIndex = 7;
            this.tbPrecio.TextChanged += new System.EventHandler(this.tbPrecio_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(518, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Precio :";
            // 
            // tbClaveReceta
            // 
            this.tbClaveReceta.Location = new System.Drawing.Point(304, 24);
            this.tbClaveReceta.Name = "tbClaveReceta";
            this.tbClaveReceta.Size = new System.Drawing.Size(101, 20);
            this.tbClaveReceta.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Clave de la receta :";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(10, 24);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(220, 20);
            this.tbCodigo.TabIndex = 0;
            // 
            // tbCostoElaboracion
            // 
            this.tbCostoElaboracion.AsciiOnly = true;
            this.tbCostoElaboracion.BeepOnError = true;
            this.tbCostoElaboracion.Location = new System.Drawing.Point(521, 189);
            this.tbCostoElaboracion.Name = "tbCostoElaboracion";
            this.tbCostoElaboracion.Size = new System.Drawing.Size(100, 20);
            this.tbCostoElaboracion.TabIndex = 5;
            this.tbCostoElaboracion.TextChanged += new System.EventHandler(this.tbCostoElaboracion_TextChanged);
            this.tbCostoElaboracion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCostoElaboracion_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Costo Elaboración :";
            // 
            // tbPrecioSugerido
            // 
            this.tbPrecioSugerido.Location = new System.Drawing.Point(521, 294);
            this.tbPrecioSugerido.Name = "tbPrecioSugerido";
            this.tbPrecioSugerido.ReadOnly = true;
            this.tbPrecioSugerido.Size = new System.Drawing.Size(100, 20);
            this.tbPrecioSugerido.TabIndex = 14;
            this.tbPrecioSugerido.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Precio sugerido :";
            // 
            // tbMargenSugerido
            // 
            this.tbMargenSugerido.Location = new System.Drawing.Point(521, 224);
            this.tbMargenSugerido.Name = "tbMargenSugerido";
            this.tbMargenSugerido.ReadOnly = true;
            this.tbMargenSugerido.Size = new System.Drawing.Size(100, 20);
            this.tbMargenSugerido.TabIndex = 4;
            this.tbMargenSugerido.TabStop = false;
            // 
            // tbCostoEstimado
            // 
            this.tbCostoEstimado.Location = new System.Drawing.Point(521, 154);
            this.tbCostoEstimado.Name = "tbCostoEstimado";
            this.tbCostoEstimado.ReadOnly = true;
            this.tbCostoEstimado.Size = new System.Drawing.Size(100, 20);
            this.tbCostoEstimado.TabIndex = 11;
            this.tbCostoEstimado.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Margen sugerido :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Costo Estimado :";
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Location = new System.Drawing.Point(10, 68);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.Size = new System.Drawing.Size(510, 281);
            this.dgvIngredientes.TabIndex = 8;
            this.dgvIngredientes.TabStop = false;
            // 
            // btBorrarSeleccion
            // 
            this.btBorrarSeleccion.Location = new System.Drawing.Point(10, 355);
            this.btBorrarSeleccion.Name = "btBorrarSeleccion";
            this.btBorrarSeleccion.Size = new System.Drawing.Size(109, 23);
            this.btBorrarSeleccion.TabIndex = 8;
            this.btBorrarSeleccion.Text = "Borrar selección";
            this.btBorrarSeleccion.UseVisualStyleBackColor = true;
            this.btBorrarSeleccion.Click += new System.EventHandler(this.btBorrarSeleccion_Click);
            // 
            // btBorrarLista
            // 
            this.btBorrarLista.Location = new System.Drawing.Point(125, 355);
            this.btBorrarLista.Name = "btBorrarLista";
            this.btBorrarLista.Size = new System.Drawing.Size(72, 23);
            this.btBorrarLista.TabIndex = 9;
            this.btBorrarLista.Text = "Borrar lista";
            this.btBorrarLista.UseVisualStyleBackColor = true;
            this.btBorrarLista.Click += new System.EventHandler(this.btBorrarLista_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de ingredientes :";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(236, 23);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(62, 21);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "Buscar...";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo o nombre de ingredientes:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(629, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buscar y Editar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buscar...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAyuda);
            this.panel1.Controls.Add(this.btGuardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 48);
            this.panel1.TabIndex = 3;
            // 
            // btAyuda
            // 
            this.btAyuda.Location = new System.Drawing.Point(126, 6);
            this.btAyuda.Name = "btAyuda";
            this.btAyuda.Size = new System.Drawing.Size(75, 23);
            this.btAyuda.TabIndex = 11;
            this.btAyuda.TabStop = false;
            this.btAyuda.Text = "Ayuda";
            this.btAyuda.UseVisualStyleBackColor = true;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(11, 6);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(109, 23);
            this.btGuardar.TabIndex = 10;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(414, 24);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(207, 20);
            this.tbDescripcion.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(411, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Nombre de la receta :";
            // 
            // tbPesoLitro
            // 
            this.tbPesoLitro.Location = new System.Drawing.Point(521, 79);
            this.tbPesoLitro.Name = "tbPesoLitro";
            this.tbPesoLitro.Size = new System.Drawing.Size(100, 20);
            this.tbPesoLitro.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(518, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Peso de 1 litro :";
            // 
            // cbTipoReceta
            // 
            this.cbTipoReceta.FormattingEnabled = true;
            this.cbTipoReceta.Location = new System.Drawing.Point(521, 117);
            this.cbTipoReceta.Name = "cbTipoReceta";
            this.cbTipoReceta.Size = new System.Drawing.Size(102, 21);
            this.cbTipoReceta.TabIndex = 27;
            this.cbTipoReceta.SelectedIndexChanged += new System.EventHandler(this.cbTipoReceta_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(518, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Tipo de receta :";
            // 
            // AgregarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 474);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "AgregarReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarReceta";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MaskedTextBox tbCostoElaboracion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbPrecioSugerido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbMargenSugerido;
        private System.Windows.Forms.MaskedTextBox tbCostoEstimado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.Button btBorrarSeleccion;
        private System.Windows.Forms.Button btBorrarLista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAyuda;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbClaveReceta;
        private System.Windows.Forms.MaskedTextBox tbMargenConPrecio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox tbPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbPesoLitro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbTipoReceta;
        private System.Windows.Forms.Label label13;
    }
}