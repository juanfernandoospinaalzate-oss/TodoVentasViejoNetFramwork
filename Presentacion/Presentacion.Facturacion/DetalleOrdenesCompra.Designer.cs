namespace Presentacion.Facturacion
{
    partial class DetalleOrdenesCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFacurarOrdenCompra = new System.Windows.Forms.Button();
            this.dgvOrdenesCompra = new System.Windows.Forms.DataGridView();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.rbNombreCliente = new System.Windows.Forms.RadioButton();
            this.rbNumeroIdentificacion = new System.Windows.Forms.RadioButton();
            this.rbNumeroOrden = new System.Windows.Forms.RadioButton();
            this.TxtOrdenCompra = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNumeroIdentificacion = new System.Windows.Forms.TextBox();
            this.dgvDetalleOrdenCompra = new System.Windows.Forms.DataGridView();
            this.btnCancelarOrdenCompra = new System.Windows.Forms.Button();
            this.lblDetalleOrdenCompra = new System.Windows.Forms.Label();
            this.lblEncabezadoOrdenCompra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).BeginInit();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFacurarOrdenCompra
            // 
            this.btnFacurarOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacurarOrdenCompra.Location = new System.Drawing.Point(997, 573);
            this.btnFacurarOrdenCompra.Name = "btnFacurarOrdenCompra";
            this.btnFacurarOrdenCompra.Size = new System.Drawing.Size(163, 23);
            this.btnFacurarOrdenCompra.TabIndex = 0;
            this.btnFacurarOrdenCompra.Text = "Facturar orden de compra";
            this.btnFacurarOrdenCompra.UseVisualStyleBackColor = true;
            this.btnFacurarOrdenCompra.Click += new System.EventHandler(this.BtnFacurarOrdenCompra_Click);
            // 
            // dgvOrdenesCompra
            // 
            this.dgvOrdenesCompra.AllowUserToAddRows = false;
            this.dgvOrdenesCompra.AllowUserToDeleteRows = false;
            this.dgvOrdenesCompra.AllowUserToResizeRows = false;
            this.dgvOrdenesCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrdenesCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenesCompra.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOrdenesCompra.Location = new System.Drawing.Point(34, 224);
            this.dgvOrdenesCompra.MultiSelect = false;
            this.dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            this.dgvOrdenesCompra.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvOrdenesCompra.RowHeadersVisible = false;
            this.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesCompra.Size = new System.Drawing.Size(1126, 138);
            this.dgvOrdenesCompra.TabIndex = 2;
            this.dgvOrdenesCompra.SelectionChanged += new System.EventHandler(this.DgvOrdenesCompra_SelectionChanged);
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.SystemColors.Control;
            this.gbFiltros.Controls.Add(this.rbNombreCliente);
            this.gbFiltros.Controls.Add(this.rbNumeroIdentificacion);
            this.gbFiltros.Controls.Add(this.rbNumeroOrden);
            this.gbFiltros.Controls.Add(this.TxtOrdenCompra);
            this.gbFiltros.Controls.Add(this.txtNombreCliente);
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.txtNumeroIdentificacion);
            this.gbFiltros.Location = new System.Drawing.Point(34, 25);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(1126, 154);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Seleccionar filtro de búsqueda";
            // 
            // rbNombreCliente
            // 
            this.rbNombreCliente.AutoSize = true;
            this.rbNombreCliente.Location = new System.Drawing.Point(22, 111);
            this.rbNombreCliente.Name = "rbNombreCliente";
            this.rbNombreCliente.Size = new System.Drawing.Size(152, 17);
            this.rbNombreCliente.TabIndex = 12;
            this.rbNombreCliente.TabStop = true;
            this.rbNombreCliente.Text = "Ingresar nombre del cliente";
            this.rbNombreCliente.UseVisualStyleBackColor = true;
            this.rbNombreCliente.Click += new System.EventHandler(this.RbNombreCliente_Click);
            // 
            // rbNumeroIdentificacion
            // 
            this.rbNumeroIdentificacion.AutoSize = true;
            this.rbNumeroIdentificacion.Location = new System.Drawing.Point(449, 60);
            this.rbNumeroIdentificacion.Name = "rbNumeroIdentificacion";
            this.rbNumeroIdentificacion.Size = new System.Drawing.Size(181, 17);
            this.rbNumeroIdentificacion.TabIndex = 11;
            this.rbNumeroIdentificacion.TabStop = true;
            this.rbNumeroIdentificacion.Text = "Ingresar número de identificación";
            this.rbNumeroIdentificacion.UseVisualStyleBackColor = true;
            this.rbNumeroIdentificacion.Click += new System.EventHandler(this.RbNumeroIdentidad_Click);
            // 
            // rbNumeroOrden
            // 
            this.rbNumeroOrden.AutoSize = true;
            this.rbNumeroOrden.Location = new System.Drawing.Point(22, 60);
            this.rbNumeroOrden.Name = "rbNumeroOrden";
            this.rbNumeroOrden.Size = new System.Drawing.Size(146, 17);
            this.rbNumeroOrden.TabIndex = 10;
            this.rbNumeroOrden.TabStop = true;
            this.rbNumeroOrden.Text = "Ingresar número de orden";
            this.rbNumeroOrden.UseVisualStyleBackColor = true;
            this.rbNumeroOrden.Click += new System.EventHandler(this.RbNumeroOrden_Click);
            // 
            // TxtOrdenCompra
            // 
            this.TxtOrdenCompra.Location = new System.Drawing.Point(184, 57);
            this.TxtOrdenCompra.Name = "TxtOrdenCompra";
            this.TxtOrdenCompra.Size = new System.Drawing.Size(230, 20);
            this.TxtOrdenCompra.TabIndex = 8;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(184, 110);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(682, 20);
            this.txtNombreCliente.TabIndex = 7;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(946, 108);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(161, 23);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // txtNumeroIdentificacion
            // 
            this.txtNumeroIdentificacion.Location = new System.Drawing.Point(636, 57);
            this.txtNumeroIdentificacion.Name = "txtNumeroIdentificacion";
            this.txtNumeroIdentificacion.Size = new System.Drawing.Size(230, 20);
            this.txtNumeroIdentificacion.TabIndex = 3;
            // 
            // dgvDetalleOrdenCompra
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleOrdenCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleOrdenCompra.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDetalleOrdenCompra.Location = new System.Drawing.Point(32, 399);
            this.dgvDetalleOrdenCompra.Name = "dgvDetalleOrdenCompra";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleOrdenCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetalleOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleOrdenCompra.Size = new System.Drawing.Size(1128, 158);
            this.dgvDetalleOrdenCompra.TabIndex = 4;
            // 
            // btnCancelarOrdenCompra
            // 
            this.btnCancelarOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarOrdenCompra.Location = new System.Drawing.Point(32, 573);
            this.btnCancelarOrdenCompra.Name = "btnCancelarOrdenCompra";
            this.btnCancelarOrdenCompra.Size = new System.Drawing.Size(150, 23);
            this.btnCancelarOrdenCompra.TabIndex = 5;
            this.btnCancelarOrdenCompra.Text = "Cancelar orden de compra";
            this.btnCancelarOrdenCompra.UseVisualStyleBackColor = true;
            this.btnCancelarOrdenCompra.Click += new System.EventHandler(this.BtnCancelarOrdenCompra_Click);
            // 
            // lblDetalleOrdenCompra
            // 
            this.lblDetalleOrdenCompra.AutoSize = true;
            this.lblDetalleOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleOrdenCompra.Location = new System.Drawing.Point(31, 379);
            this.lblDetalleOrdenCompra.Name = "lblDetalleOrdenCompra";
            this.lblDetalleOrdenCompra.Size = new System.Drawing.Size(149, 13);
            this.lblDetalleOrdenCompra.TabIndex = 6;
            this.lblDetalleOrdenCompra.Text = "Detalle de la orden de compra";
            // 
            // lblEncabezadoOrdenCompra
            // 
            this.lblEncabezadoOrdenCompra.AutoSize = true;
            this.lblEncabezadoOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoOrdenCompra.Location = new System.Drawing.Point(34, 205);
            this.lblEncabezadoOrdenCompra.Name = "lblEncabezadoOrdenCompra";
            this.lblEncabezadoOrdenCompra.Size = new System.Drawing.Size(176, 13);
            this.lblEncabezadoOrdenCompra.TabIndex = 7;
            this.lblEncabezadoOrdenCompra.Text = "Encabezado de la orden de compra";
            // 
            // DetalleOrdenesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 628);
            this.Controls.Add(this.lblEncabezadoOrdenCompra);
            this.Controls.Add(this.lblDetalleOrdenCompra);
            this.Controls.Add(this.btnCancelarOrdenCompra);
            this.Controls.Add(this.dgvDetalleOrdenCompra);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.dgvOrdenesCompra);
            this.Controls.Add(this.btnFacurarOrdenCompra);
            this.Name = "DetalleOrdenesCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetalleOrdenesCompra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetalleOrdenesCompra_FormClosed);
            this.Load += new System.EventHandler(this.DetalleOrdenesCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrdenCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFacurarOrdenCompra;
        private System.Windows.Forms.DataGridView dgvOrdenesCompra;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNumeroIdentificacion;
        private System.Windows.Forms.DataGridView dgvDetalleOrdenCompra;
        private System.Windows.Forms.Button btnCancelarOrdenCompra;
        private System.Windows.Forms.Label lblDetalleOrdenCompra;
        private System.Windows.Forms.Label lblEncabezadoOrdenCompra;
        private System.Windows.Forms.RadioButton rbNombreCliente;
        private System.Windows.Forms.RadioButton rbNumeroIdentificacion;
        private System.Windows.Forms.RadioButton rbNumeroOrden;
        private System.Windows.Forms.TextBox TxtOrdenCompra;
        private System.Windows.Forms.TextBox txtNombreCliente;
    }
}