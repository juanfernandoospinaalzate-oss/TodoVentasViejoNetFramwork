

namespace Validacion.WebPublica
{
    using System.Collections.ObjectModel;

    public class ConfiguracionPieDePagina : ContratosWeb.IConfiguracionPieDePagina
    {
        public ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> Listar()
        {
            ReglasDENegocio.WebPublica.ConfiguracionPieDePagina ConfigPieDePagina = new ReglasDENegocio.WebPublica.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
