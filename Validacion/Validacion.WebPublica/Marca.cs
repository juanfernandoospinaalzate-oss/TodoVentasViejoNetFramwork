

namespace Validacion.WebPublica
{
    using System.Collections.ObjectModel;

    public class Marca : ContratosWeb.IMarca
    {
        public ReadOnlyCollection<EntidadesWeb.Marca> Listar()
        {
            ReglasDENegocio.WebPublica.Marca marca = new ReglasDENegocio.WebPublica.Marca();
            return marca.Listar();
        }
    }
}
