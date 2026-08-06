namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IMedioDePago
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.MetodoDePago metodoDePago);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.MetodoDePago> Listar();

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int IdMedioPago);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.MetodoDePago metodoDePago);
    }
}
