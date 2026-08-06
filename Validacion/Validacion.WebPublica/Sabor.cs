namespace Validacion.WebPublica
{
    public class Sabor : ContratosWeb.ISabor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores()
        {
            ReglasDENegocio.WebPublica.Sabor Sabor = new ReglasDENegocio.WebPublica.Sabor();
            return Sabor.ListaSabores();
        }
    }
}
