namespace Presentacion.TablasMaestras
{
    partial class UnidadLongitud
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
            this.LblUnidadLongitud = new System.Windows.Forms.Label();
            this.DgvUndLongitud = new System.Windows.Forms.DataGridView();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            this.IdUnidadLongitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUndLongitud)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(202, 30);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(160, 20);
            this.TxtNombre.TabIndex = 0;
            // 
            // LblUnidadLongitud
            // 
            this.LblUnidadLongitud.AutoSize = true;
            this.LblUnidadLongitud.Location = new System.Drawing.Point(96, 33);
            this.LblUnidadLongitud.Name = "LblUnidadLongitud";
            this.LblUnidadLongitud.Size = new System.Drawing.Size(100, 13);
            this.LblUnidadLongitud.TabIndex = 1;
            // 
            // DgvUndLongitud
            // 
            this.DgvUndLongitud.AllowUserToAddRows = false;
            this.DgvUndLongitud.AllowUserToDeleteRows = false;
            this.DgvUndLongitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUndLongitud.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUnidadLongitud,
            this.Nombre});
            this.DgvUndLongitud.Location = new System.Drawing.Point(21, 66);
            this.DgvUndLongitud.Name = "DgvUndLongitud";
            this.DgvUndLongitud.ReadOnly = true;
            this.DgvUndLongitud.RowHeadersVisible = false;
            this.DgvUndLongitud.Size = new System.Drawing.Size(406, 150);
            this.DgvUndLongitud.TabIndex = 2;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(21, 243);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(406, 33);
            this.barraBotonesCRUD1.TabIndex = 3;
            // 
            // IdUnidadLongitud
            // 
            this.IdUnidadLongitud.DataPropertyName = "IdUnidadLongitud";
            this.IdUnidadLongitud.Name = "IdUnidadLongitud";
            this.IdUnidadLongitud.ReadOnly = true;
            this.IdUnidadLongitud.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // UnidadLongitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 294);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.DgvUndLongitud);
            this.Controls.Add(this.LblUnidadLongitud);
            this.Controls.Add(this.TxtNombre);
            this.Name = "UnidadLongitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UnidadLongitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUndLongitud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblUnidadLongitud;
        private System.Windows.Forms.DataGridView DgvUndLongitud;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidadLongitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}