// -----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.TablasMaestras
{
    using Entidades;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    public class Cliente : Contratos.ICliente
    {
        /// <summary>
        /// Actualiza los datos del cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Datos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Actualizar(Entidades.Cliente cliente)
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return servicioClienteCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Recupera los datos del cliente correspondiente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente usuario en la base de datos</param>
        /// <returns>datos del cliente encontrados</returns>
        public Entidades.Cliente BuscarClientePorDocCliente(int idCliente)
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return servicioClienteCliente.BuscarClientePorDocCliente(idCliente);
        }

        /// <summary>
        /// Ingresa un cliente nuevo en la base de datos
        /// </summary>
        /// <param name="cliente">Datos nuevos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Insertar(Entidades.Cliente cliente)
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return servicioClienteCliente.Insertar(cliente);
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista completa de clientes</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> Listar()
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return servicioClienteCliente.Listar();
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public Entidades.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return null;
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public Entidades.Cliente SeleccionarClientePorEmail(string email)
        {
            ServicioCliente.ClienteClient servicioClienteCliente = new ServicioCliente.ClienteClient();
            return null;
        }
    }
}
