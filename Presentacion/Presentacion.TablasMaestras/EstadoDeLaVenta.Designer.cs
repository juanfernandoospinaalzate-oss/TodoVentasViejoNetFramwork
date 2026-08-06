namespace Presentacion.TablasMaestras
{
    partial class EstadoDeLaVenta
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
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEstadoNuevo = new System.Windows.Forms.TextBox();
            this.DgvEstadoDeLaVenta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEstadoDeLaVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(12, 249);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado de la Venta";
            // 
            // TxtEstadoNuevo
            // 
            this.TxtEstadoNuevo.Location = new System.Drawing.Point(181, 39);
            this.TxtEstadoNuevo.Name = "TxtEstadoNuevo";
            this.TxtEstadoNuevo.Size = new System.Drawing.Size(177, 20);
            this.TxtEstadoNuevo.TabIndex = 2;
            // 
            // DgvEstadoDeLaVenta
            // 
            this.DgvEstadoDeLaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEstadoDeLaVenta.Location = new System.Drawing.Point(12, 79);
            this.DgvEstadoDeLaVenta.Name = "DgvEstadoDeLaVenta";
            this.DgvEstadoDeLaVenta.RowHeadersVisible = false;
            this.DgvEstadoDeLaVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEstadoDeLaVenta.Size = new System.Drawing.Size(400, 150);
            this.DgvEstadoDeLaVenta.TabIndex = 3;
            this.DgvEstadoDeLaVenta.SelectionChanged += new System.EventHandler(this.DgvEstadoDeLaVenta_SelectionChanged);
            // 
            // EstadoDeLaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 291);
            this.Controls.Add(this.DgvEstadoDeLaVenta);
            this.Controls.Add(this.TxtEstadoNuevo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Name = "EstadoDeLaVenta";
            this.Text = "EstadoDeLaVenta";
            this.Load += new System.EventHandler(this.EstadoDeLaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEstadoDeLaVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEstadoNuevo;
        private System.Windows.Forms.DataGridView DgvEstadoDeLaVenta;
    }
}