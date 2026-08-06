// -----------------------------------------------------------------------
// <copyright file="ResultadoTransaccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Entidades
{
    /// <summary>
    /// Contiene el número de registros afectados y los resultados textuales de la transacción.
    /// </summary>
    public class ResultadoTransaccion
    {
        /// <summary>
        /// creación del objeto mensaje de tipo Entidades.Mensaje
        /// </summary>
        private Entidades.Mensaje mensaje = new Entidades.Mensaje();

        /// <summary>
        /// Indica el número de registros afectados por la transacción
        /// </summary>
        public int RegistrosAfectados { get; set; }

        /// <summary>
        /// Contiene el mensaje con los resultados textuales de la transacción
        /// </summary>
        public Entidades.Mensaje Mensaje 
        {
            get
            {
                return this.mensaje;
            }

            set
            {
                this.mensaje = value;
            }
        }

        /// <summary>
        /// contiene el mensaje para tipos de mensajes no comunes 
        /// </summary>
        public object ValorAuxiliar { get; set; }
    }
}
