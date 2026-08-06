// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
[assembly: System.CLSCompliant(true)]

namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Formulario para la administración de artículos en la base de datos por operaciones CRUD
    /// </summary>
    public class Articulo : Contratos.IArticulos
    {
        /// <summary>
        /// Inserta un Artículo nuevo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.Articulo articulo)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramMarca = null;
            System.Data.SqlClient.SqlParameter paramTitulo = null;
            System.Data.SqlClient.SqlParameter paramCategoria = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramPalabrasRelacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramMetaDescripcion = null;
            System.Data.SqlClient.SqlParameter paramMetaKeyWords = null;
            System.Data.SqlClient.SqlParameter paramUnidadVolumen = null;
            System.Data.SqlClient.SqlParameter paramUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramTallas = null;
            System.Data.SqlClient.SqlParameter paramColores = null;
            System.Data.SqlClient.SqlParameter paramEnLinea = null;
            System.Data.SqlClient.SqlParameter paramPreOrdenar = null;
            System.Data.SqlClient.SqlParameter paramSabor = null;
            System.Data.SqlClient.SqlParameter paramActivo = null;
            System.Data.SqlClient.SqlParameter paramGarantiaMeses = null;
            System.Data.SqlClient.SqlParameter paramVideoYoutube = null;
            System.Data.SqlClient.SqlParameter paramOutIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramUnidadPresentacion = null;

            //// variable utilizada para manejo de la transacción y manejo de excepciones
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloInsert";

                paramMarca = new System.Data.SqlClient.SqlParameter("@IdMarca", System.Data.SqlDbType.NVarChar, 50);
                paramMarca.Value = articulo.Marca.IdMarca;
                cmd.Parameters.Add(paramMarca);

                paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 100);
                paramTitulo.Value = articulo.Titulo;
                cmd.Parameters.Add(paramTitulo);

                paramCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramCategoria.Value = articulo.Categoria.IdCategoria;
                cmd.Parameters.Add(paramCategoria);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar);
                paramDescripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramPalabrasRelacionArticulo = new System.Data.SqlClient.SqlParameter("@PalabrasRelacionArticulo", System.Data.SqlDbType.NVarChar, 250);
                paramPalabrasRelacionArticulo.Value = articulo.PalabrasRelacionArticulo;
                cmd.Parameters.Add(paramPalabrasRelacionArticulo);

                paramMetaDescripcion = new System.Data.SqlClient.SqlParameter("@MetaDescripcion", System.Data.SqlDbType.NVarChar, 250);
                paramMetaDescripcion.Value = articulo.MetaDescripcion;
                cmd.Parameters.Add(paramMetaDescripcion);

                paramMetaKeyWords = new System.Data.SqlClient.SqlParameter("@MetaKeyWords", System.Data.SqlDbType.NVarChar, 250);
                paramMetaKeyWords.Value = articulo.MetaKeyWords;
                cmd.Parameters.Add(paramMetaKeyWords);

                paramUnidadVolumen = new System.Data.SqlClient.SqlParameter("@UnidadVolumen", System.Data.SqlDbType.Bit);
                paramUnidadVolumen.Value = articulo.UnidadVolumen;
                cmd.Parameters.Add(paramUnidadVolumen);

                paramUnidadMasa = new System.Data.SqlClient.SqlParameter("@UnidadMasa", System.Data.SqlDbType.Bit);
                paramUnidadMasa.Value = articulo.UnidadMasa;
                cmd.Parameters.Add(paramUnidadMasa);

                paramUnidadLongitud = new System.Data.SqlClient.SqlParameter("@UnidadLongitud", System.Data.SqlDbType.Bit);
                paramUnidadLongitud.Value = articulo.UnidadLongitud;
                cmd.Parameters.Add(paramUnidadLongitud);

                paramTallas = new System.Data.SqlClient.SqlParameter("@Tallas", System.Data.SqlDbType.Bit);
                paramTallas.Value = articulo.Talla;
                cmd.Parameters.Add(paramTallas);

                paramColores = new System.Data.SqlClient.SqlParameter("@Colores", System.Data.SqlDbType.Bit);
                paramColores.Value = articulo.Color;
                cmd.Parameters.Add(paramColores);

                paramEnLinea = new System.Data.SqlClient.SqlParameter("@EnLinea", System.Data.SqlDbType.Bit);
                paramEnLinea.Value = articulo.ENLinea;
                cmd.Parameters.Add(paramEnLinea);

                paramPreOrdenar = new System.Data.SqlClient.SqlParameter("@PreOrdenar", System.Data.SqlDbType.Bit);
                paramPreOrdenar.Value = articulo.PreOrdenar;
                cmd.Parameters.Add(paramPreOrdenar);

                paramSabor = new System.Data.SqlClient.SqlParameter("@Sabor", System.Data.SqlDbType.Bit);
                paramSabor.Value = articulo.Sabor;
                cmd.Parameters.Add(paramSabor);

                paramActivo = new System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit);
                paramActivo.Value = articulo.Activo;
                cmd.Parameters.Add(paramActivo);

                paramGarantiaMeses = new System.Data.SqlClient.SqlParameter("@GarantiaMeses", System.Data.SqlDbType.NVarChar, 20);
                paramGarantiaMeses.Value = articulo.GarantiaMeses;
                cmd.Parameters.Add(paramGarantiaMeses);

                paramVideoYoutube = new System.Data.SqlClient.SqlParameter("@VideoYoutube", System.Data.SqlDbType.NVarChar, 150);
                paramVideoYoutube.Value = articulo.VideoYoutube;
                cmd.Parameters.Add(paramVideoYoutube);

                paramOutIdArticulo = new System.Data.SqlClient.SqlParameter("@OutIdArticulo", System.Data.SqlDbType.Int);
                paramOutIdArticulo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdArticulo);

                paramUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@UnidadPresentacion", System.Data.SqlDbType.Bit);
                paramUnidadPresentacion.Value = articulo.UnidadPresentacion;
                cmd.Parameters.Add(paramUnidadPresentacion);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();

                // Obtener el parametro de Salida.
                resultadoTransaccion.ValorAuxiliar = paramOutIdArticulo.Value;

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
                }
                else
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0052");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                resultadoTransaccion.Mensaje.Texto = "Servidor: " + ex.Server + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número Error: " + ex.Number + "\n";
                resultadoTransaccion.Mensaje.Texto += "Procedimiento: " + ex.Procedure + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número de Línea" + ex.LineNumber + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Pila de Seguimiento: " + ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.Message + "\n"; 
                
                resultadoTransaccion.RegistrosAfectados = 0;
                Logging.ErrorGeneral.Guardar(ex);                
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje.TipoMensaje = 
                resultadoTransaccion.Mensaje.Texto = ex.Message + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto = "MODULO: AccesoDatos.TablasMaestras.Artículo";
                resultadoTransaccion.RegistrosAfectados = 0;
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
        /// Actualiza los datos de un artículo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Articulo articulo)
        {
            if (articulo == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramArticulo = null;
            System.Data.SqlClient.SqlParameter paramMarca = null;
            System.Data.SqlClient.SqlParameter paramTitulo = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramPalabrasRelacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramGarantiaMeses = null;
            System.Data.SqlClient.SqlParameter paramVideoYoutube = null;
            System.Data.SqlClient.SqlParameter paramMetaDescripcion = null;
            System.Data.SqlClient.SqlParameter paramMetaKeyWords = null;
            System.Data.SqlClient.SqlParameter paramUnidadVolumen = null;
            System.Data.SqlClient.SqlParameter paramUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramTallas = null;
            System.Data.SqlClient.SqlParameter paramColores = null;
            System.Data.SqlClient.SqlParameter paramEnLinea = null;
            System.Data.SqlClient.SqlParameter paramPreOrdenar = null;
            System.Data.SqlClient.SqlParameter paramSabor = null;
            System.Data.SqlClient.SqlParameter paramActivo = null;
            System.Data.SqlClient.SqlParameter paramCategoria = null;
            System.Data.SqlClient.SqlParameter paramUnidadPresentacion = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            resultadoTransaccion.RegistrosAfectados = 0;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloUpdate";

                paramArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.NVarChar, 50);
                paramArticulo.Value = articulo.IdArticulo;
                cmd.Parameters.Add(paramArticulo);

                paramMarca = new System.Data.SqlClient.SqlParameter("@IdMarca", System.Data.SqlDbType.NVarChar, 50);
                paramMarca.Value = articulo.Marca.IdMarca;
                cmd.Parameters.Add(paramMarca);

                paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 100);
                paramTitulo.Value = articulo.Titulo;
                cmd.Parameters.Add(paramTitulo);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar);
                paramDescripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramPalabrasRelacionArticulo = new System.Data.SqlClient.SqlParameter("@PalabrasRelacionArticulo", System.Data.SqlDbType.NVarChar, 250);
                paramPalabrasRelacionArticulo.Value = articulo.PalabrasRelacionArticulo;
                cmd.Parameters.Add(paramPalabrasRelacionArticulo);

                paramGarantiaMeses = new System.Data.SqlClient.SqlParameter("@GarantiaMeses", System.Data.SqlDbType.NVarChar, 20);
                paramGarantiaMeses.Value = articulo.GarantiaMeses;
                cmd.Parameters.Add(paramGarantiaMeses);

                paramVideoYoutube = new System.Data.SqlClient.SqlParameter("@VideoYoutube", System.Data.SqlDbType.NVarChar, 150);
                paramVideoYoutube.Value = articulo.VideoYoutube;
                cmd.Parameters.Add(paramVideoYoutube);

                paramMetaDescripcion = new System.Data.SqlClient.SqlParameter("@MetaDescripcion", System.Data.SqlDbType.NVarChar, 250);
                paramMetaDescripcion.Value = articulo.MetaDescripcion;
                cmd.Parameters.Add(paramMetaDescripcion);

                paramMetaKeyWords = new System.Data.SqlClient.SqlParameter("@MetaKeyWords", System.Data.SqlDbType.NVarChar, 250);
                paramMetaKeyWords.Value = articulo.MetaKeyWords;
                cmd.Parameters.Add(paramMetaKeyWords);

                paramUnidadLongitud = new System.Data.SqlClient.SqlParameter("@UnidadLongitud", System.Data.SqlDbType.Bit);
                paramUnidadLongitud.Value = articulo.UnidadLongitud;
                cmd.Parameters.Add(paramUnidadLongitud);

                paramUnidadMasa = new System.Data.SqlClient.SqlParameter("@UnidadMasa", System.Data.SqlDbType.Bit);
                paramUnidadMasa.Value = articulo.UnidadMasa;
                cmd.Parameters.Add(paramUnidadMasa);

                paramUnidadVolumen = new System.Data.SqlClient.SqlParameter("@UnidadVolumen", System.Data.SqlDbType.Bit);
                paramUnidadVolumen.Value = articulo.UnidadVolumen;
                cmd.Parameters.Add(paramUnidadVolumen);

                paramTallas = new System.Data.SqlClient.SqlParameter("@Tallas", System.Data.SqlDbType.Bit);
                paramTallas.Value = articulo.Talla;
                cmd.Parameters.Add(paramTallas);

                paramColores = new System.Data.SqlClient.SqlParameter("@Colores", System.Data.SqlDbType.Bit);
                paramColores.Value = articulo.Color;
                cmd.Parameters.Add(paramColores);

                paramEnLinea = new System.Data.SqlClient.SqlParameter("@EnLinea", System.Data.SqlDbType.Bit);
                paramEnLinea.Value = articulo.ENLinea;
                cmd.Parameters.Add(paramEnLinea);

                paramPreOrdenar = new System.Data.SqlClient.SqlParameter("@PreOrdenar", System.Data.SqlDbType.Bit);
                paramPreOrdenar.Value = articulo.PreOrdenar;
                cmd.Parameters.Add(paramPreOrdenar);

                paramSabor = new System.Data.SqlClient.SqlParameter("@Sabor", System.Data.SqlDbType.Bit);
                paramSabor.Value = articulo.Sabor;
                cmd.Parameters.Add(paramSabor);

                paramActivo = new System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit);
                paramActivo.Value = articulo.Activo;
                cmd.Parameters.Add(paramActivo);

                paramCategoria = new System.Data.SqlClient.SqlParameter("@IdSubCategoria", System.Data.SqlDbType.Int);
                paramCategoria.Value = articulo.Categoria.IdCategoria;
                cmd.Parameters.Add(paramCategoria);

                paramUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@UnidadPresentacion", System.Data.SqlDbType.Bit);
                paramUnidadPresentacion.Value = articulo.UnidadPresentacion;
                cmd.Parameters.Add(paramUnidadPresentacion);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0017");                
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
        /// Elimina el registro de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="idarticulo">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Eliminar(int idarticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
          
            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloDelete";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idarticulo;
                cmd.Parameters.Add(paramIdArticulo);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif

                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);

            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
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
        /// Obtiene la lista de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        [CLSCompliant(false)]
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Listar()
        {
            List<Entidades.Articulo> articulo = new List<Entidades.Articulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> listaReadOnlyarticulos = null;
            // System.Data.SqlClient.SqlParameter paramOutEstadoInventario = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Articulo articulos = new Entidades.Articulo();

                    articulos.IdArticulo = datareader.GetInt32(0);
                    articulos.Marca.IdMarca = datareader.GetInt32(1);
                    articulos.Titulo = datareader.GetString(2);
                    articulos.Categoria = new Entidades.Categoria();
                    articulos.Categoria.IdCategoria = datareader.GetInt32(3);
                    articulos.Categoria.IdCategoriaPadre = datareader.GetInt32(4);
                    articulos.Categoria.Nombre = datareader.GetString(5);
                    articulos.Categoria.Descripcion = datareader.GetString(6);
                    articulos.Categoria.PalabrasClave = datareader.GetString(7);
                    articulos.Descripcion = datareader.GetString(8);
                    articulos.PalabrasRelacionArticulo = datareader.GetString(9);
                    articulos.MetaDescripcion = datareader.GetString(10);
                    articulos.MetaKeyWords = datareader.GetString(11);
                    articulos.UnidadVolumen = datareader.GetBoolean(12);
                    articulos.UnidadMasa = datareader.GetBoolean(13);
                    articulos.UnidadLongitud = datareader.GetBoolean(14);
                    articulos.Talla = datareader.GetBoolean(15);
                    articulos.Color = datareader.GetBoolean(16);
                    articulos.ENLinea = datareader.GetBoolean(17);
                    articulos.PreOrdenar = datareader.GetBoolean(18);
                    articulos.Sabor = datareader.GetBoolean(19);
                    articulos.Activo = datareader.GetBoolean(20);
                    articulos.GarantiaMeses = datareader.GetInt32(21);
                    articulos.VideoYoutube = datareader.GetString(22);
                    articulos.UnidadPresentacion = datareader.GetBoolean(23);
                    articulo.Add(articulos);
                }

                listaReadOnlyarticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo>(articulo);
                // Logging.Accion.Guardar("Lectura de la tabla articulos");
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

            return listaReadOnlyarticulos;
        }

        /// <summary>
        /// Obtiene la lista por estado de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> ListarPorEstado(Entidades.Enumeraciones.EstadoInventario estado)
        {
            List<Entidades.Articulo> articulo = new List<Entidades.Articulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> listaReadOnlyarticulos = null;
            System.Data.SqlClient.SqlParameter paramEstadoInventario = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloPorEstadoSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);

                paramEstadoInventario = new System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.Bit);

                if (estado == Entidades.Enumeraciones.EstadoInventario.Activo)
                {
                    paramEstadoInventario.Value = 1;
                }
                else
                {
                    paramEstadoInventario.Value = 0;
                }

                cmd.Parameters.Add(paramEstadoInventario);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Articulo articulos = new Entidades.Articulo();

                    articulos.IdArticulo = datareader.GetInt32(0);
                    articulos.Marca.IdMarca = datareader.GetInt32(1);
                    articulos.Titulo = datareader.GetString(2);
                    articulos.Categoria = new Entidades.Categoria();
                    articulos.Categoria.IdCategoria = datareader.GetInt32(3);
                    articulos.Categoria.IdCategoriaPadre = datareader.GetInt32(4);
                    articulos.Categoria.Nombre = datareader.GetString(5);
                    articulos.Categoria.Descripcion = datareader.GetString(6);
                    articulos.Categoria.PalabrasClave = datareader.GetString(7);
                    articulos.Descripcion = datareader.GetString(8);
                    articulos.PalabrasRelacionArticulo = datareader.GetString(9);
                    articulos.MetaDescripcion = datareader.GetString(10);
                    articulos.MetaKeyWords = datareader.GetString(11);
                    articulos.UnidadVolumen = datareader.GetBoolean(12);
                    articulos.UnidadMasa = datareader.GetBoolean(13);
                    articulos.UnidadLongitud = datareader.GetBoolean(14);
                    articulos.Talla = datareader.GetBoolean(15);
                    articulos.Color = datareader.GetBoolean(16);
                    articulos.ENLinea = datareader.GetBoolean(17);
                    articulos.PreOrdenar = datareader.GetBoolean(18);
                    articulos.Sabor = datareader.GetBoolean(19);
                    articulos.Activo = datareader.GetBoolean(20);
                    articulos.GarantiaMeses = datareader.GetInt32(21);
                    articulos.VideoYoutube = datareader.GetString(22);
                    articulos.UnidadPresentacion = datareader.GetBoolean(23);
                    articulo.Add(articulos);
                }

                listaReadOnlyarticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo>(articulo);
                // Logging.Accion.Guardar("Lectura de la tabla articulos");
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

            return listaReadOnlyarticulos;
        }
    }
}
