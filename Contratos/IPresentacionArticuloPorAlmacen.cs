namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IPresentacionArticuloPorAlmacen
    {
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas);

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen);

        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas);


        // METODOS PARA EL BOTON REMOVER
        [OperationContract]
        Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas);

        [OperationContract]
        Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas);


    }

}