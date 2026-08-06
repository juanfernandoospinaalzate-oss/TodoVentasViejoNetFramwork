
namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IPayU
    {
        [OperationContract]
        [CLSCompliant(true)]
        string Ping();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Banco> ListarBancosDisponibles();

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTrasaccionPayU SubmitTransaction(EntidadesWeb.ParametrosSubmitTransactionPayU ParametrosSubmitTransactionPayU);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Franquicia> ListarFranquiciasDisponibles();

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion GenerarCodigoReferenciaPayU();

        [OperationContract]
        [CLSCompliant(true)]
        string ConsultarOrdenPorIdentificador(int IdUsuario);

        [OperationContract]
        [CLSCompliant(true)]
        string ConsultarOrdenPorReferencia();

        [OperationContract]
        [CLSCompliant(true)]
        string ConsultarOrdenPorTransaccion();

        [OperationContract]
        [CLSCompliant(true)]
        bool ValidarValorMinimoPagosEfecty(int IdUsuario, double ValorPagoEfecty);

        [OperationContract]
        [CLSCompliant(true)]
        bool ValidarValorMinimoPagosBaloto(int idUsuario, double valorPagoBaloto);

        [OperationContract]
        [CLSCompliant(true)]
        bool ValidarValorMinimoTarjetaCredito(int idUsuario, double valorPagoTarjetaCredito);

        [OperationContract]
        [CLSCompliant(true)]
        bool ValidarValorMinimoCuentaAhorros(int idUsuario, double valorPagoCuentaAhorros);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Franquicia> ListarTarjetasDeCreditoConfiguradas();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Franquicia> ListarMediosEnEfectivoConfigurados();
    }
}
