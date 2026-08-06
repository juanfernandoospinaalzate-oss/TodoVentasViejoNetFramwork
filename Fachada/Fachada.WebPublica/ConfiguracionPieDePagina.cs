

namespace Fachada.WebPublica
{
    using System.Collections.ObjectModel;

    public class ConfiguracionPieDePagina : ContratosWeb.IConfiguracionPieDePagina
    {
        public ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> Listar()
        {
            ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient ServicioConfigPieDePagina = new ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient();
            return ServicioConfigPieDePagina.Listar();
        }
    }
}
