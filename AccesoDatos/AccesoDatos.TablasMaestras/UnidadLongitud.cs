// -----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Administra las unidades de longitud
    /// </summary>
    public class UnidadLongitud : Contratos.IUnidadLongitud
    {
        /// <summary>
        /// Ingresa una unidad de longitud nueva en la base de datos
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadLongitud unidadLongitud)
        {
            if (unidadLongitud == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudInsert";

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 40);
                paramNombre.Value = unidadLongitud.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un registro de la tabla Unidad de Longitud
        /// </summary>
        /// <param name="idlongitud">identificador de la unidad de longitud</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Eliminar(int idlongitud)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdLongitud = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudDelete";

                paramIdLongitud = new System.Data.SqlClient.SqlParameter("@IdUnidadLongitud", System.Data.SqlDbType.Int);
                paramIdLongitud.Value = idlongitud;
                cmd.Parameters.Add(paramIdLongitud);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }
        
        /// <summary>
        /// Actualiza un registro de la tabla Unidad Longitud en la base de datos.
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadLongitud unidadLongitud)
        {
            if (unidadLongitud == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdLongitud = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudUpdate";

                paramIdLongitud = new System.Data.SqlClient.SqlParameter("@IdUnidadLongitud", System.Data.SqlDbType.Int);
                paramIdLongitud.Value = unidadLongitud.IdUnidadLongitud;
                cmd.Parameters.Add(paramIdLongitud);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 40);
                paramNombre.Value = unidadLongitud.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }

        /// <summary>
        /// Lista los datos de la tabla Unidad Longitud de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadLongitud</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud> Listar()
        {
            List<Entidades.UnidadLongitud> listaundLongitud = new List<Entidades.UnidadLongitud>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud> listaReadOnlyunidadlongitud = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.UnidadLongitud unidadLongitud = new Entidades.UnidadLongitud()
                    {
                        IdUnidadLongitud = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    listaundLongitud.Add(unidadLongitud);
                }

                listaReadOnlyunidadlongitud = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud>(listaundLongitud);
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

                cmd.Dispose();

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlyunidadlongitud;
        }

        /// <summary>
        /// Verifica Si la Unidad de Longitud ya existe en la base de datos
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean verificar</param>
        /// <returns>true si la unidad de longitud ya está registrado o false si la unidad de longitud no está registrado</returns>
        [CLSCompliant(false)]
        public bool UnidadLongitudVerificarDuplicidad(Entidades.UnidadLongitud unidadLongitud)
        {
            if (unidadLongitud == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdVolumen = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudVerificarDuplicidad";
                paramIdVolumen = new System.Data.SqlClient.SqlParameter("@IdLongitud", System.Data.SqlDbType.Int);
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);

                paramIdVolumen.Value = unidadLongitud.IdUnidadLongitud;
                cmd.Parameters.Add(paramIdVolumen);

                paramNombre.Value = unidadLongitud.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
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
                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return false;
        }

        /// <summary>
        /// Verifica Si la Unidad de Longitud está relacionada(asociada) a un artículo.
        /// </summary>
        /// <param name="idlongitud">permite acceder al registro y verificar si tiene relación con un artículo</param>
        /// <returns>Verdadero si la Unidad de Longitud tiene por lo menos un artículo asociado, o falso si no tiene artículos relacionados</returns>
        [CLSCompliant(false)]
        public bool UnidadLongitudVerificarRelacionArticulo(int idlongitud)
        {
            this.UnidadLongitudVerificarRelacionArticulo(idlongitud);
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdLongitud = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudVerificarRelacionArticulo";
                paramIdLongitud = new System.Data.SqlClient.SqlParameter("@IdUnidadLongitud", System.Data.SqlDbType.Int);

                paramIdLongitud.Value = idlongitud;
                cmd.Parameters.Add(paramIdLongitud);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
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
                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return false;
        }
    }
}
