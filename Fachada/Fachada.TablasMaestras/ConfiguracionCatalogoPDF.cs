namespace Fachada.TablasMaestras
{
    public class ConfiguracionCatalogoPDF : Contratos.IConfiguracionCatalogoPDF
    {

        public Entidades.ConfiguracionCatalogoPDF Consultar()
        {
            ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient servicioCatalogo = new ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient();
            return servicioCatalogo.Consultar();
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient servicioCatalogo = new ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient();
            return servicioCatalogo.Actualizar(catalogo);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient servicioCatalogo = new ServicioConfiguracionCatalogoPDF.ConfiguracionCatalogoPDFClient();
            return servicioCatalogo.Insertar(catalogo);
        }
    }
}
