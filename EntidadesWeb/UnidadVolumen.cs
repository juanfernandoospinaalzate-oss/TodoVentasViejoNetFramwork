// -----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Representa un Unidad de volúmen para una entidad con dicha propiedad.
    /// </summary>
    public class UnidadVolumen
    {
        /// <summary>
        /// Identificación de la unidad de volúmen en la base de datos.
        /// </summary>
        public int IdUnidadVolumen { get; set; }

        /// <summary>
        /// Nombre de la unidad de volúmen
        /// </summary>
        public string Nombre { get; set; }
    }
}
