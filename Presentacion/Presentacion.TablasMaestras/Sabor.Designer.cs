namespace Presentacion.TablasMaestras
{
    partial class Sabor
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
            this.LblSabor = new System.Windows.Forms.Label();
            this.TxtSabores = new System.Windows.Forms.TextBox();
            this.DgvSabores = new System.Windows.Forms.DataGridView();
            this.IdSabor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSabores)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSabor
            // 
            this.LblSabor.AutoSize = true;
            this.LblSabor.Location = new System.Drawing.Point(100, 28);
            this.LblSabor.Name = "LblSabor";
            this.LblSabor.Size = new System.Drawing.Size(35, 13);
            this.LblSabor.TabIndex = 0;
            // 
            // TxtSabores
            // 
            this.TxtSabores.Location = new System.Drawing.Point(141, 25);
            this.TxtSabores.Name = "TxtSabores";
            this.TxtSabores.Size = new System.Drawing.Size(192, 20);
            this.TxtSabores.TabIndex = 1;
            // 
            // DgvSabores
            // 
            this.DgvSabores.AllowUserToAddRows = false;
            this.DgvSabores.AllowUserToDeleteRows = false;
            this.DgvSabores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSabores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSabor,
            this.Nombre});
            this.DgvSabores.Location = new System.Drawing.Point(93, 56);
            this.DgvSabores.Name = "DgvSabores";
            this.DgvSabores.ReadOnly = true;
            this.DgvSabores.RowHeadersVisible = false;
            this.DgvSabores.Size = new System.Drawing.Size(240, 150);
            this.DgvSabores.TabIndex = 2;
            // 
            // IdSabor
            // 
            this.IdSabor.DataPropertyName = "IdSabor";
            this.IdSabor.Name = "IdSabor";
            this.IdSabor.ReadOnly = true;
            this.IdSabor.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(21, 229);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 3;
            // 
            // Sabores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 277);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.DgvSabores);
            this.Controls.Add(this.TxtSabores);
            this.Controls.Add(this.LblSabor);
            this.Name = "Sabores";
            this.Load += new System.EventHandler(this.Sabores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSabores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSabor;
        private System.Windows.Forms.TextBox TxtSabores;
        private System.Windows.Forms.DataGridView DgvSabores;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSabor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
    }
}