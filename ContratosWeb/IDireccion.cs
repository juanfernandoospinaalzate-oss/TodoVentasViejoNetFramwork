//-----------------------------------------------------------------------
// <copyright file="IDireccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ContratosWeb
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Dirección
    /// </summary>
    [ServiceContract]
    public interface IDireccion
    {
        /// <summary>
        /// Inserta una dirección nuevo en la base de datos.
        /// </summary>
        /// <param name="direccion">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Direccion direccion);

        /// <summary>
        /// Obtiene todas las direcciones asociadas al usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>listado de direcciones asociadas al usuario encontrado</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> ListarPorIdUsuario(int idUsuario);

        /// <summary>
        /// Actualiza la dirección del usuario
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.DireccionParaGrid direccion);

        /// <summary>
        /// Elimina la dirección de un usuario
        /// </summary>
        /// <param name="idDireccion">Identificación de la dirección en la base de datos</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Eliminar(int idDireccion);

        /// <summary>
        /// Consulta los datos de una dirección en concreto
        /// </summary>
        /// <param name="idDireccion">Identificación única de la dirección en la base de datos</param>
        /// <returns>Objeto con los datos de dirección solicitados</returns>
        [OperationContract]
        EntidadesWeb.Direccion ConsultarDireccionPorId(int idDireccion);
    }
}
