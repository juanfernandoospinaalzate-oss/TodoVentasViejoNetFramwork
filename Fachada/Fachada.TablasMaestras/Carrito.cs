

namespace Fachada.TablasMaestras
{
    using Entidades;

    class Carrito : Contratos.ICarrito
    {
        public ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo)
        {
            ServicioCarrito.CarritoClient Carrito = new ServicioCarrito.CarritoClient();
            return Carrito.EliminarPorIdPresentacionArticulo(IdpresentacionArticulo);
        }
    }
}
