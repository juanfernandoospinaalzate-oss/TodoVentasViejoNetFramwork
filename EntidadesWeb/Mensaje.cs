// -----------------------------------------------------------------------
// <copyright file="Mensaje.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace EntidadesWeb
{
    /// <summary>
    /// Almacena los datos de los mensajes almacenados en la lista de mensajes de la aplicación
    /// </summary>
    public class Mensaje
    {
        /// <summary>
        /// código del mensaje en archivo de mensajes
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// indica el tipo de mensaje especificando la acción que se intentaba
        /// </summary>
        public string TipoMensaje { get; set; }

        /// <summary>
        /// indica la acción que provocó el error, ejemplo (leer un archivo, eliminar un registro)
        /// </summary>
        public string Evento { get; set; }

        /// <summary>
        /// Texto del mensaje que se le puede mostrar al usuario
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Indica  detalles específicos al programador 
        /// </summary>
        public string Detalles { get; set; }
    }
}
