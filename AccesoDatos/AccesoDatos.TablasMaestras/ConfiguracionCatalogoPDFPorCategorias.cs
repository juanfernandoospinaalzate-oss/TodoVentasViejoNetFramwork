//-----------------------------------------------------------------------
// <copyright file="ConfiguracionCatalogoPDFPorCategorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    public class ConfiguracionCatalogoPDFPorCategorias : Contratos.IConfiguracionCatalogoPDFPorCategorias
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPorCategorias configuracionCatalogoPorCategorias)
        {
            if (configuracionCatalogoPorCategorias == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdCategoria = null;
            System.Data.SqlClient.SqlParameter paramNroColumnasPorCategorias = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionCatalogoPDFPorCategoriasInsert";

                paramIdCategoria = new System.Data.SqlClient.SqlParameter("@IdCategoria", System.Data.SqlDbType.Int);
                paramIdCategoria.Value = configuracionCatalogoPorCategorias.Categoria.IdCategoria;
                cmd.Parameters.Add(paramIdCategoria);

                paramNroColumnasPorCategorias = new System.Data.SqlClient.SqlParameter("@NroColumnas", System.Data.SqlDbType.Int);
                paramNroColumnasPorCategorias.Value = configuracionCatalogoPorCategorias.NroColumnas;
                cmd.Parameters.Add(paramNroColumnasPorCategorias);

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

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> Consultar()
        {
            List<Entidades.ConfiguracionCatalogoPorCategorias> listaCatalogo = new List<Entidades.ConfiguracionCatalogoPorCategorias>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias> listaReadOnlyConfiguracionCatalogoPorCategorias = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionCatalogoPDFPorCategoriasSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.ConfiguracionCatalogoPorCategorias catalogo = new Entidades.ConfiguracionCatalogoPorCategorias();
                    catalogo.Categoria = new Entidades.Categoria();

                    catalogo.Categoria.IdCategoria = datareader.GetInt32(0);
                    catalogo.NroColumnas = datareader.GetInt32(1);
                    catalogo.Categoria.Nombre = datareader.GetString(2);

                    listaCatalogo.Add(catalogo);
                }

                listaReadOnlyConfiguracionCatalogoPorCategorias = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionCatalogoPorCategorias>(listaCatalogo);
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

            return listaReadOnlyConfiguracionCatalogoPorCategorias;
        }

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
                cmd.CommandText = "ConfiguracionCatalogoPDFPorCategoriasDelete";

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
    }
}
