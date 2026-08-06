
namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web departamento
    /// </summary>
    [ServiceContract]
    public interface IDepartamento
    {
        /// <summary>
        /// Inserta un departamento nuevo en la base de datos.
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento);

        /// <summary>
        /// Obtiene una lista con todos los países disponibles
        /// </summary>
        /// <returns>Lista con todos los países disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento);

        /// <summary>
        /// Elimina un departamento en la base de datos.
        /// </summary>
        /// <param name="idDepartamento">identificador de los datos que se desean eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idDepartamento);



    }
}
