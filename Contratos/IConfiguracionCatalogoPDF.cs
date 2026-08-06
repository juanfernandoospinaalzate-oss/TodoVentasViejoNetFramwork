namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConfiguracionCatalogoPDF
    {
        [OperationContract]
        Entidades.ConfiguracionCatalogoPDF Consultar();

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF configuracionCatalogo);

        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF configuracionCatalogo);
    }
}
