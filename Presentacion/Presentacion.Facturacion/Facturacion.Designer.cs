namespace Presentacion.Facturacion
{
    partial class Facturacion
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
            this.BtnGuardarImprimir = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtIdentificacion = new System.Windows.Forms.TextBox();
            this.LblIdentificacion = new System.Windows.Forms.Label();
            this.PbImgPresentacionArticulo = new System.Windows.Forms.PictureBox();
            this.TxtCodigoEAN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvFacturacion = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AgregarCantidad = new System.Windows.Forms.Button();
            this.QuitarCantidad = new System.Windows.Forms.Button();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PbImgCodigoBarras = new System.Windows.Forms.PictureBox();
            this.cmbMediosDePago = new System.Windows.Forms.ComboBox();
            this.cmbEstadoDeLaVenta = new System.Windows.Forms.ComboBox();
            this.btnConsultarOrdenesCompra = new System.Windows.Forms.Button();
            this.ChkImprimirDirecto = new System.Windows.Forms.CheckBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.LblTotalFactura = new System.Windows.Forms.Label();
            this.TxtCantidadArticulos = new System.Windows.Forms.TextBox();
            this.LblTotalArticulos = new System.Windows.Forms.Label();
            this.LblNumeroDeFactura = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgPresentacionArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgCodigoBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGuardarImprimir
            // 
            this.BtnGuardarImprimir.Location = new System.Drawing.Point(302, 383);
            this.BtnGuardarImprimir.Name = "BtnGuardarImprimir";
            this.BtnGuardarImprimir.Size = new System.Drawing.Size(114, 23);
            this.BtnGuardarImprimir.TabIndex = 27;
            this.BtnGuardarImprimir.Text = "Guardar e Imprimir";
            this.BtnGuardarImprimir.UseVisualStyleBackColor = true;
            this.BtnGuardarImprimir.Click += new System.EventHandler(this.BtnGuardarImprimir_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(162, 383);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(134, 23);
            this.BtnEliminar.TabIndex = 23;
            this.BtnEliminar.Text = "Eliminar elemento";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Location = new System.Drawing.Point(287, 59);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(246, 20);
            this.TxtTelefono.TabIndex = 22;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(360, 33);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(385, 20);
            this.TxtDireccion.TabIndex = 21;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(33, 59);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(248, 20);
            this.TxtNombre.TabIndex = 20;
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.Location = new System.Drawing.Point(127, 33);
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(227, 20);
            this.TxtIdentificacion.TabIndex = 19;
            this.TxtIdentificacion.Text = "71312752";
            this.TxtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIdentificacion_KeyDown);
            // 
            // LblIdentificacion
            // 
            this.LblIdentificacion.AutoSize = true;
            this.LblIdentificacion.Location = new System.Drawing.Point(30, 36);
            this.LblIdentificacion.Name = "LblIdentificacion";
            this.LblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.LblIdentificacion.TabIndex = 18;
            this.LblIdentificacion.Text = "Identificación";
            // 
            // PbImgPresentacionArticulo
            // 
            this.PbImgPresentacionArticulo.Location = new System.Drawing.Point(746, 158);
            this.PbImgPresentacionArticulo.Name = "PbImgPresentacionArticulo";
            this.PbImgPresentacionArticulo.Size = new System.Drawing.Size(164, 164);
            this.PbImgPresentacionArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbImgPresentacionArticulo.TabIndex = 17;
            this.PbImgPresentacionArticulo.TabStop = false;
            // 
            // TxtCodigoEAN
            // 
            this.TxtCodigoEAN.Location = new System.Drawing.Point(127, 90);
            this.TxtCodigoEAN.Name = "TxtCodigoEAN";
            this.TxtCodigoEAN.Size = new System.Drawing.Size(227, 20);
            this.TxtCodigoEAN.TabIndex = 16;
            this.TxtCodigoEAN.Text = "096619926626";
            this.TxtCodigoEAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoEAN_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Código de Barras";
            // 
            // DgvFacturacion
            // 
            this.DgvFacturacion.AllowUserToAddRows = false;
            this.DgvFacturacion.AllowUserToDeleteRows = false;
            this.DgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFacturacion.Location = new System.Drawing.Point(12, 120);
            this.DgvFacturacion.MultiSelect = false;
            this.DgvFacturacion.Name = "DgvFacturacion";
            this.DgvFacturacion.ReadOnly = true;
            this.DgvFacturacion.RowHeadersVisible = false;
            this.DgvFacturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFacturacion.Size = new System.Drawing.Size(728, 211);
            this.DgvFacturacion.TabIndex = 14;
            this.DgvFacturacion.SelectionChanged += new System.EventHandler(this.DgvFacturacion_SelectionChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 413);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(440, 301);
            this.reportViewer1.TabIndex = 28;
            // 
            // AgregarCantidad
            // 
            this.AgregarCantidad.AutoSize = true;
            this.AgregarCantidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarCantidad.Location = new System.Drawing.Point(93, 380);
            this.AgregarCantidad.Name = "AgregarCantidad";
            this.AgregarCantidad.Size = new System.Drawing.Size(30, 28);
            this.AgregarCantidad.TabIndex = 29;
            this.AgregarCantidad.Text = "+";
            this.AgregarCantidad.UseVisualStyleBackColor = true;
            this.AgregarCantidad.Click += new System.EventHandler(this.AgregarCantidad_Click);
            // 
            // QuitarCantidad
            // 
            this.QuitarCantidad.AutoSize = true;
            this.QuitarCantidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitarCantidad.Location = new System.Drawing.Point(124, 380);
            this.QuitarCantidad.Name = "QuitarCantidad";
            this.QuitarCantidad.Size = new System.Drawing.Size(29, 28);
            this.QuitarCantidad.TabIndex = 30;
            this.QuitarCantidad.Text = "-";
            this.QuitarCantidad.UseVisualStyleBackColor = true;
            this.QuitarCantidad.Click += new System.EventHandler(this.QuitarCantidad_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(539, 59);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(206, 20);
            this.TxtEmail.TabIndex = 32;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Location = new System.Drawing.Point(470, 413);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(440, 301);
            this.reportViewer2.TabIndex = 33;
            this.reportViewer2.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.ReportViewer2_RenderingComplete);
            // 
            // PbImgCodigoBarras
            // 
            this.PbImgCodigoBarras.Location = new System.Drawing.Point(746, 13);
            this.PbImgCodigoBarras.Name = "PbImgCodigoBarras";
            this.PbImgCodigoBarras.Size = new System.Drawing.Size(164, 97);
            this.PbImgCodigoBarras.TabIndex = 34;
            this.PbImgCodigoBarras.TabStop = false;
            // 
            // cmbMediosDePago
            // 
            this.cmbMediosDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMediosDePago.FormattingEnabled = true;
            this.cmbMediosDePago.Location = new System.Drawing.Point(361, 88);
            this.cmbMediosDePago.Name = "cmbMediosDePago";
            this.cmbMediosDePago.Size = new System.Drawing.Size(172, 21);
            this.cmbMediosDePago.TabIndex = 35;
            // 
            // cmbEstadoDeLaVenta
            // 
            this.cmbEstadoDeLaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoDeLaVenta.FormattingEnabled = true;
            this.cmbEstadoDeLaVenta.Location = new System.Drawing.Point(540, 88);
            this.cmbEstadoDeLaVenta.Name = "cmbEstadoDeLaVenta";
            this.cmbEstadoDeLaVenta.Size = new System.Drawing.Size(200, 21);
            this.cmbEstadoDeLaVenta.TabIndex = 36;
            // 
            // btnConsultarOrdenesCompra
            // 
            this.btnConsultarOrdenesCompra.Location = new System.Drawing.Point(422, 383);
            this.btnConsultarOrdenesCompra.Name = "btnConsultarOrdenesCompra";
            this.btnConsultarOrdenesCompra.Size = new System.Drawing.Size(169, 23);
            this.btnConsultarOrdenesCompra.TabIndex = 37;
            this.btnConsultarOrdenesCompra.Text = "Consultar órdenes de compra";
            this.btnConsultarOrdenesCompra.UseVisualStyleBackColor = true;
            this.btnConsultarOrdenesCompra.Click += new System.EventHandler(this.BtnConsultarOrdenesCompra_Click);
            // 
            // ChkImprimirDirecto
            // 
            this.ChkImprimirDirecto.AutoSize = true;
            this.ChkImprimirDirecto.Location = new System.Drawing.Point(597, 388);
            this.ChkImprimirDirecto.Name = "ChkImprimirDirecto";
            this.ChkImprimirDirecto.Size = new System.Drawing.Size(127, 17);
            this.ChkImprimirDirecto.TabIndex = 38;
            this.ChkImprimirDirecto.Text = "Imprimir Directamente";
            this.ChkImprimirDirecto.UseVisualStyleBackColor = true;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(12, 384);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 39;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Enabled = false;
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalFactura.Location = new System.Drawing.Point(578, 344);
            this.TxtTotalFactura.Multiline = true;
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(160, 33);
            this.TxtTotalFactura.TabIndex = 40;
            // 
            // LblTotalFactura
            // 
            this.LblTotalFactura.AutoSize = true;
            this.LblTotalFactura.Location = new System.Drawing.Point(477, 362);
            this.LblTotalFactura.Name = "LblTotalFactura";
            this.LblTotalFactura.Size = new System.Drawing.Size(70, 13);
            this.LblTotalFactura.TabIndex = 41;
            this.LblTotalFactura.Text = "Total Factura";
            // 
            // TxtCantidadArticulos
            // 
            this.TxtCantidadArticulos.Enabled = false;
            this.TxtCantidadArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadArticulos.Location = new System.Drawing.Point(431, 342);
            this.TxtCantidadArticulos.Multiline = true;
            this.TxtCantidadArticulos.Name = "TxtCantidadArticulos";
            this.TxtCantidadArticulos.Size = new System.Drawing.Size(40, 33);
            this.TxtCantidadArticulos.TabIndex = 42;
            // 
            // LblTotalArticulos
            // 
            this.LblTotalArticulos.AutoSize = true;
            this.LblTotalArticulos.Location = new System.Drawing.Point(316, 360);
            this.LblTotalArticulos.Name = "LblTotalArticulos";
            this.LblTotalArticulos.Size = new System.Drawing.Size(109, 13);
            this.LblTotalArticulos.TabIndex = 43;
            this.LblTotalArticulos.Text = "Cantidad de Artículos";
            // 
            // LblNumeroDeFactura
            // 
            this.LblNumeroDeFactura.AutoSize = true;
            this.LblNumeroDeFactura.Location = new System.Drawing.Point(789, 120);
            this.LblNumeroDeFactura.Name = "LblNumeroDeFactura";
            this.LblNumeroDeFactura.Size = new System.Drawing.Size(98, 13);
            this.LblNumeroDeFactura.TabIndex = 44;
            this.LblNumeroDeFactura.Text = "Número de Factura";
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 726);
            this.Controls.Add(this.LblNumeroDeFactura);
            this.Controls.Add(this.LblTotalArticulos);
            this.Controls.Add(this.TxtCantidadArticulos);
            this.Controls.Add(this.LblTotalFactura);
            this.Controls.Add(this.TxtTotalFactura);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.ChkImprimirDirecto);
            this.Controls.Add(this.btnConsultarOrdenesCompra);
            this.Controls.Add(this.cmbEstadoDeLaVenta);
            this.Controls.Add(this.cmbMediosDePago);
            this.Controls.Add(this.PbImgCodigoBarras);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.QuitarCantidad);
            this.Controls.Add(this.AgregarCantidad);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BtnGuardarImprimir);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtIdentificacion);
            this.Controls.Add(this.LblIdentificacion);
            this.Controls.Add(this.PbImgPresentacionArticulo);
            this.Controls.Add(this.TxtCodigoEAN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvFacturacion);
            this.KeyPreview = true;
            this.Name = "Facturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Facturacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Facturacion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PbImgPresentacionArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgCodigoBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardarImprimir;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.Label LblIdentificacion;
        private System.Windows.Forms.PictureBox PbImgPresentacionArticulo;
        private System.Windows.Forms.TextBox TxtCodigoEAN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvFacturacion;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button AgregarCantidad;
        private System.Windows.Forms.Button QuitarCantidad;
        private System.Windows.Forms.TextBox TxtEmail;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.PictureBox PbImgCodigoBarras;
        private System.Windows.Forms.ComboBox cmbMediosDePago;
        private System.Windows.Forms.ComboBox cmbEstadoDeLaVenta;
        public System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Button btnConsultarOrdenesCompra;
        private System.Windows.Forms.CheckBox ChkImprimirDirecto;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.TextBox TxtTotalFactura;
        private System.Windows.Forms.Label LblTotalFactura;
        private System.Windows.Forms.TextBox TxtCantidadArticulos;
        private System.Windows.Forms.Label LblTotalArticulos;
        private System.Windows.Forms.Label LblNumeroDeFactura;
    }
}