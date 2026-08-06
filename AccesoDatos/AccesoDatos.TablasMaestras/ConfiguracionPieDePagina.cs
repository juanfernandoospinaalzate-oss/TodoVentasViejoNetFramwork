//-----------------------------------------------------------------------
// <copyright file="ConfiguracionPieDePagina.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;

    public class ConfiguracionPieDePagina : Contratos.IConfiguracionPieDePagina
    {
        public ResultadoTransaccion Actualizar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            if (PieDePagina == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramId = null;
            System.Data.SqlClient.SqlParameter paramAtencionSkype = null;
            System.Data.SqlClient.SqlParameter paramLineaTelefonica = null;
            System.Data.SqlClient.SqlParameter paramLineaCelular = null;
            System.Data.SqlClient.SqlParameter paramCorreoElectronico = null;
            System.Data.SqlClient.SqlParameter paramDevoluciones = null;
            System.Data.SqlClient.SqlParameter paramComoPagar = null;
            System.Data.SqlClient.SqlParameter paramEnvios = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionPieDePaginaUpdate";

                paramId = new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int);
                paramId.Value = PieDePagina.Id;
                cmd.Parameters.Add(paramId);

                paramAtencionSkype = new System.Data.SqlClient.SqlParameter("@AtencionSkype", System.Data.SqlDbType.NVarChar, 4000);
                paramAtencionSkype.Value = PieDePagina.AtencionSkype;
                cmd.Parameters.Add(paramAtencionSkype);

                paramLineaTelefonica = new System.Data.SqlClient.SqlParameter("@LineaTelefonica", System.Data.SqlDbType.NVarChar, 4000);
                paramLineaTelefonica.Value = PieDePagina.LineaTelefonica;
                cmd.Parameters.Add(paramLineaTelefonica);

                paramLineaCelular = new System.Data.SqlClient.SqlParameter("@LineaCelular", System.Data.SqlDbType.NVarChar, 4000);
                paramLineaCelular.Value = PieDePagina.LineaCelular;
                cmd.Parameters.Add(paramLineaCelular);

                paramCorreoElectronico = new System.Data.SqlClient.SqlParameter("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 4000);
                paramCorreoElectronico.Value = PieDePagina.CorreoElectronico;
                cmd.Parameters.Add(paramCorreoElectronico);

                paramDevoluciones = new System.Data.SqlClient.SqlParameter("@Devoluciones", System.Data.SqlDbType.NVarChar, 4000);
                paramDevoluciones.Value = PieDePagina.Devoluciones;
                cmd.Parameters.Add(paramDevoluciones);

                paramComoPagar = new System.Data.SqlClient.SqlParameter("@ComoPagar", System.Data.SqlDbType.NVarChar, 4000);
                paramComoPagar.Value = PieDePagina.ComoPagar;
                cmd.Parameters.Add(paramComoPagar);

                paramEnvios = new System.Data.SqlClient.SqlParameter("@Envios", System.Data.SqlDbType.NVarChar, 4000);
                paramEnvios.Value = PieDePagina.Envios;
                cmd.Parameters.Add(paramEnvios);



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

        public ResultadoTransaccion Insertar(Entidades.ConfiguracionPieDePagina PieDePagina)
        {
            if (PieDePagina == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;           
            System.Data.SqlClient.SqlParameter paramAtencionSkype = null;
            System.Data.SqlClient.SqlParameter paramLineaTelefonica = null;
            System.Data.SqlClient.SqlParameter paramLineaCelular = null;
            System.Data.SqlClient.SqlParameter paramCorreoElectronico = null;
            System.Data.SqlClient.SqlParameter paramDevoluciones = null;
            System.Data.SqlClient.SqlParameter paramComoPagar = null;
            System.Data.SqlClient.SqlParameter paramEnvios = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionPieDePaginaInsert";

                paramAtencionSkype = new System.Data.SqlClient.SqlParameter("@AtencionSkype", System.Data.SqlDbType.NVarChar, 4000); 
                paramAtencionSkype.Value = PieDePagina.AtencionSkype;
                cmd.Parameters.Add(paramAtencionSkype);

                paramLineaTelefonica = new System.Data.SqlClient.SqlParameter("@LineaTelefonica", System.Data.SqlDbType.NVarChar, 4000); 
                paramLineaTelefonica.Value = PieDePagina.LineaTelefonica;
                cmd.Parameters.Add(paramLineaTelefonica);

                paramLineaCelular = new System.Data.SqlClient.SqlParameter("@LineaCelular", System.Data.SqlDbType.NVarChar, 4000); 
                paramLineaCelular.Value = PieDePagina.LineaCelular;
                cmd.Parameters.Add(paramLineaCelular);

                paramCorreoElectronico = new System.Data.SqlClient.SqlParameter("@CorreoElectronico", System.Data.SqlDbType.NVarChar, 4000); 
                paramCorreoElectronico.Value = PieDePagina.CorreoElectronico;
                cmd.Parameters.Add(paramCorreoElectronico);

                paramDevoluciones = new System.Data.SqlClient.SqlParameter("@Devoluciones", System.Data.SqlDbType.NVarChar, 4000); 
                paramDevoluciones.Value = PieDePagina.Devoluciones;
                cmd.Parameters.Add(paramDevoluciones);

                paramComoPagar = new System.Data.SqlClient.SqlParameter("@ComoPagar", System.Data.SqlDbType.NVarChar, 4000); 
                paramComoPagar.Value = PieDePagina.ComoPagar;
                cmd.Parameters.Add(paramComoPagar);

                paramEnvios = new System.Data.SqlClient.SqlParameter("@Envios", System.Data.SqlDbType.NVarChar, 4000); 
                paramEnvios.Value = PieDePagina.Envios;
                cmd.Parameters.Add(paramEnvios);



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

        public ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> Listar()
        {
            List<Entidades.ConfiguracionPieDePagina> ListaConfiguracionPieDePagina = new List<Entidades.ConfiguracionPieDePagina>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> listaReadOnlyConfiguracionPieDePagina = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionPieDePaginaSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.ConfiguracionPieDePagina PieDePagina = new Entidades.ConfiguracionPieDePagina()
                    {
                        Id = datareader.GetInt32(0),
                        AtencionSkype = datareader.GetString(1),
                        LineaTelefonica = datareader.GetString(2),
                        LineaCelular = datareader.GetString(3),
                        CorreoElectronico = datareader.GetString(4),
                        Devoluciones = datareader.GetString(5),
                        ComoPagar = datareader.GetString(6),
                        Envios = datareader.GetString(7)
                    };
                    ListaConfiguracionPieDePagina.Add(PieDePagina);
                }

                listaReadOnlyConfiguracionPieDePagina = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionPieDePagina>(ListaConfiguracionPieDePagina);                
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
            return listaReadOnlyConfiguracionPieDePagina;
        }
    }
}
