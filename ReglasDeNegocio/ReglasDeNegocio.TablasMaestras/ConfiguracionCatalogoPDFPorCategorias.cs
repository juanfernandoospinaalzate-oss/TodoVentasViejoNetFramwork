// -----------------------------------------------------------------------
// <copyright file="ConfiguracionCatalogoPDFPorCategorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class ConfiguracionCatalogoPDFPorCategorias : Contratos.IConfiguracionCatalogoPDFPorCategorias
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias configuracionCatalogoPorCategorias)
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Insertar(configuracionCatalogoPorCategorias);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Eliminar(idCategoria);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar()
        {
            AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new AccesoDatos.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Consultar();
        }
    }
}
