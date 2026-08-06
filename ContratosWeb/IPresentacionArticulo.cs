namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IPresentacionArticulo
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion();

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo);
    }
}
