// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Formulario para la administración de categorías en la base de datos por operaciones CRUD
    /// </summary>
    public class Categoria : Contratos.ICategorias
    {
        /// <summary>
        /// Inserta una categoría nueva en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.Categoria categoria)
        {
            if (categoria == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCategoriaPadre = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramPalabrasClaves = null;
            System.Data.SqlClient.SqlParameter paramOutIdCategoria = null;

            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaInsert";

                paramIdCategoriaPadre = new System.Data.SqlClient.SqlParameter("@IdCategoriaPadre", System.Data.SqlDbType.Int);
                paramIdCategoriaPadre.Value = categoria.IdCategoriaPadre;
                cmd.Parameters.Add(paramIdCategoriaPadre);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 60);
                paramNombre.Value = categoria.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcion.Value = categoria.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramPalabrasClaves = new System.Data.SqlClient.SqlParameter("@PalabrasClaves", System.Data.SqlDbType.NVarChar, 250);
                paramPalabrasClaves.Value = categoria.PalabrasClave;
                cmd.Parameters.Add(paramPalabrasClaves);

                paramOutIdCategoria = new System.Data.SqlClient.SqlParameter("@OutIdCategoria", System.Data.SqlDbType.Int);
                paramOutIdCategoria.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdCategoria);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.ValorAuxiliar = paramOutIdCategoria.Value;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
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
        /// Actualiza los datos de una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Categoria categoria)
        {
            if (categoria == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            System.Data.SqlClient.SqlParameter paramIdCategoriaPadre = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramPalabrasClaves = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaUpdate";

                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdCategoria.Value = categoria.IdCategoria;
                cmd.Parameters.Add(paramIdCategoria);

                paramIdCategoriaPadre = new System.Data.SqlClient.SqlParameter("@IdCategoriaPadre", System.Data.SqlDbType.Int);
                paramIdCategoriaPadre.Value = categoria.IdCategoriaPadre;
                cmd.Parameters.Add(paramIdCategoriaPadre);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 60);
                paramNombre.Value = categoria.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcion.Value = categoria.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramPalabrasClaves = new System.Data.SqlClient.SqlParameter("@PalabrasClaves", System.Data.SqlDbType.NVarChar, 250);
                paramPalabrasClaves.Value = categoria.PalabrasClave;
                cmd.Parameters.Add(paramPalabrasClaves);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
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

            return resultadoTransaccion;
        }

        /// <summary>
        /// Elimina el registro de una categoría existente en la base de datos.
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaDelete";

                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdCategoria.Value = idCategoria;
                cmd.Parameters.Add(paramIdCategoria);

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
        /// Obtiene la lista de Categorías almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> Listar()
        {
            List<Entidades.Categoria> categorias = new List<Entidades.Categoria>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaReadOnlycategorias = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    Entidades.Categoria categoria = new Entidades.Categoria()
                    {
                        IdCategoria = datareader.GetInt32(0),
                        IdCategoriaPadre = datareader.GetInt32(1),
                        Nombre = datareader.GetString(2),
                        Descripcion = datareader.GetString(3),
                        PalabrasClave = datareader.GetString(4)
                    };
                    categorias.Add(categoria);
                }

                listaReadOnlycategorias = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria>(categorias);
                // Logging.Accion.Guardar("Lectura de la tabla de Categoria.");
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlycategorias;
        }

        /// <summary>
        /// Obtiene la lista de Categoría almacenada en la base de datos según el id de la categoría
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> ListarPorIdCategoria(int idCategoria)
        {
            List<Entidades.Categoria> categoriaSeleccionada = new List<Entidades.Categoria>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaReadOnlycategorias = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaSelectPorIdCategoria";

                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdCategoria.Value = idCategoria;
                cmd.Parameters.Add(paramIdCategoria);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    Entidades.Categoria categoria = new Entidades.Categoria()
                    {
                        IdCategoria = datareader.GetInt32(0),
                        IdCategoriaPadre = datareader.GetInt32(1),
                        Nombre = datareader.GetString(2),
                        Descripcion = datareader.GetString(3),
                        PalabrasClave = datareader.GetString(4)
                    };
                    categoriaSeleccionada.Add(categoria);
                }

                listaReadOnlycategorias = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria>(categoriaSeleccionada);
                // Logging.Accion.Guardar("Lectura de la tabla de Categoria.");
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlycategorias;
        }

        /// <summary>
        /// Verifica si la categoría tiene por lo menos un artículo relacionado
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>true si la categoría tiene por lo menos un artículo relacionado, o false si no tiene artículos relacionados</returns>
        [CLSCompliant(false)]
        public bool CategoriaVerificarRelacionArticulo(int idCategoria)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaVerificarRelacionArticulo";
                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idCategoria;
                cmd.Parameters.Add(paramIdArticulo);
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return false;
        }

        /// <summary>
        /// verifica si la categoría a eliminar no contiene subcategoría
        /// </summary>
        /// <param name="idCategoria">identificador de la tabla categoría</param>
        /// <returns>Verdadero si la categoría tiene por lo menos una subcategoría, o Falso si no tiene ninguna subcategoría relacionada</returns>
        [CLSCompliant(false)] 
        public bool CategoriaVerificarSubCategoria(int idCategoria)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaVerificarSubCategoria";
                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdCategoria.Value = idCategoria;
                cmd.Parameters.Add(paramIdCategoria);

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

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return false;
        }

        /// <summary>
        /// verifica si el nombre de la categoría ya existe con (otro Id) para no realizar la inserción ó actualización de los datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos para verificar duplicidad</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        [CLSCompliant(false)]        
        public bool CategoriaVerificarDuplicidad(Entidades.Categoria categoria)
        {
            if (categoria == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaVerificarDuplicidad";
                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 60);
                paramIdCategoria.Value = categoria.IdCategoria;
                cmd.Parameters.Add(paramIdCategoria);

                paramNombre.Value = categoria.Nombre;
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
    }
}
