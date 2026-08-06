namespace Presentacion.TablasMaestras
{
    partial class MedioDePago
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
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvMetodoDePago = new System.Windows.Forms.DataGridView();
            this.IdMetodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodoDePago)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(37, 15);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(44, 13);
            this.LblNombre.TabIndex = 1;
            this.LblNombre.Text = "Nombre";
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(37, 48);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.LblDescripcion.TabIndex = 2;
            this.LblDescripcion.Text = "Descripción";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(122, 12);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(317, 20);
            this.TxtNombre.TabIndex = 4;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(122, 45);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(317, 37);
            this.TxtDescripcion.TabIndex = 5;
            // 
            // dgvMetodoDePago
            // 
            this.dgvMetodoDePago.AllowUserToAddRows = false;
            this.dgvMetodoDePago.AllowUserToDeleteRows = false;
            this.dgvMetodoDePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodoDePago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMetodoDePago,
            this.Nombre,
            this.Descripcion});
            this.dgvMetodoDePago.Location = new System.Drawing.Point(40, 88);
            this.dgvMetodoDePago.Name = "dgvMetodoDePago";
            this.dgvMetodoDePago.ReadOnly = true;
            this.dgvMetodoDePago.RowHeadersVisible = false;
            this.dgvMetodoDePago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetodoDePago.Size = new System.Drawing.Size(399, 209);
            this.dgvMetodoDePago.TabIndex = 6;
            this.dgvMetodoDePago.SelectionChanged += new System.EventHandler(this.DgvMetodoDePago_SelectionChanged);
            // 
            // IdMetodoDePago
            // 
            this.IdMetodoDePago.DataPropertyName = "IdMetodoDePago";
            this.IdMetodoDePago.HeaderText = "";
            this.IdMetodoDePago.Name = "IdMetodoDePago";
            this.IdMetodoDePago.ReadOnly = true;
            this.IdMetodoDePago.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(39, 303);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 3;
            // 
            // MedioDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 366);
            this.Controls.Add(this.dgvMetodoDePago);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MedioDePago";
            this.Text = "Medio de pago";
            this.Load += new System.EventHandler(this.MedioDePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodoDePago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Label LblDescripcion;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.DataGridView dgvMetodoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMetodoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
    }
}