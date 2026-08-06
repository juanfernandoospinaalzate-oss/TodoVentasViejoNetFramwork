//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Fachada.WebPublica
{
    using EntidadesWeb;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    public class Cliente : ContratosWeb.IClientes
    {
        /// <summary>
        /// Inserta un nuevo usuario para el sitio web
        /// </summary>
        /// <param name="cliente">Datos del nuevo usuario</param>
        /// <param name="direccion">Dirección usada para entregas</param>
        /// <returns>Resultado de la transacción con mensaje y número de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Cliente cliente, EntidadesWeb.Direccion direccion)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.Insertar(cliente, direccion);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();            
            return servicioCliente.SeleccionarClientePorIdCliente(idCliente);
        }

        /// <summary>
        /// Actualiza los datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del usuario para actualizar en la base de datos</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorEmail(string email)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.SeleccionarClientePorEmail(email);
        }

        /// <summary>
        /// Actualiza la clave de acceso del usuario en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del usuario en la base de datos</param>
        /// <param name="passwordNuevo">Nuevo password del usuario en el sitio web</param>
        /// <param name="passwordNuevoVerificacion">Confirmación del nuevo password del usuario en el sitio web</param>
        /// <param name="passwordActual">Password actual del usuario en el sitio web</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion CambioPassword(int idCliente, string passwordNuevo, string passwordNuevoVerificacion, string passwordActual)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.CambioPassword(idCliente, passwordNuevo, passwordNuevoVerificacion, passwordActual);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.SeleccionarClientePorDocCliente(docCliente);
        }

        /// <summary>
        /// Reemplaza el password del usuario correspondiente en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del usuario</param>
        /// <param name="passwordNuevo">Nuevo password del usuario en el sitio web</param>
        /// <param name="passwordNuevoVerificacion">Confirmación del nuevo password del usuario en el sitio web</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion RecuperarPassword(int idCliente, string passwordNuevo, string passwordNuevoVerificacion)
        {
            ServicioCliente.ClientesClient servicioCliente = new ServicioCliente.ClientesClient();
            return servicioCliente.RecuperarPassword(idCliente, passwordNuevo, passwordNuevoVerificacion);
        }
    }
}
