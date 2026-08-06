//-----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class Articulo : ContratosWeb.IArticulo
    {
        public EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo)
        {
            AccesoDatos.WebPublica.Articulo Articulo = new AccesoDatos.WebPublica.Articulo();
            return Articulo.ConsultarArticuloPorIdArtículo(idArticulo);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar()
        {
            AccesoDatos.WebPublica.Articulo Articulo = new AccesoDatos.WebPublica.Articulo();
            return Articulo.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion()
        {
            AccesoDatos.WebPublica.Articulo Articulo = new AccesoDatos.WebPublica.Articulo();
            ReadOnlyCollection<EntidadesWeb.Articulo> ListaArticulosSoloLectura = Articulo.ListarPendientesActualizacion();
            return ListaArticulosSoloLectura;
        }

        public ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias)
        {
            AccesoDatos.WebPublica.Articulo Articulo = new AccesoDatos.WebPublica.Articulo();
            return Articulo.ListarPorIdsCategorias(IdsCategorias);
        }

        public ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo)
        {
            AccesoDatos.WebPublica.Articulo Articulo = new AccesoDatos.WebPublica.Articulo();
            return Articulo.QuitarMarcaActualizarArticulo(idArticulo);
        }
    }
}
