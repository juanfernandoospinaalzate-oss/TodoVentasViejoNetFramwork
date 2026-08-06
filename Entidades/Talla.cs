// -----------------------------------------------------------------------
// <copyright file="Talla.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Entidades
{
    /// <summary>
    /// Representa un Talla de la base de datos
    /// </summary>
    public class Talla
    {
        /// <summary>
        /// Identificación de la Talla en la base de datos.
        /// </summary>          
        public int IdTalla { get; set; }
        
        /// <summary>
        /// Nombre de la Talla
        /// </summary>
        public string Nombre { get; set; }
    }
}
