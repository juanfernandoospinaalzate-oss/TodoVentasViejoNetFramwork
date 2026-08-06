namespace Validacion.TablasMaestras
{
    public class ConfiguracionCatalogoPDFPorCategorias : Contratos.IConfiguracionCatalogoPDFPorCategorias
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias ConfiguracionCatalogoPorCategorias)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Insertar(ConfiguracionCatalogoPorCategorias);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Eliminar(idCategoria);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar()
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Consultar();
        }
    }
}
