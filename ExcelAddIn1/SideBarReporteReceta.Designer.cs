namespace ExcelAddIn1
{
    partial class SideBarReporteReceta
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbConceptoReceta = new System.Windows.Forms.ComboBox();
            this.cbOrdenarReceta = new System.Windows.Forms.ComboBox();
            this.tbProducto = new System.Windows.Forms.TextBox();
            this.btGenerarReceta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concepto :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ordenar por :";
            // 
            // cbConceptoReceta
            // 
            this.cbConceptoReceta.FormattingEnabled = true;
            this.cbConceptoReceta.Location = new System.Drawing.Point(98, 71);
            this.cbConceptoReceta.Name = "cbConceptoReceta";
            this.cbConceptoReceta.Size = new System.Drawing.Size(121, 21);
            this.cbConceptoReceta.TabIndex = 3;
            // 
            // cbOrdenarReceta
            // 
            this.cbOrdenarReceta.FormattingEnabled = true;
            this.cbOrdenarReceta.Location = new System.Drawing.Point(98, 151);
            this.cbOrdenarReceta.Name = "cbOrdenarReceta";
            this.cbOrdenarReceta.Size = new System.Drawing.Size(121, 21);
            this.cbOrdenarReceta.TabIndex = 4;
            // 
            // tbProducto
            // 
            this.tbProducto.Location = new System.Drawing.Point(98, 111);
            this.tbProducto.Name = "tbProducto";
            this.tbProducto.Size = new System.Drawing.Size(121, 20);
            this.tbProducto.TabIndex = 5;
            // 
            // btGenerarReceta
            // 
            this.btGenerarReceta.Location = new System.Drawing.Point(144, 225);
            this.btGenerarReceta.Name = "btGenerarReceta";
            this.btGenerarReceta.Size = new System.Drawing.Size(75, 23);
            this.btGenerarReceta.TabIndex = 6;
            this.btGenerarReceta.Text = "Generar";
            this.btGenerarReceta.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbProducto);
            this.panel1.Controls.Add(this.btGenerarReceta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbOrdenarReceta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbConceptoReceta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 291);
            this.panel1.TabIndex = 7;
            // 
            // SideBarReporteReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SideBarReporteReceta";
            this.Size = new System.Drawing.Size(244, 291);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbConceptoReceta;
        private System.Windows.Forms.ComboBox cbOrdenarReceta;
        private System.Windows.Forms.TextBox tbProducto;
        private System.Windows.Forms.Button btGenerarReceta;
        private System.Windows.Forms.Panel panel1;
    }
}
