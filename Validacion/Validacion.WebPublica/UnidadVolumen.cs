namespace Validacion.WebPublica
{
    public class UnidadVolumen : ContratosWeb.IUnidadVolumen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen()
        {
            ReglasDENegocio.WebPublica.UnidadVolumen UnidadVolumen = new ReglasDENegocio.WebPublica.UnidadVolumen();
            return UnidadVolumen.ListaUnidadVolumen();
        }
    }
}
