// -----------------------------------------------------------------------
// <copyright file="Cliente.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    using Entidades;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    public class Cliente : Contratos.ICliente
    {
        /// <summary>
        /// Manejo de datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del cliente</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public ResultadoTransaccion Actualizar(Entidades.Cliente cliente)
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Recupera los datos del cliente correspondiente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente usuario en la base de datos</param>
        /// <returns>datos del cliente encontrados</returns>
        public Entidades.Cliente BuscarClientePorDocCliente(int idCliente)
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.BuscarClientePorDocCliente(idCliente);
        }

        /// <summary>
        /// Ingresa un cliente nuevo en la base de datos
        /// </summary>
        /// <param name="cliente">Datos nuevos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Insertar(Entidades.Cliente cliente)
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.Insertar(cliente);
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista completa de clientes</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> Listar()
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.Listar();
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public Entidades.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.SeleccionarClientePorDocCliente(docCliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public Entidades.Cliente SeleccionarClientePorEmail(string email)
        {
            Validacion.TablasMaestras.Cliente validacionCliente = new Validacion.TablasMaestras.Cliente();
            return validacionCliente.SeleccionarClientePorEmail(email);
        }
    }
}
