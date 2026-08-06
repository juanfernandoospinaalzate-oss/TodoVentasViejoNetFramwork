//-----------------------------------------------------------------------
// <copyright file="TarifasDomicilio.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;

    public class TarifasDomicilio : Contratos.ITarifasDomicilio
    {
        public ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            if (tarifasDomicilio == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdTarifasDomicilio = null;
            System.Data.SqlClient.SqlParameter paramTarifaDomicilioNuevo = null;
            System.Data.SqlClient.SqlParameter paramValorDomicilio = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarifasDomicilioUpdate";

                paramIdTarifasDomicilio = new System.Data.SqlClient.SqlParameter("@IdTarifasDomicilio", System.Data.SqlDbType.Int);
                paramIdTarifasDomicilio.Value = tarifasDomicilio.IdTarifasDomicilio;
                cmd.Parameters.Add(paramIdTarifasDomicilio);

                paramTarifaDomicilioNuevo = new System.Data.SqlClient.SqlParameter("@TarifaDomicilioNuevo", System.Data.SqlDbType.NVarChar, 50);
                paramTarifaDomicilioNuevo.Value = tarifasDomicilio.TarifaDomicilioNuevo;
                cmd.Parameters.Add(paramTarifaDomicilioNuevo);

                paramValorDomicilio = new System.Data.SqlClient.SqlParameter("@ValorDomicilio", System.Data.SqlDbType.Int);
                paramValorDomicilio.Value = tarifasDomicilio.ValorDomicilio;
                cmd.Parameters.Add(paramValorDomicilio);

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

        public ResultadoTransaccion Eliminar(int idtarifasDomicilio)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdTarifasDomicilio = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarifasDomicilioDelete";

                paramIdTarifasDomicilio = new System.Data.SqlClient.SqlParameter("@IdTarifasDomicilio", System.Data.SqlDbType.Int);
                paramIdTarifasDomicilio.Value = idtarifasDomicilio;
                cmd.Parameters.Add(paramIdTarifasDomicilio);

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

        public ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            if (tarifasDomicilio == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramTarifaDomicilioNuevo = null;
            System.Data.SqlClient.SqlParameter paramValorTarifaDomicilioNuevo = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarifasDomicilioInsert";

                paramTarifaDomicilioNuevo = new System.Data.SqlClient.SqlParameter("@TarifaDomicilioNuevo", System.Data.SqlDbType.NVarChar, 50);
                paramTarifaDomicilioNuevo.Value = tarifasDomicilio.TarifaDomicilioNuevo;
                cmd.Parameters.Add(paramTarifaDomicilioNuevo);

                paramValorTarifaDomicilioNuevo = new System.Data.SqlClient.SqlParameter("@ValorDomicilio", System.Data.SqlDbType.Float);
                paramValorTarifaDomicilioNuevo.Value = tarifasDomicilio.ValorDomicilio;
                cmd.Parameters.Add(paramValorTarifaDomicilioNuevo);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
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

        public ReadOnlyCollection<Entidades.TarifasDomicilio> Listar()
        {
            List<Entidades.TarifasDomicilio> ListaTarifasDomicilio = new List<Entidades.TarifasDomicilio>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.TarifasDomicilio> listaReadOnlyTarifasDomicilio = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarifasDomicilioSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.TarifasDomicilio tfDomicilio = new Entidades.TarifasDomicilio()
                    {
                        IdTarifasDomicilio = datareader.GetInt32(0),
                        TarifaDomicilioNuevo = datareader.GetString(1),
                        ValorDomicilio = datareader.GetDouble(2)
                    };
                    ListaTarifasDomicilio.Add(tfDomicilio);
                }

                listaReadOnlyTarifasDomicilio = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.TarifasDomicilio>(ListaTarifasDomicilio);
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

            return listaReadOnlyTarifasDomicilio;
        }
    }
}
