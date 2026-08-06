namespace Fachada.WebPublica
{
    public class UnidadLongitud : ContratosWeb.IUnidadLongitud
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud()
        {
            ServicioUnidadLongitud.UnidadLongitudClient UnidadLongitud = new ServicioUnidadLongitud.UnidadLongitudClient();
            return UnidadLongitud.ListaUnidadLongitud();
        }
    }
}
