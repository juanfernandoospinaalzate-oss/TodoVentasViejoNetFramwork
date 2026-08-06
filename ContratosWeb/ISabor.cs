namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface ISabor
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores();
    }
}
