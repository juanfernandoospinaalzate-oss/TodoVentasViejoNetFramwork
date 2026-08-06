//-----------------------------------------------------------------------
// <copyright file="MediosDePagoPayU.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;
    using System.Text;

    public class MediosDePagoPayU : Contratos.IMediosDEPagoPayU
    {

        public static bool ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string LeerArchivoXML(Entidades.Enumeraciones.FuncionPayU funcionPayU)
        {
            string rutaArchivo = string.Empty;
            System.Xml.Linq.XDocument documentoXML = null;

            switch (funcionPayU)
            {
                case Entidades.Enumeraciones.FuncionPayU.ListarFranquiciasDisponibles:
                    rutaArchivo = System.Configuration.ConfigurationManager.AppSettings["RutaXmlPayU"] + "\\ListarFranquiciasDisponibles.xml";
                    break;
                default:
                    break;
            }

            // Leer el documento
            // Si el archivo existe, cargarlos
            if (System.IO.File.Exists(rutaArchivo))
            {
                documentoXML = System.Xml.Linq.XDocument.Load(rutaArchivo);
            }
            else
            {
                // Si no existe el archivo, Dispara un error
                throw new Entidades.Excepciones.ExceptionRutaArchivoNotFound("No se encuentra o no se puede leer el archivo de mensajes localizado en al ruta " + rutaArchivo);
            }

            return documentoXML.ToString();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTodasLasFranquicias()
        {
            // Se crea un delegado para aprobar el certificado cuando se realize la peticion
            System.Net.Security.RemoteCertificateValidationCallback remoteCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
            System.Net.ServicePointManager.ServerCertificateValidationCallback += remoteCallback;
            // System.Net.CredentialCache cache = new System.Net.CredentialCache(); //Credencial vacia
            // ----------------------------------
            System.Net.HttpWebResponse httpResponse = null;
            System.IO.Stream stream = null;
            // Parametros del POST
            string paramsPost = string.Empty;
            // Agregar el certificado que se utilizara en formato DER binario codificado X.509
            System.Security.Cryptography.X509Certificates.X509Certificate certificate = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile("C:\\todo_ventas_colombia\\localhost.crt");


            paramsPost = LeerArchivoXML(Entidades.Enumeraciones.FuncionPayU.ListarFranquiciasDisponibles);

            // ------------------paramsPost = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><request><language>en</language><command>PING</command><merchant><apiLogin>84b53b4a596f1f8</apiLogin><apiKey>3ol3jugmkgrvgi5mqmkf3bquia</apiKey></merchant><isTest>false</isTest></request>";
            // paramsPost = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><request><language>en</language><command>PING</command><merchant><apiLogin>11959c415b33d0c</apiLogin><apiKey>6u39nqhq8ftd0hlvnjfs66eh8c</apiKey></merchant><isTest>false</isTest></request>";


            // Pagina que resolvera el post
            // System.Net.HttpWebRequest httpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://stg.api.payulatam.com/reports-api/4.0/service.cgi");
            System.Net.HttpWebRequest httpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://api.payulatam.com/payments-api/4.0/service.cgi");
            // Parametros del POST
            httpRequest.ClientCertificates.Add(certificate);
            httpRequest.ContentType = "application/xml";
            httpRequest.Method = "POST";
            httpRequest.UserAgent = "Client Cert Sample";
            httpRequest.ContentLength = paramsPost.Length;
            stream = httpRequest.GetRequestStream();
            // Se escribe la peticion con codificacion windows-1252 para realizar el Post sobre un archivo crt
            stream.Write(Encoding.GetEncoding(1252).GetBytes(paramsPost), 0, paramsPost.Length);
            stream.Close();
            httpResponse = (System.Net.HttpWebResponse)httpRequest.GetResponse();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream());
            // Convierte el resultado obtenido en un string
            char[] readBuff = new char[256];
            int count = streamReader.Read(readBuff, 0, 256);
            string outputData = string.Empty;

            while (count > 0)
            {
                string temp = new string(readBuff, 0, count);
                outputData += temp;
                count = streamReader.Read(readBuff, 0, 256);
            }
            //---------------------------------------------
            // Liberamos el delegado para no seguir atrapando los SSL en la funcion
            System.Net.ServicePointManager.ServerCertificateValidationCallback -= remoteCallback;
            // -----------------------------------------------------------------

            System.Xml.Linq.XDocument xmlDoc = System.Xml.Linq.XDocument.Parse(outputData);
            System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> ListaFranquiciasDisponibles = xmlDoc.Element("paymentMethodsResponse").Element("paymentMethods").Elements("paymentMethodComplete");
            System.Collections.Generic.List<Entidades.Franquicia> ListaResultadoFranquicias = new List<Entidades.Franquicia>();

            foreach (System.Xml.Linq.XElement elemento in ListaFranquiciasDisponibles)
            {

                if (elemento.Element("country").Value.ToString() == "CO")
                {
                    Entidades.Franquicia franquicia = new Entidades.Franquicia();
                    franquicia.IdPayU = int.Parse(elemento.Element("id").Value);
                    franquicia.Descripcion = elemento.Element("description").Value;
                    ListaResultadoFranquicias.Add(franquicia);
                }
            }

            return new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia>(ListaResultadoFranquicias);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTarjetasDeCreditoConfiguradas()
        {
            List<Entidades.Franquicia> TarjetasDeCreditoConfiguradas = new List<Entidades.Franquicia>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTarjetasDeCreditoConfiguradas = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarjetaCreditoPayUSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Franquicia TarjetasDeCredito = new Entidades.Franquicia();
                    TarjetasDeCredito.Id = datareader.GetInt32(0);
                    TarjetasDeCredito.IdPayU = datareader.GetInt32(1);
                    TarjetasDeCredito.Descripcion = datareader.GetString(2);
                    TarjetasDeCreditoConfiguradas.Add(TarjetasDeCredito);
                }

                ListarTarjetasDeCreditoConfiguradas = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia>(TarjetasDeCreditoConfiguradas);
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

            return ListarTarjetasDeCreditoConfiguradas;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarMediosEnEfectivoConfigurados()
        {
            List<Entidades.Franquicia> MediosEnEfectivoConfigurados = new List<Entidades.Franquicia>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarMediosEnEfectivoConfigurados = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MedioPagoEfectivoPayUSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Franquicia MedioPagoEfectivo = new Entidades.Franquicia();
                    MedioPagoEfectivo.Id = datareader.GetInt32(0);
                    MedioPagoEfectivo.IdPayU = datareader.GetInt32(1);
                    MedioPagoEfectivo.Descripcion = datareader.GetString(2);
                    MediosEnEfectivoConfigurados.Add(MedioPagoEfectivo);
                }

                ListarMediosEnEfectivoConfigurados = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia>(MediosEnEfectivoConfigurados);
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

            return ListarMediosEnEfectivoConfigurados;
        }

        public Entidades.ResultadoTransaccion InsertarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramIdPayU = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarjetaCreditoPayUInsert";
                paramIdPayU = new System.Data.SqlClient.SqlParameter("@IdPayU", System.Data.SqlDbType.Int);
                paramIdPayU.Value = franquicia.IdPayU;
                cmd.Parameters.Add(paramIdPayU);
                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 60);
                paramDescripcion.Value = franquicia.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

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

        public Entidades.ResultadoTransaccion InsertarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramIdPayU = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MedioPagoEfectivoPayUInsert";
                paramIdPayU = new System.Data.SqlClient.SqlParameter("@IdPayU", System.Data.SqlDbType.Int);
                paramIdPayU.Value = franquicia.IdPayU;
                cmd.Parameters.Add(paramIdPayU);
                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 60);
                paramDescripcion.Value = franquicia.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

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

        public Entidades.ResultadoTransaccion EliminarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramTarjetaCreditoPayUDelete = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TarjetaCreditoPayUDelete";

                paramTarjetaCreditoPayUDelete = new System.Data.SqlClient.SqlParameter("@IdPayU", System.Data.SqlDbType.Int);
                paramTarjetaCreditoPayUDelete.Value = franquicia.IdPayU;
                cmd.Parameters.Add(paramTarjetaCreditoPayUDelete);

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

        public Entidades.ResultadoTransaccion EliminarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramMedioEnEfectivoIdPayU = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MedioPagoEfectivoPayUDelete";

                paramMedioEnEfectivoIdPayU = new System.Data.SqlClient.SqlParameter("@IdPayU", System.Data.SqlDbType.Int);
                paramMedioEnEfectivoIdPayU.Value = franquicia.IdPayU;
                cmd.Parameters.Add(paramMedioEnEfectivoIdPayU);

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
