namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUnidadVolumen
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen();
    }
}
