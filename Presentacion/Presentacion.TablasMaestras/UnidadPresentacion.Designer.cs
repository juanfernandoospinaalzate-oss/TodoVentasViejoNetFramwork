namespace Presentacion.TablasMaestras
{
    partial class UnidadPresentacion
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvUnidadPresentacion = new System.Windows.Forms.DataGridView();
            this.IdUnidadPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(113, 49);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(120, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Unidad de presentación";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(240, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(237, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // dgvUnidadPresentacion
            // 
            this.dgvUnidadPresentacion.AllowUserToAddRows = false;
            this.dgvUnidadPresentacion.AllowUserToDeleteRows = false;
            this.dgvUnidadPresentacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadPresentacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUnidadPresentacion,
            this.Nombre});
            this.dgvUnidadPresentacion.Location = new System.Drawing.Point(116, 85);
            this.dgvUnidadPresentacion.Name = "dgvUnidadPresentacion";
            this.dgvUnidadPresentacion.ReadOnly = true;
            this.dgvUnidadPresentacion.Size = new System.Drawing.Size(361, 150);
            this.dgvUnidadPresentacion.TabIndex = 2;
            // 
            // IdUnidadPresentacion
            // 
            this.IdUnidadPresentacion.DataPropertyName = "IdUnidadPresentacion";
            this.IdUnidadPresentacion.HeaderText = "UnidadPresentacion";
            this.IdUnidadPresentacion.Name = "IdUnidadPresentacion";
            this.IdUnidadPresentacion.ReadOnly = true;
            this.IdUnidadPresentacion.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(94, 257);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 3;
            // 
            // UnidadPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 322);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.dgvUnidadPresentacion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "UnidadPresentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnidadPresentacion";
            this.Load += new System.EventHandler(this.UnidadPresentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadPresentacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvUnidadPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidadPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
    }
}