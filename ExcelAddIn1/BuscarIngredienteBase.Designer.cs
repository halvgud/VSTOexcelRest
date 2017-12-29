namespace ExcelAddIn1
{
    partial class BuscarIngredienteBase
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
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtIngrediente = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dgvIngredientesBase = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxUnidad = new System.Windows.Forms.ComboBox();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.txtCantidadReceta = new System.Windows.Forms.TextBox();
            this.btAgregaraReceta = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btAceptarReceta = new System.Windows.Forms.Button();
            this.txtUnidadReceta = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIngredienteReceta = new System.Windows.Forms.TextBox();
            this.btGuardarUnidad = new System.Windows.Forms.Button();
            this.chAgregarUnidad = new System.Windows.Forms.CheckBox();
            this.txtUnidadAgregar = new System.Windows.Forms.TextBox();
            this.chModificarUnidad = new System.Windows.Forms.CheckBox();
            this.cbUnidadModificar = new System.Windows.Forms.ComboBox();
            this.lbUnidad = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientesBase)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrediente";
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.Silver;
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(116, 160);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(164, 24);
            this.txtCosto.TabIndex = 1;
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged);
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.BackColor = System.Drawing.Color.Silver;
            this.txtIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngrediente.Location = new System.Drawing.Point(116, 55);
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.Size = new System.Drawing.Size(164, 24);
            this.txtIngrediente.TabIndex = 2;
            this.txtIngrediente.TextChanged += new System.EventHandler(this.txtIngrediente_TextChanged);
            this.txtIngrediente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngrediente_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.Silver;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(116, 89);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(164, 24);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // dgvIngredientesBase
            // 
            this.dgvIngredientesBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientesBase.Location = new System.Drawing.Point(409, 4);
            this.dgvIngredientesBase.Name = "dgvIngredientesBase";
            this.dgvIngredientesBase.Size = new System.Drawing.Size(438, 334);
            this.dgvIngredientesBase.TabIndex = 4;
            this.dgvIngredientesBase.SelectionChanged += new System.EventHandler(this.dgvIngredientesBase_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Unidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Costo";
            // 
            // cbxUnidad
            // 
            this.cbxUnidad.BackColor = System.Drawing.Color.Silver;
            this.cbxUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUnidad.FormattingEnabled = true;
            this.cbxUnidad.Location = new System.Drawing.Point(116, 123);
            this.cbxUnidad.Name = "cbxUnidad";
            this.cbxUnidad.Size = new System.Drawing.Size(164, 26);
            this.cbxUnidad.TabIndex = 13;
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.Black;
            this.btGuardar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.ForeColor = System.Drawing.Color.White;
            this.btGuardar.Location = new System.Drawing.Point(131, 190);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(98, 54);
            this.btGuardar.TabIndex = 14;
            this.btGuardar.Text = "Guardar Cambios";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.Black;
            this.btActualizar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.ForeColor = System.Drawing.Color.White;
            this.btActualizar.Location = new System.Drawing.Point(496, 342);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(123, 55);
            this.btActualizar.TabIndex = 16;
            this.btActualizar.Text = "Actualizar Ingrediente";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // txtCantidadReceta
            // 
            this.txtCantidadReceta.BackColor = System.Drawing.Color.Silver;
            this.txtCantidadReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadReceta.Location = new System.Drawing.Point(171, 366);
            this.txtCantidadReceta.Name = "txtCantidadReceta";
            this.txtCantidadReceta.Size = new System.Drawing.Size(89, 24);
            this.txtCantidadReceta.TabIndex = 17;
            this.txtCantidadReceta.TextChanged += new System.EventHandler(this.txtCantidadReceta_TextChanged);
            this.txtCantidadReceta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidadReceta_Validating);
            // 
            // btAgregaraReceta
            // 
            this.btAgregaraReceta.BackColor = System.Drawing.Color.Black;
            this.btAgregaraReceta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregaraReceta.ForeColor = System.Drawing.Color.White;
            this.btAgregaraReceta.Location = new System.Drawing.Point(681, 342);
            this.btAgregaraReceta.Name = "btAgregaraReceta";
            this.btAgregaraReceta.Size = new System.Drawing.Size(121, 55);
            this.btAgregaraReceta.TabIndex = 19;
            this.btAgregaraReceta.Text = "Agregar a Receta";
            this.btAgregaraReceta.UseVisualStyleBackColor = false;
            this.btAgregaraReceta.Click += new System.EventHandler(this.btAgregaraReceta_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.Black;
            this.btBuscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.ForeColor = System.Drawing.Color.White;
            this.btBuscar.Location = new System.Drawing.Point(290, 48);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(98, 38);
            this.btBuscar.TabIndex = 20;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 23;
            // 
            // btAceptarReceta
            // 
            this.btAceptarReceta.BackColor = System.Drawing.Color.Black;
            this.btAceptarReceta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptarReceta.ForeColor = System.Drawing.Color.White;
            this.btAceptarReceta.Location = new System.Drawing.Point(163, 400);
            this.btAceptarReceta.Name = "btAceptarReceta";
            this.btAceptarReceta.Size = new System.Drawing.Size(102, 36);
            this.btAceptarReceta.TabIndex = 24;
            this.btAceptarReceta.Text = "Aceptar";
            this.btAceptarReceta.UseVisualStyleBackColor = false;
            this.btAceptarReceta.Click += new System.EventHandler(this.btAceptarReceta_Click);
            // 
            // txtUnidadReceta
            // 
            this.txtUnidadReceta.BackColor = System.Drawing.Color.Silver;
            this.txtUnidadReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnidadReceta.Location = new System.Drawing.Point(266, 366);
            this.txtUnidadReceta.Name = "txtUnidadReceta";
            this.txtUnidadReceta.ReadOnly = true;
            this.txtUnidadReceta.Size = new System.Drawing.Size(122, 24);
            this.txtUnidadReceta.TabIndex = 25;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(332, 59);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(28, 20);
            this.txtId.TabIndex = 26;
            this.txtId.Visible = false;
            // 
            // txtIngredienteReceta
            // 
            this.txtIngredienteReceta.BackColor = System.Drawing.Color.Silver;
            this.txtIngredienteReceta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredienteReceta.Location = new System.Drawing.Point(16, 366);
            this.txtIngredienteReceta.Name = "txtIngredienteReceta";
            this.txtIngredienteReceta.ReadOnly = true;
            this.txtIngredienteReceta.Size = new System.Drawing.Size(149, 24);
            this.txtIngredienteReceta.TabIndex = 27;
            // 
            // btGuardarUnidad
            // 
            this.btGuardarUnidad.Location = new System.Drawing.Point(603, 50);
            this.btGuardarUnidad.Name = "btGuardarUnidad";
            this.btGuardarUnidad.Size = new System.Drawing.Size(104, 23);
            this.btGuardarUnidad.TabIndex = 28;
            this.btGuardarUnidad.Text = "Guardar Unidad";
            this.btGuardarUnidad.UseVisualStyleBackColor = true;
            // 
            // chAgregarUnidad
            // 
            this.chAgregarUnidad.AutoSize = true;
            this.chAgregarUnidad.Location = new System.Drawing.Point(609, 4);
            this.chAgregarUnidad.Name = "chAgregarUnidad";
            this.chAgregarUnidad.Size = new System.Drawing.Size(82, 17);
            this.chAgregarUnidad.TabIndex = 29;
            this.chAgregarUnidad.Text = "Add Unidad";
            this.chAgregarUnidad.UseVisualStyleBackColor = true;
            this.chAgregarUnidad.CheckedChanged += new System.EventHandler(this.cbxAgregarUnidad_CheckedChanged);
            // 
            // txtUnidadAgregar
            // 
            this.txtUnidadAgregar.Location = new System.Drawing.Point(600, 27);
            this.txtUnidadAgregar.Name = "txtUnidadAgregar";
            this.txtUnidadAgregar.Size = new System.Drawing.Size(112, 20);
            this.txtUnidadAgregar.TabIndex = 30;
            // 
            // chModificarUnidad
            // 
            this.chModificarUnidad.AutoSize = true;
            this.chModificarUnidad.Location = new System.Drawing.Point(496, 4);
            this.chModificarUnidad.Name = "chModificarUnidad";
            this.chModificarUnidad.Size = new System.Drawing.Size(109, 17);
            this.chModificarUnidad.TabIndex = 31;
            this.chModificarUnidad.Text = "Actualizar Unidad";
            this.chModificarUnidad.UseVisualStyleBackColor = true;
            this.chModificarUnidad.CheckedChanged += new System.EventHandler(this.chModificarUnidad_CheckedChanged);
            // 
            // cbUnidadModificar
            // 
            this.cbUnidadModificar.FormattingEnabled = true;
            this.cbUnidadModificar.Location = new System.Drawing.Point(496, 27);
            this.cbUnidadModificar.Name = "cbUnidadModificar";
            this.cbUnidadModificar.Size = new System.Drawing.Size(98, 21);
            this.cbUnidadModificar.TabIndex = 32;
            // 
            // lbUnidad
            // 
            this.lbUnidad.AutoSize = true;
            this.lbUnidad.Location = new System.Drawing.Point(426, 35);
            this.lbUnidad.Name = "lbUnidad";
            this.lbUnidad.Size = new System.Drawing.Size(151, 13);
            this.lbUnidad.TabIndex = 33;
            this.lbUnidad.Text = "Selecciona Unidad a modificar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(332, 27);
            this.label7.TabIndex = 34;
            this.label7.Text = "Agregar/Actualizar Ingrediente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(401, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "¿Que cantidad desea agregar a la receta?";
            // 
            // BuscarIngredienteBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 442);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIngredienteReceta);
            this.Controls.Add(this.txtUnidadReceta);
            this.Controls.Add(this.btAceptarReceta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btAgregaraReceta);
            this.Controls.Add(this.txtCantidadReceta);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.cbxUnidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvIngredientesBase);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtIngrediente);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUnidad);
            this.Controls.Add(this.cbUnidadModificar);
            this.Controls.Add(this.chModificarUnidad);
            this.Controls.Add(this.txtUnidadAgregar);
            this.Controls.Add(this.chAgregarUnidad);
            this.Controls.Add(this.btGuardarUnidad);
            this.Controls.Add(this.txtId);
            this.Name = "BuscarIngredienteBase";
            this.Text = "BuscarIngredienteBase";
            this.Load += new System.EventHandler(this.BuscarIngredienteBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientesBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtIngrediente;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridView dgvIngredientesBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxUnidad;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.TextBox txtCantidadReceta;
        private System.Windows.Forms.Button btAgregaraReceta;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAceptarReceta;
        private System.Windows.Forms.TextBox txtUnidadReceta;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtIngredienteReceta;
        private System.Windows.Forms.Button btGuardarUnidad;
        private System.Windows.Forms.CheckBox chAgregarUnidad;
        private System.Windows.Forms.TextBox txtUnidadAgregar;
        private System.Windows.Forms.CheckBox chModificarUnidad;
        private System.Windows.Forms.ComboBox cbUnidadModificar;
        private System.Windows.Forms.Label lbUnidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}