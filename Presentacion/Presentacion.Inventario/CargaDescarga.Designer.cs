namespace Presentacion.Inventario
{
    partial class CargaDescarga
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
            this.components = new System.ComponentModel.Container();
            this.RbCarga = new System.Windows.Forms.RadioButton();
            this.RbDescarga = new System.Windows.Forms.RadioButton();
            this.TxtCodigoBarras = new System.Windows.Forms.TextBox();
            this.LblArticulo = new System.Windows.Forms.Label();
            this.PictureBoxPresentacionArticulo = new System.Windows.Forms.PictureBox();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.LblExistencias = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LblCodigoBarras = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DgvArtículos = new System.Windows.Forms.DataGridView();
            this.Artículo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imágen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblDetalles = new System.Windows.Forms.Label();
            this.TxtDetalles = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPresentacionArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArtículos)).BeginInit();
            this.SuspendLayout();
            // 
            // RbCarga
            // 
            this.RbCarga.AutoSize = true;
            this.RbCarga.Checked = true;
            this.RbCarga.Location = new System.Drawing.Point(111, 32);
            this.RbCarga.Name = "RbCarga";
            this.RbCarga.Size = new System.Drawing.Size(53, 17);
            this.RbCarga.TabIndex = 0;
            this.RbCarga.TabStop = true;
            this.RbCarga.Text = "Carga";
            this.RbCarga.UseVisualStyleBackColor = true;
            this.RbCarga.Click += new System.EventHandler(this.RbCarga_Click);
            // 
            // RbDescarga
            // 
            this.RbDescarga.AutoSize = true;
            this.RbDescarga.Location = new System.Drawing.Point(200, 32);
            this.RbDescarga.Name = "RbDescarga";
            this.RbDescarga.Size = new System.Drawing.Size(71, 17);
            this.RbDescarga.TabIndex = 1;
            this.RbDescarga.Text = "Descarga";
            this.RbDescarga.UseVisualStyleBackColor = true;
            this.RbDescarga.Click += new System.EventHandler(this.RbDescarga_Click);
            // 
            // TxtCodigoBarras
            // 
            this.TxtCodigoBarras.Location = new System.Drawing.Point(130, 75);
            this.TxtCodigoBarras.Name = "TxtCodigoBarras";
            this.TxtCodigoBarras.Size = new System.Drawing.Size(185, 20);
            this.TxtCodigoBarras.TabIndex = 2;
            this.TxtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigoBarras_KeyPress);
            // 
            // LblArticulo
            // 
            this.LblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArticulo.Location = new System.Drawing.Point(12, 239);
            this.LblArticulo.Name = "LblArticulo";
            this.LblArticulo.Size = new System.Drawing.Size(364, 37);
            this.LblArticulo.TabIndex = 3;
            this.LblArticulo.Text = "Articulo";
            this.LblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBoxPresentacionArticulo
            // 
            this.PictureBoxPresentacionArticulo.Location = new System.Drawing.Point(388, 9);
            this.PictureBoxPresentacionArticulo.Name = "PictureBoxPresentacionArticulo";
            this.PictureBoxPresentacionArticulo.Size = new System.Drawing.Size(308, 306);
            this.PictureBoxPresentacionArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxPresentacionArticulo.TabIndex = 4;
            this.PictureBoxPresentacionArticulo.TabStop = false;
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(130, 117);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(100, 20);
            this.TxtCantidad.TabIndex = 5;
            this.TxtCantidad.Text = "1";
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LblExistencias
            // 
            this.LblExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExistencias.Location = new System.Drawing.Point(12, 276);
            this.LblExistencias.Name = "LblExistencias";
            this.LblExistencias.Size = new System.Drawing.Size(364, 37);
            this.LblExistencias.TabIndex = 6;
            this.LblExistencias.Text = "Existencias";
            this.LblExistencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LblCodigoBarras
            // 
            this.LblCodigoBarras.AutoSize = true;
            this.LblCodigoBarras.Location = new System.Drawing.Point(18, 75);
            this.LblCodigoBarras.Name = "LblCodigoBarras";
            this.LblCodigoBarras.Size = new System.Drawing.Size(88, 13);
            this.LblCodigoBarras.TabIndex = 7;
            this.LblCodigoBarras.Text = "Codigo de Barras";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(21, 123);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(49, 13);
            this.LblCantidad.TabIndex = 8;
            this.LblCantidad.Text = "Cantidad";
            // 
            // timer1
            // 
            this.timer1.Interval = 1250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // DgvArtículos
            // 
            this.DgvArtículos.AllowUserToAddRows = false;
            this.DgvArtículos.AllowUserToDeleteRows = false;
            this.DgvArtículos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArtículos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Artículo,
            this.Cantidad,
            this.Detalles,
            this.Imágen,
            this.Fecha});
            this.DgvArtículos.Location = new System.Drawing.Point(18, 350);
            this.DgvArtículos.Name = "DgvArtículos";
            this.DgvArtículos.ReadOnly = true;
            this.DgvArtículos.RowHeadersVisible = false;
            this.DgvArtículos.RowTemplate.Height = 100;
            this.DgvArtículos.Size = new System.Drawing.Size(661, 255);
            this.DgvArtículos.TabIndex = 9;
            // 
            // Artículo
            // 
            this.Artículo.DataPropertyName = "Nombre";
            this.Artículo.HeaderText = "Artículo";
            this.Artículo.Name = "Artículo";
            this.Artículo.ReadOnly = true;
            this.Artículo.Width = 250;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Existencias";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Detalles
            // 
            this.Detalles.DataPropertyName = "DescripcionBreve";
            this.Detalles.HeaderText = "Detalles";
            this.Detalles.Name = "Detalles";
            this.Detalles.ReadOnly = true;
            // 
            // Imágen
            // 
            this.Imágen.DataPropertyName = "Imagen1";
            this.Imágen.HeaderText = "Imágen";
            this.Imágen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Imágen.Name = "Imágen";
            this.Imágen.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // LblDetalles
            // 
            this.LblDetalles.AutoSize = true;
            this.LblDetalles.Location = new System.Drawing.Point(24, 178);
            this.LblDetalles.Name = "LblDetalles";
            this.LblDetalles.Size = new System.Drawing.Size(45, 13);
            this.LblDetalles.TabIndex = 10;
            this.LblDetalles.Text = "Detalles";
            // 
            // TxtDetalles
            // 
            this.TxtDetalles.Location = new System.Drawing.Point(130, 178);
            this.TxtDetalles.MaxLength = 50;
            this.TxtDetalles.Multiline = true;
            this.TxtDetalles.Name = "TxtDetalles";
            this.TxtDetalles.Size = new System.Drawing.Size(246, 58);
            this.TxtDetalles.TabIndex = 11;
            // 
            // CargaDescarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 617);
            this.Controls.Add(this.TxtDetalles);
            this.Controls.Add(this.LblDetalles);
            this.Controls.Add(this.DgvArtículos);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.LblCodigoBarras);
            this.Controls.Add(this.LblExistencias);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.PictureBoxPresentacionArticulo);
            this.Controls.Add(this.LblArticulo);
            this.Controls.Add(this.TxtCodigoBarras);
            this.Controls.Add(this.RbDescarga);
            this.Controls.Add(this.RbCarga);
            this.Name = "CargaDescarga";
            this.Text = "CargaDescarga";
            this.Activated += new System.EventHandler(this.CargaDescarga_Activated);
            this.Load += new System.EventHandler(this.CargaDescarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPresentacionArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArtículos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbCarga;
        private System.Windows.Forms.RadioButton RbDescarga;
        private System.Windows.Forms.TextBox TxtCodigoBarras;
        private System.Windows.Forms.Label LblArticulo;
        private System.Windows.Forms.PictureBox PictureBoxPresentacionArticulo;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label LblExistencias;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label LblCodigoBarras;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView DgvArtículos;
        private System.Windows.Forms.TextBox TxtDetalles;
        private System.Windows.Forms.Label LblDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artículo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalles;
        private System.Windows.Forms.DataGridViewImageColumn Imágen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}