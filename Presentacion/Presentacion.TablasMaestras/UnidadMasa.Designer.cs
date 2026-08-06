namespace Presentacion.TablasMaestras
{
    partial class UnidadMasa
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
            this.LblUnidadDeMasa = new System.Windows.Forms.Label();
            this.DgvUnidadDeMasa = new System.Windows.Forms.DataGridView();
            this.TxtUnidadMasa = new System.Windows.Forms.TextBox();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            this.IdUnidadMasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUnidadDeMasa)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUnidadDeMasa
            // 
            this.LblUnidadDeMasa.AutoSize = true;
            this.LblUnidadDeMasa.Location = new System.Drawing.Point(100, 33);
            this.LblUnidadDeMasa.Name = "LblUnidadDeMasa";
            this.LblUnidadDeMasa.Size = new System.Drawing.Size(83, 13);
            this.LblUnidadDeMasa.TabIndex = 1;
            // 
            // DgvUnidadDeMasa
            // 
            this.DgvUnidadDeMasa.AllowUserToAddRows = false;
            this.DgvUnidadDeMasa.AllowUserToDeleteRows = false;
            this.DgvUnidadDeMasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUnidadDeMasa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUnidadMasa,
            this.Nombre});
            this.DgvUnidadDeMasa.Location = new System.Drawing.Point(103, 65);
            this.DgvUnidadDeMasa.Name = "DgvUnidadDeMasa";
            this.DgvUnidadDeMasa.ReadOnly = true;
            this.DgvUnidadDeMasa.RowHeadersVisible = false;
            this.DgvUnidadDeMasa.Size = new System.Drawing.Size(257, 116);
            this.DgvUnidadDeMasa.TabIndex = 5;
            // 
            // TxtUnidadMasa
            // 
            this.TxtUnidadMasa.Location = new System.Drawing.Point(189, 30);
            this.TxtUnidadMasa.Name = "TxtUnidadMasa";
            this.TxtUnidadMasa.Size = new System.Drawing.Size(171, 20);
            this.TxtUnidadMasa.TabIndex = 6;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(34, 200);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 4;
            // 
            // IdUnidadMasa
            // 
            this.IdUnidadMasa.DataPropertyName = "IdUnidadMasa";
            this.IdUnidadMasa.Name = "IdUnidadMasa";
            this.IdUnidadMasa.ReadOnly = true;
            this.IdUnidadMasa.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // UnidadMasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 251);
            this.Controls.Add(this.TxtUnidadMasa);
            this.Controls.Add(this.DgvUnidadDeMasa);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.LblUnidadDeMasa);
            this.Name = "UnidadMasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UnidadesDeMasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUnidadDeMasa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUnidadDeMasa;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.DataGridView DgvUnidadDeMasa;
        private System.Windows.Forms.TextBox TxtUnidadMasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidadMasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}