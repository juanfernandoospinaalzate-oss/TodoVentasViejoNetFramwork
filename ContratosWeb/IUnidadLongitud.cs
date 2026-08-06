namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUnidadLongitud
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud();
    }
}
