// -----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------
namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Formulario para la administración de unidades de volúmen en la base de datos por operaciones CRUD
    /// </summary>
    public class UnidadVolumen : Contratos.IUnidadVolumen
    {
        /// <summary>
        /// Ingresa una unidad de volúmen nueva en la base de datos
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadVolumen unidadVolumen)
        {
            if (unidadVolumen == null)
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
                cmd.CommandText = "UnidadVolumenInsert";

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = unidadVolumen.Nombre;
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
        /// Elimina una unidad de volúmen de la base de datos.
        /// </summary>
        /// <param name="idvolumen">identificador de la tabla unidad de volúmen</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [CLSCompliant(false)]        
        public Entidades.ResultadoTransaccion Eliminar(int idvolumen)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdVolumen = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenDelete";

                paramIdVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);
                paramIdVolumen.Value = idvolumen;
                cmd.Parameters.Add(paramIdVolumen);

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
        /// Actualiza una unidad de volúmen en la base de datos.
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]        
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadVolumen unidadVolumen)
        {
            if (unidadVolumen == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdVolumen = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenUpdate";

                paramIdVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);
                paramIdVolumen.Value = unidadVolumen.IdUnidadVolumen;
                cmd.Parameters.Add(paramIdVolumen);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = unidadVolumen.Nombre;
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
        /// Obtiene la lista de unidades de volúmen almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadMasa</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadVolumen> Listar()
        {
            List<Entidades.UnidadVolumen> undVolumen = new List<Entidades.UnidadVolumen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadVolumen> listaReadOnlyunidadvolumen = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.UnidadVolumen unidadVolumen = new Entidades.UnidadVolumen()
                    {
                        IdUnidadVolumen = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    undVolumen.Add(unidadVolumen);
                }

                listaReadOnlyunidadvolumen = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadVolumen>(undVolumen);
                // Logging.Accion.Guardar("Lectura de la tabla Unidad de Volumen");
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

            return listaReadOnlyunidadvolumen;
        }

        /// <summary>
        /// Verifica que la unidad de volúmen no está ingresada en la base de datos
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean verificar</param>
        /// <returns>true si unidad de volúmen ya está registrado o false si la unidad de volúmen no está registrado</returns>
        [CLSCompliant(false)]
        public bool UnidadVolumenVerificarDuplicidad(Entidades.UnidadVolumen unidadVolumen)
        {
            if (unidadVolumen == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdVolumen = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenVerificarDuplicidad";
                paramIdVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);

                paramIdVolumen.Value = unidadVolumen.IdUnidadVolumen;
                cmd.Parameters.Add(paramIdVolumen);

                paramNombre.Value = unidadVolumen.Nombre;
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
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return false;
        }

        /// <summary>
        /// Verifica que la unidad de volúmen no se encuentre relacionada(asociada) con un artículo
        /// </summary>
        /// <param name="idvolumen">Identificador de Unidad de volúmen</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        public bool UnidadVolumenVerificarRelacionArticulo(int idvolumen)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdVolumen = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenVerificarRelacionArticulo";
                paramIdVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);

                paramIdVolumen.Value = idvolumen;
                cmd.Parameters.Add(paramIdVolumen);

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
