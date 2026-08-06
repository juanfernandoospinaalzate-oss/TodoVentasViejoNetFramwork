namespace Validacion.WebPublica
{
    public class UnidadMasa : ContratosWeb.IUnidadMasa
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> ListaUnidadMasa()
        {
            ReglasDENegocio.WebPublica.UnidadMasa UnidadMasa = new ReglasDENegocio.WebPublica.UnidadMasa();
            return UnidadMasa.ListaUnidadMasa();
        }
    }
}
