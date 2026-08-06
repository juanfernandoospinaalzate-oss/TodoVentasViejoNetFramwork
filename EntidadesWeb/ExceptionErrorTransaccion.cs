// -----------------------------------------------------------------------
// <copyright file="ExceptionErrorTransaccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------
namespace EntidadesWeb.Excepciones
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Representa una Exception
    /// </summary>
    [Serializable]
    public class ExceptionErrorTransaccion : Exception
    {
        /// <summary>
        /// Primera sobrecarga del método ExceptionErrorTransacción
        /// </summary>
        public ExceptionErrorTransaccion()
        {
        }

        /// <summary>
        /// Segunda sobrecarga del método ExceptionErrorTransacción
        /// </summary>
        /// <param name="mensaje">parámetro mensaje</param>
        public ExceptionErrorTransaccion(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Tercera sobrecarga del método ExceptionErrorTransacción
        /// </summary>
        /// <param name="mensaje">parámetro mensaje</param>
        /// <param name="inner">parámetro inner</param>
        public ExceptionErrorTransaccion(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
        }

        /// <summary>
        /// Cuarta sobrecarga del método ExceptionErrorTransacción
        /// </summary>
        /// <param name="info">parámetro SerializationInfo</param>
        /// <param name="context">parámetro StreamingContext</param>
        protected ExceptionErrorTransaccion(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
