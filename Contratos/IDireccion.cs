//-----------------------------------------------------------------------
// <copyright file="IDireccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Dirección
    /// </summary>
    [ServiceContract]
    public interface IDireccion
    {
        /// <summary>
        /// Obtiene todas las direcciones asociadas a un cliente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>listado de direcciones asociadas al cliente encontrado</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Direccion> ConsultarDireccionPorId(int idCliente);
    }
}
