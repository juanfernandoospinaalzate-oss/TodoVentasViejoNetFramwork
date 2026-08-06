// -----------------------------------------------------------------------
// <copyright file="IMarca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web IMarca.svc
    /// </summary>
    [ServiceContract]
    public interface IMarca
    {
        /// <summary>
        /// Inserta una marca nueva en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Marca marca);

        /// <summary>
        /// Actualiza una marca nueva en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Marca marca);

        /// <summary>
        /// Elimina una marca de la base de datos
        /// </summary>
        /// <param name="idmarca">Identificación con los datos que se desean Eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idmarca);

        /// <summary>
        /// Obtiene una lista con todos las marcas disponibles
        /// </summary>
        /// <returns>Lista con todos las marcas disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar();

        /// <summary>
        /// Obtiene una lista con todos las marcas disponibles ordenadas por idMarca
        /// </summary>
        /// <returns>Lista con todos las marcas disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca);

        [OperationContract]
        bool VerificarRelacionArticulo(int idMarca);
    }
}
