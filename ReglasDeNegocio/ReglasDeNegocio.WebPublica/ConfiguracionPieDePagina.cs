//-----------------------------------------------------------------------
// <copyright file="ConfiguracionPieDePagina.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using System.Collections.ObjectModel;

    public class ConfiguracionPieDePagina : ContratosWeb.IConfiguracionPieDePagina
    {
        public ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> Listar()
        {
            AccesoDatos.WebPublica.ConfiguracionPieDePagina ConfigPieDePagina = new AccesoDatos.WebPublica.ConfiguracionPieDePagina();
            return ConfigPieDePagina.Listar();
        }
    }
}
