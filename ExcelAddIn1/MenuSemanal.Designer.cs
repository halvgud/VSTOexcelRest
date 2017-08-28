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
            this.FechaMartes = new System.Windows.Forms.Label();
            this.FechaLunes = new System.Windows.Forms.Label();
            this.LabelLunes = new System.Windows.Forms.Label();
            this.dgvMartes = new System.Windows.Forms.DataGridView();
            this.LabelMiercoles = new System.Windows.Forms.Label();
            this.FechaMiercoles = new System.Windows.Forms.Label();
            this.dgvMiercoles = new System.Windows.Forms.DataGridView();
            this.LabelJueves = new System.Windows.Forms.Label();
            this.FechaJueves = new System.Windows.Forms.Label();
            this.LabelViernes = new System.Windows.Forms.Label();
            this.FechaViernes = new System.Windows.Forms.Label();
            this.dgvViernes = new System.Windows.Forms.DataGridView();
            this.LabelSabado = new System.Windows.Forms.Label();
            this.FechaSabado = new System.Windows.Forms.Label();
            this.dgvSabado = new System.Windows.Forms.DataGridView();
            this.LabelDomingo = new System.Windows.Forms.Label();
            this.FechaDomingo = new System.Windows.Forms.Label();
            this.LabelMartes = new System.Windows.Forms.Label();
            this.dgvDomingo = new System.Windows.Forms.DataGridView();
            this.tbPreviaPlatillo = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLunes = new System.Windows.Forms.DataGridView();
            this.dgvJueves = new System.Windows.Forms.DataGridView();
            this.btGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbDias = new PresentationControls.CheckBoxComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btAgregarSemana = new System.Windows.Forms.Button();
            this.btPreviaPlatilloGlobal = new System.Windows.Forms.Button();
            this.btEditarSemana = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btBorrarFila = new System.Windows.Forms.Button();
            this.btPreviaPlatillo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiercoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViernes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomingo)).BeginInit();
            this.tbPreviaPlatillo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLunes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJueves)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // FechaMartes
            // 
            this.FechaMartes.AutoSize = true;
            this.FechaMartes.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaMartes.Location = new System.Drawing.Point(640, 16);
            this.FechaMartes.Name = "FechaMartes";
            this.FechaMartes.Size = new System.Drawing.Size(11, 15);
            this.FechaMartes.TabIndex = 4;
            this.FechaMartes.Text = ".";
            this.FechaMartes.Click += new System.EventHandler(this.FechaMartes_Click);
            // 
            // FechaLunes
            // 
            this.FechaLunes.AutoSize = true;
            this.FechaLunes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaLunes.Location = new System.Drawing.Point(3, 16);
            this.FechaLunes.Name = "FechaLunes";
            this.FechaLunes.Size = new System.Drawing.Size(11, 16);
            this.FechaLunes.TabIndex = 4;
            this.FechaLunes.Text = ".";
            this.FechaLunes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelLunes
            // 
            this.LabelLunes.AutoSize = true;
            this.LabelLunes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLunes.Location = new System.Drawing.Point(3, 0);
            this.LabelLunes.Name = "LabelLunes";
            this.LabelLunes.Size = new System.Drawing.Size(54, 16);
            this.LabelLunes.TabIndex = 8;
            this.LabelLunes.Text = "Lunes :";
            // 
            // dgvMartes
            // 
            this.dgvMartes.AllowDrop = true;
            this.dgvMartes.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvMartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMartes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMartes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMartes.Location = new System.Drawing.Point(640, 35);
            this.dgvMartes.Name = "dgvMartes";
            this.dgvMartes.Size = new System.Drawing.Size(632, 128);
            this.dgvMartes.TabIndex = 2;
            this.dgvMartes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvMartes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvMartes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvMartes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvMartes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvMartes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvMartes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvMartes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvMartes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvMartes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // LabelMiercoles
            // 
            this.LabelMiercoles.AutoSize = true;
            this.LabelMiercoles.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMiercoles.Location = new System.Drawing.Point(3, 166);
            this.LabelMiercoles.Name = "LabelMiercoles";
            this.LabelMiercoles.Size = new System.Drawing.Size(77, 16);
            this.LabelMiercoles.TabIndex = 10;
            this.LabelMiercoles.Text = "Miercoles :";
            // 
            // FechaMiercoles
            // 
            this.FechaMiercoles.AutoSize = true;
            this.FechaMiercoles.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaMiercoles.Location = new System.Drawing.Point(3, 182);
            this.FechaMiercoles.Name = "FechaMiercoles";
            this.FechaMiercoles.Size = new System.Drawing.Size(12, 16);
            this.FechaMiercoles.TabIndex = 5;
            this.FechaMiercoles.Text = ".";
            // 
            // dgvMiercoles
            // 
            this.dgvMiercoles.AllowDrop = true;
            this.dgvMiercoles.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvMiercoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMiercoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMiercoles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMiercoles.Location = new System.Drawing.Point(3, 201);
            this.dgvMiercoles.Name = "dgvMiercoles";
            this.dgvMiercoles.Size = new System.Drawing.Size(631, 128);
            this.dgvMiercoles.TabIndex = 3;
            this.dgvMiercoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvMiercoles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvMiercoles.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvMiercoles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvMiercoles.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvMiercoles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvMiercoles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvMiercoles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvMiercoles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvMiercoles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // LabelJueves
            // 
            this.LabelJueves.AutoSize = true;
            this.LabelJueves.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelJueves.Location = new System.Drawing.Point(640, 166);
            this.LabelJueves.Name = "LabelJueves";
            this.LabelJueves.Size = new System.Drawing.Size(60, 16);
            this.LabelJueves.TabIndex = 11;
            this.LabelJueves.Text = "Jueves :";
            // 
            // FechaJueves
            // 
            this.FechaJueves.AutoSize = true;
            this.FechaJueves.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaJueves.Location = new System.Drawing.Point(640, 182);
            this.FechaJueves.Name = "FechaJueves";
            this.FechaJueves.Size = new System.Drawing.Size(12, 16);
            this.FechaJueves.TabIndex = 15;
            this.FechaJueves.Text = ".";
            // 
            // LabelViernes
            // 
            this.LabelViernes.AutoSize = true;
            this.LabelViernes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelViernes.Location = new System.Drawing.Point(3, 332);
            this.LabelViernes.Name = "LabelViernes";
            this.LabelViernes.Size = new System.Drawing.Size(64, 16);
            this.LabelViernes.TabIndex = 12;
            this.LabelViernes.Text = "Viernes :";
            // 
            // FechaViernes
            // 
            this.FechaViernes.AutoSize = true;
            this.FechaViernes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaViernes.Location = new System.Drawing.Point(3, 348);
            this.FechaViernes.Name = "FechaViernes";
            this.FechaViernes.Size = new System.Drawing.Size(12, 16);
            this.FechaViernes.TabIndex = 5;
            this.FechaViernes.Text = ".";
            // 
            // dgvViernes
            // 
            this.dgvViernes.AllowDrop = true;
            this.dgvViernes.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvViernes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViernes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViernes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvViernes.Location = new System.Drawing.Point(3, 367);
            this.dgvViernes.Name = "dgvViernes";
            this.dgvViernes.Size = new System.Drawing.Size(631, 128);
            this.dgvViernes.TabIndex = 5;
            this.dgvViernes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvViernes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvViernes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvViernes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvViernes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvViernes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvViernes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvViernes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvViernes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvViernes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // LabelSabado
            // 
            this.LabelSabado.AutoSize = true;
            this.LabelSabado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSabado.Location = new System.Drawing.Point(640, 332);
            this.LabelSabado.Name = "LabelSabado";
            this.LabelSabado.Size = new System.Drawing.Size(65, 16);
            this.LabelSabado.TabIndex = 13;
            this.LabelSabado.Text = "Sabado :";
            // 
            // FechaSabado
            // 
            this.FechaSabado.AutoSize = true;
            this.FechaSabado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaSabado.Location = new System.Drawing.Point(640, 348);
            this.FechaSabado.Name = "FechaSabado";
            this.FechaSabado.Size = new System.Drawing.Size(12, 16);
            this.FechaSabado.TabIndex = 5;
            this.FechaSabado.Text = ".";
            // 
            // dgvSabado
            // 
            this.dgvSabado.AllowDrop = true;
            this.dgvSabado.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvSabado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSabado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSabado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSabado.Location = new System.Drawing.Point(640, 367);
            this.dgvSabado.Name = "dgvSabado";
            this.dgvSabado.Size = new System.Drawing.Size(632, 128);
            this.dgvSabado.TabIndex = 6;
            this.dgvSabado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvSabado.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvSabado.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvSabado.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvSabado.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvSabado.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvSabado.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvSabado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvSabado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvSabado.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // LabelDomingo
            // 
            this.LabelDomingo.AutoSize = true;
            this.LabelDomingo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDomingo.Location = new System.Drawing.Point(3, 498);
            this.LabelDomingo.Name = "LabelDomingo";
            this.LabelDomingo.Size = new System.Drawing.Size(73, 16);
            this.LabelDomingo.TabIndex = 14;
            this.LabelDomingo.Text = "Domingo :";
            // 
            // FechaDomingo
            // 
            this.FechaDomingo.AutoSize = true;
            this.FechaDomingo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDomingo.Location = new System.Drawing.Point(3, 514);
            this.FechaDomingo.Name = "FechaDomingo";
            this.FechaDomingo.Size = new System.Drawing.Size(12, 16);
            this.FechaDomingo.TabIndex = 5;
            this.FechaDomingo.Text = ".";
            // 
            // LabelMartes
            // 
            this.LabelMartes.AutoSize = true;
            this.LabelMartes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMartes.Location = new System.Drawing.Point(640, 0);
            this.LabelMartes.Name = "LabelMartes";
            this.LabelMartes.Size = new System.Drawing.Size(58, 16);
            this.LabelMartes.TabIndex = 9;
            this.LabelMartes.Text = "Martes :";
            // 
            // dgvDomingo
            // 
            this.dgvDomingo.AllowDrop = true;
            this.dgvDomingo.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDomingo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomingo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDomingo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDomingo.Location = new System.Drawing.Point(3, 533);
            this.dgvDomingo.Name = "dgvDomingo";
            this.dgvDomingo.Size = new System.Drawing.Size(631, 135);
            this.dgvDomingo.TabIndex = 17;
            this.dgvDomingo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvDomingo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvDomingo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvDomingo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvDomingo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvDomingo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvDomingo.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvDomingo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvDomingo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvDomingo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // tbPreviaPlatillo
            // 
            this.tbPreviaPlatillo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPreviaPlatillo.BackColor = System.Drawing.Color.White;
            this.tbPreviaPlatillo.ColumnCount = 2;
            this.tbPreviaPlatillo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPreviaPlatillo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPreviaPlatillo.Controls.Add(this.LabelMartes, 1, 0);
            this.tbPreviaPlatillo.Controls.Add(this.FechaMartes, 1, 1);
            this.tbPreviaPlatillo.Controls.Add(this.dgvLunes, 0, 2);
            this.tbPreviaPlatillo.Controls.Add(this.FechaDomingo, 0, 10);
            this.tbPreviaPlatillo.Controls.Add(this.LabelDomingo, 0, 9);
            this.tbPreviaPlatillo.Controls.Add(this.FechaLunes, 0, 1);
            this.tbPreviaPlatillo.Controls.Add(this.LabelLunes, 0, 0);
            this.tbPreviaPlatillo.Controls.Add(this.dgvSabado, 1, 8);
            this.tbPreviaPlatillo.Controls.Add(this.FechaSabado, 1, 7);
            this.tbPreviaPlatillo.Controls.Add(this.LabelSabado, 1, 6);
            this.tbPreviaPlatillo.Controls.Add(this.dgvViernes, 0, 8);
            this.tbPreviaPlatillo.Controls.Add(this.FechaViernes, 0, 7);
            this.tbPreviaPlatillo.Controls.Add(this.LabelViernes, 0, 6);
            this.tbPreviaPlatillo.Controls.Add(this.FechaJueves, 1, 4);
            this.tbPreviaPlatillo.Controls.Add(this.LabelJueves, 1, 3);
            this.tbPreviaPlatillo.Controls.Add(this.dgvMiercoles, 0, 5);
            this.tbPreviaPlatillo.Controls.Add(this.FechaMiercoles, 0, 4);
            this.tbPreviaPlatillo.Controls.Add(this.LabelMiercoles, 0, 3);
            this.tbPreviaPlatillo.Controls.Add(this.dgvMartes, 1, 2);
            this.tbPreviaPlatillo.Controls.Add(this.dgvJueves, 1, 5);
            this.tbPreviaPlatillo.Controls.Add(this.dgvDomingo, 0, 11);
            this.tbPreviaPlatillo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPreviaPlatillo.Location = new System.Drawing.Point(0, 58);
            this.tbPreviaPlatillo.Name = "tbPreviaPlatillo";
            this.tbPreviaPlatillo.RowCount = 12;
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tbPreviaPlatillo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPreviaPlatillo.Size = new System.Drawing.Size(1275, 671);
            this.tbPreviaPlatillo.TabIndex = 3;
            // 
            // dgvLunes
            // 
            this.dgvLunes.AllowDrop = true;
            this.dgvLunes.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvLunes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLunes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLunes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvLunes.Location = new System.Drawing.Point(3, 35);
            this.dgvLunes.Name = "dgvLunes";
            this.dgvLunes.Size = new System.Drawing.Size(631, 128);
            this.dgvLunes.TabIndex = 1;
            this.dgvLunes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvLunes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvLunes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvLunes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvLunes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvLunes.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvLunes.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvLunes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvLunes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvLunes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // dgvJueves
            // 
            this.dgvJueves.AllowDrop = true;
            this.dgvJueves.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvJueves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJueves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJueves.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJueves.Location = new System.Drawing.Point(640, 201);
            this.dgvJueves.Name = "dgvJueves";
            this.dgvJueves.Size = new System.Drawing.Size(632, 128);
            this.dgvJueves.TabIndex = 18;
            this.dgvJueves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellClick);
            this.dgvJueves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJueves_CellContentClick);
            this.dgvJueves.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenerico_CellValueChanged);
            this.dgvJueves.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGenerico_CurrentCellDirtyStateChanged);
            this.dgvJueves.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGenerico_DataError);
            this.dgvJueves.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Generico_EditingControlShowing);
            this.dgvJueves.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragDrop);
            this.dgvJueves.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGenerico_DragOver);
            this.dgvJueves.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGenerico_KeyPress);
            this.dgvJueves.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseDown);
            this.dgvJueves.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGenerico_MouseMove);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.Black;
            this.btGuardar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.ForeColor = System.Drawing.Color.White;
            this.btGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGuardar.Location = new System.Drawing.Point(792, 32);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(145, 24);
            this.btGuardar.TabIndex = 16;
            this.btGuardar.Text = "Guardar Menu";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Semana a Mostrar:";
            // 
            // DtpFecha
            // 
            this.DtpFecha.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DtpFecha.Location = new System.Drawing.Point(169, 32);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha.TabIndex = 7;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // cbDias
            // 
            this.cbDias.BackColor = System.Drawing.Color.Silver;
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbDias.CheckBoxProperties = checkBoxProperties2;
            this.cbDias.DisplayMemberSingleItem = "";
            this.cbDias.FormattingEnabled = true;
            this.cbDias.Location = new System.Drawing.Point(389, 30);
            this.cbDias.Name = "cbDias";
            this.cbDias.Size = new System.Drawing.Size(200, 21);
            this.cbDias.TabIndex = 3;
            this.cbDias.SelectedIndexChanged += new System.EventHandler(this.cbDias_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(422, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dias a Agregar:";
            // 
            // btAgregarSemana
            // 
            this.btAgregarSemana.BackColor = System.Drawing.Color.Black;
            this.btAgregarSemana.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregarSemana.ForeColor = System.Drawing.Color.White;
            this.btAgregarSemana.Location = new System.Drawing.Point(595, 19);
            this.btAgregarSemana.Name = "btAgregarSemana";
            this.btAgregarSemana.Size = new System.Drawing.Size(169, 33);
            this.btAgregarSemana.TabIndex = 8;
            this.btAgregarSemana.Text = "Agregar Semana Posterior";
            this.btAgregarSemana.UseVisualStyleBackColor = false;
            this.btAgregarSemana.Click += new System.EventHandler(this.btAgregarSemana_Click);
            // 
            // btPreviaPlatilloGlobal
            // 
            this.btPreviaPlatilloGlobal.BackColor = System.Drawing.Color.Black;
            this.btPreviaPlatilloGlobal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaPlatilloGlobal.ForeColor = System.Drawing.Color.Cornsilk;
            this.btPreviaPlatilloGlobal.Location = new System.Drawing.Point(948, 5);
            this.btPreviaPlatilloGlobal.Name = "btPreviaPlatilloGlobal";
            this.btPreviaPlatilloGlobal.Size = new System.Drawing.Size(151, 24);
            this.btPreviaPlatilloGlobal.TabIndex = 17;
            this.btPreviaPlatilloGlobal.Text = "Imprimir Previa Global";
            this.btPreviaPlatilloGlobal.UseVisualStyleBackColor = false;
            this.btPreviaPlatilloGlobal.Click += new System.EventHandler(this.btPreviaPlatilloGlobal_Click);
            // 
            // btEditarSemana
            // 
            this.btEditarSemana.BackColor = System.Drawing.Color.Black;
            this.btEditarSemana.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditarSemana.ForeColor = System.Drawing.Color.White;
            this.btEditarSemana.Location = new System.Drawing.Point(792, 5);
            this.btEditarSemana.Name = "btEditarSemana";
            this.btEditarSemana.Size = new System.Drawing.Size(145, 25);
            this.btEditarSemana.TabIndex = 18;
            this.btEditarSemana.Text = "Editar Semana Actual";
            this.btEditarSemana.UseVisualStyleBackColor = false;
            this.btEditarSemana.Click += new System.EventHandler(this.btEditarSemana_Click);
            // 
            // btBorrarFila
            // 
            this.btBorrarFila.BackColor = System.Drawing.Color.Black;
            this.btBorrarFila.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBorrarFila.ForeColor = System.Drawing.Color.Cornsilk;
            this.btBorrarFila.Location = new System.Drawing.Point(1105, 30);
            this.btBorrarFila.Name = "btBorrarFila";
            this.btBorrarFila.Size = new System.Drawing.Size(145, 26);
            this.btBorrarFila.TabIndex = 18;
            this.btBorrarFila.Text = "Borrar Fila";
            this.btBorrarFila.UseVisualStyleBackColor = false;
            this.btBorrarFila.Click += new System.EventHandler(this.btBorrarFila_Click);
            // 
            // btPreviaPlatillo
            // 
            this.btPreviaPlatillo.BackColor = System.Drawing.Color.Black;
            this.btPreviaPlatillo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviaPlatillo.ForeColor = System.Drawing.Color.Cornsilk;
            this.btPreviaPlatillo.Location = new System.Drawing.Point(948, 32);
            this.btPreviaPlatillo.Name = "btPreviaPlatillo";
            this.btPreviaPlatillo.Size = new System.Drawing.Size(151, 24);
            this.btPreviaPlatillo.TabIndex = 20;
            this.btPreviaPlatillo.Text = "Imprimir Previa Platillo";
            this.btPreviaPlatillo.UseVisualStyleBackColor = false;
            this.btPreviaPlatillo.Click += new System.EventHandler(this.btPreviaPlatillo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btBorrarFila);
            this.groupBox1.Controls.Add(this.btPreviaPlatillo);
            this.groupBox1.Controls.Add(this.DtpFecha);
            this.groupBox1.Controls.Add(this.btGuardar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btPreviaPlatilloGlobal);
            this.groupBox1.Controls.Add(this.cbDias);
            this.groupBox1.Controls.Add(this.btEditarSemana);
            this.groupBox1.Controls.Add(this.btAgregarSemana);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1275, 55);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // MenuSemanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 733);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbPreviaPlatillo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuSemanal";
            this.Text = "MenuSemanal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuSemanal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiercoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViernes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomingo)).EndInit();
            this.tbPreviaPlatillo.ResumeLayout(false);
            this.tbPreviaPlatillo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLunes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJueves)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;

        private PresentationControls.CheckBoxComboBox cmbManual;
        private PresentationControls.CheckBoxComboBox cbDias;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Button btAgregarSemana;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btPreviaPlatilloGlobal;
        private System.Windows.Forms.Label FechaMartes;
        private System.Windows.Forms.Label FechaLunes;
        private System.Windows.Forms.Label LabelLunes;
        private System.Windows.Forms.DataGridView dgvMartes;
        private System.Windows.Forms.Label LabelMiercoles;
        private System.Windows.Forms.Label FechaMiercoles;
        private System.Windows.Forms.DataGridView dgvMiercoles;
        private System.Windows.Forms.Label LabelJueves;
        private System.Windows.Forms.Label FechaJueves;
        private System.Windows.Forms.Label LabelViernes;
        private System.Windows.Forms.Label FechaViernes;
        private System.Windows.Forms.DataGridView dgvViernes;
        private System.Windows.Forms.Label LabelSabado;
        private System.Windows.Forms.Label FechaSabado;
        private System.Windows.Forms.DataGridView dgvSabado;
        private System.Windows.Forms.Label LabelDomingo;
        private System.Windows.Forms.Label FechaDomingo;
        private System.Windows.Forms.Label LabelMartes;
        private System.Windows.Forms.DataGridView dgvDomingo;
        private System.Windows.Forms.TableLayoutPanel tbPreviaPlatillo;
        private System.Windows.Forms.DataGridView dgvLunes;
        private System.Windows.Forms.Button btEditarSemana;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btBorrarFila;
        private System.Windows.Forms.DataGridView dgvJueves;
        private System.Windows.Forms.Button btPreviaPlatillo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}