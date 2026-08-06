// -----------------------------------------------------------------------
// <copyright file="ITallas.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Tallas.svc
    /// </summary>
    [ServiceContract]
    public interface ITallas
    {
        /// <summary>
        /// Inserta una talla nueva en la base de datos.
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Talla talla);

        /// <summary>
        /// Actualiza una talla nueva en la base de datos.
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Talla talla);

        /// <summary>
        /// Eliminar una talla nueva en la base de datos.
        /// </summary>
        /// <param name="idtalla">identificador de los datos que se desean eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idtalla);

        /// <summary>
        /// Obtiene una lista con todos las tallas disponibles
        /// </summary>
        /// <returns>Lista con todos las tallas disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Talla> Listar();

        /// <summary>
        /// verificar si el nombre de la Talla ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="talla">identificador de los datos que se desean verificar</param>
        /// <returns>true si la Talla ya existe con (otro Id), o false si no existe la Talla</returns>
        [OperationContract]
        bool TallaVerificarDuplicidad(Entidades.Talla talla);

        /// <summary>
        /// Verifica si la Talla tiene por lo menos un artículo relacionado
        /// </summary>
        /// <param name="idTalla">Identificación de la talla en la base de datos</param>
        /// <returns>true si la talla tiene por lo menos un artículo relacionado, o false si no tiene nungún artículo relacionado</returns>
        [OperationContract]
        bool TallaVerificarRelacionArticulo(int idTalla);
    }
}
