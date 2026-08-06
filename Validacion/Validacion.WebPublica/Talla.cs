namespace Validacion.WebPublica
{
    public class Talla : ContratosWeb.ITalla
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> ListaTallas()
        {
            ReglasDENegocio.WebPublica.Talla Talla = new ReglasDENegocio.WebPublica.Talla();
            return Talla.ListaTallas();
        }
    }
}
