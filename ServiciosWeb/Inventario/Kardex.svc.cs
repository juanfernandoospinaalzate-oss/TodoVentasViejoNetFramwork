

namespace ServiciosWeb.Inventario
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class Kardex : Contratos.IKardex
    {
        public bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo)
        {
            Validacion.Inventario.Kardex Kardex = new Validacion.Inventario.Kardex();
            return Kardex.VerificarRelacionPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion Insertar(Entidades.Kardex registro)
        {
            Validacion.Inventario.Kardex Kardex = new Validacion.Inventario.Kardex();
            return Kardex.Insertar(registro);
        }

        public ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            Validacion.Inventario.Kardex Kardex = new Validacion.Inventario.Kardex();
            return Kardex.ListarPorIdPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
