// -----------------------------------------------------------------------
// <copyright file="ConfiguracionPieDePagina.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class ConfiguracionPieDePagina : Contratos.IConfiguracionPieDePagina
    {
        public ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            AccesoDatos.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new AccesoDatos.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Actualizar(PieDePagina);
        }

        public ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            AccesoDatos.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new AccesoDatos.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Insertar(PieDePagina);
        }

        public ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar()
        {
            AccesoDatos.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new AccesoDatos.TablasMaestras.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
