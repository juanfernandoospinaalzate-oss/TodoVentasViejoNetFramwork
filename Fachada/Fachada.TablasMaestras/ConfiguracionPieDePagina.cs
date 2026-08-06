

namespace Fachada.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class ConfiguracionPieDePagina : Contratos.IConfiguracionPieDePagina
    {
        public ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient ServicioPieDePagina = new ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient();
            return ServicioPieDePagina.Actualizar(PieDePagina);
        }

        public ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient ServicioPieDePagina = new ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient();
            return ServicioPieDePagina.Insertar(PieDePagina);
        }

        public ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar()
        {
            ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient ServicioPieDePagina = new ServicioConfiguracionPieDePagina.ConfiguracionPieDePaginaClient();
            return ServicioPieDePagina.Listar();
        }
    }
}
