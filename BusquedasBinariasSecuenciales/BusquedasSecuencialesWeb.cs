

namespace BusquedasBinariasSecuenciales
{
    using System.Collections.Generic;

    public class BusquedasSecuencialesWeb : ContratosWeb.IBusquedasSecuencialesWeb
    {
        public EntidadesWeb.Talla BusquedaSecuencialTallaPorNombre(List<EntidadesWeb.Talla> listaTallas, string nombreTalla)
        {
            EntidadesWeb.Talla resultado = null;

            for (int i = 0; i < listaTallas.Count; i++)
            {
                if (listaTallas[i].Nombre == nombreTalla)
                {
                    resultado = listaTallas[i];
                }
            }

            return resultado;
        }

        public EntidadesWeb.Color BusquedaSecuencialColorPorNombre(List<EntidadesWeb.Color> listaColores, string nombreColor)
        {
            EntidadesWeb.Color resultado = null;

            for (int i = 0; i < listaColores.Count; i++)
            {
                if (listaColores[i].Nombre == nombreColor)
                {
                    resultado = listaColores[i];
                }
            }

            return resultado;
        }

        public EntidadesWeb.Sabor BusquedaSecuencialSaborPorNombre(List<EntidadesWeb.Sabor> listaSabores, string nombreSabor)
        {
            EntidadesWeb.Sabor resultado = null;

            for (int i = 0; i < listaSabores.Count; i++)
            {
                if (listaSabores[i].Nombre == nombreSabor)
                {
                    resultado = listaSabores[i];
                }
            }

            return resultado;
        }

        public List<EntidadesWeb.Categoria> BusquedaSecuencialCategoriaPorIdCategoriaPadre(List<EntidadesWeb.Categoria> listaCategoriasCompleta, int IdCategoria)
        {
            List<EntidadesWeb.Categoria> resultado = new List<EntidadesWeb.Categoria>();

            for (int i = 0; i < listaCategoriasCompleta.Count; i++)
            {
                if (listaCategoriasCompleta[i].IdCategoriaPadre == IdCategoria)
                {
                    resultado.Add(listaCategoriasCompleta[i]);
                }
            }

            return resultado;
        }

        public EntidadesWeb.ItemCarrito BusquedaSecuencialItemCarritoPorId(List<EntidadesWeb.ItemCarrito> listaItemCarrito, int idIPresentacionArticulo)
        {
            EntidadesWeb.ItemCarrito resultado = null;

            for (int i = 0; i < listaItemCarrito.Count; i++)
            {
                if (listaItemCarrito[i].IdPrestacionArticulo == idIPresentacionArticulo)
                {
                    resultado = listaItemCarrito[i];
                }
            }

            return resultado;
        }

        public EntidadesWeb.PresentacionArticulo BusquedaSecuencialPresentacionArticulo(List<EntidadesWeb.PresentacionArticulo> presentacionesArticulo, List<string> filtros, List<string> valoresFiltros)
        {
            foreach (EntidadesWeb.PresentacionArticulo presentacionArticulo in presentacionesArticulo)
            {
                int filtrosEncontrados = 0;

                for (int i = 0; i < filtros.Count; i++)
                {
                    string filtro = filtros[i];
                    switch (filtro)
                    {
                        case "Volumen":
                            if (presentacionArticulo.VlrContenidoVolumetrico.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "Masa":
                            if (presentacionArticulo.VlrUnidadMasa.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "Longitud":
                            if (presentacionArticulo.VlrUnidadLongitud.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "Talla":
                            if (presentacionArticulo.Talla.IdTalla.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "Color":
                            if (presentacionArticulo.Color.IdColor.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "Sabor":
                            if (presentacionArticulo.Sabor.IdSabor.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        case "UnidadPresentacion":
                            if (presentacionArticulo.VlrUnidadPresentacion.ToString() == valoresFiltros[i])
                            {
                                filtrosEncontrados += 1;
                            }
                            break;
                        default:
                            break;
                    }
                }

                // Si se encontraron todos los filtros en la presentación de artículo entocnces es la entidad buscada
                if (filtrosEncontrados == filtros.Count)
                {
                    return presentacionArticulo;
                }
            }

            return null;
        }

        public EntidadesWeb.UnidadPresentacion BusquedaSecuencialUnidadPresentacionPorNombre(List<EntidadesWeb.UnidadPresentacion> listaUnidadPresentacion, string nombreUnidadPresentacion)
        {
            EntidadesWeb.UnidadPresentacion resultado = null;

            for (int i = 0; i < listaUnidadPresentacion.Count; i++)
            {
                if (listaUnidadPresentacion[i].Nombre == nombreUnidadPresentacion)
                {
                    resultado = listaUnidadPresentacion[i];
                }
            }

            return resultado;
        }
    }
}
