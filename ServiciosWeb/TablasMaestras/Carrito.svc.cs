

namespace ServiciosWeb.TablasMaestras
{
    using Entidades;

    public class Carrito : Contratos.ICarrito
    {
        public ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo)
        {
            Validacion.TablasMaestras.Carrito Carrito = new Validacion.TablasMaestras.Carrito();
            return Carrito.EliminarPorIdPresentacionArticulo(IdpresentacionArticulo);
        }
    }
}
