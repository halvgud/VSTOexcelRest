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
            this.dgvDiarios = new System.Windows.Forms.DataGridView();
            this.btCargarDiarios = new System.Windows.Forms.Button();
            this.btPreviaPlatillo = new System.Windows.Forms.Button();
            this.btPreviaGlobal = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btGuardarDiarios = new System.Windows.Forms.Button();
            this.btEliminarFila = new System.Windows.Forms.Button();
            this.btOrdendeTrabajo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btEditar = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioPlatillos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventarioPlatillos
            // 
            this.dgvInventarioPlatillos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvInventarioPlatillos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarioPlatillos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventarioPlatillos.Location = new System.Drawing.Point(3, 39);
            this.dgvInventarioPlatillos.Name = "dgvInventarioPlatillos";
            this.dgvInventarioPlatillos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioPlatillos.Size = new System.Drawing.Size(1047, 284);
            this.dgvInventarioPlatillos.TabIndex = 0;
            this.dgvInventarioPlatillos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioPlatillos_CellClick);
            this.dgvInventarioPlatillos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioPlatillos_CellValueChanged);
            this.dgvInventarioPlatillos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInventarioPlatillos_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gray;
            this.groupBox2.Controls.Add(this.rbregistrado);
            this.groupBox2.Controls.Add(this.rbreventa);
            this.groupBox2.Controls.Add(this.rbmerma);
            this.groupBox2.Controls.Add(this.rbcongelado);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 175);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino";
            // 
            // rbregistrado
            // 
            this.rbregistrado.AutoSize = true;
            this.rbregistrado.Location = new System.Drawing.Point(0, 121);
            this.rbregistrado.Name = "rbregistrado";
            this.rbregistrado.Size = new System.Drawing.Size(143, 29);
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
            this.rbreventa.Size = new System.Drawing.Size(129, 29);
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
            this.rbmerma.Size = new System.Drawing.Size(104, 29);
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
            this.rbcongelado.Size = new System.Drawing.Size(147, 29);
            this.rbcongelado.TabIndex = 34;
            this.rbcongelado.TabStop = true;
            this.rbcongelado.Text = "Congelados";
            this.rbcongelado.UseVisualStyleBackColor = true;
            this.rbcongelado.CheckedChanged += new System.EventHandler(this.rbcongelado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "CV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "CP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(488, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cantidad Vendida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cantidad Programada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(260, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "CR:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(781, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "SR:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(661, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "S:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(303, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cantidad Real";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(817, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sobrante Real";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(684, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Sobrante";
            // 
            // dgvDiarios
            // 
            this.dgvDiarios.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDiarios.Location = new System.Drawing.Point(3, 401);
            this.dgvDiarios.Name = "dgvDiarios";
            this.dgvDiarios.Size = new System.Drawing.Size(1047, 284);
            this.dgvDiarios.TabIndex = 0;
            this.dgvDiarios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiarios_CellValueChanged);
            this.dgvDiarios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDiarios_DataError);
            // 
            // btCargarDiarios
            // 
            this.btCargarDiarios.BackColor = System.Drawing.Color.Black;
            this.btCargarDiarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCargarDiarios.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarDiarios.ForeColor = System.Drawing.Color.White;
            this.btCargarDiarios.Location = new System.Drawing.Point(3, 408);
            this.btCargarDiarios.Name = "btCargarDiarios";
            this.btCargarDiarios.Size = new System.Drawing.Size(243, 49);
            this.btCargarDiarios.TabIndex = 35;
            this.btCargarDiarios.Text = "Cargar Diarios";
            this.btCargarDiarios.UseVisualStyleBackColor = false;
            this.btCargarDiarios.Click += new System.EventHandler(this.btCargarDiarios_Click);
            // 
            // btPreviaPlatillo
            // 
            this.btPreviaPlatillo.BackColor = System.Drawing.Color.Black;
            this.btPreviaPlatillo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btPreviaPlatillo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaPlatillo.ForeColor = System.Drawing.Color.White;
            this.btPreviaPlatillo.Location = new System.Drawing.Point(3, 518);
            this.btPreviaPlatillo.Name = "btPreviaPlatillo";
            this.btPreviaPlatillo.Size = new System.Drawing.Size(243, 49);
            this.btPreviaPlatillo.TabIndex = 37;
            this.btPreviaPlatillo.Text = "Previa Platillo";
            this.btPreviaPlatillo.UseVisualStyleBackColor = false;
            this.btPreviaPlatillo.Click += new System.EventHandler(this.btPreviaPlatillo_Click);
            // 
            // btPreviaGlobal
            // 
            this.btPreviaGlobal.BackColor = System.Drawing.Color.Black;
            this.btPreviaGlobal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaGlobal.ForeColor = System.Drawing.Color.White;
            this.btPreviaGlobal.Location = new System.Drawing.Point(1123, 693);
            this.btPreviaGlobal.Name = "btPreviaGlobal";
            this.btPreviaGlobal.Size = new System.Drawing.Size(165, 36);
            this.btPreviaGlobal.TabIndex = 38;
            this.btPreviaGlobal.Text = "Previa Global";
            this.btPreviaGlobal.UseVisualStyleBackColor = false;
            this.btPreviaGlobal.Visible = false;
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
            // btGuardarDiarios
            // 
            this.btGuardarDiarios.BackColor = System.Drawing.Color.Black;
            this.btGuardarDiarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btGuardarDiarios.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarDiarios.ForeColor = System.Drawing.Color.White;
            this.btGuardarDiarios.Location = new System.Drawing.Point(3, 463);
            this.btGuardarDiarios.Name = "btGuardarDiarios";
            this.btGuardarDiarios.Size = new System.Drawing.Size(243, 49);
            this.btGuardarDiarios.TabIndex = 48;
            this.btGuardarDiarios.Text = "Guardar";
            this.btGuardarDiarios.UseVisualStyleBackColor = false;
            this.btGuardarDiarios.Click += new System.EventHandler(this.btGuardarDiarios_Click);
            // 
            // btEliminarFila
            // 
            this.btEliminarFila.BackColor = System.Drawing.Color.Black;
            this.btEliminarFila.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEliminarFila.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarFila.ForeColor = System.Drawing.Color.White;
            this.btEliminarFila.Location = new System.Drawing.Point(3, 628);
            this.btEliminarFila.Name = "btEliminarFila";
            this.btEliminarFila.Size = new System.Drawing.Size(243, 54);
            this.btEliminarFila.TabIndex = 49;
            this.btEliminarFila.Text = "EliminarFila";
            this.btEliminarFila.UseVisualStyleBackColor = false;
            this.btEliminarFila.Click += new System.EventHandler(this.btEliminarFila_Click);
            // 
            // btOrdendeTrabajo
            // 
            this.btOrdendeTrabajo.BackColor = System.Drawing.Color.Black;
            this.btOrdendeTrabajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOrdendeTrabajo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOrdendeTrabajo.ForeColor = System.Drawing.Color.White;
            this.btOrdendeTrabajo.Location = new System.Drawing.Point(3, 573);
            this.btOrdendeTrabajo.Name = "btOrdendeTrabajo";
            this.btOrdendeTrabajo.Size = new System.Drawing.Size(243, 49);
            this.btOrdendeTrabajo.TabIndex = 50;
            this.btOrdendeTrabajo.Text = "Orden de Trabajo";
            this.btOrdendeTrabajo.UseVisualStyleBackColor = false;
            this.btOrdendeTrabajo.Click += new System.EventHandler(this.btOrdendeTrabajo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 329);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1047, 30);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 691);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1047, 33);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(303, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 24);
            this.label18.TabIndex = 20;
            this.label18.Text = "Cantidad Elaborar";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(485, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 24);
            this.label19.TabIndex = 13;
            this.label19.Text = "CV:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(817, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 24);
            this.label20.TabIndex = 21;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(527, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(138, 24);
            this.label21.TabIndex = 15;
            this.label21.Text = "Cantidad Real";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(44, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(210, 24);
            this.label22.TabIndex = 16;
            this.label22.Text = "Cantidad Programada";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(260, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 24);
            this.label23.TabIndex = 17;
            this.label23.Text = "CR:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(781, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 24);
            this.label24.TabIndex = 18;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(661, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 24);
            this.label25.TabIndex = 19;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(684, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 24);
            this.label26.TabIndex = 22;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(1, 3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 24);
            this.label27.TabIndex = 14;
            this.label27.Text = "CP:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btOrdendeTrabajo, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btCargarDiarios, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btGuardarDiarios, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btPreviaPlatillo, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btEditar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btEliminarFila, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.btGuardar, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1093, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.02703F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 685);
            this.tableLayoutPanel1.TabIndex = 53;
            // 
            // btEditar
            // 
            this.btEditar.BackColor = System.Drawing.Color.Black;
            this.btEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEditar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditar.ForeColor = System.Drawing.Color.White;
            this.btEditar.Location = new System.Drawing.Point(3, 188);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(243, 49);
            this.btEditar.TabIndex = 45;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.Black;
            this.btGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btGuardar.Enabled = false;
            this.btGuardar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.ForeColor = System.Drawing.Color.White;
            this.btGuardar.Location = new System.Drawing.Point(3, 243);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(243, 49);
            this.btGuardar.TabIndex = 33;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.dgvInventarioPlatillos, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.dgvDiarios, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1053, 727);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bernard MT Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(3, 362);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1047, 36);
            this.label13.TabIndex = 54;
            this.label13.Text = "Menu del Dia";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bernard MT Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1047, 36);
            this.label12.TabIndex = 53;
            this.label12.Text = "Inventario Platillos";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Diario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btPreviaGlobal);
            this.Name = "Diario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diario";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Diario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioPlatillos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventarioPlatillos;
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
        private System.Windows.Forms.RadioButton rbreventa;
        private System.Windows.Forms.RadioButton rbmerma;
        private System.Windows.Forms.RadioButton rbcongelado;
        private System.Windows.Forms.DataGridView dgvDiarios;
        private System.Windows.Forms.Button btCargarDiarios;
        private System.Windows.Forms.Button btPreviaPlatillo;
        private System.Windows.Forms.Button btPreviaGlobal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btGuardarDiarios;
        private System.Windows.Forms.Button btEliminarFila;
        private System.Windows.Forms.RadioButton rbregistrado;
        private System.Windows.Forms.Button btOrdendeTrabajo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}