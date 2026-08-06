namespace Validacion.WebPublica
{
    public class Color : ContratosWeb.IColor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> ListaColores()
        {
            ReglasDENegocio.WebPublica.Color Color = new ReglasDENegocio.WebPublica.Color();
            return Color.ListaColores();
        }
    }
}
