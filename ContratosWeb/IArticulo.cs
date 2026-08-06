namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IArticulo
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion();

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo);
    }
}
