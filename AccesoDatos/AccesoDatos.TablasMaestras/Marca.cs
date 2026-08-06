// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;

    /// <summary>
    /// Formulario para la administración de marcas en la base de datos por operaciones CRUD
    /// </summary>
    public class Marca : Contratos.IMarca
    {
        /// <summary>
        /// Inserta una marca nueva en la base de datos
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.Marca marca)
        {
            if (marca == null)
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
                cmd.CommandText = "MarcaInsert";
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = marca.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
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
        /// Actualiza los datos de un marca en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Marca marca)
        {
            if (marca == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdMarca = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaUpdate";

                paramIdMarca = new System.Data.SqlClient.SqlParameter("@IdMarca", System.Data.SqlDbType.Int);
                paramIdMarca.Value = marca.IdMarca;
                cmd.Parameters.Add(paramIdMarca);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = marca.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
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
        /// Elimina el registro de un marca existente en la base de datos.
        /// </summary>
        /// <param name="idmarca">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Eliminar(int idmarca)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdMarca = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaDelete";

                paramIdMarca = new System.Data.SqlClient.SqlParameter("@IdMarca", System.Data.SqlDbType.Int);
                paramIdMarca.Value = idmarca;
                cmd.Parameters.Add(paramIdMarca);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                return resultado;
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
        /// Obtiene la lista de marca de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar()
        {
            List<Entidades.Marca> marcas = new List<Entidades.Marca>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> listaReadOnlymarca = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Marca marca = new Entidades.Marca()
                    {
                        IdMarca = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    marcas.Add(marca);
                }

                listaReadOnlymarca = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca>(marcas);
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

            return listaReadOnlymarca;
        }

        public ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca()
        {
            List<Entidades.Marca> marcas = new List<Entidades.Marca>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> listaReadOnlyMarcaOrdenadoPorIdMarca = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaSelectOrdenadoPorId";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Marca marca = new Entidades.Marca()
                    {
                        IdMarca = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    marcas.Add(marca);
                }

                listaReadOnlyMarcaOrdenadoPorIdMarca = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca>(marcas);
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

            return listaReadOnlyMarcaOrdenadoPorIdMarca;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.Marca Marca = null;
            System.Collections.Generic.List<Entidades.Marca> ListaMarcas = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaSelectPorNombre";

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = marca;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                ListaMarcas = new List<Entidades.Marca>();

                while (datareader.Read())
                {
                    Marca = new Entidades.Marca();
                    Marca.IdMarca = datareader.GetInt32(0);
                    Marca.Nombre = datareader.GetString(1);
                    ListaMarcas.Add(Marca);
                }
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

            return new ReadOnlyCollection<Entidades.Marca>(ListaMarcas);
        }

        public ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdMarca = null;
            Entidades.Marca Marca = null;
            System.Collections.Generic.List<Entidades.Marca> ListaMarcas = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaSelectPorId";

                paramIdMarca = new System.Data.SqlClient.SqlParameter("@idMarca", System.Data.SqlDbType.Int);
                paramIdMarca.Value = idMarca;
                cmd.Parameters.Add(paramIdMarca);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                ListaMarcas = new List<Entidades.Marca>();

                if (datareader.Read())
                {
                    Marca = new Entidades.Marca();
                    Marca.IdMarca = datareader.GetInt32(0);
                    Marca.Nombre = datareader.GetString(1);
                    ListaMarcas.Add(Marca);
                }
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

            return new ReadOnlyCollection<Entidades.Marca>(ListaMarcas);
        }

        public bool VerificarRelacionArticulo(int idMarca)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdMarca = null;
            bool Resultado = false;
            string ResultadoString = string.Empty;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaVerificarRelacionArticulo";

                paramIdMarca = new System.Data.SqlClient.SqlParameter("@idMarca", System.Data.SqlDbType.Int);
                paramIdMarca.Value = idMarca;
                cmd.Parameters.Add(paramIdMarca);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                ResultadoString = cmd.ExecuteScalar().ToString();
                Resultado = bool.Parse(ResultadoString);
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

            return Resultado;
        }
    }
}
