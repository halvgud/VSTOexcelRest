namespace ExcelAddIn1
{
    partial class Congelados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Congelados));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpagregar = new System.Windows.Forms.TabPage();
            this.btguardaragregar = new System.Windows.Forms.Button();
            this.dgvcongelados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscarcongelado = new System.Windows.Forms.TextBox();
            this.tpbuscaryeditar = new System.Windows.Forms.TabPage();
            this.btguardareditar = new System.Windows.Forms.Button();
            this.dgvcongeladobuscaryeditar = new System.Windows.Forms.DataGridView();
            this.txtbuscarcongeladoeditar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btbuscareditar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpagregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongelados)).BeginInit();
            this.tpbuscaryeditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongeladobuscaryeditar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpagregar);
            this.tabControl1.Controls.Add(this.tpbuscaryeditar);
            this.tabControl1.Location = new System.Drawing.Point(12, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(634, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // tpagregar
            // 
            this.tpagregar.Controls.Add(this.btguardaragregar);
            this.tpagregar.Controls.Add(this.dgvcongelados);
            this.tpagregar.Controls.Add(this.label1);
            this.tpagregar.Controls.Add(this.txtbuscarcongelado);
            this.tpagregar.Location = new System.Drawing.Point(4, 22);
            this.tpagregar.Name = "tpagregar";
            this.tpagregar.Padding = new System.Windows.Forms.Padding(3);
            this.tpagregar.Size = new System.Drawing.Size(626, 304);
            this.tpagregar.TabIndex = 0;
            this.tpagregar.Text = "Agregar";
            this.tpagregar.UseVisualStyleBackColor = true;
            // 
            // btguardaragregar
            // 
            this.btguardaragregar.Location = new System.Drawing.Point(29, 259);
            this.btguardaragregar.Name = "btguardaragregar";
            this.btguardaragregar.Size = new System.Drawing.Size(69, 39);
            this.btguardaragregar.TabIndex = 3;
            this.btguardaragregar.Text = "Guardar";
            this.btguardaragregar.UseVisualStyleBackColor = true;
            // 
            // dgvcongelados
            // 
            this.dgvcongelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcongelados.Location = new System.Drawing.Point(29, 79);
            this.dgvcongelados.Name = "dgvcongelados";
            this.dgvcongelados.Size = new System.Drawing.Size(562, 161);
            this.dgvcongelados.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clave/Descripcion :";
            // 
            // txtbuscarcongelado
            // 
            this.txtbuscarcongelado.Location = new System.Drawing.Point(29, 28);
            this.txtbuscarcongelado.Name = "txtbuscarcongelado";
            this.txtbuscarcongelado.Size = new System.Drawing.Size(562, 20);
            this.txtbuscarcongelado.TabIndex = 0;
            this.txtbuscarcongelado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbuscarcongelado_KeyDown);
            // 
            // tpbuscaryeditar
            // 
            this.tpbuscaryeditar.Controls.Add(this.btguardareditar);
            this.tpbuscaryeditar.Controls.Add(this.dgvcongeladobuscaryeditar);
            this.tpbuscaryeditar.Controls.Add(this.txtbuscarcongeladoeditar);
            this.tpbuscaryeditar.Controls.Add(this.label2);
            this.tpbuscaryeditar.Controls.Add(this.btbuscareditar);
            this.tpbuscaryeditar.Location = new System.Drawing.Point(4, 22);
            this.tpbuscaryeditar.Name = "tpbuscaryeditar";
            this.tpbuscaryeditar.Padding = new System.Windows.Forms.Padding(3);
            this.tpbuscaryeditar.Size = new System.Drawing.Size(626, 304);
            this.tpbuscaryeditar.TabIndex = 1;
            this.tpbuscaryeditar.Text = "Buscar y Editar";
            this.tpbuscaryeditar.UseVisualStyleBackColor = true;
            // 
            // btguardareditar
            // 
            this.btguardareditar.Location = new System.Drawing.Point(512, 233);
            this.btguardareditar.Name = "btguardareditar";
            this.btguardareditar.Size = new System.Drawing.Size(86, 28);
            this.btguardareditar.TabIndex = 4;
            this.btguardareditar.Text = "Guardar";
            this.btguardareditar.UseVisualStyleBackColor = true;
            this.btguardareditar.Click += new System.EventHandler(this.btguardareditar_Click);
            // 
            // dgvcongeladobuscaryeditar
            // 
            this.dgvcongeladobuscaryeditar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcongeladobuscaryeditar.Location = new System.Drawing.Point(21, 86);
            this.dgvcongeladobuscaryeditar.Name = "dgvcongeladobuscaryeditar";
            this.dgvcongeladobuscaryeditar.Size = new System.Drawing.Size(577, 141);
            this.dgvcongeladobuscaryeditar.TabIndex = 3;
            // 
            // txtbuscarcongeladoeditar
            // 
            this.txtbuscarcongeladoeditar.Location = new System.Drawing.Point(21, 49);
            this.txtbuscarcongeladoeditar.Name = "txtbuscarcongeladoeditar";
            this.txtbuscarcongeladoeditar.Size = new System.Drawing.Size(248, 20);
            this.txtbuscarcongeladoeditar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave/Descripcion :";
            // 
            // btbuscareditar
            // 
            this.btbuscareditar.Location = new System.Drawing.Point(287, 47);
            this.btbuscareditar.Name = "btbuscareditar";
            this.btbuscareditar.Size = new System.Drawing.Size(75, 23);
            this.btbuscareditar.TabIndex = 0;
            this.btbuscareditar.Text = "Buscar";
            this.btbuscareditar.UseVisualStyleBackColor = true;
            this.btbuscareditar.Click += new System.EventHandler(this.btbuscareditar_Click);
            // 
            // Congelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 370);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Congelados";
            this.Text = "Congelados";
            this.Load += new System.EventHandler(this.Congelados_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpagregar.ResumeLayout(false);
            this.tpagregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongelados)).EndInit();
            this.tpbuscaryeditar.ResumeLayout(false);
            this.tpbuscaryeditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongeladobuscaryeditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscarcongelado;
        private System.Windows.Forms.Button btguardaragregar;
        private System.Windows.Forms.DataGridView dgvcongelados;
        private System.Windows.Forms.Button btguardareditar;
        private System.Windows.Forms.DataGridView dgvcongeladobuscaryeditar;
        private System.Windows.Forms.TextBox txtbuscarcongeladoeditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btbuscareditar;
        public System.Windows.Forms.TabPage tpagregar;
        public System.Windows.Forms.TabPage tpbuscaryeditar;
        public System.Windows.Forms.TabControl tabControl1;
    }
}