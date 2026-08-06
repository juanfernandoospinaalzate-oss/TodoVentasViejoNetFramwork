

namespace Fachada.Inventario
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class Kardex : Contratos.IKardex
    {
        public bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo)
        {
            ServicioKardex.KardexClient Kardex = new ServicioKardex.KardexClient();
            return Kardex.VerificarRelacionPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion Insertar(Entidades.Kardex registro)
        {
            ServicioKardex.KardexClient Kardex = new ServicioKardex.KardexClient();
            return Kardex.Insertar(registro);
        }

        public ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            ServicioKardex.KardexClient Kardex = new ServicioKardex.KardexClient();
            return Kardex.ListarPorIdPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
