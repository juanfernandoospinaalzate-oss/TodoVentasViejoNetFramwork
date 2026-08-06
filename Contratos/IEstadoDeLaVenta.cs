namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web IEstadoDeLaVenta.svc
    /// </summary>
    [ServiceContract]
    public interface IEstadoVenta
    {
        /// <summary>
        /// Inserta un EstadoDeLaVenta nuevo en la base de datos.
        /// </summary>
        /// <param name="estado de la venta">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.EstadoVenta estadoDeLaVenta);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.EstadoVenta estadoDeLaVenta);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.EstadoVenta> Listar();

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idEstadoVenta);

    }
}
