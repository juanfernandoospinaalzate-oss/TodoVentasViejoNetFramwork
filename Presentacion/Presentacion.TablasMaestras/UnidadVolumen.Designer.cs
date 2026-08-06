namespace Presentacion.TablasMaestras
{
    partial class UnidadVolumen
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
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblUnidadVolumen = new System.Windows.Forms.Label();
            this.DgvUndVolumen = new System.Windows.Forms.DataGridView();
            this.IdUnidadVolumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUndVolumen)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(187, 32);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(146, 20);
            this.TxtNombre.TabIndex = 0;
            // 
            // LblUnidadVolumen
            // 
            this.LblUnidadVolumen.AutoSize = true;
            this.LblUnidadVolumen.Location = new System.Drawing.Point(81, 35);
            this.LblUnidadVolumen.Name = "LblUnidadVolumen";
            this.LblUnidadVolumen.Size = new System.Drawing.Size(0, 13);
            this.LblUnidadVolumen.TabIndex = 1;
            // 
            // DgvUndVolumen
            // 
            this.DgvUndVolumen.AllowUserToAddRows = false;
            this.DgvUndVolumen.AllowUserToDeleteRows = false;
            this.DgvUndVolumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUndVolumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUnidadVolumen,
            this.Nombre});
            this.DgvUndVolumen.Location = new System.Drawing.Point(84, 77);
            this.DgvUndVolumen.Name = "DgvUndVolumen";
            this.DgvUndVolumen.ReadOnly = true;
            this.DgvUndVolumen.RowHeadersVisible = false;
            this.DgvUndVolumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUndVolumen.Size = new System.Drawing.Size(249, 150);
            this.DgvUndVolumen.TabIndex = 2;
            this.DgvUndVolumen.SelectionChanged += new System.EventHandler(this.DgvUndVolumen_SelectionChanged);
            // 
            // IdUnidadVolumen
            // 
            this.IdUnidadVolumen.DataPropertyName = "IdUnidadVolumen";
            this.IdUnidadVolumen.Name = "IdUnidadVolumen";
            this.IdUnidadVolumen.ReadOnly = true;
            this.IdUnidadVolumen.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(16, 267);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 3;
            // 
            // UnidadVolumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 325);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.DgvUndVolumen);
            this.Controls.Add(this.LblUnidadVolumen);
            this.Controls.Add(this.TxtNombre);
            this.Name = "UnidadVolumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UnidadVolumen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUndVolumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblUnidadVolumen;
        private System.Windows.Forms.DataGridView DgvUndVolumen;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidadVolumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}