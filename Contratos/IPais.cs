// -----------------------------------------------------------------------
// <copyright file="IPais.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web
    /// </summary>
    [ServiceContract]
    public interface IPais
    {
        /// <summary>
        /// Inserta un país nuevo en la base de datos.
        /// </summary>
        /// <param name="pais">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais);

        /// <summary>
        /// Obtiene una lista con todos los países disponibles
        /// </summary>
        /// <returns>Lista con todos los países disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar();

        /// <summary>
        /// Eliminar un país nuevo en la base de datos.
        /// </summary>
        /// <param name="idtalla">identificador de los datos que se desean eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idpais);

        /// <summary>
        /// Verifica si el país tiene por lo menos un departamento relacionado
        /// </summary>
        /// <param name="idpais">Identificación de la talla en la base de datos</param>
        /// <returns>true si la í tiene por lo menos un artículo relacionado, o false si no tiene nungún artículo relacionado</returns>
        [OperationContract]
        bool PaisVerificarRelacionDpto(int idpais);

    }
}
