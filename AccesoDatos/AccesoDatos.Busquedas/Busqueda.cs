//-----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.Busquedas
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    /// <summary>
    /// Busqueda en base de datos utilizando full text search
    /// </summary>
    public class Busqueda : Contratos.IBusqueda
    {
        /// <summary>
        /// Aprueba busquedas hechas por usuarios guardadas en base de datos.
        /// </summary>
        /// <returns></returns>
        public Entidades.ResultadoTransaccion Aprobar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="idArticulos"></param>
        /// <returns></returns>
        public ReadOnlyCollection<Entidades.Articulo> Buscar(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos)
        {
            List<Entidades.Articulo> ListaArticulos = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter parametroSQL = null;
            System.Data.SqlClient.SqlDataReader dataReader = null;

            try
            {
                ListaArticulos = new List<Entidades.Articulo>();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectPorIdArticulo";
                parametroSQL = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                cmd.Parameters.Add(parametroSQL);
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                for (int i = 0; i < idArticulos.Count; i++)
                {
                    parametroSQL.Value = idArticulos[i];

                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }

                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        Entidades.Articulo articulo = this.CargarArticulo(dataReader);
                        ListaArticulos.Add(articulo);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Logging.ErrorGeneral.Guardar(sqlEx);
            }
            catch (Exception ex)
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

                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

            return new ReadOnlyCollection<Entidades.Articulo>(ListaArticulos);
        }

        private Entidades.Articulo CargarArticulo(System.Data.SqlClient.SqlDataReader dataReader)
        {
            Entidades.Articulo articulo = new Entidades.Articulo();
            articulo.IdArticulo = dataReader.GetInt32(0); // [Articulo].[IdArticulo]
            articulo.Marca.IdMarca = dataReader.GetInt32(1); // ,[Articulo].[IdMarca]
            articulo.Titulo = dataReader.GetString(2); // ,[Articulo].[Titulo]
            articulo.Categoria.IdCategoria = dataReader.GetInt32(3); // ,[Articulo].[IdCategoria]
            articulo.Categoria.IdCategoriaPadre = dataReader.GetInt32(4); // ,[Categoria].[IdCategoriaPadre]
            articulo.Categoria.Nombre = dataReader.GetString(5); // ,[Categoria].[Nombre]
            articulo.Categoria.Descripcion = dataReader.GetString(6); // ,[Categoria].[Descripcion]
            articulo.Categoria.PalabrasClave = dataReader.GetString(7); // ,[Categoria].[PalabrasClaves]
            articulo.Descripcion = dataReader.GetString(8); // ,[Articulo].[Descripcion]
            articulo.PalabrasRelacionArticulo = dataReader.GetString(9); // ,[Articulo].[PalabrasRelacionArticulo]
            articulo.MetaDescripcion = dataReader.GetString(10); // ,[Articulo].[MetaDescripcion]
            articulo.MetaKeyWords = dataReader.GetString(11); // ,[Articulo].[MetaKeyWords]
            articulo.UnidadVolumen = dataReader.GetBoolean(12); // ,[Articulo].[UnidadVolumen]
            articulo.UnidadMasa = dataReader.GetBoolean(13); // ,[Articulo].[UnidadMasa]
            articulo.UnidadLongitud = dataReader.GetBoolean(14); // ,[Articulo].[UnidadLongitud]
            articulo.Talla = dataReader.GetBoolean(15); // ,[Articulo].[Tallas]
            articulo.Color = dataReader.GetBoolean(16); // ,[Articulo].[Colores]
            articulo.ENLinea = dataReader.GetBoolean(17); // ,[Articulo].[EnLinea]
            articulo.PreOrdenar = dataReader.GetBoolean(18); // ,[Articulo].[PreOrdenar]
            articulo.Sabor = dataReader.GetBoolean(19); // ,[Articulo].[Sabor]
            articulo.Activo = dataReader.GetBoolean(20); // ,[Articulo].[Activo]
            articulo.GarantiaMeses = dataReader.GetInt32(21); // ,[Articulo].[GarantiaMeses]
            articulo.VideoYoutube = dataReader.GetString(22); // ,[Articulo].[VideoYoutube]
            articulo.UnidadPresentacion = dataReader.GetBoolean(23); // ,[Articulo].[UnidadPresentacion]
            return articulo;
        }

        private List<Entidades.Articulo> ConsultarArticuloPorIdArticulo()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Articulo> BuscarPorEstado(string texto, ReadOnlyCollection<double> idArticulos, Estado estado)
        {
            List<Entidades.Articulo> ListaArticulos = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader dataReader = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramEstado = null;

            try
            {
                ListaArticulos = new List<Articulo>();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectPorIdArticuloEstado";
                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                cmd.Parameters.Add(paramIdArticulo);
                paramEstado = new System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.Bit);
                cmd.Parameters.Add(paramEstado);
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                for (int i = 0; i < idArticulos.Count; i++)
                {
                    paramIdArticulo.Value = idArticulos[i];

                    if (estado == Estado.Habilitado)
                    {
                        paramEstado.Value = 1;
                    }
                    else
                    {
                        paramEstado.Value = 0;
                    }

                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        Entidades.Articulo articulo = this.CargarArticulo(dataReader);
                        ListaArticulos.Add(articulo);
                    }

                    dataReader.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Logging.ErrorGeneral.Guardar(sqlEx);
            }
            catch (Exception ex)
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

                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

            return new ReadOnlyCollection<Entidades.Articulo>(ListaArticulos);
        }

        public Entidades.ResultadoTransaccion Eliminar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Busqueda> Listar(bool Eliminado, bool Aprobado)
        {
            throw new NotImplementedException();
        }
    }
}
