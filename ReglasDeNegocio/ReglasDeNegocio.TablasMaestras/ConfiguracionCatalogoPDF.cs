// -----------------------------------------------------------------------
// <copyright file="ConfiguracionCatalogoPDF.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class ConfiguracionCatalogoPDF : Contratos.IConfiguracionCatalogoPDF
    {

        public Entidades.ConfiguracionCatalogoPDF Consultar()
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF();
            return Catalogo.Consultar();
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF();
            return Catalogo.Actualizar(catalogo);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDF();
            return Catalogo.Insertar(catalogo);
        }
    }
}
