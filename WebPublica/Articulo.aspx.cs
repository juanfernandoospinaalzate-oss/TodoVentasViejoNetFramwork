// -----------------------------------------------------------------------
// <copyright file="Articulo.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    /// <summary>
    /// Página para la presentación de los artículos y sus respectivas presentaciones configuradas en la aplicación
    /// </summary>
    public partial class Articulo : System.Web.UI.Page
    {
        /// <summary>
        /// Configura el procedimiento de evento para la carga de los datos al final de la carga de la página
        /// </summary>
        /// <param name="sender">Objeto que desata el evento</param>
        /// <param name="e">Argumentos para el procedimiento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += this.Articulo_LoadComplete;
        }

        /// <summary>
        /// Obtiene todos los datos necesarios de artículo para carga la página incluyendo todas las presentaciones configuradas
        /// </summary>
        /// <param name="sender">Objeto que desata el evento</param>
        /// <param name="e">Argumentos para el procedimiento de evento</param>
        protected void Articulo_LoadComplete(object sender, EventArgs e)
        {
            List<EntidadesWeb.Articulo> listaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            List<EntidadesWeb.UnidadMasa> listaUnidadMasa = Application["ListaUnidadMasa"] as List<EntidadesWeb.UnidadMasa>;

            int idArticuloBuscado = 0;
            int idPresentacionArticuloBuscado = idArticuloBuscado = int.Parse(Request.Params[0].ToString());
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            EntidadesWeb.Articulo articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(listaArticulos, idArticuloBuscado);
            EntidadesWeb.PresentacionArticulo presentacionArticulo = null;

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

                BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb BusquedasSecuencialesWeb = new BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb();
                presentacionArticulo = BusquedasSecuencialesWeb.BusquedaSecuencialPresentacionArticulo(articulo.PresentacionesDelArticulo, filtros, valoresFiltros);
            }
            else
            {
                // cuando no es un postback se toman los id de la url
                idPresentacionArticuloBuscado = int.Parse(Request.Params[1].ToString());

                // Obtener los datos de la presentación de artículo que se va a mostrar inicialmente.
                presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulos, idPresentacionArticuloBuscado);
            }

            if (presentacionArticulo == null)
            {
                HiddenFieldIdPresentacionArticulo.Value = "0";
            }
            else
            {
                HiddenFieldIdPresentacionArticulo.Value = presentacionArticulo.IdPresentacionArticulo.ToString();
            }
            
            WucImagenesArticulo.Asignacion_Inicial_Imagenes(presentacionArticulo);

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
                WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Longitud, presentacionArticulo.VlrUnidadLongitud.ToString());
            }

            if (articulo.Talla == true)
            {
                WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Talla, presentacionArticulo.Talla.IdTalla.ToString());
            }

            if (articulo.Color == true)
            {
                WucFiltroArticulo1.AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro.Color, presentacionArticulo.Color.IdColor.ToString());
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

            LblDescripcionBreve.InnerHtml = articulo.Descripcion + "</br>";

            if (presentacionArticulo == null)
            {
                LblPrecio.InnerHtml = "Valor No Disponible";
            }
            else
            {
                LblPrecio.InnerHtml = presentacionArticulo.Precio.ToString();
            }
            
        }

        protected void BtnAnadirAlCarrito_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();
            EntidadesWeb.ItemCarrito itemCarrito = new EntidadesWeb.ItemCarrito();
            int idPresentacionArticulo = 0;
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            
            idPresentacionArticulo = int.Parse(this.Request["IdPresentacionArticulo"]);
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            EntidadesWeb.PresentacionArticulo presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ListaPresentacionArticulos, idPresentacionArticulo);
            itemCarrito.IdPrestacionArticulo = idPresentacionArticulo;
            itemCarrito.Cantidad = int.Parse(TxtCantidad.Text);
            itemCarrito.Nombre = presentacionArticulo.Nombre;
            itemCarrito.Precio = presentacionArticulo.Precio;

            double subTotal = double.Parse((itemCarrito.Cantidad * itemCarrito.Precio).ToString());
            
            // Cuando se agregan elementos al carrito sin haberse logueado (IdUsuario es nulo).
            if (this.Session["TicketUsuario"] == null)
            {
                List<EntidadesWeb.ItemCarrito> ListaCarritoModoInvitado = null;

                // verificar si ya hay un carrito en "modo invitado"
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
                    BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb BusquedasBinariasSecuencialesWeb = new BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb();
                    EntidadesWeb.ItemCarrito itemBuscado = BusquedasBinariasSecuencialesWeb.BusquedaSecuencialItemCarritoPorId(ListaCarritoModoInvitado, itemCarrito.IdPrestacionArticulo);

                    if (itemBuscado == null)
                    {
                        // si el nuevo item no existe en el carrito, entonces se añade como un item nuevo
                        ListaCarritoModoInvitado.Add(itemCarrito);
                    }
                    else
                    {
                        // si el nuevo item ya existe entonces se acumulan las unidades que el usuario desea añadir
                        itemBuscado.Cantidad += itemCarrito.Cantidad;
                    }
                }

                this.Session["ListaCarritoModoInvitado"] = ListaCarritoModoInvitado;
            }
            else
            {
                itemCarrito.IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
                carrito.Insertar(itemCarrito);
            }

            Response.Redirect("/Carrito.aspx", false);
        } 
    }
}