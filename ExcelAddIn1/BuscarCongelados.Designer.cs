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
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscar_congelados)).BeginInit();
            this.SuspendLayout();
            // 
            // btaceptarbcongelados
            // 
            this.btaceptarbcongelados.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btaceptarbcongelados.Location = new System.Drawing.Point(349, 22);
            this.btaceptarbcongelados.Name = "btaceptarbcongelados";
            this.btaceptarbcongelados.Size = new System.Drawing.Size(75, 36);
            this.btaceptarbcongelados.TabIndex = 0;
            this.btaceptarbcongelados.Text = "Aceptar";
            this.btaceptarbcongelados.UseVisualStyleBackColor = true;
            // 
            // dgvbuscar_congelados
            // 
            this.dgvbuscar_congelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbuscar_congelados.Location = new System.Drawing.Point(12, 12);
            this.dgvbuscar_congelados.Name = "dgvbuscar_congelados";
            this.dgvbuscar_congelados.Size = new System.Drawing.Size(306, 186);
            this.dgvbuscar_congelados.TabIndex = 1;
            // 
            // BuscarCongelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 219);
            this.Controls.Add(this.dgvbuscar_congelados);
            this.Controls.Add(this.btaceptarbcongelados);
            this.Name = "BuscarCongelados";
            this.Text = "BuscarCongelados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscar_congelados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btaceptarbcongelados;
        private System.Windows.Forms.DataGridView dgvbuscar_congelados;
    }
}