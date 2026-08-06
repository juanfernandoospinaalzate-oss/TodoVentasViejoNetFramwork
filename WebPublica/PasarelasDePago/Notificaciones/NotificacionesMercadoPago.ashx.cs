

namespace WebPublica.PasarelasDePago.Notificaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Summary description for NotificacionesMercadoPago
    /// </summary>
    public class NotificacionesMercadoPago : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                // Obtener todas las variables y sus valores de la solicitud
                Dictionary<string, string> variables = new Dictionary<string, string>();
                foreach (string key in context.Request.Form.AllKeys)
                {
                    string value = context.Request.Form[key];
                    variables.Add(key, value);
                }

                // Guardar los valores en un archivo de texto en C:\
                string filePath = System.Configuration.ConfigurationManager.AppSettings["RutaLogs"] + "\\notificacion.txt";
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath);
                foreach (var entry in variables)
                {
                    writer.WriteLine(entry.Key + ": " + entry.Value);
                }

                // Asegurarse de cerrar el recurso StreamWriter
                writer.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            // context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}