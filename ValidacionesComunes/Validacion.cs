//-----------------------------------------------------------------------
// <copyright file="Validacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ValidacionesComunes
{
    public class Validacion
    {
        /// <summary>
        /// Retorna la cantidad máxima de unidades disponibles para la compra en el momento
        /// </summary>
        /// <param name="existenciasDisponibles">Cantidad disponible en inventario para la venta</param>
        /// <param name="cantidadParaAniadir">cantidad que se desea añadir al carrito</param>
        /// <param name="cantidadActualEnCarrito">Cantidad que hay en carrito para la sesión actual</param>
        /// <returns></returns>
        public int ControlCantidadDisponible(int existenciasDisponibles, int cantidadParaAniadir, int cantidadActualEnCarrito)
        {
            int NuevoTotalCantidadCarrito = cantidadActualEnCarrito + cantidadParaAniadir;

            if (NuevoTotalCantidadCarrito > existenciasDisponibles)
            {
                NuevoTotalCantidadCarrito = existenciasDisponibles;
            }

            return NuevoTotalCantidadCarrito;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool EsUrlHttpsValida(string url)
        {
            System.Uri uriResultado;
            bool esValida = false;

            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            // Verificar si se tiene un formato correcto de URI sin importar el protocolo
            esValida = System.Uri.TryCreate(url, System.UriKind.Absolute, out uriResultado);

            if (!esValida)
            {
                return false;
            }

            // Verificar si la URI es https
            if (uriResultado.Scheme == System.Uri.UriSchemeHttps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
