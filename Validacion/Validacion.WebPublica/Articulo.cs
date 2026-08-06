// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class Articulo : ContratosWeb.IArticulo
    {
        public EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo)
        {
            ReglasDENegocio.WebPublica.Articulo Articulo = new ReglasDENegocio.WebPublica.Articulo();
            return Articulo.ConsultarArticuloPorIdArtículo(idArticulo);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar()
        {
            ReglasDENegocio.WebPublica.Articulo Articulo = new ReglasDENegocio.WebPublica.Articulo();
            return Articulo.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion()
        {
            ReglasDENegocio.WebPublica.Articulo Articulo = new ReglasDENegocio.WebPublica.Articulo();
            return Articulo.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias)
        {
            ReglasDENegocio.WebPublica.Articulo Articulo = new ReglasDENegocio.WebPublica.Articulo();
            return Articulo.ListarPorIdsCategorias(IdsCategorias);
        }

        public ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo)
        {
            ReglasDENegocio.WebPublica.Articulo Articulo = new ReglasDENegocio.WebPublica.Articulo();
            return Articulo.QuitarMarcaActualizarArticulo(idArticulo);
        }
    }
}
