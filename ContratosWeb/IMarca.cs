// -----------------------------------------------------------------------
// <copyright file="IMarca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace ContratosWeb
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web IMarca.svc
    /// </summary>
    [ServiceContract]
    public interface IMarca
    {

        /// <summary>
        /// Obtiene una lista con todos las marcas disponibles
        /// </summary>
        /// <returns>Lista con todos las marcas disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Marca> Listar();
    }
}
