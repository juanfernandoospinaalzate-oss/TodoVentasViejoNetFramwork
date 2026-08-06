namespace Presentacion.TablasMaestras
{
    partial class Departamento
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
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.CbPais = new System.Windows.Forms.ComboBox();
            this.LblPais = new System.Windows.Forms.Label();
            this.TxtDepartamento = new System.Windows.Forms.TextBox();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            this.DgvDepartamento = new System.Windows.Forms.DataGridView();
            this.IdDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDepartamento)).BeginInit();
            this.SuspendLayout();
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Location = new System.Drawing.Point(87, 30);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(0, 13);
            this.LblDepartamento.TabIndex = 0;
            // 
            // CbPais
            // 
            this.CbPais.FormattingEnabled = true;
            this.CbPais.Location = new System.Drawing.Point(181, 49);
            this.CbPais.Name = "CbPais";
            this.CbPais.Size = new System.Drawing.Size(159, 21);
            this.CbPais.TabIndex = 1;
            this.CbPais.SelectedIndexChanged += new System.EventHandler(this.CbPais_SelectedIndexChanged);
            // 
            // LblPais
            // 
            this.LblPais.AutoSize = true;
            this.LblPais.Location = new System.Drawing.Point(93, 52);
            this.LblPais.Name = "LblPais";
            this.LblPais.Size = new System.Drawing.Size(0, 13);
            this.LblPais.TabIndex = 2;
            // 
            // TxtDepartamento
            // 
            this.TxtDepartamento.Location = new System.Drawing.Point(181, 22);
            this.TxtDepartamento.Name = "TxtDepartamento";
            this.TxtDepartamento.Size = new System.Drawing.Size(159, 20);
            this.TxtDepartamento.TabIndex = 3;
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(28, 183);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 4;
            // 
            // DgvDepartamento
            // 
            this.DgvDepartamento.AllowUserToAddRows = false;
            this.DgvDepartamento.AllowUserToDeleteRows = false;
            this.DgvDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDepartamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDepartamento,
            this.Nombre});
            this.DgvDepartamento.Location = new System.Drawing.Point(28, 85);
            this.DgvDepartamento.Name = "DgvDepartamento";
            this.DgvDepartamento.ReadOnly = true;
            this.DgvDepartamento.RowHeadersVisible = false;
            this.DgvDepartamento.Size = new System.Drawing.Size(400, 80);
            this.DgvDepartamento.TabIndex = 5;
            // 
            // IdDepartamento
            // 
            this.IdDepartamento.DataPropertyName = "IdDepartamento";
            this.IdDepartamento.Name = "IdDepartamento";
            this.IdDepartamento.ReadOnly = true;
            this.IdDepartamento.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Departamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 231);
            this.Controls.Add(this.DgvDepartamento);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.TxtDepartamento);
            this.Controls.Add(this.LblPais);
            this.Controls.Add(this.CbPais);
            this.Controls.Add(this.LblDepartamento);
            this.Name = "Departamento";
            this.Load += new System.EventHandler(this.Departamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDepartamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.ComboBox CbPais;
        private System.Windows.Forms.Label LblPais;
        private System.Windows.Forms.TextBox TxtDepartamento;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.DataGridView DgvDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}