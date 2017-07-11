namespace ExcelAddIn1
{
    partial class Acceso
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
            this.btacceso = new System.Windows.Forms.Button();
            this.lbusuario = new System.Windows.Forms.Label();
            this.lbcontraseña = new System.Windows.Forms.Label();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btacceso
            // 
            this.btacceso.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btacceso.Location = new System.Drawing.Point(128, 261);
            this.btacceso.Name = "btacceso";
            this.btacceso.Size = new System.Drawing.Size(95, 35);
            this.btacceso.TabIndex = 0;
            this.btacceso.Text = "Acceso";
            this.btacceso.UseVisualStyleBackColor = true;
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusuario.Location = new System.Drawing.Point(52, 166);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(67, 18);
            this.lbusuario.TabIndex = 1;
            this.lbusuario.Text = "Usuario :";
            // 
            // lbcontraseña
            // 
            this.lbcontraseña.AutoSize = true;
            this.lbcontraseña.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcontraseña.Location = new System.Drawing.Point(31, 212);
            this.lbcontraseña.Name = "lbcontraseña";
            this.lbcontraseña.Size = new System.Drawing.Size(88, 18);
            this.lbcontraseña.TabIndex = 2;
            this.lbcontraseña.Text = "Contraseña :";
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Location = new System.Drawing.Point(125, 210);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(145, 20);
            this.txtcontraseña.TabIndex = 3;
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(128, 164);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(145, 20);
            this.txtusuario.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExcelAddIn1.Properties.Resources.FINAL_;
            this.pictureBox1.Location = new System.Drawing.Point(38, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 308);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.txtcontraseña);
            this.Controls.Add(this.lbcontraseña);
            this.Controls.Add(this.lbusuario);
            this.Controls.Add(this.btacceso);
            this.Name = "Acceso";
            this.Text = "Acceso";
            this.Load += new System.EventHandler(this.Acceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btacceso;
        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.Label lbcontraseña;
        private System.Windows.Forms.TextBox txtcontraseña;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}