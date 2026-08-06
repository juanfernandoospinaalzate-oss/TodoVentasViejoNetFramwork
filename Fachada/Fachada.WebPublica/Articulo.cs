

namespace Fachada.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class Articulo : ContratosWeb.IArticulo
    {
        public EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo)
        {
            ServicioArticulo.ArticuloClient Articulo = new ServicioArticulo.ArticuloClient();
            return Articulo.ConsultarArticuloPorIdArtículo(idArticulo);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar()
        {
            ServicioArticulo.ArticuloClient Articulo = new ServicioArticulo.ArticuloClient();
            return Articulo.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion()
        {
            ServicioArticulo.ArticuloClient Articulo = new ServicioArticulo.ArticuloClient();
            return Articulo.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias)
        {
            ServicioArticulo.ArticuloClient Articulo = new ServicioArticulo.ArticuloClient();
            return Articulo.ListarPorIdsCategorias(IdsCategorias);
        }

        public ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo)
        {
            ServicioArticulo.ArticuloClient Articulo = new ServicioArticulo.ArticuloClient();
            return Articulo.QuitarMarcaActualizarArticulo(idArticulo);
        }
    }
}