//-----------------------------------------------------------------------
// <copyright file="WucResultadoCajaListado.ascx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class WucResultadocajaListado : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.LoadComplete += this.Page_LoadComplete;
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            int tamanioPagina = int.MinValue; // Número de artículos por página
            int cantidadPaginas = int.MinValue;
            int paginaActual = int.MinValue;
            int IndiceInicialPresentacionesArticulosPorPagina = int.MinValue;
            List<string> ListaPaginas = new List<string>(); // Contiene la númeración desde 1 hasta N de la paginación
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionesAticulos = null; // lista completa de todas las presentaciones de articulo disponibles
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionesArticulosPaginaActual = new List<EntidadesWeb.PresentacionArticulo>(); // Lista de los artículos que se muestran en la página actual

            // Verificar que el tamaño de página sea seleccionada y no escrito arbitrariamente en el url
            if (Request.QueryString["PageSize"] != null)
            {
                tamanioPagina = int.Parse(Request.QueryString["PageSize"]);
                HiddenFieldTamanioPagina.Value = Request.QueryString["PageSize"];
                // style="font-weight:bold"
                switch (tamanioPagina)
                {
                    case 10:
                        this.LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                        this.LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
                        break;
                    case 25:
                        this.LinkButtonTamanioPagina25.Style["font-weight"] = "bold";
                        this.LinkButtonTamanioPagina25.Style["text-decoration"] = "underline";
                        break;
                    case 50:
                        this.LinkButtonTamanioPagina50.Style["font-weight"] = "bold";
                        this.LinkButtonTamanioPagina50.Style["text-decoration"] = "underline";
                        break;
                    case 100:
                        this.LinkButtonTamanioPagina100.Style["font-weight"] = "bold";
                        this.LinkButtonTamanioPagina100.Style["text-decoration"] = "underline";
                        break;
                    default:
                        // Si modifican el tamaño de pagina desde la url a un tamaño no predeterminado
                        tamanioPagina = 10;
                        this.HiddenFieldTamanioPagina.Value = tamanioPagina.ToString();
                        this.LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                        this.LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
                        break;
                }
            }
            else 
            {
                // Si no se especifica el tamaño de página se establece el predeterminado a 10 elementos
                tamanioPagina = 10;
                this.HiddenFieldTamanioPagina.Value = tamanioPagina.ToString();
                this.LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                this.LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
            }

            // Obtener la lista de las presentaciones de artículo según sea una búsqueda o nó sea una busqueda
            if (this.Request.QueryString["CadenaBusqueda"] == null)
            {
                // Se cargan todas las presentaciones disponibles.
                listaPresentacionesAticulos = this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
                
                listaPresentacionesAticulos = this.Application["ListaPresentacionArticuloInvertida"] as List<EntidadesWeb.PresentacionArticulo>;
            }
            else 
            {
                // Cargar las presentaciones según la cadena de busqueda
                // Obtenemos la cadena de busqueda para guardar el texto de la busqueda, hacer el conteo y luego realizar la busqueda.
                string TextoBusqueda = this.Request.QueryString["CadenaBusqueda"];

                // Se registra el texto de la busqueda o hace conteo del texto de la busqueda.
                System.Threading.Thread delegado = new System.Threading.Thread(WucResultadocajaListado.InsertarBusqueda);
                delegado.Start(TextoBusqueda); 

                // realizar la busqueda consultando solo los Id correspondientes.
                System.Collections.ObjectModel.ReadOnlyCollection<double> ListaArticulosResultadosBusqueda = null;
                Fachada.WebPublica.Busqueda Busqueda = new Fachada.WebPublica.Busqueda();
                ListaArticulosResultadosBusqueda = Busqueda.Buscar(TextoBusqueda);
                List<EntidadesWeb.PresentacionArticulo> TemplistaPresentacionesAticulos = this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
                List<EntidadesWeb.Articulo> TempListaArticulos = this.Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
                listaPresentacionesAticulos = new List<EntidadesWeb.PresentacionArticulo>();
                BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedaBinariaWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();

                try
                {
                    // Obtenemos los datos correspondientes a los Ids en la variable listaPresentacionesAticulos
                    for (int i = 0; i < ListaArticulosResultadosBusqueda.Count; i++)
                    { 
                        // ListaArticulosResultadosBusqueda[i]
                        EntidadesWeb.Articulo Articulo = BusquedaBinariaWeb.BusquedaBinariaArticuloPorIdArticulo(TempListaArticulos, ListaArticulosResultadosBusqueda[i]);

                        if (Articulo != null)
                        {
                            for (int j = 0; j < Articulo.PresentacionesDelArticulo.Count; j++)
                            {
                                double IdPresentacionArticulo = Articulo.PresentacionesDelArticulo[j].IdPresentacionArticulo;
                                EntidadesWeb.PresentacionArticulo PresentacionArticulo = BusquedaBinariaWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(TemplistaPresentacionesAticulos, IdPresentacionArticulo);
                                if (PresentacionArticulo != null)
                                {
                                    listaPresentacionesAticulos.Add(PresentacionArticulo);
                                }
                            } 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.ErrorGeneral.Guardar(ex);
                }
                
            }
            
            // Determinar la cantidad de páginas
            cantidadPaginas = listaPresentacionesAticulos.Count / tamanioPagina;
            if (listaPresentacionesAticulos.Count % tamanioPagina > 0)
            {
                // Si la división tiene sobrante se añade una pagina más.
                cantidadPaginas = cantidadPaginas + 1;
            }

            // listar desde 1 hasta N las páginas calculadas
            for (int i = 1; i <= cantidadPaginas; i++)
            {
                ListaPaginas.Add(i.ToString());
            }
            
            // establecer la página actual
            if (this.Request.QueryString["Page"] == null)
            {
                paginaActual = 1;

                // Si es la primera página se oculta el botón "Anterior" y se muestra el botón "Siguiente"
                this.LinkButtonAnterior.Visible = false;
                this.LinkButtonSiguiente.Visible = true;
            }
            else 
            {
                // Cuando se está pidiendo una página especifica
                paginaActual = int.Parse(Request.QueryString["Page"]);

                // Si se intenta pasar a una página que no existe modificando la url, se pasa a la página 1
                if (paginaActual > cantidadPaginas)
                {
                    paginaActual = 1;
                }

                // El botón "Anterior" se oculta, pero solo cuando se está imprimiendo la primera página
                if (paginaActual == 1)
                {
                    this.LinkButtonAnterior.Visible = false;
                }
                else
                {
                    this.LinkButtonAnterior.Visible = true;
                }
                
                // El botón "siguiente" se oculta, pero no cuando se está imprimiendo la últma página
                if (paginaActual == cantidadPaginas)
                {
                    this.LinkButtonSiguiente.Visible = false;
                }
                else
                {
                    this.LinkButtonSiguiente.Visible = true;
                }
            }

            // Listar los artículos correspondientes a la página actual
            IndiceInicialPresentacionesArticulosPorPagina = (paginaActual - 1) * tamanioPagina; // Calcula el indice inicial del primero de los N artículos que se muestran
            for (int i = IndiceInicialPresentacionesArticulosPorPagina; i < (IndiceInicialPresentacionesArticulosPorPagina + tamanioPagina); i++)
            {
                // Evitar desbordamiento en el indice
                if (i < listaPresentacionesAticulos.Count) 
                {
                    ListaPresentacionesArticulosPaginaActual.Add(listaPresentacionesAticulos[i]);
                }
            }

            this.Repeater1.DataSource = ListaPresentacionesArticulosPaginaActual;
            this.Repeater1.DataBind();

            this.RepeaterPaginacion.DataSource = ListaPaginas;
            this.RepeaterPaginacion.DataBind();

            // Mostrar información sobre el cantidad de elementos mostrados
            this.LblInformacionPaginacion.Text = "Mostrando artículos del " + (paginaActual * tamanioPagina - tamanioPagina + 1).ToString() + " al " + (paginaActual * tamanioPagina - tamanioPagina + ListaPresentacionesArticulosPaginaActual.Count).ToString() + " de " + listaPresentacionesAticulos.Count;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            (e.Item.FindControl("WucResultadoCaja") as ControlesDeUsuario.WucResultadoCaja).PresentacionArticulo = e.Item.DataItem as EntidadesWeb.PresentacionArticulo;
        }

        protected void RepeaterPaginacion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.LinkButton Boton = e.Item.FindControl("LinkButtonNroPagina") as System.Web.UI.WebControls.LinkButton;
            Boton.Text = e.Item.DataItem as string;
            Boton.CommandArgument = Boton.Text;
        }

        protected void LinkButtonNroPagina_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;

            if (this.Request["CadenaBusqueda"] == null)
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + linkButton.CommandArgument + "&PageSize=" + this.HiddenFieldTamanioPagina.Value, false);
            }
            else
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + linkButton.CommandArgument + "&PageSize=" + this.HiddenFieldTamanioPagina.Value + "&CadenaBusqueda=" + this.Request["CadenaBusqueda"], false);
            }
        }

        protected void LinkButtonTamanioPagina_Click(object sender, EventArgs e)
        {
            // Evitar que no se especifique  un tamaño de página
            LinkButton linkButton = sender as LinkButton;
            HiddenFieldTamanioPagina.Value = linkButton.CommandArgument;

            if (this.Request["CadenaBusqueda"] == null)
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=1" + "&PageSize=" + linkButton.CommandArgument, false);
            }
            else
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=1" + "&PageSize=" + linkButton.CommandArgument + "&CadenaBusqueda=" + this.Request["CadenaBusqueda"], false);
            }
        }

        protected void LinkButtonAnterior_Click(object sender, EventArgs e)
        {
            int Pagina = int.Parse(this.Request["Page"]);
            int TamanioPagina = int.Parse(this.Request["PageSize"]);

            Pagina = Pagina - 1;

            if (this.Request["CadenaBusqueda"] == null)
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + Pagina + "&PageSize=" + this.Request["PageSize"], false);
            }
            else
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + Pagina + "&PageSize=" + this.Request["PageSize"] + "&CadenaBusqueda=" + this.Request["CadenaBusqueda"], false);
            }
            
        }

        protected void LinkButtonSiguiente_Click(object sender, EventArgs e)
        {
            int Pagina = int.MinValue;
            int TamanioPagina = int.MinValue;

            // Verificar si se especificó una página
            if (int.TryParse(this.Request["Page"], out Pagina) == false)
            {
                // Si no se especificó una pagína
                Pagina = 1;
            }

            // Verificar si se especificó un tamaño de página
            if (int.TryParse(this.Request["PageSize"], out TamanioPagina) == false)
            {
                // Si no se especificó un tamaño de página
                TamanioPagina = 10;
            }

            Pagina = Pagina + 1;

            if (this.Request["CadenaBusqueda"] == null)
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + Pagina + "&PageSize=" + TamanioPagina, false);
            }
            else
            {
                this.Response.Redirect("ResultadoCaja.aspx?Page=" + Pagina + "&PageSize=" + TamanioPagina + "&CadenaBusqueda=" + this.Request["CadenaBusqueda"], false);
            }
        }

        public static void InsertarBusqueda(object textoBusqueda)
        {
            Fachada.WebPublica.Busqueda Busqueda = new Fachada.WebPublica.Busqueda();
            Busqueda.Insertar(textoBusqueda.ToString());
        }
    }
}