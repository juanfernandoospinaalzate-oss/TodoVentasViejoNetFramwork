namespace Validacion.WebPublica
{
    public class UnidadLongitud : ContratosWeb.IUnidadLongitud
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud()
        {
            ReglasDENegocio.WebPublica.UnidadLongitud UnidadLongitud = new ReglasDENegocio.WebPublica.UnidadLongitud();
            return UnidadLongitud.ListaUnidadLongitud();
        }
    }
}
