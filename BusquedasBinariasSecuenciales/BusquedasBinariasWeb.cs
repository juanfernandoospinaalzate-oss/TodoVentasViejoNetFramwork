//-----------------------------------------------------------------------
// <copyright file="BusquedasBinariasWeb.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace BusquedasBinariasSecuenciales
{
    using System.Collections.Generic;

    public class BusquedasBinariasWeb : ContratosWeb.IBusquedasBinariasWeb
    {
        public EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(ref List<EntidadesWeb.Articulo> ListaArticulos, int idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            EntidadesWeb.Articulo resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaArticulos[medio].IdArticulo == idArticulo)
                {
                    resultado = ListaArticulos[medio];
                }
                else
                {
                    if (idArticulo < ListaArticulos[medio].IdArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public int BusquedaBinariaArticuloIndiceDondeInsertar(ref List<EntidadesWeb.Articulo> ListaArticulos, int idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;

            // La inserción se hace en el lugar correspondiente al índice cero si "idPresentacionArticulo" es menor a "inferior"
            if (idArticulo < ListaArticulos[0].IdArticulo)
            {
                return 0;
            }

            // La inserción se hace en el lugar correspondiente al último indice si idPresentacionArticulo" es mayor a "superior"
            int ultimoIndice = ListaArticulos.Count - 1;
            if (idArticulo > ListaArticulos[ultimoIndice].IdArticulo)
            {
                return ultimoIndice;
            }

            while (inferior <= superior)
            {
                medio = (inferior + superior) / 2;

                // Si el tamaño del subvector de busqueda es pequeño
                if (superior - inferior < 10)
                {
                    // Busqueda secuencial del indice donde se insertará
                    // resultado = ListaPresentacionArticulos[medio];
                    for (int i = inferior; i <= superior; i++)
                    {
                        // La inserción se hace en lugar del indice, del elemento que tiene el valor superior
                        if (idArticulo > ListaArticulos[i].IdArticulo && idArticulo < ListaArticulos[i + 1].IdArticulo)
                        {
                            return i + 1;
                        }
                    }
                }
                else
                {
                    if (idArticulo < ListaArticulos[medio].IdArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }

            return int.MinValue;
        }

        public EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(List<EntidadesWeb.Articulo> ListaArticulos, double idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            EntidadesWeb.Articulo resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaArticulos[medio].IdArticulo == idArticulo)
                {
                    resultado = ListaArticulos[medio];
                }
                else
                {
                    if (idArticulo < ListaArticulos[medio].IdArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(List<EntidadesWeb.Articulo> ListaArticulos, long idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            EntidadesWeb.Articulo resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaArticulos[medio].IdArticulo == idArticulo)
                {
                    resultado = ListaArticulos[medio];
                }
                else
                {
                    if (idArticulo < ListaArticulos[medio].IdArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public int BusquedaBinariaPresentacionArticuloIndiceDondeInsertar(ref List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;

            // La inserción se hace en el lugar correspondiente al índice cero si "idPresentacionArticulo" es menor a "inferior"
            if (idPresentacionArticulo < ListaPresentacionArticulos[inferior].IdPresentacionArticulo)
            {
                return inferior;
            }

            // La inserción se hace en el lugar correspondiente al último indice si idPresentacionArticulo" es mayor a "superior"
            if (idPresentacionArticulo > ListaPresentacionArticulos[superior].IdPresentacionArticulo)
            {
                return superior;
            }

            while (inferior <= superior)
            {
                medio = (inferior + superior) / 2;

                // Verificar si la inserción se hace en ...
                if (idPresentacionArticulo > ListaPresentacionArticulos[medio].IdPresentacionArticulo && idPresentacionArticulo < ListaPresentacionArticulos[medio + 1].IdPresentacionArticulo)
                {
                    return medio + 1;
                }

                // Verificar si la inserción se hace en ...
                if (idPresentacionArticulo < ListaPresentacionArticulos[medio].IdPresentacionArticulo && idPresentacionArticulo > ListaPresentacionArticulos[medio - 1].IdPresentacionArticulo)
                {
                    return medio - 1;
                }

                // Si el tamaño del subvector de busqueda es pequeño
                if (superior - inferior < 10)
                {
                    // Busqueda secuencial del indice donde se insertará
                    // resultado = ListaPresentacionArticulos[medio];
                    for (int i = inferior; i <= superior; i++)
                    {
                        // La inserción se hace en lugar del indice, del elemento que tiene el valor superior
                        if (idPresentacionArticulo > ListaPresentacionArticulos[i].IdPresentacionArticulo && idPresentacionArticulo < ListaPresentacionArticulos[i + 1].IdPresentacionArticulo)
                        {
                            return i + 1;
                        }
                    }
                }
                else
                {
                    if (idPresentacionArticulo < ListaPresentacionArticulos[medio].IdPresentacionArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }

            return int.MinValue;
        }

        public EntidadesWeb.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ref List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;
            EntidadesWeb.PresentacionArticulo resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaPresentacionArticulos[medio].IdPresentacionArticulo == idPresentacionArticulo)
                {
                    resultado = ListaPresentacionArticulos[medio];
                }
                else
                {
                    if (idPresentacionArticulo < ListaPresentacionArticulos[medio].IdPresentacionArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public EntidadesWeb.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;
            EntidadesWeb.PresentacionArticulo resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaPresentacionArticulos[medio].IdPresentacionArticulo == idPresentacionArticulo)
                {
                    resultado = ListaPresentacionArticulos[medio];
                }
                else
                {
                    if (idPresentacionArticulo < ListaPresentacionArticulos[medio].IdPresentacionArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public EntidadesWeb.Categoria BusquedaBinariaCategoriaPorIdCategoria(List<EntidadesWeb.Categoria> listaCategorias, int idCategoria)
        {
            int inferior = 0;
            int superior = listaCategorias.Count - 1;
            int medio;
            EntidadesWeb.Categoria resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaCategorias[medio].IdCategoria == idCategoria)
                {
                    resultado = listaCategorias[medio];
                }
                else
                {
                    if (idCategoria < listaCategorias[medio].IdCategoria)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public EntidadesWeb.Marca BusquedaBinariaMarca(List<EntidadesWeb.Marca> listaMarcas, int idMarca)
        {
            int inferior = 0;
            int superior = listaMarcas.Count - 1;
            int medio;
            EntidadesWeb.Marca resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaMarcas[medio].IdMarca == idMarca)
                {
                    resultado = listaMarcas[medio];
                }
                else
                {
                    if (idMarca < listaMarcas[medio].IdMarca)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }


    }
}
