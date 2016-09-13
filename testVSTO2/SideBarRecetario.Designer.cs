namespace testVSTO2
{
    partial class SideBarRecetario
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbRecetas = new System.Windows.Forms.ListBox();
            this.btSeleccion = new System.Windows.Forms.Button();
            this.btBorrarLista = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btBuscarReceta = new System.Windows.Forms.Button();
            this.tbBuscarReceta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAyuda = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(258, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbRecetas);
            this.tabPage1.Controls.Add(this.btSeleccion);
            this.tabPage1.Controls.Add(this.btBorrarLista);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btBuscar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(250, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Menú del día";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbRecetas
            // 
            this.lbRecetas.FormattingEnabled = true;
            this.lbRecetas.Location = new System.Drawing.Point(7, 69);
            this.lbRecetas.Name = "lbRecetas";
            this.lbRecetas.Size = new System.Drawing.Size(190, 264);
            this.lbRecetas.TabIndex = 7;
            // 
            // btSeleccion
            // 
            this.btSeleccion.Location = new System.Drawing.Point(10, 355);
            this.btSeleccion.Name = "btSeleccion";
            this.btSeleccion.Size = new System.Drawing.Size(109, 23);
            this.btSeleccion.TabIndex = 6;
            this.btSeleccion.Text = "Borrar selección";
            this.btSeleccion.UseVisualStyleBackColor = true;
            // 
            // btBorrarLista
            // 
            this.btBorrarLista.Location = new System.Drawing.Point(125, 355);
            this.btBorrarLista.Name = "btBorrarLista";
            this.btBorrarLista.Size = new System.Drawing.Size(72, 23);
            this.btBorrarLista.TabIndex = 5;
            this.btBorrarLista.Text = "Borrar lista";
            this.btBorrarLista.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de recetas :";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(7, 24);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(62, 20);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "Buscar...";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btBuscarReceta);
            this.tabPage2.Controls.Add(this.tbBuscarReceta);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(250, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buscar y Editar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btBuscarReceta
            // 
            this.btBuscarReceta.Location = new System.Drawing.Point(138, 24);
            this.btBuscarReceta.Name = "btBuscarReceta";
            this.btBuscarReceta.Size = new System.Drawing.Size(62, 20);
            this.btBuscarReceta.TabIndex = 6;
            this.btBuscarReceta.Text = "Buscar...";
            this.btBuscarReceta.UseVisualStyleBackColor = true;
            this.btBuscarReceta.Click += new System.EventHandler(this.btBuscarReceta_Click);
            // 
            // tbBuscarReceta
            // 
            this.tbBuscarReceta.Location = new System.Drawing.Point(7, 24);
            this.tbBuscarReceta.Name = "tbBuscarReceta";
            this.tbBuscarReceta.Size = new System.Drawing.Size(124, 20);
            this.tbBuscarReceta.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAyuda);
            this.panel1.Controls.Add(this.btGuardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 48);
            this.panel1.TabIndex = 1;
            // 
            // btAyuda
            // 
            this.btAyuda.Location = new System.Drawing.Point(126, 6);
            this.btAyuda.Name = "btAyuda";
            this.btAyuda.Size = new System.Drawing.Size(75, 23);
            this.btAyuda.TabIndex = 8;
            this.btAyuda.Text = "Ayuda";
            this.btAyuda.UseVisualStyleBackColor = true;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(11, 6);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(109, 23);
            this.btGuardar.TabIndex = 7;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            // 
            // SideBarRecetario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SideBarRecetario";
            this.Size = new System.Drawing.Size(258, 485);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btSeleccion;
        private System.Windows.Forms.Button btBorrarLista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btBuscarReceta;
        private System.Windows.Forms.TextBox tbBuscarReceta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAyuda;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.ListBox lbRecetas;
    }
}
