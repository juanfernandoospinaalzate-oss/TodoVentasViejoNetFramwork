// -----------------------------------------------------------------------
// <copyright file="ErrorGeneral.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace Logging
{
    using System;

    /// <summary>
    /// Encargado de escribir el archivo XML de Log de acciones
    /// </summary>
    public static class ErrorGeneral
    {
        /// <summary>
        /// Almacena en el Log de errores los detalles pasados por parámetro
        /// </summary>
        /// <param name="excepcion">Excepción con los detalles a guardar</param>
        public static void Guardar(System.Data.SqlClient.SqlException excepcion)
        {
            string datosExcepcion = string.Empty;

            if (excepcion != null)
            {
                datosExcepcion = "Número de error: " + excepcion.Number;
                datosExcepcion += "\nFuente: " + excepcion.Source;
                datosExcepcion += "\nServidor: " + excepcion.Server;
                datosExcepcion += "\nProcedimiento Almacenado: " + excepcion.Procedure;
                datosExcepcion += "\nMensaje: " + excepcion.Message;
                datosExcepcion += "\nPila de seguimiento: " + excepcion.StackTrace;
            }

            LinqToXml.Guardar(datosExcepcion, TipoLog.LogErrores);
        }

        /// <summary>
        /// Almacena en el Log de errores los detalles pasados por parámetro
        /// </summary>
        /// <param name="excepcion">Excepción con los detalles a guardar</param>
        public static void Guardar(Exception excepcion)
        {
            string datosExcepcion = string.Empty;

            if (excepcion != null)
            {
                datosExcepcion += "\nFuente: " + excepcion.Source;
                datosExcepcion += "\nMensaje: " + excepcion.Message;
                datosExcepcion += "\nPila de seguimiento: " + excepcion.StackTrace;
            }

            LinqToXml.Guardar(datosExcepcion, TipoLog.LogErrores);
        }
    }
}
