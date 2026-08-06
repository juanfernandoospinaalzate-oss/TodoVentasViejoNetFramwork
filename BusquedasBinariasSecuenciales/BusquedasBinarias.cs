

namespace BusquedasBinariasSecuenciales
{
    using System.Collections.Generic;

    public class BusquedasBinarias : Contratos.IBusquedasBinarias
    {
        public Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(ref List<Entidades.Articulo> ListaArticulos, int idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            Entidades.Articulo resultado = null;

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

        public int BusquedaBinariaArticuloIndiceDondeInsertar(ref List<Entidades.Articulo> ListaArticulos, int idArticulo)
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

        public Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(List<Entidades.Articulo> ListaArticulos, double idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            Entidades.Articulo resultado = null;

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

        public Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(List<Entidades.Articulo> ListaArticulos, long idArticulo)
        {
            int inferior = 0;
            int superior = ListaArticulos.Count - 1;
            int medio;
            Entidades.Articulo resultado = null;

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

        public int BusquedaBinariaPresentacionArticuloIndiceDondeInsertar(ref List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo)
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

        public Entidades.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ref List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;
            Entidades.PresentacionArticulo resultado = null;

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

        public Entidades.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;
            Entidades.PresentacionArticulo resultado = null;

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

        public Entidades.Categoria BusquedaBinariaCategoriaPorIdCategoria(List<Entidades.Categoria> listaCategorias, int idCategoria)
        {
            int inferior = 0;
            int superior = listaCategorias.Count - 1;
            int medio;
            Entidades.Categoria resultado = null;

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

        public void BusquedaBinariaBorradoPresentacionArticuloPorIdPresentacionArticulo(List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo)
        {
            int inferior = 0;
            int superior = ListaPresentacionArticulos.Count - 1;
            int medio;
            int idPresentacionBorrar = int.MinValue;

            while (idPresentacionBorrar == int.MinValue && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (ListaPresentacionArticulos[medio].IdPresentacionArticulo == idPresentacionArticulo)
                {
                    ListaPresentacionArticulos.RemoveAt(medio);
                    return;
                }
                else
                {
                    if (idPresentacionArticulo < ListaPresentacionArticulos[medio].IdPresentacionArticulo)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return;
        }

        public Entidades.Marca BusquedaBinariaMarcaPorIdMarca(List<Entidades.Marca> listaMarcas, int idMarca)
        {
            int inferior = 0;
            int superior = listaMarcas.Count - 1;
            int medio;
            Entidades.Marca resultado = null;

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

        public Entidades.UnidadVolumen BusquedaBinariaUnidadDeVolumenPorIdUnidadDeVolumen(List<Entidades.UnidadVolumen> listaUnidadVolumen, int idUnidadVolumen)
        {
            int inferior = 0;
            int superior = listaUnidadVolumen.Count - 1;
            int medio;
            Entidades.UnidadVolumen resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaUnidadVolumen[medio].IdUnidadVolumen == idUnidadVolumen)
                {
                    resultado = listaUnidadVolumen[medio];
                }
                else
                {
                    if (idUnidadVolumen < listaUnidadVolumen[medio].IdUnidadVolumen)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public Entidades.UnidadMasa BusquedaBinariaUnidadDeMasaPorIdUnidadDeMasa(List<Entidades.UnidadMasa> listaUnidadesMasa, int idUnidadMasa)
        {
            int inferior = 0;
            int superior = listaUnidadesMasa.Count - 1;
            int medio;
            Entidades.UnidadMasa resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaUnidadesMasa[medio].IdUnidadMasa == idUnidadMasa)
                {
                    resultado = listaUnidadesMasa[medio];
                }
                else
                {
                    if (idUnidadMasa < listaUnidadesMasa[medio].IdUnidadMasa)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public Entidades.UnidadLongitud BusquedaBinariaUnidadLongitudPorIdUnidadLongitud(List<Entidades.UnidadLongitud> listaUnidadesLongitud, int idUnidadLongitud)
        {
            int inferior = 0;
            int superior = listaUnidadesLongitud.Count - 1;
            int medio;
            Entidades.UnidadLongitud resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaUnidadesLongitud[medio].IdUnidadLongitud == idUnidadLongitud)
                {
                    resultado = listaUnidadesLongitud[medio];
                }
                else
                {
                    if (idUnidadLongitud < listaUnidadesLongitud[medio].IdUnidadLongitud)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public Entidades.Talla BusquedaBinariaTallaPorIdTalla(List<Entidades.Talla> listaTallas, int idTalla)
        {
            int inferior = 0;
            int superior = listaTallas.Count - 1;
            int medio;
            Entidades.Talla resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaTallas[medio].IdTalla == idTalla)
                {
                    resultado = listaTallas[medio];
                }
                else
                {
                    if (idTalla < listaTallas[medio].IdTalla)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public Entidades.Sabor BusquedaBinariaSaborPorIdSabor(List<Entidades.Sabor> listaSabores, int idSabor)
        {
            int inferior = 0;
            int superior = listaSabores.Count - 1;
            int medio;
            Entidades.Sabor resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaSabores[medio].IdSabor == idSabor)
                {
                    resultado = listaSabores[medio];
                }
                else
                {
                    if (idSabor < listaSabores[medio].IdSabor)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }

        public Entidades.UnidadPresentacion BusquedaBinariaUnidadPresentacionPorIdUnidadPresentacion(List<Entidades.UnidadPresentacion> listaUnidadPresentacion, int idUnidadPresentacion)
        {
            int inferior = 0;
            int superior = listaUnidadPresentacion.Count - 1;
            int medio;
            Entidades.UnidadPresentacion resultado = null;

            while (resultado == null && inferior <= superior)
            {
                medio = (inferior + superior) / 2;
                if (listaUnidadPresentacion[medio].IdUnidadPresentacion == idUnidadPresentacion)
                {
                    resultado = listaUnidadPresentacion[medio];
                }
                else
                {
                    if (idUnidadPresentacion < listaUnidadPresentacion[medio].IdUnidadPresentacion)
                        superior = medio - 1;
                    else
                        inferior = medio + 1;
                }
            }
            return resultado;
        }
    }
}
