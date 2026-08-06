//-----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using EntidadesWeb;

    public class Articulo : ContratosWeb.IArticulo
    {
        public EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo)
        {
            EntidadesWeb.Articulo Articulo = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectPorIdArticulo";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("IdArticulo", SqlDbType.Int);
                paramIdArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    Articulo.IdArticulo = datareader.GetInt32(0);
                    Articulo.Marca.IdMarca = datareader.GetInt32(1);
                    Articulo.Titulo = datareader.GetString(2);
                    Articulo.Categoria = new EntidadesWeb.Categoria();
                    Articulo.Categoria.IdCategoria = datareader.GetInt32(3);
                    Articulo.Categoria.IdCategoriaPadre = datareader.GetInt32(4);
                    Articulo.Categoria.Nombre = datareader.GetString(5);
                    Articulo.Categoria.Descripcion = datareader.GetString(6);
                    Articulo.Categoria.PalabraClave = datareader.GetString(7);
                    Articulo.Descripcion = datareader.GetString(8);
                    Articulo.PalabrasRelacionArticulo = datareader.GetString(9);
                    Articulo.MetaDescripcion = datareader.GetString(10);
                    Articulo.MetaKeyWords = datareader.GetString(11);
                    Articulo.UnidadVolumen = datareader.GetBoolean(12);
                    Articulo.UnidadMasa = datareader.GetBoolean(13);
                    Articulo.UnidadLongitud = datareader.GetBoolean(14);
                    Articulo.Talla = datareader.GetBoolean(15);
                    Articulo.Color = datareader.GetBoolean(16);
                    Articulo.ENLinea = datareader.GetBoolean(17);
                    Articulo.PreOrdenar = datareader.GetBoolean(18);
                    Articulo.Sabor = datareader.GetBoolean(19);
                    Articulo.Activo = datareader.GetBoolean(20);
                    Articulo.GarantiaMeses = datareader.GetInt32(21);
                    Articulo.VideoYoutube = datareader.GetString(22);
                    Articulo.UnidadPresentacion = datareader.GetBoolean(23);
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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

            return Articulo;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar()
        {
            List<EntidadesWeb.Articulo> listaArticulo = new List<EntidadesWeb.Articulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> listaReadOnlyarticulos = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectWeb";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Articulo articulo = new EntidadesWeb.Articulo();

                    articulo.IdArticulo = datareader.GetInt32(0);
                    articulo.Marca.IdMarca = datareader.GetInt32(1);
                    articulo.Titulo = datareader.GetString(2);
                    articulo.Categoria = new EntidadesWeb.Categoria();
                    articulo.Categoria.IdCategoria = datareader.GetInt32(3);
                    articulo.Categoria.IdCategoriaPadre = datareader.GetInt32(4);
                    articulo.Categoria.Nombre = datareader.GetString(5);
                    articulo.Categoria.Descripcion = datareader.GetString(6);
                    articulo.Categoria.PalabraClave = datareader.GetString(7);
                    articulo.Descripcion = datareader.GetString(8);
                    articulo.PalabrasRelacionArticulo = datareader.GetString(9);
                    articulo.MetaDescripcion = datareader.GetString(10);
                    articulo.MetaKeyWords = datareader.GetString(11);
                    articulo.UnidadVolumen = datareader.GetBoolean(12);
                    articulo.UnidadMasa = datareader.GetBoolean(13);
                    articulo.UnidadLongitud = datareader.GetBoolean(14);
                    articulo.Talla = datareader.GetBoolean(15);
                    articulo.Color = datareader.GetBoolean(16);
                    articulo.ENLinea = datareader.GetBoolean(17);
                    articulo.PreOrdenar = datareader.GetBoolean(18);
                    articulo.Sabor = datareader.GetBoolean(19);
                    articulo.Activo = datareader.GetBoolean(20);
                    articulo.GarantiaMeses = datareader.GetInt32(21);
                    articulo.VideoYoutube = datareader.GetString(22);
                    articulo.UnidadPresentacion = datareader.GetBoolean(23);
                    listaArticulo.Add(articulo);
                }

                listaReadOnlyarticulos = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo>(listaArticulo);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyarticulos;
        }

        public ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion()
        {
            List<EntidadesWeb.Articulo> listaArticulo = new List<EntidadesWeb.Articulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> listaReadOnlyarticulos = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectWebPendientesActualizacion";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Articulo articulo = new EntidadesWeb.Articulo();

                    articulo.IdArticulo = datareader.GetInt32(0);
                    articulo.Marca.IdMarca = datareader.GetInt32(1);
                    articulo.Titulo = datareader.GetString(2);
                    articulo.Categoria = new EntidadesWeb.Categoria();
                    articulo.Categoria.IdCategoria = datareader.GetInt32(3);
                    articulo.Categoria.IdCategoriaPadre = datareader.GetInt32(4);
                    articulo.Categoria.Nombre = datareader.GetString(5);
                    articulo.Categoria.Descripcion = datareader.GetString(6);
                    articulo.Categoria.PalabraClave = datareader.GetString(7);
                    articulo.Descripcion = datareader.GetString(8);
                    articulo.PalabrasRelacionArticulo = datareader.GetString(9);
                    articulo.MetaDescripcion = datareader.GetString(10);
                    articulo.MetaKeyWords = datareader.GetString(11);
                    articulo.UnidadVolumen = datareader.GetBoolean(12);
                    articulo.UnidadMasa = datareader.GetBoolean(13);
                    articulo.UnidadLongitud = datareader.GetBoolean(14);
                    articulo.Talla = datareader.GetBoolean(15);
                    articulo.Color = datareader.GetBoolean(16);
                    articulo.ENLinea = datareader.GetBoolean(17);
                    articulo.PreOrdenar = datareader.GetBoolean(18);
                    articulo.Sabor = datareader.GetBoolean(19);
                    articulo.Activo = datareader.GetBoolean(20);
                    articulo.GarantiaMeses = datareader.GetInt32(21);
                    articulo.VideoYoutube = datareader.GetString(22);
                    articulo.UnidadPresentacion = datareader.GetBoolean(23);
                    articulo.Marca.Nombre = datareader.GetString(24);
                    listaArticulo.Add(articulo);
                }

                listaReadOnlyarticulos = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo>(listaArticulo);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyarticulos;
        }

        public ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias)
        {
            List<double> listaArticulos = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<double> listaReadOnlyarticulos = null;

            // Preparar la lista de Ids de categoría para ser pasadas por parametro
            System.Data.DataTable TablaIdsCategorias = new System.Data.DataTable();
            TablaIdsCategorias.Clear();
            TablaIdsCategorias.Columns.Add("Ids", typeof(double));
            foreach (double idCategoria in IdsCategorias)
            {
                System.Data.DataRow nuevaFila = TablaIdsCategorias.NewRow();
                nuevaFila[0] = idCategoria;
                TablaIdsCategorias.Rows.Add(nuevaFila);
            }

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloSelectWebPorListaCategorias";
                cmd.Parameters.AddWithValue("@Ids", TablaIdsCategorias);
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();
                listaArticulos = new List<double>();

                while (datareader.Read())
                {
                    double idArticulo = double.MinValue;
                    idArticulo = datareader.GetInt32(0);
                    listaArticulos.Add(idArticulo);
                }

                listaReadOnlyarticulos = new System.Collections.ObjectModel.ReadOnlyCollection<double>(listaArticulos);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyarticulos;
        }

        public ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticuloUpdateQuitarMarcaActualizar";

                paramIdPresentacionArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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
            }

            return resultadoTransaccion;
        }
    }
}
