

namespace WebConfirmacion
{
    using System;

    public partial class ConfirmarTransaccionesPayU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Request.Params["response_code_po"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["response_code_po"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }

            }
 
            if (Request.Params["merchant_id"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["merchant_id"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
 
            if (Request.Params["state_pol"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["state_pol"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
 
            if (Request.Params["risk"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["risk"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
 
            if (Request.Params["reference_sale"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["reference_sale"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["reference_pol"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["reference_pol"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["sign"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["sign"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["extra1"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["extra1"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["extra2"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["extra2"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
 
            if (Request.Params["payment_method"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["payment_method"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["payment_method_type"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["payment_method_type"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["installments_number"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["installments_number"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
 
            if (Request.Params["value"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["value"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["tax"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["tax"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["additional_value"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["additional_value"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["transaction_date"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["transaction_date"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["currency"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["currency"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["email_buyer"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["email_buyer"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["cus"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["cus"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["pse_bank"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["pse_bank"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["test"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["test"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["description"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["description"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["billing_address"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["billing_address"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["shipping_address"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["shipping_address"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["phone"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["phone"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["office_phone"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["office_phone"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["account_number_ach"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["account_number_ach"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["account_type_ach"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["account_type_ach"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["administrative_fee"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["administrative_fee"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["administrative_fee_base"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["administrative_fee_base"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["administrative_fee_tax"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["administrative_fee_tax"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["airline_code"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["airline_code"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["attempts"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["attempts"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["authorization_code"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["authorization_code"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["bank_id"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["bank_id"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["billing_city"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["billing_city"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["billing_country"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["billing_country"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["commision_pol"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["commision_pol"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["commision_pol_currency"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["commision_pol_currency"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["customer_number"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["customer_number"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["date"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["date"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["error_code_bank"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["error_code_bank"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["error_message_bank"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["error_message_bank"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["exchange_rate"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["exchange_rate"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["ip"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["ip"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["nickname_buyer"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["nickname_buyer"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["nickname_seller"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["nickname_seller"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["payment_method_id"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["payment_method_id"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["payment_request_state"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["payment_request_state"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["pseReference1"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["pseReference1"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["pseReference2"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["pseReference2"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["pseReference3"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["pseReference3"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["response_message_pol"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["response_message_pol"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["shipping_city"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["shipping_city"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["shipping_country"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["shipping_country"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["transaction_bank_id"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["transaction_bank_id"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["transaction_id"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["transaction_id"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }

            if (Request.Params["payment_method_name"] != null)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlDataReader datareader = null;
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

                try
                {
                    cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [dbo].[Prueba]([variable],[valor])VALUES('response_code_po', '" + Request.Params["payment_method_name"].ToString() + "')";
                    datareader = cmd.ExecuteReader();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                catch (Entidades.Excepciones.ExceptionErrorTransaccion)
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
        }
    }
}