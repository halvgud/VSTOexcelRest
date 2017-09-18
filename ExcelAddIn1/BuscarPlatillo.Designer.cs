namespace ExcelAddIn1
{
    partial class BuscarPlatillo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Martes = new System.Windows.Forms.RadioButton();
            this.Viernes = new System.Windows.Forms.RadioButton();
            this.Jueves = new System.Windows.Forms.RadioButton();
            this.Domingo = new System.Windows.Forms.RadioButton();
            this.Sabado = new System.Windows.Forms.RadioButton();
            this.Miercoles = new System.Windows.Forms.RadioButton();
            this.Lunes = new System.Windows.Forms.RadioButton();
            this.btAgregarSemana = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(531, 552);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Martes);
            this.groupBox1.Controls.Add(this.Viernes);
            this.groupBox1.Controls.Add(this.Jueves);
            this.groupBox1.Controls.Add(this.Domingo);
            this.groupBox1.Controls.Add(this.Sabado);
            this.groupBox1.Controls.Add(this.Miercoles);
            this.groupBox1.Controls.Add(this.Lunes);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(541, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 284);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dia a Agregar:";
            // 
            // Martes
            // 
            this.Martes.AutoSize = true;
            this.Martes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Martes.Location = new System.Drawing.Point(6, 63);
            this.Martes.Name = "Martes";
            this.Martes.Size = new System.Drawing.Size(92, 26);
            this.Martes.TabIndex = 6;
            this.Martes.TabStop = true;
            this.Martes.Text = "Martes";
            this.Martes.UseVisualStyleBackColor = true;
            // 
            // Viernes
            // 
            this.Viernes.AutoSize = true;
            this.Viernes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Viernes.Location = new System.Drawing.Point(6, 151);
            this.Viernes.Name = "Viernes";
            this.Viernes.Size = new System.Drawing.Size(99, 26);
            this.Viernes.TabIndex = 5;
            this.Viernes.TabStop = true;
            this.Viernes.Text = "Viernes";
            this.Viernes.UseVisualStyleBackColor = true;
            // 
            // Jueves
            // 
            this.Jueves.AutoSize = true;
            this.Jueves.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jueves.Location = new System.Drawing.Point(6, 122);
            this.Jueves.Name = "Jueves";
            this.Jueves.Size = new System.Drawing.Size(95, 26);
            this.Jueves.TabIndex = 4;
            this.Jueves.TabStop = true;
            this.Jueves.Text = "Jueves";
            this.Jueves.UseVisualStyleBackColor = true;
            // 
            // Domingo
            // 
            this.Domingo.AutoSize = true;
            this.Domingo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Domingo.Location = new System.Drawing.Point(6, 209);
            this.Domingo.Name = "Domingo";
            this.Domingo.Size = new System.Drawing.Size(112, 26);
            this.Domingo.TabIndex = 3;
            this.Domingo.TabStop = true;
            this.Domingo.Text = "Domingo";
            this.Domingo.UseVisualStyleBackColor = true;
            // 
            // Sabado
            // 
            this.Sabado.AutoSize = true;
            this.Sabado.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sabado.Location = new System.Drawing.Point(6, 180);
            this.Sabado.Name = "Sabado";
            this.Sabado.Size = new System.Drawing.Size(99, 26);
            this.Sabado.TabIndex = 2;
            this.Sabado.TabStop = true;
            this.Sabado.Text = "Sabado";
            this.Sabado.UseVisualStyleBackColor = true;
            // 
            // Miercoles
            // 
            this.Miercoles.AutoSize = true;
            this.Miercoles.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Miercoles.Location = new System.Drawing.Point(6, 92);
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.Size = new System.Drawing.Size(119, 26);
            this.Miercoles.TabIndex = 1;
            this.Miercoles.TabStop = true;
            this.Miercoles.Text = "Miercoles";
            this.Miercoles.UseVisualStyleBackColor = true;
            // 
            // Lunes
            // 
            this.Lunes.AutoSize = true;
            this.Lunes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lunes.Location = new System.Drawing.Point(6, 34);
            this.Lunes.Name = "Lunes";
            this.Lunes.Size = new System.Drawing.Size(86, 26);
            this.Lunes.TabIndex = 0;
            this.Lunes.TabStop = true;
            this.Lunes.Text = "Lunes";
            this.Lunes.UseVisualStyleBackColor = true;
            // 
            // btAgregarSemana
            // 
            this.btAgregarSemana.BackColor = System.Drawing.Color.Black;
            this.btAgregarSemana.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregarSemana.ForeColor = System.Drawing.Color.White;
            this.btAgregarSemana.Location = new System.Drawing.Point(708, 270);
            this.btAgregarSemana.Name = "btAgregarSemana";
            this.btAgregarSemana.Size = new System.Drawing.Size(95, 35);
            this.btAgregarSemana.TabIndex = 8;
            this.btAgregarSemana.Text = "Agregar";
            this.btAgregarSemana.UseVisualStyleBackColor = false;
            this.btAgregarSemana.Click += new System.EventHandler(this.btAgregarSemana_Click);
            // 
            // BuscarPlatillo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(805, 557);
            this.Controls.Add(this.btAgregarSemana);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BuscarPlatillo";
            this.Text = "BuscarPlatillo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Martes;
        private System.Windows.Forms.RadioButton Viernes;
        private System.Windows.Forms.RadioButton Jueves;
        private System.Windows.Forms.RadioButton Domingo;
        private System.Windows.Forms.RadioButton Sabado;
        private System.Windows.Forms.RadioButton Miercoles;
        private System.Windows.Forms.RadioButton Lunes;
        private System.Windows.Forms.Button btAgregarSemana;
    }
}