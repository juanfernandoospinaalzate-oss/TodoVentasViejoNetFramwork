namespace Presentacion.TablasMaestras
{
    partial class Cliente
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
            this.LblIdentificacion = new System.Windows.Forms.Label();
            this.TxtIdentificacion = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TxtNombres = new System.Windows.Forms.TextBox();
            this.LblNombres = new System.Windows.Forms.Label();
            this.LblApellidos = new System.Windows.Forms.Label();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.ucPaisDepartamentoCiudad1 = new Controles.WinForms.UcPaisDepartamentoCiudad();
            this.LblPaís = new System.Windows.Forms.Label();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.LblCiudad = new System.Windows.Forms.Label();
            this.LblCorreoElectronico = new System.Windows.Forms.Label();
            this.TxtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.LblContraseña = new System.Windows.Forms.Label();
            this.TxtContraseña = new System.Windows.Forms.TextBox();
            this.LblRepetirContrasena = new System.Windows.Forms.Label();
            this.TxtRepetirContrasena = new System.Windows.Forms.TextBox();
            this.LblTelefonoFijo = new System.Windows.Forms.Label();
            this.TxtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.TxtTelefonoMovil = new System.Windows.Forms.TextBox();
            this.LblTelefonoMovil = new System.Windows.Forms.Label();
            this.LblNombreDestinatario = new System.Windows.Forms.Label();
            this.LblTelefonoDestinatario = new System.Windows.Forms.Label();
            this.TxtNombreDestinatario = new System.Windows.Forms.TextBox();
            this.TxtTelefonoDestinatario = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.LblDireccion = new System.Windows.Forms.Label();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.barraBotonesCrud1 = new Controles.WinForms.BarraBotonesCrud();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.LblBusqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // LblIdentificacion
            // 
            this.LblIdentificacion.AutoSize = true;
            this.LblIdentificacion.Location = new System.Drawing.Point(12, 15);
            this.LblIdentificacion.Name = "LblIdentificacion";
            this.LblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.LblIdentificacion.TabIndex = 0;
            this.LblIdentificacion.Text = "Identificación";
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.Enabled = false;
            this.TxtIdentificacion.Location = new System.Drawing.Point(131, 12);
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(173, 20);
            this.TxtIdentificacion.TabIndex = 1;
            this.TxtIdentificacion.Text = "1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TxtNombres
            // 
            this.TxtNombres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtNombres.Enabled = false;
            this.TxtNombres.Location = new System.Drawing.Point(131, 38);
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.Size = new System.Drawing.Size(173, 20);
            this.TxtNombres.TabIndex = 2;
            // 
            // LblNombres
            // 
            this.LblNombres.AutoSize = true;
            this.LblNombres.Location = new System.Drawing.Point(12, 41);
            this.LblNombres.Name = "LblNombres";
            this.LblNombres.Size = new System.Drawing.Size(49, 13);
            this.LblNombres.TabIndex = 3;
            this.LblNombres.Text = "Nombres";
            // 
            // LblApellidos
            // 
            this.LblApellidos.AutoSize = true;
            this.LblApellidos.Location = new System.Drawing.Point(12, 67);
            this.LblApellidos.Name = "LblApellidos";
            this.LblApellidos.Size = new System.Drawing.Size(49, 13);
            this.LblApellidos.TabIndex = 4;
            this.LblApellidos.Text = "Apellidos";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.Enabled = false;
            this.TxtApellidos.Location = new System.Drawing.Point(131, 64);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(173, 20);
            this.TxtApellidos.TabIndex = 5;
            // 
            // ucPaisDepartamentoCiudad1
            // 
            this.ucPaisDepartamentoCiudad1.Enabled = false;
            this.ucPaisDepartamentoCiudad1.Location = new System.Drawing.Point(129, 90);
            this.ucPaisDepartamentoCiudad1.Name = "ucPaisDepartamentoCiudad1";
            this.ucPaisDepartamentoCiudad1.Size = new System.Drawing.Size(175, 84);
            this.ucPaisDepartamentoCiudad1.TabIndex = 6;
            // 
            // LblPaís
            // 
            this.LblPaís.AutoSize = true;
            this.LblPaís.Location = new System.Drawing.Point(12, 98);
            this.LblPaís.Name = "LblPaís";
            this.LblPaís.Size = new System.Drawing.Size(29, 13);
            this.LblPaís.TabIndex = 7;
            this.LblPaís.Tag = "";
            this.LblPaís.Text = "País";
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Location = new System.Drawing.Point(12, 126);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(74, 13);
            this.LblDepartamento.TabIndex = 8;
            this.LblDepartamento.Text = "Departamento";
            // 
            // LblCiudad
            // 
            this.LblCiudad.AutoSize = true;
            this.LblCiudad.Location = new System.Drawing.Point(12, 156);
            this.LblCiudad.Name = "LblCiudad";
            this.LblCiudad.Size = new System.Drawing.Size(40, 13);
            this.LblCiudad.TabIndex = 9;
            this.LblCiudad.Text = "Ciudad";
            // 
            // LblCorreoElectronico
            // 
            this.LblCorreoElectronico.AutoSize = true;
            this.LblCorreoElectronico.Location = new System.Drawing.Point(359, 17);
            this.LblCorreoElectronico.Name = "LblCorreoElectronico";
            this.LblCorreoElectronico.Size = new System.Drawing.Size(94, 13);
            this.LblCorreoElectronico.TabIndex = 10;
            this.LblCorreoElectronico.Text = "Correo Electrónico";
            // 
            // TxtCorreoElectronico
            // 
            this.TxtCorreoElectronico.Enabled = false;
            this.TxtCorreoElectronico.Location = new System.Drawing.Point(478, 12);
            this.TxtCorreoElectronico.Name = "TxtCorreoElectronico";
            this.TxtCorreoElectronico.Size = new System.Drawing.Size(173, 20);
            this.TxtCorreoElectronico.TabIndex = 11;
            // 
            // LblContraseña
            // 
            this.LblContraseña.AutoSize = true;
            this.LblContraseña.Location = new System.Drawing.Point(359, 46);
            this.LblContraseña.Name = "LblContraseña";
            this.LblContraseña.Size = new System.Drawing.Size(61, 13);
            this.LblContraseña.TabIndex = 12;
            this.LblContraseña.Text = "Contraseña";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.Enabled = false;
            this.TxtContraseña.Location = new System.Drawing.Point(478, 38);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Size = new System.Drawing.Size(173, 20);
            this.TxtContraseña.TabIndex = 13;
            // 
            // LblRepetirContrasena
            // 
            this.LblRepetirContrasena.AutoSize = true;
            this.LblRepetirContrasena.Location = new System.Drawing.Point(359, 71);
            this.LblRepetirContrasena.Name = "LblRepetirContrasena";
            this.LblRepetirContrasena.Size = new System.Drawing.Size(98, 13);
            this.LblRepetirContrasena.TabIndex = 14;
            this.LblRepetirContrasena.Text = "Repetir Contraseña";
            // 
            // TxtRepetirContrasena
            // 
            this.TxtRepetirContrasena.Enabled = false;
            this.TxtRepetirContrasena.Location = new System.Drawing.Point(478, 64);
            this.TxtRepetirContrasena.Name = "TxtRepetirContrasena";
            this.TxtRepetirContrasena.Size = new System.Drawing.Size(173, 20);
            this.TxtRepetirContrasena.TabIndex = 15;
            // 
            // LblTelefonoFijo
            // 
            this.LblTelefonoFijo.AutoSize = true;
            this.LblTelefonoFijo.Location = new System.Drawing.Point(359, 93);
            this.LblTelefonoFijo.Name = "LblTelefonoFijo";
            this.LblTelefonoFijo.Size = new System.Drawing.Size(68, 13);
            this.LblTelefonoFijo.TabIndex = 16;
            this.LblTelefonoFijo.Text = "Teléfono Fijo";
            // 
            // TxtTelefonoFijo
            // 
            this.TxtTelefonoFijo.Enabled = false;
            this.TxtTelefonoFijo.Location = new System.Drawing.Point(478, 90);
            this.TxtTelefonoFijo.Name = "TxtTelefonoFijo";
            this.TxtTelefonoFijo.Size = new System.Drawing.Size(173, 20);
            this.TxtTelefonoFijo.TabIndex = 17;
            // 
            // TxtTelefonoMovil
            // 
            this.TxtTelefonoMovil.Enabled = false;
            this.TxtTelefonoMovil.Location = new System.Drawing.Point(478, 116);
            this.TxtTelefonoMovil.Name = "TxtTelefonoMovil";
            this.TxtTelefonoMovil.Size = new System.Drawing.Size(173, 20);
            this.TxtTelefonoMovil.TabIndex = 18;
            // 
            // LblTelefonoMovil
            // 
            this.LblTelefonoMovil.AutoSize = true;
            this.LblTelefonoMovil.Location = new System.Drawing.Point(359, 119);
            this.LblTelefonoMovil.Name = "LblTelefonoMovil";
            this.LblTelefonoMovil.Size = new System.Drawing.Size(77, 13);
            this.LblTelefonoMovil.TabIndex = 19;
            this.LblTelefonoMovil.Text = "Telefono Móvil";
            // 
            // LblNombreDestinatario
            // 
            this.LblNombreDestinatario.AutoSize = true;
            this.LblNombreDestinatario.Location = new System.Drawing.Point(359, 145);
            this.LblNombreDestinatario.Name = "LblNombreDestinatario";
            this.LblNombreDestinatario.Size = new System.Drawing.Size(103, 13);
            this.LblNombreDestinatario.TabIndex = 20;
            this.LblNombreDestinatario.Text = "Nombre Destinatario";
            // 
            // LblTelefonoDestinatario
            // 
            this.LblTelefonoDestinatario.AutoSize = true;
            this.LblTelefonoDestinatario.Location = new System.Drawing.Point(359, 171);
            this.LblTelefonoDestinatario.Name = "LblTelefonoDestinatario";
            this.LblTelefonoDestinatario.Size = new System.Drawing.Size(108, 13);
            this.LblTelefonoDestinatario.TabIndex = 21;
            this.LblTelefonoDestinatario.Text = "Teléfono Destinatario";
            // 
            // TxtNombreDestinatario
            // 
            this.TxtNombreDestinatario.Enabled = false;
            this.TxtNombreDestinatario.Location = new System.Drawing.Point(478, 142);
            this.TxtNombreDestinatario.Name = "TxtNombreDestinatario";
            this.TxtNombreDestinatario.Size = new System.Drawing.Size(173, 20);
            this.TxtNombreDestinatario.TabIndex = 22;
            // 
            // TxtTelefonoDestinatario
            // 
            this.TxtTelefonoDestinatario.Enabled = false;
            this.TxtTelefonoDestinatario.Location = new System.Drawing.Point(478, 168);
            this.TxtTelefonoDestinatario.Name = "TxtTelefonoDestinatario";
            this.TxtTelefonoDestinatario.Size = new System.Drawing.Size(173, 20);
            this.TxtTelefonoDestinatario.TabIndex = 23;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Location = new System.Drawing.Point(131, 180);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(173, 20);
            this.TxtDireccion.TabIndex = 24;
            // 
            // LblDireccion
            // 
            this.LblDireccion.AutoSize = true;
            this.LblDireccion.Location = new System.Drawing.Point(12, 183);
            this.LblDireccion.Name = "LblDireccion";
            this.LblDireccion.Size = new System.Drawing.Size(52, 13);
            this.LblDireccion.TabIndex = 25;
            this.LblDireccion.Text = "Direccion";
            // 
            // DgvClientes
            // 
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Location = new System.Drawing.Point(15, 267);
            this.DgvClientes.MultiSelect = false;
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClientes.Size = new System.Drawing.Size(636, 150);
            this.DgvClientes.TabIndex = 26;
            this.DgvClientes.SelectionChanged += new System.EventHandler(this.DgvClientes_SelectionChanged);
            // 
            // barraBotonesCrud1
            // 
            this.barraBotonesCrud1.Location = new System.Drawing.Point(157, 438);
            this.barraBotonesCrud1.Name = "barraBotonesCrud1";
            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCrud1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCrud1.TabIndex = 27;
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(131, 206);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(520, 20);
            this.TxtBusqueda.TabIndex = 28;
            // 
            // LblBusqueda
            // 
            this.LblBusqueda.AutoSize = true;
            this.LblBusqueda.Location = new System.Drawing.Point(12, 209);
            this.LblBusqueda.Name = "LblBusqueda";
            this.LblBusqueda.Size = new System.Drawing.Size(40, 13);
            this.LblBusqueda.TabIndex = 29;
            this.LblBusqueda.Text = "Buscar";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 477);
            this.Controls.Add(this.LblBusqueda);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.barraBotonesCrud1);
            this.Controls.Add(this.DgvClientes);
            this.Controls.Add(this.LblDireccion);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.TxtTelefonoDestinatario);
            this.Controls.Add(this.TxtNombreDestinatario);
            this.Controls.Add(this.LblTelefonoDestinatario);
            this.Controls.Add(this.LblNombreDestinatario);
            this.Controls.Add(this.LblTelefonoMovil);
            this.Controls.Add(this.TxtTelefonoMovil);
            this.Controls.Add(this.TxtTelefonoFijo);
            this.Controls.Add(this.LblTelefonoFijo);
            this.Controls.Add(this.TxtRepetirContrasena);
            this.Controls.Add(this.LblRepetirContrasena);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.LblContraseña);
            this.Controls.Add(this.TxtCorreoElectronico);
            this.Controls.Add(this.LblCorreoElectronico);
            this.Controls.Add(this.LblCiudad);
            this.Controls.Add(this.LblDepartamento);
            this.Controls.Add(this.LblPaís);
            this.Controls.Add(this.ucPaisDepartamentoCiudad1);
            this.Controls.Add(this.TxtApellidos);
            this.Controls.Add(this.LblApellidos);
            this.Controls.Add(this.LblNombres);
            this.Controls.Add(this.TxtNombres);
            this.Controls.Add(this.TxtIdentificacion);
            this.Controls.Add(this.LblIdentificacion);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblIdentificacion;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox TxtNombres;
        private System.Windows.Forms.Label LblNombres;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.Label LblApellidos;
        private System.Windows.Forms.Label LblCiudad;
        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.Label LblPaís;
        private Controles.WinForms.UcPaisDepartamentoCiudad ucPaisDepartamentoCiudad1;
        private System.Windows.Forms.Label LblTelefonoMovil;
        private System.Windows.Forms.TextBox TxtTelefonoMovil;
        private System.Windows.Forms.TextBox TxtTelefonoFijo;
        private System.Windows.Forms.Label LblTelefonoFijo;
        private System.Windows.Forms.TextBox TxtRepetirContrasena;
        private System.Windows.Forms.Label LblRepetirContrasena;
        private System.Windows.Forms.TextBox TxtContraseña;
        private System.Windows.Forms.Label LblContraseña;
        private System.Windows.Forms.TextBox TxtCorreoElectronico;
        private System.Windows.Forms.Label LblCorreoElectronico;
        private System.Windows.Forms.TextBox TxtTelefonoDestinatario;
        private System.Windows.Forms.TextBox TxtNombreDestinatario;
        private System.Windows.Forms.Label LblTelefonoDestinatario;
        private System.Windows.Forms.Label LblNombreDestinatario;
        private System.Windows.Forms.Label LblDireccion;
        private System.Windows.Forms.TextBox TxtDireccion;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCrud1;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label LblBusqueda;
    }
}