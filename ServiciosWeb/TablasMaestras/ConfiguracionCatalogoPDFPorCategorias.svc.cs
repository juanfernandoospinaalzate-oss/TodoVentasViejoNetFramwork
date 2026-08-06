namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConfiguracionCatalogoPDFPorCategorias" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ConfiguracionCatalogoPDFPorCategorias.svc o ConfiguracionCatalogoPDFPorCategorias.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConfiguracionCatalogoPDFPorCategorias : Contratos.IConfiguracionCatalogoPDFPorCategorias
    {

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias ConfiguracionCatalogoPorCategorias)
        {
            Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Insertar(ConfiguracionCatalogoPorCategorias);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Eliminar(idCategoria);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar()
        {
            Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new Validacion.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            return Catalogo.Consultar();
        }
    }
}
