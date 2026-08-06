namespace Fachada.WebPublica
{
    public class UnidadVolumen : ContratosWeb.IUnidadVolumen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen()
        {
            ServicioUnidadVolumen.UnidadVolumenClient UnidadVolumen = new ServicioUnidadVolumen.UnidadVolumenClient();
            return UnidadVolumen.ListaUnidadVolumen();
        }
    }
}
