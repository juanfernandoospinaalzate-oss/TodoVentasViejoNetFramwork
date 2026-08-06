namespace Validacion.TablasMaestras
{
    public class Catalogo : Contratos.IConfiguracionCatalogoPDF
    {

        public Entidades.ConfiguracionCatalogoPDF Consultar()
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF reglasDENegocioCatalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF();
            return reglasDENegocioCatalogo.Consultar();
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF reglasDENegocioCatalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF();
            return reglasDENegocioCatalogo.Actualizar(catalogo);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF reglasDENegocioCatalogo = new ReglasDENegocio.TablasMaestras.ConfiguracionCatalogoPDF();
            Entidades.ConfiguracionCatalogoPorCategorias ConfiguracionCatalogoPorCategorias = new Entidades.ConfiguracionCatalogoPorCategorias();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            int x = int.MinValue;
            if (int.TryParse(ConfiguracionCatalogoPorCategorias.NroColumnas.ToString(), out x))
            {
                return reglasDENegocioCatalogo.Insertar(catalogo);
            }
            else
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0017");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

        }

    }
}
