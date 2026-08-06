//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
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
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            cliente.Contrasena = Criptografia.Criptografia.Encriptar(cliente.Contrasena);
            cliente.ConfirmarContrasena = Criptografia.Criptografia.Encriptar(cliente.ConfirmarContrasena);

            // Si el Documento del cliente ya existe en la Base de Datos, no se hace inserción
            EntidadesWeb.Cliente resultadoBusquedaCliente = accesoDatosCliente.SeleccionarClientePorDocCliente(cliente.DocCliente);
            if (resultadoBusquedaCliente.IdCliente != 0)
            {
                // Devolver resultado de transacción no exitosa.
                EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0060");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultado.Mensaje.Texto));
                resultado.RegistrosAfectados = 0;
                return resultado;
            }

            // Si el Email del cliente ya existe en la Base de Datos, no se hace inserción
            resultadoBusquedaCliente = null;
            resultadoBusquedaCliente = accesoDatosCliente.SeleccionarClientePorEmail(cliente.Email);
            if (resultadoBusquedaCliente.IdCliente != 0)
            {
                // Devolver resultado de transacción no exitosa.
                EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0061");
                resultado.RegistrosAfectados = 0;
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultado.Mensaje.Texto));
                return resultado;
            }

            return accesoDatosCliente.Insertar(cliente, direccion);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente)
        {
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            return accesoDatosCliente.SeleccionarClientePorIdCliente(idCliente);
        }

        /// <summary>
        /// Actualiza los datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del usuario para actualizar en la base de datos</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente)
        {
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            return accesoDatosCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorEmail(string email)
        {
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            return accesoDatosCliente.SeleccionarClientePorEmail(email);
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
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            passwordNuevo = Criptografia.Criptografia.Encriptar(passwordNuevo);
            return accesoDatosCliente.CambioPassword(idCliente, passwordNuevo, passwordNuevoVerificacion, passwordActual);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">identificación legal del usuario</param>
        /// <returns>Datos del cliente</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            AccesoDatos.WebPublica.Cliente accesoDatosCliente = new AccesoDatos.WebPublica.Cliente();
            return accesoDatosCliente.SeleccionarClientePorDocCliente(docCliente);
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
            AccesoDatos.WebPublica.Cliente objCliente = new AccesoDatos.WebPublica.Cliente();
            passwordNuevo = Criptografia.Criptografia.Encriptar(passwordNuevo);
            return objCliente.RecuperarPassword(idCliente, passwordNuevo, passwordNuevoVerificacion);
        }
    }
}
