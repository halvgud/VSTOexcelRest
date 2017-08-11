namespace ExcelAddIn1
{
    partial class Diario
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
            this.dgvInventarioPlatillos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbregistrado = new System.Windows.Forms.RadioButton();
            this.rbreventa = new System.Windows.Forms.RadioButton();
            this.rbmerma = new System.Windows.Forms.RadioButton();
            this.rbcongelado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDiarios = new System.Windows.Forms.DataGridView();
            this.btCargarDiarios = new System.Windows.Forms.Button();
            this.btPreviaPlatillo = new System.Windows.Forms.Button();
            this.btPreviaGlobal = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btEditar = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btGuardarDiarios = new System.Windows.Forms.Button();
            this.btEliminarFila = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioPlatillos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventarioPlatillos
            // 
            this.dgvInventarioPlatillos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarioPlatillos.Location = new System.Drawing.Point(18, 33);
            this.dgvInventarioPlatillos.Name = "dgvInventarioPlatillos";
            this.dgvInventarioPlatillos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioPlatillos.Size = new System.Drawing.Size(809, 263);
            this.dgvInventarioPlatillos.TabIndex = 0;
            this.dgvInventarioPlatillos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioPlatillos_CellClick);
            this.dgvInventarioPlatillos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioPlatillos_CellValueChanged);
            this.dgvInventarioPlatillos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInventarioPlatillos_DataError);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvInventarioPlatillos);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventario Platillos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbregistrado);
            this.groupBox2.Controls.Add(this.rbreventa);
            this.groupBox2.Controls.Add(this.rbmerma);
            this.groupBox2.Controls.Add(this.rbcongelado);
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(839, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 149);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino";
            // 
            // rbregistrado
            // 
            this.rbregistrado.AutoSize = true;
            this.rbregistrado.Location = new System.Drawing.Point(5, 117);
            this.rbregistrado.Name = "rbregistrado";
            this.rbregistrado.Size = new System.Drawing.Size(120, 25);
            this.rbregistrado.TabIndex = 37;
            this.rbregistrado.TabStop = true;
            this.rbregistrado.Text = "Registrado";
            this.rbregistrado.UseVisualStyleBackColor = true;
            this.rbregistrado.CheckedChanged += new System.EventHandler(this.rbregistrado_CheckedChanged);
            // 
            // rbreventa
            // 
            this.rbreventa.AutoSize = true;
            this.rbreventa.Location = new System.Drawing.Point(6, 86);
            this.rbreventa.Name = "rbreventa";
            this.rbreventa.Size = new System.Drawing.Size(108, 25);
            this.rbreventa.TabIndex = 36;
            this.rbreventa.TabStop = true;
            this.rbreventa.Text = "Re Venta";
            this.rbreventa.UseVisualStyleBackColor = true;
            this.rbreventa.CheckedChanged += new System.EventHandler(this.rbreventa_CheckedChanged);
            // 
            // rbmerma
            // 
            this.rbmerma.AutoSize = true;
            this.rbmerma.Location = new System.Drawing.Point(6, 57);
            this.rbmerma.Name = "rbmerma";
            this.rbmerma.Size = new System.Drawing.Size(87, 25);
            this.rbmerma.TabIndex = 35;
            this.rbmerma.TabStop = true;
            this.rbmerma.Text = "Merma";
            this.rbmerma.UseVisualStyleBackColor = true;
            this.rbmerma.CheckedChanged += new System.EventHandler(this.rbmerma_CheckedChanged);
            // 
            // rbcongelado
            // 
            this.rbcongelado.AutoSize = true;
            this.rbcongelado.Location = new System.Drawing.Point(5, 29);
            this.rbcongelado.Name = "rbcongelado";
            this.rbcongelado.Size = new System.Drawing.Size(123, 25);
            this.rbcongelado.TabIndex = 34;
            this.rbcongelado.TabStop = true;
            this.rbcongelado.Text = "Congelados";
            this.rbcongelado.UseVisualStyleBackColor = true;
            this.rbcongelado.CheckedChanged += new System.EventHandler(this.rbcongelado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "CV :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "CP :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(337, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cantidad Vendida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cantidad Programada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(182, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "CR:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(541, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "SR:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(451, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "S:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(210, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cantidad Real";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(566, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sobrante Real";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(467, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Sobrante";
            // 
            // btGuardar
            // 
            this.btGuardar.Enabled = false;
            this.btGuardar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Location = new System.Drawing.Point(848, 267);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(105, 27);
            this.btGuardar.TabIndex = 33;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDiarios);
            this.groupBox3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(833, 266);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Platillos Diarios";
            // 
            // dgvDiarios
            // 
            this.dgvDiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDiarios.Location = new System.Drawing.Point(6, 30);
            this.dgvDiarios.Name = "dgvDiarios";
            this.dgvDiarios.Size = new System.Drawing.Size(821, 230);
            this.dgvDiarios.TabIndex = 0;
            this.dgvDiarios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDiarios_DataError);
            // 
            // btCargarDiarios
            // 
            this.btCargarDiarios.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarDiarios.Location = new System.Drawing.Point(833, 443);
            this.btCargarDiarios.Name = "btCargarDiarios";
            this.btCargarDiarios.Size = new System.Drawing.Size(118, 30);
            this.btCargarDiarios.TabIndex = 35;
            this.btCargarDiarios.Text = "Cargar Diarios";
            this.btCargarDiarios.UseVisualStyleBackColor = true;
            this.btCargarDiarios.Click += new System.EventHandler(this.btCargarDiarios_Click);
            // 
            // btPreviaPlatillo
            // 
            this.btPreviaPlatillo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaPlatillo.Location = new System.Drawing.Point(833, 479);
            this.btPreviaPlatillo.Name = "btPreviaPlatillo";
            this.btPreviaPlatillo.Size = new System.Drawing.Size(118, 28);
            this.btPreviaPlatillo.TabIndex = 37;
            this.btPreviaPlatillo.Text = "Previa Platillo";
            this.btPreviaPlatillo.UseVisualStyleBackColor = true;
            this.btPreviaPlatillo.Click += new System.EventHandler(this.btPreviaPlatillo_Click);
            // 
            // btPreviaGlobal
            // 
            this.btPreviaGlobal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaGlobal.Location = new System.Drawing.Point(833, 513);
            this.btPreviaGlobal.Name = "btPreviaGlobal";
            this.btPreviaGlobal.Size = new System.Drawing.Size(118, 29);
            this.btPreviaGlobal.TabIndex = 38;
            this.btPreviaGlobal.Text = "Previa Global";
            this.btPreviaGlobal.UseVisualStyleBackColor = true;
            this.btPreviaGlobal.Click += new System.EventHandler(this.btPreviaGlobal_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 650);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 651);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "Cantidad Programada";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(210, 651);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "Cantidad Elaborar";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(350, 651);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "Cantidad Real";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(178, 651);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 16);
            this.label15.TabIndex = 43;
            this.label15.Text = "CE :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(318, 650);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 16);
            this.label16.TabIndex = 44;
            this.label16.Text = "CR :";
            // 
            // btEditar
            // 
            this.btEditar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditar.Location = new System.Drawing.Point(849, 231);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(104, 27);
            this.btEditar.TabIndex = 45;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(10, 650);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 46;
            this.label17.Text = "CP :";
            // 
            // btGuardarDiarios
            // 
            this.btGuardarDiarios.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarDiarios.Location = new System.Drawing.Point(833, 582);
            this.btGuardarDiarios.Name = "btGuardarDiarios";
            this.btGuardarDiarios.Size = new System.Drawing.Size(118, 27);
            this.btGuardarDiarios.TabIndex = 48;
            this.btGuardarDiarios.Text = "Guardar";
            this.btGuardarDiarios.UseVisualStyleBackColor = true;
            this.btGuardarDiarios.Click += new System.EventHandler(this.btGuardarDiarios_Click);
            // 
            // btEliminarFila
            // 
            this.btEliminarFila.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarFila.Location = new System.Drawing.Point(833, 548);
            this.btEliminarFila.Name = "btEliminarFila";
            this.btEliminarFila.Size = new System.Drawing.Size(118, 28);
            this.btEliminarFila.TabIndex = 49;
            this.btEliminarFila.Text = "EliminarFila";
            this.btEliminarFila.UseVisualStyleBackColor = true;
            this.btEliminarFila.Click += new System.EventHandler(this.btEliminarFila_Click);
            // 
            // Diario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 675);
            this.Controls.Add(this.btEliminarFila);
            this.Controls.Add(this.btGuardarDiarios);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btPreviaGlobal);
            this.Controls.Add(this.btPreviaPlatillo);
            this.Controls.Add(this.btCargarDiarios);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Diario";
            this.Text = "Diario";
            this.Load += new System.EventHandler(this.Diario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioPlatillos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventarioPlatillos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.RadioButton rbreventa;
        private System.Windows.Forms.RadioButton rbmerma;
        private System.Windows.Forms.RadioButton rbcongelado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDiarios;
        private System.Windows.Forms.Button btCargarDiarios;
        private System.Windows.Forms.Button btPreviaPlatillo;
        private System.Windows.Forms.Button btPreviaGlobal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btGuardarDiarios;
        private System.Windows.Forms.Button btEliminarFila;
        private System.Windows.Forms.RadioButton rbregistrado;
    }
}