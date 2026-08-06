

namespace Validacion.TablasMaestras
{
    using Entidades;

    public class Carrito : Contratos.ICarrito
    {
        public ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo)
        {
            ReglasDENegocio.TablasMaestras.Carrito Carrito = new ReglasDENegocio.TablasMaestras.Carrito();
            return Carrito.EliminarPorIdPresentacionArticulo(IdpresentacionArticulo);
        }
    }
}
