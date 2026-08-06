//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Validacion.WebPublica
{
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
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            if (cliente == null)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (direccion == null)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (string.IsNullOrEmpty(cliente.Nombre.Trim()))
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0010");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (string.IsNullOrEmpty(cliente.Apellido.Trim()))
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0010");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (string.IsNullOrEmpty(cliente.Telefono1.Trim()))
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0010");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (cliente.Contrasena != cliente.ConfirmarContrasena)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0010");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(cliente.Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$") == false || System.Text.RegularExpressions.Regex.IsMatch(cliente.Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") == false)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0100");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            return reglasDeNegocioCliente.Insertar(cliente, direccion);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente)
        {
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            return reglasDeNegocioCliente.SeleccionarClientePorIdCliente(idCliente);
        }

        /// <summary>
        /// Actualiza los datos del usuario del sitio web en la base de datos
        /// </summary>
        /// <param name="cliente">Datos del usuario</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente)
        {
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            return reglasDeNegocioCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorEmail(string email)
        {
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            return reglasDeNegocioCliente.SeleccionarClientePorEmail(email);
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
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();

            if (string.IsNullOrEmpty(passwordNuevo) == true || string.IsNullOrEmpty(passwordNuevoVerificacion) == true || string.IsNullOrEmpty(passwordActual) == true)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion.Mensaje = mensaje;
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            // validar el ingreso de la contraseña actual(que sea igual)
            EntidadesWeb.Cliente entidadCliente = this.SeleccionarClientePorIdCliente(idCliente);
            if (entidadCliente.DocCliente == 0)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion.Mensaje = mensaje;
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            return reglasDeNegocioCliente.CambioPassword(idCliente, passwordNuevo, passwordNuevoVerificacion, passwordActual);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">identificación legal del usuario</param>
        /// <returns>Datos del cliente</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            return reglasDeNegocioCliente.SeleccionarClientePorDocCliente(docCliente);
        }

        /// <summary>
        /// Reemplaza el password del usuario correspondiente en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del usuario</param>
        /// <param name="passwordNuevo">Nuevo password del usuario en el sitio web</param>
        /// <param name="passwordNuevoVerificacion">Confirmación del nuevo password del usuario en el sitio web</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion RecuperarPassword(int idCliente, string passwordNuevo, string passwordNuevoVerificacion)
        {
            ReglasDENegocio.WebPublica.Cliente reglasDeNegocioCliente = new ReglasDENegocio.WebPublica.Cliente();
            if (string.IsNullOrEmpty(passwordNuevo) == true || string.IsNullOrEmpty(passwordNuevoVerificacion) == true)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion.Mensaje = mensaje;
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            // validar el ingreso de la contraseña actual(que sea igual)
            EntidadesWeb.Cliente entidadCliente = this.SeleccionarClientePorIdCliente(idCliente);
            if (entidadCliente.DocCliente == 0)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion.Mensaje = mensaje;
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            return reglasDeNegocioCliente.RecuperarPassword(idCliente, passwordNuevo, passwordNuevoVerificacion);
        }
    }
}
