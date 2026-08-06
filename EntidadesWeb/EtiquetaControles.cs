// -----------------------------------------------------------------------
// <copyright file="EtiquetaControles.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------
namespace EntidadesWeb
{
    /// <summary>
    /// Almacena los datos de los mensajes almacenados en la lista de mensajes de la aplicación
    /// </summary>
    public class EtiquetaControles
    {
        /// <summary>
        /// código del mensaje en archivo de mensajes
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// indica el nombre del formulario en la aplicación
        /// </summary>
        public string NombreFormulario { get; set; }

        /// <summary>
        /// indica el nombre del control en el formulario
        /// </summary>
        public string NombreControl { get; set; }

        /// <summary>
        /// Texto del mensaje que se le puede mostrar al usuario
        /// </summary>
        public string Texto { get; set; }
    }
}
