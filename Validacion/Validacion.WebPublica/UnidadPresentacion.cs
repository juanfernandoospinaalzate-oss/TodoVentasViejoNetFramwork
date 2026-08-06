namespace Validacion.WebPublica
{
    public class UnidadPresentacion : ContratosWeb.IUnidadPresentacion
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar()
        {
            ReglasDENegocio.WebPublica.UnidadPresentacion unidadPresentacion = new ReglasDENegocio.WebPublica.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
