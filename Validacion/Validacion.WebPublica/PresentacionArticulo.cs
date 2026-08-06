

namespace Validacion.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;
    public class PresentacionArticulo : ContratosWeb.IPresentacionArticulo
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar()
        {
            ReglasDENegocio.WebPublica.PresentacionArticulo Presentacion = new ReglasDENegocio.WebPublica.PresentacionArticulo();
            return Presentacion.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion()
        {
            ReglasDENegocio.WebPublica.PresentacionArticulo Presentacion = new ReglasDENegocio.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo)
        {
            ReglasDENegocio.WebPublica.PresentacionArticulo Presentacion = new ReglasDENegocio.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPorIdArticulo(idArticulo);
        }

        public EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            ReglasDENegocio.WebPublica.PresentacionArticulo Presentacion = new ReglasDENegocio.WebPublica.PresentacionArticulo();
            return Presentacion.ConsultarPorIdPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo)
        {
            ReglasDENegocio.WebPublica.PresentacionArticulo Presentacion = new ReglasDENegocio.WebPublica.PresentacionArticulo();
            return Presentacion.QuitarMarcaActualizarPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
