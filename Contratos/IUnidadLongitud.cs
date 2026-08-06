// -----------------------------------------------------------------------
// <copyright file="IUnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web UnidadLongitud.svc
    /// </summary>
    [ServiceContract]
    public interface IUnidadLongitud
    {
        /// <summary>
        /// Inserta una Unidad de longitud nueva en la base de datos.
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.UnidadLongitud unidadLongitud);

        /// <summary>
        /// Elimina una Unidad de longitud nueva en la base de datos.
        /// </summary>
        /// <param name="idlongitud">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idlongitud);

        /// <summary>
        /// Actualizar una unidad de volúmen nueva en la base de datos.
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadLongitud unidadLongitud);

        /// <summary>
        /// Listar una Unidades de longitud nueva en la base de datos.
        /// </summary>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud> Listar();

        /// <summary>
        /// verificar si el nombre de la unidad de volúmen ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="unidadLongitud">objeto con los datos que se desean verificar</param>
        /// <returns>true si la unidad de volúmen ya existe con (otro Id), o false si no existe la unidad de volúmen</returns>
        [OperationContract]
        bool UnidadLongitudVerificarDuplicidad(Entidades.UnidadLongitud unidadLongitud);
    }
}
