

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += this.DetalleArticulo_LoadComplete;
        }

        void DetalleArticulo_LoadComplete(object sender, EventArgs e)
        {
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            List<EntidadesWeb.UnidadMasa> listaUnidadMasa = Application["ListaUnidadMasa"] as List<EntidadesWeb.UnidadMasa>;
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();

            int idArticuloBuscado = int.Parse(Request.Params[0].ToString());
            int idPresentacionArticuloBuscado = int.Parse(Request.Params[1].ToString());
            double precio = double.MinValue;
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb BusquedasSecuencialesWeb = new BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb();
            EntidadesWeb.Articulo articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(listaArticulos, idArticuloBuscado);
            EntidadesWeb.PresentacionArticulo presentacionArticulo = null;
            string rutaUrlCompletaCruda = "/" + Request.RawUrl.Remove(0, 1);

            if (Page.IsPostBack == true)
            {
                // Cuando es un postback es porque se pulsó un filtro (peso, volumen, color, etc)
                List<string> filtros = new List<string>();
                List<string> valoresFiltros = new List<string>();

                if (WucFiltroArticulo1.FiltroSeleccionado1 != string.Empty)
                {
                    filtros.Add(WucFiltroArticulo1.FiltroSeleccionado1);
                    valoresFiltros.Add(WucFiltroArticulo1.ValorFiltroSeleccionado1);
                }

                if (WucFiltroArticulo1.FiltroSeleccionado2 != string.Empty)
                {
                    filtros.Add(WucFiltroArticulo1.FiltroSeleccionado2);
                    valoresFiltros.Add(WucFiltroArticulo1.ValorFiltroSeleccionado2);
                }

                if (WucFiltroArticulo1.FiltroSeleccionado3 != string.Empty)
                {
                    filtros.Add(WucFiltroArticulo1.FiltroSeleccionado3);
                    valoresFiltros.Add(WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }

                presentacionArticulo = BusquedasSecuencialesWeb.BusquedaSecuencialPresentacionArticulo(articulo.PresentacionesDelArticulo, filtros, valoresFiltros);
            }
            else
            {
                // cuando no es un postback se toman los id de la url
                idPresentacionArticuloBuscado = int.Parse(Request.Params[1].ToString());

                // Obtener los datos de la presentación de artículo que se va a mostrar inicialmente.
                presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulos, idPresentacionArticuloBuscado);
            }

            DdlCantidad.Items.Clear(); // antes de cargar las cantidades de existencias eliminar las cantidades de la presentación seleccionada anteriormente
            if (presentacionArticulo == null)
            {
                HiddenFieldIdPresentacionArticulo.Value = "0";
            }
            else
            {
                // Cuando hay existencias en cero, se debe presentar como fuera de stock
                if (presentacionArticulo.Existencias == 0)
                {
                    // Ocultar etiqueta de cantidad
                    LiteralCantidad.Visible = false;

                    // Ocultar el DropdownList
                    DdlCantidad.Visible = false;

                    // Mostrar Mensaje indicando que no hay existencias en inventario
                    LblMensajeCantidad.Visible = true;

                    // Establecer el mensaje
                    LblMensajeCantidad.Text = "AGOTADO: Más unidades en camino";

                    // Ocultar Botón "añadir al carrito"
                    BtnAniadirAlCarrito.Visible = false;
                }
                else 
                {
                    // Si hay existencias se cargan las cantidades.
                    // Mostrar etiqueta de cantidad
                    LiteralCantidad.Visible = true;

                    // Cargar el DropDownList con las cantidades
                    for (int i = 1; i < presentacionArticulo.Existencias + 1; i++)
                    {
                        DdlCantidad.Items.Add(i.ToString());
                        if (i == 6)
                        {
                            break;
                        }
                    }

                    // Asegurar no mostrar mensaje indicando que no hay existencias en inventario
                    LblMensajeCantidad.Visible = false;

                    // Mostrar el botón "añadir al carrito"
                    BtnAniadirAlCarrito.Visible = true;
                }

                HiddenFieldIdPresentacionArticulo.Value = presentacionArticulo.IdPresentacionArticulo.ToString();
            }

            WucImagenesArticuloPgwSlider.Asignacion_Inicial_Imagenes(presentacionArticulo);

            // Los filtros se crean con la primera carga de la página, luego se mantienen con el viewstate
            if (Page.IsPostBack == false)
            {
                WucFiltroArticulo1.Crear_Filtros(articulo);
            }

            WucFiltroArticulo1.ResetearEstilosFiltros();

            // Según el filtro seleccionado
            // Si el filtro de Volumen se encuentra Activo
            if (articulo.UnidadVolumen == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Volumen, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Volumen, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Volumen, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Volumen, presentacionArticulo.VlrContenidoVolumetrico.ToString());
                }
            }

            if (articulo.UnidadMasa == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Masa, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Masa, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Masa, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Masa, presentacionArticulo.VlrUnidadMasa.ToString());
                }
            }

            if (articulo.UnidadLongitud == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Longitud, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Longitud, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Longitud, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Longitud, presentacionArticulo.VlrUnidadLongitud.ToString());
                }
            }

            if (articulo.Talla == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Talla, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Talla, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Talla, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Talla, presentacionArticulo.Talla.IdTalla.ToString());
                }
            }

            if (articulo.Color == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Color, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Color, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Color, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Color, presentacionArticulo.Color.IdColor.ToString());
                }
            }

            if (articulo.Sabor == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Sabor, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Sabor, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Sabor, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Sabor, presentacionArticulo.Sabor.IdSabor.ToString());
                }
            }

            if (articulo.UnidadPresentacion == true)
            {
                if (presentacionArticulo == null)
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion, WucFiltroArticulo1.ValorFiltroSeleccionado1);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion, WucFiltroArticulo1.ValorFiltroSeleccionado2);
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion, WucFiltroArticulo1.ValorFiltroSeleccionado3);
                }
                else
                {
                    WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion, presentacionArticulo.VlrUnidadPresentacion.ToString());
                }
            }

            string DescripcionArticulo = ObtenerTextoFormateado(articulo.Descripcion);
            string MetaDescripción = ObtenerTextoFormateado(presentacionArticulo.DescripcionBreve);
            LitDescripcionArticulo.Text = $"{DescripcionArticulo}<br/><br/>{MetaDescripción}";

            if (presentacionArticulo == null)
            {
                LitPrecioArticulo.Text = "Valor No Disponible";
            }
            else
            {
                LitTituloArticulo.Text = presentacionArticulo.Nombre;
                LitDescripcionCortaArticulo.Text = presentacionArticulo.DescripcionBreve;

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
                culture.NumberFormat.CurrencyDecimalDigits = 0;

                precio = presentacionArticulo.Precio;

                if (presentacionArticulo.UsarDescuento == true && presentacionArticulo.FechaInicioDescuento < DateTime.Now && presentacionArticulo.FechaFinalDescuento > DateTime.Now)
                {
                    this.LitPrecioArticulo.Text = "<span style=\"text-decoration: line-through double;\">" + precio.ToString("C", culture) + " </span>/ ";
                    if (presentacionArticulo.UsarPorcentajeDescuento == true)
                    {
                        this.LitPrecioArticulo.Text += (precio * (100 - presentacionArticulo.ValorPorcentajeDescuento) / 100).ToString("C", culture);
                    }

                    if (presentacionArticulo.UsarValorFijoDescuento == true)
                    {
                        LitPrecioArticulo.Text += (precio - presentacionArticulo.ValorFijoDescuento).ToString("C", culture);
                    }
                }
                else
                {
                    this.LitPrecioArticulo.Text = precio.ToString("C", culture);
                }
            }

            ImgActualizando.ImageUrl = "/Graficas/Iconos/cargando_01.gif";

            // Configuración de los botones para compartir en redes sociales
            this.BtnFacebook.Attributes.Add("onClick", "window.open('https://www.facebook.com/sharer/sharer.php?u=" + rutaUrlCompletaCruda + "')");
            this.BtnGooglePlus.Attributes.Add("onClick", "window.open('https://plus.google.com/share?url=" + rutaUrlCompletaCruda + "')");
            this.BtnTwitter.Attributes.Add("onClick", "window.open('https://twitter.com/?status=" + rutaUrlCompletaCruda + "')");

            // Lenado de las meta tags
            Page.MetaDescription = articulo.MetaDescripcion;
            Page.MetaKeywords = articulo.MetaKeyWords;
        }

        private static string ObtenerTextoFormateado(string texto)
        {
            string DescripcionFormateada = string.Empty;
            foreach (char item in texto)
            {
                if (item.Equals('\r') || item.Equals('\n'))
                {
                    if (item.Equals('\n'))
                    {
                        DescripcionFormateada += "<br/>";
                    }
                }
                else
                {
                    DescripcionFormateada += item;
                }
            }

            return DescripcionFormateada;
        }

        protected void BtnAniadirAlCarrito_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();
            EntidadesWeb.ItemCarrito itemCarrito = new EntidadesWeb.ItemCarrito();
            int idPresentacionArticulo = 0;
            string rutaUrlBase = string.Empty;
            ValidacionesComunes.Validacion validacion = new ValidacionesComunes.Validacion();
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;

            idPresentacionArticulo = int.Parse(HiddenFieldIdPresentacionArticulo.Value);
            // idPresentacionArticulo = int.Parse(Request["IdPresentacionArticulo"]);
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            EntidadesWeb.PresentacionArticulo presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ListaPresentacionArticulos, idPresentacionArticulo);
            itemCarrito.IdPrestacionArticulo = idPresentacionArticulo;
            itemCarrito.Cantidad = int.Parse(DdlCantidad.Text);
            itemCarrito.Nombre = presentacionArticulo.Nombre;
            itemCarrito.Precio = presentacionArticulo.Precio;

            double subTotal = double.Parse((itemCarrito.Cantidad * itemCarrito.Precio).ToString());

            // Cuando se agregan elementos al carrito sin haberse logueado (IdUsuario es nulo).
            if (this.Session["TicketUsuario"] == null)
            {
                List<EntidadesWeb.ItemCarrito> ListaCarritoModoInvitado = null;

                // veriicar si ya hay un carrito en "modo invitado"
                if (this.Session["ListaCarritoModoInvitado"] == null)
                {
                    // Si no hay carrito en modo invitado se crea añadiendo el primer elemento
                    ListaCarritoModoInvitado = new List<EntidadesWeb.ItemCarrito>();
                    ListaCarritoModoInvitado.Add(itemCarrito);
                    this.Session["ListaCarritoModoInvitado"] = ListaCarritoModoInvitado;
                }
                else
                {
                    // Si ya hay carrito en modo invitado se añade el elemento
                    // en caso de ya existir el item en el carrito, se añaden las unidades correspondientes
                    ListaCarritoModoInvitado = Session["ListaCarritoModoInvitado"] as List<EntidadesWeb.ItemCarrito>;
                    BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb BusquedasSecuencialesWeb = new BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb();
                    EntidadesWeb.ItemCarrito itemBuscado = BusquedasSecuencialesWeb.BusquedaSecuencialItemCarritoPorId(ListaCarritoModoInvitado, itemCarrito.IdPrestacionArticulo);

                    if (itemBuscado == null)
                    {
                        // si el nuevo item no existe en el carrito, entonces se añade como un item nuevo
                        ListaCarritoModoInvitado.Add(itemCarrito);
                    }
                    else
                    {
                        // si el nuevo item ya existe entonces se acumulan las unidades que el usuario desea añadir
                        itemBuscado.Cantidad = validacion.ControlCantidadDisponible(presentacionArticulo.Existencias, int.Parse(DdlCantidad.Text), itemBuscado.Cantidad);
                    }
                }

                this.Session["ListaCarritoModoInvitado"] = ListaCarritoModoInvitado;
            }
            else
            {
                itemCarrito.IdUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);

                // Consultar en la tabla de carrito
                EntidadesWeb.ItemCarrito ItemCarritoEnBaseDatos = carrito.ConsultarPorIdPresentacionArticulo(itemCarrito.IdPrestacionArticulo, itemCarrito.IdUsuario);

                // Si el item está en la tabla de carrito, se utiliza y actualiza la cantidad en el carrito
                if (ItemCarritoEnBaseDatos != null)
                {
                    itemCarrito.Cantidad = validacion.ControlCantidadDisponible(presentacionArticulo.Existencias, int.Parse(DdlCantidad.Text), ItemCarritoEnBaseDatos.Cantidad);
                    itemCarrito.IdItemCarrito = ItemCarritoEnBaseDatos.IdItemCarrito;
                    carrito.Actualizar(itemCarrito);
                }
                else
                {   // si el item no está en la tabla de carrito, se inserta
                    itemCarrito.Cantidad = validacion.ControlCantidadDisponible(presentacionArticulo.Existencias, int.Parse(DdlCantidad.Text), 0);
                    carrito.Insertar(itemCarrito);
                }
            }

            Response.Redirect(rutaUrlBase + "/Carrito.aspx", false);
        }
    }
}