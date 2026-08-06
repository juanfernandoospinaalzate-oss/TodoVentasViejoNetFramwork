// -----------------------------------------------------------------------
// <copyright file="PadreMDI.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.Mdi
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario principal MDI
    /// </summary>
    public partial class PadreMdi : Form
    {
        /// <summary>
        /// Constructor del formulario MDI
        /// </summary>
        public PadreMdi()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Cierra el programa y todos los formularios Hijos.
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Salir"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestra y oculta la barra de estado
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Barra de estado" </param>
        /// <param name="e">Argumentos para manejo del evento</param>
        private void VerBarraEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statusStrip.Visible = this.VerBarraEstadoToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Organiza las ventanas hijas en formación Cascada
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Cascada"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "No se puede cumplir con la directiva.")]
        private void CascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Organiza las ventanas hijas en formación Mosaico Vertical
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Mosaico Vertical"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "No se puede cumplir con la directiva.")]
        private void MosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Organiza las ventanas hijas en formación Mosaico horizontal
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Mosaico horizontal"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "No se puede cumplir con la directiva.")]
        private void MozaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Cierra todas las ventanas hijas
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Cerrar todas las ventanas"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "No se puede cumplir con la directiva.")]
        private void CerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// Muestra el formulario de administración de colores
        /// </summary>
        /// <param name="sender">Representa el item de menú presionado "Colores"</param>
        /// <param name="e">Argumentos para manejo del evento</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "El objeto formularioColores no puede ser destruido proque no permite el uso del formulario")]
        private void ColoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Colores formularioColores = new Presentacion.TablasMaestras.Colores();
            formularioColores.MdiParent = this;
            formularioColores.Show();
        }

        /// <summary>
        /// Muestra el Formulario de Categorías
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Categorias formularioCategorias = null;
            formularioCategorias = new TablasMaestras.Categorias();
            formularioCategorias.MdiParent = this;
            formularioCategorias.Show();
        }

        /// <summary>
        /// No muestra ningún formulario
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void ParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Muestra el Formulario de Tallas
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void TallasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Talla formularioTallas = null;
            formularioTallas = new Presentacion.TablasMaestras.Talla();
            formularioTallas.MdiParent = this;
            formularioTallas.Show();  
        }

        /// <summary>
        /// Muestra el Formulario de Articulos
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Articulo formularioArticulos = null;
            formularioArticulos = new Presentacion.TablasMaestras.Articulo();
            formularioArticulos.MdiParent = this;
            formularioArticulos.Show();
        }

        /// <summary>
        /// Muestra el Formulario de  Unidades de Masa
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void UnidadDePesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.UnidadMasa formularioUnidadMasa = null;
            formularioUnidadMasa = new Presentacion.TablasMaestras.UnidadMasa();
            formularioUnidadMasa.MdiParent = this;
            formularioUnidadMasa.Show();
        }

        /// <summary>
        /// Muestra el Formulario de Unidades de volúmen
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void UnidadDeVolumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.UnidadVolumen formularioUnidadVolumen = null;
            formularioUnidadVolumen = new Presentacion.TablasMaestras.UnidadVolumen();
            formularioUnidadVolumen.MdiParent = this;
            formularioUnidadVolumen.Show();
        }

        /// <summary>
        /// Muestra el Formulario de Unidades de Longitud
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void UnidadDeLongitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.UnidadLongitud formularioUnidadLongitud = null;
            formularioUnidadLongitud = new Presentacion.TablasMaestras.UnidadLongitud();
            formularioUnidadLongitud.MdiParent = this;
            formularioUnidadLongitud.Show();   
        }

        /// <summary>
        /// Muestra el Formulario Presentación Artículo
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void PresentaciónArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.PresentacionArticulo formularioPresentacionArticulo = null;
            formularioPresentacionArticulo = new Presentacion.TablasMaestras.PresentacionArticulo();
            formularioPresentacionArticulo.MdiParent = this;
            formularioPresentacionArticulo.Show();
        }

        /// <summary>
        /// Muestra el Formulario Marca
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void MarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Marca formularioMarca = null;
            formularioMarca = new Presentacion.TablasMaestras.Marca();
            formularioMarca.MdiParent = this;
            formularioMarca.Show();
        }

        /// <summary>
        /// Muestra el Formulario Sabores
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parámetros del evento</param>
        private void SaboresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Sabor formularioSabores = null;
            formularioSabores = new TablasMaestras.Sabor();
            formularioSabores.MdiParent = this;
            formularioSabores.Show();
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void PadreMdi_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0099");
            this.MenuEdicion.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0100");
            this.MenuArchivo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0101");
            this.SalirToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0102");
            this.undoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0103");
            this.redoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0104");
            this.cutToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0105");
            this.copyToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0106");
            this.pasteToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0107");
            this.selectAllToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0108");
            this.toolsMenu.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0109");
            this.OpcionesToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0110");
            this.ParametrosToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0111");
            this.ArticulosToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0112");
            this.CategoriasToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0113");
            this.ColoresToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0114");
            this.TallasToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0115");
            this.UnidadDeLongitudToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0116");
            this.UnidadDePesoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0117");
            this.UnidadDeVolúmenToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0118");
            this.presentaciónArtículoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0119");
            this.marcaToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0120");
            this.menuStrip.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0121");
            this.viewMenu.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0122");
            this.VerBarraEstadoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0123");
            this.windowsMenu.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0124");
            this.CascadaToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0125");
            this.MosaicoVerticalToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0126");
            this.MosaicoHorizontalToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0127");
            this.CerrarTodasLasVentanasToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0128");
            this.helpMenu.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0129");
            this.contentsToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0130");
            this.indexToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0131");
            this.searchToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0132");
            this.aboutToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0133");
            this.statusStrip.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0134");
            this.toolStripStatusLabel.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0135");
            this.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0140");
            this.saboresToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0186");
            this.paisToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0187");
            this.departamentoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0188");
            this.ciudadToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0239");
            this.facturaciónToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0240");
            this.estadoDeLaVentaToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0241");
            this.almacenToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0242");
            this.configuracionFacturaToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0243");
            this.catalogoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0244");
            this.presentacionArticuloPorAlmacenToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0245");
            this.unidadDePresentacionToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0246");
            this.medioDePagoToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0247");
            this.tarifasDomicilioToolStripMenuItem.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0248");
            this.configuracionPieDePaginaToolStripMenuItem.Text = etiqueta.Texto;
        }

        private void PaisToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Pais formularioPais = null;
            formularioPais = new TablasMaestras.Pais();
            formularioPais.MdiParent = this;
            formularioPais.Show();
        }

        private void DepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Departamento formularioDepartamento = null;
            formularioDepartamento = new TablasMaestras.Departamento();
            formularioDepartamento.MdiParent = this;
            formularioDepartamento.Show();
        }

        private void CiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Ciudad formularioCiudad = null;
            formularioCiudad = new TablasMaestras.Ciudad();
            formularioCiudad.MdiParent = this;
            formularioCiudad.Show();
        }

        private void FacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.Facturacion.Facturacion formularioFacturacion = null;
            formularioFacturacion = new Facturacion.Facturacion();
            formularioFacturacion.MdiParent = this;
            formularioFacturacion.Show();
        }

        private void AlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Almacen formularioAlmacen = null;
            formularioAlmacen = new TablasMaestras.Almacen();
            formularioAlmacen.MdiParent = this;
            formularioAlmacen.Show();
        }

        private void ConfiguracionFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.Facturacion.ConfiguracionFactura formularioConfiguracionFactura = null;
            formularioConfiguracionFactura = new Facturacion.ConfiguracionFactura();
            formularioConfiguracionFactura.MdiParent = this;
            formularioConfiguracionFactura.Show();
        }

        private void CtálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Catalogo formularioCatalogo = null;
            formularioCatalogo = new TablasMaestras.Catalogo();
            formularioCatalogo.MdiParent = this;
            formularioCatalogo.Show();
        }

        private void PresentaciónArtículoPorAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.PresentacionArticuloPorAlmacen formularioPresentacionArticuloPorAlmacen = null;
            formularioPresentacionArticuloPorAlmacen = new TablasMaestras.PresentacionArticuloPorAlmacen();
            formularioPresentacionArticuloPorAlmacen.MdiParent = this;
            formularioPresentacionArticuloPorAlmacen.Show();
        }

        private void MedioDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.MedioDePago formularioMedioDePago = null;
            formularioMedioDePago = new TablasMaestras.MedioDePago();
            formularioMedioDePago.MdiParent = this;
            formularioMedioDePago.Show();
        }

        private void TarifasDomicilioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.TarifasDomicilio formularioTarifasDomicilio = null;
            formularioTarifasDomicilio = new TablasMaestras.TarifasDomicilio();
            formularioTarifasDomicilio.MdiParent = this;
            formularioTarifasDomicilio.Show();
        }

        private void ConfiguraciónPieDePáginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.ConfiguracionPieDePagina formularioConfigPieDePagina = null;
            formularioConfigPieDePagina = new TablasMaestras.ConfiguracionPieDePagina();
            formularioConfigPieDePagina.MdiParent = this;
            formularioConfigPieDePagina.Show();
        }

        private void EstadoDeLaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.EstadoDeLaVenta formularioEstadoDeLaVenta = null;
            formularioEstadoDeLaVenta = new TablasMaestras.EstadoDeLaVenta();
            formularioEstadoDeLaVenta.MdiParent = this;
            formularioEstadoDeLaVenta.Show();
        }

        private void UnidadDePresentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.UnidadPresentacion formularioUnidadPresentacion = null;
            formularioUnidadPresentacion = new TablasMaestras.UnidadPresentacion();
            formularioUnidadPresentacion.MdiParent = this;
            formularioUnidadPresentacion.Show();
        }

        private void AbonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Abonos formularioAbonos = null;
            formularioAbonos = new TablasMaestras.Abonos();
            formularioAbonos.Show();
        }

        private void OrdenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.Facturacion.OrdenesCompra formularioOrdenesCompra = null;
            formularioOrdenesCompra = new Facturacion.OrdenesCompra();
            formularioOrdenesCompra.Show();
        }

        private void FaviconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Favicon formularioFavicon = null;
            formularioFavicon = new TablasMaestras.Favicon();
            formularioFavicon.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.Cliente formularioClientes = null;
            formularioClientes = new TablasMaestras.Cliente();
            formularioClientes.Show();
        }

        private void CargaYDescargaInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.Inventario.CargaDescarga FormularioCargaDescargaInvenario = null;
            FormularioCargaDescargaInvenario = new Inventario.CargaDescarga();
            FormularioCargaDescargaInvenario.Show();
        }

        private void bannerPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.TablasMaestras.BannerPrincipal FormularioBannerPrincipal = null;
            FormularioBannerPrincipal = new TablasMaestras.BannerPrincipal();
            FormularioBannerPrincipal.Show();
        }
    }
}
