namespace Presentacion.TablasMaestras
{
    partial class Talla
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
            this.LblTalla = new System.Windows.Forms.Label();
            this.TxtTalla = new System.Windows.Forms.TextBox();
            this.DgvTalla = new System.Windows.Forms.DataGridView();
            this.IdTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTalla)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTalla
            // 
            this.LblTalla.AutoSize = true;
            this.LblTalla.Location = new System.Drawing.Point(107, 33);
            this.LblTalla.Name = "LblTalla";
            this.LblTalla.Size = new System.Drawing.Size(0, 13);
            this.LblTalla.TabIndex = 1;
            // 
            // TxtTalla
            // 
            this.TxtTalla.Enabled = false;
            this.TxtTalla.Location = new System.Drawing.Point(157, 30);
            this.TxtTalla.Name = "TxtTalla";
            this.TxtTalla.Size = new System.Drawing.Size(185, 20);
            this.TxtTalla.TabIndex = 2;
            this.TxtTalla.TextChanged += new System.EventHandler(this.TxtTalla_TextChanged);
            // 
            // DgvTalla
            // 
            this.DgvTalla.AllowUserToAddRows = false;
            this.DgvTalla.AllowUserToDeleteRows = false;
            this.DgvTalla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTalla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTalla,
            this.Nombre});
            this.DgvTalla.Location = new System.Drawing.Point(110, 66);
            this.DgvTalla.Name = "DgvTalla";
            this.DgvTalla.ReadOnly = true;
            this.DgvTalla.RowHeadersVisible = false;
            this.DgvTalla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTalla.Size = new System.Drawing.Size(232, 146);
            this.DgvTalla.TabIndex = 3;
            this.DgvTalla.SelectionChanged += new System.EventHandler(this.DgvTalla_SelectionChanged);
            // 
            // IdTalla
            // 
            this.IdTalla.DataPropertyName = "IdTalla";
            this.IdTalla.Name = "IdTalla";
            this.IdTalla.ReadOnly = true;
            this.IdTalla.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(25, 235);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 4;
            // 
            // Talla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 287);
            this.Controls.Add(this.DgvTalla);
            this.Controls.Add(this.TxtTalla);
            this.Controls.Add(this.LblTalla);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Name = "Talla";
            this.Load += new System.EventHandler(this.Talla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTalla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.Label LblTalla;
        private System.Windows.Forms.TextBox TxtTalla;
        private System.Windows.Forms.DataGridView DgvTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}