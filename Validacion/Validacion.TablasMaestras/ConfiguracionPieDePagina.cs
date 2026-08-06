

namespace Validacion.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class ConfiguracionPieDePagina : Contratos.IConfiguracionPieDePagina
    {
        public ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Actualizar(PieDePagina);
        }

        public ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Insertar(PieDePagina);
        }

        public ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar()
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new ReglasDENegocio.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
