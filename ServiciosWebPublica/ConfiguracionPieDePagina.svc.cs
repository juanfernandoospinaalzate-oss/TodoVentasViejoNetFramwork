

namespace ServiciosWebPublica
{
    using System.Collections.ObjectModel;
    public class ConfiguracionPieDePagina : ContratosWeb.IConfiguracionPieDePagina
    {
        public ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> Listar()
        {
            Validacion.WebPublica.ConfiguracionPieDePagina ConfigPieDePagina = new Validacion.WebPublica.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
