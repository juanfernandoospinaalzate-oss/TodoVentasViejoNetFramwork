namespace Presentacion.Facturacion
{
    partial class OrdenesCompra
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblTotalArticulos = new System.Windows.Forms.Label();
            this.TxtCantidadArticulos = new System.Windows.Forms.TextBox();
            this.LblTotalFactura = new System.Windows.Forms.Label();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.TxtValorAbonado = new System.Windows.Forms.TextBox();
            this.ChkActivarValorAbonado = new System.Windows.Forms.CheckBox();
            this.btnOrdenCompra = new System.Windows.Forms.Button();
            this.cmbMediosDePago = new System.Windows.Forms.ComboBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.QuitarCantidad = new System.Windows.Forms.Button();
            this.AgregarCantidad = new System.Windows.Forms.Button();
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
            this.btnConsultarOrdenesCompra = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgPresentacionArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblTotalArticulos);
            this.groupBox2.Controls.Add(this.TxtCantidadArticulos);
            this.groupBox2.Controls.Add(this.LblTotalFactura);
            this.groupBox2.Controls.Add(this.TxtTotalFactura);
            this.groupBox2.Controls.Add(this.TxtValorAbonado);
            this.groupBox2.Controls.Add(this.ChkActivarValorAbonado);
            this.groupBox2.Controls.Add(this.btnOrdenCompra);
            this.groupBox2.Controls.Add(this.cmbMediosDePago);
            this.groupBox2.Controls.Add(this.TxtEmail);
            this.groupBox2.Controls.Add(this.QuitarCantidad);
            this.groupBox2.Controls.Add(this.AgregarCantidad);
            this.groupBox2.Controls.Add(this.BtnEliminar);
            this.groupBox2.Controls.Add(this.TxtTelefono);
            this.groupBox2.Controls.Add(this.TxtDireccion);
            this.groupBox2.Controls.Add(this.TxtNombre);
            this.groupBox2.Controls.Add(this.TxtIdentificacion);
            this.groupBox2.Controls.Add(this.LblIdentificacion);
            this.groupBox2.Controls.Add(this.PbImgPresentacionArticulo);
            this.groupBox2.Controls.Add(this.TxtCodigoEAN);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DgvFacturacion);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(965, 426);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nueva orden de compra";
            // 
            // LblTotalArticulos
            // 
            this.LblTotalArticulos.AutoSize = true;
            this.LblTotalArticulos.Location = new System.Drawing.Point(358, 340);
            this.LblTotalArticulos.Name = "LblTotalArticulos";
            this.LblTotalArticulos.Size = new System.Drawing.Size(109, 13);
            this.LblTotalArticulos.TabIndex = 94;
            this.LblTotalArticulos.Text = "Cantidad de Artículos";
            // 
            // TxtCantidadArticulos
            // 
            this.TxtCantidadArticulos.Enabled = false;
            this.TxtCantidadArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadArticulos.Location = new System.Drawing.Point(473, 324);
            this.TxtCantidadArticulos.Multiline = true;
            this.TxtCantidadArticulos.Name = "TxtCantidadArticulos";
            this.TxtCantidadArticulos.Size = new System.Drawing.Size(40, 33);
            this.TxtCantidadArticulos.TabIndex = 93;
            this.TxtCantidadArticulos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblTotalFactura
            // 
            this.LblTotalFactura.AutoSize = true;
            this.LblTotalFactura.Location = new System.Drawing.Point(535, 340);
            this.LblTotalFactura.Name = "LblTotalFactura";
            this.LblTotalFactura.Size = new System.Drawing.Size(70, 13);
            this.LblTotalFactura.TabIndex = 92;
            this.LblTotalFactura.Text = "Total Factura";
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Enabled = false;
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalFactura.Location = new System.Drawing.Point(611, 324);
            this.TxtTotalFactura.Multiline = true;
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(160, 33);
            this.TxtTotalFactura.TabIndex = 91;
            this.TxtTotalFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtValorAbonado
            // 
            this.TxtValorAbonado.Location = new System.Drawing.Point(473, 116);
            this.TxtValorAbonado.Name = "TxtValorAbonado";
            this.TxtValorAbonado.Size = new System.Drawing.Size(233, 20);
            this.TxtValorAbonado.TabIndex = 90;
            this.TxtValorAbonado.Leave += new System.EventHandler(this.TxtValorAbonado_Leave);
            // 
            // ChkActivarValorAbonado
            // 
            this.ChkActivarValorAbonado.AutoSize = true;
            this.ChkActivarValorAbonado.Location = new System.Drawing.Point(370, 118);
            this.ChkActivarValorAbonado.Name = "ChkActivarValorAbonado";
            this.ChkActivarValorAbonado.Size = new System.Drawing.Size(97, 17);
            this.ChkActivarValorAbonado.TabIndex = 89;
            this.ChkActivarValorAbonado.Text = "Realizar abono";
            this.ChkActivarValorAbonado.UseVisualStyleBackColor = true;
            this.ChkActivarValorAbonado.CheckedChanged += new System.EventHandler(this.ChkActivarValorAbonado_CheckedChanged);
            // 
            // btnOrdenCompra
            // 
            this.btnOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenCompra.Location = new System.Drawing.Point(611, 375);
            this.btnOrdenCompra.Name = "btnOrdenCompra";
            this.btnOrdenCompra.Size = new System.Drawing.Size(160, 23);
            this.btnOrdenCompra.TabIndex = 88;
            this.btnOrdenCompra.Text = "Generar Ordenar de Compra";
            this.btnOrdenCompra.UseVisualStyleBackColor = true;
            this.btnOrdenCompra.Click += new System.EventHandler(this.BtnOrdenCompra_Click);
            // 
            // cmbMediosDePago
            // 
            this.cmbMediosDePago.FormattingEnabled = true;
            this.cmbMediosDePago.Location = new System.Drawing.Point(712, 116);
            this.cmbMediosDePago.Name = "cmbMediosDePago";
            this.cmbMediosDePago.Size = new System.Drawing.Size(229, 21);
            this.cmbMediosDePago.TabIndex = 86;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(712, 86);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(229, 20);
            this.TxtEmail.TabIndex = 85;
            // 
            // QuitarCantidad
            // 
            this.QuitarCantidad.AutoSize = true;
            this.QuitarCantidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitarCantidad.Location = new System.Drawing.Point(74, 370);
            this.QuitarCantidad.Name = "QuitarCantidad";
            this.QuitarCantidad.Size = new System.Drawing.Size(29, 28);
            this.QuitarCantidad.TabIndex = 84;
            this.QuitarCantidad.Text = "-";
            this.QuitarCantidad.UseVisualStyleBackColor = true;
            this.QuitarCantidad.Click += new System.EventHandler(this.QuitarCantidad_Click);
            // 
            // AgregarCantidad
            // 
            this.AgregarCantidad.AutoSize = true;
            this.AgregarCantidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarCantidad.Location = new System.Drawing.Point(43, 370);
            this.AgregarCantidad.Name = "AgregarCantidad";
            this.AgregarCantidad.Size = new System.Drawing.Size(30, 28);
            this.AgregarCantidad.TabIndex = 83;
            this.AgregarCantidad.Text = "+";
            this.AgregarCantidad.UseVisualStyleBackColor = true;
            this.AgregarCantidad.Click += new System.EventHandler(this.AgregarCantidad_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(114, 373);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(134, 23);
            this.BtnEliminar.TabIndex = 81;
            this.BtnEliminar.Text = "Eliminar elemento";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Location = new System.Drawing.Point(370, 86);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(336, 20);
            this.TxtTelefono.TabIndex = 80;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(370, 60);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(571, 20);
            this.TxtDireccion.TabIndex = 79;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(137, 86);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(227, 20);
            this.TxtNombre.TabIndex = 78;
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.Location = new System.Drawing.Point(137, 60);
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(227, 20);
            this.TxtIdentificacion.TabIndex = 77;
            this.TxtIdentificacion.Text = "71312752";
            this.TxtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIdentificacion_KeyDown);
            // 
            // LblIdentificacion
            // 
            this.LblIdentificacion.AutoSize = true;
            this.LblIdentificacion.Location = new System.Drawing.Point(40, 63);
            this.LblIdentificacion.Name = "LblIdentificacion";
            this.LblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.LblIdentificacion.TabIndex = 76;
            this.LblIdentificacion.Text = "Identificación";
            // 
            // PbImgPresentacionArticulo
            // 
            this.PbImgPresentacionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbImgPresentacionArticulo.Location = new System.Drawing.Point(777, 154);
            this.PbImgPresentacionArticulo.Name = "PbImgPresentacionArticulo";
            this.PbImgPresentacionArticulo.Size = new System.Drawing.Size(164, 164);
            this.PbImgPresentacionArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbImgPresentacionArticulo.TabIndex = 75;
            this.PbImgPresentacionArticulo.TabStop = false;
            // 
            // TxtCodigoEAN
            // 
            this.TxtCodigoEAN.Location = new System.Drawing.Point(137, 117);
            this.TxtCodigoEAN.Name = "TxtCodigoEAN";
            this.TxtCodigoEAN.Size = new System.Drawing.Size(227, 20);
            this.TxtCodigoEAN.TabIndex = 74;
            this.TxtCodigoEAN.Text = "bbws003";
            this.TxtCodigoEAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoEAN_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Código de Barras";
            // 
            // DgvFacturacion
            // 
            this.DgvFacturacion.AllowUserToAddRows = false;
            this.DgvFacturacion.AllowUserToDeleteRows = false;
            this.DgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFacturacion.Location = new System.Drawing.Point(43, 154);
            this.DgvFacturacion.MultiSelect = false;
            this.DgvFacturacion.Name = "DgvFacturacion";
            this.DgvFacturacion.ReadOnly = true;
            this.DgvFacturacion.RowHeadersVisible = false;
            this.DgvFacturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFacturacion.Size = new System.Drawing.Size(728, 164);
            this.DgvFacturacion.TabIndex = 72;
            this.DgvFacturacion.SelectionChanged += new System.EventHandler(this.DgvFacturacion_SelectionChanged);
            // 
            // btnConsultarOrdenesCompra
            // 
            this.btnConsultarOrdenesCompra.Location = new System.Drawing.Point(806, 35);
            this.btnConsultarOrdenesCompra.Name = "btnConsultarOrdenesCompra";
            this.btnConsultarOrdenesCompra.Size = new System.Drawing.Size(196, 22);
            this.btnConsultarOrdenesCompra.TabIndex = 92;
            this.btnConsultarOrdenesCompra.Text = "Consultar ordenes de compra";
            this.btnConsultarOrdenesCompra.UseVisualStyleBackColor = true;
            this.btnConsultarOrdenesCompra.Click += new System.EventHandler(this.BtnConsultarOrdenesCompra_Click);
            // 
            // OrdenesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 518);
            this.Controls.Add(this.btnConsultarOrdenesCompra);
            this.Controls.Add(this.groupBox2);
            this.Name = "OrdenesCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de compra";
            this.Load += new System.EventHandler(this.OrdenesCompra_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbImgPresentacionArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMediosDePago;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Button QuitarCantidad;
        private System.Windows.Forms.Button AgregarCantidad;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.TextBox TxtTelefono;
        public System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.Label LblIdentificacion;
        private System.Windows.Forms.PictureBox PbImgPresentacionArticulo;
        private System.Windows.Forms.TextBox TxtCodigoEAN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvFacturacion;
        private System.Windows.Forms.Button btnOrdenCompra;
        private System.Windows.Forms.TextBox TxtValorAbonado;
        private System.Windows.Forms.CheckBox ChkActivarValorAbonado;
        private System.Windows.Forms.Button btnConsultarOrdenesCompra;
        private System.Windows.Forms.Label LblTotalArticulos;
        private System.Windows.Forms.TextBox TxtCantidadArticulos;
        private System.Windows.Forms.Label LblTotalFactura;
        private System.Windows.Forms.TextBox TxtTotalFactura;
    }
}