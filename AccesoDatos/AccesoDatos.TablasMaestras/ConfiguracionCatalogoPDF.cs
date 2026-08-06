//-----------------------------------------------------------------------
// <copyright file="ConfiguracionCatalogoPDF.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    public class ConfiguracionCatalogoPDF : Contratos.IConfiguracionCatalogoPDF
    {
        public Entidades.ConfiguracionCatalogoPDF Consultar()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            Entidades.ConfiguracionCatalogoPDF entidadCatalogo = new Entidades.ConfiguracionCatalogoPDF();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionCatalogoPDFSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();


                if (datareader.Read())
                {
                    entidadCatalogo.Existencias = datareader.GetBoolean(0);
                    entidadCatalogo.Precio = datareader.GetBoolean(1);
                    entidadCatalogo.NroDeColumnas = datareader.GetInt32(2);
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

            return entidadCatalogo;
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            if (catalogo == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramExistencias = null;
            System.Data.SqlClient.SqlParameter paramPrecio = null;
            System.Data.SqlClient.SqlParameter paramNroColumnas = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionCatalogoPDFUpdate";

                paramExistencias = new System.Data.SqlClient.SqlParameter("@existencias", System.Data.SqlDbType.Bit);
                paramExistencias.Value = catalogo.Existencias;
                cmd.Parameters.Add(paramExistencias);

                paramPrecio = new System.Data.SqlClient.SqlParameter("@precio", System.Data.SqlDbType.Bit);
                paramPrecio.Value = catalogo.Precio;
                cmd.Parameters.Add(paramPrecio);

                paramNroColumnas = new System.Data.SqlClient.SqlParameter("@nroDeColumnas", System.Data.SqlDbType.Int);
                paramNroColumnas.Value = catalogo.NroDeColumnas;
                cmd.Parameters.Add(paramNroColumnas);

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

        public Entidades.ResultadoTransaccion Insertar(Entidades.ConfiguracionCatalogoPDF catalogo)
        {
            if (catalogo == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramExistencias = null;
            System.Data.SqlClient.SqlParameter paramPrecio = null;
            System.Data.SqlClient.SqlParameter paramNroColumnas = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionCatalogoPDFInsert";

                paramExistencias = new System.Data.SqlClient.SqlParameter("@existencias", System.Data.SqlDbType.Bit);
                paramExistencias.Value = catalogo.Existencias;
                cmd.Parameters.Add(paramExistencias);

                paramPrecio = new System.Data.SqlClient.SqlParameter("@precio", System.Data.SqlDbType.Bit);
                paramPrecio.Value = catalogo.Precio;
                cmd.Parameters.Add(paramPrecio);

                paramNroColumnas = new System.Data.SqlClient.SqlParameter("@nroDeColumnas", System.Data.SqlDbType.Int);
                paramNroColumnas.Value = catalogo.NroDeColumnas;
                cmd.Parameters.Add(paramNroColumnas);

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
    }
}
