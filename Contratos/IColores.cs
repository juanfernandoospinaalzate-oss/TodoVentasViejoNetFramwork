// -----------------------------------------------------------------------
// <copyright file="IColores.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Colores.svc
    /// </summary>
    [ServiceContract]
    public interface IColores
    {
        /// <summary>
        /// Inserta un color nuevo en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Color color);

        /// <summary>
        /// Actualiza los datos de un color existente en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean actualizar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Color color);

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificación del color en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idColor);

        /// <summary>
        /// Obtiene una lista con todos los colores disponibles
        /// </summary>
        /// <returns>Lista con todos los colores disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> Listar();

        /// <summary>
        /// Obtiene los datos de un color buscando por us ID único de tabla.
        /// </summary>
        /// <param name="idColor">Identificación de color en la base de datos.</param>
        /// <returns>Objeto de tipo color buscado, en caso de no encontrarlo retorna un valor null</returns>
        [OperationContract]
        Entidades.Color ConsultarPorId(int idColor);

        /// <summary>
        /// Indica si el color tiene un registro relacionado en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificador del color.</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        [OperationContract]
        bool ColorVerificarRelacionArticulo(int idColor);

        /// <summary>
        /// Indica si el código hexadecimal ya existe en un registro de la tabla de colores
        /// </summary>
        /// <param name="color">código RGB en formato Hexadecimal de 6 caracteres</param>
        /// <returns>true si el código ya está registrado o false si el código no está registrado</returns>
        [OperationContract]
        bool ColorVerificaUnicidadCodigo(Entidades.Color color);

        /// <summary>
        /// indica si el nombre del color ya se encuentra registrado en la tabla de colores
        /// </summary>
        /// <param name="nombreColor">Nombre del color de 20 caracteres como máximo</param>
        /// <returns>true si el nombre ya está registrado o false si el nombre no está registrado</returns>
        [OperationContract]
        bool ColorVerificaUnicidadNombre(string nombreColor);
    }
}
