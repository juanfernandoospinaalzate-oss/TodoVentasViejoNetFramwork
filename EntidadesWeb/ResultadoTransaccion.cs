// -----------------------------------------------------------------------
// <copyright file="ResultadoTransaccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Contiene el número de registros afectados y los resultados textuales de la transacción.
    /// </summary>
    public class ResultadoTransaccion
    {
        /// <summary>
        /// creación del objeto mensaje de tipo Entidades.Mensaje
        /// </summary>
        private EntidadesWeb.Mensaje mensaje = new EntidadesWeb.Mensaje();

        /// <summary>
        /// Indica el número de registros afectados por la transacción
        /// </summary>
        public int RegistrosAfectados { get; set; }

        /// <summary>
        /// Contiene el mensaje cons los resultados textuales de la transacción
        /// </summary>
        public EntidadesWeb.Mensaje Mensaje 
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
