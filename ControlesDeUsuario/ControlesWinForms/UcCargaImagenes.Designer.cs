namespace Controles.WinForms
{
    partial class UcCargaImagenes
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblUrlimagen1 = new System.Windows.Forms.Label();
            this.BtnExaminar = new System.Windows.Forms.Button();
            this.pictureBoxImg1 = new System.Windows.Forms.PictureBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.ControlToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUrlimagen1
            // 
            this.LblUrlimagen1.BackColor = System.Drawing.SystemColors.Info;
            this.LblUrlimagen1.Location = new System.Drawing.Point(1, 2);
            this.LblUrlimagen1.Name = "LblUrlimagen1";
            this.LblUrlimagen1.Size = new System.Drawing.Size(188, 23);
            this.LblUrlimagen1.TabIndex = 122;
            this.LblUrlimagen1.MouseHover += new System.EventHandler(this.UcCargaImagenes_MouseHover);
            // 
            // BtnExaminar
            // 
            this.BtnExaminar.Location = new System.Drawing.Point(197, 2);
            this.BtnExaminar.Name = "BtnExaminar";
            this.BtnExaminar.Size = new System.Drawing.Size(83, 23);
            this.BtnExaminar.TabIndex = 121;
            this.BtnExaminar.Text = "Examinar...";
            this.BtnExaminar.UseVisualStyleBackColor = true;
            this.BtnExaminar.Click += new System.EventHandler(this.BtnExaminar_Click);
            this.BtnExaminar.MouseHover += new System.EventHandler(this.UcCargaImagenes_MouseHover);
            // 
            // pictureBoxImg1
            // 
            this.pictureBoxImg1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxImg1.Location = new System.Drawing.Point(287, 2);
            this.pictureBoxImg1.Name = "pictureBoxImg1";
            this.pictureBoxImg1.Size = new System.Drawing.Size(31, 22);
            this.pictureBoxImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImg1.TabIndex = 124;
            this.pictureBoxImg1.TabStop = false;
            this.pictureBoxImg1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UcCargaImagenes_MouseHover);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(324, 2);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(22, 23);
            this.BtnLimpiar.TabIndex = 125;
            this.BtnLimpiar.Text = "X";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            this.BtnLimpiar.MouseHover += new System.EventHandler(this.UcCargaImagenes_MouseHover);
            // 
            // UcCargaImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.pictureBoxImg1);
            this.Controls.Add(this.LblUrlimagen1);
            this.Controls.Add(this.BtnExaminar);
            this.MinimumSize = new System.Drawing.Size(350, 28);
            this.Name = "UcCargaImagenes";
            this.Size = new System.Drawing.Size(353, 28);
            this.MouseHover += new System.EventHandler(this.UcCargaImagenes_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblUrlimagen1;
        private System.Windows.Forms.Button BtnExaminar;
        private System.Windows.Forms.PictureBox pictureBoxImg1;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.ToolTip ControlToolTip;
    }
}
