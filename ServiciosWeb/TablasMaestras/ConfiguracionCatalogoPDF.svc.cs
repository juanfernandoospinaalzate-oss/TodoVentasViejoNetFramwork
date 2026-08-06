namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Catalogo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Catalogo.svc o Catalogo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConfiguracionCatalogoPDF : Contratos.IConfiguracionCatalogoPDF
    {
        public Entidades.ConfiguracionCatalogoPDF Consultar()
        {
            Validacion.TablasMaestras.Catalogo validacionCatalogo = new Validacion.TablasMaestras.Catalogo();
            return validacionCatalogo.Consultar();
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            Validacion.TablasMaestras.Catalogo validacionCatalogo = new Validacion.TablasMaestras.Catalogo();
            return validacionCatalogo.Actualizar(catalogo);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            Validacion.TablasMaestras.Catalogo validacionCatalogo = new Validacion.TablasMaestras.Catalogo();
            return validacionCatalogo.Insertar(catalogo);
        }
    }
}
