namespace ExcelAddIn1
{
    partial class Agregar_Congelados
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbfechaagregar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtgagregarcongelados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgagregarcongelados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha ;";
            // 
            // lbfechaagregar
            // 
            this.lbfechaagregar.AutoSize = true;
            this.lbfechaagregar.Location = new System.Drawing.Point(262, 9);
            this.lbfechaagregar.Name = "lbfechaagregar";
            this.lbfechaagregar.Size = new System.Drawing.Size(37, 13);
            this.lbfechaagregar.TabIndex = 3;
            this.lbfechaagregar.Text = "xxxxxx";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dtgagregarcongelados
            // 
            this.dtgagregarcongelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgagregarcongelados.Location = new System.Drawing.Point(12, 99);
            this.dtgagregarcongelados.Name = "dtgagregarcongelados";
            this.dtgagregarcongelados.Size = new System.Drawing.Size(344, 71);
            this.dtgagregarcongelados.TabIndex = 9;
            // 
            // Agregar_Congelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 201);
            this.Controls.Add(this.dtgagregarcongelados);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbfechaagregar);
            this.Controls.Add(this.label1);
            this.Name = "Agregar_Congelados";
            this.Text = "Agregar_Congelados";
            ((System.ComponentModel.ISupportInitialize)(this.dtgagregarcongelados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbfechaagregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgagregarcongelados;
    }
}