// -----------------------------------------------------------------------
// <copyright file="IUnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web UnidadVolúmen.svc
    /// </summary>
    [ServiceContract]
    public interface IUnidadVolumen
    {
        /// <summary>
        /// Inserta una Unidad de volúmen nueva en la base de datos.
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.UnidadVolumen unidadVolumen);

        /// <summary>
        /// Elimina una Unidad de volúmen nueva en la base de datos.
        /// </summary>
        /// <param name="idvolumen">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idvolumen);

        /// <summary>
        /// Actualizar una Unidad de volúmen nueva en la base de datos.
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadVolumen unidadVolumen);

        /// <summary>
        /// Listar una Unidades de masa nueva en la base de datos.
        /// </summary>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadVolumen> Listar();

        /// <summary>
        /// verificar si el nombre de la unidad de volúmen ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="unidadVolumen">objeto con los datos que se desean verificar</param>
        /// <returns>true si la unidad de volúmen ya existe con (otro Id), o false si no existe la unidad de volúmen</returns>
        [OperationContract]
        bool UnidadVolumenVerificarDuplicidad(Entidades.UnidadVolumen unidadVolumen);
        
        /// <summary>
        /// verificar si el nombre de la unidad de volúmen ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="idvolumen">identificación con los datos que se desean verificar</param>
        /// <returns>true si la unidad de volúmen ya existe con (otro Id), o false si no existe la unidad de volúmen</returns>
        [OperationContract]
        bool UnidadVolumenVerificarRelacionArticulo(int idvolumen);
    }
}
