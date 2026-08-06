namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IConfiguracionFactura
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Guardar(Entidades.ConfiguracionFactura configuracionFactura);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(int nroFactura);
    }
}
