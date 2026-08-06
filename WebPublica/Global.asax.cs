//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;

    public class Global : System.Web.HttpApplication
    {
        static System.Timers.Timer Centinela = new System.Timers.Timer();
        static int ControlCasosCentinela = 0;
        protected void Application_Start(object sender, EventArgs e)
        {
            EntidadesWeb.BannerPrincipal BannerPrincipal = null;

            Fachada.WebPublica.Articulo Articulo = new Fachada.WebPublica.Articulo();
            Fachada.WebPublica.PresentacionArticulo Presentacion = new Fachada.WebPublica.PresentacionArticulo();
            Fachada.WebPublica.UnidadMasa UnidadMasa = new Fachada.WebPublica.UnidadMasa();
            Fachada.WebPublica.UnidadVolumen UnidadVolumen = new Fachada.WebPublica.UnidadVolumen();
            Fachada.WebPublica.UnidadLongitud UnidadLongitud = new Fachada.WebPublica.UnidadLongitud();
            Fachada.WebPublica.Talla Talla = new Fachada.WebPublica.Talla();
            Fachada.WebPublica.Color Color = new Fachada.WebPublica.Color();
            Fachada.WebPublica.Sabor Sabor = new Fachada.WebPublica.Sabor();
            Fachada.WebPublica.BannerPrincipal ConfiguraciónBannerPrincipal = new Fachada.WebPublica.BannerPrincipal();
            Fachada.WebPublica.UnidadPresentacion UnidadPresentacion = new Fachada.WebPublica.UnidadPresentacion();
            this.CargarActualizarMarcaDesdeBaseDatos_a_SitioWeb();
            this.CargarActualizarCategoriasDesdeBaseDatos_a_SitioWeb();
            Fachada.WebPublica.ConfiguracionPieDePagina ConfigPieDePagina = new Fachada.WebPublica.ConfiguracionPieDePagina();
            Fachada.WebPublica.BannerPrincipal FachadaBannerPrincipal = new Fachada.WebPublica.BannerPrincipal();

            // Declaración de las listas de solo lectura
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> listaReadOnlyArticulos = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> listaReadOnlyPresentacionArticulo = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> listaReadOnlyUnidadMasa = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> listaReadOnlyUnidadVolumen = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> listaReadOnlyUnidadLongitud = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> listaReadOnlyTalla = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> listaReadOnlyColor = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> listaReadOnlySabor = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> listaReadOnlyUnidadPresentacion = null;

            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> listaReadOnlyConfiguracionPieDePagina = null;

            // Declaración de las listas con las que luego se hará llenado de las listas de solo lectura
            List<EntidadesWeb.Articulo> ListaArticulos = new List<EntidadesWeb.Articulo>();
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos = new List<EntidadesWeb.PresentacionArticulo>();
            List<EntidadesWeb.UnidadMasa> ListaUnidadMasa = new List<EntidadesWeb.UnidadMasa>();
            List<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen = new List<EntidadesWeb.UnidadVolumen>();
            List<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud = new List<EntidadesWeb.UnidadLongitud>();
            List<EntidadesWeb.Talla> ListaTalla = new List<EntidadesWeb.Talla>();
            List<EntidadesWeb.Color> ListaColor = new List<EntidadesWeb.Color>();
            List<EntidadesWeb.Sabor> ListaSabor = new List<EntidadesWeb.Sabor>();
            EntidadesWeb.BannerPrincipal EntidadBannerPrincipal = null;
            List<EntidadesWeb.UnidadPresentacion> ListaUnidadPresentacion = new List<EntidadesWeb.UnidadPresentacion>();

            List<EntidadesWeb.ConfiguracionPieDePagina> ListaConfiguracionPieDePagina = new List<EntidadesWeb.ConfiguracionPieDePagina>();


            listaReadOnlyArticulos = Articulo.Listar();
            listaReadOnlyPresentacionArticulo = Presentacion.Listar();
            listaReadOnlyUnidadMasa = UnidadMasa.ListaUnidadMasa();
            listaReadOnlyUnidadVolumen = UnidadVolumen.ListaUnidadVolumen();
            listaReadOnlyUnidadLongitud = UnidadLongitud.ListaUnidadLongitud();
            listaReadOnlyTalla = Talla.ListaTallas();
            listaReadOnlyColor = Color.ListaColores();
            listaReadOnlySabor = Sabor.ListaSabores();
            EntidadBannerPrincipal = ConfiguraciónBannerPrincipal.Consultar();
            listaReadOnlyUnidadPresentacion = UnidadPresentacion.Listar();
            listaReadOnlyConfiguracionPieDePagina = ConfigPieDePagina.Listar();
            BannerPrincipal = FachadaBannerPrincipal.Consultar();

            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            List<EntidadesWeb.Marca> ListaMarcas = Application["ListaMarca"] as List<EntidadesWeb.Marca>;
            foreach (EntidadesWeb.Articulo articulo in listaReadOnlyArticulos)
            {
                articulo.Marca = BusquedasBinariasWeb.BusquedaBinariaMarca(ListaMarcas, articulo.Marca.IdMarca);
                ListaArticulos.Add(articulo);
            }

            List<EntidadesWeb.Categoria> ListaCategorias = Application["ListaCategorias"] as List<EntidadesWeb.Categoria>;
            foreach (EntidadesWeb.PresentacionArticulo presentacionArticulo in listaReadOnlyPresentacionArticulo)
            {
                presentacionArticulo.Categoria = BusquedasBinariasWeb.BusquedaBinariaCategoriaPorIdCategoria(ListaCategorias, presentacionArticulo.Categoria.IdCategoria);
                presentacionArticulo.Articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(ListaArticulos, presentacionArticulo.Articulo.IdArticulo);
                ListaPresentacionArticulos.Add(presentacionArticulo);
            }

            foreach (EntidadesWeb.UnidadMasa unidadMasa in listaReadOnlyUnidadMasa)
            {
                ListaUnidadMasa.Add(unidadMasa);
            }

            foreach (EntidadesWeb.UnidadVolumen unidadVolumen in listaReadOnlyUnidadVolumen)
            {
                ListaUnidadVolumen.Add(unidadVolumen);
            }

            foreach (EntidadesWeb.UnidadLongitud unidadLongitud in listaReadOnlyUnidadLongitud)
            {
                ListaUnidadLongitud.Add(unidadLongitud);
            }

            foreach (EntidadesWeb.Talla talla in listaReadOnlyTalla)
            {
                ListaTalla.Add(talla);
            }

            foreach (EntidadesWeb.Color color in listaReadOnlyColor)
            {
                ListaColor.Add(color);
            }

            foreach (EntidadesWeb.Sabor sabor in listaReadOnlySabor)
            {
                ListaSabor.Add(sabor);
            }

            foreach (EntidadesWeb.UnidadPresentacion unidadPresentacion in listaReadOnlyUnidadPresentacion)
            {
                ListaUnidadPresentacion.Add(unidadPresentacion);
            }

            foreach (EntidadesWeb.ConfiguracionPieDePagina PieDePagina in listaReadOnlyConfiguracionPieDePagina)
            {
                ListaConfiguracionPieDePagina.Add(PieDePagina);
            }

            this.Application["ListaArticulos"] = ListaArticulos;
            this.CrearListaArticuloInvertida();
            this.Application["ListaPresentacionArticulo"] = ListaPresentacionArticulos;
            this.CrearListaPresentacionArticuloInvertida();
            this.Application["ListaUnidadMasa"] = ListaUnidadMasa;
            this.Application["ListaUnidadVolumen"] = ListaUnidadVolumen;
            this.Application["ListaTalla"] = ListaTalla;
            this.Application["ListaColor"] = ListaColor;
            this.Application["ListaSabor"] = ListaSabor;
            this.Application["ListaUnidadPresentacion"] = ListaUnidadPresentacion;
            this.Application["ListaConfiguracionPieDePagina"] = listaReadOnlyConfiguracionPieDePagina;
            this.Application["UrlBase"] = System.Configuration.ConfigurationManager.AppSettings["UrlBase"];
            this.Application["RutaImagenesBanner"] = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesBanner"];
            this.Application["BannerPrincipal"] = BannerPrincipal;

            // A cada Articulo, se le carga sus correspondientes presentaciones
            CargaPresentacionesEnArticulo(
            this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>,
            this.Application["ListaArticulos"] as List<EntidadesWeb.Articulo>);

            // Temporizador para tareas programadas
            Centinela.Interval = 1000 * 60;
            // Centinela.Interval = 1000 * 20; // PRUEBAS
            Centinela.Enabled = true;
            Centinela.Elapsed += this.Centinela_Elapsed;
            Centinela.Start(); 
        }

        private void Centinela_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ControlCasosCentinela++;

            switch (ControlCasosCentinela)
            {
                case 1:
                    this.CrearCatalogoPDF();
                    break;
                case 2:
                    this.CrearSitemap();
                    break;
                case 3:
                    // Levantaer los datos nuevos desde la base de datos a la memoria del sitio web
                    this.ActualizarArticulosDesdeBaseDatos_a_SitioWeb();
                    this.ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb();
                    this.CrearListaArticuloInvertida();
                    this.RemoverPublicacionesSitioWeb();

                    // this.CrearCatalogoPDF(); // SOLO POR PRUEBAS Y NO ESPERAR QUE DISPARE ELSENTINELA POR TERCERA VEZ
                    break;
                default:
                    ControlCasosCentinela = 0;
                    break;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // this.Application["UrlBase"] = Request.Url.Scheme + "://" + Request.Url.Authority + "/";
            // this.CargarVariableSesionUrlBase();

            if (Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName] != null)
            {
                string NombreCookie = System.Web.Security.FormsAuthentication.FormsCookieName;
                System.Web.HttpCookie Cookie = Request.Cookies[NombreCookie];
                System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(Cookie.Value);
                this.Session["TicketUsuario"] = ticket;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Si en el último segmento los ultimos cuatro caracteres son "aspx", se continúa con la sobreescritura
            string ultimosCuatro = string.Empty;

            // Si pidieron el directorio raiz
            if (Request.Url.AbsolutePath == "/")
            {
                Context.RewritePath("~/Index.aspx", true);
            }
            else
            {
                ultimosCuatro = Request.Url.AbsolutePath.Substring(Request.Url.AbsolutePath.Length - 4);
            }

            if (ultimosCuatro == "aspx")
            {
                // RutaUrlBase + NombresCategorias + "/" + presentacionArticulo.NombreArticulo + "-" + presentacionArticulo.IdArticulo + "-" + presentacionArticulo.IdPresentacionArticulo);
                // Listar los segmentos y obtener el último
                string[] segmentosUrl = Request.Url.Segments;
                int indiceUltimoElemento = segmentosUrl.Length - 1;
                string ultimoSegmento = string.Empty;
                string[] parametrosDelSegmento = null;


                // Utilizando el primer segmento que sigue al nombre de dominio se establece el tipo de enlace

                switch (segmentosUrl[1])
                {
                    // Enlace a un artículo
                    //                       0       1                2                           3
                    case "Articulo/": // Dominio/"Articulo"/Categorias {variable}/nombre presentacion articulo.aspx"
                        if (this.Request["__VIEWSTATE"] != null)
                        {
                            // si se cumple, en la mayoria de los casos es un postback.
                            // se sale del case para no generar un error

                            // Response.Redirect(System.Web.Security.FormsAuthentication.GetRedirectUrl(login.Usuario, isPersistent));

                            // Context.RewritePath("~/Articulo.aspx?IdArticulo=" + 2 + "&IdPresentacionArticulo=" + 6, true);
                            // break;
                        }

                        string IdArticulo = string.Empty;
                        string IdPresentacionArticulo = string.Empty;

                        // Extraer los parametros del ultimo segmento de url
                        ultimoSegmento = segmentosUrl[indiceUltimoElemento];
                        ultimoSegmento = ultimoSegmento.Remove(ultimoSegmento.Length - 5);
                        parametrosDelSegmento = ultimoSegmento.Split('-');
                        IdArticulo = parametrosDelSegmento[parametrosDelSegmento.Length - 2];
                        IdPresentacionArticulo = parametrosDelSegmento[parametrosDelSegmento.Length - 1];

                        // Verificar si son casos 404 y 410, para hacer la redirección correspondiente y devolución de códigos de status.
                        if (this.ControlStatus404y410(IdArticulo, IdPresentacionArticulo) == true)
                        {
                            // Se hizo un control 404 o 410
                            break;
                        }

                        Context.RewritePath("~/DetalleArticulo.aspx?IdArticulo=" + IdArticulo + "&IdPresentacionArticulo=" + IdPresentacionArticulo, true);
                        break;
                    // Enlace a una lista de busqueda
                    //    0             1                   2
                    // Dominio/"Resultado_Busqueda"/palabras_claves.aspx"
                    case "Categoria/":
                        string idCategoria = string.Empty;
                        // Extraer los parametros del ultimo segmento de url
                        ultimoSegmento = segmentosUrl[indiceUltimoElemento];
                        ultimoSegmento = ultimoSegmento.Remove(ultimoSegmento.Length - 5);
                        parametrosDelSegmento = ultimoSegmento.Split('-');
                        idCategoria = parametrosDelSegmento[parametrosDelSegmento.Length - 1];
                        Context.RewritePath("~/ResultadoCajaCategoria.aspx?Categoria=" + idCategoria, true);
                        break;
                    // http://localhost:7235/Resultado_Busqueda/Omega_3-IdArticulo-IdPresentacionArticulo
                    // Enlace a un indeterminado
                    // 1        2       3         4           5         6
                    case "alguna cosa": // Dominio/"juego"/formato/NombreJuego/IdJuego/"Default.aspx"
                        Context.RewritePath("~/Juego.aspx?Juego=");
                        break;
                    default:
                        break;
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        #region "Métodos añadidos"

        public static void CargaPresentacionesEnArticulo(List<EntidadesWeb.PresentacionArticulo> ListaPresentacionesDeArticulo, List<EntidadesWeb.Articulo> ListaArticulos)
        {
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();

            foreach (EntidadesWeb.PresentacionArticulo itemPresentacionArticulo in ListaPresentacionesDeArticulo)
            {
                EntidadesWeb.Articulo Articulo = null;
                Articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(ListaArticulos, itemPresentacionArticulo.Articulo.IdArticulo);

                if (Articulo != null)
                {
                    Articulo.PresentacionesDelArticulo.Add(itemPresentacionArticulo);
                }
            }
        }

        private void CargarActualizarMarcaDesdeBaseDatos_a_SitioWeb()
        {
            Fachada.WebPublica.Marca Marca = new Fachada.WebPublica.Marca();
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Marca> listaReadOnlyMarca = null;
            List<EntidadesWeb.Marca> ListaMarca = new List<EntidadesWeb.Marca>();
            listaReadOnlyMarca = Marca.Listar();

            foreach (EntidadesWeb.Marca marca in listaReadOnlyMarca)
            {
                ListaMarca.Add(marca);
            }

            this.Application["ListaMarca"] = ListaMarca;

            List<EntidadesWeb.Articulo> a = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
        }

        private void CargarActualizarCategoriasDesdeBaseDatos_a_SitioWeb()
        {
            Fachada.WebPublica.Categoria Categoria = new Fachada.WebPublica.Categoria();
            List<EntidadesWeb.Categoria> ListaCategorias = new List<EntidadesWeb.Categoria>();
            List<EntidadesWeb.Categoria> ListaCategoriasUsadas = new List<EntidadesWeb.Categoria>();
            ListaCategorias = Categoria.Listar().ToList<EntidadesWeb.Categoria>();
            ListaCategoriasUsadas = Categoria.ListarCategoriasUsadas().ToList<EntidadesWeb.Categoria>();

            // Cargar segmentos amigables
            foreach (EntidadesWeb.Categoria categoria in ListaCategorias)
            {
                categoria.SegmentoAmigableUrlCategoria = Global.CargaSegmentosAmigablesUrl(categoria, ListaCategorias);
            }

            // Listar las categorías usadas (ligadas a artículos)
            foreach (EntidadesWeb.Categoria categoriaUsada in ListaCategoriasUsadas)
            {
                categoriaUsada.SegmentoAmigableUrlCategoria = Global.CargaSegmentosAmigablesUrl(categoriaUsada, ListaCategoriasUsadas);
            }

            this.Application["ListaCategorias"] = ListaCategorias;
            this.Application["ListaCategoriasUsadas"] = ListaCategoriasUsadas;
            this.Application["MenuItemRaiz"] = null; // Para que el componente WucMenuCategorias sea reconstruido
        }

        /// <summary>
        /// Sobre escribe en el sitio web, los datos de las presentaciones de artículo que han sido modificados en la base de datos 
        /// </summary>
        public void ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb()
        {
            Fachada.WebPublica.PresentacionArticulo PresentacionArticulo = new Fachada.WebPublica.PresentacionArticulo();
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();

            // Obtener la lista de presentaciones de artículos en la memoria del sitio web
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulo = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;

            // Obtener la lista de artículos de la memoria del sitio web
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;

            // Obtener la lista de presentaciones que se deben actualizar en memoria (Fueron actualizadas en la base de datos)
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> listaPresentacionArticuloPendientesActualizacion = PresentacionArticulo.ListarPendientesActualizacion();
            if (listaPresentacionArticuloPendientesActualizacion == null)
            {
                return;
            }

            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();

            // Subir los cambios en las presentaciones de artículo
            foreach (EntidadesWeb.PresentacionArticulo presentacionArticuloNueva in listaPresentacionArticuloPendientesActualizacion)
            {
                EntidadesWeb.PresentacionArticulo PresentacionArticuloParaActualizar = null;
                System.Reflection.PropertyInfo[] infosArticulo = typeof(EntidadesWeb.PresentacionArticulo).GetProperties();
                System.Reflection.PropertyInfo[] infosPresentacionArticulo = typeof(EntidadesWeb.PresentacionArticulo).GetProperties();
                PresentacionArticuloParaActualizar = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ref listaPresentacionArticulo, presentacionArticuloNueva.IdPresentacionArticulo);
                // Verificar que la info actualizada si esté cargada en al variable de aplicación
                if (PresentacionArticuloParaActualizar != null)
                {
                    // Ccopia de seguridad de los datos de artículo
                    EntidadesWeb.Articulo articulo = PresentacionArticuloParaActualizar.Articulo;

                    // Sobreescribir la info de todas las propiedades por cada presentación
                    foreach (System.Reflection.PropertyInfo info in infosPresentacionArticulo)
                    {
                        if (info.CanWrite == true)
                        {
                            info.SetValue(PresentacionArticuloParaActualizar, info.GetValue(presentacionArticuloNueva, null), null);
                        }
                    }

                    PresentacionArticuloParaActualizar.Articulo = articulo; // re`poner datos perdidos
                }
                else
                {
                    // Si la información actualizada NO está en las variable de aplicación, se debe insertar en la variable de aplicación "ListaPresentacionArticulo"
                    // Verificar que el atículo esté en Activo y en línea, de lo contrario no se hace la inserción
                    EntidadesWeb.Articulo Articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(listaArticulos, presentacionArticuloNueva.Articulo.IdArticulo);

                    // Verificar si fue activo y/o puesto en línea (Nuevos y dados de baja por configuración)
                    if (presentacionArticuloNueva.Activo == true && presentacionArticuloNueva.ENLinea == true)
                    {
                        int posicionInsercionPresentacionArticulo = int.MinValue;
                        posicionInsercionPresentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloIndiceDondeInsertar(ref listaPresentacionArticulo, presentacionArticuloNueva.IdPresentacionArticulo);
                        if (posicionInsercionPresentacionArticulo != int.MinValue)
                        {
                            // Añadir la presentación a la lista de presentaciones de artículo correspondiente
                            listaPresentacionArticulo.Insert(posicionInsercionPresentacionArticulo, presentacionArticuloNueva);

                            // añadir la presentación a la lista de presentaciones de artículo asociados al correspondiente artículo que se encuentra cargado en memoria
                            if (Articulo.PresentacionesDelArticulo.Exists(p => p.IdPresentacionArticulo == presentacionArticuloNueva.IdPresentacionArticulo) == false)
                            {
                                presentacionArticuloNueva.Articulo = Articulo;
                                Articulo.PresentacionesDelArticulo.Add(presentacionArticuloNueva);
                            }
                        }
                    }
                }
                // Desmarcar la presentación del artículo para no ser actualizada en la próxima iteración del centinela
                PresentacionArticulo.QuitarMarcaActualizarPresentacionArticulo(presentacionArticuloNueva.IdPresentacionArticulo);
            }
        }

        /// <summary>
        /// Sobre escribe en el sitio web, los datos de los artículos que han sido modificados en la base de datos 
        /// </summary>
        public void ActualizarArticulosDesdeBaseDatos_a_SitioWeb()
        {
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
            Fachada.WebPublica.PresentacionArticulo FachadaPresentacionArticulo = new Fachada.WebPublica.PresentacionArticulo();
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>; // Obtener la lista de artículos de la memoria del sitio web

            // Obtener la lista de Articulos que se deben actualizar en memoria (Fueron actualizadas en la base de datos)
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> listaArticuloPendientesActualizacion = FachadaArticulo.ListarPendientesActualizacion();
            if (listaArticuloPendientesActualizacion == null)
            {
                return; // Terminar si no hay artículos por actualizar 
            }

            this.CargarActualizarMarcaDesdeBaseDatos_a_SitioWeb(); // Si hay artículos nuevos se refrescan las marcas
            this.CargarActualizarCategoriasDesdeBaseDatos_a_SitioWeb(); // Si hay artículos nuevo se refrescan las categorías

            // Subir los cambios en los artículos
            foreach (EntidadesWeb.Articulo articuloNuevo in listaArticuloPendientesActualizacion)
            {
                EntidadesWeb.Articulo ArticuloParaActualizar = null;
                System.Reflection.PropertyInfo[] infosArticulo = typeof(EntidadesWeb.Articulo).GetProperties();
                ArticuloParaActualizar = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(ref listaArticulos, articuloNuevo.IdArticulo); // Buscar en la variable de aplicación el artículo

                if (ArticuloParaActualizar != null)
                {
                    // Si el artículo ya está en memoria, se actualizan sus datos tomando la lista de artículos de la base de datos
                    EntidadesWeb.Marca Marca = ArticuloParaActualizar.Marca;

                    // Sobreescribir la info de todas las propiedades por cada presentación
                    foreach (System.Reflection.PropertyInfo info in infosArticulo)
                    {
                        if (info.CanWrite == true)
                        {
                            info.SetValue(ArticuloParaActualizar, info.GetValue(articuloNuevo, null), null);
                        }
                    }

                    // ArticuloParaActualizar = articuloNuevo;
                    ArticuloParaActualizar.PresentacionesDelArticulo = FachadaPresentacionArticulo.ListarPorIdArticulo(articuloNuevo.IdArticulo).ToList(); // Cargar presentaciones activas desde la base de datos
                    ArticuloParaActualizar.Marca = Marca; // Reponder datos perdidos
                }
                else
                {
                    // Si la información actualizada NO está en las variable de aplicación, se debe insertar en la variable de aplicación "ListaArticulos"
                    // Verificar si fue activo y/o puesto en línea (articulos Nuevos y que fueron dados de baja por configuración)
                    if (articuloNuevo.Activo == true && articuloNuevo.ENLinea == true)
                    {
                        ArticuloParaActualizar = articuloNuevo;
                        ArticuloParaActualizar.PresentacionesDelArticulo = FachadaPresentacionArticulo.ListarPorIdArticulo(articuloNuevo.IdArticulo).ToList(); // Cargar presentaciones activas desde la base de datos

                        int posicionInsercionPresentacionArticulo = int.MinValue;
                        posicionInsercionPresentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaArticuloIndiceDondeInsertar(ref listaArticulos, articuloNuevo.IdArticulo);
                        if (posicionInsercionPresentacionArticulo != int.MinValue)
                        {
                            listaArticulos.Insert(posicionInsercionPresentacionArticulo, ArticuloParaActualizar); // Añadir la presentación a la memoria del sitio
                        }
                    }
                }

                FachadaArticulo.QuitarMarcaActualizarArticulo(articuloNuevo.IdArticulo); // Desmarcar la presentación del artículo para no ser actualizada en la próxima iteración del centinela
            }
        }

        /// <summary>
        /// Elimina de las variables de aplicación las presentaciones de artículo y los artículos que encuentre señalados para tal fin.
        /// </summary>
        public void RemoverPublicacionesSitioWeb()
        {
            // Obtener la lista de presentaciones de artículos
            Fachada.WebPublica.PresentacionArticulo PresentacionArticulo = new Fachada.WebPublica.PresentacionArticulo();
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulo = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;

            // Se inactivó o se bajó de línea el artículo, y con este todas sus presentaciones. 
            for (int i = 0; i < listaArticulos.Count; i++)
            {
                // Eliminar de la memoria los artículos que se tienen que bajar por configuración y todas sus presentaciones sin importar la configuración de la presentación
                if (listaArticulos[i].ENLinea == false || listaArticulos[i].Activo == false)
                {
                    List<EntidadesWeb.PresentacionArticulo> PresentacionesDelArticulo = listaArticulos[i].PresentacionesDelArticulo;
                    // Remover las presentaciones del artículo de la variable de sesión
                    for (int j = 0; j < PresentacionesDelArticulo.Count; i++)
                    {
                        // Eliminar la presentación de la memoria de Aplicación del sitio web
                        PresentacionesDelArticulo.RemoveAt(j);
                        if (PresentacionesDelArticulo.Count != 0)
                        {
                            j--;
                        }
                    }

                    listaArticulos.RemoveAt(i);
                    if (listaArticulos.Count != 0)
                    {
                        i--;
                    }
                }
            }

            // Eliminar de la memoria las presentaciones que se tienen que bajar por configuración
            for (int i = 0; i < listaPresentacionArticulo.Count; i++)
            {
                if (listaPresentacionArticulo[i].ENLinea == false || listaPresentacionArticulo[i].Activo == false || listaPresentacionArticulo[i].Articulo.ENLinea == false || listaPresentacionArticulo[i].Articulo.Activo == false)
                {
                    // Remover la presentación de la lista de presentaciones (del artículo padre)
                    for (int j = 0; j < listaPresentacionArticulo[i].Articulo.PresentacionesDelArticulo.Count; j++)
                    {
                        if (listaPresentacionArticulo[i].Articulo.PresentacionesDelArticulo[j].IdPresentacionArticulo == listaPresentacionArticulo[i].IdPresentacionArticulo)
                        {
                            listaPresentacionArticulo[i].Articulo.PresentacionesDelArticulo.RemoveAt(j);
                            if (listaPresentacionArticulo[i].Articulo.PresentacionesDelArticulo.Count() != 0)
                            {
                                j--;
                            }
                        }
                    }

                    // Remover la presentación de la lista de presentaciones del sitio web
                    listaPresentacionArticulo.RemoveAt(i);
                    if (listaPresentacionArticulo.Count() != 0)
                    {
                        i--;
                    }
                }
            }
        }

        private void CrearSitemap()
        {
            string DireccionSitemapDisco = string.Empty;
            System.Xml.Linq.XDocument documentoXML = null;
            System.Xml.Linq.XElement ElementoXMLUrlset = null;
            System.Xml.Linq.XNamespace Xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            System.Xml.Linq.XNamespace XmlnsImagen = "http://www.google.com/schemas/sitemap-image/1.1";
            System.Xml.Linq.XElement ElementoXmlUrl = null;
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos = null;
            System.Xml.Linq.XElement ElementoXML_Loc = null;
            System.Xml.Linq.XElement ElementoXml_Image = null;
            System.Xml.Linq.XElement ElementoXml_ImageLoc = null;
            string RutaUrlBase = this.Application["UrlBase"].ToString();
            string RutaImagenes = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "/";

            DireccionSitemapDisco = HttpRuntime.AppDomainAppPath + "SiteMap.xml";

            // Verificar que el archivo exista para eliminarlo
            if (System.IO.File.Exists(DireccionSitemapDisco))
            {
                System.IO.File.Delete(DireccionSitemapDisco);
            }

            ElementoXMLUrlset = new System.Xml.Linq.XElement(Xmlns + "urlset", new System.Xml.Linq.XAttribute(System.Xml.Linq.XNamespace.Xmlns + "image", XmlnsImagen));

            ListaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;

            foreach (EntidadesWeb.PresentacionArticulo PresentacionArticulo in ListaPresentacionArticulos)
            {
                ElementoXmlUrl = new System.Xml.Linq.XElement(Xmlns + "url");
                ElementoXML_Loc = new System.Xml.Linq.XElement(Xmlns + "loc");
                ElementoXML_Loc.Value = RutaUrlBase + "Articulo/" + Global.CargaSegmentosAmigablesUrl(PresentacionArticulo.Categoria, Application["ListaCategorias"] as List<EntidadesWeb.Categoria>) + "/" + PresentacionArticulo.NombreSinEspacios + "-" + PresentacionArticulo.Articulo.IdArticulo + "-" + PresentacionArticulo.IdPresentacionArticulo + ".aspx";

                ElementoXml_Image = new System.Xml.Linq.XElement(XmlnsImagen + "image");
                ElementoXml_ImageLoc = new System.Xml.Linq.XElement(XmlnsImagen + "loc");
                ElementoXml_ImageLoc.Value = RutaUrlBase + RutaImagenes + PresentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + PresentacionArticulo.IdPresentacionArticulo + "A.jpg";
                ElementoXml_Image.Add(ElementoXml_ImageLoc);

                ElementoXmlUrl.Add(ElementoXML_Loc);
                ElementoXmlUrl.Add(ElementoXml_Image);

                ElementoXMLUrlset.Add(ElementoXmlUrl);
            }

            documentoXML = new System.Xml.Linq.XDocument(ElementoXMLUrlset);
            documentoXML.Save(DireccionSitemapDisco);
        }

        public static string CargaSegmentosAmigablesUrl(EntidadesWeb.Categoria categoria, List<EntidadesWeb.Categoria> ListaCategoria)
        {
            string NombresCategorias = string.Empty;

            // recorremos las lista de categorías buscando por IdCategoria
            foreach (EntidadesWeb.Categoria itemCategoria in ListaCategoria)
            {
                // si se encuentra el IdCategoria.
                if (itemCategoria.IdCategoria == categoria.IdCategoria)
                {
                    // concatenamos el nombre de la categoria para comenzara ensamblar la url amigable
                    NombresCategorias += itemCategoria.Nombre;

                    // si la categoria encontrada tiene un idCategoriaPadre entonces se añade a la izquierda de la url amigable 
                    if (itemCategoria.IdCategoriaPadre != 0)
                    {
                        foreach (EntidadesWeb.Categoria itemUnoCategoria in ListaCategoria)
                        {
                            if (itemCategoria.IdCategoriaPadre == itemUnoCategoria.IdCategoria)
                            {
                                // concatenamos el nombre de la categoria para comenzara ensamblar la url amigable
                                NombresCategorias = itemUnoCategoria.Nombre + "/" + NombresCategorias;

                                // si la categoria encontrada tiene un idCategoriaPadre entonces se añade a la izquierda de la url amigable 
                                if (itemUnoCategoria.IdCategoriaPadre != 0)
                                {
                                    foreach (EntidadesWeb.Categoria itemDosCategoria in ListaCategoria)
                                    {
                                        if (itemUnoCategoria.IdCategoriaPadre == itemDosCategoria.IdCategoria)
                                        {
                                            NombresCategorias = itemDosCategoria.Nombre + "/" + NombresCategorias;

                                            if (itemDosCategoria.IdCategoria != 0)
                                            {
                                                foreach (EntidadesWeb.Categoria itemTresCategoria in ListaCategoria)
                                                {
                                                    if (itemDosCategoria.IdCategoriaPadre == itemTresCategoria.IdCategoria)
                                                    {
                                                        NombresCategorias = itemTresCategoria.Nombre + "/" + NombresCategorias;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return NombresCategorias.Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n").Replace("'", string.Empty).Replace("&", "and").Replace("+", string.Empty);
        }

        /// <summary>
        /// Controla y ejecuta sobre escritura de url si se está consultando un artículo o una presentación de artículo 
        /// que no está disponible momentánea o permanentemente y redirige a la página de error específica para el caso
        /// </summary>
        /// <param name="idAarticulo">Identificación única del Artículo en la base de datos</param>
        /// <param name="idPresentacionArticulo">Identificación única de la Presentación del Artículo en la base de datos</param>
        /// <returns>true si se ejecutó un control de status, retorna false en caso que no se ejecute un control de status</returns>
        private bool ControlStatus404y410(string idAarticulo, string idPresentacionArticulo)
        {
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
            Fachada.WebPublica.PresentacionArticulo FachadaPresentacionArticulo = new Fachada.WebPublica.PresentacionArticulo();
            EntidadesWeb.Articulo articulo = null;
            EntidadesWeb.PresentacionArticulo presentacionArticulo = null;
            int IdArticulo = int.MinValue;
            int IdPresentacionArticulo = int.MinValue;

            if (int.TryParse(idAarticulo, out IdArticulo) == false || int.TryParse(idPresentacionArticulo, out IdPresentacionArticulo) == false)
            {
                return false;
            }

            // Control de Error 410 en Artículo
            // -Primero verificar que no esté en la variable de aplicación, en caso de no estar, se busca en base de datos.
            // -Si el artículo no existe en base de datos, 410 acualquier presentación (porque no hay presentaciones)
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(listaArticulos, IdArticulo);

            if (articulo == null)
            {
                // Si el artículo no está en la variable de aplicación...
                // Busqueda en base de datos
                articulo = FachadaArticulo.ConsultarArticuloPorIdArtículo(IdArticulo);
                if (articulo == null)
                {
                    // Si el artículo no existe en base de datos 
                    Context.RewritePath("~/PaginaNoEncontrada410.aspx", true);
                    return true;
                }

                // Si llega aquí es porque el artículo NO existe en variable de aplicación, pero SI en base de datos.
                // no se hace control en este punto porque el artículo puede ser que está por se levantado a variables de aplicación,
                // inactivo, o fuera de línea.
                return false;
            }

            // Control de errores 404 de Articulo y 410 de Presentación de Artículo
            // 1- Si el Artículo EAhorros línea 404
            if (articulo != null) 
            {
                // 1- Si el Artículo Existe en variable de aplicación...
                if (articulo.Activo == false || articulo.ENLinea == false)
                {
                    // 2- Pero está Inactivo 404(cualquier presentación)
                    // 3- Pero está fuera de línea 404(cualquier presentación)
                    Context.RewritePath("~/PaginaNoEncontrada404.aspx", true);
                    return true;
                }

                // 4.1--- Si la presentación buscada NO Existe en variable de aplicación y si en base de datos 404 
                // Obtener la lista de presentaciones de artículos en la memoria del sitio web
                List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulo = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
                presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulo, IdPresentacionArticulo);
                if (presentacionArticulo == null)
                {
                    // como no está en el sitio web, verificamos si está en base de datos.
                    presentacionArticulo = FachadaPresentacionArticulo.ConsultarPorIdPresentacionArticulo(IdPresentacionArticulo);
                    if (true)
                    {
                        // TODO: Terminar
                    }
                }

                // 4.2--- Si la presentación buscada NO Existe En Base de datos 410

                // EVALUAR SI ES NECESARIO IMPLEMENTAR LOS PUNTOS DEL NÚMERAL 5
                // 5--- y la presentación buscada SI Existe en variable de aplicación...
            }

            // Context.RewritePath("~/PaginaNoEncontrada404.aspx", true);
            // return true;

            return false;
        }

        private void CrearCatalogoPDF()
        {
            double ValorTransporte = 18000;

            iTextSharp.text.Font FuenteCabecera = null;
            iTextSharp.text.Font FuenteNombreArticulo = null;
            iTextSharp.text.Font FuentePrecio = null;
            iTextSharp.text.Font FuenteUnidadesDisponibles = null;

            // Creamos el documento con el tamaño de página Carta
            iTextSharp.text.Document DocumentoPdf = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            iTextSharp.text.pdf.PdfWriter ObjPdf = iTextSharp.text.pdf.PdfWriter.GetInstance(
                    DocumentoPdf,
                    new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "CATALOGO.pdf", System.IO.FileMode.Create));

            // Añadir el Titulo y el Autor
            DocumentoPdf.AddTitle("Catalogo");
            DocumentoPdf.AddCreator("Aplicacion");
            DocumentoPdf.Open();

            // Configurarción de la fuenta a utilizar en la cabecera
            FuenteCabecera = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.pdf.PdfPTable TablaPdf = null;
            iTextSharp.text.pdf.PdfPCell CeldaPdf = null;
            iTextSharp.text.Paragraph ParagrafoPdf = null;

            // Escribir Cabeza del Cocumento, una tabla con solo dos celdas
            TablaPdf = new iTextSharp.text.pdf.PdfPTable(2);

            // Celda con el logo en la cabecera del documento
            CeldaPdf = new iTextSharp.text.pdf.PdfPCell();
            CeldaPdf.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //iTextSharp.text.Image ImagenLogo = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "LogoSitioWeb.jpg");
            //ImagenLogo.ScalePercent(25, 25);
            //CeldaPdf.AddElement(ImagenLogo);
            TablaPdf.AddCell(CeldaPdf);

            // Celda con texto de cabecera de documento
            CeldaPdf = new iTextSharp.text.pdf.PdfPCell();
            CeldaPdf.Border = iTextSharp.text.Rectangle.NO_BORDER;
            ParagrafoPdf = new iTextSharp.text.Paragraph("", FuenteCabecera);
            ParagrafoPdf.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
            CeldaPdf.AddElement(ParagrafoPdf);

            TablaPdf.AddCell(CeldaPdf);
            DocumentoPdf.Add(TablaPdf);
            // DocumentoPdf.Add(iTextSharp.text.Chunk.NEWLINE);

            // Crear tabla a tres columnas y la celda para trabajar
            TablaPdf = new iTextSharp.text.pdf.PdfPTable(3);
            TablaPdf.WidthPercentage = 100;

            // Obtener la lista de atículos del catálogo
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos = this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            List<EntidadesWeb.Articulo> ListaArticulos = this.Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;

            // Ordenamiento por Categoría, Marca y Alfabético
            ListaArticulos = ListaArticulos.OrderBy(c => c.Categoria.IdCategoria)
                               .ThenBy(m => m.Marca.IdMarca)
                               .ThenBy(a => a.Titulo).ToList();

            // Imprimir las presentaciones del artículo recorriendo los artículos principales
            for (int i = 0; i < ListaArticulos.Count; i++)
            {
                ListaPresentacionArticulos = ListaArticulos[i].PresentacionesDelArticulo;
                for (int j = 0; j < ListaPresentacionArticulos.Count; j++)
                {
                    // Crear la celda para añadir a la tabla
                     CeldaPdf = new iTextSharp.text.pdf.PdfPCell();

                    // Obtener la imágen, prepararla y añadirla
                    string DireccionImagen = AppDomain.CurrentDomain.BaseDirectory + "ImagenesArticulo\\" + ListaPresentacionArticulos[j].Fecha.ToString("yyyy-MM-dd") + "\\" + ListaPresentacionArticulos[j].IdPresentacionArticulo + "A.jpg";
                    // string DireccionImagen = "C:\\todo_ventas_colombia\\WebPublica\\ImagenesArticulo\\" + ListaPresentacionArticulos[j].Fecha.ToString("yyyy-MM-dd") + "\\" + ListaPresentacionArticulos[j].IdPresentacionArticulo + "A.jpg";
                    if (System.IO.File.Exists(DireccionImagen))
                    {
                        iTextSharp.text.Image ImagenArticulo = iTextSharp.text.Image.GetInstance(DireccionImagen);
                        ImagenArticulo.ScaleAbsolute(150, 150);
                        ImagenArticulo.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                        CeldaPdf.AddElement(ImagenArticulo);
                    }
                    
                    // Añadir el nombre de la presentación de artículo 
                    FuenteNombreArticulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                    CeldaPdf.AddElement(new iTextSharp.text.Paragraph(ListaPresentacionArticulos[j].Nombre, FuenteNombreArticulo));

                    // Añadir el precio con formato y alineado al centro
                    FuentePrecio = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                    // System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name);
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
                    culture.NumberFormat.CurrencyDecimalDigits = 0; // para dar formato al precio
                    ParagrafoPdf = new iTextSharp.text.Paragraph();
                    if (ListaPresentacionArticulos[j].UsarDescuento == true && DateTime.Now > ListaPresentacionArticulos[j].FechaInicioDescuento && DateTime.Now < ListaPresentacionArticulos[j].FechaFinalDescuento)
                    {
                        double precio = ListaPresentacionArticulos[j].Precio - ValorTransporte;
                        double precioConDescuento = double.MinValue;

                        if (ListaPresentacionArticulos[j].UsarPorcentajeDescuento == true)
                        {
                            precioConDescuento = precio * (100 - ListaPresentacionArticulos[j].ValorPorcentajeDescuento) / 100;
                        }

                        if (ListaPresentacionArticulos[j].UsarValorFijoDescuento == true)
                        {
                            precioConDescuento = precio - ListaPresentacionArticulos[j].ValorFijoDescuento;
                        }
                        
                        ParagrafoPdf.Add(new iTextSharp.text.Chunk(precio.ToString("C", culture), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.STRIKETHRU, iTextSharp.text.BaseColor.RED)));

                        ParagrafoPdf.Add(new iTextSharp.text.Chunk(" / " + precioConDescuento.ToString("C", culture), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));

                        // ParagrafoPdf.Add(new iTextSharp.text.Chunk(" Válido Hasta: " + ListaPresentacionArticulos[j].FechaFinalDescuento.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                    }
                    else
                    {
                        ParagrafoPdf = new iTextSharp.text.Paragraph((ListaPresentacionArticulos[j].Precio - ValorTransporte).ToString("C", culture), FuentePrecio);
                    }
                    ParagrafoPdf.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                    CeldaPdf.AddElement(ParagrafoPdf);

                    // Añadir las unidades disponibles alineado al centro
                    FuenteUnidadesDisponibles = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                    ParagrafoPdf = new iTextSharp.text.Paragraph("Unidades Disponibles: " + ListaPresentacionArticulos[j].Existencias, FuenteUnidadesDisponibles);
                    ParagrafoPdf.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                    CeldaPdf.AddElement(ParagrafoPdf);

                    // Añadir la fecha de Vencimiento
                    if (ListaPresentacionArticulos[j].Existencias > 0 && ListaPresentacionArticulos[j].FechaProximoVencimiento > DateTime.Parse("01/01/2020") && ListaPresentacionArticulos[j].UsarFechaProximoVencimiento == true)
                    {
                        ParagrafoPdf = new iTextSharp.text.Paragraph("Vencimiento Producto: " + ListaPresentacionArticulos[j].FechaProximoVencimiento.ToShortDateString(), FuenteUnidadesDisponibles);
                        ParagrafoPdf.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                        CeldaPdf.AddElement(ParagrafoPdf);
                    }

                    if (ListaPresentacionArticulos[j].Existencias == 0)
                    {
                        // Añadir las unidades disponibles alineado al centro
                        ParagrafoPdf = new iTextSharp.text.Paragraph("AGOTADO: Regresará Pronto");
                        ParagrafoPdf.Font.Color = iTextSharp.text.BaseColor.RED;
                        ParagrafoPdf.Alignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                        CeldaPdf.AddElement(ParagrafoPdf);
                    }

                    TablaPdf.AddCell(CeldaPdf);
                }

                // investigar si es el último artículo y Añadir las celdas vacías que hacen falta para completar la fila (de 3 celdas)
                if (ListaArticulos.Count == i + 1)
                {
                    int Faltantes = ListaArticulos.Count % 3;
                    System.Diagnostics.Debug.WriteLine("Faltantes: " + Faltantes.ToString());

                    for (int k = 0; k < Faltantes; k++)
                    {   
                        CeldaPdf = new iTextSharp.text.pdf.PdfPCell();
                        CeldaPdf.AddElement(new iTextSharp.text.Paragraph(string.Empty));
                        TablaPdf.AddCell(CeldaPdf);
                    }
                }
            }

            DocumentoPdf.Add(TablaPdf);
            DocumentoPdf.Close();
            ObjPdf.Close();
        }

        private void CrearListaPresentacionArticuloInvertida()
        {
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulo = this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticuloInvertida = new List<EntidadesWeb.PresentacionArticulo>();

            for (int i = 0; i < ListaPresentacionArticulo.Count; i++)
            {
                ListaPresentacionArticuloInvertida.Insert(0, ListaPresentacionArticulo[i]);
            }

            this.Application["ListaPresentacionArticuloInvertida"] = ListaPresentacionArticuloInvertida;
        }

        private void CrearListaArticuloInvertida()
        {
            List<EntidadesWeb.Articulo> listarticulo = this.Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
            List<EntidadesWeb.Articulo> listaArticuloInvertida = new List<EntidadesWeb.Articulo>();

            for (int i = 0; i < listarticulo.Count; i++)
            {
                listaArticuloInvertida.Insert(0, listarticulo[i]);
            }

            this.Application["ListaArticuloInvertida"] = listaArticuloInvertida;
        }

        public void CargarVariableSesionUrlBase()
        {
            Session["UrlBase"] = Request.Url.Scheme + "://" + Request.Url.Authority + "/";
        }
        #endregion
    }
}