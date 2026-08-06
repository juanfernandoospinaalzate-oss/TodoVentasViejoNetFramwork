namespace Contratos
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Articulos.svc
    /// </summary>
    [ServiceContract]
    public interface IAlmacen
    {
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar();

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idAlmacen);
    }
}
