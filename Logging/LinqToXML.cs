// -----------------------------------------------------------------------
// <copyright file="LinqToXML.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace Logging
{
    using System;

    /// <summary>
    /// Indica el archivo de log en el que se guarda
    /// </summary>
    public enum TipoLog
    {
        /// <summary>
        /// Guardar en el archivo de acciones de la aplicación
        /// </summary>
        LogAcciones = 0,

        /// <summary>
        /// Guardar en el archivo de errores de la aplicación
        /// </summary>
        LogErrores = 1,
    }

    /// <summary>
    /// Encargado de escribir los archivos XML de Log de acciones y de Errores
    /// </summary>
    public static class LinqToXml
    {
        /// <summary>
        /// Escribe el archivo de log según el tipo de log pasado por parámetro.
        /// </summary>
        /// <param name="detalles">Detalles del registro que se guarda</param>
        /// <param name="tipoLog">indica el tipo de log</param>
        public static void Guardar(string detalles, TipoLog tipoLog)
        {
            string nombreArchivo = string.Empty;
            string rutaArchivo = string.Empty;
            string nombreElementoRaiz = string.Empty;
            string nombreElementoSecundadrio = string.Empty;
            System.Xml.Linq.XDocument documentoXML = null;
            System.Xml.Linq.XElement elementoXML = null;

            // Elegir el nombre del archivo sobre el que se trabajará
            switch (tipoLog)
            {
                case TipoLog.LogAcciones:
                    nombreArchivo = "LogAcciones.xml";
                    nombreElementoRaiz = "acciones";
                    nombreElementoSecundadrio = "accion";
                    break;
                case TipoLog.LogErrores:
                    nombreArchivo = "LogErrores.xml";
                    nombreElementoRaiz = "errores";
                    nombreElementoSecundadrio = "error";
                    break;
            }

            // Leer el documento
            rutaArchivo = System.Configuration.ConfigurationManager.AppSettings["RutaLogs"] + "\\" + nombreArchivo;

            // Si el archivo existe, cargarlos
            if (System.IO.File.Exists(rutaArchivo))
            {
                documentoXML = System.Xml.Linq.XDocument.Load(rutaArchivo);
            }
            else 
            {
                // Si no existe el archivo, crearlo
                // Crear un documento nuevo y añadir un elemento raíz
                documentoXML = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement(nombreElementoRaiz));
            }

            elementoXML = new System.Xml.Linq.XElement(nombreElementoSecundadrio, new System.Xml.Linq.XAttribute("fechaHora", DateTime.Now.ToString()));
            elementoXML.Value = detalles;

            documentoXML.Element(nombreElementoRaiz).Add(elementoXML);

            documentoXML.Save(rutaArchivo);
        }
    }
}
