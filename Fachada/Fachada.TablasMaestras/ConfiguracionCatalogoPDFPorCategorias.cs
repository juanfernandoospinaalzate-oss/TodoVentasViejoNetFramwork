namespace Fachada.TablasMaestras
{
    public class ConfiguracionCatalogoPDFPorCategorias : Contratos.IConfiguracionCatalogoPDFPorCategorias
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias configuracionCatalogoPorCategorias)
        {
            ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient Catalogo = new ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient();
            return Catalogo.Insertar(configuracionCatalogoPorCategorias);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar()
        {
            ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient Catalogo = new ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient();
            return Catalogo.Consultar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient Catalogo = new ServicioConfiguracionCatalogoPDFPorCategorias.ConfiguracionCatalogoPDFPorCategoriasClient();
            return Catalogo.Eliminar(idCategoria);
        }
    }
}
