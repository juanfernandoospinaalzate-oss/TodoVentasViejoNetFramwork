

namespace ContratosWeb
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web UnidadesDeMasa.svc
    /// </summary>
    [ServiceContract]
    public interface IUnidadPresentacion
    {
        /// <summary>
        /// Listar todas Unidades de presentación presentes en la base de datos.
        /// </summary>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar();
    }
}
