// -----------------------------------------------------------------------
// <copyright file="LinqToXML.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace MensajesWeb
{
    using System.Linq;

    /// <summary>
    /// encargada de leer el archivo XML que contiene los mensajes de la aplicación.
    /// </summary>
    public static class LinqToXml
    {
        /// <summary>
        /// leer el archivo XML que contiene los mensajes de la aplicación.
        /// </summary>
        /// <param name="codigoMensaje">Identificador el mensaje en el archivo XML de origen</param>
        /// <returns>Objeto con los datos del registro tomados del archivo XML</returns>
        public static EntidadesWeb.Mensaje LeerMensaje(string codigoMensaje)
        {
            string rutaArchivo = string.Empty;
            System.Xml.Linq.XDocument documentoXML = null;

            // Leer el documento
            rutaArchivo = System.Configuration.ConfigurationManager.AppSettings["RutaLogs"] + "\\Mensajes.xml";

            // Si el archivo existe, cargarlos
            if (System.IO.File.Exists(rutaArchivo))
            {
                documentoXML = System.Xml.Linq.XDocument.Load(rutaArchivo);
            }
            else 
            {
                // Si no existe el archivo, Dispara un error
                throw new EntidadesWeb.Excepciones.ExceptionRutaArchivoNotFound("No se encuentra o no se puede leer el archivo de mensajes localizado en al ruta " + rutaArchivo);           
            }

           System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> elementoXML = from el in documentoXML.Root.Elements("mensaje")
                          where el.Element("codigo").Value == codigoMensaje
                          select el;

           if (elementoXML.Count() != 0)
           {
               return new EntidadesWeb.Mensaje() 
               { 
                    Codigo = elementoXML.ElementAt(0).Element("codigo").Value,
                    TipoMensaje = elementoXML.ElementAt(0).Element("tipoMensaje").Value,
                    Evento = elementoXML.ElementAt(0).Element("evento").Value,
                    Texto = elementoXML.ElementAt(0).Element("texto").Value,
                    Detalles = elementoXML.ElementAt(0).Element("detalles").Value 
                };
           }
           else
           {
               return null;
           }
        }

        /// <summary>
        /// leer el archivo XML que contiene las etiquetas de los formularios de la aplicación.
        /// </summary>
        /// <param name="codigoEtiqueta">Identificador de la etiqueta  en el archivo XML de origen</param>
        /// <returns>Objeto con los datos del registro tomados del archivo XML</returns>
        public static EntidadesWeb.EtiquetaControles LeerEtiquetaControles(string codigoEtiqueta)
        {
            string rutaArchivo = string.Empty;
            System.Xml.Linq.XDocument documentoXML = null;

            // Leer el documento
            rutaArchivo = System.Configuration.ConfigurationManager.AppSettings["RutaLogs"] + "\\Etiquetas.xml";

            // Si el archivo existe, cargarlos
            if (System.IO.File.Exists(rutaArchivo))
            {
                documentoXML = System.Xml.Linq.XDocument.Load(rutaArchivo);
            }
            else
            {
                // Si no existe el archivo, Dispara un error
                throw new EntidadesWeb.Excepciones.ExceptionRutaArchivoNotFound("No se encuentra o no se puede leer el archivo de mensajes localizado en al ruta " + rutaArchivo);
            }

            System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> elementoXML = from el in documentoXML.Root.Elements("mensaje")
                   where el.Element("Codigo").Value == codigoEtiqueta
                   select el;

            if (elementoXML.Count() != 0)
            {
                return new EntidadesWeb.EtiquetaControles()
                {
                    Codigo = elementoXML.ElementAt(0).Element("Codigo").Value,
                    NombreFormulario = elementoXML.ElementAt(0).Element("NombreFormulario").Value,
                    NombreControl = elementoXML.ElementAt(0).Element("NombreControl").Value,
                    Texto = elementoXML.ElementAt(0).Element("Texto").Value
                };
            }
            else
            {
                return null;
            }
        }


    }
}
