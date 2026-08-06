namespace Presentacion.TablasMaestras
{
    partial class Abonos
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
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.LblNroFactura = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.dgvAbonos = new System.Windows.Forms.DataGridView();
            this.TxtValorAbono = new System.Windows.Forms.TextBox();
            this.LblValorAbono = new System.Windows.Forms.Label();
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonos)).BeginInit();
            this.groupBoxFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(255, 41);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(545, 20);
            this.txtBusqueda.TabIndex = 1;
            // 
            // LblNroFactura
            // 
            this.LblNroFactura.AutoSize = true;
            this.LblNroFactura.Location = new System.Drawing.Point(40, 44);
            this.LblNroFactura.Name = "LblNroFactura";
            this.LblNroFactura.Size = new System.Drawing.Size(211, 13);
            this.LblNroFactura.TabIndex = 2;
            this.LblNroFactura.Text = "Ingresar palabra como criterio de búsqueda";
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(400, 48);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(222, 20);
            this.LblTitulo.TabIndex = 4;
            this.LblTitulo.Text = "Registrar Abono a Factura";
            // 
            // dgvAbonos
            // 
            this.dgvAbonos.AllowUserToAddRows = false;
            this.dgvAbonos.AllowUserToDeleteRows = false;
            this.dgvAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbonos.Location = new System.Drawing.Point(40, 216);
            this.dgvAbonos.Name = "dgvAbonos";
            this.dgvAbonos.ReadOnly = true;
            this.dgvAbonos.Size = new System.Drawing.Size(946, 150);
            this.dgvAbonos.TabIndex = 5;
            // 
            // TxtValorAbono
            // 
            this.TxtValorAbono.Enabled = false;
            this.TxtValorAbono.Location = new System.Drawing.Point(773, 385);
            this.TxtValorAbono.Name = "TxtValorAbono";
            this.TxtValorAbono.Size = new System.Drawing.Size(212, 20);
            this.TxtValorAbono.TabIndex = 7;
            // 
            // LblValorAbono
            // 
            this.LblValorAbono.AutoSize = true;
            this.LblValorAbono.Location = new System.Drawing.Point(646, 388);
            this.LblValorAbono.Name = "LblValorAbono";
            this.LblValorAbono.Size = new System.Drawing.Size(121, 13);
            this.LblValorAbono.TabIndex = 6;
            this.LblValorAbono.Text = "Ingresar valor del abono";
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.btnConsultar);
            this.groupBoxFiltro.Controls.Add(this.txtBusqueda);
            this.groupBoxFiltro.Controls.Add(this.LblNroFactura);
            this.groupBoxFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFiltro.Location = new System.Drawing.Point(40, 100);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(946, 100);
            this.groupBoxFiltro.TabIndex = 8;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(808, 39);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(122, 23);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar compra";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(311, 452);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 9;
            // 
            // Abonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 512);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.groupBoxFiltro);
            this.Controls.Add(this.TxtValorAbono);
            this.Controls.Add(this.LblValorAbono);
            this.Controls.Add(this.dgvAbonos);
            this.Controls.Add(this.LblTitulo);
            this.Name = "Abonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonos";
            this.Load += new System.EventHandler(this.Abonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonos)).EndInit();
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label LblNroFactura;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridView dgvAbonos;
        private System.Windows.Forms.TextBox TxtValorAbono;
        private System.Windows.Forms.Label LblValorAbono;
        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.Button btnConsultar;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
    }
}