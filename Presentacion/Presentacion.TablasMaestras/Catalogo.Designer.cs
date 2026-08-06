namespace Presentacion.TablasMaestras
{
    partial class Catalogo
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
            this.LblNroColumnas = new System.Windows.Forms.Label();
            this.TxtNroColumnas = new System.Windows.Forms.TextBox();
            this.BtnGuardarConfiguracionGeneral = new System.Windows.Forms.Button();
            this.ChkExistencias = new System.Windows.Forms.CheckBox();
            this.ChkPrecio = new System.Windows.Forms.CheckBox();
            this.DgvCatalogo = new System.Windows.Forms.DataGridView();
            this.GroupBoxConfiguracionGeneral = new System.Windows.Forms.GroupBox();
            this.txtNroColumnasPorCategoria = new System.Windows.Forms.TextBox();
            this.LblNroColumnasPorCategoria = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uctrCategorias1 = new Controles.WinForms.UctrCategorias();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCatalogo)).BeginInit();
            this.GroupBoxConfiguracionGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblNroColumnas
            // 
            this.LblNroColumnas.AutoSize = true;
            this.LblNroColumnas.Location = new System.Drawing.Point(26, 100);
            this.LblNroColumnas.Name = "LblNroColumnas";
            this.LblNroColumnas.Size = new System.Drawing.Size(107, 13);
            this.LblNroColumnas.TabIndex = 2;
            this.LblNroColumnas.Text = "Número de columnas";
            // 
            // TxtNroColumnas
            // 
            this.TxtNroColumnas.Location = new System.Drawing.Point(220, 97);
            this.TxtNroColumnas.Name = "TxtNroColumnas";
            this.TxtNroColumnas.Size = new System.Drawing.Size(180, 20);
            this.TxtNroColumnas.TabIndex = 5;
            // 
            // BtnGuardarConfiguracionGeneral
            // 
            this.BtnGuardarConfiguracionGeneral.Location = new System.Drawing.Point(292, 123);
            this.BtnGuardarConfiguracionGeneral.Name = "BtnGuardarConfiguracionGeneral";
            this.BtnGuardarConfiguracionGeneral.Size = new System.Drawing.Size(108, 23);
            this.BtnGuardarConfiguracionGeneral.TabIndex = 7;
            this.BtnGuardarConfiguracionGeneral.Text = "Guardar";
            this.BtnGuardarConfiguracionGeneral.UseVisualStyleBackColor = true;
            this.BtnGuardarConfiguracionGeneral.Click += new System.EventHandler(this.BtnGuardarConfiguracionGeneral_Click);
            // 
            // ChkExistencias
            // 
            this.ChkExistencias.AutoSize = true;
            this.ChkExistencias.Location = new System.Drawing.Point(29, 48);
            this.ChkExistencias.Name = "ChkExistencias";
            this.ChkExistencias.Size = new System.Drawing.Size(79, 17);
            this.ChkExistencias.TabIndex = 8;
            this.ChkExistencias.Text = "Existencias";
            this.ChkExistencias.UseVisualStyleBackColor = true;
            // 
            // ChkPrecio
            // 
            this.ChkPrecio.AutoSize = true;
            this.ChkPrecio.Location = new System.Drawing.Point(29, 71);
            this.ChkPrecio.Name = "ChkPrecio";
            this.ChkPrecio.Size = new System.Drawing.Size(56, 17);
            this.ChkPrecio.TabIndex = 9;
            this.ChkPrecio.Text = "Precio";
            this.ChkPrecio.UseVisualStyleBackColor = true;
            // 
            // DgvCatalogo
            // 
            this.DgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCatalogo.Location = new System.Drawing.Point(19, 48);
            this.DgvCatalogo.Name = "DgvCatalogo";
            this.DgvCatalogo.RowHeadersVisible = false;
            this.DgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCatalogo.Size = new System.Drawing.Size(393, 86);
            this.DgvCatalogo.TabIndex = 10;
            // 
            // GroupBoxConfiguracionGeneral
            // 
            this.GroupBoxConfiguracionGeneral.Controls.Add(this.LblNroColumnas);
            this.GroupBoxConfiguracionGeneral.Controls.Add(this.ChkPrecio);
            this.GroupBoxConfiguracionGeneral.Controls.Add(this.TxtNroColumnas);
            this.GroupBoxConfiguracionGeneral.Controls.Add(this.ChkExistencias);
            this.GroupBoxConfiguracionGeneral.Controls.Add(this.BtnGuardarConfiguracionGeneral);
            this.GroupBoxConfiguracionGeneral.Location = new System.Drawing.Point(14, 12);
            this.GroupBoxConfiguracionGeneral.Name = "GroupBoxConfiguracionGeneral";
            this.GroupBoxConfiguracionGeneral.Size = new System.Drawing.Size(429, 157);
            this.GroupBoxConfiguracionGeneral.TabIndex = 11;
            this.GroupBoxConfiguracionGeneral.TabStop = false;
            this.GroupBoxConfiguracionGeneral.Text = "Configuración general del archivo PDF";
            // 
            // txtNroColumnasPorCategoria
            // 
            this.txtNroColumnasPorCategoria.Location = new System.Drawing.Point(147, 21);
            this.txtNroColumnasPorCategoria.Name = "txtNroColumnasPorCategoria";
            this.txtNroColumnasPorCategoria.Size = new System.Drawing.Size(145, 20);
            this.txtNroColumnasPorCategoria.TabIndex = 13;
            // 
            // LblNroColumnasPorCategoria
            // 
            this.LblNroColumnasPorCategoria.AutoSize = true;
            this.LblNroColumnasPorCategoria.Location = new System.Drawing.Point(17, 24);
            this.LblNroColumnasPorCategoria.Name = "LblNroColumnasPorCategoria";
            this.LblNroColumnasPorCategoria.Size = new System.Drawing.Size(120, 13);
            this.LblNroColumnasPorCategoria.TabIndex = 14;
            this.LblNroColumnasPorCategoria.Text = "Columnas por categoría";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(161, 140);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(108, 23);
            this.BtnEliminar.TabIndex = 15;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Location = new System.Drawing.Point(302, 19);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(108, 23);
            this.BtnInsertar.TabIndex = 16;
            this.BtnInsertar.Text = "Agregar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnAgregarConfiguracionPorCategoria_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEliminar);
            this.groupBox1.Controls.Add(this.DgvCatalogo);
            this.groupBox1.Controls.Add(this.BtnInsertar);
            this.groupBox1.Controls.Add(this.LblNroColumnasPorCategoria);
            this.groupBox1.Controls.Add(this.txtNroColumnasPorCategoria);
            this.groupBox1.Location = new System.Drawing.Point(12, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 173);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración por Categorías";
            // 
            // uctrCategorias1
            // 
            this.uctrCategorias1.Location = new System.Drawing.Point(29, 175);
            this.uctrCategorias1.Name = "uctrCategorias1";
            this.uctrCategorias1.Size = new System.Drawing.Size(395, 162);
            this.uctrCategorias1.TabIndex = 18;
            // 
            // Catalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 525);
            this.Controls.Add(this.uctrCategorias1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBoxConfiguracionGeneral);
            this.Name = "Catalogo";
            this.Text = "Catálogo";
            this.Load += new System.EventHandler(this.Catalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCatalogo)).EndInit();
            this.GroupBoxConfiguracionGeneral.ResumeLayout(false);
            this.GroupBoxConfiguracionGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblNroColumnas;
        private System.Windows.Forms.TextBox TxtNroColumnas;
        private System.Windows.Forms.Button BtnGuardarConfiguracionGeneral;
        private System.Windows.Forms.CheckBox ChkExistencias;
        private System.Windows.Forms.CheckBox ChkPrecio;
        private System.Windows.Forms.DataGridView DgvCatalogo;
        private System.Windows.Forms.GroupBox GroupBoxConfiguracionGeneral;
        private System.Windows.Forms.TextBox txtNroColumnasPorCategoria;
        private System.Windows.Forms.Label LblNroColumnasPorCategoria;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnInsertar;
        private Controles.WinForms.UctrCategorias uctrCategorias1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}