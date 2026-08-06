namespace Presentacion.Facturacion
{
    partial class ConfiguracionFactura
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
            this.LblIdAlmacen = new System.Windows.Forms.Label();
            this.CbAlmacen = new System.Windows.Forms.ComboBox();
            this.LblNIT = new System.Windows.Forms.Label();
            this.TxtNIT = new System.Windows.Forms.TextBox();
            this.LblPiePagina = new System.Windows.Forms.Label();
            this.TxtPiePagina = new System.Windows.Forms.TextBox();
            this.LblPaginaWeb = new System.Windows.Forms.Label();
            this.TxtUrlPaginaWeb = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.GbConfiguracionFactura = new System.Windows.Forms.GroupBox();
            this.GbActualizarNroFactura = new System.Windows.Forms.GroupBox();
            this.BtnActualizarNroFactura = new System.Windows.Forms.Button();
            this.TxtNroFactura = new System.Windows.Forms.TextBox();
            this.LblNroFactura = new System.Windows.Forms.Label();
            this.GbConfiguracionFactura.SuspendLayout();
            this.GbActualizarNroFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblIdAlmacen
            // 
            this.LblIdAlmacen.AutoSize = true;
            this.LblIdAlmacen.Location = new System.Drawing.Point(43, 32);
            this.LblIdAlmacen.Name = "LblIdAlmacen";
            this.LblIdAlmacen.Size = new System.Drawing.Size(48, 13);
            this.LblIdAlmacen.TabIndex = 0;
            this.LblIdAlmacen.Text = "Almacén";
            // 
            // CbAlmacen
            // 
            this.CbAlmacen.FormattingEnabled = true;
            this.CbAlmacen.Location = new System.Drawing.Point(166, 29);
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.Size = new System.Drawing.Size(259, 21);
            this.CbAlmacen.TabIndex = 1;
            // 
            // LblNIT
            // 
            this.LblNIT.AutoSize = true;
            this.LblNIT.Location = new System.Drawing.Point(47, 59);
            this.LblNIT.Name = "LblNIT";
            this.LblNIT.Size = new System.Drawing.Size(25, 13);
            this.LblNIT.TabIndex = 2;
            this.LblNIT.Text = "NIT";
            // 
            // TxtNIT
            // 
            this.TxtNIT.Location = new System.Drawing.Point(166, 56);
            this.TxtNIT.Name = "TxtNIT";
            this.TxtNIT.Size = new System.Drawing.Size(259, 20);
            this.TxtNIT.TabIndex = 3;
            // 
            // LblPiePagina
            // 
            this.LblPiePagina.AutoSize = true;
            this.LblPiePagina.Location = new System.Drawing.Point(43, 85);
            this.LblPiePagina.Name = "LblPiePagina";
            this.LblPiePagina.Size = new System.Drawing.Size(103, 13);
            this.LblPiePagina.TabIndex = 4;
            this.LblPiePagina.Text = "Texto Pie de Página";
            // 
            // TxtPiePagina
            // 
            this.TxtPiePagina.Location = new System.Drawing.Point(166, 82);
            this.TxtPiePagina.Name = "TxtPiePagina";
            this.TxtPiePagina.Size = new System.Drawing.Size(259, 20);
            this.TxtPiePagina.TabIndex = 5;
            // 
            // LblPaginaWeb
            // 
            this.LblPaginaWeb.AutoSize = true;
            this.LblPaginaWeb.Location = new System.Drawing.Point(46, 111);
            this.LblPaginaWeb.Name = "LblPaginaWeb";
            this.LblPaginaWeb.Size = new System.Drawing.Size(66, 13);
            this.LblPaginaWeb.TabIndex = 6;
            this.LblPaginaWeb.Text = "Página Web";
            // 
            // TxtUrlPaginaWeb
            // 
            this.TxtUrlPaginaWeb.Location = new System.Drawing.Point(166, 108);
            this.TxtUrlPaginaWeb.Name = "TxtUrlPaginaWeb";
            this.TxtUrlPaginaWeb.Size = new System.Drawing.Size(259, 20);
            this.TxtUrlPaginaWeb.TabIndex = 7;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(276, 134);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(149, 23);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // GbConfiguracionFactura
            // 
            this.GbConfiguracionFactura.Controls.Add(this.TxtUrlPaginaWeb);
            this.GbConfiguracionFactura.Controls.Add(this.LblPaginaWeb);
            this.GbConfiguracionFactura.Controls.Add(this.BtnGuardar);
            this.GbConfiguracionFactura.Controls.Add(this.TxtPiePagina);
            this.GbConfiguracionFactura.Controls.Add(this.LblPiePagina);
            this.GbConfiguracionFactura.Controls.Add(this.TxtNIT);
            this.GbConfiguracionFactura.Controls.Add(this.LblNIT);
            this.GbConfiguracionFactura.Controls.Add(this.CbAlmacen);
            this.GbConfiguracionFactura.Controls.Add(this.LblIdAlmacen);
            this.GbConfiguracionFactura.Location = new System.Drawing.Point(15, 12);
            this.GbConfiguracionFactura.Name = "GbConfiguracionFactura";
            this.GbConfiguracionFactura.Size = new System.Drawing.Size(436, 168);
            this.GbConfiguracionFactura.TabIndex = 9;
            this.GbConfiguracionFactura.TabStop = false;
            // 
            // GbActualizarNroFactura
            // 
            this.GbActualizarNroFactura.Controls.Add(this.BtnActualizarNroFactura);
            this.GbActualizarNroFactura.Controls.Add(this.TxtNroFactura);
            this.GbActualizarNroFactura.Controls.Add(this.LblNroFactura);
            this.GbActualizarNroFactura.Location = new System.Drawing.Point(15, 187);
            this.GbActualizarNroFactura.Name = "GbActualizarNroFactura";
            this.GbActualizarNroFactura.Size = new System.Drawing.Size(436, 60);
            this.GbActualizarNroFactura.TabIndex = 10;
            this.GbActualizarNroFactura.TabStop = false;
            // 
            // BtnActualizarNroFactura
            // 
            this.BtnActualizarNroFactura.Location = new System.Drawing.Point(362, 27);
            this.BtnActualizarNroFactura.Name = "BtnActualizarNroFactura";
            this.BtnActualizarNroFactura.Size = new System.Drawing.Size(63, 23);
            this.BtnActualizarNroFactura.TabIndex = 2;
            this.BtnActualizarNroFactura.Text = "Actualizar";
            this.BtnActualizarNroFactura.UseVisualStyleBackColor = true;
            this.BtnActualizarNroFactura.Click += new System.EventHandler(this.BtnActualizarNroFactura_Click);
            // 
            // TxtNroFactura
            // 
            this.TxtNroFactura.Location = new System.Drawing.Point(161, 29);
            this.TxtNroFactura.Name = "TxtNroFactura";
            this.TxtNroFactura.Size = new System.Drawing.Size(195, 20);
            this.TxtNroFactura.TabIndex = 1;
            // 
            // LblNroFactura
            // 
            this.LblNroFactura.AutoSize = true;
            this.LblNroFactura.Location = new System.Drawing.Point(43, 32);
            this.LblNroFactura.Name = "LblNroFactura";
            this.LblNroFactura.Size = new System.Drawing.Size(98, 13);
            this.LblNroFactura.TabIndex = 0;
            this.LblNroFactura.Text = "Número de Factura";
            // 
            // ConfiguracionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 271);
            this.Controls.Add(this.GbActualizarNroFactura);
            this.Controls.Add(this.GbConfiguracionFactura);
            this.Name = "ConfiguracionFactura";
            this.Text = "Configuración Factura";
            this.Load += new System.EventHandler(this.ConfiguracionFactura_Load);
            this.GbConfiguracionFactura.ResumeLayout(false);
            this.GbConfiguracionFactura.PerformLayout();
            this.GbActualizarNroFactura.ResumeLayout(false);
            this.GbActualizarNroFactura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblIdAlmacen;
        private System.Windows.Forms.ComboBox CbAlmacen;
        private System.Windows.Forms.Label LblNIT;
        private System.Windows.Forms.TextBox TxtNIT;
        private System.Windows.Forms.Label LblPiePagina;
        private System.Windows.Forms.TextBox TxtPiePagina;
        private System.Windows.Forms.Label LblPaginaWeb;
        private System.Windows.Forms.TextBox TxtUrlPaginaWeb;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox GbConfiguracionFactura;
        private System.Windows.Forms.GroupBox GbActualizarNroFactura;
        private System.Windows.Forms.Button BtnActualizarNroFactura;
        private System.Windows.Forms.TextBox TxtNroFactura;
        private System.Windows.Forms.Label LblNroFactura;
    }
}