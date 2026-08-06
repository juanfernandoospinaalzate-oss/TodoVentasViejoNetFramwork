// -----------------------------------------------------------------------
// <copyright file="ExceptionRutaArchivoNotFound.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------
namespace Entidades.Excepciones
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Representa un ExceptionRutaArchivoNotFound 
    /// </summary>
    [Serializable]
    public class ExceptionRutaArchivoNotFound : Exception
    {
        /// <summary>
        /// Primera sobrecarga del método ExceptionRutaArchivoNotFound
        /// </summary>
        public ExceptionRutaArchivoNotFound()
        {
        }

        /// <summary>
        ///  Segunda sobrecarga del método ExceptionRutaArchivoNotFound
        /// </summary>
        /// <param name="mensaje">parámetro mensaje</param>
        public ExceptionRutaArchivoNotFound(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Tercera sobrecarga del método ExceptionRutaArchivoNotFound
        /// </summary>
        /// <param name="mensaje">parámetro mensaje con los datos que se desean enviar</param>
        /// <param name="inner">parámetro inner</param>
        public ExceptionRutaArchivoNotFound(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
        }

        /// <summary>
        /// Cuarta sobrecarga del método ExceptionRutaArchivoNotFound
        /// </summary>
        /// <param name="info">parámetro SerializationInfo</param>
        /// <param name="context">parámetro StreamingContext</param>
        protected ExceptionRutaArchivoNotFound(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
