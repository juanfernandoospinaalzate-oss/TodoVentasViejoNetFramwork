namespace Presentacion.TablasMaestras
{
    partial class Articulo
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DgvArticulo = new System.Windows.Forms.DataGridView();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtTitulo = new System.Windows.Forms.TextBox();
            this.LblMarca = new System.Windows.Forms.Label();
            this.ChkColores = new System.Windows.Forms.CheckBox();
            this.ChkTallas = new System.Windows.Forms.CheckBox();
            this.ChkLongitud = new System.Windows.Forms.CheckBox();
            this.ChkMasa = new System.Windows.Forms.CheckBox();
            this.ChkVolumen = new System.Windows.Forms.CheckBox();
            this.ChkActivo = new System.Windows.Forms.CheckBox();
            this.ChkPreOrdenar = new System.Windows.Forms.CheckBox();
            this.ChkEnLinea = new System.Windows.Forms.CheckBox();
            this.TxtMetaKeyWords = new System.Windows.Forms.TextBox();
            this.TxtMetaDescripcion = new System.Windows.Forms.TextBox();
            this.LblMetaKeyWords = new System.Windows.Forms.Label();
            this.LblMetaDescripcion = new System.Windows.Forms.Label();
            this.TxtVideoYoutube = new System.Windows.Forms.TextBox();
            this.TxtGarantiaMeses = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblVideoYoutube = new System.Windows.Forms.Label();
            this.LblGarantiaMeses = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.LblPalabrasRelacionadas = new System.Windows.Forms.Label();
            this.TxtPalabrasRelacionadas = new System.Windows.Forms.TextBox();
            this.CmbMarca = new System.Windows.Forms.ComboBox();
            this.BtnEditPresentacion = new System.Windows.Forms.Button();
            this.RbActivo = new System.Windows.Forms.RadioButton();
            this.RbInactivo = new System.Windows.Forms.RadioButton();
            this.RbTodos = new System.Windows.Forms.RadioButton();
            this.ChkSabores = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFiltrarBusqueda = new System.Windows.Forms.GroupBox();
            this.ChkUnidadPresentacion = new System.Windows.Forms.CheckBox();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            this.ucTrCategorias1 = new Controles.WinForms.UctrCategorias();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbFiltrarBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // DgvArticulo
            // 
            this.DgvArticulo.AllowUserToAddRows = false;
            this.DgvArticulo.AllowUserToDeleteRows = false;
            this.DgvArticulo.AllowUserToResizeColumns = false;
            this.DgvArticulo.AllowUserToResizeRows = false;
            this.DgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvArticulo.Location = new System.Drawing.Point(13, 374);
            this.DgvArticulo.MultiSelect = false;
            this.DgvArticulo.Name = "DgvArticulo";
            this.DgvArticulo.ReadOnly = true;
            this.DgvArticulo.RowHeadersVisible = false;
            this.DgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArticulo.Size = new System.Drawing.Size(1122, 296);
            this.DgvArticulo.TabIndex = 24;
            this.DgvArticulo.SelectionChanged += new System.EventHandler(this.DgvArticulo_SelectionChanged);
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Location = new System.Drawing.Point(10, 37);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(0, 13);
            this.LblTitulo.TabIndex = 82;
            // 
            // TxtTitulo
            // 
            this.TxtTitulo.Location = new System.Drawing.Point(137, 32);
            this.TxtTitulo.Name = "TxtTitulo";
            this.TxtTitulo.Size = new System.Drawing.Size(556, 20);
            this.TxtTitulo.TabIndex = 1;
            // 
            // LblMarca
            // 
            this.LblMarca.AutoSize = true;
            this.LblMarca.Location = new System.Drawing.Point(10, 8);
            this.LblMarca.Name = "LblMarca";
            this.LblMarca.Size = new System.Drawing.Size(0, 13);
            this.LblMarca.TabIndex = 85;
            // 
            // ChkColores
            // 
            this.ChkColores.AutoSize = true;
            this.ChkColores.Location = new System.Drawing.Point(143, 46);
            this.ChkColores.Name = "ChkColores";
            this.ChkColores.Size = new System.Drawing.Size(15, 14);
            this.ChkColores.TabIndex = 13;
            this.ChkColores.UseVisualStyleBackColor = true;
            // 
            // ChkTallas
            // 
            this.ChkTallas.AutoSize = true;
            this.ChkTallas.Location = new System.Drawing.Point(143, 26);
            this.ChkTallas.Name = "ChkTallas";
            this.ChkTallas.Size = new System.Drawing.Size(15, 14);
            this.ChkTallas.TabIndex = 10;
            this.ChkTallas.UseVisualStyleBackColor = true;
            // 
            // ChkLongitud
            // 
            this.ChkLongitud.AutoSize = true;
            this.ChkLongitud.Location = new System.Drawing.Point(272, 46);
            this.ChkLongitud.Name = "ChkLongitud";
            this.ChkLongitud.Size = new System.Drawing.Size(15, 14);
            this.ChkLongitud.TabIndex = 14;
            this.ChkLongitud.UseVisualStyleBackColor = true;
            // 
            // ChkMasa
            // 
            this.ChkMasa.AutoSize = true;
            this.ChkMasa.Location = new System.Drawing.Point(6, 46);
            this.ChkMasa.Name = "ChkMasa";
            this.ChkMasa.Size = new System.Drawing.Size(15, 14);
            this.ChkMasa.TabIndex = 12;
            this.ChkMasa.UseVisualStyleBackColor = true;
            // 
            // ChkVolumen
            // 
            this.ChkVolumen.AutoSize = true;
            this.ChkVolumen.Location = new System.Drawing.Point(6, 26);
            this.ChkVolumen.Name = "ChkVolumen";
            this.ChkVolumen.Size = new System.Drawing.Size(15, 14);
            this.ChkVolumen.TabIndex = 9;
            this.ChkVolumen.UseVisualStyleBackColor = true;
            // 
            // ChkActivo
            // 
            this.ChkActivo.AutoSize = true;
            this.ChkActivo.Location = new System.Drawing.Point(718, 126);
            this.ChkActivo.Name = "ChkActivo";
            this.ChkActivo.Size = new System.Drawing.Size(15, 14);
            this.ChkActivo.TabIndex = 16;
            this.ChkActivo.UseVisualStyleBackColor = true;
            // 
            // ChkPreOrdenar
            // 
            this.ChkPreOrdenar.AutoSize = true;
            this.ChkPreOrdenar.Location = new System.Drawing.Point(984, 126);
            this.ChkPreOrdenar.Name = "ChkPreOrdenar";
            this.ChkPreOrdenar.Size = new System.Drawing.Size(15, 14);
            this.ChkPreOrdenar.TabIndex = 18;
            this.ChkPreOrdenar.UseVisualStyleBackColor = true;
            // 
            // ChkEnLinea
            // 
            this.ChkEnLinea.AutoSize = true;
            this.ChkEnLinea.Location = new System.Drawing.Point(855, 126);
            this.ChkEnLinea.Name = "ChkEnLinea";
            this.ChkEnLinea.Size = new System.Drawing.Size(15, 14);
            this.ChkEnLinea.TabIndex = 17;
            this.ChkEnLinea.UseVisualStyleBackColor = true;
            // 
            // TxtMetaKeyWords
            // 
            this.TxtMetaKeyWords.Location = new System.Drawing.Point(836, 8);
            this.TxtMetaKeyWords.Name = "TxtMetaKeyWords";
            this.TxtMetaKeyWords.Size = new System.Drawing.Size(267, 20);
            this.TxtMetaKeyWords.TabIndex = 7;
            // 
            // TxtMetaDescripcion
            // 
            this.TxtMetaDescripcion.Location = new System.Drawing.Point(137, 240);
            this.TxtMetaDescripcion.Multiline = true;
            this.TxtMetaDescripcion.Name = "TxtMetaDescripcion";
            this.TxtMetaDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMetaDescripcion.Size = new System.Drawing.Size(556, 96);
            this.TxtMetaDescripcion.TabIndex = 6;
            // 
            // LblMetaKeyWords
            // 
            this.LblMetaKeyWords.AutoSize = true;
            this.LblMetaKeyWords.Location = new System.Drawing.Point(711, 15);
            this.LblMetaKeyWords.Name = "LblMetaKeyWords";
            this.LblMetaKeyWords.Size = new System.Drawing.Size(0, 13);
            this.LblMetaKeyWords.TabIndex = 99;
            // 
            // LblMetaDescripcion
            // 
            this.LblMetaDescripcion.AutoSize = true;
            this.LblMetaDescripcion.Location = new System.Drawing.Point(10, 286);
            this.LblMetaDescripcion.Name = "LblMetaDescripcion";
            this.LblMetaDescripcion.Size = new System.Drawing.Size(0, 13);
            this.LblMetaDescripcion.TabIndex = 98;
            // 
            // TxtVideoYoutube
            // 
            this.TxtVideoYoutube.Location = new System.Drawing.Point(137, 214);
            this.TxtVideoYoutube.Name = "TxtVideoYoutube";
            this.TxtVideoYoutube.Size = new System.Drawing.Size(556, 20);
            this.TxtVideoYoutube.TabIndex = 5;
            // 
            // TxtGarantiaMeses
            // 
            this.TxtGarantiaMeses.Location = new System.Drawing.Point(137, 188);
            this.TxtGarantiaMeses.Name = "TxtGarantiaMeses";
            this.TxtGarantiaMeses.Size = new System.Drawing.Size(556, 20);
            this.TxtGarantiaMeses.TabIndex = 4;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(137, 57);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescripcion.Size = new System.Drawing.Size(556, 99);
            this.TxtDescripcion.TabIndex = 2;
            // 
            // LblVideoYoutube
            // 
            this.LblVideoYoutube.AutoSize = true;
            this.LblVideoYoutube.Location = new System.Drawing.Point(10, 222);
            this.LblVideoYoutube.Name = "LblVideoYoutube";
            this.LblVideoYoutube.Size = new System.Drawing.Size(0, 13);
            this.LblVideoYoutube.TabIndex = 92;
            // 
            // LblGarantiaMeses
            // 
            this.LblGarantiaMeses.AutoSize = true;
            this.LblGarantiaMeses.Location = new System.Drawing.Point(10, 196);
            this.LblGarantiaMeses.Name = "LblGarantiaMeses";
            this.LblGarantiaMeses.Size = new System.Drawing.Size(0, 13);
            this.LblGarantiaMeses.TabIndex = 91;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(10, 67);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(0, 13);
            this.LblDescripcion.TabIndex = 89;
            // 
            // LblPalabrasRelacionadas
            // 
            this.LblPalabrasRelacionadas.AutoSize = true;
            this.LblPalabrasRelacionadas.Location = new System.Drawing.Point(10, 165);
            this.LblPalabrasRelacionadas.Name = "LblPalabrasRelacionadas";
            this.LblPalabrasRelacionadas.Size = new System.Drawing.Size(0, 13);
            this.LblPalabrasRelacionadas.TabIndex = 102;
            // 
            // TxtPalabrasRelacionadas
            // 
            this.TxtPalabrasRelacionadas.Location = new System.Drawing.Point(137, 162);
            this.TxtPalabrasRelacionadas.Name = "TxtPalabrasRelacionadas";
            this.TxtPalabrasRelacionadas.Size = new System.Drawing.Size(556, 20);
            this.TxtPalabrasRelacionadas.TabIndex = 3;
            // 
            // CmbMarca
            // 
            this.CmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMarca.FormattingEnabled = true;
            this.CmbMarca.Location = new System.Drawing.Point(137, 5);
            this.CmbMarca.Name = "CmbMarca";
            this.CmbMarca.Size = new System.Drawing.Size(556, 21);
            this.CmbMarca.TabIndex = 0;
            // 
            // BtnEditPresentacion
            // 
            this.BtnEditPresentacion.Location = new System.Drawing.Point(861, 323);
            this.BtnEditPresentacion.Name = "BtnEditPresentacion";
            this.BtnEditPresentacion.Size = new System.Drawing.Size(245, 23);
            this.BtnEditPresentacion.TabIndex = 20;
            this.BtnEditPresentacion.UseVisualStyleBackColor = true;
            this.BtnEditPresentacion.Click += new System.EventHandler(this.BtnEditPresentacion_Click);
            // 
            // RbActivo
            // 
            this.RbActivo.AutoSize = true;
            this.RbActivo.Checked = true;
            this.RbActivo.Location = new System.Drawing.Point(803, 355);
            this.RbActivo.Name = "RbActivo";
            this.RbActivo.Size = new System.Drawing.Size(14, 13);
            this.RbActivo.TabIndex = 21;
            this.RbActivo.TabStop = true;
            this.RbActivo.UseVisualStyleBackColor = true;
            this.RbActivo.CheckedChanged += new System.EventHandler(this.RbActivo_CheckedChanged);
            // 
            // RbInactivo
            // 
            this.RbInactivo.AutoSize = true;
            this.RbInactivo.Location = new System.Drawing.Point(905, 355);
            this.RbInactivo.Name = "RbInactivo";
            this.RbInactivo.Size = new System.Drawing.Size(14, 13);
            this.RbInactivo.TabIndex = 22;
            this.RbInactivo.UseVisualStyleBackColor = true;
            this.RbInactivo.CheckedChanged += new System.EventHandler(this.RbInactivo_CheckedChanged);
            // 
            // RbTodos
            // 
            this.RbTodos.AutoSize = true;
            this.RbTodos.Location = new System.Drawing.Point(1012, 355);
            this.RbTodos.Name = "RbTodos";
            this.RbTodos.Size = new System.Drawing.Size(14, 13);
            this.RbTodos.TabIndex = 23;
            this.RbTodos.UseVisualStyleBackColor = true;
            this.RbTodos.CheckedChanged += new System.EventHandler(this.RbTodos_CheckedChanged);
            // 
            // ChkSabores
            // 
            this.ChkSabores.AutoSize = true;
            this.ChkSabores.Location = new System.Drawing.Point(272, 26);
            this.ChkSabores.Name = "ChkSabores";
            this.ChkSabores.Size = new System.Drawing.Size(15, 14);
            this.ChkSabores.TabIndex = 11;
            this.ChkSabores.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbFiltrarBusqueda
            // 
            this.gbFiltrarBusqueda.Controls.Add(this.ChkUnidadPresentacion);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkVolumen);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkMasa);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkTallas);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkColores);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkLongitud);
            this.gbFiltrarBusqueda.Controls.Add(this.ChkSabores);
            this.gbFiltrarBusqueda.Location = new System.Drawing.Point(712, 34);
            this.gbFiltrarBusqueda.Name = "gbFiltrarBusqueda";
            this.gbFiltrarBusqueda.Size = new System.Drawing.Size(394, 86);
            this.gbFiltrarBusqueda.TabIndex = 8;
            this.gbFiltrarBusqueda.TabStop = false;
            this.gbFiltrarBusqueda.Text = "groupBox1";
            // 
            // ChkUnidadPresentacion
            // 
            this.ChkUnidadPresentacion.AutoSize = true;
            this.ChkUnidadPresentacion.Location = new System.Drawing.Point(6, 63);
            this.ChkUnidadPresentacion.Name = "ChkUnidadPresentacion";
            this.ChkUnidadPresentacion.Size = new System.Drawing.Size(71, 17);
            this.ChkUnidadPresentacion.TabIndex = 15;
            this.ChkUnidadPresentacion.Text = "Unidades";
            this.ChkUnidadPresentacion.UseVisualStyleBackColor = true;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(373, 676);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 25;
            // 
            // ucTrCategorias1
            // 
            this.ucTrCategorias1.Location = new System.Drawing.Point(712, 155);
            this.ucTrCategorias1.Name = "ucTrCategorias1";
            this.ucTrCategorias1.Size = new System.Drawing.Size(393, 162);
            this.ucTrCategorias1.TabIndex = 19;
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(137, 342);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(556, 20);
            this.TxtBusqueda.TabIndex = 103;
            this.TxtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBusqueda_KeyPress);
            // 
            // Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 715);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.gbFiltrarBusqueda);
            this.Controls.Add(this.ChkActivo);
            this.Controls.Add(this.ChkEnLinea);
            this.Controls.Add(this.ChkPreOrdenar);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.RbTodos);
            this.Controls.Add(this.RbInactivo);
            this.Controls.Add(this.RbActivo);
            this.Controls.Add(this.BtnEditPresentacion);
            this.Controls.Add(this.CmbMarca);
            this.Controls.Add(this.TxtPalabrasRelacionadas);
            this.Controls.Add(this.LblPalabrasRelacionadas);
            this.Controls.Add(this.TxtMetaKeyWords);
            this.Controls.Add(this.TxtMetaDescripcion);
            this.Controls.Add(this.LblMetaKeyWords);
            this.Controls.Add(this.LblMetaDescripcion);
            this.Controls.Add(this.TxtVideoYoutube);
            this.Controls.Add(this.TxtGarantiaMeses);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.LblVideoYoutube);
            this.Controls.Add(this.LblGarantiaMeses);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblMarca);
            this.Controls.Add(this.TxtTitulo);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.ucTrCategorias1);
            this.Controls.Add(this.DgvArticulo);
            this.Name = "Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Articulo_Load);
            this.EnabledChanged += new System.EventHandler(this.Articulo_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbFiltrarBusqueda.ResumeLayout(false);
            this.gbFiltrarBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView DgvArticulo;
        private Controles.WinForms.UctrCategorias ucTrCategorias1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtTitulo;
        private System.Windows.Forms.Label LblMarca;
        private System.Windows.Forms.CheckBox ChkLongitud;
        private System.Windows.Forms.CheckBox ChkMasa;
        private System.Windows.Forms.CheckBox ChkVolumen;
        private System.Windows.Forms.CheckBox ChkTallas;
        private System.Windows.Forms.CheckBox ChkColores;
        private System.Windows.Forms.TextBox TxtMetaKeyWords;
        private System.Windows.Forms.TextBox TxtMetaDescripcion;
        private System.Windows.Forms.Label LblMetaKeyWords;
        private System.Windows.Forms.Label LblMetaDescripcion;
        private System.Windows.Forms.TextBox TxtVideoYoutube;
        private System.Windows.Forms.TextBox TxtGarantiaMeses;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblVideoYoutube;
        private System.Windows.Forms.Label LblGarantiaMeses;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblPalabrasRelacionadas;
        private System.Windows.Forms.TextBox TxtPalabrasRelacionadas;
        private System.Windows.Forms.ComboBox CmbMarca;
        private System.Windows.Forms.Button BtnEditPresentacion;
        private System.Windows.Forms.CheckBox ChkEnLinea;
        private System.Windows.Forms.CheckBox ChkPreOrdenar;
        private System.Windows.Forms.CheckBox ChkActivo;
        private System.Windows.Forms.RadioButton RbActivo;
        private System.Windows.Forms.RadioButton RbInactivo;
        private System.Windows.Forms.RadioButton RbTodos;
        private System.Windows.Forms.CheckBox ChkSabores;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.GroupBox gbFiltrarBusqueda;
        private System.Windows.Forms.CheckBox ChkUnidadPresentacion;
        private System.Windows.Forms.TextBox TxtBusqueda;
    }
}