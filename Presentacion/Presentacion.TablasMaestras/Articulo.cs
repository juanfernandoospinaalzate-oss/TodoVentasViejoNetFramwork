// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de artículos en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Articulo : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Articulo()
        {
            Fachada.Busquedas.Busqueda busqueda = new Fachada.Busquedas.Busqueda();
            this.InitializeComponent();
        }

        /// <summary>
        /// Inserta los datos nuevos en modo edición, o guarda los datos modificados en modo edición
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Entidades.Articulo articulo = new Entidades.Articulo();
            Entidades.ResultadoTransaccion respuestaTransaccion = new Entidades.ResultadoTransaccion();
            Fachada.TablasMaestras.Articulo articulos = new Fachada.TablasMaestras.Articulo();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");

            errorProvider1.Clear();

            if (this.CmbMarca.SelectedValue.ToString() == "0")
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0026");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.CmbMarca, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtTitulo.Text = this.TxtTitulo.Text.Trim();
            if (this.TxtTitulo.Text == string.Empty)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0024");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.TxtTitulo, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtDescripcion.Text = this.TxtDescripcion.Text.Trim();
            if (TxtDescripcion.Text == string.Empty)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0025");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.TxtDescripcion, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            this.TxtPalabrasRelacionadas.Text = this.TxtPalabrasRelacionadas.Text.Trim();
            if (this.TxtPalabrasRelacionadas.Text == string.Empty)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0027");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.TxtPalabrasRelacionadas, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            int garantiaMeses = int.MinValue;
            if (int.TryParse(this.TxtGarantiaMeses.Text, out garantiaMeses) == false)
            {
                // Si la garantía no es numerica se ingresa un cero al textbox para continuar con el proceso
                if (garantiaMeses == 0)
                {
                    this.TxtGarantiaMeses.Text = garantiaMeses.ToString();
                }
            }

            if (this.TxtVideoYoutube.Text != string.Empty)
            {
                Uri resultadoURL = null;
                bool urlValida = false;
                // verficar que sea una URI válida
                urlValida = Uri.TryCreate(this.TxtVideoYoutube.Text, UriKind.Absolute, out resultadoURL);

                if (resultadoURL == null)
                {
                    // si la url está mala
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0029");
                    MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    errorProvider1.SetError(this.TxtVideoYoutube, respuestaTransaccion.Mensaje.Texto);
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    this.ResetearBotonesOperacionGuardar();
                    return;
                }
                else
                {
                    // Si la url es válida, verificar que sea una url con esquema http
                    if (resultadoURL.Scheme != Uri.UriSchemeHttp)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0030");
                        MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        errorProvider1.SetError(this.TxtVideoYoutube, respuestaTransaccion.Mensaje.Texto);
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        this.ResetearBotonesOperacionGuardar();
                        return;
                    }
                }
            }

            if (this.TxtMetaDescripcion.Text == string.Empty)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0031");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.TxtMetaDescripcion, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.TxtMetaKeyWords.Text == string.Empty)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0032");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.TxtMetaKeyWords, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            int contadorFiltrosActivos = int.MinValue;
            contadorFiltrosActivos = 0;
            if (this.ChkVolumen.Checked)
            {
                articulo.UnidadVolumen = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkMasa.Checked == true)
            {
                articulo.UnidadMasa = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkLongitud.Checked == true)
            {
                articulo.UnidadLongitud = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkTallas.Checked)
            {
                articulo.Talla = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkColores.Checked)
            {
                articulo.Color = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkSabores.Checked)
            {
                articulo.Sabor = true;
                contadorFiltrosActivos++;
            }

            if (this.ChkUnidadPresentacion.Checked)
            {
                articulo.UnidadPresentacion = true;
                contadorFiltrosActivos++;
            }

            if (contadorFiltrosActivos > 3)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0033");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.gbFiltrarBusqueda, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            if (this.ChkEnLinea.Checked)
            {
                articulo.ENLinea = true;
            }

            if (this.ChkPreOrdenar.Checked)
            {
                articulo.PreOrdenar = true;
            }

            if (this.ChkActivo.Checked)
            {
                articulo.Activo = true;
            }

            if (this.ucTrCategorias1.TreeViewCategorias.SelectedNode == null)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0034");
                MessageBox.Show(respuestaTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                errorProvider1.SetError(this.ucTrCategorias1, respuestaTransaccion.Mensaje.Texto);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                this.ResetearBotonesOperacionGuardar();
                return;
            }

            articulo.Marca = this.CmbMarca.SelectedItem as Entidades.Marca;
            articulo.Titulo = this.TxtTitulo.Text;
            articulo.Descripcion = this.TxtDescripcion.Text;
            articulo.PalabrasRelacionArticulo = this.TxtPalabrasRelacionadas.Text;
            articulo.VideoYoutube = this.TxtVideoYoutube.Text;
            articulo.MetaDescripcion = this.TxtMetaDescripcion.Text;
            articulo.MetaKeyWords = this.TxtMetaKeyWords.Text;
            articulo.Categoria = this.ucTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria;
            articulo.UnidadVolumen = this.ChkVolumen.Checked;
            articulo.UnidadMasa = this.ChkMasa.Checked;
            articulo.UnidadLongitud = this.ChkLongitud.Checked;
            articulo.Talla = this.ChkTallas.Checked;
            articulo.Color = this.ChkColores.Checked;
            articulo.ENLinea = this.ChkEnLinea.Checked;
            articulo.PreOrdenar = this.ChkPreOrdenar.Checked;
            articulo.Sabor = this.ChkSabores.Checked;
            articulo.Activo = this.ChkActivo.Checked;
            articulo.GarantiaMeses = int.Parse(this.TxtGarantiaMeses.Text.ToString(), culture);
            articulo.UnidadPresentacion = this.ChkUnidadPresentacion.Checked;

            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                Entidades.ResultadoTransaccion resultadoTransaccion = articulos.Insertar(articulo);

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    Presentacion.TablasMaestras.PresentacionArticulo formularioPresentacionArticulo = null;
                    try
                    {
                        formularioPresentacionArticulo = new Presentacion.TablasMaestras.PresentacionArticulo();
                    }
                    catch (Exception ex)
                    {
                        Logging.ErrorGeneral.Guardar(ex);
                    }

                    formularioPresentacionArticulo.TxtIdArticulo.Text = resultadoTransaccion.ValorAuxiliar.ToString();
                    formularioPresentacionArticulo.ShowDialog();
                    this.ListarArticulos();
                    this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                }
                else
                {
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.ResetearBotonesOperacionGuardar();
                }
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    articulo.IdArticulo = int.Parse(DgvArticulo.SelectedRows[0].Cells[2].Value.ToString(), culture);

                    Entidades.ResultadoTransaccion resultadoTransaccion = articulos.Actualizar(articulo);
                    if (resultadoTransaccion.RegistrosAfectados == 1)
                    {
                        MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0007").Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        barraBotonesCRUD1.BotonCancelar.PerformClick();
                        this.ListarArticulos();
                    }
                    else
                    {
                        MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        this.ResetearBotonesOperacionGuardar();
                    }
                }
            }
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Articulo_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Marca marcas = new Fachada.TablasMaestras.Marca();
            this.CmbMarca.DataSource = marcas.Listar();
            this.CmbMarca.DisplayMember = "Nombre";
            this.CmbMarca.ValueMember = "IdMarca";
            this.TxtTitulo.Enabled = false;
            this.TxtDescripcion.Enabled = false;
            this.TxtPalabrasRelacionadas.Enabled = false;
            this.TxtGarantiaMeses.Enabled = false;
            this.TxtVideoYoutube.Enabled = false;
            this.TxtMetaDescripcion.Enabled = false;
            this.TxtMetaKeyWords.Enabled = false;
            this.CmbMarca.Enabled = false;
            this.ChkActivo.Enabled = false;
            this.ChkColores.Enabled = false;
            this.ChkEnLinea.Enabled = false;
            this.ChkLongitud.Enabled = false;
            this.ChkMasa.Enabled = false;
            this.ChkPreOrdenar.Enabled = false;
            this.ChkSabores.Enabled = false;
            this.ChkTallas.Enabled = false;
            this.ChkVolumen.Enabled = false;
            this.ChkUnidadPresentacion.Enabled = false;
            ucTrCategorias1.HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Inhabilitado);

            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0008");
            this.LblDescripcion.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0009");
            this.LblTitulo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0010");
            this.LblMarca.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0011");
            this.gbFiltrarBusqueda.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0012");
            this.ChkEnLinea.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0013");
            this.ChkColores.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0014");
            this.ChkTallas.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0015");
            this.ChkLongitud.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0016");
            this.ChkMasa.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0017");
            this.ChkVolumen.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0018");
            this.LblMetaKeyWords.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0019");
            this.LblMetaDescripcion.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0020");
            this.LblVideoYoutube.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0021");
            this.LblGarantiaMeses.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0022");
            // this.LblDescripcionWeb.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0023");
            // this.LblNombre.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0024");
            this.LblPalabrasRelacionadas.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0025");
            this.BtnEditPresentacion.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0026");
            // this.IdArticulo.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0027");
            // this.Titulo.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0028");
            // this.CodigoEAN.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0029");
            // this.Nombre.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0030");
            // this.Descripcion.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0031");
            // this.DescripcionCorta.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0032");
            // this.PalabrasRelacionArticulo.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0033");
            // this.MetaDescripcion.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0034");
            // this.MetaKeyWords.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0035");
            // this.UnidadVolumen.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0036");
            // this.UnidadMasa.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0037");
            // this.UnidadLongitud.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0038");
            // this.Talla.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0039");
            // this.Color.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0040");
            // this.EnLinea.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0041");
            // this.GarantiaMeses.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0042");
            // this.VideoYoutube.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0090");
            this.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0136");
            this.ChkPreOrdenar.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0137");
            // this.PreOrdenar.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0138");
            // this.ChkSabores.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0139");
            // this.Sabores.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0145");
            this.ChkActivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0146");
            this.RbActivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0147");
            this.RbInactivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0148");
            this.RbTodos.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0189");
            this.ChkSabores.Text = etiqueta.Texto;

            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);
            this.barraBotonesCRUD1.BotonNuevo.Click += new EventHandler(this.BtnNuevo_Click);

            this.ListarArticulos();

            // se ocultan las columnas no deseadas en la vista
            this.DgvArticulo.Columns[0].Visible = false; // categoria
            this.DgvArticulo.Columns[1].Visible = false; // marca
            this.DgvArticulo.Columns[2].Visible = false; // idarticulo
            // this.DgvArticulo.Columns[3].Visible = false; // titulo
            this.DgvArticulo.Columns[3].Width = 300; // titulo
            this.DgvArticulo.Columns[4].Visible = false; // descripcion
            this.DgvArticulo.Columns[5].Visible = false; // palabras relacionadas
            this.DgvArticulo.Columns[6].Visible = false; // garantia
            this.DgvArticulo.Columns[7].Visible = false; // video woutube
            this.DgvArticulo.Columns[8].Visible = false; // meta descripcion
            this.DgvArticulo.Columns[9].Visible = false; // meta key words
            // this.DgvArticulo.Columns[10].Visible = false; // unidad volumen
            this.DgvArticulo.Columns[10].Width = 90;
            // this.DgvArticulo.Columns[11].Visible = false; // unidad longitud
            this.DgvArticulo.Columns[11].Width = 90;
            // this.DgvArticulo.Columns[12].Visible = false; // unidad masa
            this.DgvArticulo.Columns[12].Width = 75;
            // this.DgvArticulo.Columns[13].Visible = false; // talla
            this.DgvArticulo.Columns[13].Width = 40;
            // this.DgvArticulo.Columns[14].Visible = false; // color
            this.DgvArticulo.Columns[14].Width = 40;
            // this.DgvArticulo.Columns[15].Visible = false; // En Linea
            this.DgvArticulo.Columns[15].Width = 55;
            // this.DgvArticulo.Columns[16].Visible = false; // Pre Ordenar
            this.DgvArticulo.Columns[16].Width = 65;
            // this.DgvArticulo.Columns[17].Visible = false; // Sabor
            this.DgvArticulo.Columns[17].Width = 45;
            // this.DgvArticulo.Columns[18].Visible = false; // Activo
            this.DgvArticulo.Columns[18].Width = 45;
            // this.DgvArticulo.Columns[19].Visible = false; // UnidadPresentacion
            this.DgvArticulo.Columns[19].Width = 110;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.BtnEditPresentacion.Enabled = false;
            this.RbActivo.Enabled = false;
            this.RbInactivo.Enabled = false;
            this.RbTodos.Enabled = false;
            this.DgvArticulo.Enabled = false;
            this.CmbMarca.Focus();
        }

        /// <summary>
        /// Elimina un artículo de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {

                Fachada.TablasMaestras.Articulo articulos = new Fachada.TablasMaestras.Articulo();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idarticulo = int.Parse(DgvArticulo.CurrentRow.Cells[2].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = articulos.Eliminar(idarticulo);

                if (resultadoEliminar.RegistrosAfectados == 1)
                {
                    resultadoEliminar.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
                    MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else
                {
                    resultadoEliminar.Mensaje = Mensajes.LinqToXml.LeerMensaje("0004");
                    MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }

                this.DgvArticulo.Enabled = true;
                this.ListarArticulos();
            }
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.DgvArticulo.Enabled = false;
            this.BtnEditPresentacion.Enabled = false;
            this.RbActivo.Enabled = false;
            this.RbInactivo.Enabled = false;
            this.RbTodos.Enabled = false;
            this.CmbMarca.Focus();
        }

        /// <summary>
        /// Cancela cualquier operación de inserción y edición en curso.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DgvArticulo.Enabled = true;
            this.BtnEditPresentacion.Enabled = true;
            this.RbActivo.Enabled = true;
            this.RbActivo.Checked = true;
            this.RbInactivo.Enabled = true;
            this.RbTodos.Enabled = true;
            this.DgvArticulo.Enabled = true;
            this.TxtBusqueda.Enabled = true;

            // Seleccionar la primera fila del grid, si la hay
            if (this.DgvArticulo.Rows.Count > 0)
            {
                this.DgvArticulo.Rows[0].Selected = false; // Evita el bug de vaciar las casillas si hay solo una fila en el grid
                this.DgvArticulo.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// carga los datos al formulario una vez es seleccionado un elemento del datagridview
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void DgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DgvArticulo.SelectedRows.Count > 0)
            {
                this.ucTrCategorias1.BuscarNodo((this.DgvArticulo.SelectedRows[0].Cells[0].Value as Entidades.Categoria).IdCategoria);
                this.CmbMarca.SelectedValue = (this.DgvArticulo.SelectedRows[0].Cells[1].Value as Entidades.Marca).IdMarca;

                this.TxtTitulo.Text = this.DgvArticulo.SelectedRows[0].Cells[3].Value.ToString();
                this.TxtDescripcion.Text = this.DgvArticulo.SelectedRows[0].Cells[4].Value.ToString();
                this.TxtPalabrasRelacionadas.Text = this.DgvArticulo.SelectedRows[0].Cells[5].Value.ToString();
                this.TxtGarantiaMeses.Text = this.DgvArticulo.SelectedRows[0].Cells[6].Value.ToString();
                this.TxtVideoYoutube.Text = this.DgvArticulo.SelectedRows[0].Cells[7].Value.ToString();
                this.TxtMetaDescripcion.Text = this.DgvArticulo.SelectedRows[0].Cells[8].Value.ToString();
                this.TxtMetaKeyWords.Text = this.DgvArticulo.SelectedRows[0].Cells[9].Value.ToString();

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[10].Value.ToString()) == true)
                {
                    this.ChkVolumen.Checked = true;
                }
                else
                {
                    this.ChkVolumen.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[12].Value.ToString()) == true)
                {
                    this.ChkMasa.Checked = true;
                }
                else
                {
                    this.ChkMasa.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[11].Value.ToString()) == true)
                {
                    this.ChkLongitud.Checked = true;
                }
                else
                {
                    this.ChkLongitud.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[13].Value.ToString()) == true)
                {
                    this.ChkTallas.Checked = true;
                }
                else
                {
                    this.ChkTallas.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[14].Value.ToString()) == true)
                {
                    this.ChkColores.Checked = true;
                }
                else
                {
                    this.ChkColores.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[15].Value.ToString()) == true)
                {
                    this.ChkEnLinea.Checked = true;
                }
                else
                {
                    this.ChkEnLinea.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[16].Value.ToString()) == true)
                {
                    this.ChkPreOrdenar.Checked = true;
                }
                else
                {
                    this.ChkPreOrdenar.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[17].Value.ToString()) == true)
                {
                    this.ChkSabores.Checked = true;
                }
                else
                {
                    this.ChkSabores.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[18].Value.ToString()) == true)
                {
                    this.ChkActivo.Checked = true;
                }
                else
                {
                    this.ChkActivo.Checked = false;
                }

                if (bool.Parse(this.DgvArticulo.SelectedRows[0].Cells[19].Value.ToString()) == true)
                {
                    this.ChkUnidadPresentacion.Checked = true;
                }
                else
                {
                    this.ChkUnidadPresentacion.Checked = false;
                }

                this.DgvArticulo.Select();
            }
        }

        /// <summary>
        /// Llamado al formulario Presentación Artículo en modo de edición 
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void BtnEditPresentacion_Click(object sender, EventArgs e)
        {
            // Evitar ejecución si no hay un artículo seleccionado
            if (this.DgvArticulo.SelectedRows.Count == 0)
            {
                MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0035").Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                return;
            }

            Presentacion.TablasMaestras.PresentacionArticulo formularioPresentacionArticulo = null;
            formularioPresentacionArticulo = new Presentacion.TablasMaestras.PresentacionArticulo();
            formularioPresentacionArticulo.TxtIdArticulo.Text = this.DgvArticulo.SelectedRows[0].Cells[2].Value.ToString();
            formularioPresentacionArticulo.ShowDialog();
        }

        private void ListarArticulos()
        {
            Fachada.TablasMaestras.Articulo articulos = new Fachada.TablasMaestras.Articulo();

            this.Enabled = false;

            if (TxtBusqueda.Text.Trim() == string.Empty) 
            {
                // No hay texto de búsqueda, se listan todos los artículos
                if (this.RbTodos.Checked == true)
                {
                    this.DgvArticulo.DataSource = articulos.Listar();
                }

                if (this.RbActivo.Checked == true)
                {
                    this.DgvArticulo.DataSource = articulos.ListarPorEstado(Entidades.Enumeraciones.EstadoInventario.Activo);
                }

                if (this.RbInactivo.Checked == true)
                {
                    this.DgvArticulo.DataSource = articulos.ListarPorEstado(Entidades.Enumeraciones.EstadoInventario.Inactivo);
                }
            }
            else
            {
                if (this.RbTodos.Checked == true)
                {
                    Fachada.Busquedas.Busqueda Busqueda = new Fachada.Busquedas.Busqueda();
                    this.DgvArticulo.DataSource = Busqueda.Buscar(TxtBusqueda.Text, null);
                }

                if (this.RbActivo.Checked == true)
                {
                    Fachada.Busquedas.Busqueda Busqueda = new Fachada.Busquedas.Busqueda();
                    this.DgvArticulo.DataSource = Busqueda.BuscarPorEstado(TxtBusqueda.Text, null, Entidades.Enumeraciones.Estado.Habilitado);
                }

                if (this.RbInactivo.Checked == true)
                {
                    Fachada.Busquedas.Busqueda Busqueda = new Fachada.Busquedas.Busqueda();
                    this.DgvArticulo.DataSource = Busqueda.BuscarPorEstado(TxtBusqueda.Text, null, Entidades.Enumeraciones.Estado.Inhabilitado);
                }
                
            }

            this.Enabled = true;
        }

        private void RbActivo_CheckedChanged(object sender, EventArgs e)
        {
            this.ListarArticulos();
        }

        private void RbInactivo_CheckedChanged(object sender, EventArgs e)
        {
            this.ListarArticulos();
        }

        private void RbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.ListarArticulos();
        }

        private void Articulo_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (DgvArticulo.SelectedRows.Count > 0)
                {
                    ucTrCategorias1.BuscarNodo((DgvArticulo.SelectedRows[0].Cells[0].Value as Entidades.Categoria).IdCategoria);
                    this.DgvArticulo.Select();
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

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ListarArticulos();
            }
        }
    }
}