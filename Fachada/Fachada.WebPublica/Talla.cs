namespace Fachada.WebPublica
{
    public class Talla : ContratosWeb.ITalla
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> ListaTallas()
        {
            ServicioTalla.TallaClient Talla = new ServicioTalla.TallaClient();
            return Talla.ListaTallas();
        }
    }
}
