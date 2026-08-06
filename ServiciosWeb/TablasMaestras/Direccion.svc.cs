//-----------------------------------------------------------------------
// <copyright file="Direccion.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    /// <summary>
    /// Servicio web para manipulación de direcciones de los clientes
    /// </summary>
    public class Direccion : Contratos.IDireccion
    {
        /// <summary>
        /// Obtiene todas las direcciones asociadas a un cliente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>listado de direcciones asociadas al cliente encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Direccion> ConsultarDireccionPorId(int idCliente)
        {
            Validacion.TablasMaestras.Direccion direccion = new Validacion.TablasMaestras.Direccion();
            return direccion.ConsultarDireccionPorId(idCliente);
        }
    }
}
