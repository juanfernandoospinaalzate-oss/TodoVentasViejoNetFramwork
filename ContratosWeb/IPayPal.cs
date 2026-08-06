

namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IPayPal
    {
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTrasaccionPayPal SubmitTransaction(EntidadesWeb.ParametrosSubmitTransactionPayPal ParametrosSubmitTransactionPayPal);

    }
}
