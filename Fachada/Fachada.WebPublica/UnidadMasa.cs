namespace Fachada.WebPublica
{
    public class UnidadMasa : ContratosWeb.IUnidadMasa
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> ListaUnidadMasa()
        {
            ServicioUnidadMasa.UnidadMasaClient UnidadMasa = new ServicioUnidadMasa.UnidadMasaClient();
            return UnidadMasa.ListaUnidadMasa();
        }
    }
}
