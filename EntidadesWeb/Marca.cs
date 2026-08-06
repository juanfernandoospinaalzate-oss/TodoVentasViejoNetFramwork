// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Representa un Marca de la base de datos
    /// </summary>
    public class Marca
    {
        /// <summary>
        /// Identificación de la Marca en la base de datos.
        /// </summary> 
        public int IdMarca { get; set; }
        
        /// <summary>
        /// Nombre de la Marca
        /// </summary>
        public string Nombre { get; set; }
    }
}
