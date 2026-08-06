namespace Fachada.WebPublica
{
    public class Color : ContratosWeb.IColor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> ListaColores()
        {
            ServicioColor.ColorClient Color = new ServicioColor.ColorClient();
            return Color.ListaColores();
        }
    }
}
