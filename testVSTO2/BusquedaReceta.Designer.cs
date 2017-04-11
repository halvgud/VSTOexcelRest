namespace testVSTO2
{
    partial class BusquedaReceta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.tbClaveReceta = new System.Windows.Forms.TextBox();
            this.cbTipoReceta = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPesoLitro = new System.Windows.Forms.MaskedTextBox();
            this.tbMargenConPrecio = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.MaskedTextBox();
            this.tbCostoElaboracion = new System.Windows.Forms.MaskedTextBox();
            this.tbCostoEstimado = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRecetas = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 424);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 364);
            this.panel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvIngredientes);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(258, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 364);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingredientes";
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientes.Location = new System.Drawing.Point(3, 16);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.Size = new System.Drawing.Size(328, 345);
            this.dgvIngredientes.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbDescripcion);
            this.groupBox4.Controls.Add(this.tbClaveReceta);
            this.groupBox4.Controls.Add(this.cbTipoReceta);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tbPesoLitro);
            this.groupBox4.Controls.Add(this.tbMargenConPrecio);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tbPrecio);
            this.groupBox4.Controls.Add(this.tbCostoElaboracion);
            this.groupBox4.Controls.Add(this.tbCostoEstimado);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(592, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 364);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detalle";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(6, 71);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.ReadOnly = true;
            this.tbDescripcion.Size = new System.Drawing.Size(169, 20);
            this.tbDescripcion.TabIndex = 46;
            // 
            // tbClaveReceta
            // 
            this.tbClaveReceta.Location = new System.Drawing.Point(6, 30);
            this.tbClaveReceta.Name = "tbClaveReceta";
            this.tbClaveReceta.ReadOnly = true;
            this.tbClaveReceta.Size = new System.Drawing.Size(169, 20);
            this.tbClaveReceta.TabIndex = 45;
            // 
            // cbTipoReceta
            // 
            this.cbTipoReceta.FormattingEnabled = true;
            this.cbTipoReceta.Location = new System.Drawing.Point(6, 154);
            this.cbTipoReceta.Name = "cbTipoReceta";
            this.cbTipoReceta.Size = new System.Drawing.Size(169, 21);
            this.cbTipoReceta.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Clave de la receta :";
            // 
            // tbPesoLitro
            // 
            this.tbPesoLitro.Location = new System.Drawing.Point(6, 116);
            this.tbPesoLitro.Name = "tbPesoLitro";
            this.tbPesoLitro.ReadOnly = true;
            this.tbPesoLitro.Size = new System.Drawing.Size(169, 20);
            this.tbPesoLitro.TabIndex = 29;
            // 
            // tbMargenConPrecio
            // 
            this.tbMargenConPrecio.Location = new System.Drawing.Point(6, 265);
            this.tbMargenConPrecio.Name = "tbMargenConPrecio";
            this.tbMargenConPrecio.ReadOnly = true;
            this.tbMargenConPrecio.Size = new System.Drawing.Size(169, 20);
            this.tbMargenConPrecio.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Nombre de la receta :";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(6, 299);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.ReadOnly = true;
            this.tbPrecio.Size = new System.Drawing.Size(169, 20);
            this.tbPrecio.TabIndex = 33;
            // 
            // tbCostoElaboracion
            // 
            this.tbCostoElaboracion.AsciiOnly = true;
            this.tbCostoElaboracion.BeepOnError = true;
            this.tbCostoElaboracion.Location = new System.Drawing.Point(6, 226);
            this.tbCostoElaboracion.Name = "tbCostoElaboracion";
            this.tbCostoElaboracion.ReadOnly = true;
            this.tbCostoElaboracion.Size = new System.Drawing.Size(169, 20);
            this.tbCostoElaboracion.TabIndex = 31;
            // 
            // tbCostoEstimado
            // 
            this.tbCostoEstimado.Location = new System.Drawing.Point(6, 191);
            this.tbCostoEstimado.Name = "tbCostoEstimado";
            this.tbCostoEstimado.ReadOnly = true;
            this.tbCostoEstimado.Size = new System.Drawing.Size(169, 20);
            this.tbCostoEstimado.TabIndex = 36;
            this.tbCostoEstimado.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Tipo de receta :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Peso de 1 litro :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Margen con precio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Precio :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Costo Elaboración :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Costo Estimado :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRecetas);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 364);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recetas";
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecetas.Location = new System.Drawing.Point(3, 16);
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.Size = new System.Drawing.Size(252, 345);
            this.dgvRecetas.TabIndex = 4;
            this.dgvRecetas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecetas_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbCodigo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.tbCantidad);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 41);
            this.panel3.TabIndex = 9;
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(9, 17);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(268, 20);
            this.tbCodigo.TabIndex = 0;
            //this.tbCodigo.TextChanged += new System.EventHandler(this.tbCodigo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Clave o descripcion de la receta:";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(364, 18);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(98, 20);
            this.tbCantidad.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Cantidad:";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(283, 17);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 21);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 57);
            this.panel1.TabIndex = 1;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(94, 6);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(500, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 57);
            this.panel2.TabIndex = 0;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(13, 6);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // BusquedaReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BusquedaReceta";
            this.Text = "Buscar receta...";
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRecetas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbTipoReceta;
        private System.Windows.Forms.MaskedTextBox tbPesoLitro;
        private System.Windows.Forms.MaskedTextBox tbMargenConPrecio;
        private System.Windows.Forms.MaskedTextBox tbPrecio;
        private System.Windows.Forms.MaskedTextBox tbCostoElaboracion;
        private System.Windows.Forms.MaskedTextBox tbCostoEstimado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.TextBox tbClaveReceta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}