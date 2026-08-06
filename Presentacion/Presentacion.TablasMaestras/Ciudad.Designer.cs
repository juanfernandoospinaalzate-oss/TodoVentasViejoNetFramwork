namespace Presentacion.TablasMaestras
{
    partial class Ciudad
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
            this.LblCiudad = new System.Windows.Forms.Label();
            this.TxtCiudad = new System.Windows.Forms.TextBox();
            this.CmbDepartamento = new System.Windows.Forms.ComboBox();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.DgvCiudad = new System.Windows.Forms.DataGridView();
            this.IdCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            this.CmbPais = new System.Windows.Forms.ComboBox();
            this.LblPais = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCiudad)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCiudad
            // 
            this.LblCiudad.AutoSize = true;
            this.LblCiudad.Location = new System.Drawing.Point(100, 26);
            this.LblCiudad.Name = "LblCiudad";
            this.LblCiudad.Size = new System.Drawing.Size(0, 13);
            this.LblCiudad.TabIndex = 0;
            // 
            // TxtCiudad
            // 
            this.TxtCiudad.Location = new System.Drawing.Point(180, 23);
            this.TxtCiudad.Name = "TxtCiudad";
            this.TxtCiudad.Size = new System.Drawing.Size(157, 20);
            this.TxtCiudad.TabIndex = 1;
            // 
            // CmbDepartamento
            // 
            this.CmbDepartamento.FormattingEnabled = true;
            this.CmbDepartamento.Location = new System.Drawing.Point(180, 79);
            this.CmbDepartamento.Name = "CmbDepartamento";
            this.CmbDepartamento.Size = new System.Drawing.Size(157, 21);
            this.CmbDepartamento.TabIndex = 2;
            this.CmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.CmbDepartamento_SelectedIndexChanged);
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Location = new System.Drawing.Point(100, 81);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(0, 13);
            this.LblDepartamento.TabIndex = 3;
            // 
            // DgvCiudad
            // 
            this.DgvCiudad.AllowUserToAddRows = false;
            this.DgvCiudad.AllowUserToDeleteRows = false;
            this.DgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCiudad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCiudad,
            this.Nombre});
            this.DgvCiudad.Location = new System.Drawing.Point(26, 129);
            this.DgvCiudad.Name = "DgvCiudad";
            this.DgvCiudad.ReadOnly = true;
            this.DgvCiudad.RowHeadersVisible = false;
            this.DgvCiudad.Size = new System.Drawing.Size(400, 86);
            this.DgvCiudad.TabIndex = 4;
            // 
            // IdCiudad
            // 
            this.IdCiudad.DataPropertyName = "IdCiudad";
            this.IdCiudad.Name = "IdCiudad";
            this.IdCiudad.ReadOnly = true;
            this.IdCiudad.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(26, 246);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 5;
            // 
            // CmbPais
            // 
            this.CmbPais.Location = new System.Drawing.Point(180, 52);
            this.CmbPais.Name = "CmbPais";
            this.CmbPais.Size = new System.Drawing.Size(157, 21);
            this.CmbPais.TabIndex = 0;
            // 
            // LblPais
            // 
            this.LblPais.AutoSize = true;
            this.LblPais.Location = new System.Drawing.Point(100, 55);
            this.LblPais.Name = "LblPais";
            this.LblPais.Size = new System.Drawing.Size(27, 13);
            this.LblPais.TabIndex = 6;
            this.LblPais.Text = "Pais";
            // 
            // Ciudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 315);
            this.Controls.Add(this.LblPais);
            this.Controls.Add(this.CmbPais);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.DgvCiudad);
            this.Controls.Add(this.LblDepartamento);
            this.Controls.Add(this.CmbDepartamento);
            this.Controls.Add(this.TxtCiudad);
            this.Controls.Add(this.LblCiudad);
            this.Name = "Ciudad";
            this.Load += new System.EventHandler(this.Ciudad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCiudad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCiudad;
        private System.Windows.Forms.TextBox TxtCiudad;
        private System.Windows.Forms.ComboBox CmbDepartamento;
        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.DataGridView DgvCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.ComboBox CmbPais;
        private System.Windows.Forms.Label LblPais;
    }
}