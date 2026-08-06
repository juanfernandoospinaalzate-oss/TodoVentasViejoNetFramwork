//-----------------------------------------------------------------------
// <copyright file="Pais.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    public class Pais : Contratos.IPais
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais)
        {
            if (pais == null)
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
                cmd.CommandText = "PaisInsert";
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 20);
                paramNombre.Value = pais.Nombre;
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


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar()
        {
            List<Entidades.Pais> Pais = new List<Entidades.Pais>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> listaReadOnlyPais = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PaisSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Pais pais = new Entidades.Pais()
                    {
                        IdPais = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    Pais.Add(pais);
                }

                listaReadOnlyPais = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais>(Pais);
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

            return listaReadOnlyPais;
        }



        public Entidades.ResultadoTransaccion Eliminar(int idpais)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PaisDelete";

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = idpais;
                cmd.Parameters.Add(paramIdPais);

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


        public bool PaisVerificarRelacionDpto(int idpais)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PaisVerificarRelacionDpto";
                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);

                paramIdPais.Value = idpais;
                cmd.Parameters.Add(paramIdPais);

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
