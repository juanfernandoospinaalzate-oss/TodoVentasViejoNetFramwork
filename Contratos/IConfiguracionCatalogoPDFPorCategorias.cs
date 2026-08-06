namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConfiguracionCatalogoPDFPorCategorias
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias configuracionCatalogoPorCategorias);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar();

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idCategoria);
    }
}
