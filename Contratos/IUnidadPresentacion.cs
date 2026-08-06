//-----------------------------------------------------------------------
// <copyright file="IUnidadPresentacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web UnidadesDeMasa.svc
    /// </summary>
    [ServiceContract]
    public interface IUnidadPresentacion
    {

        /// <summary>
        /// Inserta una Unidad de presentación nueva en la base de datos.
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.UnidadPresentacion unidadPresentacion);

        /// <summary>
        /// Actualizar una Unidad de presentación de la base de datos.
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadPresentacion unidadPresentacion);

        /// <summary>
        /// Elimina una Unidad de presentación de la base de datos.
        /// </summary>
        /// <param name="idmasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int IdUnidadPresentacion);

        /// <summary>
        /// Listar todas Unidades de presentación presentes en la base de datos.
        /// </summary>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadPresentacion> Listar();
    }
}
