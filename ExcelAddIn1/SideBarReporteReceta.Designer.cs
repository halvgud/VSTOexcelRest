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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOrdenarReceta = new System.Windows.Forms.ComboBox();
            this.btGenerarReceta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbproducto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ordenar por :";
            // 
            // cbOrdenarReceta
            // 
            this.cbOrdenarReceta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOrdenarReceta.FormattingEnabled = true;
            this.cbOrdenarReceta.Location = new System.Drawing.Point(117, 150);
            this.cbOrdenarReceta.Name = "cbOrdenarReceta";
            this.cbOrdenarReceta.Size = new System.Drawing.Size(121, 21);
            this.cbOrdenarReceta.TabIndex = 4;
            // 
            // btGenerarReceta
            // 
            this.btGenerarReceta.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerarReceta.Location = new System.Drawing.Point(94, 213);
            this.btGenerarReceta.Name = "btGenerarReceta";
            this.btGenerarReceta.Size = new System.Drawing.Size(80, 33);
            this.btGenerarReceta.TabIndex = 6;
            this.btGenerarReceta.Text = "Generar";
            this.btGenerarReceta.UseVisualStyleBackColor = true;
            this.btGenerarReceta.Click += new System.EventHandler(this.btGenerarReceta_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbproducto);
            this.panel1.Controls.Add(this.btGenerarReceta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbOrdenarReceta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 291);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbproducto
            // 
            this.cbproducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbproducto.FormattingEnabled = true;
            this.cbproducto.Location = new System.Drawing.Point(117, 71);
            this.cbproducto.Name = "cbproducto";
            this.cbproducto.Size = new System.Drawing.Size(121, 21);
            this.cbproducto.TabIndex = 7;
            // 
            // SideBarReporteReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SideBarReporteReceta";
            this.Size = new System.Drawing.Size(244, 291);
            this.Load += new System.EventHandler(this.SideBarReporteReceta_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SideBarReporteReceta_MouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOrdenarReceta;
        private System.Windows.Forms.Button btGenerarReceta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbproducto;
    }
}
