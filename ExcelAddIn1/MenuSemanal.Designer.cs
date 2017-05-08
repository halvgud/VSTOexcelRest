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
        /// 
        private void InitializeComponent()
        {
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuSemanal));
            this.cmbManual = new PresentationControls.CheckBoxComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvViernes = new System.Windows.Forms.DataGridView();
            this.dgvJueves = new System.Windows.Forms.DataGridView();
            this.dgvMiercoles = new System.Windows.Forms.DataGridView();
            this.dgvMartes = new System.Windows.Forms.DataGridView();
            this.dgvDomingo = new System.Windows.Forms.DataGridView();
            this.dgvSabado = new System.Windows.Forms.DataGridView();
            this.FechaLunes = new System.Windows.Forms.Label();
            this.LabelLunes = new System.Windows.Forms.Label();
            this.FechaMartes = new System.Windows.Forms.Label();
            this.LabelMartes = new System.Windows.Forms.Label();
            this.FechaMiercoles = new System.Windows.Forms.Label();
            this.LabelMiercoles = new System.Windows.Forms.Label();
            this.FechaJueves = new System.Windows.Forms.Label();
            this.LabelJueves = new System.Windows.Forms.Label();
            this.FechaViernes = new System.Windows.Forms.Label();
            this.LabelViernes = new System.Windows.Forms.Label();
            this.FechaSabado = new System.Windows.Forms.Label();
            this.LabelSabado = new System.Windows.Forms.Label();
            this.FechaDomingo = new System.Windows.Forms.Label();
            this.LabelDomingo = new System.Windows.Forms.Label();
            this.dgvLunes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAgregarSemana = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDias = new PresentationControls.CheckBoxComboBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViernes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJueves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiercoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomingo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLunes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbManual
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbManual.CheckBoxProperties = checkBoxProperties1;
            this.cmbManual.DisplayMemberSingleItem = "";
            this.cmbManual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManual.FormattingEnabled = true;
            this.cmbManual.Location = new System.Drawing.Point(148, 24);
            this.cmbManual.Name = "cmbManual";
            this.cmbManual.Size = new System.Drawing.Size(151, 21);
            this.cmbManual.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.dgvViernes, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgvJueves, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgvMiercoles, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvMartes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvDomingo, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.dgvSabado, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.FechaLunes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelLunes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaMartes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelMartes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaMiercoles, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelMiercoles, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaJueves, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LabelJueves, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.FechaViernes, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LabelViernes, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FechaSabado, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.LabelSabado, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.FechaDomingo, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.LabelDomingo, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.dgvLunes, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1276, 633);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvViernes
            // 
            this.dgvViernes.AllowDrop = true;
            this.dgvViernes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViernes.Location = new System.Drawing.Point(428, 254);
            this.dgvViernes.Name = "dgvViernes";
            this.dgvViernes.Size = new System.Drawing.Size(419, 165);
            this.dgvViernes.TabIndex = 5;
            this.dgvViernes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvViernes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvViernes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvViernes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvJueves
            // 
            this.dgvJueves.AllowDrop = true;
            this.dgvJueves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJueves.Location = new System.Drawing.Point(3, 254);
            this.dgvJueves.Name = "dgvJueves";
            this.dgvJueves.Size = new System.Drawing.Size(419, 165);
            this.dgvJueves.TabIndex = 4;
            this.dgvJueves.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvJueves.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvJueves.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvJueves.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvMiercoles
            // 
            this.dgvMiercoles.AllowDrop = true;
            this.dgvMiercoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMiercoles.Location = new System.Drawing.Point(853, 43);
            this.dgvMiercoles.Name = "dgvMiercoles";
            this.dgvMiercoles.Size = new System.Drawing.Size(420, 165);
            this.dgvMiercoles.TabIndex = 3;
            this.dgvMiercoles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvMiercoles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvMiercoles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvMiercoles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvMartes
            // 
            this.dgvMartes.AllowDrop = true;
            this.dgvMartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMartes.Location = new System.Drawing.Point(428, 43);
            this.dgvMartes.Name = "dgvMartes";
            this.dgvMartes.Size = new System.Drawing.Size(419, 165);
            this.dgvMartes.TabIndex = 2;
            this.dgvMartes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvMartes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvMartes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvMartes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvDomingo
            // 
            this.dgvDomingo.AllowDrop = true;
            this.dgvDomingo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomingo.Location = new System.Drawing.Point(428, 465);
            this.dgvDomingo.Name = "dgvDomingo";
            this.dgvDomingo.Size = new System.Drawing.Size(419, 165);
            this.dgvDomingo.TabIndex = 7;
            this.dgvDomingo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDomingo_DataBindingComplete);
            this.dgvDomingo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvDomingo.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvDomingo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvDomingo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvSabado
            // 
            this.dgvSabado.AllowDrop = true;
            this.dgvSabado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSabado.Location = new System.Drawing.Point(853, 254);
            this.dgvSabado.Name = "dgvSabado";
            this.dgvSabado.Size = new System.Drawing.Size(420, 165);
            this.dgvSabado.TabIndex = 6;
            this.dgvSabado.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvSabado.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvSabado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvSabado.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // FechaLunes
            // 
            this.FechaLunes.AutoSize = true;
            this.FechaLunes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaLunes.Location = new System.Drawing.Point(3, 20);
            this.FechaLunes.Name = "FechaLunes";
            this.FechaLunes.Size = new System.Drawing.Size(13, 18);
            this.FechaLunes.TabIndex = 4;
            this.FechaLunes.Text = ".";
            this.FechaLunes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelLunes
            // 
            this.LabelLunes.AutoSize = true;
            this.LabelLunes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLunes.Location = new System.Drawing.Point(3, 0);
            this.LabelLunes.Name = "LabelLunes";
            this.LabelLunes.Size = new System.Drawing.Size(64, 18);
            this.LabelLunes.TabIndex = 8;
            this.LabelLunes.Text = "Lunes :";
            // 
            // FechaMartes
            // 
            this.FechaMartes.AutoSize = true;
            this.FechaMartes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaMartes.Location = new System.Drawing.Point(428, 20);
            this.FechaMartes.Name = "FechaMartes";
            this.FechaMartes.Size = new System.Drawing.Size(13, 18);
            this.FechaMartes.TabIndex = 4;
            this.FechaMartes.Text = ".";
            // 
            // LabelMartes
            // 
            this.LabelMartes.AutoSize = true;
            this.LabelMartes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMartes.Location = new System.Drawing.Point(428, 0);
            this.LabelMartes.Name = "LabelMartes";
            this.LabelMartes.Size = new System.Drawing.Size(69, 18);
            this.LabelMartes.TabIndex = 9;
            this.LabelMartes.Text = "Martes :";
            // 
            // FechaMiercoles
            // 
            this.FechaMiercoles.AutoSize = true;
            this.FechaMiercoles.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaMiercoles.Location = new System.Drawing.Point(853, 20);
            this.FechaMiercoles.Name = "FechaMiercoles";
            this.FechaMiercoles.Size = new System.Drawing.Size(13, 18);
            this.FechaMiercoles.TabIndex = 5;
            this.FechaMiercoles.Text = ".";
            // 
            // LabelMiercoles
            // 
            this.LabelMiercoles.AutoSize = true;
            this.LabelMiercoles.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMiercoles.Location = new System.Drawing.Point(853, 0);
            this.LabelMiercoles.Name = "LabelMiercoles";
            this.LabelMiercoles.Size = new System.Drawing.Size(89, 18);
            this.LabelMiercoles.TabIndex = 10;
            this.LabelMiercoles.Text = "Miercoles :";
            // 
            // FechaJueves
            // 
            this.FechaJueves.AutoSize = true;
            this.FechaJueves.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaJueves.Location = new System.Drawing.Point(3, 231);
            this.FechaJueves.Name = "FechaJueves";
            this.FechaJueves.Size = new System.Drawing.Size(13, 18);
            this.FechaJueves.TabIndex = 15;
            this.FechaJueves.Text = ".";
            // 
            // LabelJueves
            // 
            this.LabelJueves.AutoSize = true;
            this.LabelJueves.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelJueves.Location = new System.Drawing.Point(3, 211);
            this.LabelJueves.Name = "LabelJueves";
            this.LabelJueves.Size = new System.Drawing.Size(65, 18);
            this.LabelJueves.TabIndex = 11;
            this.LabelJueves.Text = "Jueves :";
            // 
            // FechaViernes
            // 
            this.FechaViernes.AutoSize = true;
            this.FechaViernes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaViernes.Location = new System.Drawing.Point(428, 231);
            this.FechaViernes.Name = "FechaViernes";
            this.FechaViernes.Size = new System.Drawing.Size(13, 18);
            this.FechaViernes.TabIndex = 5;
            this.FechaViernes.Text = ".";
            // 
            // LabelViernes
            // 
            this.LabelViernes.AutoSize = true;
            this.LabelViernes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelViernes.Location = new System.Drawing.Point(428, 211);
            this.LabelViernes.Name = "LabelViernes";
            this.LabelViernes.Size = new System.Drawing.Size(75, 18);
            this.LabelViernes.TabIndex = 12;
            this.LabelViernes.Text = "Viernes :";
            // 
            // FechaSabado
            // 
            this.FechaSabado.AutoSize = true;
            this.FechaSabado.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaSabado.Location = new System.Drawing.Point(853, 231);
            this.FechaSabado.Name = "FechaSabado";
            this.FechaSabado.Size = new System.Drawing.Size(13, 18);
            this.FechaSabado.TabIndex = 5;
            this.FechaSabado.Text = ".";
            // 
            // LabelSabado
            // 
            this.LabelSabado.AutoSize = true;
            this.LabelSabado.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSabado.Location = new System.Drawing.Point(853, 211);
            this.LabelSabado.Name = "LabelSabado";
            this.LabelSabado.Size = new System.Drawing.Size(70, 18);
            this.LabelSabado.TabIndex = 13;
            this.LabelSabado.Text = "Sabado :";
            // 
            // FechaDomingo
            // 
            this.FechaDomingo.AutoSize = true;
            this.FechaDomingo.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDomingo.Location = new System.Drawing.Point(428, 442);
            this.FechaDomingo.Name = "FechaDomingo";
            this.FechaDomingo.Size = new System.Drawing.Size(13, 18);
            this.FechaDomingo.TabIndex = 5;
            this.FechaDomingo.Text = ".";
            // 
            // LabelDomingo
            // 
            this.LabelDomingo.AutoSize = true;
            this.LabelDomingo.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDomingo.Location = new System.Drawing.Point(428, 422);
            this.LabelDomingo.Name = "LabelDomingo";
            this.LabelDomingo.Size = new System.Drawing.Size(85, 18);
            this.LabelDomingo.TabIndex = 14;
            this.LabelDomingo.Text = "Domingo :";
            // 
            // dgvLunes
            // 
            this.dgvLunes.AllowDrop = true;
            this.dgvLunes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLunes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvLunes.Location = new System.Drawing.Point(3, 43);
            this.dgvLunes.Name = "dgvLunes";
            this.dgvLunes.Size = new System.Drawing.Size(419, 165);
            this.dgvLunes.TabIndex = 1;
            this.dgvLunes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvLunes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvLunes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvLunes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAgregarSemana);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbDias);
            this.panel1.Controls.Add(this.DtpFecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 100);
            this.panel1.TabIndex = 4;
            // 
            // btAgregarSemana
            // 
            this.btAgregarSemana.Location = new System.Drawing.Point(756, 55);
            this.btAgregarSemana.Name = "btAgregarSemana";
            this.btAgregarSemana.Size = new System.Drawing.Size(143, 23);
            this.btAgregarSemana.TabIndex = 8;
            this.btAgregarSemana.Text = "Agregar Semana Actual";
            this.btAgregarSemana.UseVisualStyleBackColor = true;
            this.btAgregarSemana.Click += new System.EventHandler(this.btAgregarSemana_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dias a Agregar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // cbDias
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbDias.CheckBoxProperties = checkBoxProperties2;
            this.cbDias.DisplayMemberSingleItem = "";
            this.cbDias.FormattingEnabled = true;
            this.cbDias.Location = new System.Drawing.Point(620, 55);
            this.cbDias.Name = "cbDias";
            this.cbDias.Size = new System.Drawing.Size(121, 21);
            this.cbDias.TabIndex = 3;
            this.cbDias.SelectedIndexChanged += new System.EventHandler(this.cbDias_SelectedIndexChanged);
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(626, 11);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha.TabIndex = 7;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // MenuSemanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuSemanal";
            this.Text = "MenuSemanal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuSemanal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViernes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJueves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiercoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomingo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLunes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvSabado;
        private System.Windows.Forms.DataGridView dgvViernes;
        private System.Windows.Forms.DataGridView dgvDomingo;
        private System.Windows.Forms.Label LabelSabado;
        private System.Windows.Forms.Label LabelViernes;
        private System.Windows.Forms.Label LabelJueves;
        private System.Windows.Forms.Label LabelMiercoles;
        private System.Windows.Forms.Label LabelMartes;
        private System.Windows.Forms.DataGridView dgvMiercoles;
        private System.Windows.Forms.DataGridView dgvLunes;
        private System.Windows.Forms.Label LabelLunes;
        private System.Windows.Forms.Label LabelDomingo;
        private System.Windows.Forms.Label FechaMartes;
        private System.Windows.Forms.Label FechaLunes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FechaMiercoles;
        private System.Windows.Forms.Label FechaDomingo;
        private System.Windows.Forms.Label FechaViernes;
        private System.Windows.Forms.Label FechaSabado;
        private System.Windows.Forms.Label FechaJueves;
        private System.Windows.Forms.Panel panel1;

        private PresentationControls.CheckBoxComboBox cmbManual;
        private PresentationControls.CheckBoxComboBox cbDias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Button btAgregarSemana;
        private System.Windows.Forms.DataGridView dgvJueves;
        private System.Windows.Forms.DataGridView dgvMartes;
    }
}