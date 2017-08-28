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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbplatillo = new System.Windows.Forms.Label();
            this.dgingredientesReceta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecetasact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgingredientesReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvrecetasact
            // 
            this.dgvrecetasact.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvrecetasact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrecetasact.Location = new System.Drawing.Point(12, 51);
            this.dgvrecetasact.Name = "dgvrecetasact";
            this.dgvrecetasact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrecetasact.Size = new System.Drawing.Size(420, 225);
            this.dgvrecetasact.TabIndex = 1;
            this.dgvrecetasact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvrecetasact_CellClick);
            this.dgvrecetasact.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvrecetasact_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "ALERTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(450, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingredientes :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Receta :";
            // 
            // lbplatillo
            // 
            this.lbplatillo.AutoSize = true;
            this.lbplatillo.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbplatillo.Location = new System.Drawing.Point(531, 46);
            this.lbplatillo.Name = "lbplatillo";
            this.lbplatillo.Size = new System.Drawing.Size(28, 24);
            this.lbplatillo.TabIndex = 6;
            this.lbplatillo.Text = "...";
            // 
            // dgingredientesReceta
            // 
            this.dgingredientesReceta.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgingredientesReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgingredientesReceta.Location = new System.Drawing.Point(452, 119);
            this.dgingredientesReceta.Name = "dgingredientesReceta";
            this.dgingredientesReceta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgingredientesReceta.Size = new System.Drawing.Size(515, 157);
            this.dgingredientesReceta.TabIndex = 12;
            // 
            // ActualizarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(979, 296);
            this.Controls.Add(this.dgingredientesReceta);
            this.Controls.Add(this.lbplatillo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvrecetasact);
            this.Name = "ActualizarPrecios";
            this.Text = "Actualizar_Precios";
            this.Load += new System.EventHandler(this.Actualizar_Precios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecetasact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgingredientesReceta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvrecetasact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbplatillo;
        private System.Windows.Forms.DataGridView dgingredientesReceta;
    }
}