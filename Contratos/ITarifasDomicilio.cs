//-----------------------------------------------------------------------
// <copyright file="ITarifasDomicilio.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ITarifasDomicilio
    {
        /// <summary>
        /// Inserta una tarifa domicilio nueva en la base de datos.
        /// </summary>
        /// <param name="tarifasDomicilio">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio);

        /// <summary>
        /// Actualiza una tarifa domicilio nueva en la base de datos.
        /// </summary>
        /// <param name="tarifasDomicilio">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio);

        /// <summary>
        /// Elimina una tarifa domicilio de la base de datos
        /// </summary>
        /// <param name="idtarifasDomicilio">Identificación con los datos que se desean Eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idtarifasDomicilio);

        /// <summary>
        /// Obtiene una lista con todos las tarifas domicilio disponibles
        /// </summary>
        /// <returns>Lista con todos las tarifas domicilio disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.TarifasDomicilio> Listar();

    }
}
