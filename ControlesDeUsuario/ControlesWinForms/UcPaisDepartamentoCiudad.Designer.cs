namespace Controles.WinForms
{
    partial class UcPaisDepartamentoCiudad
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CbCiudad = new System.Windows.Forms.ComboBox();
            this.CbDepartamento = new System.Windows.Forms.ComboBox();
            this.CbPais = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CbCiudad
            // 
            this.CbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCiudad.FormattingEnabled = true;
            this.CbCiudad.Location = new System.Drawing.Point(3, 60);
            this.CbCiudad.Name = "CbCiudad";
            this.CbCiudad.Size = new System.Drawing.Size(169, 21);
            this.CbCiudad.TabIndex = 20;
            // 
            // CbDepartamento
            // 
            this.CbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDepartamento.FormattingEnabled = true;
            this.CbDepartamento.Location = new System.Drawing.Point(3, 30);
            this.CbDepartamento.Name = "CbDepartamento";
            this.CbDepartamento.Size = new System.Drawing.Size(169, 21);
            this.CbDepartamento.TabIndex = 19;
            this.CbDepartamento.SelectedIndexChanged += new System.EventHandler(this.CbDepartamento_SelectedIndexChanged);
            // 
            // CbPais
            // 
            this.CbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPais.FormattingEnabled = true;
            this.CbPais.Location = new System.Drawing.Point(3, 3);
            this.CbPais.Name = "CbPais";
            this.CbPais.Size = new System.Drawing.Size(169, 21);
            this.CbPais.TabIndex = 18;
            this.CbPais.SelectedIndexChanged += new System.EventHandler(this.CbPais_SelectedIndexChanged);
            // 
            // UcPaisDepartamentoCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbCiudad);
            this.Controls.Add(this.CbDepartamento);
            this.Controls.Add(this.CbPais);
            this.Name = "UcPaisDepartamentoCiudad";
            this.Size = new System.Drawing.Size(175, 84);
            this.Load += new System.EventHandler(this.UcPaisDepartamentoCiudad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbCiudad;
        private System.Windows.Forms.ComboBox CbDepartamento;
        private System.Windows.Forms.ComboBox CbPais;
    }
}
