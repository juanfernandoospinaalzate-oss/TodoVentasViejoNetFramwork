

namespace ServiciosWeb.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class ConfiguracionPieDePagina : Contratos.IConfiguracionPieDePagina
    {
        public ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            Validacion.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new Validacion.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Actualizar(PieDePagina);
        }

        public ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            Validacion.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new Validacion.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Insertar(PieDePagina);
        }

        public ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar()
        {
            Validacion.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new Validacion.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
