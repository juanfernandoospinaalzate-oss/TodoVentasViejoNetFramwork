namespace Presentacion.TablasMaestras
{
    partial class TarifasDomicilio
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
            this.LblTarifasDomicilio = new System.Windows.Forms.Label();
            this.LblValorTarifasDomicilio = new System.Windows.Forms.Label();
            this.TxtTarifaDomicilioNuevo = new System.Windows.Forms.TextBox();
            this.TxtValorTarifaDomicilio = new System.Windows.Forms.TextBox();
            this.dgvTarifasDomicilio = new System.Windows.Forms.DataGridView();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasDomicilio)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTarifasDomicilio
            // 
            this.LblTarifasDomicilio.AutoSize = true;
            this.LblTarifasDomicilio.Location = new System.Drawing.Point(67, 39);
            this.LblTarifasDomicilio.Name = "LblTarifasDomicilio";
            this.LblTarifasDomicilio.Size = new System.Drawing.Size(119, 13);
            this.LblTarifasDomicilio.TabIndex = 0;
            this.LblTarifasDomicilio.Text = "Destino domicilio nuevo";
            // 
            // LblValorTarifasDomicilio
            // 
            this.LblValorTarifasDomicilio.AutoSize = true;
            this.LblValorTarifasDomicilio.Location = new System.Drawing.Point(67, 72);
            this.LblValorTarifasDomicilio.Name = "LblValorTarifasDomicilio";
            this.LblValorTarifasDomicilio.Size = new System.Drawing.Size(100, 13);
            this.LblValorTarifasDomicilio.TabIndex = 1;
            this.LblValorTarifasDomicilio.Text = "Valor tarifa domicilio";
            // 
            // TxtTarifaDomicilioNuevo
            // 
            this.TxtTarifaDomicilioNuevo.Location = new System.Drawing.Point(202, 36);
            this.TxtTarifaDomicilioNuevo.Name = "TxtTarifaDomicilioNuevo";
            this.TxtTarifaDomicilioNuevo.Size = new System.Drawing.Size(192, 20);
            this.TxtTarifaDomicilioNuevo.TabIndex = 2;
            // 
            // TxtValorTarifaDomicilio
            // 
            this.TxtValorTarifaDomicilio.Location = new System.Drawing.Point(202, 69);
            this.TxtValorTarifaDomicilio.Name = "TxtValorTarifaDomicilio";
            this.TxtValorTarifaDomicilio.Size = new System.Drawing.Size(192, 20);
            this.TxtValorTarifaDomicilio.TabIndex = 3;
            // 
            // dgvTarifasDomicilio
            // 
            this.dgvTarifasDomicilio.AllowUserToAddRows = false;
            this.dgvTarifasDomicilio.AllowUserToDeleteRows = false;
            this.dgvTarifasDomicilio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasDomicilio.Location = new System.Drawing.Point(39, 107);
            this.dgvTarifasDomicilio.Name = "dgvTarifasDomicilio";
            this.dgvTarifasDomicilio.ReadOnly = true;
            this.dgvTarifasDomicilio.RowHeadersVisible = false;
            this.dgvTarifasDomicilio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarifasDomicilio.Size = new System.Drawing.Size(400, 150);
            this.dgvTarifasDomicilio.TabIndex = 5;
            this.dgvTarifasDomicilio.SelectionChanged += new System.EventHandler(this.DgvTarifasDomicilio_SelectionChanged);
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(39, 276);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 4;
            // 
            // TarifasDomicilio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 334);
            this.Controls.Add(this.dgvTarifasDomicilio);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.TxtValorTarifaDomicilio);
            this.Controls.Add(this.TxtTarifaDomicilioNuevo);
            this.Controls.Add(this.LblValorTarifasDomicilio);
            this.Controls.Add(this.LblTarifasDomicilio);
            this.Name = "TarifasDomicilio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TarifasDomicilio";
            this.Load += new System.EventHandler(this.TarifasDomicilio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasDomicilio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTarifasDomicilio;
        private System.Windows.Forms.Label LblValorTarifasDomicilio;
        private System.Windows.Forms.TextBox TxtTarifaDomicilioNuevo;
        private System.Windows.Forms.TextBox TxtValorTarifaDomicilio;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.DataGridView dgvTarifasDomicilio;
    }
}