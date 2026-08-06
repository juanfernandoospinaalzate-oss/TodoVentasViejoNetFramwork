// -----------------------------------------------------------------------
// <copyright file="IUnidadMasa.cs" company="Todo Ventas Colombia">
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
    public interface IUnidadMasa
    {
        /// <summary>
        /// Inserta una Unidad de masa nueva en la base de datos.
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.UnidadMasa unidadMasa);

        /// <summary>
        /// Actualizar una Unidad de masa nueva en la base de datos.
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadMasa unidadMasa);

        /// <summary>
        /// Elimina una Unidad de masa nueva en la base de datos.
        /// </summary>
        /// <param name="idmasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idmasa);

        /// <summary>
        /// Listar una Unidades de masa nueva en la base de datos.
        /// </summary>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadMasa> Listar();
                
        /// <summary>
        /// verificar si el nombre de la unidad de masa ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="unidadMasa">objeto con los datos que se desean verificar</param>
        /// <returns>true si la Talla ya existe con (otro Id), o false si no existe la Talla</returns>
        [OperationContract]
        bool UnidadMasaVerificarDuplicidad(Entidades.UnidadMasa unidadMasa);

        /// <summary>
        /// verificar si el nombre de la unidad de masa ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="idmasa">identificación con los datos que se desean verificar</param>
        /// <returns>true si la Talla ya existe con (otro Id), o false si no existe la Talla</returns>
        [OperationContract]
        bool UnidadMasaVerificarRelacionArticulo(int idmasa);
    }
}
