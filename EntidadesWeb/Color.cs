// -----------------------------------------------------------------------
// <copyright file="color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Representa un color para una entidad con dicha propiedad.
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Identificación del color en la base de datos.
        /// </summary>
        public int IdColor { get; set; }

        /// <summary>
        /// Código del color en formato hexadecimal GRB.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del color
        /// </summary>
        public string Nombre { get; set; }
    }
}
