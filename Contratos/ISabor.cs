// -----------------------------------------------------------------------
// <copyright file="ISabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Sabor.svc
    /// </summary>
    [ServiceContract]
    public interface ISabor
    {
        /// <summary>
        /// Inserta un Sabor nuevo en la base de datos.
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Sabor sabor);

        /// <summary>
        /// Obtiene la lista de Sabor almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Color</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Sabor> Listar();

        /// <summary>
        /// Elimina el registro de un sabor existente en la base de datos.
        /// </summary>
        /// <param name="idsabor">Identificación del color en la base de datos</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idsabor);

        /// <summary>
        /// Actualiza los datos de un Sabor existente en la base de datos.
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Sabor sabor);
    }
}
