

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    public partial class FiltrosArticulo : System.Web.UI.UserControl
    {

        public string FiltroSeleccionado1
        {
            get
            {
                return HiddenFieldFiltroSeleccionado1.Value;
            }
            set
            {
                HiddenFieldFiltroSeleccionado1.Value = value;
            }
        }

        public string ValorFiltroSeleccionado1
        {
            get
            {
                return HiddenFieldValorFiltroSeleccionado1.Value;
            }
            set
            {
                HiddenFieldValorFiltroSeleccionado1.Value = value;
            }
        }

        public string FiltroSeleccionado2
        {
            get
            {
                return HiddenFieldFiltroSeleccionado2.Value;
            }
            set
            {
                HiddenFieldFiltroSeleccionado2.Value = value;
            }
        }

        public string ValorFiltroSeleccionado2
        {
            get
            {
                return HiddenFieldValorFiltroSeleccionado2.Value;
            }
            set
            {
                HiddenFieldValorFiltroSeleccionado2.Value = value;
            }
        }

        public string FiltroSeleccionado3
        {
            get
            {
                return HiddenFieldFiltroSeleccionado3.Value;
            }
            set
            {
                HiddenFieldFiltroSeleccionado3.Value = value;
            }
        }

        public string ValorFiltroSeleccionado3
        {
            get
            {
                return HiddenFieldValorFiltroSeleccionado3.Value;
            }
            set
            {
                HiddenFieldValorFiltroSeleccionado3.Value = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Crear_Filtros(EntidadesWeb.Articulo articulo)
        {
            string etiquetaFiltro = string.Empty;
            byte contadorFiltroCargado = 1;
            DataList dataListACargar = null;
            HiddenField campoOcultoFiltroSeleccionado = null;
            List<string> ListFiltrosACargar = null;
            System.Collections.Generic.List<string> listaEtiquetasImpresas = new List<string>(); // Lista única con todas las etiquetas impresas sin importar el tipo de filtro

            // Recorrer los filtros para buscar los configurados como activos y añadirlos a la página.
            foreach (EntidadesWeb.Enumeraciones.Filtro filtro in Enum.GetValues(typeof(EntidadesWeb.Enumeraciones.Filtro)))
            {
                // se marca para saber si se han impreso etiquetas para una línea de filtro
                bool impresionLineaFiltro = false;

                if (contadorFiltroCargado < 4)
                {
                    // Imprimir la etiqueta de filtro solo si el filtro está configurado como true en las propiedades del artículo

                    dataListACargar = this.FindControl("DataList" + contadorFiltroCargado.ToString()) as DataList;
                    campoOcultoFiltroSeleccionado = this.FindControl("HiddenFieldFiltroSeleccionado" + contadorFiltroCargado.ToString()) as HiddenField;
                    ListFiltrosACargar = new List<string>();

                    foreach (EntidadesWeb.PresentacionArticulo itemPresentacionArticulo in articulo.PresentacionesDelArticulo)
                    {
                        // string urlRelativa = Request.RawUrl.Substring(1);
                        // string[] parametrosDelSegmento = urlRelativa.Split('-');
                        // string idPresentacionArticulo = itemPresentacionArticulo.IdPresentacionArticulo.ToString();
                        // urlRelativa = parametrosDelSegmento[0] + "-" + parametrosDelSegmento[1] + "-" + idPresentacionArticulo + ".aspx";
                        etiquetaFiltro = string.Empty;

                        switch (filtro)
                        {
                            case EntidadesWeb.Enumeraciones.Filtro.Volumen:
                                if (articulo.UnidadVolumen == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Volumen.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.VlrContenidoVolumetrico.ToString() + " " + itemPresentacionArticulo.UnidadVolumen.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.Masa:
                                // verificar si el filtro tiene configuración activa
                                if (articulo.UnidadMasa == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Masa.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.VlrUnidadMasa.ToString() + " " + itemPresentacionArticulo.UnidadMasa.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }

                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.Longitud:
                                if (articulo.UnidadLongitud == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Longitud.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.VlrUnidadLongitud.ToString() + " " + itemPresentacionArticulo.UnidadLongitud.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.Talla:
                                if (articulo.Talla == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Talla.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.Talla.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.Color:
                                // verificar si el filtro tiene configuración activa
                                if (articulo.Color == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Color.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.Color.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.Sabor:
                                // verificar si el filtro tiene configuración activa
                                if (articulo.Sabor == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.Sabor.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.Sabor.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            case EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion:
                                // verificar si el filtro tiene configuración activa
                                if (articulo.UnidadPresentacion == true)
                                {
                                    campoOcultoFiltroSeleccionado.Value = EntidadesWeb.Enumeraciones.Filtro.UnidadPresentacion.ToString();
                                    etiquetaFiltro = itemPresentacionArticulo.VlrUnidadPresentacion + " " + itemPresentacionArticulo.UnidadPresentacion.Nombre;

                                    // Verificar que la etiqueta de filtro no ha sido impresa anteriormente
                                    if (listaEtiquetasImpresas.Exists(x => x == etiquetaFiltro) == false)
                                    {
                                        // Indica que será impresa una línea de filtro para que sean contadas dichas líneas
                                        impresionLineaFiltro = true;
                                        listaEtiquetasImpresas.Add(etiquetaFiltro);
                                        ListFiltrosACargar.Add(etiquetaFiltro);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    dataListACargar.DataSource = ListFiltrosACargar;
                    dataListACargar.DataBind();
                }

                // Si se ha impreso una línea de filtro para el filtro actual del ciclo se prepara la siguiente línea y se cuentan
                if (impresionLineaFiltro == true)
                {
                    contadorFiltroCargado++;
                }

            }
        }

        protected void DataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Se identifica el Datalist que se dispara para obtener el filtro correspondiente (si es el 1, el 2 o el 3).
            System.Web.UI.WebControls.DataList dataList = sender as System.Web.UI.WebControls.DataList;
            string IdDatalist = dataList.ID.Substring(dataList.ID.Length - 1, 1);

            // con el id del datalist se obtiene el campo con el filtro correspondiente
            string filtro = (this.FindControl("HiddenFieldFiltroSeleccionado" + IdDatalist) as HiddenField).Value;

            // cagar los datos de valor de filtro
            LinkButton linkButton = e.Item.FindControl("LinkButton1") as LinkButton;
            linkButton.Text = e.Item.DataItem as string;

            BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb BusquedasSecuencialesWeb = new BusquedasBinariasSecuenciales.BusquedasSecuencialesWeb();

            // Con el texto del filtro se obtiene el Id de la base de datos par los casos que aplica
            switch (filtro)
            {
                case "Volumen":
                    // Obtener el Valor Para la unidad de Volumen
                    string ValorUnidadVolumen = linkButton.Text.Split(' ')[0];
                    linkButton.CommandArgument = ValorUnidadVolumen;
                    break;
                case "Masa":
                    string ValorUnidadMasa = linkButton.Text.Split(' ')[0];
                    linkButton.CommandArgument = ValorUnidadMasa;
                    break;
                case "Longitud":
                    string ValorUnidadLongitud = linkButton.Text.Split(' ')[0];
                    linkButton.CommandArgument = ValorUnidadLongitud;
                    break;
                case "Talla":
                    List<EntidadesWeb.Talla> listaTallas = Application["ListaTalla"] as List<EntidadesWeb.Talla>;
                    EntidadesWeb.Talla talla = BusquedasSecuencialesWeb.BusquedaSecuencialTallaPorNombre(listaTallas, linkButton.Text);
                    linkButton.CommandArgument = talla.IdTalla.ToString();
                    break;
                case "Color":
                    List<EntidadesWeb.Color> listaColores = Application["ListaColor"] as List<EntidadesWeb.Color>;
                    EntidadesWeb.Color color = BusquedasSecuencialesWeb.BusquedaSecuencialColorPorNombre(listaColores, linkButton.Text);
                    linkButton.CommandArgument = color.IdColor.ToString();
                    break;
                case "Sabor":
                    List<EntidadesWeb.Sabor> listaSabores = Application["ListaSabor"] as List<EntidadesWeb.Sabor>;
                    EntidadesWeb.Sabor sabor = BusquedasSecuencialesWeb.BusquedaSecuencialSaborPorNombre(listaSabores, linkButton.Text);
                    linkButton.CommandArgument = sabor.IdSabor.ToString();
                    break;
                case "UnidadPresentacion":
                    // List<EntidadesWeb.UnidadPresentacion> listaUnidadPresentacion = Application["ListaUnidadPresentacion"] as List<EntidadesWeb.UnidadPresentacion>;
                    // EntidadesWeb.UnidadPresentacion unidadPresentacion = Busqueda.BusquedasSecuenciales.BusquedaSecuencialUnidadPresentacionPorNombre( listaUnidadPresentacion, linkButton.Text);
                    // linkButton.CommandArgument = unidadPresentacion.IdUnidadPresentacion.ToString();
                    string ValorUnidadPresentacion = linkButton.Text.Split(' ')[0];
                    linkButton.CommandArgument = ValorUnidadPresentacion;
                    break;
                default:
                    break;
            }

            
        }

        protected void DataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            // e.CommandArgument: Contiene el Id del filtro que recibió el click
            // e.CommandName: Contiene el Nombre del Filtro

            // Identificar cuál de los Datalist es el seleccionado para conocer.
            System.Web.UI.WebControls.DataList datalist = source as System.Web.UI.WebControls.DataList;
            string nroDatalist = datalist.ID.Substring(datalist.ID.Length - 1, 1);

            HiddenField HiddenFieldValorFiltroSeleccionado = this.FindControl("HiddenFieldValorFiltroSeleccionado" + nroDatalist) as HiddenField;
            HiddenFieldValorFiltroSeleccionado.Value = e.CommandArgument.ToString();

            // DataListItem E = e.Item;
        }

        public void ResetearEstilosFiltros()
        {
            List<DataList> ListaDataList = new List<DataList>();
            ListaDataList.Add(this.DataList1);
            ListaDataList.Add(this.DataList2);
            ListaDataList.Add(this.DataList3);

            foreach (DataList dataList in ListaDataList)
            {
                foreach (DataListItem dataListItem in dataList.Items)
                {
                    LinkButton linkButton = dataListItem.Controls[1] as LinkButton;
                    linkButton.CssClass = "ui label";
                }
            }
        }

        public void AsignarEstilosyValoresFiltros(EntidadesWeb.Enumeraciones.Filtro filtro, string valorFiltro)
        {
            List<DataList> ListaDataList = new List<DataList>();
            ListaDataList.Add(this.DataList1);
            ListaDataList.Add(this.DataList2);
            ListaDataList.Add(this.DataList3);

            foreach (DataList dataList in ListaDataList)
            {
                // Buscar el filtro seleccionado y asignar el estilo de visualización
                foreach (DataListItem dataListItem in dataList.Items)
                {
                    LinkButton linkButton = dataListItem.Controls[1] as LinkButton;

                    if (dataList.ID == "DataList1")
                    {
                        if (HiddenFieldFiltroSeleccionado1.Value == filtro.ToString() && linkButton.CommandArgument == valorFiltro)
                        {
                            HiddenFieldValorFiltroSeleccionado1.Value = valorFiltro;
                            linkButton.CssClass = "ui brown label";
                            break;
                        }
                    }

                    if (dataList.ID == "DataList2")
                    {
                        if (HiddenFieldFiltroSeleccionado2.Value == filtro.ToString() && linkButton.CommandArgument == valorFiltro)
                        {
                            HiddenFieldValorFiltroSeleccionado2.Value = valorFiltro;
                            linkButton.CssClass = "ui brown label";
                            break;
                        }
                    }

                    if (dataList.ID == "DataList3")
                    {
                        if (HiddenFieldFiltroSeleccionado3.Value == filtro.ToString() && linkButton.CommandArgument == valorFiltro)
                        {
                            HiddenFieldValorFiltroSeleccionado3.Value = valorFiltro;
                            linkButton.CssClass = "ui brown label";
                            break;
                        }
                    }
                }
            }
        }
    }
}