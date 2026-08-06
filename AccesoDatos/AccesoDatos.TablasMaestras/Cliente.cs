// -----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;
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
            System.Data.SqlClient.SqlCommand cmdCliente = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramApellido = null;
            System.Data.SqlClient.SqlParameter paramTelefono1 = null;
            System.Data.SqlClient.SqlParameter paramTelefono2 = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            System.Data.SqlClient.SqlCommand cmdDireccion = null;
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = null;
            System.Data.SqlClient.SqlParameter paramDireccion = null;
            System.Data.SqlClient.SqlParameter paramTelefono = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Data.SqlClient.SqlParameter paramIdDpto = null;
            System.Data.SqlClient.SqlParameter paramIdCiudad = null;
            System.Data.SqlClient.SqlParameter paramIdDireccion = null;
            System.Data.SqlClient.SqlConnection conexion = null;
            System.Data.SqlClient.SqlTransaction transaccion = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            if (cliente == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            try
            {
                cmdCliente = new System.Data.SqlClient.SqlCommand();
                cmdCliente.CommandType = System.Data.CommandType.StoredProcedure;
                cmdCliente.CommandText = "ClienteUpdate";

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = cliente.IdCliente;
                cmdCliente.Parameters.Add(paramIdCliente);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 30);
                paramNombre.Value = cliente.Nombre;
                cmdCliente.Parameters.Add(paramNombre);

                paramApellido = new System.Data.SqlClient.SqlParameter("@Apellido", System.Data.SqlDbType.NVarChar, 30);
                paramApellido.Value = cliente.Apellido;
                cmdCliente.Parameters.Add(paramApellido);

                paramTelefono1 = new System.Data.SqlClient.SqlParameter("@Telefono1", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono1.Value = cliente.Telefono1;
                cmdCliente.Parameters.Add(paramTelefono1);

                paramTelefono2 = new System.Data.SqlClient.SqlParameter("@Telefono2", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono2.Value = cliente.Telefono2;
                cmdCliente.Parameters.Add(paramTelefono2);

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = cliente.Email;
                cmdCliente.Parameters.Add(paramEmail);

                // Direcciones
                cmdDireccion = new System.Data.SqlClient.SqlCommand();
                cmdDireccion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDireccion.CommandText = "DireccionUpdate";

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = cliente.Direcciones[0].NombreDestinatario;
                cmdDireccion.Parameters.Add(paramNombreDestinatario);

                paramDireccion = new System.Data.SqlClient.SqlParameter("@DireccionEnvio", System.Data.SqlDbType.NVarChar, 30);
                paramDireccion.Value = cliente.Direcciones[0].DireccionEnvio;
                cmdDireccion.Parameters.Add(paramDireccion);

                paramTelefono = new System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.NVarChar, 30);
                paramTelefono.Value = cliente.Direcciones[0].Telefono;
                cmdDireccion.Parameters.Add(paramTelefono);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = cliente.Direcciones[0].Pais.IdPais;
                cmdDireccion.Parameters.Add(paramIdPais);

                paramIdDpto = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDpto.Value = cliente.Direcciones[0].Departamento.IdDepartamento;
                cmdDireccion.Parameters.Add(paramIdDpto);

                paramIdCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramIdCiudad.Value = cliente.Direcciones[0].Ciudad.IdCiudad;
                cmdDireccion.Parameters.Add(paramIdCiudad);

                paramIdDireccion = new System.Data.SqlClient.SqlParameter("@IdDireccion", System.Data.SqlDbType.Int);
                paramIdDireccion.Value = cliente.Direcciones[0].IdDireccion;
                cmdDireccion.Parameters.Add(paramIdDireccion);

                conexion = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                conexion.Open();

                cmdCliente.Connection = conexion;
                cmdDireccion.Connection = conexion;
                transaccion = conexion.BeginTransaction();
                cmdCliente.Transaction = transaccion;
                cmdDireccion.Transaction = transaccion;
                
                int i = cmdCliente.ExecuteNonQuery();
                int j = cmdDireccion.ExecuteNonQuery();

                if (i == 1 && j == 1)
                {
                    transaccion.Commit();
                    resultadoTransaccion.RegistrosAfectados = 1;
                }
                else
                {
                    transaccion.Rollback();
                    resultadoTransaccion.RegistrosAfectados = 0;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                transaccion.Rollback();
                resultadoTransaccion.Mensaje.Texto = ex.Message.ToString();
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                transaccion.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
                return resultadoTransaccion;
            }
            finally
            {
                if (cmdCliente.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmdCliente.Connection.Close();
                }

                if (cmdCliente != null)
                {  
                    cmdCliente.Dispose();
                }
            }

            return resultadoTransaccion;
        }

        /// <summary>
        /// Recupera los datos del cliente correspondiente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente usuario en la base de datos</param>
        /// <returns>datos del cliente encontrados</returns>
        public Entidades.Cliente BuscarClientePorDocCliente(int idCliente)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlDataReader datareaderDirecciones = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            Entidades.Cliente datosPersonales = new Entidades.Cliente();
            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorDocCliente";
                paramIdCliente = new System.Data.SqlClient.SqlParameter("@docCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = idCliente;
                cmd.Parameters.Add(paramIdCliente);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
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

                // Consultar las direcciones registradas para el cliente
                if (datareader.HasRows == true)
                {
                    cmd.CommandText = "DireccionSelectDocCliente";
                    cmd.Parameters.Clear();
                    paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                    paramIdCliente.Value = idCliente;
                    cmd.Parameters.Add(paramIdCliente);
                    datareaderDirecciones = cmd.ExecuteReader();

                    if (datareaderDirecciones.Read())
                    {
                        Entidades.Direccion direccion = new Entidades.Direccion();
                        direccion.IdDireccion = datareaderDirecciones.GetInt32(0);
                        direccion.NombreDestinatario = datareaderDirecciones.GetString(1);
                        direccion.DireccionEnvio = datareaderDirecciones.GetString(2);
                        direccion.Telefono = datareaderDirecciones.GetString(3);
                        direccion.Pais.IdPais = datareaderDirecciones.GetInt32(4);
                        direccion.Departamento.IdDepartamento = datareaderDirecciones.GetInt32(5);
                        direccion.Ciudad.IdCiudad = datareaderDirecciones.GetInt32(6);
                        direccion.IdCliente = datareaderDirecciones.GetInt32(7);
                        direccion.Pais.Nombre = datareaderDirecciones.GetString(8);
                        direccion.Departamento.Nombre = datareaderDirecciones.GetString(9);
                        direccion.Ciudad.Nombre = datareaderDirecciones.GetString(10);
                        datosPersonales.Direcciones.Add(direccion);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
                if (datareader != null)
                {
                    datareader.Close();
                }

                if (datareaderDirecciones != null)
                {
                    datareaderDirecciones.Close();
                }
            }

            return datosPersonales;
        }

        /// <summary>
        /// Ingresa un cliente nuevo en la base de datos
        /// </summary>
        /// <param name="cliente">Datos nuevos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Insertar(Entidades.Cliente cliente)
        {
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

            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            if (cliente == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            try
            {
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
                paramOutIdCliente.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdCliente);

                // Direcciones
                cmdDireccion = new System.Data.SqlClient.SqlCommand();
                cmdDireccion.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDireccion.CommandText = "DireccionInsert";

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = cliente.Direcciones[0].NombreDestinatario;
                cmdDireccion.Parameters.Add(paramNombreDestinatario);

                paramDireccion = new System.Data.SqlClient.SqlParameter("@DireccionEnvio", System.Data.SqlDbType.NVarChar, 30);
                paramDireccion.Value = cliente.Direcciones[0].DireccionEnvio;
                cmdDireccion.Parameters.Add(paramDireccion);

                paramTelefono = new System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.NVarChar, 30);
                paramTelefono.Value = cliente.Direcciones[0].Telefono;
                cmdDireccion.Parameters.Add(paramTelefono);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = cliente.Direcciones[0].Pais.IdPais;
                cmdDireccion.Parameters.Add(paramIdPais);

                paramIdDpto = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDpto.Value = cliente.Direcciones[0].Departamento.IdDepartamento;
                cmdDireccion.Parameters.Add(paramIdDpto);

                paramIdCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramIdCiudad.Value = cliente.Direcciones[0].Ciudad.IdCiudad;
                cmdDireccion.Parameters.Add(paramIdCiudad);

                conexion = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);

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

                if (i == 1 && j == 1)
                {
                    resultadoTransaccion.RegistrosAfectados = 1;
                    transaccion.Commit();
                }
                else
                {
                    resultadoTransaccion.RegistrosAfectados = 0;
                    transaccion.Rollback();
                }

                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                transaccion.Rollback();
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
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

            return resultadoTransaccion;
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista completa de clientes</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> Listar()
        {
            List<Entidades.Cliente> listaClientes = new List<Entidades.Cliente>();
            AccesoDatos.TablasMaestras.Direccion direccion = new AccesoDatos.TablasMaestras.Direccion();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> listaReadOnlyCliente = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Cliente cliente = new Entidades.Cliente();
                    cliente.IdCliente = datareader.GetInt32(0);
                    cliente.DocCliente = datareader.GetInt32(1);
                    cliente.Nombre = datareader.GetString(2);
                    cliente.Apellido = datareader.GetString(3);
                    cliente.Telefono1 = datareader.GetString(4);
                    cliente.Telefono2 = datareader.GetString(5);
                    cliente.Email = datareader.GetString(6);
                    listaClientes.Add(cliente);
                }

                listaReadOnlyCliente = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente>(listaClientes);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
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

            return listaReadOnlyCliente;
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public Entidades.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            Entidades.Cliente datosPersonales = new Entidades.Cliente();
            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorDocCliente";
                paramIdCliente = new System.Data.SqlClient.SqlParameter("@docCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = docCliente;
                cmd.Parameters.Add(paramIdCliente);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
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
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public Entidades.Cliente SeleccionarClientePorEmail(string email)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            Entidades.Cliente datosPersonales = new Entidades.Cliente();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ClienteSelectPorEmail";

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = email;
                cmd.Parameters.Add(paramEmail);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
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
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
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
    }
}
