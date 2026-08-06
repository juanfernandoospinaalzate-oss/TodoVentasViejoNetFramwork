

namespace Fachada.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class PresentacionArticulo : ContratosWeb.IPresentacionArticulo
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar()
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion()
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
           return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ListarPorIdArticulo(idArticulo);
        }

        public EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ConsultarPorIdPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.QuitarMarcaActualizarPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
