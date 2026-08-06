//-----------------------------------------------------------------------
// <copyright file="Cliente.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ServiciosWebPublica
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
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.Insertar(cliente, direccion);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente)
        {
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.SeleccionarClientePorIdCliente(idCliente);
        }

        /// <summary>
        /// Actualiza los datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del usuario para actualizar en la base de datos</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente)
        {
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorEmail(string email)
        {
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.SeleccionarClientePorEmail(email);
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
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.CambioPassword(idCliente, passwordNuevo, passwordNuevoVerificacion, passwordActual);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.SeleccionarClientePorDocCliente(docCliente);
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
            Validacion.WebPublica.Cliente validacionCliente = new Validacion.WebPublica.Cliente();
            return validacionCliente.RecuperarPassword(idCliente, passwordNuevo, passwordNuevoVerificacion);
        }
    }
}
