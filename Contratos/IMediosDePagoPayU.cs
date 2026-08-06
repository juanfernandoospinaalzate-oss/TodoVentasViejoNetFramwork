namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web IPayU.svc
    /// </summary>
    [ServiceContract]
    public interface IMediosDEPagoPayU
    {
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTodasLasFranquicias();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTarjetasDeCreditoConfiguradas();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarMediosEnEfectivoConfigurados();

        [OperationContract]
        Entidades.ResultadoTransaccion InsertarTarjetaDeCredito(Entidades.Franquicia franquicia);

        [OperationContract]
        Entidades.ResultadoTransaccion InsertarMedioEnEfectivo(Entidades.Franquicia franquicia);

        [OperationContract]
        Entidades.ResultadoTransaccion EliminarTarjetaDeCredito(Entidades.Franquicia franquicia);

        [OperationContract]
        Entidades.ResultadoTransaccion EliminarMedioEnEfectivo(Entidades.Franquicia franquicia);
    }
}
