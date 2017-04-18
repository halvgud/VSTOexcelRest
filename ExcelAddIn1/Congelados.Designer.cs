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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btguardaragregar = new System.Windows.Forms.Button();
            this.dgvcongelados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscarcongelado = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btguardareditar = new System.Windows.Forms.Button();
            this.dgvcongeladobuscaryeditar = new System.Windows.Forms.DataGridView();
            this.txtbuscarcongeladoeditar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btbuscareditar = new System.Windows.Forms.Button();
            this.btreportecongelado = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongelados)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongeladobuscaryeditar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(634, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btguardaragregar);
            this.tabPage1.Controls.Add(this.dgvcongelados);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtbuscarcongelado);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(626, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.label1.Location = new System.Drawing.Point(26, 3);
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
            this.txtbuscarcongelado.TextChanged += new System.EventHandler(this.txtbuscarcongelado_TextChanged);
            this.txtbuscarcongelado.Enter += new System.EventHandler(this.txtbuscarcongelado_Enter);
            this.txtbuscarcongelado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbuscarcongelado_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btguardareditar);
            this.tabPage2.Controls.Add(this.dgvcongeladobuscaryeditar);
            this.tabPage2.Controls.Add(this.txtbuscarcongeladoeditar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btbuscareditar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(626, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buscar y Editar";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.dgvcongeladobuscaryeditar.Location = new System.Drawing.Point(21, 71);
            this.dgvcongeladobuscaryeditar.Name = "dgvcongeladobuscaryeditar";
            this.dgvcongeladobuscaryeditar.Size = new System.Drawing.Size(577, 141);
            this.dgvcongeladobuscaryeditar.TabIndex = 3;
            // 
            // txtbuscarcongeladoeditar
            // 
            this.txtbuscarcongeladoeditar.Location = new System.Drawing.Point(21, 32);
            this.txtbuscarcongeladoeditar.Name = "txtbuscarcongeladoeditar";
            this.txtbuscarcongeladoeditar.Size = new System.Drawing.Size(248, 20);
            this.txtbuscarcongeladoeditar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave/Descripcion :";
            // 
            // btbuscareditar
            // 
            this.btbuscareditar.Location = new System.Drawing.Point(287, 30);
            this.btbuscareditar.Name = "btbuscareditar";
            this.btbuscareditar.Size = new System.Drawing.Size(75, 23);
            this.btbuscareditar.TabIndex = 0;
            this.btbuscareditar.Text = "Buscar";
            this.btbuscareditar.UseVisualStyleBackColor = true;
            this.btbuscareditar.Click += new System.EventHandler(this.btbuscareditar_Click);
            // 
            // btreportecongelado
            // 
            this.btreportecongelado.Location = new System.Drawing.Point(537, 12);
            this.btreportecongelado.Name = "btreportecongelado";
            this.btreportecongelado.Size = new System.Drawing.Size(105, 46);
            this.btreportecongelado.TabIndex = 4;
            this.btreportecongelado.Text = "Reporte";
            this.btreportecongelado.UseVisualStyleBackColor = true;
            // 
            // Congelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 396);
            this.Controls.Add(this.btreportecongelado);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Congelados";
            this.Text = "Congelados";
            this.Load += new System.EventHandler(this.Congelados_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongelados)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcongeladobuscaryeditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscarcongelado;
        private System.Windows.Forms.Button btguardaragregar;
        private System.Windows.Forms.DataGridView dgvcongelados;
        private System.Windows.Forms.Button btguardareditar;
        private System.Windows.Forms.DataGridView dgvcongeladobuscaryeditar;
        private System.Windows.Forms.TextBox txtbuscarcongeladoeditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btbuscareditar;
        private System.Windows.Forms.Button btreportecongelado;
    }
}