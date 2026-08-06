//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    /// <summary>
    /// Administra las direcciones del usuario
    /// </summary>
    public class Direccion : ContratosWeb.IDireccion    
    {
        /// <summary>
        /// Inserta una dirección nuevo en la base de datos.
        /// </summary>
        /// <param name="direccion">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Direccion direccion)
        {
            if (direccion == null)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = null;
            System.Data.SqlClient.SqlParameter paramDireccionEnvio = null;
            System.Data.SqlClient.SqlParameter paramTelefono = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Data.SqlClient.SqlParameter paramIdDpto = null;
            System.Data.SqlClient.SqlParameter paramIdCiudad = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;

            System.Data.SqlClient.SqlConnection conexion = null;
            System.Data.SqlClient.SqlTransaction transaccion = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionInsert";

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = direccion.NombreDestinatario;
                cmd.Parameters.Add(paramNombreDestinatario);

                paramDireccionEnvio = new System.Data.SqlClient.SqlParameter("@DireccionEnvio", System.Data.SqlDbType.NVarChar, 40);
                paramDireccionEnvio.Value = direccion.DireccionEnvio;
                cmd.Parameters.Add(paramDireccionEnvio);

                paramTelefono = new System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono.Value = direccion.Telefono;
                cmd.Parameters.Add(paramTelefono);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = direccion.Pais.IdPais;
                cmd.Parameters.Add(paramIdPais);

                paramIdDpto = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDpto.Value = direccion.Departamento.IdDepartamento;
                cmd.Parameters.Add(paramIdDpto);

                paramIdCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramIdCiudad.Value = direccion.Ciudad.IdCiudad;
                cmd.Parameters.Add(paramIdCiudad);

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = direccion.IdCliente;
                cmd.Parameters.Add(paramIdCliente);

                conexion = AccesoDatos.WebPublica.Conexion.NuevaConexion();

                cmd.Connection = conexion;

                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmd.Transaction = transaccion;

                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    resultado.RegistrosAfectados = 1;
                    transaccion.Commit();
                }
                else
                {
                    resultado.RegistrosAfectados = 0;
                    transaccion.Rollback();
                }

                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");
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
        /// Obtiene todas las direcciones asociadas al usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>listado de direcciones asociadas al usuario encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> ListarPorIdUsuario(int idUsuario)
        {
            List<EntidadesWeb.DireccionParaGrid> listDirecciones = new List<EntidadesWeb.DireccionParaGrid>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> listaReadOnlyDireccion = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionSelectIdUsuario";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = idUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.DireccionParaGrid direccion = new EntidadesWeb.DireccionParaGrid();

                    direccion.IdDireccion = datareader.GetInt32(0);
                    direccion.NombreDestinatario = datareader.GetString(1);
                    direccion.DireccionEnvio = datareader.GetString(2);
                    direccion.Telefono = datareader.GetString(3);
                    direccion.IdPais = datareader.GetInt32(4);
                    direccion.IdDepartamento = datareader.GetInt32(5);
                    direccion.IdCiudad = datareader.GetInt32(6);
                    direccion.IdCliente = datareader.GetInt32(7);
                    direccion.NombrePais = datareader.GetString(8);
                    direccion.NombreDepartamento = datareader.GetString(9);
                    direccion.NombreCiudad = datareader.GetString(10);
                    listDirecciones.Add(direccion);
                }

                listaReadOnlyDireccion = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid>(listDirecciones);
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

            return listaReadOnlyDireccion;
        }

        /// <summary>
        /// Actualiza la dirección del usuario
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.DireccionParaGrid direccion)
        {
            if (direccion == null)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = null;
            System.Data.SqlClient.SqlParameter paramDireccionEnvio = null;
            System.Data.SqlClient.SqlParameter paramTelefono = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Data.SqlClient.SqlParameter paramIdDepartamento = null;
            System.Data.SqlClient.SqlParameter paramIdCiudad = null;
            System.Data.SqlClient.SqlParameter paramIdDireccion = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionUpdate";

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = direccion.NombreDestinatario;
                cmd.Parameters.Add(paramNombreDestinatario);

                paramDireccionEnvio = new System.Data.SqlClient.SqlParameter("@DireccionEnvio", System.Data.SqlDbType.NVarChar, 40);
                paramDireccionEnvio.Value = direccion.DireccionEnvio;
                cmd.Parameters.Add(paramDireccionEnvio);

                paramTelefono = new System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.NVarChar, 20);
                paramTelefono.Value = direccion.Telefono;
                cmd.Parameters.Add(paramTelefono);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.NVarChar, 20);
                paramIdPais.Value = direccion.IdPais;
                cmd.Parameters.Add(paramIdPais);

                paramIdDepartamento = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDepartamento.Value = direccion.IdDepartamento;
                cmd.Parameters.Add(paramIdDepartamento);

                paramIdCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramIdCiudad.Value = direccion.IdCiudad;
                cmd.Parameters.Add(paramIdCiudad);

                paramIdDireccion = new System.Data.SqlClient.SqlParameter("@IdDireccion", System.Data.SqlDbType.Int);
                paramIdDireccion.Value = direccion.IdDireccion;
                cmd.Parameters.Add(paramIdDireccion);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
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
        /// Elimina la dirección de un usuario
        /// </summary>
        /// <param name="idDireccion">Identificación de la dirección en la base de datos</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idDireccion)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdDireccion = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionDelete";

                paramIdDireccion = new System.Data.SqlClient.SqlParameter("@IdDireccion", System.Data.SqlDbType.Int);
                paramIdDireccion.Value = idDireccion;
                cmd.Parameters.Add(paramIdDireccion);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0006");
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
        /// Consulta los datos de una dirección en concreto
        /// </summary>
        /// <param name="idDireccion">Identificación única de la dirección en la base de datos</param>
        /// <returns>Objeto con los datos de dirección solicitados</returns>
        public EntidadesWeb.Direccion ConsultarDireccionPorId(int idDireccion)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdDireccion = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.Direccion direccion = new EntidadesWeb.Direccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionConsultarPorIdDireccion";
                paramIdDireccion = new System.Data.SqlClient.SqlParameter("@IdDireccion", System.Data.SqlDbType.Int);
                paramIdDireccion.Value = idDireccion;
                cmd.Parameters.Add(paramIdDireccion);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    direccion.IdDireccion = datareader.GetInt32(0);
                    direccion.IdCliente = datareader.GetInt32(1);
                    direccion.NombreDestinatario = datareader.GetString(2);
                    direccion.DireccionEnvio = datareader.GetString(3);
                    direccion.Telefono = datareader.GetString(4);
                    direccion.Pais.IdPais = datareader.GetInt32(5);
                    direccion.Departamento.IdDepartamento = datareader.GetInt32(6);
                    direccion.Ciudad.IdCiudad = datareader.GetInt32(7);
                    direccion.Pais.Nombre = datareader.GetString(8);
                    direccion.Departamento.Nombre = datareader.GetString(9);
                    direccion.Ciudad.Nombre = datareader.GetString(10);
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

            return direccion;
        }
    }
}
