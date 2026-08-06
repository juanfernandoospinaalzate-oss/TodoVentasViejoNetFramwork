// -----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    /// <summary>
    /// Administra las direcciones del cliente
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
            AccesoDatos.TablasMaestras.Direccion direccion = new AccesoDatos.TablasMaestras.Direccion();
            return direccion.ConsultarDireccionPorId(idCliente);
        }
    }
}
