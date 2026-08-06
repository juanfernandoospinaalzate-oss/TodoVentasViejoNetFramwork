// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------
namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de presentación artículo en la base de datos por operaciones CRUD
    /// </summary>
    public partial class PresentacionArticulo : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public PresentacionArticulo()
        {
            this.InitializeComponent();
        }

        int IdArticulo = 0;

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void PresentacionArticulo_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0066");
            this.LblCodigoColor.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0067");
            this.LblCodTalla.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0068");
            this.BtnShowColorDialog.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0069");
            this.LblUndVolumen.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0070");
            this.LblUndMasa.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0071");
            this.LblUndLongitud.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0072");
            this.LblCodigoArticulo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0073");
            this.LblDescripcion.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0074");
            this.LblImagen6.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0075");
            this.LblImagen5.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0076");
            this.LblImagen4.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0077");
            this.LblImagen3.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0078");
            this.LblImagen2.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0079");
            this.LblImagen1.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0080");
            // this.IdArticulo.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0081");
            // this.IdColor.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0082");
            // this.IdTalla.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0083");
            // this.UnidadVolumen.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0084");
            // this.UnidadMasa.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0085");
            // this.UnidadLongitud.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0086");
            // this.BreveDescripcion.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0097");
            this.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0190");
            this.LblNombre.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0191");
            this.LblContenidoVolumetrico.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0192");
            this.LblSabor.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0193");
            this.LblExistencias.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0194");
            this.LblPrecio.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0195");
            this.LblCostoArticulo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0196");
            this.LblFechaIngreso.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0197");
            this.ChkEnLinea.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0198");
            this.ChkActivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0199");
            this.RbActivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0200");
            this.RbInactivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0201");
            this.RbTodos.Text = etiqueta.Texto;

            Fachada.TablasMaestras.UnidadVolumen unidadesVolumen = new Fachada.TablasMaestras.UnidadVolumen();
            this.CmbUnidadVolumen.DataSource = unidadesVolumen.Listar();
            this.CmbUnidadVolumen.DisplayMember = "Nombre";
            this.CmbUnidadVolumen.ValueMember = "IdUnidadVolumen";

            Fachada.TablasMaestras.UnidadMasa unidadesMasa = new Fachada.TablasMaestras.UnidadMasa();
            this.CmbUnidadMasa.DataSource = unidadesMasa.Listar();
            this.CmbUnidadMasa.DisplayMember = "Nombre";
            this.CmbUnidadMasa.ValueMember = "IdUnidadMasa";

            Fachada.TablasMaestras.UnidadLongitud unidadesLongitud = new Fachada.TablasMaestras.UnidadLongitud();
            this.CmbUnidadLongitud.DataSource = unidadesLongitud.Listar();
            this.CmbUnidadLongitud.DisplayMember = "Nombre";
            this.CmbUnidadLongitud.ValueMember = "IdUnidadLongitud";

            Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
            this.CmbTalla.DataSource = tallas.Listar();
            this.CmbTalla.DisplayMember = "Nombre";
            this.CmbTalla.ValueMember = "IdTalla";

            Fachada.TablasMaestras.Sabor Sabor = new Fachada.TablasMaestras.Sabor();
            this.CmbSabor.DataSource = Sabor.Listar();
            this.CmbSabor.DisplayMember = "Nombre";
            this.CmbSabor.ValueMember = "IdSabor";

            Fachada.TablasMaestras.UnidadPresentacion unidadPresentacion = new Fachada.TablasMaestras.UnidadPresentacion();
            this.CmbUnidadPresentacion.DataSource = unidadPresentacion.Listar();
            this.CmbUnidadPresentacion.DisplayMember = "Nombre";
            this.CmbUnidadPresentacion.ValueMember = "IdUnidadPresentacion";

            // Deshabilitar los controles predeterminadamente, manteniendo el IdArticulo intacto
            int.TryParse(this.TxtIdArticulo.Text.ToString(), out this.IdArticulo);
            barraBotonesCRUD1.BotonCancelar.PerformClick();
            this.RbActivo.Enabled = true;
            this.RbInactivo.Enabled = true;
            this.RbTodos.Enabled = true;

            Fachada.TablasMaestras.PresentacionArticulo Presentacion = new Fachada.TablasMaestras.PresentacionArticulo();

            this.DgvPresentacionArticulo.DataSource = Presentacion.Listar(this.IdArticulo);

            if (DgvPresentacionArticulo.Columns.Count > 0)
            {
                this.DgvPresentacionArticulo.Columns[0].Visible = false; // IdPresentacionArticulo
                this.DgvPresentacionArticulo.Columns[1].Visible = false; // IdArticulo
                this.DgvPresentacionArticulo.Columns[2].Visible = false; // CodigoEAN
                this.DgvPresentacionArticulo.Columns[3].Width = 300; // Nombre
                this.DgvPresentacionArticulo.Columns[4].Visible = false; // DescripciónBreve
                this.DgvPresentacionArticulo.Columns[5].Visible = false; // Color
                this.DgvPresentacionArticulo.Columns[6].Visible = false; // Talla
                this.DgvPresentacionArticulo.Columns[7].Visible = false; // Imagen1
                this.DgvPresentacionArticulo.Columns[8].Visible = false; // Imagen2
                this.DgvPresentacionArticulo.Columns[9].Visible = false; // Imagen3
                this.DgvPresentacionArticulo.Columns[10].Visible = false; // Imagen4
                this.DgvPresentacionArticulo.Columns[11].Visible = false; // Imagen5
                this.DgvPresentacionArticulo.Columns[12].Visible = false; // Imagen6
                // this.DgvPresentacionArticulo.Columns[13].Visible = false; // Fecha
                this.DgvPresentacionArticulo.Columns[13].Width = 70;
                this.DgvPresentacionArticulo.Columns[14].Visible = false; // UnidadMasa
                this.DgvPresentacionArticulo.Columns[15].Visible = false; // VlrUnidadMasa
                this.DgvPresentacionArticulo.Columns[16].Visible = false; // UnidadVolumen
                this.DgvPresentacionArticulo.Columns[17].Visible = false; // VlrUnidadVolumenLargo
                this.DgvPresentacionArticulo.Columns[18].Visible = false; // VlrUnidadVolumenAncho
                this.DgvPresentacionArticulo.Columns[19].Visible = false; // VlrUnidadVolumenProfundidad
                this.DgvPresentacionArticulo.Columns[20].Visible = false; // VlrContenidoVolumetrico
                this.DgvPresentacionArticulo.Columns[21].Visible = false; // UnidadLongitud
                this.DgvPresentacionArticulo.Columns[22].Visible = false; // VlrUnidadLongitud
                // this.DgvPresentacionArticulo.Columns[23].Visible = false; // EnLinea
                this.DgvPresentacionArticulo.Columns[23].Width = 55;
                // this.DgvPresentacionArticulo.Columns[24].Visible = false; // Activo
                this.DgvPresentacionArticulo.Columns[24].Width = 55;
                // this.DgvPresentacionArticulo.Columns[25].Visible = false; // Precio
                this.DgvPresentacionArticulo.Columns[25].DefaultCellStyle.Format = "c"; // Mostrar en formato de moneda de manera predeterminada
                this.DgvPresentacionArticulo.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alinear contenido a la derecha
                this.DgvPresentacionArticulo.Columns[25].Width = 65;
                // this.DgvPresentacionArticulo.Columns[26].Visible = false; // Existencias 
                this.DgvPresentacionArticulo.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DgvPresentacionArticulo.Columns[26].Width = 65;
                this.DgvPresentacionArticulo.Columns[27].Visible = false; // Sabor
                // this.DgvPresentacionArticulo.Columns[28].Visible = false; // CostoArtículo
                this.DgvPresentacionArticulo.Columns[28].DefaultCellStyle.Format = "c"; // Mostrar en formato de moneda de manera predeterminada
                this.DgvPresentacionArticulo.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alinear contenido a la derecha
                this.DgvPresentacionArticulo.Columns[28].Width = 70;
                // this.DgvPresentacionArticulo.Columns[29].Visible = false; // Preorden
                this.DgvPresentacionArticulo.Columns[29].Width = 65;
                this.DgvPresentacionArticulo.Columns[30].Visible = false; // IdUnidadPresentacion
                this.DgvPresentacionArticulo.Columns[31].Visible = false; // VlrUnidadPresentacion
                this.DgvPresentacionArticulo.Columns[32].Visible = false; // FechaProximoVencimiento
                // this.DgvPresentacionArticulo.Columns[33].Visible = false; // UsarFechaProximoVencimiento
                this.DgvPresentacionArticulo.Columns[33].Width = 70;
                // this.DgvPresentacionArticulo.Columns[34].Visible = false; // UsarDescuento
                this.DgvPresentacionArticulo.Columns[34].Width = 90;
                this.DgvPresentacionArticulo.Columns[35].Visible = false;
                this.DgvPresentacionArticulo.Columns[36].Visible = false;
                this.DgvPresentacionArticulo.Columns[37].Visible = false;
                this.DgvPresentacionArticulo.Columns[38].Visible = false;
                this.DgvPresentacionArticulo.Columns[39].Visible = false;
                this.DgvPresentacionArticulo.Columns[40].Visible = false;
            }

            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);
            this.barraBotonesCRUD1.BotonNuevo.Click += new EventHandler(this.BtnNuevo_Click);

            this.DgvPresentacionArticulo.Focus();
        }

        void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.TxtIdArticulo.Enabled = false;
            this.TxtIdArticulo.Text = this.IdArticulo.ToString();
            this.DesHabilitarTextboxColor();
            this.RbActivo.Enabled = false;
            this.RbInactivo.Enabled = false;
            this.RbTodos.Enabled = false;
            this.DgvPresentacionArticulo.Enabled = false;
            this.ucCargaImagenes1.BtnLimpiar_Click(null, null);
            this.ucCargaImagenes2.BtnLimpiar_Click(null, null);
            this.ucCargaImagenes3.BtnLimpiar_Click(null, null);
            this.ucCargaImagenes4.BtnLimpiar_Click(null, null);
            this.ucCargaImagenes5.BtnLimpiar_Click(null, null);
            this.ucCargaImagenes6.BtnLimpiar_Click(null, null);
            this.PbImagenPrincipalPresentacionArticulo.ImageLocation = string.Empty;
            this.DtpFechaProximoVencimiento.Value = DateTime.Now;
        #if Pruebas
            this.PrepararDatosDePrueba();
        #endif
        }

        /// <summary>
        /// Elimina una presentación artículo de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvPresentacionArticulo.SelectedRows.Count == 0)
            {
                return;
            }

            // Si el usuario confirmó la intención de elminar
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.PresentacionArticulo Presentacion = new Fachada.TablasMaestras.PresentacionArticulo();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idPresentacionArticulo = int.Parse(DgvPresentacionArticulo.SelectedRows[0].Cells[0].Value.ToString());
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Presentacion.Eliminar(idPresentacionArticulo);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                // this.DgvPresentacionArticulo.Enabled = false;
                // barraBotonesCRUD1.BotonNuevo.Enabled = true;
                // barraBotonesCRUD1.BotonEditar.Enabled = true;
                // barraBotonesCRUD1.BotonGuardar.Enabled = false;
                // barraBotonesCRUD1.BotonEliminar.Enabled = true;
                barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
                this.DgvPresentacionArticulo.DataSource = Presentacion.Listar(this.IdArticulo);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.DgvPresentacionArticulo.SelectedRows.Count == 0)
            {
                this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                return;
            }

            this.DgvPresentacionArticulo.Enabled = false;
            this.TxtIdArticulo.Enabled = false;
            this.DesHabilitarTextboxColor();
            this.RbActivo.Enabled = false;
            this.RbInactivo.Enabled = false;
            this.RbTodos.Enabled = false;
        }

        /// <summary>
        /// Cancela cualquier operación de inserción y edición en curso.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DgvPresentacionArticulo.Enabled = true;
            this.TxtColor.Tag = null;
            this.RbActivo.Enabled = true;
            this.RbInactivo.Enabled = true;
            this.RbTodos.Enabled = true;
            if (this.DgvPresentacionArticulo.Rows.Count > 0)
            {
                this.DgvPresentacionArticulo.Rows[0].Selected = false; // Evita el bug de vaciar las casillas si hay solo una fila en el grid
                this.DgvPresentacionArticulo.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// Inserta los datos nuevos en modo de edición, o guarda los datos modificados en modo edición
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumento para el evento</param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticulo FachadaPresentacion = null;
            Entidades.PresentacionArticulo presentacion = new Entidades.PresentacionArticulo();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            Entidades.Kardex RegistroKardex = new Entidades.Kardex();

            this.errorProvider1.Clear();

            if (this.TxtIdArticulo.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0036");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtIdArticulo, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.TxtNombre.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0038");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtNombre, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtCodigoEAN.Text = this.TxtCodigoEAN.Text.Trim();
            if (this.TxtCodigoEAN.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0037");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtCodigoEAN, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            // Validar la selección de Color, si no se ha seleccionado un color usar el valor predeterminado "sin color" con identificación de color 1

            if (this.TxtColor.Tag == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0043");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.BtnShowColorDialog, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.CmbTalla.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0039");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbTalla, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            // Valida solo la selección de la lista desplegable
            if (this.CmbUnidadVolumen.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0040");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbUnidadVolumen, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            // Si no hay un valor de contenido volumetrico, se guarda un cero
            float contenidoVolumetrico = float.MinValue;
            if (float.TryParse(this.TxtValorContenidoVolumetrico.Text, out contenidoVolumetrico) == false)
            {
                if (contenidoVolumetrico == 0)
                {
                    this.TxtValorContenidoVolumetrico.Text = contenidoVolumetrico.ToString();
                }
            }

            // Valída solo la selección de la lista desplegable
            if (this.CmbUnidadMasa.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0041");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbUnidadMasa, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            // Si no hay un valor de Masa (Peso), se guarda un cero
            double valorMasa = double.MinValue;
            if (double.TryParse(this.TxtValorMasa.Text, out valorMasa) == false)
            {
                if (valorMasa == 0)
                {
                    this.TxtValorMasa.Text = valorMasa.ToString();
                }
            }

            // valída solo la selección de la lista desplegable
            if (this.CmbUnidadLongitud.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0042");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbUnidadLongitud, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double valorLongitud = double.MinValue;
            if (double.TryParse(this.TxtValorLongitud.Text, out valorLongitud) == false)
            {
                if (valorLongitud == 0)
                {
                    this.TxtValorLongitud.Text = valorLongitud.ToString();
                }
            }

            // valída solo la selección de la lista desplegable
            if (this.CmbUnidadPresentacion.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0053");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbUnidadPresentacion, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double valorUnidadPresentacion = double.MinValue;
            if (double.TryParse(this.TxtValorUnidadPresentacion.Text, out valorUnidadPresentacion) == false)
            {
                if (valorUnidadPresentacion == 0)
                {
                    this.TxtValorUnidadPresentacion.Text = valorUnidadPresentacion.ToString();
                }
            }

            if (this.CmbSabor.SelectedItem == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0044");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.CmbSabor, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtDescripcion.Text = this.TxtDescripcion.Text.Trim();
            if (this.TxtDescripcion.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0045");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtDescripcion, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double valorVolumenLargo = double.MinValue;
            if (double.TryParse(this.TxtUndVolumenLargo.Text, out valorVolumenLargo) == false)
            {
                if (valorVolumenLargo == 0)
                {
                    this.TxtUndVolumenLargo.Text = valorVolumenLargo.ToString();
                }
            }

            double valorVolumenAncho = double.MinValue;
            if (double.TryParse(this.TxtUndVolumenAncho.Text, out valorVolumenAncho) == false)
            {
                if (valorVolumenAncho == 0)
                {
                    this.TxtUndVolumenAncho.Text = valorVolumenAncho.ToString();
                }
            }

            double valorVolumenProfundidad = double.MinValue;
            if (double.TryParse(this.TxtUndVolumenProfundidad.Text, out valorVolumenProfundidad) == false)
            {
                if (valorVolumenProfundidad == 0)
                {
                    this.TxtUndVolumenProfundidad.Text = valorVolumenProfundidad.ToString();
                }
            }

            if (System.IO.File.Exists(this.ucCargaImagenes1.LblUrlimagenes.Text))
            {
                presentacion.Imagen1 = System.IO.File.ReadAllBytes(this.ucCargaImagenes1.LblUrlimagenes.Text);
            }

            if (System.IO.File.Exists(this.ucCargaImagenes2.LblUrlimagenes.Text))
            {
                presentacion.Imagen2 = System.IO.File.ReadAllBytes(this.ucCargaImagenes2.LblUrlimagenes.Text);
            }

            if (System.IO.File.Exists(this.ucCargaImagenes3.LblUrlimagenes.Text))
            {
                presentacion.Imagen3 = System.IO.File.ReadAllBytes(this.ucCargaImagenes3.LblUrlimagenes.Text);
            }

            if (System.IO.File.Exists(this.ucCargaImagenes4.LblUrlimagenes.Text))
            {
                presentacion.Imagen4 = System.IO.File.ReadAllBytes(this.ucCargaImagenes4.LblUrlimagenes.Text);
            }

            if (System.IO.File.Exists(this.ucCargaImagenes5.LblUrlimagenes.Text))
            {
                presentacion.Imagen5 = System.IO.File.ReadAllBytes(this.ucCargaImagenes5.LblUrlimagenes.Text);
            }

            if (System.IO.File.Exists(this.ucCargaImagenes6.LblUrlimagenes.Text))
            {
                presentacion.Imagen6 = System.IO.File.ReadAllBytes(this.ucCargaImagenes6.LblUrlimagenes.Text);
            }

            this.TxtExistencias.Text = this.TxtExistencias.Text.Trim();
            if (this.TxtExistencias.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0046");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtExistencias, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            int Existencias = int.MinValue;
            bool ResultadoConversion = int.TryParse(this.TxtExistencias.Text, out Existencias);
            if (ResultadoConversion == false || Existencias < 0)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0047");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtExistencias, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtPrecio.Text = this.TxtPrecio.Text.Trim();
            if (TxtPrecio.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0048");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtPrecio, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double valorPrecio = double.MinValue;
            if (double.TryParse(this.TxtPrecio.Text, out valorPrecio) == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0049");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtPrecio, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtCostoArticulo.Text = this.TxtCostoArticulo.Text.Trim();
            if (this.TxtCostoArticulo.Text == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0050");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtCostoArticulo, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double valorCostoArticulo = double.MinValue;
            if (double.TryParse(this.TxtCostoArticulo.Text, out valorCostoArticulo) == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0051");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.errorProvider1.SetError(this.TxtCostoArticulo, resultadoTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.TxtCodigoEAN.Text.Length > 18)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0096");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.TxtNombre.Text.Length > 100)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0097");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            double ValorPorcentajeDescuento = double.MinValue;
            if (double.TryParse(this.TxtValorPorcentajeDescuento.Text, out ValorPorcentajeDescuento) == false)
            {
                if (ValorPorcentajeDescuento == 0)
                {
                    this.TxtValorPorcentajeDescuento.Text = ValorPorcentajeDescuento.ToString();
                }
            }

            double ValorFijoDescuento = double.MinValue;
            if (double.TryParse(TxtValorFijoDescuento.Text, out ValorFijoDescuento) == false)
            {
                if (ValorFijoDescuento == 0)
                {
                    this.TxtValorFijoDescuento.Text = ValorFijoDescuento.ToString();
                }
            }

            if (this.DgvPresentacionArticulo.SelectedRows.Count > 0)
            {
                presentacion.IdPresentacionArticulo = int.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[0].Value.ToString());
            }

            presentacion.Articulo.IdArticulo = int.Parse(this.TxtIdArticulo.Text);
            presentacion.Nombre = this.TxtNombre.Text;
            presentacion.CodigoEAN = this.TxtCodigoEAN.Text;
            presentacion.Color = this.TxtColor.Tag as Entidades.Color;
            presentacion.Talla = this.CmbTalla.SelectedItem as Entidades.Talla;
            presentacion.Fecha = System.DateTime.Now;
            presentacion.UnidadVolumen = this.CmbUnidadVolumen.SelectedItem as Entidades.UnidadVolumen;
            presentacion.VlrContenidoVolumetrico = double.Parse(this.TxtValorContenidoVolumetrico.Text);
            presentacion.UnidadMasa = this.CmbUnidadMasa.SelectedItem as Entidades.UnidadMasa;
            presentacion.VlrUnidadMasa = double.Parse(this.TxtValorMasa.Text);
            presentacion.UnidadLongitud = this.CmbUnidadLongitud.SelectedItem as Entidades.UnidadLongitud;
            presentacion.VlrUnidadLongitud = double.Parse(this.TxtValorLongitud.Text);
            presentacion.Sabor = CmbSabor.SelectedItem as Entidades.Sabor;
            presentacion.DescripcionBreve = this.TxtDescripcion.Text;
            presentacion.VlrUnidadVolumenLargo = double.Parse(this.TxtUndVolumenLargo.Text);
            presentacion.VlrUnidadVolumenAncho = double.Parse(this.TxtUndVolumenAncho.Text);
            presentacion.VlrUnidadVolumenProfundidad = double.Parse(this.TxtUndVolumenProfundidad.Text);
            presentacion.EnLinea = ChkEnLinea.Checked;
            presentacion.Activo = ChkActivo.Checked;
            presentacion.PreOrden = ChkPreorden.Checked;
            presentacion.Existencias = int.Parse(this.TxtExistencias.Text);
            presentacion.Precio = double.Parse(this.TxtPrecio.Text);
            presentacion.CostoArticulo = double.Parse(this.TxtCostoArticulo.Text);
            presentacion.UnidadPresentacion = this.CmbUnidadPresentacion.SelectedItem as Entidades.UnidadPresentacion;
            presentacion.VlrUnidadPresentacion = double.Parse(this.TxtValorUnidadPresentacion.Text);
            presentacion.FechaProximoVencimiento = this.DtpFechaProximoVencimiento.Value;
            presentacion.UsarFechaProximoVencimiento = this.ChkUsarFechaProximoVencimiento.Checked;
            presentacion.UsarDescuento = this.ChkUsarDescuento.Checked;
            presentacion.UsarPorcentajeDescuento = this.RbUsarPorcentajeDescuento.Checked;
            presentacion.ValorPorcentajeDescuento = double.Parse(this.TxtValorPorcentajeDescuento.Text);
            presentacion.UsarValorFijoDescuento = this.RbUsarValorFijoDescuento.Checked;
            presentacion.ValorFijoDescuento = double.Parse(this.TxtValorFijoDescuento.Text);
            presentacion.FechaInicioDescuento = this.DtpFechaInicioDescuento.Value;
            presentacion.FechaFinalDescuento = this.DtpFechaFinalDescuento.Value;

            RegistroKardex.IdPresentacionArticulo = presentacion.IdPresentacionArticulo;
            RegistroKardex.CostoUnitario = presentacion.CostoArticulo;
            RegistroKardex.PrecioUnitario = presentacion.Precio;
            RegistroKardex.TotalExistencias = presentacion.Existencias;
            RegistroKardex.CostoTotal = presentacion.CostoArticulo * presentacion.Existencias;
            RegistroKardex.PrecioTotal = presentacion.Precio * presentacion.Existencias;
            RegistroKardex.Fecha = DateTime.Now;
            RegistroKardex.Nombre = presentacion.Nombre;

            FachadaPresentacion = new Fachada.TablasMaestras.PresentacionArticulo();
            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                RegistroKardex.Detalle = "Presentación de Artículo Nuevo desde Pantalla Presentación de Artículo";
                resultadoTransaccion = FachadaPresentacion.Insertar(presentacion, RegistroKardex);

                // Los dos Registros afectados son en PresentacionArticulo y Kardex
                if (resultadoTransaccion.RegistrosAfectados == 2) 
                {
                    this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                    this.DgvPresentacionArticulo.DataSource = FachadaPresentacion.Listar(presentacion.Articulo.IdArticulo);
                }
                else
                {
                    this.ResetearBotonesOperacionGuardar();
                }

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    System.DateTime dt; // En la inserción se usa la fecha del sistema, en actualización se usala fecha ya guardada
                    System.DateTime.TryParse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[13].Value.ToString(), out dt);
                    presentacion.Fecha = dt;
                    int ExistenciasAntesDeActualizar = int.MinValue;
                    int.TryParse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[26].Value.ToString(), out ExistenciasAntesDeActualizar);

                    // Determinar si hubo un incremento en existencias
                    if (ExistenciasAntesDeActualizar < presentacion.Existencias)
                    {
                        RegistroKardex.CantidadEntrada = presentacion.Existencias - ExistenciasAntesDeActualizar;
                    }

                    // Determinar si hubo salida de datos
                    if (ExistenciasAntesDeActualizar > presentacion.Existencias)
                    {
                        RegistroKardex.CantidadSalida = ExistenciasAntesDeActualizar - presentacion.Existencias;
                    }

                    RegistroKardex.Detalle = "Actualización desde Pantalla Presentación de Artículo";
                    resultadoTransaccion = FachadaPresentacion.Actualizar(presentacion, RegistroKardex);

                    // Los dos Registros afectados son en PresentacionArticulo y Kardex
                    if (resultadoTransaccion.RegistrosAfectados == 2) 
                    {
                        this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                        this.DgvPresentacionArticulo.DataSource = FachadaPresentacion.Listar(presentacion.Articulo.IdArticulo);
                    }
                    else
                    {
                        this.ResetearBotonesOperacionGuardar();
                    }

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
        }

        private void ResetearBotonesOperacionGuardar()
        {
            this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
            this.barraBotonesCRUD1.BotonEditar.Enabled = false;
            this.barraBotonesCRUD1.BotonGuardar.Enabled = true;
            this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
        }

        /// <summary>
        /// Deshabilita los Textbox que muestran las características de color para la presentación artículo
        /// </summary>
        private void DesHabilitarTextboxColor()
        {
            this.TxtCodigoColor.Enabled = false;
            this.TxtColor.Enabled = false;
            this.TxtColor.BackColor = System.Drawing.Color.White;
            this.TxtNombreColor.Enabled = false;
        }

        private void DgvPresentacionArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DgvPresentacionArticulo.SelectedRows.Count == 0)
            {
                return;
            }

            string rutaTemporal = System.IO.Path.GetTempPath();
            int idPresentacionArticulo = int.Parse(DgvPresentacionArticulo.SelectedRows[0].Cells[0].Value.ToString());

            this.ucCargaImagenes1.LblUrlimagenes.Text = string.Empty;
            this.ucCargaImagenes2.LblUrlimagenes.Text = string.Empty;
            this.ucCargaImagenes3.LblUrlimagenes.Text = string.Empty;
            this.ucCargaImagenes4.LblUrlimagenes.Text = string.Empty;
            this.ucCargaImagenes5.LblUrlimagenes.Text = string.Empty;
            this.ucCargaImagenes6.LblUrlimagenes.Text = string.Empty;

            this.ucCargaImagenes1.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.ucCargaImagenes2.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.ucCargaImagenes3.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.ucCargaImagenes4.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.ucCargaImagenes5.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.ucCargaImagenes6.PbVistaPreviaImagen.ImageLocation = string.Empty;
            this.PbImagenPrincipalPresentacionArticulo.ImageLocation = string.Empty;

            this.TxtIdArticulo.Text = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[1].Value as Entidades.Articulo).IdArticulo.ToString();
            this.TxtNombre.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[3].Value.ToString();
            this.TxtDescripcion.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[4].Value.ToString();
            this.TxtCodigoEAN.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[2].Value.ToString();

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[5].Value != null)
            {
                // Cargar los datos de color, código RGB, nombre y color visual
                Entidades.Color color = this.DgvPresentacionArticulo.SelectedRows[0].Cells[5].Value as Entidades.Color;
                this.TxtColor.Tag = color;
                this.TxtCodigoColor.Text = color.Codigo;
                this.TxtNombreColor.Text = color.Nombre;
                this.TxtColor.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + TxtCodigoColor.Text);
            }

            this.CmbTalla.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[6].Value as Entidades.Talla).IdTalla;

            if (DgvPresentacionArticulo.SelectedRows[0].Cells[7].Value != null)
            {
                ucCargaImagenes1.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "A.jpg";
                byte[] imagen = this.DgvPresentacionArticulo.SelectedRows[0].Cells[7].Value as byte[];

                if (System.IO.File.Exists(this.ucCargaImagenes1.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(this.ucCargaImagenes1.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes1.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                this.ucCargaImagenes1.PbVistaPreviaImagen.ImageLocation = this.ucCargaImagenes1.LblUrlimagenes.Text;
                this.PbImagenPrincipalPresentacionArticulo.ImageLocation = this.ucCargaImagenes1.LblUrlimagenes.Text;
            }

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[8].Value != null)
            {
                this.ucCargaImagenes2.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "B.jpg";
                byte[] imagen = DgvPresentacionArticulo.SelectedRows[0].Cells[8].Value as byte[];

                if (System.IO.File.Exists(this.ucCargaImagenes2.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(this.ucCargaImagenes2.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes2.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                this.ucCargaImagenes2.PbVistaPreviaImagen.ImageLocation = this.ucCargaImagenes2.LblUrlimagenes.Text;
            }

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[9].Value != null)
            {
                this.ucCargaImagenes3.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "C.jpg";
                byte[] imagen = this.DgvPresentacionArticulo.SelectedRows[0].Cells[9].Value as byte[];

                if (System.IO.File.Exists(this.ucCargaImagenes3.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(this.ucCargaImagenes3.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes3.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                this.ucCargaImagenes3.PbVistaPreviaImagen.ImageLocation = this.ucCargaImagenes3.LblUrlimagenes.Text;
            }

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[10].Value != null)
            {
                ucCargaImagenes4.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "D.jpg";
                byte[] imagen = this.DgvPresentacionArticulo.SelectedRows[0].Cells[10].Value as byte[];

                if (System.IO.File.Exists(ucCargaImagenes4.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(ucCargaImagenes4.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes4.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                this.ucCargaImagenes4.PbVistaPreviaImagen.ImageLocation = this.ucCargaImagenes4.LblUrlimagenes.Text;
            }

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[11].Value != null)
            {
                this.ucCargaImagenes5.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "E.jpg";
                byte[] imagen = this.DgvPresentacionArticulo.SelectedRows[0].Cells[11].Value as byte[];

                if (System.IO.File.Exists(ucCargaImagenes5.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(ucCargaImagenes5.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes5.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                ucCargaImagenes5.PbVistaPreviaImagen.ImageLocation = ucCargaImagenes5.LblUrlimagenes.Text;
            }

            if (this.DgvPresentacionArticulo.SelectedRows[0].Cells[12].Value != null)
            {
                this.ucCargaImagenes6.LblUrlimagenes.Text = rutaTemporal + idPresentacionArticulo + "E.jpg";
                byte[] imagen = this.DgvPresentacionArticulo.SelectedRows[0].Cells[12].Value as byte[];

                if (System.IO.File.Exists(this.ucCargaImagenes6.LblUrlimagenes.Text))
                {
                    System.IO.File.Delete(this.ucCargaImagenes6.LblUrlimagenes.Text);
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(this.ucCargaImagenes6.LblUrlimagenes.Text, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                this.ucCargaImagenes6.PbVistaPreviaImagen.ImageLocation = this.ucCargaImagenes6.LblUrlimagenes.Text;
            }

            this.TxtFechaIngreso.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[13].Value.ToString();
            this.CmbUnidadMasa.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[14].Value as Entidades.UnidadMasa).IdUnidadMasa;
            this.TxtValorMasa.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[15].Value.ToString();
            this.CmbUnidadVolumen.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[16].Value as Entidades.UnidadVolumen).IdUnidadVolumen;
            this.TxtUndVolumenAncho.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[17].Value.ToString();
            this.TxtUndVolumenLargo.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[18].Value.ToString();
            this.TxtUndVolumenProfundidad.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[19].Value.ToString();
            this.TxtValorContenidoVolumetrico.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[20].Value.ToString();
            this.CmbUnidadLongitud.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[21].Value as Entidades.UnidadLongitud).IdUnidadLongitud;
            this.TxtValorLongitud.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[22].Value.ToString();
            this.ChkEnLinea.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[23].Value.ToString());
            this.ChkActivo.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[24].Value.ToString());
            this.TxtPrecio.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[25].Value.ToString();
            this.TxtExistencias.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[26].Value.ToString();
            this.CmbSabor.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[27].Value as Entidades.Sabor).IdSabor;
            this.TxtCostoArticulo.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[28].Value.ToString();
            this.ChkPreorden.Checked = bool.Parse(DgvPresentacionArticulo.SelectedRows[0].Cells[29].Value.ToString());
            this.CmbUnidadPresentacion.SelectedValue = (this.DgvPresentacionArticulo.SelectedRows[0].Cells[30].Value as Entidades.UnidadPresentacion).IdUnidadPresentacion;
            this.TxtValorUnidadPresentacion.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[31].Value.ToString();
            this.DtpFechaProximoVencimiento.Value = DateTime.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[32].Value.ToString());
            this.ChkUsarFechaProximoVencimiento.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[33].Value.ToString());

            this.ChkUsarDescuento.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[34].Value.ToString());
            this.RbUsarPorcentajeDescuento.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[35].Value.ToString());
            this.TxtValorPorcentajeDescuento.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[36].Value.ToString();
            this.RbUsarValorFijoDescuento.Checked = bool.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[37].Value.ToString());
            this.TxtValorFijoDescuento.Text = this.DgvPresentacionArticulo.SelectedRows[0].Cells[38].Value.ToString();
            this.DtpFechaInicioDescuento.Value = DateTime.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[39].Value.ToString());
            this.DtpFechaFinalDescuento.Value = DateTime.Parse(this.DgvPresentacionArticulo.SelectedRows[0].Cells[40].Value.ToString());
        }

        private void BtnShowColorDialog_Click(object sender, EventArgs e)
        {
            Presentacion.Busquedas.Color formularioBusquedaColor = new Busquedas.Color();

            DialogResult resultado = formularioBusquedaColor.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                this.TxtCodigoColor.Text = formularioBusquedaColor.ColorSeleccionado.Codigo;
                this.TxtColor.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + formularioBusquedaColor.ColorSeleccionado.Codigo);
                this.TxtNombreColor.Text = formularioBusquedaColor.ColorSeleccionado.Nombre;
                this.TxtColor.Tag = formularioBusquedaColor.ColorSeleccionado;
            }
        }

        private void PrepararDatosDePrueba()
        {
            Entidades.PresentacionArticulo Presentacion = new Entidades.PresentacionArticulo()
            {
                Activo = true,
                Articulo = new Entidades.Articulo() { IdArticulo = 1 },
                CodigoEAN = "096619926626",
                Color = new Entidades.Color() { IdColor = 1, Nombre = "Color Falso", Codigo = "#FFFFFF" },
                CostoArticulo = 0,
                DescripcionBreve = "Aceite de pescado bla bla bla",
                EnLinea = true,
                Existencias = 0,
                Fecha = DateTime.Now,
                FechaFinalDescuento = DateTime.Now,
                FechaInicioDescuento = DateTime.Now,
                FechaProximoVencimiento = DateTime.Now,
                IdPresentacionArticulo = 1,
                Imagen1 = new byte[] { 1, 2, 3 },
                Imagen2 = new byte[] { 4, 5, 6 },
                Imagen3 = new byte[] { 7, 8, 9 },
                Imagen4 = new byte[] { 10, 11, 12 },
                Imagen5 = new byte[] { 13, 14, 15 },
                Imagen6 = new byte[] { 16, 17, 18 },
                Nombre = "Fish Oil Omega 3 Kirkland",
                Precio = 164000,
                PreOrden = true,
                Sabor = new Entidades.Sabor() { IdSabor = 1 },
                Talla = new Entidades.Talla() { IdTalla = 1 },
                UnidadLongitud = new Entidades.UnidadLongitud() { IdUnidadLongitud = 1 },
                UnidadMasa = new Entidades.UnidadMasa() { IdUnidadMasa = 1 },
                UnidadPresentacion = new Entidades.UnidadPresentacion() { IdUnidadPresentacion = 4 },
                UnidadVolumen = new Entidades.UnidadVolumen() { IdUnidadVolumen = 1 },
                UsarDescuento = false,
                UsarFechaProximoVencimiento = false,
                UsarPorcentajeDescuento = false,
                UsarValorFijoDescuento = false,
                ValorFijoDescuento = 0,
                ValorPorcentajeDescuento = 0,
                VlrContenidoVolumetrico = 0,
                VlrUnidadLongitud = 0,
                VlrUnidadMasa = 0,
                VlrUnidadPresentacion = 0,
                VlrUnidadVolumenAncho = 0,
                VlrUnidadVolumenLargo = 0,
                VlrUnidadVolumenProfundidad = 0
            };

            Entidades.Kardex Registrokardex = new Entidades.Kardex()
            {
                IdPresentacionArticulo = 1,
                CantidadEntrada = 0,
                CantidadSalida = 0,
                CostoUnitario = 5000,
                PrecioUnitario = 15000,
                TotalExistencias = 2,
                CostoTotal = 10000,
                PrecioTotal = 30000,
                Detalle = "Prueba Atomatizada",
                Fecha = DateTime.Now,
                Nombre = "Artículo de Prueba Automatizada"
            };

            this.TxtIdArticulo.Text = "1";
            this.TxtNombre.Text = Presentacion.Nombre;
            this.TxtDescripcion.Text = Presentacion.DescripcionBreve;
            this.TxtCodigoEAN.Text = Presentacion.CodigoEAN;

            // Cargar los datos de color, código RGB, nombre y color visual
            Entidades.Color color = Presentacion.Color;
            this.TxtColor.Tag = color;
            this.TxtCodigoColor.Text = color.Codigo;
            this.TxtNombreColor.Text = color.Nombre;
            this.TxtColor.BackColor = System.Drawing.ColorTranslator.FromHtml(color.Codigo);

            this.CmbTalla.SelectedValue = Presentacion.Talla.IdTalla;
            this.TxtFechaIngreso.Text = Presentacion.Fecha.ToString();
            this.CmbUnidadMasa.SelectedValue = Presentacion.UnidadMasa.IdUnidadMasa;
            this.TxtValorMasa.Text = Presentacion.VlrUnidadMasa.ToString();
            this.CmbUnidadVolumen.SelectedValue = Presentacion.UnidadVolumen.IdUnidadVolumen;
            this.TxtUndVolumenAncho.Text = Presentacion.VlrUnidadVolumenAncho.ToString();
            this.TxtUndVolumenLargo.Text = Presentacion.VlrUnidadVolumenLargo.ToString();
            this.TxtUndVolumenProfundidad.Text = Presentacion.VlrUnidadVolumenProfundidad.ToString();
            this.TxtValorContenidoVolumetrico.Text = Presentacion.VlrContenidoVolumetrico.ToString();
            this.CmbUnidadLongitud.SelectedValue = Presentacion.UnidadLongitud.IdUnidadLongitud;
            this.TxtValorLongitud.Text = Presentacion.VlrUnidadLongitud.ToString();
            this.ChkEnLinea.Checked = Presentacion.EnLinea;
            this.ChkActivo.Checked = Presentacion.Activo;
            this.TxtPrecio.Text = Presentacion.Precio.ToString();
            this.TxtExistencias.Text = Presentacion.Existencias.ToString();
            this.CmbSabor.SelectedValue = Presentacion.Sabor.IdSabor;
            this.TxtCostoArticulo.Text = Presentacion.CostoArticulo.ToString();
            this.ChkPreorden.Checked = Presentacion.PreOrden;
            this.CmbUnidadPresentacion.SelectedValue = Presentacion.UnidadPresentacion.IdUnidadPresentacion;
            this.TxtValorUnidadPresentacion.Text = Presentacion.VlrUnidadPresentacion.ToString();
            this.DtpFechaProximoVencimiento.Value = Presentacion.FechaProximoVencimiento;

            this.ChkUsarFechaProximoVencimiento.Checked = Presentacion.UsarFechaProximoVencimiento;
            this.ChkUsarDescuento.Checked = Presentacion.UsarDescuento;
            this.RbUsarPorcentajeDescuento.Checked = Presentacion.UsarPorcentajeDescuento;
            this.TxtValorPorcentajeDescuento.Text = Presentacion.ValorPorcentajeDescuento.ToString();
            this.RbUsarValorFijoDescuento.Checked = Presentacion.UsarValorFijoDescuento;
            this.TxtValorFijoDescuento.Text = Presentacion.ValorFijoDescuento.ToString();
            this.DtpFechaInicioDescuento.Value = Presentacion.FechaInicioDescuento;
            this.DtpFechaFinalDescuento.Value = Presentacion.FechaFinalDescuento;
        }
    }
}
