namespace Presentacion.TablasMaestras
{
    partial class Favicon
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
            this.ucCargaImagenes1 = new Controles.WinForms.UcCargaImagenes();
            this.BtnCargarIcono = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucCargaImagenes1
            // 
            this.ucCargaImagenes1.Location = new System.Drawing.Point(12, 138);
            this.ucCargaImagenes1.MinimumSize = new System.Drawing.Size(350, 28);
            this.ucCargaImagenes1.Name = "ucCargaImagenes1";
            this.ucCargaImagenes1.Size = new System.Drawing.Size(350, 28);
            this.ucCargaImagenes1.TabIndex = 0;
            this.ucCargaImagenes1.ToolTipText = "";
            // 
            // BtnCargarIcono
            // 
            this.BtnCargarIcono.Location = new System.Drawing.Point(31, 168);
            this.BtnCargarIcono.Name = "BtnCargarIcono";
            this.BtnCargarIcono.Size = new System.Drawing.Size(75, 23);
            this.BtnCargarIcono.TabIndex = 1;
            this.BtnCargarIcono.Text = "Cargar";
            this.BtnCargarIcono.UseVisualStyleBackColor = true;
            this.BtnCargarIcono.Click += new System.EventHandler(this.BtnCargarIcono_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(112, 168);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(97, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(193, 168);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "La imágen debe ser icono .ico y resolución de 32px por 32px";
            // 
            // Favicon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 203);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnCargarIcono);
            this.Controls.Add(this.ucCargaImagenes1);
            this.Name = "Favicon";
            this.Text = "Favicon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.WinForms.UcCargaImagenes ucCargaImagenes1;
        private System.Windows.Forms.Button BtnCargarIcono;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label label1;
    }
}