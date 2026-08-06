

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class WucResultadocajaListadoCategoria : System.Web.UI.UserControl
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
                        LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                        LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
                        break;
                    case 25:
                        LinkButtonTamanioPagina25.Style["font-weight"] = "bold";
                        LinkButtonTamanioPagina25.Style["text-decoration"] = "underline";
                        break;
                    case 50:
                        LinkButtonTamanioPagina50.Style["font-weight"] = "bold";
                        LinkButtonTamanioPagina50.Style["text-decoration"] = "underline";
                        break;
                    case 100:
                        LinkButtonTamanioPagina100.Style["font-weight"] = "bold";
                        LinkButtonTamanioPagina100.Style["text-decoration"] = "underline";
                        break;
                    default:
                        // Si modifican el tamaño de pagina desde la url a un tamaño no predeterminado
                        tamanioPagina = 10;
                        HiddenFieldTamanioPagina.Value = tamanioPagina.ToString();
                        LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                        LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
                        break;
                }
            }
            else 
            {
                // Si no se especifica el tamaño de página se establece el predeterminado a 10 elementos
                tamanioPagina = 10;
                HiddenFieldTamanioPagina.Value = tamanioPagina.ToString();
                LinkButtonTamanioPagina10.Style["font-weight"] = "bold";
                LinkButtonTamanioPagina10.Style["text-decoration"] = "underline";
            }

            // Obtener la lista de las presentaciones de artículo según la categoría
            if (Request.QueryString["Categoria"] == null)
            {
                // Se cargan todas las presentaciones disponibles.
                listaPresentacionesAticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            }
            else 
            {
                // Cargar las presentaciones según la cadena de busqueda
                // Obtenemos el id de la categoría a buscar.
                int idCategoria = int.Parse(Request.QueryString["Categoria"]);

                // Obtener la lista ocompleta de categorías y de esta tomar la categoría buscada junto con todas sus subcategorías
                List<EntidadesWeb.Categoria> TempListaCategorias = Application["ListaCategorias"] as List<EntidadesWeb.Categoria>;
                List<EntidadesWeb.Categoria> TempListaCategoriasResultadoBusquedaSecuencial2 = null; // Para resultados en caso de un segundo nivel
                List<EntidadesWeb.Categoria> TempListaCategoriasResultadoBusquedaSecuencial3 = null; // Para resultados en caso de un tercer nivel
                List<EntidadesWeb.Categoria> TempListaCategoriasResultadoBusquedaSecuencial4 = null; // Para resultados en caso de un cuarto nivel
                List<double> TempListaCategoriasFiltradas = new List<double>();
                BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
                BusquedasBinariasSecuenciales.BusquedasSecuenciales BusquedasSecuenciales = new BusquedasBinariasSecuenciales.BusquedasSecuenciales();

                // Se registra el texto de la busqueda o hace conteo del texto de la busqueda.
                System.Threading.Thread delegado = new System.Threading.Thread(WucResultadocajaListado.InsertarBusqueda);
                EntidadesWeb.Categoria categoriaPrincipalBuscada = BusquedasBinariasWeb.BusquedaBinariaCategoriaPorIdCategoria(TempListaCategorias, idCategoria);
                delegado.Start(categoriaPrincipalBuscada.Nombre);

                // Buscar categoría seleccionada, posible primer nivel
                TempListaCategoriasFiltradas.Add(idCategoria);

                // Buscar categorías de un segundo nivel 
                TempListaCategoriasResultadoBusquedaSecuencial2 = BusquedasSecuenciales.BusquedaSecuencialCategoriaPorIdCategoriaPadre(TempListaCategorias, idCategoria);
                for (int i = 0; i < TempListaCategoriasResultadoBusquedaSecuencial2.Count; i++)
                {
                    // Añadir a la lista de subcategorías encontradas
                    TempListaCategoriasFiltradas.Add(TempListaCategoriasResultadoBusquedaSecuencial2[i].IdCategoria);
                }

                // Buscar categorías de un tercer nivel
                for (int i = 0; i < TempListaCategoriasResultadoBusquedaSecuencial2.Count; i++)
                {
                    TempListaCategoriasResultadoBusquedaSecuencial3 = BusquedasSecuenciales.BusquedaSecuencialCategoriaPorIdCategoriaPadre(TempListaCategorias, TempListaCategoriasResultadoBusquedaSecuencial2[i].IdCategoria);

                    for (int j = 0; j < TempListaCategoriasResultadoBusquedaSecuencial3.Count; j++)
                    {
                        // Añadir a la lista de subcategorías encontradas
                        TempListaCategoriasFiltradas.Add(TempListaCategoriasResultadoBusquedaSecuencial3[j].IdCategoria);

                        // Buscar categorías de un cuarto nivel
                        for (int k = 0; k < TempListaCategoriasResultadoBusquedaSecuencial3.Count; k++)
                        {
                            TempListaCategoriasResultadoBusquedaSecuencial4 = BusquedasSecuenciales.BusquedaSecuencialCategoriaPorIdCategoriaPadre(TempListaCategorias, TempListaCategoriasResultadoBusquedaSecuencial3[k].IdCategoria);

                            for (int l = 0; l < TempListaCategoriasResultadoBusquedaSecuencial4.Count; l++)
                            {
                                TempListaCategoriasFiltradas.Add(TempListaCategoriasResultadoBusquedaSecuencial4[l].IdCategoria);
                            }
                        }
                    }
                }
                
                // Preparar la lista de Ids de categoría para ser pasadas por parametro
                System.Collections.ObjectModel.ReadOnlyCollection<double> ParametroListaCategoriasFiltradas = new System.Collections.ObjectModel.ReadOnlyCollection<double>(TempListaCategoriasFiltradas);

                // realizar la busqueda consultando solo los Id de categoría correspondientes.
                Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
                System.Collections.ObjectModel.ReadOnlyCollection<double> ListaArticulosResultadosBusqueda = null;
                ListaArticulosResultadosBusqueda = FachadaArticulo.ListarPorIdsCategorias(ParametroListaCategoriasFiltradas);

                List<EntidadesWeb.PresentacionArticulo> TemplistaPresentacionesAticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
                List<EntidadesWeb.Articulo> TempListaArticulos = Application["ListaArticulos"] as List<EntidadesWeb.Articulo>;
                listaPresentacionesAticulos = new List<EntidadesWeb.PresentacionArticulo>();

                // Obtenemos los datos correspondientes a los Ids en la variable listaPresentacionesAticulos
                for (int i = 0; i < ListaArticulosResultadosBusqueda.Count; i++)
                {
                    // ListaArticulosResultadosBusqueda[i]
                    EntidadesWeb.Articulo Articulo = BusquedasBinariasWeb.BusquedaBinariaArticuloPorIdArticulo(TempListaArticulos, ListaArticulosResultadosBusqueda[i]);

                    for (int j = 0; j < Articulo.PresentacionesDelArticulo.Count; j++)
                    {
                        double IdPresentacionArticulo = Articulo.PresentacionesDelArticulo[j].IdPresentacionArticulo;
                        EntidadesWeb.PresentacionArticulo PresentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(TemplistaPresentacionesAticulos, IdPresentacionArticulo);
                        listaPresentacionesAticulos.Add(PresentacionArticulo);
                    }
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
            if (Request.QueryString["Page"] == null)
            {
                paginaActual = 1;

                // Si es la primera página se oculta el botón "Anterior" y se muestra el botón "Siguiente"
                LinkButtonAnterior.Visible = false;
                LinkButtonSiguiente.Visible = true;
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
                    LinkButtonAnterior.Visible = false;
                }
                else
                {
                    LinkButtonAnterior.Visible = true;
                }

                // El botón "siguiente" se oculta, pero no cuando se está imprimiendo la últma página
                if (paginaActual == cantidadPaginas)
                {
                    LinkButtonSiguiente.Visible = false;
                }
                else
                {
                    LinkButtonSiguiente.Visible = true;
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

            Repeater1.DataSource = ListaPresentacionesArticulosPaginaActual;
            Repeater1.DataBind();

            RepeaterPaginacion.DataSource = ListaPaginas;
            RepeaterPaginacion.DataBind();

            // Mostrar información sobre el cantidad de elementos mostrados
            LblInformacionPaginacion.Text = "Mostrando artículos del " + (paginaActual * tamanioPagina - tamanioPagina + 1).ToString() + " al " + (paginaActual * tamanioPagina - tamanioPagina + ListaPresentacionesArticulosPaginaActual.Count).ToString() + " de " + listaPresentacionesAticulos.Count;
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

            if (this.Request["Categoria"] == null)
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + linkButton.CommandArgument + "&PageSize=" + HiddenFieldTamanioPagina.Value, false);
            }
            else
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + linkButton.CommandArgument + "&PageSize=" + HiddenFieldTamanioPagina.Value + "&Categoria=" + this.Request["Categoria"], false);
            }
        }

        protected void LinkButtonTamanioPagina_Click(object sender, EventArgs e)
        {
            // Evitar que no se especifique  un tamaño de página
            LinkButton linkButton = sender as LinkButton;
            HiddenFieldTamanioPagina.Value = linkButton.CommandArgument;

            if (this.Request["Categoria"] == null)
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=1" + "&PageSize=" + linkButton.CommandArgument, false);
            }
            else
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=1" + "&PageSize=" + linkButton.CommandArgument + "&Categoria=" + this.Request["Categoria"], false);
            }
        }

        protected void LinkButtonAnterior_Click(object sender, EventArgs e)
        {
            int Pagina = int.Parse(this.Request["Page"]);
            int TamanioPagina = int.Parse(this.Request["PageSize"]);

            Pagina = Pagina - 1;

            if (this.Request["Categoria"] == null)
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + Pagina + "&PageSize=" + this.Request["PageSize"], false);
            }
            else
            {
                this.Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + Pagina + "&PageSize=" + this.Request["PageSize"] + "&Categoria=" + this.Request["Categoria"], false);
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

            if (this.Request["Categoria"] == null)
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + Pagina + "&PageSize=" + TamanioPagina, false);
            }
            else
            {
                Response.Redirect("ResultadoCajaCategoria.aspx?Page=" + Pagina + "&PageSize=" + TamanioPagina + "&Categoria=" + this.Request["Categoria"], false);
            }
        }

        public static void InsertarBusqueda(string nombreCategoria)
        {
            Fachada.WebPublica.Busqueda Busqueda = new Fachada.WebPublica.Busqueda();
            Busqueda.Insertar(nombreCategoria);
        }
    }
}