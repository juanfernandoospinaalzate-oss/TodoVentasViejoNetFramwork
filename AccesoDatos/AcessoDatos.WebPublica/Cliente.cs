//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Data;
    using EntidadesWeb;

    /// <summary>
    /// Administra los datos del usuario en el sitio web
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
            if (cliente == null && direccion == null)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramDocCliente = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramApellido = null;
            System.Data.SqlClient.SqlParameter paramTelefono1 = null;
            System.Data.SqlClient.SqlParameter paramTelefono2 = null;
            System.Data.SqlClient.SqlParameter parameMail = null;
            System.Data.SqlClient.SqlParameter paramContrasena = null;
            System.Data.SqlClient.SqlParameter paramOutIdCliente = null;

            System.Data.SqlClient.SqlCommand cmdDireccion = null;
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = null;
            System.Data.SqlClient.SqlParameter paramDireccion = null;
            System.Data.SqlClient.SqlParameter paramTelefono = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Data.SqlClient.SqlParameter paramIdDpto = null;
            System.Data.SqlClient.SqlParameter paramIdCiudad = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            System.Data.SqlClient.SqlConnection conexion = null;
            System.Data.SqlClient.SqlTransaction transaccion = null;
            EntidadesWeb.ResultadoTransaccion resultado = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = null;

            try
            {
                resultado = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

                // Clientes
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteInsert";

                paramDocCliente = new System.Data.SqlClient.SqlParameter("@DocCliente", System.Data.SqlDbType.Int);
                paramDocCliente.Value = cliente.DocCliente;
                cmd.Parameters.Add(paramDocCliente);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 30);
                paramNombre.Value = cliente.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramApellido = new System.Data.SqlClient.SqlParameter("@Apellido", System.Data.SqlDbType.NVarChar, 30);
                paramApellido.Value = cliente.Apellido;
                cmd.Parameters.Add(paramApellido);

                paramTelefono1 = new System.Data.SqlClient.SqlParameter("@Telefono1", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono1.Value = cliente.Telefono1;
                cmd.Parameters.Add(paramTelefono1);

                paramTelefono2 = new System.Data.SqlClient.SqlParameter("@Telefono2", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono2.Value = cliente.Telefono2;
                cmd.Parameters.Add(paramTelefono2);

                parameMail = new System.Data.SqlClient.SqlParameter("@eMail", System.Data.SqlDbType.NVarChar, 50);
                parameMail.Value = cliente.Email;
                cmd.Parameters.Add(parameMail);

                paramContrasena = new System.Data.SqlClient.SqlParameter("@Contrasena", System.Data.SqlDbType.NVarChar, 50);
                paramContrasena.Value = cliente.Contrasena;
                cmd.Parameters.Add(paramContrasena);

                paramOutIdCliente = new System.Data.SqlClient.SqlParameter("@OutIdCliente", System.Data.SqlDbType.Int);
                paramOutIdCliente.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdCliente);

                // Direcciones
                cmdDireccion = new System.Data.SqlClient.SqlCommand();
                cmdDireccion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDireccion.CommandText = "DireccionInsert";

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = direccion.NombreDestinatario;
                cmdDireccion.Parameters.Add(paramNombreDestinatario);

                paramDireccion = new System.Data.SqlClient.SqlParameter("@DireccionEnvio", System.Data.SqlDbType.NVarChar, 30);
                paramDireccion.Value = direccion.DireccionEnvio;
                cmdDireccion.Parameters.Add(paramDireccion);

                paramTelefono = new System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.NVarChar, 30);
                paramTelefono.Value = direccion.Telefono;
                cmdDireccion.Parameters.Add(paramTelefono);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = direccion.Pais.IdPais;
                cmdDireccion.Parameters.Add(paramIdPais);

                paramIdDpto = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDpto.Value = direccion.Departamento.IdDepartamento;
                cmdDireccion.Parameters.Add(paramIdDpto);

                paramIdCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramIdCiudad.Value = direccion.Ciudad.IdCiudad;
                cmdDireccion.Parameters.Add(paramIdCiudad);

                conexion = AccesoDatos.WebPublica.Conexion.NuevaConexion();

                cmd.Connection = conexion;
                cmdDireccion.Connection = conexion;

                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmd.Transaction = transaccion;
                cmdDireccion.Transaction = transaccion;
                int i = cmd.ExecuteNonQuery();

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.NVarChar, 30);
                paramIdCliente.Value = paramOutIdCliente.Value;
                cmdDireccion.Parameters.Add(paramIdCliente);

                int j = cmdDireccion.ExecuteNonQuery();

                resultado.RegistrosAfectados = i + j;

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif

                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                transaccion.Rollback();
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                transaccion.Rollback();
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.Cliente datosPersonales = new EntidadesWeb.Cliente();

            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorIdCliente";
                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = idCliente;
                cmd.Parameters.Add(paramIdCliente);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    datosPersonales.IdCliente = datareader.GetInt32(0);
                    datosPersonales.DocCliente = datareader.GetInt32(1);
                    datosPersonales.Nombre = datareader.GetString(2);
                    datosPersonales.Apellido = datareader.GetString(3);
                    datosPersonales.Telefono1 = datareader.GetString(4);
                    datosPersonales.Telefono2 = datareader.GetString(5);
                    datosPersonales.Email = datareader.GetString(6);
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return datosPersonales;
        }

        /// <summary>
        /// Actualiza los datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del usuario para actualizar en la base de datos</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente)
        {
            if (cliente == null)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramApellido = null;
            System.Data.SqlClient.SqlParameter paramTelefono1 = null;
            System.Data.SqlClient.SqlParameter paramTelefono2 = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteUpdate";

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = cliente.IdCliente;
                cmd.Parameters.Add(paramIdCliente);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 30);
                paramNombre.Value = cliente.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramApellido = new System.Data.SqlClient.SqlParameter("@Apellido", System.Data.SqlDbType.NVarChar, 30);
                paramApellido.Value = cliente.Apellido;
                cmd.Parameters.Add(paramApellido);

                paramTelefono1 = new System.Data.SqlClient.SqlParameter("@Telefono1", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono1.Value = cliente.Telefono1;
                cmd.Parameters.Add(paramTelefono1);

                paramTelefono2 = new System.Data.SqlClient.SqlParameter("@Telefono2", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono2.Value = cliente.Telefono2;
                cmd.Parameters.Add(paramTelefono2);

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = cliente.Email;
                cmd.Parameters.Add(paramEmail);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorEmail(string email)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            EntidadesWeb.Cliente datosPersonales = new EntidadesWeb.Cliente();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorEmail";

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = email;
                cmd.Parameters.Add(paramEmail);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    datosPersonales.IdCliente = datareader.GetInt32(0);
                    datosPersonales.DocCliente = datareader.GetInt32(1);
                    datosPersonales.Nombre = datareader.GetString(2);
                    datosPersonales.Apellido = datareader.GetString(3);
                    datosPersonales.Telefono1 = datareader.GetString(4);
                    datosPersonales.Telefono2 = datareader.GetString(5);
                    datosPersonales.Email = datareader.GetString(6);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return datosPersonales;
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
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramPasswordNuevo = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteCambioPassword";

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = idCliente;
                cmd.Parameters.Add(paramIdCliente);

                paramPasswordNuevo = new System.Data.SqlClient.SqlParameter("@PasswordNuevo", System.Data.SqlDbType.NVarChar, 50);
                paramPasswordNuevo.Value = passwordNuevo;
                cmd.Parameters.Add(paramPasswordNuevo);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">identificación legal del usuario</param>
        /// <returns>Datos del cliente</returns>
        public EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.Cliente datosPersonales = new EntidadesWeb.Cliente();
            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorDocCliente";
                paramIdCliente = new System.Data.SqlClient.SqlParameter("@docCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = docCliente;
                cmd.Parameters.Add(paramIdCliente);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    datosPersonales.IdCliente = datareader.GetInt32(0);
                    datosPersonales.DocCliente = datareader.GetInt32(1);
                    datosPersonales.Nombre = datareader.GetString(2);
                    datosPersonales.Apellido = datareader.GetString(3);
                    datosPersonales.Telefono1 = datareader.GetString(4);
                    datosPersonales.Telefono2 = datareader.GetString(5);
                    datosPersonales.Email = datareader.GetString(6);
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return datosPersonales;
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
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramPasswordNuevo = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteResetPassword";

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = idCliente;
                cmd.Parameters.Add(paramIdCliente);

                paramPasswordNuevo = new System.Data.SqlClient.SqlParameter("@PasswordNuevo", System.Data.SqlDbType.NVarChar, 50);
                paramPasswordNuevo.Value = passwordNuevo;
                cmd.Parameters.Add(paramPasswordNuevo);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }
    }
}
