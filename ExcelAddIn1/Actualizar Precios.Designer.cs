namespace ExcelAddIn1
{
    partial class ActualizarPrecios
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
            this.dgvrecetasact = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvingredientes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecetasact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvingredientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvrecetasact
            // 
            this.dgvrecetasact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrecetasact.Location = new System.Drawing.Point(12, 51);
            this.dgvrecetasact.Name = "dgvrecetasact";
            this.dgvrecetasact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrecetasact.Size = new System.Drawing.Size(509, 77);
            this.dgvrecetasact.TabIndex = 1;
            this.dgvrecetasact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvrecetasact_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recetas que necesitan actualizacion de precio.";
            // 
            // dgvingredientes
            // 
            this.dgvingredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvingredientes.Location = new System.Drawing.Point(24, 27);
            this.dgvingredientes.Name = "dgvingredientes";
            this.dgvingredientes.Size = new System.Drawing.Size(403, 77);
            this.dgvingredientes.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvingredientes);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredientes";
            // 
            // Actualizar_Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvrecetasact);
            this.Name = "ActualizarPrecios";
            this.Text = "Actualizar_Precios";
            this.Load += new System.EventHandler(this.Actualizar_Precios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecetasact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvingredientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvrecetasact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvingredientes;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}