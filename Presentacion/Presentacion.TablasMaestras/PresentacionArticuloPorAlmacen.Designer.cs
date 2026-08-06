namespace Presentacion.TablasMaestras
{
    partial class PresentacionArticuloPorAlmacen
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
            this.LblAlmacen = new System.Windows.Forms.Label();
            this.CmbAlmacen = new System.Windows.Forms.ComboBox();
            this.DgvListarPresentacionArticulo = new System.Windows.Forms.DataGridView();
            this.DgvListarPresentacionArticuloPorAlmacen = new System.Windows.Forms.DataGridView();
            this.LblDgvPresentacionArticuloPorAlmacen = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnEliminarPresentacionArticuloPorAlmacen = new System.Windows.Forms.Button();
            this.LblDgvPresentacionArticuloPorAlmacenII = new System.Windows.Forms.Label();
            this.DgvListarPresentacionArticuloPorAlmacenII = new System.Windows.Forms.DataGridView();
            this.CmbAlmacenII = new System.Windows.Forms.ComboBox();
            this.LblAlmacenII = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnRemover = new System.Windows.Forms.Button();
            this.TxtTranferirCantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticuloPorAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticuloPorAlmacenII)).BeginInit();
            this.SuspendLayout();
            // 
            // LblAlmacen
            // 
            this.LblAlmacen.AutoSize = true;
            this.LblAlmacen.Location = new System.Drawing.Point(41, 35);
            this.LblAlmacen.Name = "LblAlmacen";
            this.LblAlmacen.Size = new System.Drawing.Size(48, 13);
            this.LblAlmacen.TabIndex = 0;
            this.LblAlmacen.Text = "Almacén";
            // 
            // CmbAlmacen
            // 
            this.CmbAlmacen.FormattingEnabled = true;
            this.CmbAlmacen.Location = new System.Drawing.Point(112, 32);
            this.CmbAlmacen.Name = "CmbAlmacen";
            this.CmbAlmacen.Size = new System.Drawing.Size(436, 21);
            this.CmbAlmacen.TabIndex = 1;
            this.CmbAlmacen.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacen_SelectedIndexChanged);
            // 
            // DgvListarPresentacionArticulo
            // 
            this.DgvListarPresentacionArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListarPresentacionArticulo.Location = new System.Drawing.Point(38, 317);
            this.DgvListarPresentacionArticulo.Name = "DgvListarPresentacionArticulo";
            this.DgvListarPresentacionArticulo.RowHeadersVisible = false;
            this.DgvListarPresentacionArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListarPresentacionArticulo.Size = new System.Drawing.Size(1098, 150);
            this.DgvListarPresentacionArticulo.TabIndex = 2;
            // 
            // DgvListarPresentacionArticuloPorAlmacen
            // 
            this.DgvListarPresentacionArticuloPorAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListarPresentacionArticuloPorAlmacen.Location = new System.Drawing.Point(38, 84);
            this.DgvListarPresentacionArticuloPorAlmacen.Name = "DgvListarPresentacionArticuloPorAlmacen";
            this.DgvListarPresentacionArticuloPorAlmacen.RowHeadersVisible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListarPresentacionArticuloPorAlmacen.Size = new System.Drawing.Size(510, 150);
            this.DgvListarPresentacionArticuloPorAlmacen.TabIndex = 3;
            this.DgvListarPresentacionArticuloPorAlmacen.SelectionChanged += new System.EventHandler(this.DgvListarPresentacionArticuloPorAlmacen_SelectionChanged);
            // 
            // LblDgvPresentacionArticuloPorAlmacen
            // 
            this.LblDgvPresentacionArticuloPorAlmacen.AutoSize = true;
            this.LblDgvPresentacionArticuloPorAlmacen.Location = new System.Drawing.Point(41, 68);
            this.LblDgvPresentacionArticuloPorAlmacen.Name = "LblDgvPresentacionArticuloPorAlmacen";
            this.LblDgvPresentacionArticuloPorAlmacen.Size = new System.Drawing.Size(195, 13);
            this.LblDgvPresentacionArticuloPorAlmacen.TabIndex = 4;
            this.LblDgvPresentacionArticuloPorAlmacen.Text = "Presentaciones de Articulo por Almacén";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(38, 269);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(196, 20);
            this.TxtCantidad.TabIndex = 5;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(240, 267);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(106, 23);
            this.BtnActualizar.TabIndex = 6;
            this.BtnActualizar.Text = "Actualizar Cantidad";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnEliminarPresentacionArticuloPorAlmacen
            // 
            this.BtnEliminarPresentacionArticuloPorAlmacen.Location = new System.Drawing.Point(38, 240);
            this.BtnEliminarPresentacionArticuloPorAlmacen.Name = "BtnEliminarPresentacionArticuloPorAlmacen";
            this.BtnEliminarPresentacionArticuloPorAlmacen.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminarPresentacionArticuloPorAlmacen.TabIndex = 7;
            this.BtnEliminarPresentacionArticuloPorAlmacen.Text = "Eliminar";
            this.BtnEliminarPresentacionArticuloPorAlmacen.UseVisualStyleBackColor = true;
            this.BtnEliminarPresentacionArticuloPorAlmacen.Click += new System.EventHandler(this.BtnEliminarPresentacionArticuloPorAlmacen_Click);
            // 
            // LblDgvPresentacionArticuloPorAlmacenII
            // 
            this.LblDgvPresentacionArticuloPorAlmacenII.AutoSize = true;
            this.LblDgvPresentacionArticuloPorAlmacenII.Location = new System.Drawing.Point(629, 68);
            this.LblDgvPresentacionArticuloPorAlmacenII.Name = "LblDgvPresentacionArticuloPorAlmacenII";
            this.LblDgvPresentacionArticuloPorAlmacenII.Size = new System.Drawing.Size(195, 13);
            this.LblDgvPresentacionArticuloPorAlmacenII.TabIndex = 11;
            this.LblDgvPresentacionArticuloPorAlmacenII.Text = "Presentaciones de Articulo por Almacén";
            // 
            // DgvListarPresentacionArticuloPorAlmacenII
            // 
            this.DgvListarPresentacionArticuloPorAlmacenII.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListarPresentacionArticuloPorAlmacenII.Location = new System.Drawing.Point(626, 84);
            this.DgvListarPresentacionArticuloPorAlmacenII.Name = "DgvListarPresentacionArticuloPorAlmacenII";
            this.DgvListarPresentacionArticuloPorAlmacenII.RowHeadersVisible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListarPresentacionArticuloPorAlmacenII.Size = new System.Drawing.Size(510, 150);
            this.DgvListarPresentacionArticuloPorAlmacenII.TabIndex = 10;
            // 
            // CmbAlmacenII
            // 
            this.CmbAlmacenII.FormattingEnabled = true;
            this.CmbAlmacenII.Location = new System.Drawing.Point(700, 32);
            this.CmbAlmacenII.Name = "CmbAlmacenII";
            this.CmbAlmacenII.Size = new System.Drawing.Size(436, 21);
            this.CmbAlmacenII.TabIndex = 9;
            this.CmbAlmacenII.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacenII_SelectedIndexChanged);
            // 
            // LblAlmacenII
            // 
            this.LblAlmacenII.AutoSize = true;
            this.LblAlmacenII.Location = new System.Drawing.Point(629, 35);
            this.LblAlmacenII.Name = "LblAlmacenII";
            this.LblAlmacenII.Size = new System.Drawing.Size(48, 13);
            this.LblAlmacenII.TabIndex = 8;
            this.LblAlmacenII.Text = "Almacén";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(556, 182);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(63, 23);
            this.BtnAgregar.TabIndex = 12;
            this.BtnAgregar.Text = ">>";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnRemover
            // 
            this.BtnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemover.Location = new System.Drawing.Point(556, 211);
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(63, 23);
            this.BtnRemover.TabIndex = 13;
            this.BtnRemover.Text = "<<";
            this.BtnRemover.UseVisualStyleBackColor = true;
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // TxtTranferirCantidad
            // 
            this.TxtTranferirCantidad.Location = new System.Drawing.Point(556, 156);
            this.TxtTranferirCantidad.Name = "TxtTranferirCantidad";
            this.TxtTranferirCantidad.Size = new System.Drawing.Size(63, 20);
            this.TxtTranferirCantidad.TabIndex = 14;
            // 
            // PresentacionArticuloPorAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 502);
            this.Controls.Add(this.TxtTranferirCantidad);
            this.Controls.Add(this.BtnRemover);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LblDgvPresentacionArticuloPorAlmacenII);
            this.Controls.Add(this.DgvListarPresentacionArticuloPorAlmacenII);
            this.Controls.Add(this.CmbAlmacenII);
            this.Controls.Add(this.LblAlmacenII);
            this.Controls.Add(this.BtnEliminarPresentacionArticuloPorAlmacen);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.LblDgvPresentacionArticuloPorAlmacen);
            this.Controls.Add(this.DgvListarPresentacionArticuloPorAlmacen);
            this.Controls.Add(this.DgvListarPresentacionArticulo);
            this.Controls.Add(this.CmbAlmacen);
            this.Controls.Add(this.LblAlmacen);
            this.Name = "PresentacionArticuloPorAlmacen";
            this.Text = "Configuración: Presentacion Articulo Por Almacen";
            this.Load += new System.EventHandler(this.PresentacionArticuloPorAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticuloPorAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListarPresentacionArticuloPorAlmacenII)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAlmacen;
        private System.Windows.Forms.ComboBox CmbAlmacen;
        private System.Windows.Forms.DataGridView DgvListarPresentacionArticulo;
        private System.Windows.Forms.DataGridView DgvListarPresentacionArticuloPorAlmacen;
        private System.Windows.Forms.Label LblDgvPresentacionArticuloPorAlmacen;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnEliminarPresentacionArticuloPorAlmacen;
        private System.Windows.Forms.Label LblDgvPresentacionArticuloPorAlmacenII;
        private System.Windows.Forms.DataGridView DgvListarPresentacionArticuloPorAlmacenII;
        private System.Windows.Forms.ComboBox CmbAlmacenII;
        private System.Windows.Forms.Label LblAlmacenII;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnRemover;
        private System.Windows.Forms.TextBox TxtTranferirCantidad;
    }
}