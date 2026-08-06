// -----------------------------------------------------------------------
// <copyright file="Carrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using Entidades;

    public class Carrito : Contratos.ICarrito
    {
        public ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo)
        {
            AccesoDatos.TablasMaestras.Carrito Carrito = new AccesoDatos.TablasMaestras.Carrito();
            return Carrito.EliminarPorIdPresentacionArticulo(IdpresentacionArticulo);
        }
    }
}
